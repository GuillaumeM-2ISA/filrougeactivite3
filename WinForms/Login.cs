using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Login : Form
    {
        DAL _dal = DAL.getDAL();

        public Login()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            var jwt = await _dal.LoginAsync(nicknameTextbox.Text, passwordTextbox.Text);

            if (jwt != null)
            {
                DevelopmentForm developmentForm = DevelopmentForm.getDevelopmentForm();
                developmentForm.Show();
                developmentForm.Grisage();
                this.Hide();
            }
            else
            {
                labelError.Visible = true;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            DevelopmentForm developmentForm = DevelopmentForm.getDevelopmentForm();
            developmentForm.Show();
            developmentForm.Grisage();
            this.Hide();
        }
    }
}
