namespace WindowManager
{
    partial class Advanced
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
            this.winOptions = new System.Windows.Forms.CheckedListBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // winOptions
            // 
            this.winOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winOptions.CheckOnClick = true;
            this.winOptions.FormattingEnabled = true;
            this.winOptions.Items.AddRange(new object[] {
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
            this.winOptions.Location = new System.Drawing.Point(12, 12);
            this.winOptions.Name = "winOptions";
            this.winOptions.Size = new System.Drawing.Size(183, 214);
            this.winOptions.TabIndex = 9;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.Location = new System.Drawing.Point(121, 235);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(74, 24);
            this.buttonAccept.TabIndex = 10;
            this.buttonAccept.Text = "Close";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // Advanced
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 262);
            this.ControlBox = false;
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.winOptions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Advanced";
            this.Text = "Advanced";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox winOptions;
        private System.Windows.Forms.Button buttonAccept;
    }
}