
namespace WinForms
{
    partial class TopicForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.btnRelaxZone = new System.Windows.Forms.Button();
            this.btnQuestions = new System.Windows.Forms.Button();
            this.btnAddress = new System.Windows.Forms.Button();
            this.btnDev = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.contentTextbox = new System.Windows.Forms.RichTextBox();
            this.labelError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabDelete = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvResponses = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.bsResponses = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.tabDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResponses)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdatePassword);
            this.splitContainer1.Panel1.Controls.Add(this.btnRelaxZone);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuestions);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddress);
            this.splitContainer1.Panel1.Controls.Add(this.btnDev);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.dgvResponses);
            this.splitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer1.Size = new System.Drawing.Size(957, 582);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Location = new System.Drawing.Point(15, 44);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(152, 51);
            this.btnUpdatePassword.TabIndex = 6;
            this.btnUpdatePassword.Text = "Mettre à jour le mot de passe";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnRelaxZone
            // 
            this.btnRelaxZone.Location = new System.Drawing.Point(15, 360);
            this.btnRelaxZone.Name = "btnRelaxZone";
            this.btnRelaxZone.Size = new System.Drawing.Size(152, 29);
            this.btnRelaxZone.TabIndex = 4;
            this.btnRelaxZone.Text = "Espace détente";
            this.btnRelaxZone.UseVisualStyleBackColor = true;
            this.btnRelaxZone.Click += new System.EventHandler(this.btnRelaxZone_Click);
            // 
            // btnQuestions
            // 
            this.btnQuestions.Location = new System.Drawing.Point(15, 310);
            this.btnQuestions.Name = "btnQuestions";
            this.btnQuestions.Size = new System.Drawing.Size(152, 29);
            this.btnQuestions.TabIndex = 3;
            this.btnQuestions.Text = "Questions diverses";
            this.btnQuestions.UseVisualStyleBackColor = true;
            this.btnQuestions.Click += new System.EventHandler(this.btnQuestions_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(15, 263);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(152, 29);
            this.btnAddress.TabIndex = 2;
            this.btnAddress.Text = "Adresses utiles";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // btnDev
            // 
            this.btnDev.Location = new System.Drawing.Point(15, 216);
            this.btnDev.Name = "btnDev";
            this.btnDev.Size = new System.Drawing.Size(152, 29);
            this.btnDev.TabIndex = 1;
            this.btnDev.Text = "Développement";
            this.btnDev.UseVisualStyleBackColor = true;
            this.btnDev.Click += new System.EventHandler(this.btnDev_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAdd);
            this.tabControl1.Controls.Add(this.tabDelete);
            this.tabControl1.Location = new System.Drawing.Point(19, 424);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 137);
            this.tabControl1.TabIndex = 5;
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.contentTextbox);
            this.tabAdd.Controls.Add(this.labelError);
            this.tabAdd.Controls.Add(this.label1);
            this.tabAdd.Controls.Add(this.btnAdd);
            this.tabAdd.Location = new System.Drawing.Point(4, 29);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(620, 104);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Text = "Ajouter";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // contentTextbox
            // 
            this.contentTextbox.Location = new System.Drawing.Point(87, 13);
            this.contentTextbox.Name = "contentTextbox";
            this.contentTextbox.Size = new System.Drawing.Size(344, 65);
            this.contentTextbox.TabIndex = 8;
            this.contentTextbox.Text = "";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(16, 81);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(244, 20);
            this.labelError.TabIndex = 7;
            this.labelError.Text = "Le champs contenu doit être rempli";
            this.labelError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contenu";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(502, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabDelete
            // 
            this.tabDelete.Controls.Add(this.btnDelete);
            this.tabDelete.Location = new System.Drawing.Point(4, 29);
            this.tabDelete.Name = "tabDelete";
            this.tabDelete.Padding = new System.Windows.Forms.Padding(3);
            this.tabDelete.Size = new System.Drawing.Size(620, 104);
            this.tabDelete.TabIndex = 2;
            this.tabDelete.Text = "Supprimer";
            this.tabDelete.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(124, 39);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvResponses
            // 
            this.dgvResponses.AllowUserToAddRows = false;
            this.dgvResponses.AllowUserToDeleteRows = false;
            this.dgvResponses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResponses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResponses.Location = new System.Drawing.Point(19, 12);
            this.dgvResponses.MultiSelect = false;
            this.dgvResponses.Name = "dgvResponses";
            this.dgvResponses.ReadOnly = true;
            this.dgvResponses.RowHeadersVisible = false;
            this.dgvResponses.RowHeadersWidth = 51;
            this.dgvResponses.RowTemplate.Height = 29;
            this.dgvResponses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResponses.Size = new System.Drawing.Size(728, 406);
            this.dgvResponses.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(653, 492);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 29);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Actualiser";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // TopicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 582);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TopicForm";
            this.Text = "Sujet";
            this.Load += new System.EventHandler(this.TopicForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.tabDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResponses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResponses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRelaxZone;
        private System.Windows.Forms.Button btnQuestions;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button btnDev;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvResponses;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.BindingSource bsResponses;
        private System.Windows.Forms.RichTextBox contentTextbox;
        private System.Windows.Forms.Button btnUpdatePassword;
    }
}

