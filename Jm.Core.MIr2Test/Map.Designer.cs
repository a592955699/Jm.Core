
namespace Jm.Core.MIr2Test
{
    partial class Map
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
            this.gb_mapinfo = new System.Windows.Forms.GroupBox();
            this.btn_brower = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.lbl_end = new System.Windows.Forms.Label();
            this.lbl_start = new System.Windows.Forms.Label();
            this.lbl_point = new System.Windows.Forms.Label();
            this.lbl_MapSize = new System.Windows.Forms.Label();
            this.lbl_mapName = new System.Windows.Forms.Label();
            this.lbl_fileName = new System.Windows.Forms.Label();
            this.btn_findPath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_map = new System.Windows.Forms.Panel();
            this.pic_map = new System.Windows.Forms.PictureBox();
            this.gb_mapinfo.SuspendLayout();
            this.panel_map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_map)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_mapinfo
            // 
            this.gb_mapinfo.Controls.Add(this.btn_brower);
            this.gb_mapinfo.Controls.Add(this.lbl_info);
            this.gb_mapinfo.Controls.Add(this.lbl_end);
            this.gb_mapinfo.Controls.Add(this.lbl_start);
            this.gb_mapinfo.Controls.Add(this.lbl_point);
            this.gb_mapinfo.Controls.Add(this.lbl_MapSize);
            this.gb_mapinfo.Controls.Add(this.lbl_mapName);
            this.gb_mapinfo.Controls.Add(this.lbl_fileName);
            this.gb_mapinfo.Controls.Add(this.btn_findPath);
            this.gb_mapinfo.Controls.Add(this.label6);
            this.gb_mapinfo.Controls.Add(this.label5);
            this.gb_mapinfo.Controls.Add(this.label4);
            this.gb_mapinfo.Controls.Add(this.label3);
            this.gb_mapinfo.Controls.Add(this.label2);
            this.gb_mapinfo.Controls.Add(this.label1);
            this.gb_mapinfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.gb_mapinfo.Location = new System.Drawing.Point(0, 0);
            this.gb_mapinfo.Name = "gb_mapinfo";
            this.gb_mapinfo.Size = new System.Drawing.Size(170, 461);
            this.gb_mapinfo.TabIndex = 0;
            this.gb_mapinfo.TabStop = false;
            this.gb_mapinfo.Text = "Map info";
            // 
            // btn_brower
            // 
            this.btn_brower.Location = new System.Drawing.Point(6, 180);
            this.btn_brower.Name = "btn_brower";
            this.btn_brower.Size = new System.Drawing.Size(77, 23);
            this.btn_brower.TabIndex = 14;
            this.btn_brower.Text = "Select map";
            this.btn_brower.UseVisualStyleBackColor = true;
            this.btn_brower.Click += new System.EventHandler(this.btn_brower_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(7, 155);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(59, 12);
            this.lbl_info.TabIndex = 13;
            this.lbl_info.Text = "Message：";
            // 
            // lbl_end
            // 
            this.lbl_end.AutoSize = true;
            this.lbl_end.Location = new System.Drawing.Point(70, 132);
            this.lbl_end.Name = "lbl_end";
            this.lbl_end.Size = new System.Drawing.Size(17, 12);
            this.lbl_end.TabIndex = 12;
            this.lbl_end.Text = "--";
            // 
            // lbl_start
            // 
            this.lbl_start.AutoSize = true;
            this.lbl_start.Location = new System.Drawing.Point(70, 109);
            this.lbl_start.Name = "lbl_start";
            this.lbl_start.Size = new System.Drawing.Size(17, 12);
            this.lbl_start.TabIndex = 11;
            this.lbl_start.Text = "--";
            // 
            // lbl_point
            // 
            this.lbl_point.AutoSize = true;
            this.lbl_point.Location = new System.Drawing.Point(70, 87);
            this.lbl_point.Name = "lbl_point";
            this.lbl_point.Size = new System.Drawing.Size(17, 12);
            this.lbl_point.TabIndex = 10;
            this.lbl_point.Text = "--";
            // 
            // lbl_MapSize
            // 
            this.lbl_MapSize.AutoSize = true;
            this.lbl_MapSize.Location = new System.Drawing.Point(70, 64);
            this.lbl_MapSize.Name = "lbl_MapSize";
            this.lbl_MapSize.Size = new System.Drawing.Size(17, 12);
            this.lbl_MapSize.TabIndex = 9;
            this.lbl_MapSize.Text = "--";
            // 
            // lbl_mapName
            // 
            this.lbl_mapName.AutoSize = true;
            this.lbl_mapName.Location = new System.Drawing.Point(70, 42);
            this.lbl_mapName.Name = "lbl_mapName";
            this.lbl_mapName.Size = new System.Drawing.Size(17, 12);
            this.lbl_mapName.TabIndex = 8;
            this.lbl_mapName.Text = "--";
            // 
            // lbl_fileName
            // 
            this.lbl_fileName.AutoSize = true;
            this.lbl_fileName.Location = new System.Drawing.Point(70, 21);
            this.lbl_fileName.Name = "lbl_fileName";
            this.lbl_fileName.Size = new System.Drawing.Size(17, 12);
            this.lbl_fileName.TabIndex = 7;
            this.lbl_fileName.Text = "--";
            // 
            // btn_findPath
            // 
            this.btn_findPath.Location = new System.Drawing.Point(89, 180);
            this.btn_findPath.Name = "btn_findPath";
            this.btn_findPath.Size = new System.Drawing.Size(75, 23);
            this.btn_findPath.TabIndex = 6;
            this.btn_findPath.Text = "Find Path";
            this.btn_findPath.UseVisualStyleBackColor = true;
            this.btn_findPath.Click += new System.EventHandler(this.btn_findPath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "End:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Start:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Point:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Map Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Map Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // panel_map
            // 
            this.panel_map.Controls.Add(this.pic_map);
            this.panel_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_map.Location = new System.Drawing.Point(170, 0);
            this.panel_map.Name = "panel_map";
            this.panel_map.Size = new System.Drawing.Size(514, 461);
            this.panel_map.TabIndex = 1;
            // 
            // pic_map
            // 
            this.pic_map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_map.Location = new System.Drawing.Point(0, 0);
            this.pic_map.Name = "pic_map";
            this.pic_map.Size = new System.Drawing.Size(514, 461);
            this.pic_map.TabIndex = 0;
            this.pic_map.TabStop = false;
            this.pic_map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pic_map_MouseClick);
            this.pic_map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_map_MouseMove);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.panel_map);
            this.Controls.Add(this.gb_mapinfo);
            this.Name = "Map";
            this.Text = "Mir Map Tool By rober.hu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gb_mapinfo.ResumeLayout(false);
            this.gb_mapinfo.PerformLayout();
            this.panel_map.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_mapinfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_map;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pic_map;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_findPath;
        private System.Windows.Forms.Label lbl_end;
        private System.Windows.Forms.Label lbl_start;
        private System.Windows.Forms.Label lbl_point;
        private System.Windows.Forms.Label lbl_MapSize;
        private System.Windows.Forms.Label lbl_mapName;
        private System.Windows.Forms.Label lbl_fileName;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Button btn_brower;
    }
}

