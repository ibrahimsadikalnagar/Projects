namespace PracticeCRUD
{
    partial class FrmMainWords
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
            this.btnAddNew = new System.Windows.Forms.Button();
            this.dataGridViewNewWord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewWord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(647, 29);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(128, 58);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Add New Words";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // dataGridViewNewWord
            // 
            this.dataGridViewNewWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNewWord.Location = new System.Drawing.Point(12, 136);
            this.dataGridViewNewWord.Name = "dataGridViewNewWord";
            this.dataGridViewNewWord.RowHeadersWidth = 51;
            this.dataGridViewNewWord.RowTemplate.Height = 26;
            this.dataGridViewNewWord.Size = new System.Drawing.Size(763, 264);
            this.dataGridViewNewWord.TabIndex = 1;
            // 
            // FrmMainWords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewNewWord);
            this.Controls.Add(this.btnAddNew);
            this.Name = "FrmMainWords";
            this.Text = "FrmMainWords";
            this.Load += new System.EventHandler(this.FrmMainWords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNewWord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView dataGridViewNewWord;
    }
}