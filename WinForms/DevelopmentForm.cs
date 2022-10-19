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
    public partial class DevelopmentForm : Form
    {
        DAL _dal = DAL.getDAL();
        List<Topic> _lstTopics;

        public DevelopmentForm()
        {
            InitializeComponent();
        }

        private async Task RefreshAsync(int id = 0)
        {
            _lstTopics = await _dal.GetAllTopicsByCategoryIdAsync(1);
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
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var topic = (Topic)bsTopics.Current;

            if (topic != null)
            {
                bool res = await _dal.DeleteTopicAsync(1, topic.Id);

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
                var newTopic = await _dal.AddTopicAsync(newTitleTextbox.Text, newDescriptionTextbox.Text, 1, _dal.IdMember);

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

            TopicForm topicForm = new TopicForm(1, topic.Id);
            topicForm.Show();
            this.Hide();
        }
    }
}
