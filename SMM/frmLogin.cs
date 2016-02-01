using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Model;
using BLL;
using System.Data.SqlClient;

namespace SMM
{
    public partial class frmLogin : Form
    {
        //用户对象
        Model.User user = null;
        //超市对象
        Model.Supermarket supermarket = null;

        static int times = 0;

        //动画效果常量
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        
        //动画效果加载函数
        protected static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        public const Int32 AW_BLEND = 0x00080000;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_ACTIVATE = 0x00020000;

        //记录参数
        int tryCount = 0;
        int tryLimit = 100;
        bool userNameOK = true;
        bool pwdOK = true;
        enum frmType { LOGIN, REGIST};
        frmType frmtype = frmType.LOGIN;

        public frmLogin()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (frmtype == frmType.LOGIN)
            {
                exit();
            }
            else
            {
                BLLAccess.setUserList();
                showLoginInterFace();
            }
        }

        /// <summary>
        /// 检查用户的supermarketID，为空的用户还未分配职位，无法进入系统
        /// </summary>
        /// <returns></returns>
        private bool checkSupermarketID()
        {
            return user.Supermarket == "";
        }

        /// <summary>
        /// 设置超市属性的Model内容
        /// </summary>
        private void setSupermarketModel()
        {
            var obj = cmbLoadSupermarket.SelectedItem as DataRowView;
            supermarket = new Supermarket(obj[SuperMarketTable.name].ToString());
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (!BLL.DBSafeHelper.ProcessSqlStr(txtPassword.Text) || !BLL.DBSafeHelper.ProcessSqlStr(txtUserName.Text))
            {
                setUserNameStatusNO("可能有注入风险，拒绝操作");
                times++;
                return;
            }
            if (frmtype == frmType.LOGIN)
            {
                if (tryCount >= 3)
                {
                    MessageBox.Show("失败超过三次，自动退出");
                    Application.Exit();
                }
                if (login())
                {
                    if (checkSupermarketID())
                    {
                        setUserNameStatusNO("该用户的职位尚未安排，无法登陆");
                        return;
                    }
                    
                    showMainFrm();
                }
            }
            else
            {
                regist();
            }
        }

