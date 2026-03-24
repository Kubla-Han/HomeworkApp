using System.Windows.Forms;

namespace HomeworkApp
{
    partial class FrmPupilMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvHomework = new System.Windows.Forms.DataGridView();
            this.btnMarkDone = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHomework)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(26, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(145, 21);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Кабинет ученика";
            // 
            // dgvHomework
            // 
            this.dgvHomework.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHomework.Location = new System.Drawing.Point(26, 52);
            this.dgvHomework.Name = "dgvHomework";
            this.dgvHomework.ReadOnly = true;
            this.dgvHomework.Size = new System.Drawing.Size(634, 347);
            this.dgvHomework.TabIndex = 2;
            // 
            // btnMarkDone
            // 
            this.btnMarkDone.Location = new System.Drawing.Point(26, 407);
            this.btnMarkDone.Name = "btnMarkDone";
            this.btnMarkDone.Size = new System.Drawing.Size(171, 26);
            this.btnMarkDone.TabIndex = 1;
            this.btnMarkDone.Text = "Отметить выполненным";
            this.btnMarkDone.UseVisualStyleBackColor = true;
            this.btnMarkDone.Click += new System.EventHandler(this.btnMarkDone_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(489, 17);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(171, 26);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Выход";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FrmPupilMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 451);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMarkDone);
            this.Controls.Add(this.dgvHomework);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmPupilMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кабинет ученика";
            this.Load += new System.EventHandler(this.FrmPupilMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHomework)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblTitle;
        private DataGridView dgvHomework;
        private Button btnMarkDone;
        private Button btnLogout;
    }
}