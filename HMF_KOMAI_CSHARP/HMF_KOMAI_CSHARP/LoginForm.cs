using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HMF_KOMAI_CSHARP.DataModels;

namespace HMF_KOMAI_CSHARP
{
    public partial class LoginForm : Form
    {
        private User user;
        private SynchronizationContext uiCon;

        public LoginForm()
		{
            uiCon = SynchronizationContext.Current;
            InitializeComponent();
            user = new User();
            user.LoginEvent += LoginedCallback;
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void trueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.Status = AuthStatus.LOGINED;
        }

        private void falseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.Status = AuthStatus.NO_LOGIN;
        }

        private void showUserStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.Debug.ShowUserStatus(user);
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => { 
                System.Threading.Thread.Sleep(3000);	//DEBUG
				//ここで認証処理を行う
                if (true)
                {
                    User.CheckAuthentication(null, ref user);
					Utils.Debug.ShowUserStatus(user);
                }
            });
        }

		/// <summary>
		/// Userの認証ステータスが変更されたときのイベント
		/// UIスレッド以外にも、ワーカースレッドから呼び出される可能性があるのでSynchronizationContextを利用
		/// </summary>
		/// <param name="sender"></param>
        private void LoginedCallback(Object sender)
        {
            uiCon.Post(state => { 
				this.Hide();
				MainForm form = new MainForm(user);
				form.FormClosed += CloseMainForm;
				form.ShowDialog();
            }, null);
        }

        private void CloseMainForm(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
