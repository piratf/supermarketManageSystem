using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using System.Runtime.InteropServices;

namespace SMM
{
    public partial class frmChangePassword : Form
    {
        Model.User user;

        /// <summary>
        /// 测试用构造函数
        /// </summary>
        public frmChangePassword()
        {
            InitializeComponent();
            user = null;
        }

        /// <summary>
        /// 接受一个User参数的构造函数
        /// </summary>
        /// <param name="_user"></param>
        public frmChangePassword(User _user)
        {
            InitializeComponent();
            user = _user;
        }

        private void btnSubmitPassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            if (newPassword == "" || confirmPassword == "")
            {
                MessageBox.Show("不允许空密码");
            }
            else if (newPassword != confirmPassword)
            {
                MessageBox.Show("两次的输入密码不一致");
            }
            else if (!BLL.DBSafeHelper.ProcessSqlStr(oldPassword) || !BLL.DBSafeHelper.ProcessSqlStr(newPassword) ||
                !BLL.DBSafeHelper.ProcessSqlStr(confirmPassword))
            {
                MessageBox.Show("输入内容可能有风险，提交失败");
            }
            else
            {
                if (BLL.BLLAccess.login(user.UserID, txtOldPassword.Text.Trim()) != 0)
                {
                    MessageBox.Show("旧密码验证失败");
                }
                else
                {
                    if (BLL.BLLUser.changePassword(user.UserID, newPassword))
                    {
                        MessageBox.Show("密码修改成功");
                    }
                    else
                    {
                        MessageBox.Show("密码修改失败，请联系管理员");
                    }
                }
            }
        }

        // 移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // 窗体上鼠标按下时
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                // 移动窗体
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (user != null)
            {
                labelWelcome.Text += user.UserID;
            }
            else
            {
                labelWelcome.Text += Author.authorName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
