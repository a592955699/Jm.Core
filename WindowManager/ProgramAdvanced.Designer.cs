namespace WindowManager
{
    partial class ProgramAdvanced
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
            this.buttonProgAccept = new System.Windows.Forms.Button();
            this.winProgOptions = new System.Windows.Forms.CheckedListBox();
            this.styleProgOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProgCancel = new System.Windows.Forms.Button();
            this.btnProgRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonProgAccept
            // 
            this.buttonProgAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProgAccept.Location = new System.Drawing.Point(66, 271);
            this.buttonProgAccept.Name = "buttonProgAccept";
            this.buttonProgAccept.Size = new System.Drawing.Size(74, 24);
            this.buttonProgAccept.TabIndex = 12;
            this.buttonProgAccept.Text = "OK";
            this.buttonProgAccept.UseVisualStyleBackColor = true;
            this.buttonProgAccept.Click += new System.EventHandler(this.buttonProgAccept_Click);
            // 
            // winProgOptions
            // 
            this.winProgOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winProgOptions.CheckOnClick = true;
            this.winProgOptions.FormattingEnabled = true;
            this.winProgOptions.Items.AddRange(new object[] {
            "WS_BORDER",
            "WS_CAPTION",
            "WS_CHILD",
            "WS_CLIPCHILDREN",
            "WS_CLIPSIBLINGS",
            "WS_DISABLED",
            "WS_DLGFRAME",
            "WS_GROUP",
            "WS_HSCROLL",
            "WS_MAXIMIZE",
            "WS_MAXIMIZEBOX",
            "WS_MINIMIZE",
            "WS_MINIMIZEBOX",
            "WS_OVERLAPPED",
            "WS_POPUP",
            "WS_SYSMENU",
            "WS_TABSTOP",
            "WS_THICKFRAME",
            "WS_VISIBLE",
            "WS_VSCROLL"});
            this.winProgOptions.Location = new System.Drawing.Point(12, 12);
            this.winProgOptions.Name = "winProgOptions";
            this.winProgOptions.Size = new System.Drawing.Size(200, 214);
            this.winProgOptions.TabIndex = 11;
            this.winProgOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.winProgOptions_ItemCheck);
            // 
            // styleProgOutput
            // 
            this.styleProgOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleProgOutput.Location = new System.Drawing.Point(48, 245);
            this.styleProgOutput.Name = "styleProgOutput";
            this.styleProgOutput.ReadOnly = true;
            this.styleProgOutput.Size = new System.Drawing.Size(124, 20);
            this.styleProgOutput.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Style:";
            // 
            // btnProgCancel
            // 
            this.btnProgCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProgCancel.Location = new System.Drawing.Point(146, 271);
            this.btnProgCancel.Name = "btnProgCancel";
            this.btnProgCancel.Size = new System.Drawing.Size(66, 24);
            this.btnProgCancel.TabIndex = 15;
            this.btnProgCancel.Text = "Cancel";
            this.btnProgCancel.UseVisualStyleBackColor = true;
            this.btnProgCancel.Click += new System.EventHandler(this.btnProgCancel_Click);
            // 
            // btnProgRefresh
            // 
            this.btnProgRefresh.Image = global::WindowManager.Properties.Resources.arrow_refresh;
            this.btnProgRefresh.Location = new System.Drawing.Point(178, 242);
            this.btnProgRefresh.Name = "btnProgRefresh";
            this.btnProgRefresh.Size = new System.Drawing.Size(34, 23);
            this.btnProgRefresh.TabIndex = 16;
            this.btnProgRefresh.UseVisualStyleBackColor = true;
            this.btnProgRefresh.Click += new System.EventHandler(this.btnProgRefresh_Click);
            // 
            // ProgramAdvanced
            // 
            this.AcceptButton = this.buttonProgAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 308);
            this.ControlBox = false;
            this.Controls.Add(this.btnProgRefresh);
            this.Controls.Add(this.btnProgCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.styleProgOutput);
            this.Controls.Add(this.buttonProgAccept);
            this.Controls.Add(this.winProgOptions);
            this.Name = "ProgramAdvanced";
            this.Text = "Advanced";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonProgAccept;
        private System.Windows.Forms.CheckedListBox winProgOptions;
        private System.Windows.Forms.TextBox styleProgOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProgCancel;
        private System.Windows.Forms.Button btnProgRefresh;

    }
}