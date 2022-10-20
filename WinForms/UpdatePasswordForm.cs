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
    public partial class UpdatePasswordForm : Form
    {
        DAL _dal = DAL.getDAL();

        public UpdatePasswordForm()
        {
            InitializeComponent();
        }

        private async void btnValid_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(newPasswordTextbox.Text))
            {
                labelError.Visible = true;
            }
            else
            {
                string res = await _dal.UpdatePasswordAsync(_dal.IdMember, newPasswordTextbox.Text);

                label2.Text = res;
                label2.Visible = true;
            }
        }
    }
}
