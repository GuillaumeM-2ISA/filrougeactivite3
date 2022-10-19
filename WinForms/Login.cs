﻿using System;
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
            var jwt = await _dal.Login(nicknameTextbox.Text, passwordTextbox.Text);

            if (jwt != null)
            {
                DevelopmentForm developmentForm = new DevelopmentForm();
                developmentForm.Show();
                this.Hide();
            }
            else
            {
                labelError.Visible = true;
            }
        }
    }
}
