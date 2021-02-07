namespace WindowManager
{
    partial class ManagerMain
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
                // Make sure we stop hooking before quitting! Otherwise, the hook procedures in GlobalCbtHook.dll
                // will keep being called, even after our application quits, which will needlessly degrade system
                // performance. And it's just plain sloppy.
                _GlobalHooks.CBT.Stop();
                _GlobalHooks.Shell.Stop();
                _GlobalHooks.MouseLL.Stop();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerMain));
            this.listWindows = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkMinToTray = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBalloonStart = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboWinStyle = new System.Windows.Forms.ComboBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBorderStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPreview = new System.Windows.Forms.GroupBox();
            this.preview = new System.Windows.Forms.PictureBox();
            this.container = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnProgAdvanced = new System.Windows.Forms.Button();
            this.comboProgStatus = new System.Windows.Forms.ComboBox();
            this.btnProgSet = new System.Windows.Forms.Button();
            this.btnProgReset = new System.Windows.Forms.Button();
            this.comboProgStyle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.remSelected = new System.Windows.Forms.Button();
            this.btnAddProgram = new System.Windows.Forms.Button();
            this.listPrograms = new System.Windows.Forms.ListView();
            this.Executable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Directory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Options = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openExec = new System.Windows.Forms.OpenFileDialog();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.traySettings = new System.Windows.Forms.ToolStripMenuItem();
            this.trayRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.container.Panel1.SuspendLayout();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listWindows
            // 
            this.listWindows.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listWindows.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listWindows.FullRowSelect = true;
            this.listWindows.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listWindows.HideSelection = false;
            this.listWindows.LargeImageList = this.iconList;
            this.listWindows.Location = new System.Drawing.Point(0, 0);
            this.listWindows.MultiSelect = false;
            this.listWindows.Name = "listWindows";
            this.listWindows.Size = new System.Drawing.Size(286, 198);
            this.listWindows.SmallImageList = this.iconList;
            this.listWindows.TabIndex = 0;
            this.listWindows.UseCompatibleStateImageBehavior = false;
            this.listWindows.View = System.Windows.Forms.View.Details;
            this.listWindows.ItemActivate += new System.EventHandler(this.listWindows_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Window";
            this.columnHeader1.Width = 256;
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "accept.png");
            this.iconList.Images.SetKeyName(1, "exclamation.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = global::WindowManager.Properties.Resources.door_open;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Checked = true;
            this.viewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshNowToolStripMenuItem,
            this.toolStripSeparator2,
            this.checkMinToTray,
            this.checkBalloonStart});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // refreshNowToolStripMenuItem
            // 
            this.refreshNowToolStripMenuItem.Image = global::WindowManager.Properties.Resources.arrow_refresh;
            this.refreshNowToolStripMenuItem.Name = "refreshNowToolStripMenuItem";
            this.refreshNowToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.refreshNowToolStripMenuItem.Text = "Refresh";
            this.refreshNowToolStripMenuItem.Click += new System.EventHandler(this.refreshNowToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // checkMinToTray
            // 
            this.checkMinToTray.Checked = true;
            this.checkMinToTray.CheckOnClick = true;
            this.checkMinToTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkMinToTray.Name = "checkMinToTray";
            this.checkMinToTray.Size = new System.Drawing.Size(214, 22);
            this.checkMinToTray.Text = "Minimize to system tray";
            this.checkMinToTray.Click += new System.EventHandler(this.checkMinToTray_Click);
            // 
            // checkBalloonStart
            // 
            this.checkBalloonStart.Checked = true;
            this.checkBalloonStart.CheckOnClick = true;
            this.checkBalloonStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBalloonStart.Name = "checkBalloonStart";
            this.checkBalloonStart.Size = new System.Drawing.Size(214, 22);
            this.checkBalloonStart.Text = "Balloon tip on start";
            this.checkBalloonStart.Click += new System.EventHandler(this.checkBalloonStart_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::WindowManager.Properties.Resources.information;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboWinStyle);
            this.groupBox1.Controls.Add(this.buttonAccept);
            this.groupBox1.Controls.Add(this.buttonRefresh);
            this.groupBox1.Controls.Add(this.comboBorderStyle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 93);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // buttonClose
            // 
            this.buttonClose.Image = global::WindowManager.Properties.Resources.close;
            this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.Location = new System.Drawing.Point(199, 66);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(66, 21);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(421, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Advanced";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboWinStyle
            // 
            this.comboWinStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboWinStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWinStyle.FormattingEnabled = true;
            this.comboWinStyle.Items.AddRange(new object[] {
            "Normal",
            "Minimized",
            "Maximized"});
            this.comboWinStyle.Location = new System.Drawing.Point(258, 42);
            this.comboWinStyle.Name = "comboWinStyle";
            this.comboWinStyle.Size = new System.Drawing.Size(228, 20);
            this.comboWinStyle.TabIndex = 5;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Image = global::WindowManager.Properties.Resources.accept;
            this.buttonAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAccept.Location = new System.Drawing.Point(9, 66);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(61, 21);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Set";
            this.buttonAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Image = global::WindowManager.Properties.Resources.arrow_refresh;
            this.buttonRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRefresh.Location = new System.Drawing.Point(99, 66);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 21);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // comboBorderStyle
            // 
            this.comboBorderStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBorderStyle.FormattingEnabled = true;
            this.comboBorderStyle.Items.AddRange(new object[] {
            "None",
            "Sizable",
            "Advanced..."});
            this.comboBorderStyle.Location = new System.Drawing.Point(258, 18);
            this.comboBorderStyle.Name = "comboBorderStyle";
            this.comboBorderStyle.Size = new System.Drawing.Size(157, 20);
            this.comboBorderStyle.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Window Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Border Style";
            // 
            // groupPreview
            // 
            this.groupPreview.Controls.Add(this.preview);
            this.groupPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPreview.Location = new System.Drawing.Point(0, 0);
            this.groupPreview.Name = "groupPreview";
            this.groupPreview.Size = new System.Drawing.Size(198, 198);
            this.groupPreview.TabIndex = 5;
            this.groupPreview.TabStop = false;
            this.groupPreview.Text = "Preview";
            // 
            // preview
            // 
            this.preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview.Location = new System.Drawing.Point(3, 17);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(192, 178);
            this.preview.TabIndex = 2;
            this.preview.TabStop = false;
            // 
            // container
            // 
            this.container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.container.Location = new System.Drawing.Point(8, 6);
            this.container.Name = "container";
            // 
            // container.Panel1
            // 
            this.container.Panel1.Controls.Add(this.listWindows);
            // 
            // container.Panel2
            // 
            this.container.Panel2.Controls.Add(this.groupPreview);
            this.container.Size = new System.Drawing.Size(488, 198);
            this.container.SplitterDistance = 286;
            this.container.TabIndex = 6;
            this.container.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.container_SplitterMoved);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(512, 334);
            this.tabControl.TabIndex = 7;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.container);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current Processes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.remSelected);
            this.tabPage2.Controls.Add(this.btnAddProgram);
            this.tabPage2.Controls.Add(this.listPrograms);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Program Profiles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnProgAdvanced);
            this.groupBox2.Controls.Add(this.comboProgStatus);
            this.groupBox2.Controls.Add(this.btnProgSet);
            this.groupBox2.Controls.Add(this.btnProgReset);
            this.groupBox2.Controls.Add(this.comboProgStyle);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 93);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // btnProgAdvanced
            // 
            this.btnProgAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProgAdvanced.Enabled = false;
            this.btnProgAdvanced.Location = new System.Drawing.Point(262, 17);
            this.btnProgAdvanced.Name = "btnProgAdvanced";
            this.btnProgAdvanced.Size = new System.Drawing.Size(64, 20);
            this.btnProgAdvanced.TabIndex = 6;
            this.btnProgAdvanced.Text = "Advanced";
            this.btnProgAdvanced.UseVisualStyleBackColor = true;
            this.btnProgAdvanced.Click += new System.EventHandler(this.btnProgAdvanced_Click);
            // 
            // comboProgStatus
            // 
            this.comboProgStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboProgStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProgStatus.Enabled = false;
            this.comboProgStatus.FormattingEnabled = true;
            this.comboProgStatus.Items.AddRange(new object[] {
            "Normal",
            "Minimized",
            "Maximized"});
            this.comboProgStatus.Location = new System.Drawing.Point(99, 42);
            this.comboProgStatus.Name = "comboProgStatus";
            this.comboProgStatus.Size = new System.Drawing.Size(228, 20);
            this.comboProgStatus.TabIndex = 5;
            this.comboProgStatus.SelectedIndexChanged += new System.EventHandler(this.comboProgStatus_SelectedIndexChanged);
            // 
            // btnProgSet
            // 
            this.btnProgSet.Image = global::WindowManager.Properties.Resources.accept;
            this.btnProgSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgSet.Location = new System.Drawing.Point(9, 66);
            this.btnProgSet.Name = "btnProgSet";
            this.btnProgSet.Size = new System.Drawing.Size(61, 21);
            this.btnProgSet.TabIndex = 4;
            this.btnProgSet.Text = "Save";
            this.btnProgSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProgSet.UseVisualStyleBackColor = true;
            this.btnProgSet.Click += new System.EventHandler(this.btnProgSet_Click);
            // 
            // btnProgReset
            // 
            this.btnProgReset.Image = global::WindowManager.Properties.Resources.exclamation;
            this.btnProgReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgReset.Location = new System.Drawing.Point(99, 66);
            this.btnProgReset.Name = "btnProgReset";
            this.btnProgReset.Size = new System.Drawing.Size(75, 21);
            this.btnProgReset.TabIndex = 3;
            this.btnProgReset.Text = "Reset";
            this.btnProgReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProgReset.UseVisualStyleBackColor = true;
            this.btnProgReset.Click += new System.EventHandler(this.btnProgReset_Click);
            // 
            // comboProgStyle
            // 
            this.comboProgStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboProgStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProgStyle.Enabled = false;
            this.comboProgStyle.FormattingEnabled = true;
            this.comboProgStyle.Items.AddRange(new object[] {
            "None",
            "Sizable",
            "Advanced..."});
            this.comboProgStyle.Location = new System.Drawing.Point(99, 18);
            this.comboProgStyle.Name = "comboProgStyle";
            this.comboProgStyle.Size = new System.Drawing.Size(157, 20);
            this.comboProgStyle.TabIndex = 2;
            this.comboProgStyle.SelectedIndexChanged += new System.EventHandler(this.comboProgStyle_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Window Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Border Style";
            // 
            // remSelected
            // 
            this.remSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remSelected.Location = new System.Drawing.Point(69, 185);
            this.remSelected.Name = "remSelected";
            this.remSelected.Size = new System.Drawing.Size(101, 22);
            this.remSelected.TabIndex = 2;
            this.remSelected.Text = "Remove Selected";
            this.remSelected.UseVisualStyleBackColor = true;
            this.remSelected.Click += new System.EventHandler(this.remSelected_Click);
            // 
            // btnAddProgram
            // 
            this.btnAddProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddProgram.Location = new System.Drawing.Point(8, 185);
            this.btnAddProgram.Name = "btnAddProgram";
            this.btnAddProgram.Size = new System.Drawing.Size(55, 22);
            this.btnAddProgram.TabIndex = 1;
            this.btnAddProgram.Text = "Add...";
            this.btnAddProgram.UseVisualStyleBackColor = true;
            this.btnAddProgram.Click += new System.EventHandler(this.btnAddProgram_Click);
            // 
            // listPrograms
            // 
            this.listPrograms.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listPrograms.CheckBoxes = true;
            this.listPrograms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Executable,
            this.Directory,
            this.Options});
            this.listPrograms.FullRowSelect = true;
            this.listPrograms.HideSelection = false;
            this.listPrograms.Location = new System.Drawing.Point(8, 6);
            this.listPrograms.MultiSelect = false;
            this.listPrograms.Name = "listPrograms";
            this.listPrograms.Size = new System.Drawing.Size(329, 174);
            this.listPrograms.TabIndex = 0;
            this.listPrograms.UseCompatibleStateImageBehavior = false;
            this.listPrograms.View = System.Windows.Forms.View.Details;
            this.listPrograms.ItemActivate += new System.EventHandler(this.listPrograms_ItemActivate);
            this.listPrograms.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listPrograms_ItemChecked);
            this.listPrograms.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listPrograms_ItemSelectionChanged);
            // 
            // Executable
            // 
            this.Executable.Text = "Executable";
            this.Executable.Width = 170;
            // 
            // Directory
            // 
            this.Directory.Text = "File Path";
            // 
            // Options
            // 
            this.Options.Text = "Options";
            this.Options.Width = 54;
            // 
            // openExec
            // 
            this.openExec.Filter = "Executable|*.exe";
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Window Manager";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traySettings,
            this.trayRestore,
            this.toolStripSeparator1,
            this.trayClose});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(123, 76);
            this.trayMenu.Text = "Window Manager";
            // 
            // traySettings
            // 
            this.traySettings.Name = "traySettings";
            this.traySettings.Size = new System.Drawing.Size(122, 22);
            this.traySettings.Text = "Settings";
            this.traySettings.Click += new System.EventHandler(this.traySettings_Click);
            // 
            // trayRestore
            // 
            this.trayRestore.Name = "trayRestore";
            this.trayRestore.Size = new System.Drawing.Size(122, 22);
            this.trayRestore.Text = "Restore";
            this.trayRestore.Click += new System.EventHandler(this.trayRestore_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
            // 
            // trayClose
            // 
            this.trayClose.Name = "trayClose";
            this.trayClose.Size = new System.Drawing.Size(122, 22);
            this.trayClose.Text = "Close";
            this.trayClose.Click += new System.EventHandler(this.trayClose_Click);
            // 
            // ManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 359);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagerMain";
            this.Text = "Window Manager";
            this.Resize += new System.EventHandler(this.ManagerMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.container.Panel1.ResumeLayout(false);
            this.container.Panel2.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listWindows;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBorderStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupPreview;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ComboBox comboWinStyle;
        private System.Windows.Forms.SplitContainer container;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnProgAdvanced;
        private System.Windows.Forms.ComboBox comboProgStatus;
        private System.Windows.Forms.Button btnProgSet;
        private System.Windows.Forms.Button btnProgReset;
        private System.Windows.Forms.ComboBox comboProgStyle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button remSelected;
        private System.Windows.Forms.Button btnAddProgram;
        private System.Windows.Forms.ListView listPrograms;
        private System.Windows.Forms.ColumnHeader Executable;
        private System.Windows.Forms.ColumnHeader Options;
        private System.Windows.Forms.ColumnHeader Directory;
        private System.Windows.Forms.OpenFileDialog openExec;
        private System.Windows.Forms.ToolStripMenuItem checkMinToTray;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripMenuItem traySettings;
        private System.Windows.Forms.ToolStripMenuItem trayRestore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trayClose;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem checkBalloonStart;
        private System.Windows.Forms.Button buttonClose;
    }
}

