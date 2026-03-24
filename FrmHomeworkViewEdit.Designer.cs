using System.Windows.Forms;
using System;

namespace HomeworkApp
{
    partial class FrmHomeworkViewEdit
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
            this.lblSubject = new Label();
            this.cmbSubject = new ComboBox();
            this.lblClass = new Label();
            this.cmbClass = new ComboBox();
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblTask = new Label();
            this.rtbTask = new RichTextBox();
            this.lblDueDate = new Label();
            this.dtpDueDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // lblSubject
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(30, 30);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(50, 13);
            this.lblSubject.Text = "Предмет:";
            // cmbSubject
            this.cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSubject.Location = new System.Drawing.Point(90, 30);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(300, 23);
            // lblClass
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(30, 70);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(50, 13);
            this.lblClass.Text = "Класс:";
            // cmbClass
            this.cmbClass.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClass.Location = new System.Drawing.Point(90, 70);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(300, 23);
            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(30, 110);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 13);
            this.lblTitle.Text = "Название:";
            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(90, 110);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(300, 23);
            // lblTask
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(30, 150);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(50, 13);
            this.lblTask.Text = "Задание:";
            // rtbTask
            this.rtbTask.Location = new System.Drawing.Point(90, 150);
            this.rtbTask.Name = "rtbTask";
            this.rtbTask.Size = new System.Drawing.Size(300, 150);
            // lblDueDate
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(30, 310);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(50, 13);
            this.lblDueDate.Text = "Срок:";
            // dtpDueDate
            this.dtpDueDate.Format = DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(90, 310);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(300, 23);
            // btnSave
            this.btnSave.Location = new System.Drawing.Point(90, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(250, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 30);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // FrmHomeworkViewEdit
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.rtbTask);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.lblSubject);
            this.Name = "FrmHomeworkViewEdit";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Редактирование задания";
            this.Load += new EventHandler(this.FrmHomeworkViewEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblSubject;
        private ComboBox cmbSubject;
        private Label lblClass;
        private ComboBox cmbClass;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblTask;
        private RichTextBox rtbTask;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;
        private Button btnSave;
        private Button btnCancel;
    }
}