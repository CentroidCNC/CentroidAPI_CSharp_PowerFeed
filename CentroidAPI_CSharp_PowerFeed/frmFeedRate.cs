//****************************************************************************
// Title:        frmSetup.cs
// Author(s):    Jacob Holes
// Start Date:   11-04-24
// Purpose: Setup panel that provides users access to configure the feedrate used for the power feed commands
//
// Environment/platform  ( Windows 10/11, C# .net)
//
// Last Update: 11-20-24 - JDH - Made feature complete with VB Example
// Prior Update: 11-04-24 - JDH - Added header and comments
// Prior Update: 11-04-24 - JDH - Created frmSetup, built form, added logic
//****************************************************************************

using CentroidAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentroidAPI_CSharp_PowerFeed
{
    public partial class frmFeedRate : Form
    {
        // create pipe
        private CNCPipe m_pipe;

        /// <summary>
        /// Basic class initialization
        /// </summary>
        public frmFeedRate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This constructor initializes the form and sets txtFeedrate.Text by pulling from our app settings.
        /// </summary>
        public frmFeedRate(CNCPipe MainPipe)
        {
            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.

            // set txtFeedrate.Text to our setting dblFeedRate
            this.txtFeedrate.Text = Properties.Settings.Default.dblFeedRate.ToString();
            // pass main pipe so we can communicate with CNC12 using the same pipe
            m_pipe = MainPipe;
        }

        /// <summary>
        /// Handles input from all buttons except clear, accept, and cancel.
        /// </summary>
        private void HandleButtonPress_Click(object sender, EventArgs e)
        {
            // Get the button the user clicked, cast it as a button
            var ClickedButton = (Button)sender;

            // if we clicked the decimal point...
            if (ClickedButton.Text == ".")
            {
                // check that we don't already have a decimal point
                if (!this.txtFeedrate.Text.Contains("."))
                {
                    // add the decimal point
                    this.txtFeedrate.Text += ClickedButton.Text;
                }
            }
            else
            {
                // allow everything else
                this.txtFeedrate.Text += ClickedButton.Text;
            }
        }

        /// <summary>
        /// Clears the txtFeedrate text.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            // clear the text
            this.txtFeedrate.Clear();
        }

        /// <summary>
        /// Saves the feedrate value to settings where it will be used in a power feed command.
        /// </summary>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            // convert txtFeedrate.Text to a double then save that value in our settings
            Properties.Settings.Default.dblFeedRate = Convert.ToDouble(this.txtFeedrate.Text);
            // save our settings
            Properties.Settings.Default.Save();
            // close this form
            this.Close();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // close this form
            this.Close();
        }

        /// <summary>
        /// When the form loads, checks the units of measurement and displays the correct label text.
        /// </summary>
        private void frmFeedRate_Load(object sender, EventArgs e)
        {
            // create wrapper for state
            var state = new CentroidAPI.CNCPipe.State(m_pipe);
            // variable to hold our unit of measurement
            CNCPipe.State.UnitsOfMeasure uom;

            // if we had a successful call then
            if (state.GetUnitsOfMeasureDro(out uom) == CNCPipe.ReturnCode.SUCCESS)
            {
                // check what the unit of measurement is and display it
                if (uom == CNCPipe.State.UnitsOfMeasure.INCH_UNITS)
                {
                    this.lblUnits.Text = "Inches per minute";
                }
                else if (uom == CNCPipe.State.UnitsOfMeasure.METRIC_UNITS)
                {
                    this.lblUnits.Text = "Millimeters per minute";
                }
            }
        }
        /// <summary>
        /// Handles any of the numerical buttons or decimal point, appends their text to the txtFeedrate textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if (ClickedButton.Text == ".")
            {
                if (this.txtFeedrate.Text.Contains("."))
                {
                    // do nothing if we already have a decimal point in the text box
                }
                else
                {
                    this.txtFeedrate.Text += ClickedButton.Text;
                }
            }
            else
            {
                this.txtFeedrate.Text += ClickedButton.Text;
            }
        }
        /// <summary>
        /// Clears the text from the txtFeedrate textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnterClear_Click(object sender, EventArgs e)
        {
            this.txtFeedrate.Clear();
        }
    }
}



