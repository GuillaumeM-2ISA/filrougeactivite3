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
    }
}
