namespace SMM
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.GbCityInfo = new System.Windows.Forms.GroupBox();
            this.labelNoticeMain = new System.Windows.Forms.Label();
            this.tab1labelTime = new System.Windows.Forms.Label();
            this.tab1labelRelativeHumidity = new System.Windows.Forms.Label();
            this.tab1labelWindPower = new System.Windows.Forms.Label();
            this.tab1labelWindDirection = new System.Windows.Forms.Label();
            this.tab1labelTemperature = new System.Windows.Forms.Label();
            this.tab1labelCityName = new System.Windows.Forms.Label();
            this.InfoAndStatus = new System.Windows.Forms.StatusStrip();
            this.tssName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssStuId = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTheClass = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssContactMe = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCity = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.bgwWeather = new System.ComponentModel.BackgroundWorker();
            this.labelChangeBgImg = new System.Windows.Forms.Label();
            this.labelExit = new System.Windows.Forms.Label();
            this.labelMaxi = new System.Windows.Forms.Label();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tab2lableCityName = new System.Windows.Forms.Label();
            this.tab2labelTemperature = new System.Windows.Forms.Label();
            this.tab2lableWeather = new System.Windows.Forms.Label();
            this.tab2lableUpdateTime = new System.Windows.Forms.Label();
            this.tablabelIPAddress = new System.Windows.Forms.Label();
            this.labelMenu = new System.Windows.Forms.Label();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.fpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnSubmitMain = new System.Windows.Forms.Button();
            this.GbCityInfo.SuspendLayout();
            this.InfoAndStatus.SuspendLayout();
            this.gbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbCityInfo
            // 
            this.GbCityInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbCityInfo.BackColor = System.Drawing.Color.Transparent;
            this.GbCityInfo.Controls.Add(this.tab1labelTime);
            this.GbCityInfo.Controls.Add(this.tab1labelRelativeHumidity);
            this.GbCityInfo.Controls.Add(this.tab1labelWindPower);
            this.GbCityInfo.Controls.Add(this.tab1labelWindDirection);
            this.GbCityInfo.Controls.Add(this.tab1labelTemperature);
            this.GbCityInfo.Controls.Add(this.tab1labelCityName);
            this.GbCityInfo.Location = new System.Drawing.Point(447, 192);
            this.GbCityInfo.Name = "GbCityInfo";
            this.GbCityInfo.Size = new System.Drawing.Size(234, 242);
            this.GbCityInfo.TabIndex = 8;
            this.GbCityInfo.TabStop = false;
            this.GbCityInfo.Text = "城市信息";
            // 
            // labelNoticeMain
            // 
            this.labelNoticeMain.AutoSize = true;
            this.labelNoticeMain.BackColor = System.Drawing.Color.Transparent;
            this.labelNoticeMain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNoticeMain.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelNoticeMain.Location = new System.Drawing.Point(542, 353);
            this.labelNoticeMain.Name = "labelNoticeMain";
            this.labelNoticeMain.Size = new System.Drawing.Size(90, 21);
            this.labelNoticeMain.TabIndex = 49;
            this.labelNoticeMain.Text = "当前操作：";
            // 
            // tab1labelTime
            // 
            this.tab1labelTime.AutoSize = true;
            this.tab1labelTime.Location = new System.Drawing.Point(16, 203);
            this.tab1labelTime.Name = "tab1labelTime";
            this.tab1labelTime.Size = new System.Drawing.Size(65, 12);
            this.tab1labelTime.TabIndex = 12;
            this.tab1labelTime.Text = "更新时间：";
            // 
            // tab1labelRelativeHumidity
            // 
            this.tab1labelRelativeHumidity.AutoSize = true;
            this.tab1labelRelativeHumidity.Location = new System.Drawing.Point(16, 174);
            this.tab1labelRelativeHumidity.Name = "tab1labelRelativeHumidity";
            this.tab1labelRelativeHumidity.Size = new System.Drawing.Size(65, 12);
            this.tab1labelRelativeHumidity.TabIndex = 11;
            this.tab1labelRelativeHumidity.Text = "相对湿度：";
            // 
            // tab1labelWindPower
            // 
            this.tab1labelWindPower.AutoSize = true;
            this.tab1labelWindPower.Location = new System.Drawing.Point(16, 145);
            this.tab1labelWindPower.Name = "tab1labelWindPower";
            this.tab1labelWindPower.Size = new System.Drawing.Size(41, 12);
            this.tab1labelWindPower.TabIndex = 10;
            this.tab1labelWindPower.Text = "风力：";
            // 
            // tab1labelWindDirection
            // 
            this.tab1labelWindDirection.AutoSize = true;
            this.tab1labelWindDirection.Location = new System.Drawing.Point(16, 116);
            this.tab1labelWindDirection.Name = "tab1labelWindDirection";
            this.tab1labelWindDirection.Size = new System.Drawing.Size(41, 12);
            this.tab1labelWindDirection.TabIndex = 9;
            this.tab1labelWindDirection.Text = "风向：";
            // 
            // tab1labelTemperature
            // 
            this.tab1labelTemperature.AutoSize = true;
            this.tab1labelTemperature.Location = new System.Drawing.Point(16, 87);
            this.tab1labelTemperature.Name = "tab1labelTemperature";
            this.tab1labelTemperature.Size = new System.Drawing.Size(41, 12);
            this.tab1labelTemperature.TabIndex = 8;
            this.tab1labelTemperature.Text = "温度：";
            // 
            // tab1labelCityName
            // 
            this.tab1labelCityName.AutoSize = true;
            this.tab1labelCityName.Location = new System.Drawing.Point(16, 27);
            this.tab1labelCityName.Name = "tab1labelCityName";
            this.tab1labelCityName.Size = new System.Drawing.Size(65, 12);
            this.tab1labelCityName.TabIndex = 7;
            this.tab1labelCityName.Text = "城市名称：";
            // 
            // InfoAndStatus
            // 
            this.InfoAndStatus.BackColor = System.Drawing.Color.Gray;
            this.InfoAndStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssName,
            this.tssStuId,
            this.tssTheClass,
            this.tssContactMe,
            this.tssCity,
            this.tssTime});
            this.InfoAndStatus.Location = new System.Drawing.Point(0, 437);
            this.InfoAndStatus.Name = "InfoAndStatus";
            this.InfoAndStatus.Size = new System.Drawing.Size(703, 24);
            this.InfoAndStatus.TabIndex = 14;
            this.InfoAndStatus.Text = "statusStrip1";
            // 
            // tssName
            // 
            this.tssName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssName.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tssName.Name = "tssName";
            this.tssName.Size = new System.Drawing.Size(47, 19);
            this.tssName.Text = "潘雄飞";
            // 
            // tssStuId
            // 
            this.tssStuId.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssStuId.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssStuId.Name = "tssStuId";
            this.tssStuId.Size = new System.Drawing.Size(117, 19);
            this.tssStuId.Text = "学号：1325111028";
            // 
            // tssTheClass
            // 
            this.tssTheClass.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssTheClass.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssTheClass.Name = "tssTheClass";
            this.tssTheClass.Size = new System.Drawing.Size(135, 19);
            this.tssTheClass.Text = "班级：软工一班2013级";
            // 
            // tssContactMe
            // 
            this.tssContactMe.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssContactMe.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssContactMe.Name = "tssContactMe";
            this.tssContactMe.Size = new System.Drawing.Size(148, 19);
            this.tssContactMe.Text = "联系方式：18196518300";
            // 
            // tssCity
            // 
            this.tssCity.BackColor = System.Drawing.Color.Gray;
            this.tssCity.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssCity.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tssCity.Name = "tssCity";
            this.tssCity.Size = new System.Drawing.Size(40, 19);
            this.tssCity.Text = "-->--";
            this.tssCity.Click += new System.EventHandler(this.tssCity_Click);
            this.tssCity.MouseLeave += new System.EventHandler(this.tssCity_MouseLeave);
            this.tssCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tssCity_MouseMove);
            // 
            // tssTime
            // 
            this.tssTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tssTime.Name = "tssTime";
            this.tssTime.Size = new System.Drawing.Size(201, 19);
            this.tssTime.Spring = true;
            this.tssTime.Text = "time";
            this.tssTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // bgwWeather
            // 
            this.bgwWeather.WorkerReportsProgress = true;
            this.bgwWeather.WorkerSupportsCancellation = true;
            this.bgwWeather.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWeather_DoWork);
            this.bgwWeather.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWeather_RunWorkerCompleted);
            // 
            // labelChangeBgImg
            // 
            this.labelChangeBgImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChangeBgImg.AutoSize = true;
            this.labelChangeBgImg.BackColor = System.Drawing.Color.Transparent;
            this.labelChangeBgImg.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelChangeBgImg.Location = new System.Drawing.Point(570, 2);
            this.labelChangeBgImg.Name = "labelChangeBgImg";
            this.labelChangeBgImg.Size = new System.Drawing.Size(42, 21);
            this.labelChangeBgImg.TabIndex = 19;
            this.labelChangeBgImg.Text = "帮助";
            this.labelChangeBgImg.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelExit
            // 
            this.labelExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelExit.BackColor = System.Drawing.Color.Transparent;
            this.labelExit.Image = ((System.Drawing.Image)(resources.GetObject("labelExit.Image")));
            this.labelExit.Location = new System.Drawing.Point(676, 4);
            this.labelExit.Name = "labelExit";
            this.labelExit.Size = new System.Drawing.Size(16, 16);
            this.labelExit.TabIndex = 20;
            this.labelExit.Text = " ";
            this.labelExit.Click += new System.EventHandler(this.labelExit_Click);
            // 
            // labelMaxi
            // 
            this.labelMaxi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaxi.BackColor = System.Drawing.Color.Transparent;
            this.labelMaxi.Image = ((System.Drawing.Image)(resources.GetObject("labelMaxi.Image")));
            this.labelMaxi.Location = new System.Drawing.Point(654, 4);
            this.labelMaxi.Name = "labelMaxi";
            this.labelMaxi.Size = new System.Drawing.Size(16, 16);
            this.labelMaxi.TabIndex = 21;
            this.labelMaxi.Text = " ";
            this.labelMaxi.Click += new System.EventHandler(this.labelMaxi_Click);
            // 
            // labelMinimize
            // 
            this.labelMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMinimize.BackColor = System.Drawing.Color.Transparent;
            this.labelMinimize.Image = ((System.Drawing.Image)(resources.GetObject("labelMinimize.Image")));
            this.labelMinimize.Location = new System.Drawing.Point(630, 4);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(16, 16);
            this.labelMinimize.TabIndex = 22;
            this.labelMinimize.Text = " ";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // tab2lableCityName
            // 
            this.tab2lableCityName.AutoSize = true;
            this.tab2lableCityName.Location = new System.Drawing.Point(16, 27);
            this.tab2lableCityName.Name = "tab2lableCityName";
            this.tab2lableCityName.Size = new System.Drawing.Size(65, 12);
            this.tab2lableCityName.TabIndex = 7;
            // 
            // tab2labelTemperature
            // 
            this.tab2labelTemperature.AutoSize = true;
            this.tab2labelTemperature.Location = new System.Drawing.Point(16, 54);
            this.tab2labelTemperature.Name = "tab2labelTemperature";
            this.tab2labelTemperature.Size = new System.Drawing.Size(41, 12);
            this.tab2labelTemperature.TabIndex = 8;
            // 
            // tab2lableWeather
            // 
            this.tab2lableWeather.AutoSize = true;
            this.tab2lableWeather.Location = new System.Drawing.Point(16, 81);
            this.tab2lableWeather.Name = "tab2lableWeather";
            this.tab2lableWeather.Size = new System.Drawing.Size(41, 12);
            this.tab2lableWeather.TabIndex = 9;
            // 
            // tab2lableUpdateTime
            // 
            this.tab2lableUpdateTime.AutoSize = true;
            this.tab2lableUpdateTime.Location = new System.Drawing.Point(16, 196);
            this.tab2lableUpdateTime.Name = "tab2lableUpdateTime";
            this.tab2lableUpdateTime.Size = new System.Drawing.Size(65, 12);
            this.tab2lableUpdateTime.TabIndex = 12;
            // 
            // tablabelIPAddress
            // 
            this.tablabelIPAddress.AutoSize = true;
            this.tablabelIPAddress.Location = new System.Drawing.Point(16, 104);
            this.tablabelIPAddress.Name = "tablabelIPAddress";
            this.tablabelIPAddress.Size = new System.Drawing.Size(29, 12);
            this.tablabelIPAddress.TabIndex = 13;
            this.tablabelIPAddress.Visible = false;
            // 
            // labelMenu
            // 
            this.labelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMenu.BackColor = System.Drawing.Color.Transparent;
            this.labelMenu.Image = ((System.Drawing.Image)(resources.GetObject("labelMenu.Image")));
            this.labelMenu.Location = new System.Drawing.Point(513, 1);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(50, 27);
            this.labelMenu.TabIndex = 23;
            this.labelMenu.Text = " ";
            this.labelMenu.Click += new System.EventHandler(this.labelMenu_Click);
            // 
            // gbMenu
            // 
            this.gbMenu.BackColor = System.Drawing.Color.Transparent;
            this.gbMenu.Controls.Add(this.fpMenu);
            this.gbMenu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbMenu.Location = new System.Drawing.Point(411, 12);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(152, 100);
            this.gbMenu.TabIndex = 24;
            this.gbMenu.TabStop = false;
            this.gbMenu.Text = "菜单";
            this.gbMenu.Visible = false;
            // 
            // fpMenu
            // 
            this.fpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpMenu.Location = new System.Drawing.Point(3, 22);
            this.fpMenu.Name = "fpMenu";
            this.fpMenu.Size = new System.Drawing.Size(146, 75);
            this.fpMenu.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(42, 28);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(0, 38);
            this.labelTitle.TabIndex = 32;
            // 
            // btnSubmitMain
            // 
            this.btnSubmitMain.BackColor = System.Drawing.SystemColors.Control;
            this.btnSubmitMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitMain.Font = new System.Drawing.Font("华文细黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmitMain.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSubmitMain.Location = new System.Drawing.Point(544, 383);
            this.btnSubmitMain.Name = "btnSubmitMain";
            this.btnSubmitMain.Size = new System.Drawing.Size(110, 40);
            this.btnSubmitMain.TabIndex = 48;
            this.btnSubmitMain.Text = "提交修改";
            this.btnSubmitMain.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SMM.Properties.Resources.bgImg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(703, 461);
            this.ControlBox = false;
            this.Controls.Add(this.labelNoticeMain);
            this.Controls.Add(this.btnSubmitMain);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelMenu);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.GbCityInfo);
            this.Controls.Add(this.labelMinimize);
            this.Controls.Add(this.labelMaxi);
            this.Controls.Add(this.labelExit);
            this.Controls.Add(this.labelChangeBgImg);
            this.Controls.Add(this.InfoAndStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMM";
            this.Load += new System.EventHandler(this.main_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.GbCityInfo.ResumeLayout(false);
            this.GbCityInfo.PerformLayout();
            this.InfoAndStatus.ResumeLayout(false);
            this.InfoAndStatus.PerformLayout();
            this.gbMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GbCityInfo;
        private System.Windows.Forms.Label tab1labelTime;
        private System.Windows.Forms.Label tab1labelRelativeHumidity;
        private System.Windows.Forms.Label tab1labelWindPower;
        private System.Windows.Forms.Label tab1labelWindDirection;
        private System.Windows.Forms.Label tab1labelTemperature;
        private System.Windows.Forms.Label tab1labelCityName;
        private System.Windows.Forms.StatusStrip InfoAndStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssName;
        private System.Windows.Forms.ToolStripStatusLabel tssStuId;
        private System.Windows.Forms.ToolStripStatusLabel tssTheClass;
        private System.Windows.Forms.ToolStripStatusLabel tssContactMe;
        private System.Windows.Forms.ToolStripStatusLabel tssTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel tssCity;
        private System.ComponentModel.BackgroundWorker bgwWeather;
        private System.Windows.Forms.Label labelChangeBgImg;
        private System.Windows.Forms.Label labelExit;
        private System.Windows.Forms.Label labelMaxi;
        private System.Windows.Forms.Label labelMinimize;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label tab2lableCityName;
        private System.Windows.Forms.Label tab2labelTemperature;
        private System.Windows.Forms.Label tab2lableWeather;
        private System.Windows.Forms.Label tab2lableUpdateTime;
        private System.Windows.Forms.Label tablabelIPAddress;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.GroupBox gbMenu;
        private System.Windows.Forms.FlowLayoutPanel fpMenu;
        protected System.Windows.Forms.Label labelTitle;
        protected System.Windows.Forms.Label labelNoticeMain;
        protected System.Windows.Forms.Button btnSubmitMain;
    }
}

