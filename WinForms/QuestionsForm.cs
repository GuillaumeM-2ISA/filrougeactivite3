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
    public partial class QuestionsForm : Form
    {
        static QuestionsForm _questionsForm = null;

        DAL _dal = DAL.getDAL();
        List<Topic> _lstTopics;

        private QuestionsForm()
        {
            InitializeComponent();

            if (_dal.IdMember == -1)
            {
                btnUpdatePassword.Enabled = false;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (!_dal.Roles.Contains("MODERATOR"))
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        public static QuestionsForm getQuestionsForm()
        {
            if (_questionsForm == null)
                _questionsForm = new QuestionsForm();

            return _questionsForm;
        }

        private async Task RefreshAsync(int id = 0)
        {
            _lstTopics = await _dal.GetAllTopicsByCategoryIdAsync(3);
            bsTopics.DataSource = _lstTopics;
            bsTopics.ResetBindings(false);

            bsTopics.Position = _lstTopics.FindIndex(topic => topic.Id == id);
        }

        private async void DevelopmentForm_Load(object sender, EventArgs e)
        {
            await RefreshAsync();

            dgvTopics.DataSource = bsTopics;

            modifiedTitleTextbox.DataBindings.Add("Text", bsTopics, "Title", false, DataSourceUpdateMode.Never);
            modifiedDescriptionTextbox.DataBindings.Add("Text", bsTopics, "Description", false, DataSourceUpdateMode.Never);
            modifiedIdCategoryTextbox.DataBindings.Add("Text", bsTopics, "CategoryId", false, DataSourceUpdateMode.Never);

            dgvTopics.Columns["CreatedAt"].Visible = false;
            dgvTopics.Columns["UpdatedAt"].Visible = false;
            dgvTopics.Columns["Member"].Visible = false;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var topic = (Topic)bsTopics.Current;

            if (topic != null)
            {
                bool res = await _dal.DeleteTopicAsync(3, topic.Id);

                if (!res)
                    MessageBox.Show("Erreur lors de la suppression");

                await RefreshAsync();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(newTitleTextbox.Text) && String.IsNullOrEmpty(newDescriptionTextbox.Text))
            {
                labelError.Visible = true;
            }
            else
            {
                var newTopic = await _dal.AddTopicAsync(newTitleTextbox.Text, newDescriptionTextbox.Text, 3, _dal.IdMember);

                await RefreshAsync(newTopic.Id);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var topic = (Topic)bsTopics.Current;

            if (topic != null)
            {
                var updateUtil = await _dal.UpdateTopicAsync(topic.Id, modifiedTitleTextbox.Text, modifiedDescriptionTextbox.Text, int.Parse(modifiedIdCategoryTextbox.Text));
            }

            await RefreshAsync(topic.Id);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshAsync();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            var topic = (Topic)bsTopics.Current;

            TopicForm topicForm = new TopicForm(3, topic.Id);
            topicForm.Show();
            this.Hide();
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

        private void btnRelaxZone_Click(object sender, EventArgs e)
        {
            RelaxZoneForm relaxZoneForm = RelaxZoneForm.getRelaxZoneForm();
            relaxZoneForm.Show();
            this.Hide();
        }
    }
}
