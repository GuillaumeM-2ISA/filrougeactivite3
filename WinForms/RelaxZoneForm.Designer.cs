
namespace WinForms
{
    partial class RelaxZoneForm
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
            this.labelError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.newTitleTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.modifiedIdCategoryTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.modifiedDescriptionTextbox = new System.Windows.Forms.TextBox();
            this.modifiedTitleTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabDelete = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tabRead = new System.Windows.Forms.TabPage();
            this.btnRead = new System.Windows.Forms.Button();
            this.dgvTopics = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.bsTopics = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.tabDelete.SuspendLayout();
            this.tabRead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTopics)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.dgvTopics);
            this.splitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer1.Size = new System.Drawing.Size(957, 582);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Location = new System.Drawing.Point(15, 46);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(152, 51);
            this.btnUpdatePassword.TabIndex = 5;
            this.btnUpdatePassword.Text = "Mettre à jour le mot de passe";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnRelaxZone
            // 
            this.btnRelaxZone.Enabled = false;
            this.btnRelaxZone.Location = new System.Drawing.Point(15, 360);
            this.btnRelaxZone.Name = "btnRelaxZone";
            this.btnRelaxZone.Size = new System.Drawing.Size(152, 29);
            this.btnRelaxZone.TabIndex = 4;
            this.btnRelaxZone.Text = "Espace détente";
            this.btnRelaxZone.UseVisualStyleBackColor = true;
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
            this.tabControl1.Controls.Add(this.tabEdit);
            this.tabControl1.Controls.Add(this.tabDelete);
            this.tabControl1.Controls.Add(this.tabRead);
            this.tabControl1.Location = new System.Drawing.Point(19, 424);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 137);
            this.tabControl1.TabIndex = 5;
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.labelError);
            this.tabAdd.Controls.Add(this.label2);
            this.tabAdd.Controls.Add(this.newDescriptionTextbox);
            this.tabAdd.Controls.Add(this.newTitleTextbox);
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
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(16, 81);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(342, 20);
            this.labelError.TabIndex = 7;
            this.labelError.Text = "Les champs titre et description doivent être rempli";
            this.labelError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description";
            // 
            // newDescriptionTextbox
            // 
            this.newDescriptionTextbox.Location = new System.Drawing.Point(107, 45);
            this.newDescriptionTextbox.Name = "newDescriptionTextbox";
            this.newDescriptionTextbox.Size = new System.Drawing.Size(351, 27);
            this.newDescriptionTextbox.TabIndex = 5;
            // 
            // newTitleTextbox
            // 
            this.newTitleTextbox.Location = new System.Drawing.Point(107, 10);
            this.newTitleTextbox.Name = "newTitleTextbox";
            this.newTitleTextbox.Size = new System.Drawing.Size(203, 27);
            this.newTitleTextbox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Titre";
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
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.modifiedIdCategoryTextbox);
            this.tabEdit.Controls.Add(this.label5);
            this.tabEdit.Controls.Add(this.label3);
            this.tabEdit.Controls.Add(this.modifiedDescriptionTextbox);
            this.tabEdit.Controls.Add(this.modifiedTitleTextbox);
            this.tabEdit.Controls.Add(this.label4);
            this.tabEdit.Controls.Add(this.btnEdit);
            this.tabEdit.Location = new System.Drawing.Point(4, 29);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(620, 104);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "Modifier";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // modifiedIdCategoryTextbox
            // 
            this.modifiedIdCategoryTextbox.Location = new System.Drawing.Point(459, 11);
            this.modifiedIdCategoryTextbox.Name = "modifiedIdCategoryTextbox";
            this.modifiedIdCategoryTextbox.Size = new System.Drawing.Size(50, 27);
            this.modifiedIdCategoryTextbox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Id de la catégorie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description";
            // 
            // modifiedDescriptionTextbox
            // 
            this.modifiedDescriptionTextbox.Location = new System.Drawing.Point(109, 48);
            this.modifiedDescriptionTextbox.Name = "modifiedDescriptionTextbox";
            this.modifiedDescriptionTextbox.Size = new System.Drawing.Size(351, 27);
            this.modifiedDescriptionTextbox.TabIndex = 9;
            // 
            // modifiedTitleTextbox
            // 
            this.modifiedTitleTextbox.Location = new System.Drawing.Point(109, 11);
            this.modifiedTitleTextbox.Name = "modifiedTitleTextbox";
            this.modifiedTitleTextbox.Size = new System.Drawing.Size(203, 27);
            this.modifiedTitleTextbox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Titre";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(503, 39);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Modifier";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // tabRead
            // 
            this.tabRead.Controls.Add(this.btnRead);
            this.tabRead.Location = new System.Drawing.Point(4, 29);
            this.tabRead.Name = "tabRead";
            this.tabRead.Padding = new System.Windows.Forms.Padding(3);
            this.tabRead.Size = new System.Drawing.Size(620, 104);
            this.tabRead.TabIndex = 3;
            this.tabRead.Text = "Consulter";
            this.tabRead.UseVisualStyleBackColor = true;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(126, 39);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(94, 29);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Consulter";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // dgvTopics
            // 
            this.dgvTopics.AllowUserToAddRows = false;
            this.dgvTopics.AllowUserToDeleteRows = false;
            this.dgvTopics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopics.Location = new System.Drawing.Point(19, 12);
            this.dgvTopics.MultiSelect = false;
            this.dgvTopics.Name = "dgvTopics";
            this.dgvTopics.ReadOnly = true;
            this.dgvTopics.RowHeadersVisible = false;
            this.dgvTopics.RowHeadersWidth = 51;
            this.dgvTopics.RowTemplate.Height = 29;
            this.dgvTopics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopics.Size = new System.Drawing.Size(728, 406);
            this.dgvTopics.TabIndex = 0;
            this.dgvTopics.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopics_CellDoubleClick);
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
            // RelaxZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 582);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RelaxZoneForm";
            this.Text = "Espace detente";
            this.Load += new System.EventHandler(this.DevelopmentForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.tabEdit.ResumeLayout(false);
            this.tabEdit.PerformLayout();
            this.tabDelete.ResumeLayout(false);
            this.tabRead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTopics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRelaxZone;
        private System.Windows.Forms.Button btnQuestions;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button btnDev;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TabPage tabDelete;
        private System.Windows.Forms.TextBox newTitleTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newDescriptionTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox modifiedDescriptionTextbox;
        private System.Windows.Forms.TextBox modifiedTitleTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.TabPage tabRead;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.BindingSource bsTopics;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox modifiedIdCategoryTextbox;
        private System.Windows.Forms.Button btnUpdatePassword;
    }
}

