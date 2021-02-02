namespace Jm.Core.Win32Test
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Bind = new System.Windows.Forms.Button();
            this.btn_UnBind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMouseState = new System.Windows.Forms.Label();
            this.lbKeyState = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Bind
            // 
            this.btn_Bind.Location = new System.Drawing.Point(13, 13);
            this.btn_Bind.Name = "btn_Bind";
            this.btn_Bind.Size = new System.Drawing.Size(75, 23);
            this.btn_Bind.TabIndex = 0;
            this.btn_Bind.Text = "绑定钩子";
            this.btn_Bind.UseVisualStyleBackColor = true;
            this.btn_Bind.Click += new System.EventHandler(this.btn_Bind_Click);
            // 
            // btn_UnBind
            // 
            this.btn_UnBind.Location = new System.Drawing.Point(106, 13);
            this.btn_UnBind.Name = "btn_UnBind";
            this.btn_UnBind.Size = new System.Drawing.Size(75, 23);
            this.btn_UnBind.TabIndex = 1;
            this.btn_UnBind.Text = "卸载钩子";
            this.btn_UnBind.UseVisualStyleBackColor = true;
            this.btn_UnBind.Click += new System.EventHandler(this.btn_UnBind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "鼠标：";
            // 
            // lbMouseState
            // 
            this.lbMouseState.AutoSize = true;
            this.lbMouseState.Location = new System.Drawing.Point(60, 43);
            this.lbMouseState.Name = "lbMouseState";
            this.lbMouseState.Size = new System.Drawing.Size(0, 12);
            this.lbMouseState.TabIndex = 3;
            // 
            // lbKeyState
            // 
            this.lbKeyState.AutoSize = true;
            this.lbKeyState.Location = new System.Drawing.Point(60, 69);
            this.lbKeyState.Name = "lbKeyState";
            this.lbKeyState.Size = new System.Drawing.Size(0, 12);
            this.lbKeyState.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "键盘：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "屏蔽键盘";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "恢复键盘";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbKeyState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMouseState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_UnBind);
            this.Controls.Add(this.btn_Bind);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Bind;
        private System.Windows.Forms.Button btn_UnBind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMouseState;
        private System.Windows.Forms.Label lbKeyState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

