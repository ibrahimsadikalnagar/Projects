namespace PracticeCRUD
{
    partial class Form2
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
            this.txtboxPersonID = new System.Windows.Forms.TextBox();
            this.buttonReturnData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtboxPersonID
            // 
            this.txtboxPersonID.Location = new System.Drawing.Point(34, 89);
            this.txtboxPersonID.Name = "txtboxPersonID";
            this.txtboxPersonID.Size = new System.Drawing.Size(170, 24);
            this.txtboxPersonID.TabIndex = 0;
            // 
            // buttonReturnData
            // 
            this.buttonReturnData.Location = new System.Drawing.Point(285, 75);
            this.buttonReturnData.Name = "buttonReturnData";
            this.buttonReturnData.Size = new System.Drawing.Size(159, 68);
            this.buttonReturnData.TabIndex = 1;
            this.buttonReturnData.Text = "ReturnForm1";
            this.buttonReturnData.UseVisualStyleBackColor = true;
            this.buttonReturnData.Click += new System.EventHandler(this.buttonReturnData_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 275);
            this.Controls.Add(this.buttonReturnData);
            this.Controls.Add(this.txtboxPersonID);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxPersonID;
        private System.Windows.Forms.Button buttonReturnData;
    }
}