        /// <summary>
        /// 关闭当前窗体，显示主窗体
        /// </summary>
        private void showMainFrm()
        {
            // 售货员
            if (user.Level == 1)
            {
                frmPaymentTermial fpt = new frmPaymentTermial(user, supermarket);
                fpt.Show();
            }
            // 超市管理员
            else if (user.Level == 2)
            {
                frmMerchandiseManagement fmm = new frmMerchandiseManagement(user, supermarket);
                fmm.Show();
            }
            else if (user.Level == 0)
            {
                frmAuthorityManagement fam = new frmAuthorityManagement(user, supermarket);
                fam.Show();
            }
            this.Hide();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        private bool login()
        {
            btnLogin.Text = "启动中..";
            //drop space
            string userName = txtUserName.Text.Trim();
            string userPassword = txtPassword.Text.Trim();

            int loginStatus = BLLAccess.login(userName, userPassword);
            if (loginStatus == 0)
            {
                try
                {
                    user = BLLAccess.fillUserInfo(userName);
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("填充信息失败，程序结束");
                    Application.Exit();
                }

                setSupermarketModel();
                return true;
            }
            else
            {
                tryCount++;
                if (loginStatus == -1)
                {
                    //用户不存在
                    btnLogin.Text = "启动";
                    setUserNameStatusNO("用户不存在");
                    txtUserName.Focus();
                }
                else if (loginStatus == 1)
                {
                    //密码错误
                    btnLogin.Text = "启动";
                    setPwdStatusNO("密码错误");
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
                if (tryCount == tryLimit - 1)
                {
                    lnkTips.Text = "您已尝试" + tryCount + "次\n再次登录失败程序将自动退出";
                }
                if (tryCount == tryLimit)
                {
                    MessageBox.Show("多次尝试失败，程序自动退出...");
                    exit();
                }
            }
            return false;
        }

        /// <summary>
        /// 加载超市
        /// </summary>
        private void loadSupermarket()
        {
            DataTable dtItemClass = BLL.TableMethod.getSupermarketList();
            cmbLoadSupermarket.DataSource = dtItemClass;
            cmbLoadSupermarket.DisplayMember = SuperMarketTable.name;
            cmbLoadSupermarket.ValueMember = SuperMarketTable.id;
            cmbLoadSupermarket.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //AnimateWindow(this.Handle, 500, AW_BLEND | AW_CENTER | AW_ACTIVATE); 

            // 载入超市列表
            loadSupermarket();
            // 后台载入用户列表
            bgwLoadUserList.RunWorkerAsync();

            // 绘制界面
            lnkUserNameStatus.Enabled = false;
            lnkUserNameStatus.Text = "";
            lnkPasswordStatus.Enabled = false;
            lnkPasswordStatus.Text = "";
            lnkTips.Enabled = false;
            lnkTips.Text = "";

            // 准备输入
            txtUserName.Focus();
            this.txtPassword.Enabled = false;
        }

        /// <summary>
        /// 窗体退出
        /// </summary>
        private void exit()
        {
            this.Close();
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 点击新用户链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkNewUser.Visible = false;
            frmtype = frmType.REGIST;
            btnLogin.Text = "注册";
            btnExit.Text = "返回";
            this.Text = "新用户注册";
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        private void regist()
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            int lev = 1;


            if (userName == "")
            {
                //MessageBox.Show("用户名或密码不能为空");
                setUserNameStatusNO("用户名不能为空");
                txtUserName.Focus();
                userNameOK = false;
            }
            else if (password == "")
            {
                setPwdStatusNO("密码不能为空");
                txtPassword.Focus();
                userNameOK = false;
            }

            if (userNameOK == false || pwdOK == false)
            {
            }
            else
            {
                try
                {
                    if (BLLAccess.regist(userName, password, lev))
                    {
                        MessageBox.Show("注册成功");
                    }
                    else
                    {
                        MessageBox.Show("注册失败");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
        }

        /// <summary>
        /// 密码内容修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            cleanPwdStatus();
            if (frmtype == frmType.REGIST)
            {
                if (txtPassword.TextLength < 8)
                {
                    setPwdStatusNO("密码长度不能少于8位");
                    pwdOK = false;
                }
            }
            else if (frmtype == frmType.LOGIN)
            {
                if (txtUserName.TextLength == 0)
                {
                    setUserNameStatusNO("用户名不能为空");
                    userNameOK = false;
                }
            }
        }

        /// <summary>
        /// 绘制分割线
        /// </summary>
        private void drawLine()
        {
            Graphics g = this.CreateGraphics();
            g.DrawLine(new Pen(Color.Gray, 2), new Point(120, 24), new Point(120, 225));
            g.Dispose();
        }

        /// <summary>
        /// 窗体显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Shown(object sender, EventArgs e)
        {
            //初始化参数
            frmtype = frmType.LOGIN;
            userNameOK = true;
            pwdOK = true;
            tryCount = 0;
            drawLine();
        }

        /// <summary>
        /// 显示登录UI
        /// </summary>
        private void showLoginInterFace()
        {
            //绘制界面
            btnLogin.Text = "启动";
            btnExit.Text = "退出";
            this.Text = "登录";
            lnkNewUser.Visible = true;

            // 清除状态信息
            cleanUserNameStatus();
            cleanPwdStatus();
            frmtype = frmType.LOGIN;
            txtPassword.Text = "";
            txtUserName.Text = "";
        }

        /// <summary>
        /// 用户名文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            cleanUserNameStatus();
        }

        /// <summary>
        /// 清楚用户名提示内容
        /// </summary>
        private void cleanUserNameStatus()
        {
            picBoxUserNameStatus.Image = null;
            lnkUserNameStatus.Text = "";
        }

        /// <summary>
        /// 清除密码提示内容
        /// </summary>
        private void cleanPwdStatus()
        {
            picBoxPwdStatus.Image = null;
            lnkPasswordStatus.Text = "";
        }

        /// <summary>
        /// 设置用户名提示为成功
        /// </summary>
        private void setUserNameStatusOK()
        {
            picBoxUserNameStatus.Image = imgListLogin.Images["OK"];
            lnkUserNameStatus.Text = "";
            userNameOK = true;
        }

        /// <summary>
        /// 设置用户名提示为失败
        /// </summary>
        /// <param name="_content"></param>
        private void setUserNameStatusNO(string _content)
        {
            picBoxUserNameStatus.Image = imgListLogin.Images["NO"];
            lnkUserNameStatus.Text = _content;
            txtUserName.Focus();
        }

        /// <summary>
        /// 设置密码提示为成功
        /// </summary>
        private void setPwdStatusOK()
        {
            picBoxPwdStatus.Image = imgListLogin.Images["OK"];
            lnkPasswordStatus.Text = "";
            pwdOK = true;
        }

        /// <summary>
        /// 设置密码提示为失败
        /// </summary>
        /// <param name="_content"></param>
        private void setPwdStatusNO(string _content)
        {
            picBoxPwdStatus.Image = imgListLogin.Images["NO"];
            lnkPasswordStatus.Text = _content;
            txtPassword.Focus();
        }

        /// <summary>
        /// 提示文本抖动
        /// </summary>
        /// <param name="_lnk"></param>
        private void Txtshake( LinkLabel _lnk )
        {
            Random ran = new Random((int)DateTime.Now.Ticks);

            Point point = this.Location;

            for (int i = 0; i < 10; i++)
            {
                _lnk.Location = new Point(point.X + ran.Next(8) - 4, point.Y + ran.Next(8) - 4);
                _lnk.Show();
                System.Threading.Thread.Sleep(15);

                _lnk.Location = point;
                _lnk.Show();
                System.Threading.Thread.Sleep(15);
            }
        }

        /// <summary>
        /// 离开用户名文本框事件
        /// 做输入安全性检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (frmtype == frmType.REGIST)
            {
                if (txtUserName.Text == "")
                {
                    setUserNameStatusNO("用户名不能为空");
                    userNameOK = false;
                }
                else if (BLLAccess.isNameExist(txtUserName.Text))
                {
                    setUserNameStatusNO("该用户名已存在");
                    userNameOK = false;
                }
                else if (txtUserName.TextLength > 48)
                {
                    picBoxUserNameStatus.Image = imgListLogin.Images["NO"];
                    lnkUserNameStatus.Text = "用户名不能超过50字符";
                    userNameOK = false;
                }
                else
                {
                    setUserNameStatusOK();
                }
            }
            else
            {
                if (txtUserName.Text == "")
                {
                    setUserNameStatusNO("用户名不能为空");
                    userNameOK = false;
                }
            }
        }

        /// <summary>
        /// 离开密码文本框事件
        /// 判断密码长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (frmtype == frmType.REGIST)
            {
                if (txtPassword.Text.Length > 7)
                {
                    setPwdStatusOK();
                }
            }
        }


        /// <summary>
        /// 博客链接点击事件
        /// 进入博客链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkBlog.Links[0].LinkData = "http://piratf.ml";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());    
        }

        /// <summary>
        /// 后台载入用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadUserList_DoWork(object sender, DoWorkEventArgs e)
        {
            // 用户名单载入内存
            BLLAccess.setUserList();
        }

        /// <summary>
        /// 用户名文本框键盘按下事件
        /// 判断是否是回车键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPassword.Text == "")
                {
                    txtPassword.Focus();
                }
                else if (txtUserName.Text != "")
                {
                    btnLogin_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// 密码文本框键盘按下事件
        /// 判断是否是回车键，快速登陆或注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUserName.Text == "")
                {
                    txtUserName.Focus();
                }
                else if (txtPassword.Text != "")
                {
                    btnLogin_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// 登陆按钮键盘弹起事件
        /// 判断是否是回车键
        /// 代替点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (frmtype == frmType.LOGIN)
                {
                    login();
                }
                else
                {
                    regist();
                }
            }
        }

        private void bgwLoadUserList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                this.txtPassword.Enabled = true;
            }));
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
