using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SMM
{
    /// <summary>
    /// 主窗体
    /// 为其他各模块提供UI支持
    /// 控制窗体设计风格
    /// 提供员工信息存储
    /// </summary>
    public partial class frmMain : Form
    {
        //事件委托
        delegate void SetTextCallback(WeatherToday _wt);

        //动画效果常量
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        protected static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);

        // 移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //业务类
        BLL.Weather weatherBus = new Weather();
        BLL.IPPostion IpPostion = new IPPostion();

        //按钮图片数组
        List<Image> listImage = new List<Image>();
        Image bgImg = null;

        //用户信息对象
        protected Model.User user = null;

        //超市信息对象
        protected Supermarket supermarket = null;

        //下拉列表数据
        DataTable dtProvince;

        //天气类
        protected WeatherToday wt = null;
        protected WeatherNow wn = null;
        enum TssCity { SUCCESS, FAILED };
        TssCity cityInfo;

        //暂存字符串
        string tempTssCity = string.Empty;
        string ipv4 = string.Empty;

        /// <summary>
        /// 无参构造基本窗体
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            user = new User("piratf", -1, "-1");
            wn = null;
            wt = null;
        }

        /// <summary>
        /// 带参数构造窗体
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="_supermarket"></param>
        public frmMain(Model.User _user, Supermarket _supermarket = null, WeatherNow _wn = null, WeatherToday _wt = null)
        {
            try
            {
                user = new Model.User(_user.UserID, _user.Level, _user.Supermarket);
                supermarket = new Supermarket(_supermarket.Name);
                wn = null;
                wt = null;
                if (_wn != null)
                {
                    wn = _wn;
                }
                if (_wt != null)
                {
                    wt = _wt;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("用户信息加载失败，程序退出\n请联系管理员进行维护");
                Application.Exit();
            }
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            //获取和设置天气
            if (wn == null || wt == null)
            {
                bgwWeather.RunWorkerAsync();
            }
            else
            {
                setTss(wt);
                setLable(wn);
                setLable(wt);
            }

            //绘制圆角窗口
            SetWindowRegion();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, 
                Screen.PrimaryScreen.WorkingArea.Height);
       
            //隐藏天气面板
            GbCityInfo.Visible = false;

            labelNoticeMain.Text += labelTitle.Text;
        }

        /// <summary>
        /// 根据天气数据刷新UI
        /// </summary>
        /// <param name="_wt"></param>
        public void setLable(WeatherToday _wt)
        {
            this.Invoke(new EventHandler(delegate
            {
                this.tablabelIPAddress.Text = ipv4;
                this.tab2lableCityName.Text += _wt.weatherInfo.city;
                this.tab2labelTemperature.Text += _wt.weatherInfo.temp2 + "~" + _wt.weatherInfo.temp1;
                this.tab2lableWeather.Text += _wt.weatherInfo.weather;
                this.tab2lableUpdateTime.Text += _wt.weatherInfo.ptime;
            }));
        }

        /// <summary>
        /// 根据天气信息刷新UI
        /// </summary>
        /// <param name="_wn"></param>
        public void setLable(WeatherNow _wn)
        {
            this.Invoke(new EventHandler(delegate
            {
                this.tab1labelCityName.Text += _wn.weatherInfo.city;
                this.tab1labelRelativeHumidity.Text += _wn.weatherInfo.SD;
                this.tab1labelTemperature.Text += _wn.weatherInfo.temp + "℃";
                this.tab1labelWindDirection.Text += _wn.weatherInfo.WD;
                this.tab1labelWindPower.Text += _wn.weatherInfo.WS;
                this.tab1labelTime.Text += _wn.weatherInfo.time;
            }));
        }

        /// <summary>
        /// 更新ToolStatusStrip地址信息
        /// </summary>
        /// <param name="_wt"></param>
        private void setTss(WeatherToday _wt)
        {
            if (_wt != null)
            {
                // bgwWeather.ReportProgress(50, _wt);
                this.Invoke(new EventHandler(delegate
                {
                    tssCity.Text = _wt.weatherInfo.city + " " + _wt.weatherInfo.weather + " ";
                }));
            }
            else
            {
                tssCity.Text = "加载失败";
            }
        }

        /// <summary>
        /// 更新地址栏的时间显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.tssTime.Text = DateTime.Now.ToString();
        }
        
        /// <summary>
        /// 绘制圆角窗体
        /// </summary>
        private void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect, 10);
            this.Region = new Region(FormPath);
        }
        
        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }
        
        /// <summary>
        /// 主窗体调整大小时刷新背景图片，二次刷新窗体避免抖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            this.Refresh();
            SetWindowRegion();

            if (this.BackgroundImage != null)
            {
                setBGImg(this.BackgroundImage);
            }
        }

        /// <summary>
        /// 重新设置背景图片
        /// </summary>
        /// <param name="_img"></param>
        private void setBGImg(Image _img)
        {
            this.BackgroundImage = _img;
            //this.Height = this.BackgroundImage.Height;
        }

        /// <summary>
        /// 获取背景图片高度
        /// </summary>
        /// <param name="_img"></param>
        /// <returns></returns>
        private int getBGImgHeight(Image _img)
        {
            return (int)((double)_img.Height * ((double)this.Size.Width / (double)_img.Width));
        }


        /// <summary>
        /// 窗体拖动函数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                // 移动窗体
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /// <summary>
        /// 将图片压缩至指定大小
        /// </summary>
        /// <param name="srcImage"></param>
        /// <param name="_w"></param>
        /// <param name="_h"></param>
        /// <returns></returns>
        public Bitmap compressImage(Image srcImage, int _w, int _h)
        {
            // 缩小后的宽度 
            int newW = _w;
            // 缩小后的高度 
            int newH = _h;
            try
            {
                // 要保存到的图片 
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(srcImage, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 切换背景图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 背景图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "选择背景图片";
            openFileDialog.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|PNG图片|*.png";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bgImg = new Bitmap(openFileDialog.FileName);
                setBGImg(bgImg);
            }
        }

        /// <summary>
        /// 开启调整城市窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeLocation_Click(object sender, EventArgs e)
        {
            //loadCityList();
        }

        /// <summary>
        /// 加载城市列表
        /// </summary>
        private void loadCityList()
        {
            dtProvince = BLLUserConfig.getProvince();
        }

        /// <summary>
        /// 后台线程载入城市列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadCity_DoWork(object sender, DoWorkEventArgs e)
        {
            loadCityList();
        }

        /// <summary>
        /// 后台获取天气
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwWeather_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!bgwWeather.CancellationPending)
            {
                loadWeather();
            }
        }

        /// <summary>
        /// 联网获取天气
        /// </summary>
        private void loadWeather()
        {
            //显示天气
            string cityId = string.Empty;
                ipv4 = IpPostion.GetIp();
                if (ipv4 == null)
                {
                    tssCity.Text = "网络连接失败";
                    cityInfo = TssCity.FAILED;
                    return;
                }
                //this.tablabelIPAddress.Text += ipv4;
                //get city id by ipv4
                cityId = IpPostion.getCityId(ipv4);
                if (cityId == null)
                {
                    tssCity.Text = "网络连接失败";
                    cityInfo = TssCity.FAILED;
                    return;
                }
            wn = weatherBus.loadWeatherNow(cityId);
            wt = weatherBus.loadWeatherToday(cityId);
        }

        /// <summary>
        /// 后台载入天气完成后显示到UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwWeather_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setTss(wt);
            if (wn == null || wt == null)
            {
                tssCity.Text = "网络连接失败";
                cityInfo = TssCity.FAILED;
            }
            else
            {
                setLable(wn);
                setLable(wt);
            }
            return;
        }

        /// <summary>
        /// 选择城市时切换地区列表
        /// 因为地区列表不完整，为了用户体验，只需精确到城市即可
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dtArea = BLLUserConfig.getAreaFromCity(cmbCity.Text);
            //cmbArea.DataSource = dtArea;
            //cmbArea.DisplayMember = "area";
            //cmbArea.ValueMember = "area";
            //if (dtArea.Rows.Count > 0)
            //{
            //    cmbArea.SelectedIndex = 0;
            //}
        }

        /// <summary>
        /// 打开详细天气面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssCity_Click(object sender, EventArgs e)
        {
            if (cityInfo == TssCity.FAILED)
            {
                return;
            }
            if (GbCityInfo.Visible == true)
            {
                GbCityInfo.Visible = false;
                tssCity.Text = tempTssCity;
            }
            else
            {
                GbCityInfo.BringToFront();
                tempTssCity = tssCity.Text;
                tssCity.Text = "关闭页面";
                GbCityInfo.Visible = true;
            }
        }

        /// <summary>
        /// 状态栏城市部分鼠标离开事件
        /// 修改背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssCity_MouseLeave(object sender, EventArgs e)
        {
            tssCity.BackColor = Color.Gray;
        }


        /// <summary>
        /// 修改背景图片按钮点击事件
        /// 暂时不用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeBgImg_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 状态栏城市部分鼠标划过事件
        /// 修改背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssCity_MouseMove(object sender, MouseEventArgs e)
        {
            tssCity.BackColor = Color.DarkGray;
        }

        /// <summary>
        /// 皮肤按钮单击事件
        /// 暂时不用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "选择背景图片";
            openFileDialog.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|PNG图片|*.png";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bgImg = new Bitmap(openFileDialog.FileName);
                setBGImg(bgImg);
            }
        }

        /// <summary>
        /// 关闭按钮单击事件
        /// 完全退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelExit_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 最大化按钮单击事件
        /// 最大化和还原窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMaxi_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// 最小化按钮点击事件
        /// 最小化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 向菜单中动态填充菜单项
        /// </summary>
        /// <param name="_name"></param>
        /// <returns></returns>
        private int addMenuItem(string _name)
        {
            Label menuItem = new Label();
            menuItem.BackColor = Color.Transparent;
            menuItem.Text = _name;
            menuItem.Click += menuItem_Click;
            fpMenu.Controls.Add(menuItem);
            return menuItem.Height;
        }

        /// <summary>
        /// 菜单项点击事件
        /// 根据菜单项的标题标签名称打开不同的窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menuItem_Click(object sender, EventArgs e)
        {
            Label menuItem = (Label)sender;
            if (menuItem.Text == labelTitle.Text)
            {
                return;
            }
            switch (menuItem.Text)
            {
                case Model.frmSetting.paymentTitle: frmPaymentTermial fpt = new frmPaymentTermial(user, supermarket);
                    fpt.Show(); break;
                case Model.frmSetting.classTitle: frmClassSetting fcs = new frmClassSetting(user, supermarket);
                    fcs.Show(); break;
                case Model.frmSetting.itemTitle: frmMerchandiseManagement fmm = new frmMerchandiseManagement(user, supermarket);
                    fmm.Show(); break;
                case Model.frmSetting.authorityTitle: frmAuthorityManagement fam = new frmAuthorityManagement(user, supermarket);
                    fam.Show(); break;
                case Model.frmSetting.changePasswordTitle: frmChangePassword fcp = new frmChangePassword(user);
                    fcp.Owner = this;
                    fcp.ShowDialog();
                    break;
                case Model.frmSetting.checkPurchaseLog: frmCheckpurchaseLog fpc = new frmCheckpurchaseLog(user, supermarket);
                    fpc.Show(); break;
                default: break;
            }
            if (menuItem.Text != frmSetting.changePasswordTitle)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 菜单按钮单击事件
        /// 打开菜单，根据菜单项的数量自动维护菜单高度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelMenu_Click(object sender, EventArgs e)
        {
            if (fpMenu.Controls.Count <= 0)
            {
                if (user != null)
                {
                    addMenuItem(frmSetting.paymentTitle);
                    addMenuItem(frmSetting.changePasswordTitle);
                    if (user.Level > 1)
                    {
                        addMenuItem(frmSetting.itemTitle);
                        addMenuItem(frmSetting.classTitle);
                        addMenuItem(frmSetting.checkPurchaseLog);
                    }

                    if (user.Level == 0)
                    {
                        addMenuItem(frmSetting.authorityTitle);
                    }
                }
                gbMenu.Height = 27 * (fpMenu.Controls.Count + 1);
            }

            gbMenu.BringToFront();
            labelMenu.BringToFront();
            if (gbMenu.Visible == true)
            {
                gbMenu.Visible = false;
            }
            else
            {
                gbMenu.Visible = true;
            }
        }
    }
}
