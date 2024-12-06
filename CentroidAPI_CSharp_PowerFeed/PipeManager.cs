using CentroidAPI;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CentroidAPI.CNCPipe.Dro;
using static CentroidAPI.CNCPipe.Plc;
using static CentroidAPI.CNCPipe;

namespace CentroidAPI_CSharp_PowerFeed
{
    internal class PipeManager
    {
        // our pipe holder
        private CNCPipe m_pipe;

        /// <summary>
        /// Class constructor, creates new pipe for communicating with CNC12
        /// </summary>
        public PipeManager()
        {
            // when we initialize a new pipe manager, give it a new pipe
            m_pipe = new CNCPipe();
        }

        /// <summary>
        /// Gets the currently active cnc pipe
        /// </summary>
        /// <returns>Returns the currently active cnc pipe</returns>
        public CNCPipe Pipe
        {
            get
            {
                // return our pipe holder
                return m_pipe;
            }
            set
            {
                // assign the set value to our pipe holder
                m_pipe = value;
            }
        }

        /// <summary>
        /// This function checks to see if any of our known processes are running, then extracts the working directory from the process
        /// </summary>
        /// <returns>The directory our current version of CNC12 (Normal, or Offline) is running from</returns>
        public string GetCNC12WorkingDirectory()
        {
            // Define the list of process names to check
            string[] processNames = { "cncm", "cnct", "cncr", "cncp", "MillDemo", "LatheDemo" };

            Process[] allProcesses = Process.GetProcesses();
            foreach (string processName in processNames)
            {
                // Get all processes with the specified name
                Process[] processes = Process.GetProcessesByName(processName);

                // Loop through each instance of the process
                foreach (Process proc in processes)
                {
                    try
                    {
                        if (proc != null) { 
                            // Attempt to get the executable path and working directory
                            string executablePath = proc.MainModule.FileName ?? "";
                            string workingDirectory = Path.GetDirectoryName(executablePath) ?? "";
                            return workingDirectory;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            // return default directory if we failed for some reason
            return "C:\\cncm";
        }

        /// <summary>
        /// Checks the connection status of the CNC12 pipe and tries to recreate it when it fails. 
        /// </summary>
        /// <returns>True if connected to CNC12 Pipe; False otherwise.</returns>
        public bool ConnectedToCNC12()
        {
            try { 
                if (m_pipe != null && m_pipe.IsConstructed())
                {
                    double paramValue = 0;
                    var param = new CentroidAPI.CNCPipe.Parameter(m_pipe);
                    CNCPipe.ReturnCode returnCode = param.GetMachineParameterValue(1, out paramValue);

                    switch (returnCode)
                    {
                        case CNCPipe.ReturnCode.SUCCESS:
                            // Successfully connected to CNC12
                            return true;
                        case CNCPipe.ReturnCode.ERROR_PIPE_IS_BROKEN:
                            // Recreate the pipe if it is broken
                            m_pipe = new CNCPipe();
                            break;
                        case CNCPipe.ReturnCode.ERROR_CLIENT_LOCKED:
                            // Client locked means we are still connected but the client is locked, don't treat this as a disconnection
                            return true;
                        default:
                            // Any other error means disconnection
                            return false;
                    }
                }
                else
                {
                    // Pipe is not constructed; try to recreate it
                    m_pipe = new CNCPipe();
                }
            } catch (Exception) { 
                
            }
            // Return false if connection is not established or we failed the try catch
            return false;
        }

        /// <summary>
        /// This function checks the PLC to see if a program is running
        /// </summary>
        /// <returns>Returns true if program is running per pc system variable bit</returns>
        public bool IsRunningJob()
        {
            if (ConnectedToCNC12())
            {
                var CNCPLC = new CentroidAPI.CNCPipe.Plc(m_pipe);
                CentroidAPI.CNCPipe.Plc.IOState programRunning;
                CNCPLC.GetPcSystemVariableBit(PcToMpuSysVarBit.SV_PROGRAM_RUNNING, out programRunning);

                switch (programRunning)
                {
                    case IOState.IO_LOGICAL_0:
                        // return false if we aren't running a job
                        return false;
                    case IOState.IO_LOGICAL_1:
                        // return true if we are running a job
                        return true;
                    case IOState.IO_STATE_UNKNOWN:
                        // return true for safety
                        return true;
                }
            }
            // return false because we're not connected
            return false;
        }


        // ------------------------------------------------------------------------------------------- //
        // This section below includes samples to help you accomplish your goals using the CentroidAPI //
        // ------------------------------------------------------------------------------------------- //



        /// <summary>
        /// Loads a job into CNC12 but does not start the job.
        /// </summary>
        /// <param name="jobLocation">The full or relative path of the file</param>
        /// <returns>Returns a ReturnCode</returns>
        public CNCPipe.ReturnCode LoadJob(string jobLocation)
        {
            // Check that the file exists and that we are connected to CNC12
            if (File.Exists(jobLocation))
            {
                if (ConnectedToCNC12())
                {
                    var cmd = new CentroidAPI.CNCPipe.Job(m_pipe);
                    // Return the return code for Load, check it for SUCCESS
                    return cmd.Load(jobLocation, GetCNC12WorkingDirectory());
                }
                else
                {
                    // Warn that we aren't connected to CNC12
                    System.Windows.Forms.MessageBox.Show("Error: Not Connected to CNC12");
                    return CNCPipe.ReturnCode.ERROR_SEND_COMMAND;
                }
            }
            else
            {
                // Warn that file not found
                System.Windows.Forms.MessageBox.Show("Error: Job File Not Found");
                return CNCPipe.ReturnCode.ERROR_SEND_COMMAND;
            }
        }

        /// <summary>
        /// Uses Skinning Events to emulate cycle start, warning: this will start the job if CNC12 is on a screen that allows cycle start. 
        /// Use with Caution. Operators should have to press cycle start to begin machine motion.
        /// </summary>
        /// <returns>Returns a ReturnCode</returns>
        public CNCPipe.ReturnCode RunJob()
        {
            var cncPLC = new CentroidAPI.CNCPipe.Plc(m_pipe);

            // We are using SetSkinEventState to simulate a button press of cycle start by passing the state of 1 (pressed)
            if (cncPLC.SetSkinEventState(50, 1) == CNCPipe.ReturnCode.SUCCESS)
            {
                // Sleep for 50 milliseconds so the PLC has a chance to see the button press
                System.Threading.Thread.Sleep(50);
                // Then return the result of setting the state to 0 (unpressed)
                return cncPLC.SetSkinEventState(50, 0);
            }
            return CNCPipe.ReturnCode.ERROR_UNKNOWN;
        }

        /// <summary>
        /// Returns the Dro Machine Position for the axis index passed, 0-7
        /// </summary>
        /// <param name="axis">Specify the Axis index you want to get the Dro Machine Position of</param>
        /// <returns>A string value of the Axis position</returns>
        public string GetDroReadout(int axis)
        {
            var cncDro = new CentroidAPI.CNCPipe.Dro(m_pipe);

            // What coordinate type do we want to return
            var droType = DroCoordinates.DRO_MACHINE;
            Tuple<string, string, string>[] droStrings;

            // Get result
            if (cncDro.GetDro(droType, out droStrings) == ReturnCode.SUCCESS)
            {
                return droStrings[axis].Item2;
            }

            // Return null if we fail
            return String.Empty;
        }

        /// <summary>
        /// Gets the state of a given input
        /// </summary>
        /// <param name="iInput">The Index of the input, please see operator manuals for more details as outputs vary between system and expansion boards</param>
        /// <returns>True if Input is On, False otherwise.</returns>
        public bool IsInputOn(int iInput)
        {
            if (ConnectedToCNC12())
            {
                var cncPlc = new CentroidAPI.CNCPipe.Plc(m_pipe);
                CentroidAPI.CNCPipe.Plc.IOState inputState;

                if (cncPlc.GetInputState(iInput, out inputState) == ReturnCode.SUCCESS)
                {
                    switch (inputState)
                    {
                        case IOState.IO_LOGICAL_0:
                            return false;
                        case IOState.IO_LOGICAL_1:
                            return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the state of a given output
        /// </summary>
        /// <param name="iOutput">The Index of the output, please see operator manuals for more details as outputs vary between system and expansion boards</param>
        /// <returns>True if Output is On, False otherwise</returns>
        public bool IsOutputOn(int iOutput)
        {
            if (ConnectedToCNC12())
            {
                var cncPlc = new CentroidAPI.CNCPipe.Plc(m_pipe);
                CentroidAPI.CNCPipe.Plc.IOState outputState;

                if (cncPlc.GetOutputState(iOutput, out outputState) == ReturnCode.SUCCESS)
                {
                    switch (outputState)
                    {
                        case IOState.IO_LOGICAL_0:
                            return false;
                        case IOState.IO_LOGICAL_1:
                            return true;
                    }
                }
            }
            return false;
        }
    }
}