using Domain.Entities;
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
    public partial class TopicForm : Form
    {
        DAL _dal = DAL.getDAL();
        List<Response> _lstResponses;
        public int idCategory { get; set; }
        public int idTopic { get; set; }

        public TopicForm(int idCategory, int id)
        {
            this.idCategory = idCategory;
            this.idTopic = id;

            InitializeComponent();

            if (_dal.IdMember == -1)
            {
                btnUpdatePassword.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (!_dal.Roles.Contains("MODERATOR"))
            {
                btnDelete.Enabled = false;
            }
        }

        private async Task RefreshAsync(int id = 0)
        {
            _lstResponses = await _dal.GetAllResponsesByTopicIdAsync(this.idCategory, this.idTopic);
            bsResponses.DataSource = _lstResponses;
            bsResponses.ResetBindings(false);

            bsResponses.Position = _lstResponses.FindIndex(topic => topic.Id == id);
        }

        private async void TopicForm_Load(object sender, EventArgs e)
        {
            await RefreshAsync();

            dgvResponses.DataSource = bsResponses;
            dgvResponses.Columns["SentOn"].Visible = false;
            dgvResponses.Columns["Member"].Visible = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(contentTextbox.Text))
            {
                labelError.Visible = true;
            }
            else
            {
                var newResponse = await _dal.AddResponseAsync(this.idCategory, contentTextbox.Text, this.idTopic, _dal.IdMember);

                await RefreshAsync(newResponse.Id);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var response = (Response)bsResponses.Current;

            if (response != null)
            {
                bool res = await _dal.DeleteResponseAsync(this.idCategory, this.idTopic, response.Id);

                if (!res)
                    MessageBox.Show("Erreur lors de la suppression");

                await RefreshAsync();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshAsync();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            UpdatePasswordForm updatePasswordForm = new UpdatePasswordForm();
            updatePasswordForm.ShowDialog();
        }

        private void btnDev_Click(object sender, EventArgs e)
        {
            DevelopmentForm developmentForm = DevelopmentForm.getDevelopmentForm();
            developmentForm.Show();
            this.Hide();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = AddressForm.getAddressForm();
            addressForm.Show();
            this.Hide();
        }

        private void btnQuestions_Click(object sender, EventArgs e)
        {
            QuestionsForm questionsForm = QuestionsForm.getQuestionsForm();
            questionsForm.Show();
            this.Hide();
        }

        private void btnRelaxZone_Click(object sender, EventArgs e)
        {
            RelaxZoneForm relaxZoneForm = RelaxZoneForm.getRelaxZoneForm();
            relaxZoneForm.Show();
            this.Hide();
        }
    }
}
