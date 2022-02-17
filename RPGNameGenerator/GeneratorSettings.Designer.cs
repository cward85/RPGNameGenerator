namespace RPGNameGenerator
{
    partial class GeneratorSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorSettings));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblAdjectiveList = new System.Windows.Forms.Label();
            this.lblNounList = new System.Windows.Forms.Label();
            this.lblPlaceList = new System.Windows.Forms.Label();
            this.lblModifierList = new System.Windows.Forms.Label();
            this.txtAdjective = new System.Windows.Forms.TextBox();
            this.txtNoun = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.btnAdjectiveFolder = new System.Windows.Forms.Button();
            this.btnNounFolder = new System.Windows.Forms.Button();
            this.btnPlaceFolder = new System.Windows.Forms.Button();
            this.btnModifierFolder = new System.Windows.Forms.Button();
            this.gbFileLists = new System.Windows.Forms.GroupBox();
            this.lblFileListDescription = new System.Windows.Forms.Label();
            this.grdSentenceStructure = new System.Windows.Forms.DataGridView();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFileLists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSentenceStructure)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(346, 492);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "Close";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblAdjectiveList
            // 
            this.lblAdjectiveList.AutoSize = true;
            this.lblAdjectiveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjectiveList.Location = new System.Drawing.Point(7, 22);
            this.lblAdjectiveList.Name = "lblAdjectiveList";
            this.lblAdjectiveList.Size = new System.Drawing.Size(75, 13);
            this.lblAdjectiveList.TabIndex = 1;
            this.lblAdjectiveList.Text = "Adjectives List";
            // 
            // lblNounList
            // 
            this.lblNounList.AutoSize = true;
            this.lblNounList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNounList.Location = new System.Drawing.Point(7, 50);
            this.lblNounList.Name = "lblNounList";
            this.lblNounList.Size = new System.Drawing.Size(57, 13);
            this.lblNounList.TabIndex = 4;
            this.lblNounList.Text = "Nouns List";
            // 
            // lblPlaceList
            // 
            this.lblPlaceList.AutoSize = true;
            this.lblPlaceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaceList.Location = new System.Drawing.Point(6, 76);
            this.lblPlaceList.Name = "lblPlaceList";
            this.lblPlaceList.Size = new System.Drawing.Size(58, 13);
            this.lblPlaceList.TabIndex = 7;
            this.lblPlaceList.Text = "Places List";
            // 
            // lblModifierList
            // 
            this.lblModifierList.AutoSize = true;
            this.lblModifierList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModifierList.Location = new System.Drawing.Point(6, 104);
            this.lblModifierList.Name = "lblModifierList";
            this.lblModifierList.Size = new System.Drawing.Size(68, 13);
            this.lblModifierList.TabIndex = 10;
            this.lblModifierList.Text = "Modifiers List";
            // 
            // txtAdjective
            // 
            this.txtAdjective.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjective.Location = new System.Drawing.Point(83, 19);
            this.txtAdjective.Name = "txtAdjective";
            this.txtAdjective.ReadOnly = true;
            this.txtAdjective.Size = new System.Drawing.Size(166, 20);
            this.txtAdjective.TabIndex = 2;
            // 
            // txtNoun
            // 
            this.txtNoun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoun.Location = new System.Drawing.Point(83, 47);
            this.txtNoun.Name = "txtNoun";
            this.txtNoun.ReadOnly = true;
            this.txtNoun.Size = new System.Drawing.Size(166, 20);
            this.txtNoun.TabIndex = 5;
            // 
            // txtPlace
            // 
            this.txtPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlace.Location = new System.Drawing.Point(83, 73);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.ReadOnly = true;
            this.txtPlace.Size = new System.Drawing.Size(166, 20);
            this.txtPlace.TabIndex = 8;
            // 
            // txtModifier
            // 
            this.txtModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifier.Location = new System.Drawing.Point(83, 101);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.ReadOnly = true;
            this.txtModifier.Size = new System.Drawing.Size(166, 20);
            this.txtModifier.TabIndex = 11;
            // 
            // btnAdjectiveFolder
            // 
            this.btnAdjectiveFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAdjectiveFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnAdjectiveFolder.Image")));
            this.btnAdjectiveFolder.Location = new System.Drawing.Point(255, 19);
            this.btnAdjectiveFolder.Name = "btnAdjectiveFolder";
            this.btnAdjectiveFolder.Size = new System.Drawing.Size(22, 20);
            this.btnAdjectiveFolder.TabIndex = 3;
            this.btnAdjectiveFolder.UseVisualStyleBackColor = true;
            this.btnAdjectiveFolder.Click += new System.EventHandler(this.btnAdjectiveFolder_Click);
            // 
            // btnNounFolder
            // 
            this.btnNounFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNounFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnNounFolder.Image")));
            this.btnNounFolder.Location = new System.Drawing.Point(255, 47);
            this.btnNounFolder.Name = "btnNounFolder";
            this.btnNounFolder.Size = new System.Drawing.Size(22, 20);
            this.btnNounFolder.TabIndex = 6;
            this.btnNounFolder.UseVisualStyleBackColor = true;
            this.btnNounFolder.Click += new System.EventHandler(this.btnNounFolder_Click);
            // 
            // btnPlaceFolder
            // 
            this.btnPlaceFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPlaceFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnPlaceFolder.Image")));
            this.btnPlaceFolder.Location = new System.Drawing.Point(255, 73);
            this.btnPlaceFolder.Name = "btnPlaceFolder";
            this.btnPlaceFolder.Size = new System.Drawing.Size(22, 20);
            this.btnPlaceFolder.TabIndex = 9;
            this.btnPlaceFolder.UseVisualStyleBackColor = true;
            this.btnPlaceFolder.Click += new System.EventHandler(this.btnPlaceFolder_Click);
            // 
            // btnModifierFolder
            // 
            this.btnModifierFolder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModifierFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnModifierFolder.Image")));
            this.btnModifierFolder.Location = new System.Drawing.Point(255, 101);
            this.btnModifierFolder.Name = "btnModifierFolder";
            this.btnModifierFolder.Size = new System.Drawing.Size(22, 20);
            this.btnModifierFolder.TabIndex = 12;
            this.btnModifierFolder.UseVisualStyleBackColor = true;
            this.btnModifierFolder.Click += new System.EventHandler(this.btnModifierFolder_Click);
            // 
            // gbFileLists
            // 
            this.gbFileLists.Controls.Add(this.lblFileListDescription);
            this.gbFileLists.Controls.Add(this.lblAdjectiveList);
            this.gbFileLists.Controls.Add(this.txtAdjective);
            this.gbFileLists.Controls.Add(this.btnModifierFolder);
            this.gbFileLists.Controls.Add(this.txtPlace);
            this.gbFileLists.Controls.Add(this.lblNounList);
            this.gbFileLists.Controls.Add(this.txtNoun);
            this.gbFileLists.Controls.Add(this.btnPlaceFolder);
            this.gbFileLists.Controls.Add(this.txtModifier);
            this.gbFileLists.Controls.Add(this.lblPlaceList);
            this.gbFileLists.Controls.Add(this.btnAdjectiveFolder);
            this.gbFileLists.Controls.Add(this.btnNounFolder);
            this.gbFileLists.Controls.Add(this.lblModifierList);
            this.gbFileLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFileLists.Location = new System.Drawing.Point(12, 12);
            this.gbFileLists.Name = "gbFileLists";
            this.gbFileLists.Size = new System.Drawing.Size(284, 160);
            this.gbFileLists.TabIndex = 15;
            this.gbFileLists.TabStop = false;
            this.gbFileLists.Text = "File Lists";
            // 
            // lblFileListDescription
            // 
            this.lblFileListDescription.AutoSize = true;
            this.lblFileListDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileListDescription.Location = new System.Drawing.Point(7, 135);
            this.lblFileListDescription.Name = "lblFileListDescription";
            this.lblFileListDescription.Size = new System.Drawing.Size(259, 13);
            this.lblFileListDescription.TabIndex = 13;
            this.lblFileListDescription.Text = "Select a file that has a comma separated list";
            // 
            // grdSentenceStructure
            // 
            this.grdSentenceStructure.AllowUserToAddRows = false;
            this.grdSentenceStructure.AllowUserToResizeColumns = false;
            this.grdSentenceStructure.AllowUserToResizeRows = false;
            this.grdSentenceStructure.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdSentenceStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSentenceStructure.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdSentenceStructure.Location = new System.Drawing.Point(9, 19);
            this.grdSentenceStructure.Name = "grdSentenceStructure";
            this.grdSentenceStructure.RowHeadersVisible = false;
            this.grdSentenceStructure.Size = new System.Drawing.Size(703, 249);
            this.grdSentenceStructure.TabIndex = 14;
            this.grdSentenceStructure.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSentenceStructure_CellClick);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.Location = new System.Drawing.Point(637, 274);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 15;
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddRow);
            this.groupBox1.Controls.Add(this.grdSentenceStructure);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 308);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sentence Structure";
            // 
            // GeneratorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 524);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbFileLists);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneratorSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.TopMost = true;
            this.gbFileLists.ResumeLayout(false);
            this.gbFileLists.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSentenceStructure)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblAdjectiveList;
        private System.Windows.Forms.Label lblNounList;
        private System.Windows.Forms.Label lblPlaceList;
        private System.Windows.Forms.Label lblModifierList;
        private System.Windows.Forms.TextBox txtAdjective;
        private System.Windows.Forms.TextBox txtNoun;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.Button btnAdjectiveFolder;
        private System.Windows.Forms.Button btnNounFolder;
        private System.Windows.Forms.Button btnPlaceFolder;
        private System.Windows.Forms.Button btnModifierFolder;
        private System.Windows.Forms.GroupBox gbFileLists;
        private System.Windows.Forms.Label lblFileListDescription;
        private System.Windows.Forms.DataGridView grdSentenceStructure;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}