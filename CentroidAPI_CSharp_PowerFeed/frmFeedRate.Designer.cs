namespace CentroidAPI_CSharp_PowerFeed
{
    partial class frmFeedRate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFeedRate));
            tlpButtonContainer = new TableLayoutPanel();
            btnEnterClear = new Button();
            btnEnterDecimal = new Button();
            btnEnter0 = new Button();
            btnEnter9 = new Button();
            btnEnter8 = new Button();
            btnEnter7 = new Button();
            btnEnter6 = new Button();
            btnEnter5 = new Button();
            btnEnter4 = new Button();
            btnEnter3 = new Button();
            btnEnter2 = new Button();
            gpbAmountToMoveX = new GroupBox();
            flpFeedrate = new FlowLayoutPanel();
            txtFeedrate = new TextBox();
            lblUnits = new Label();
            btnEnter1 = new Button();
            btnAccept = new Button();
            btnCancel = new Button();
            tlpButtonContainer.SuspendLayout();
            gpbAmountToMoveX.SuspendLayout();
            flpFeedrate.SuspendLayout();
            SuspendLayout();
            // 
            // tlpButtonContainer
            // 
            tlpButtonContainer.ColumnCount = 3;
            tlpButtonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpButtonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpButtonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpButtonContainer.Controls.Add(btnEnterClear, 2, 4);
            tlpButtonContainer.Controls.Add(btnEnterDecimal, 1, 4);
            tlpButtonContainer.Controls.Add(btnEnter0, 0, 4);
            tlpButtonContainer.Controls.Add(btnEnter9, 2, 3);
            tlpButtonContainer.Controls.Add(btnEnter8, 1, 3);
            tlpButtonContainer.Controls.Add(btnEnter7, 0, 3);
            tlpButtonContainer.Controls.Add(btnEnter6, 2, 2);
            tlpButtonContainer.Controls.Add(btnEnter5, 1, 2);
            tlpButtonContainer.Controls.Add(btnEnter4, 0, 2);
            tlpButtonContainer.Controls.Add(btnEnter3, 2, 1);
            tlpButtonContainer.Controls.Add(btnEnter2, 1, 1);
            tlpButtonContainer.Controls.Add(gpbAmountToMoveX, 0, 0);
            tlpButtonContainer.Controls.Add(btnEnter1, 0, 1);
            tlpButtonContainer.Location = new Point(12, 12);
            tlpButtonContainer.Name = "tlpButtonContainer";
            tlpButtonContainer.RowCount = 5;
            tlpButtonContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 14.4971018F));
            tlpButtonContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 21.3757267F));
            tlpButtonContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 21.3757267F));
            tlpButtonContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 21.3757267F));
            tlpButtonContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 21.3757267F));
            tlpButtonContainer.Size = new Size(436, 426);
            tlpButtonContainer.TabIndex = 1;
            // 
            // btnEnterClear
            // 
            btnEnterClear.Dock = DockStyle.Fill;
            btnEnterClear.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnterClear.Location = new Point(293, 337);
            btnEnterClear.Name = "btnEnterClear";
            btnEnterClear.Size = new Size(140, 86);
            btnEnterClear.TabIndex = 12;
            btnEnterClear.Text = "Clear";
            btnEnterClear.UseVisualStyleBackColor = true;
            btnEnterClear.Click += btnEnterClear_Click;
            // 
            // btnEnterDecimal
            // 
            btnEnterDecimal.Dock = DockStyle.Fill;
            btnEnterDecimal.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnterDecimal.Location = new Point(148, 337);
            btnEnterDecimal.Name = "btnEnterDecimal";
            btnEnterDecimal.Size = new Size(139, 86);
            btnEnterDecimal.TabIndex = 11;
            btnEnterDecimal.Text = ".";
            btnEnterDecimal.UseVisualStyleBackColor = true;
            btnEnterDecimal.Click += btnEnter_Click;
            // 
            // btnEnter0
            // 
            btnEnter0.Dock = DockStyle.Fill;
            btnEnter0.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter0.Location = new Point(3, 337);
            btnEnter0.Name = "btnEnter0";
            btnEnter0.Size = new Size(139, 86);
            btnEnter0.TabIndex = 10;
            btnEnter0.Text = "0";
            btnEnter0.UseVisualStyleBackColor = true;
            btnEnter0.Click += btnEnter_Click;
            // 
            // btnEnter9
            // 
            btnEnter9.Dock = DockStyle.Fill;
            btnEnter9.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter9.Location = new Point(293, 246);
            btnEnter9.Name = "btnEnter9";
            btnEnter9.Size = new Size(140, 85);
            btnEnter9.TabIndex = 9;
            btnEnter9.Text = "9";
            btnEnter9.UseVisualStyleBackColor = true;
            btnEnter9.Click += btnEnter_Click;
            // 
            // btnEnter8
            // 
            btnEnter8.Dock = DockStyle.Fill;
            btnEnter8.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter8.Location = new Point(148, 246);
            btnEnter8.Name = "btnEnter8";
            btnEnter8.Size = new Size(139, 85);
            btnEnter8.TabIndex = 8;
            btnEnter8.Text = "8";
            btnEnter8.UseVisualStyleBackColor = true;
            btnEnter8.Click += btnEnter_Click;
            // 
            // btnEnter7
            // 
            btnEnter7.Dock = DockStyle.Fill;
            btnEnter7.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter7.Location = new Point(3, 246);
            btnEnter7.Name = "btnEnter7";
            btnEnter7.Size = new Size(139, 85);
            btnEnter7.TabIndex = 7;
            btnEnter7.Text = "7";
            btnEnter7.UseVisualStyleBackColor = true;
            btnEnter7.Click += btnEnter_Click;
            // 
            // btnEnter6
            // 
            btnEnter6.Dock = DockStyle.Fill;
            btnEnter6.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter6.Location = new Point(293, 155);
            btnEnter6.Name = "btnEnter6";
            btnEnter6.Size = new Size(140, 85);
            btnEnter6.TabIndex = 6;
            btnEnter6.Text = "6";
            btnEnter6.UseVisualStyleBackColor = true;
            btnEnter6.Click += btnEnter_Click;
            // 
            // btnEnter5
            // 
            btnEnter5.Dock = DockStyle.Fill;
            btnEnter5.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter5.Location = new Point(148, 155);
            btnEnter5.Name = "btnEnter5";
            btnEnter5.Size = new Size(139, 85);
            btnEnter5.TabIndex = 5;
            btnEnter5.Text = "5";
            btnEnter5.UseVisualStyleBackColor = true;
            btnEnter5.Click += btnEnter_Click;
            // 
            // btnEnter4
            // 
            btnEnter4.Dock = DockStyle.Fill;
            btnEnter4.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter4.Location = new Point(3, 155);
            btnEnter4.Name = "btnEnter4";
            btnEnter4.Size = new Size(139, 85);
            btnEnter4.TabIndex = 4;
            btnEnter4.Text = "4";
            btnEnter4.UseVisualStyleBackColor = true;
            btnEnter4.Click += btnEnter_Click;
            // 
            // btnEnter3
            // 
            btnEnter3.Dock = DockStyle.Fill;
            btnEnter3.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter3.Location = new Point(293, 64);
            btnEnter3.Name = "btnEnter3";
            btnEnter3.Size = new Size(140, 85);
            btnEnter3.TabIndex = 3;
            btnEnter3.Text = "3";
            btnEnter3.UseVisualStyleBackColor = true;
            btnEnter3.Click += btnEnter_Click;
            // 
            // btnEnter2
            // 
            btnEnter2.Dock = DockStyle.Fill;
            btnEnter2.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter2.Location = new Point(148, 64);
            btnEnter2.Name = "btnEnter2";
            btnEnter2.Size = new Size(139, 85);
            btnEnter2.TabIndex = 2;
            btnEnter2.Text = "2";
            btnEnter2.UseVisualStyleBackColor = true;
            btnEnter2.Click += btnEnter_Click;
            // 
            // gpbAmountToMoveX
            // 
            tlpButtonContainer.SetColumnSpan(gpbAmountToMoveX, 3);
            gpbAmountToMoveX.Controls.Add(flpFeedrate);
            gpbAmountToMoveX.Dock = DockStyle.Fill;
            gpbAmountToMoveX.Location = new Point(3, 3);
            gpbAmountToMoveX.Name = "gpbAmountToMoveX";
            gpbAmountToMoveX.Size = new Size(430, 55);
            gpbAmountToMoveX.TabIndex = 0;
            gpbAmountToMoveX.TabStop = false;
            gpbAmountToMoveX.Text = "Default Feedrate:";
            // 
            // flpFeedrate
            // 
            flpFeedrate.Controls.Add(txtFeedrate);
            flpFeedrate.Controls.Add(lblUnits);
            flpFeedrate.Dock = DockStyle.Fill;
            flpFeedrate.Location = new Point(3, 19);
            flpFeedrate.Name = "flpFeedrate";
            flpFeedrate.Size = new Size(424, 33);
            flpFeedrate.TabIndex = 0;
            // 
            // txtFeedrate
            // 
            txtFeedrate.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtFeedrate.Location = new Point(3, 3);
            txtFeedrate.Name = "txtFeedrate";
            txtFeedrate.Size = new Size(278, 30);
            txtFeedrate.TabIndex = 0;
            // 
            // lblUnits
            // 
            lblUnits.AutoSize = true;
            lblUnits.Dock = DockStyle.Fill;
            lblUnits.Location = new Point(287, 0);
            lblUnits.Name = "lblUnits";
            lblUnits.Size = new Size(102, 36);
            lblUnits.TabIndex = 1;
            lblUnits.Text = "Inches Per Minute";
            lblUnits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEnter1
            // 
            btnEnter1.Dock = DockStyle.Fill;
            btnEnter1.Font = new Font("Cascadia Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnter1.Location = new Point(3, 64);
            btnEnter1.Name = "btnEnter1";
            btnEnter1.Size = new Size(139, 85);
            btnEnter1.TabIndex = 1;
            btnEnter1.Text = "1";
            btnEnter1.UseVisualStyleBackColor = true;
            btnEnter1.Click += btnEnter_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(305, 444);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(144, 51);
            btnAccept.TabIndex = 2;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(155, 444);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(144, 51);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmFeedRate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 507);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(tlpButtonContainer);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFeedRate";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Power Feed App - Feedrate";
            Load += frmFeedRate_Load;
            tlpButtonContainer.ResumeLayout(false);
            gpbAmountToMoveX.ResumeLayout(false);
            flpFeedrate.ResumeLayout(false);
            flpFeedrate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpButtonContainer;
        private Button btnEnterClear;
        private Button btnEnterDecimal;
        private Button btnEnter0;
        private Button btnEnter9;
        private Button btnEnter8;
        private Button btnEnter7;
        private Button btnEnter6;
        private Button btnEnter5;
        private Button btnEnter4;
        private Button btnEnter3;
        private Button btnEnter2;
        private GroupBox gpbAmountToMoveX;
        private TextBox txtFeedrate;
        private Button btnEnter1;
        private FlowLayoutPanel flpFeedrate;
        private Label lblUnits;
        private Button btnAccept;
        private Button btnCancel;
    }
}