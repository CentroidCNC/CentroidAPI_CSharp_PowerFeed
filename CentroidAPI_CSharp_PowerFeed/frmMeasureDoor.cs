using CentroidAPI;
using Microsoft.VisualBasic;
namespace CentroidAPI_CSharp_PowerFeed
{
    public partial class frmMeasureDoor : Form
    {
        private PipeManager CNCPipeManager;
        private Thread cnc12_isRunning_thread;

        /// <summary>
        /// Initialize componets and pipe manager
        /// </summary>
        public frmMeasureDoor()
        {
            InitializeComponent();

            CNCPipeManager = new PipeManager();
        }

        /// <summary>
        /// On form load, check if we're connected then throw a message and exit, otherwise begin watching for CNC12
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMeasureDoor_Load(object sender, EventArgs e)
        {
            if (!CNCPipeManager.ConnectedToCNC12())
            {
                MessageBox.Show("Could not connect to CNC12. Please make sure CNC12 is running before using this application.", "Could not connect to CNC12");

                Application.Exit();
            }

            // create new thread that calls IsCNC12Running
            cnc12_isRunning_thread = new Thread(new ThreadStart(IsCNC12Running));
            // set it as a background thread
            cnc12_isRunning_thread.IsBackground = true;
            // start the thread
            cnc12_isRunning_thread.Start();

        }

        /// <summary>
        /// Appends the character on the pressed button to the txtDoorMeasure textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterNumber_Click(object sender, EventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if (ClickedButton.Text == ".")
            {
                if (this.txtDoorMeasure.Text.Contains("."))
                {
                    // do nothing if we already have a decimal point in the text box
                }
                else
                {
                    this.txtDoorMeasure.Text += ClickedButton.Text;
                }
            }
            else
            {
                this.txtDoorMeasure.Text += ClickedButton.Text;
            }
        }

        /// <summary>
        /// Clears the text for txtDoorMeasure textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterClear_Click(object sender, EventArgs e)
        {
            this.txtDoorMeasure.Clear();
        }

        /// <summary>
        /// Sends a G1 command using xDistance as X axis distance and FeedRate as desired FeedRate
        /// </summary>
        /// <param name="xDistance">Distance to move X Axis</param>
        /// <param name="FeedRate">Speed at which to move X Axis</param>
        /// <returns></returns>
        public CentroidAPI.CNCPipe.ReturnCode SendXMoveCommand(double xDistance, double FeedRate = 50)
        {
            // check that pipe is initialized
            if (CNCPipeManager.ConnectedToCNC12() && !CNCPipeManager.IsRunningJob())
            {
                // reference to Job class
                var cmd = new CentroidAPI.CNCPipe.Job(CNCPipeManager.Pipe);
                // return the result of the command after building the command and sending it to cnc12
                return cmd.RunCommand("G1 X" + xDistance + " F" + FeedRate, CNCPipeManager.GetCNC12WorkingDirectory(), false);
            }
            // if we failed, send back an unknown error
            return CentroidAPI.CNCPipe.ReturnCode.ERROR_UNKNOWN;
        }

        /// <summary>
        /// Sends Cycle Stop Command
        /// </summary>
        /// <returns>ReturnCode</returns>
        public CentroidAPI.CNCPipe.ReturnCode SendCycleStopCommand()
        {
            if (CNCPipeManager.ConnectedToCNC12())
            {
                var cmd = new CentroidAPI.CNCPipe.Job(CNCPipeManager.Pipe);
                return cmd.CancelExecution();
            }

            return CentroidAPI.CNCPipe.ReturnCode.ERROR_UNKNOWN;
        }


        /// <summary>
        /// This subprocedure checks if CNC12 is running and updates the title bar text depending on the result
        /// </summary>
        private void IsCNC12Running()
        {
            // called from a background thread and we want it to continue forever, so while true...
            while (true)
            {
                try
                {
                    // if we are connected, display in the title bar
                    if (CNCPipeManager.ConnectedToCNC12())
                    {
                        ChangeTitleBarText("Power Feed App - Connected to CNC12");
                    }
                    else
                    {
                        // if we are disconnected, display in the title bar
                        ChangeTitleBarText("Power Feed App - Disconnected from CNC12");
                    }
                }
                catch (Exception)
                {
                    // if we get an exception when checking then assume we are disconnected
                    ChangeTitleBarText("Power Feed App - Disconnected from CNC12");
                }

                // sleep for half a second so we don't use up a CPU core
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// This subprocedure checks if an invoke is needed to access the form from another thread, then changes the form text
        /// </summary>
        /// <param name="text"></param>
        private void ChangeTitleBarText(string text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    this.Text = text;
                }));
            }
            else
            {
                this.Text = text;
            }
        }

        /// <summary>
        /// Sends the command for moving the X axis to the absolute position entered in txtDoorMeasure textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picCycleStart_Click(object sender, EventArgs e)
        {
            // check that textbox text is not empty
            if (this.txtDoorMeasure.Text.Trim() != "")
            {
                // try to convert the value of textbox text to a double
                double xVal = Convert.ToDouble(this.txtDoorMeasure.Text);
                // send the value and the feedrate value from settings to the SendXMoveCommand so movement command can be created
                if (SendXMoveCommand(xVal, Properties.Settings.Default.dblFeedRate) == CNCPipe.ReturnCode.SUCCESS)
                {
                    // if the movement command succeeded then clear the text
                    this.txtDoorMeasure.Clear();
                }
                else
                {
                    // throw a message that an error occured, needs better error handling but this will work for example
                    MessageBox.Show("An Error has occured...");
                }
            }
        }

        /// <summary>
        /// Attempts to cancel the currently running command or job
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picCycleCancel_Click(object sender, EventArgs e)
        {
            if (SendCycleStopCommand() != CNCPipe.ReturnCode.SUCCESS)
            {
                MessageBox.Show("An error has occured...");
            }
        }

        /// <summary>
        /// Opens the frmFeedrate window to edit desired feedrate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var feedrateFrm = new frmFeedRate(CNCPipeManager.Pipe);

            feedrateFrm.ShowDialog();
        }
    }
}
