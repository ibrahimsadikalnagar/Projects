namespace WindowsFormPersentationLayer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewCountry = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.edltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountry)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1049, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add New Contact";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCountry
            // 
            this.dataGridViewCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCountry.ContextMenuStrip = this.contextMenuStrip3;
            this.dataGridViewCountry.Location = new System.Drawing.Point(12, 123);
            this.dataGridViewCountry.Name = "dataGridViewCountry";
            this.dataGridViewCountry.RowHeadersWidth = 51;
            this.dataGridViewCountry.RowTemplate.Height = 26;
            this.dataGridViewCountry.Size = new System.Drawing.Size(1170, 296);
            this.dataGridViewCountry.TabIndex = 1;
            this.dataGridViewCountry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.edltToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(211, 62);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // edltToolStripMenuItem
            // 
            this.edltToolStripMenuItem.Name = "edltToolStripMenuItem";
            this.edltToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.edltToolStripMenuItem.Text = "Edlt";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 450);
            this.Controls.Add(this.dataGridViewCountry);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountry)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewCountry;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem edltToolStripMenuItem;
    }
}

