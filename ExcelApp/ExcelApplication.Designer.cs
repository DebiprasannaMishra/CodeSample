namespace ExcelApp
{
    partial class ExcelApplication
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
            this.txtTask1 = new System.Windows.Forms.TextBox();
            this.txtTask2 = new System.Windows.Forms.TextBox();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTask4 = new System.Windows.Forms.TextBox();
            this.txtTask3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTask1
            // 
            this.txtTask1.Location = new System.Drawing.Point(155, 70);
            this.txtTask1.Name = "txtTask1";
            this.txtTask1.Size = new System.Drawing.Size(186, 26);
            this.txtTask1.TabIndex = 0;
            // 
            // txtTask2
            // 
            this.txtTask2.Location = new System.Drawing.Point(155, 118);
            this.txtTask2.Name = "txtTask2";
            this.txtTask2.Size = new System.Drawing.Size(186, 26);
            this.txtTask2.TabIndex = 1;
            // 
            // lblLine1
            // 
            this.lblLine1.AutoSize = true;
            this.lblLine1.Location = new System.Drawing.Point(84, 73);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(56, 20);
            this.lblLine1.TabIndex = 2;
            this.lblLine1.Text = "Task 1";
            // 
            // lblLine2
            // 
            this.lblLine2.AutoSize = true;
            this.lblLine2.Location = new System.Drawing.Point(84, 121);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(56, 20);
            this.lblLine2.TabIndex = 3;
            this.lblLine2.Text = "Task 2";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(90, 296);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(251, 37);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.Export_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Task 4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Task 3";
            // 
            // txtTask4
            // 
            this.txtTask4.Location = new System.Drawing.Point(155, 211);
            this.txtTask4.Name = "txtTask4";
            this.txtTask4.Size = new System.Drawing.Size(186, 26);
            this.txtTask4.TabIndex = 3;
            // 
            // txtTask3
            // 
            this.txtTask3.Location = new System.Drawing.Point(155, 166);
            this.txtTask3.Name = "txtTask3";
            this.txtTask3.Size = new System.Drawing.Size(186, 26);
            this.txtTask3.TabIndex = 2;
            // 
            // ExcelApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 394);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTask4);
            this.Controls.Add(this.txtTask3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.txtTask2);
            this.Controls.Add(this.txtTask1);
            this.Name = "ExcelApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTask1;
        private System.Windows.Forms.TextBox txtTask2;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTask4;
        private System.Windows.Forms.TextBox txtTask3;
    }
}

