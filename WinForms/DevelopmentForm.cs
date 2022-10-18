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
        DAL _dal = new DAL();
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
    }
}
