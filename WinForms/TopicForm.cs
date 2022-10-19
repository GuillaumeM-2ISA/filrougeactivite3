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
    }
}
