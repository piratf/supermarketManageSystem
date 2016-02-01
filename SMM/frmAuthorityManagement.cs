using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace SMM
{
    /// <summary>
    /// 权限管理窗体
    /// 左侧的权限树和中间的ListView同步
    /// 用户可以通过右侧的按钮调整用户权限
    /// 用户可以将未分配的用户拖拽到超市里
    /// 未分配的用户默认是售货员权限，被分配到超市里之后才能登陆系统
    /// </summary>
    public partial class frmAuthorityManagement : SMM.frmMain
    {
        // 保存修改的记录
        // 使用Set合并重复的修改
        Dictionary<string, Model.User> modifySet;
        
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public frmAuthorityManagement()
        {
            user = null;
            supermarket = null;
            labelTitle.Text = frmSetting.authorityTitle;
            InitializeComponent();
        }

        /// <summary>
        /// 带参数构造函数
        /// 继承父类构造函数
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="_supermarket"></param>
        public frmAuthorityManagement(User _user, Supermarket _supermarket)
            : base(_user, _supermarket)
        {
            labelTitle.Text = frmSetting.authorityTitle;
            InitializeComponent();
        }


        /// <summary>
        /// 设置用户表表头
        /// </summary>
        private void setTableHead(DataTable userTable)
        {
            //添加表头（列）
            if (listViewAuthority.Columns.Count <= 0)
            {
                listViewAuthority.Columns.Add(userTable.Columns[0].ColumnName, 80, HorizontalAlignment.Center);
                listViewAuthority.Columns.Add(userTable.Columns[1].ColumnName, 90, HorizontalAlignment.Center);
                listViewAuthority.Columns.Add(userTable.Columns[2].ColumnName, -2, HorizontalAlignment.Center);
            }
        }

        /// <summary>
        /// 加载用户列表
        /// 隔行绘制绿色背景
        /// 未分配的用户用深蓝色表示
        /// 
        /// 每个行的Name为user的id
        /// 每个subitem的name为编号，text为内容
        /// </summary>
        private void loadUserTable()
        {
            listViewAuthority.Clear();

            DataTable userInfoFull = BLL.BLLUser.getUserInfoFull();
            DataTable userInfoSafe = BLL.BLLUser.getUserInfoSafe();
            setTableHead(userInfoFull);
            for (int i = 0; i < userInfoFull.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.Name = item.Text = userInfoFull.Rows[i][0].ToString();
                // 添加等级信息
                item.SubItems.Add(userInfoFull.Rows[i][1].ToString());
                item.SubItems[item.SubItems.Count - 1].Name = userInfoSafe.Rows[i][1].ToString();
                // 添加所属超市信息
                if (userInfoFull.Rows[i][2].ToString() == "")
                {
                    item.SubItems.Add(AuthorityName.unallocatedCH);
                    item.SubItems[item.SubItems.Count - 1].Name = AuthorityName.unallocatedEN;
                    item.BackColor = Color.PowderBlue;
                }
                else
                {
                    item.SubItems.Add(userInfoFull.Rows[i][2].ToString());
                    item.SubItems[item.SubItems.Count - 1].Name = userInfoSafe.Rows[i][2].ToString();
                }
                if ((i & 1) == 0 && item.BackColor != Color.PowderBlue)
                {
                    item.BackColor = Color.Azure;
                }
                listViewAuthority.Items.Add(item);
            }
        }

        /// <summary>
        /// 显示欢迎信息
        /// </summary>
        private void loadWelcome()
        {
            if (user != null && supermarket != null)
            {
                labelWelcome.Text += user.UserID;
                labelCurrentSupermarket.Text += supermarket.Name;
            }
            else
            {
                labelWelcome.Text += "piratf";
                labelCurrentSupermarket.Text += "后台模式";
            }
        }

        /// <summary>
        /// 向超市中添加用户
        /// </summary>
        /// <param name="_user"></param>
        /// <param name="_level1"></param>
        /// <param name="_level2"></param>
        private void addUser2Supermarket(string _name, int _level)
        {
            switch (_level)
            {
                case 0: treeAuthority.Nodes[0].Nodes[AuthorityName.level0].Nodes.Add(_name, _name); break;
                case 1: treeAuthority.Nodes[0].Nodes[AuthorityName.level1].Nodes.Add(_name, _name); break;
                case 2: treeAuthority.Nodes[0].Nodes[AuthorityName.level2].Nodes.Add(_name, _name); break;
                default: break;
            }
        }

        /// <summary>
        /// 加载权限树
        /// </summary>
        private void loadAuthorityTree()
        {
            treeAuthority.Nodes.Clear();
            DataTable supermarketDt = BLL.Authority.getSupermarketList();
            ArrayList userList = BLL.BLLUser.getUserList();
            ArrayList unallocatedList = new ArrayList();
            // 遍历所有超市
            foreach (DataRow dr in supermarketDt.Rows)
            {
                // 根节点为超市名称
                TreeNode root = new TreeNode(dr[SuperMarketTable.name].ToString());
                root.Name = dr[SuperMarketTable.id].ToString();
                this.treeAuthority.Nodes.Add(root);
                TreeNode level2 = new TreeNode(AuthorityName.level2);
                level2.Name = AuthorityName.level2;
                TreeNode level1 = new TreeNode(AuthorityName.level1);
                level1.Name = AuthorityName.level1;
                TreeNode level0 = new TreeNode(AuthorityName.level0);
                level0.Name = AuthorityName.level0;
                root.Nodes.Add(level1);
                root.Nodes.Add(level2);
                root.Nodes.Add(level0);
                foreach (Model.User user in userList)
                {
                    if (user.Supermarket == root.Name)
                    {
                        addUser2Supermarket(user.UserID, user.Level);
                    }
                    else
                    {
                        unallocatedList.Add(user);
                    }
                }
            }

            TreeNode unallocated = new TreeNode(AuthorityName.unallocatedCH);
            unallocated.Name = AuthorityName.unallocatedEN;
            this.treeAuthority.Nodes.Add(unallocated);
            foreach (Model.User user in unallocatedList)
            {
                unallocated.Nodes.Add(new TreeNode(user.UserID));
            }

            treeAuthority.ExpandAll();
        }

        /// <summary>
        /// 窗体加载函数
        /// 加载欢迎信息
        /// 初始化修改日志
        /// 初始化ListView
        /// 加载权限编号和权限名称关系
        /// 加载所有用户的列表
        /// 加载左侧权限树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAuthorityManagement_Load(object sender, EventArgs e)
        {
            loadWelcome();
            modifySet = new Dictionary<string, Model.User>();
            frmClassSetting.setListView(listViewAuthority);

            // 加载所有用户的列表
            loadUserTable();

            // 加载左侧权限树
            loadAuthorityTree();
        }

        /// <summary>
        /// 给用户设置等级
        /// </summary>
        /// <param name="_level"></param>
        private void setLevel(int _level, string _levelName)
        {
            if (listViewAuthority.SelectedItems.Count < 1)
            {
                return;
            }
            if (listViewAuthority.SelectedItems[0].SubItems[2].Text == AuthorityName.unallocatedCH)
            {
                MessageBox.Show("尚未分配的用户，无法操作");
                return;
            }
            if (listViewAuthority.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listViewAuthority.SelectedItems.Count; i++)
                {
                    // 修改ListView中的内容，并添加到modifySet
                    string name = listViewAuthority.SelectedItems[i].SubItems[0].Text;
                    if (listViewAuthority.SelectedItems[i].SubItems[1].Text != _levelName)
                    {
                        if (modifySet.ContainsKey(name))
                        {
                            modifySet[name].Level = _level;
                        }
                        else
                        {
                            modifySet.Add(name, new Model.User(name, _level, listViewAuthority.SelectedItems[i].SubItems[2].Name));
                        }
                        listViewAuthority.SelectedItems[i].SubItems[1].Text = _levelName;
                    }

                    // 更新权限树
                    moveUserByLevel(name, _level);
                }
            }
        }

        private void moveUserByLevel(string _name, int _level)
        {
            TreeNode tn = treeAuthority.Nodes.Find(_name, true)[0];
            TreeNode newNode = (TreeNode)tn.Clone();
            addUser2Supermarket(_name, _level);
            tn.Remove();
        }

        /// <summary>
        /// 设置用户为售货员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetSeller_Click(object sender, EventArgs e)
        {
            setLevel(1, Model.AuthorityName.level1);
        }

        /// <summary>
        /// 窗体退出事件，如果有修改未提交会报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAuthorityManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modifySet.Count > 0)
            {
                if (MessageBox.Show("有修改未提交，是否退出？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// 设置用户为店长
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetAdmin_Click(object sender, EventArgs e)
        {
            setLevel(2, Model.AuthorityName.level2);
        }
            
        /// <summary>
        /// 设置用户为超级管理员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetRoot_Click(object sender, EventArgs e)
        {
            setLevel(0, Model.AuthorityName.level0);
        }

        /// <summary>
        /// 提交修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitMain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交？", labelNoticeMain.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                if (modifySet.Count <= 0)
                {
                    MessageBox.Show("未做任何修改");
                    return;
                }
                int submitFlag = 0;
                foreach (KeyValuePair<string, Model.User> pair in modifySet)
                {
                    if (!BLL.Authority.setAuthority(pair.Value))
                    {
                        submitFlag++;
                    }
                }
                if (submitFlag > 0)
                {
                    MessageBox.Show("有" + submitFlag + "条设置失败");
                }
                else
                {
                    MessageBox.Show("添加成功");
                }
                modifySet.Clear();
                loadUserTable();
                loadAuthorityTree();
            }
        }

        /// <summary>
        /// 拖动控件效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeAuthority_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && ((TreeNode)e.Item).Parent == treeAuthority.Nodes[AuthorityName.unallocatedEN])
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// 拖动完成后将节点加入到超市下方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeAuthority_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            // 根据鼠标坐标确定要移动到的目标节点
            Point pt;
            TreeNode targeNode;
            pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            targeNode = this.treeAuthority.GetNodeAt(pt);
            // 克隆新的节点进行插入
            TreeNode newNode = (TreeNode)moveNode.Clone();
            newNode.Name = newNode.Text;
            while (targeNode.Parent != null)
            {
                targeNode = targeNode.Parent;
            }
            if (targeNode.Name != "0")
            {
                return;
            }
            // 添加到售货员下
            targeNode.Nodes[0].Nodes.Add(newNode);

            // 插入完成后展开节点
            targeNode.Expand();

            // 删除中间变量
            moveNode.Remove();

            // 在列表中更新
            ListViewItem lvi = findUserInListView(newNode.Text);
            lvi.SubItems[2].Text = targeNode.Text;
            lvi.SubItems[2].Name = "0";
            addModifySet(lvi.Name, new User(lvi.Name, int.Parse(lvi.SubItems[1].Name), lvi.SubItems[2].Name));
        }

        private void addModifySet(string _userID, Model.User _user)
        {
            if (modifySet.ContainsKey(_userID))
            {
                modifySet[_userID].UserID = _user.UserID;
                modifySet[_userID].Level = _user.Level;
                modifySet[_userID].Supermarket = _user.Supermarket;
            }
            else
            {
                modifySet[_userID] = _user;
            }
        }

        private void treeAuthority_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 在列表中查找某个用户
        /// 用户名不会重复，所以只返回一个
        /// </summary>
        /// <param name="_userID"></param>  用户名
        /// <returns></returns>
        private ListViewItem findUserInListView(string _userID)
        {
            ListViewItem[] lvi = listViewAuthority.Items.Find(_userID, false);
            if (lvi.Length > 0)
            {
                return lvi[0];
            }
            else
            {
                return null;
            }
        }

        private void txtFindUser_Leave(object sender, EventArgs e)
        {
        }

        private void txtFindUser_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 通过用户名在列表中查找用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            if (txtFindUser.Text != "")
            {
                ListViewItem lvi = findUserInListView(txtFindUser.Text);
                if (lvi != null)
                {
                    listViewAuthority.Focus();
                    listViewAuthority.Items[lvi.Index].Selected = true;
                    listViewAuthority.Items[lvi.Index].Focused = true;
                    txtFindUser.Text = "";
                }
                else
                {
                    MessageBox.Show("未找到用户");
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除用户操作不可撤销，是否确认删除？", "删除用户", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (BLL.BLLUser.deleteUser(listViewAuthority.SelectedItems[0].Text))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            else
            {
                return;
            }
            loadUserTable();
            loadAuthorityTree();
        }

        /// <summary>
        /// 重新加载表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            loadUserTable();
            loadAuthorityTree();
        }
    }
}
