
namespace BDHotel
{
    partial class DeleteEmployeesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Grid_EmployeesDelete = new System.Windows.Forms.DataGridView();
            this.txt_Delete = new System.Windows.Forms.TextBox();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_EmployeesDelete)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid_EmployeesDelete
            // 
            this.Grid_EmployeesDelete.AllowUserToAddRows = false;
            this.Grid_EmployeesDelete.AllowUserToDeleteRows = false;
            this.Grid_EmployeesDelete.AllowUserToResizeColumns = false;
            this.Grid_EmployeesDelete.AllowUserToResizeRows = false;
            this.Grid_EmployeesDelete.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.Grid_EmployeesDelete.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_EmployeesDelete.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Grid_EmployeesDelete.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_EmployeesDelete.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_EmployeesDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_EmployeesDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_EmployeesDelete.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grid_EmployeesDelete.EnableHeadersVisualStyles = false;
            this.Grid_EmployeesDelete.Location = new System.Drawing.Point(13, 39);
            this.Grid_EmployeesDelete.Name = "Grid_EmployeesDelete";
            this.Grid_EmployeesDelete.RowHeadersVisible = false;
            this.Grid_EmployeesDelete.Size = new System.Drawing.Size(673, 352);
            this.Grid_EmployeesDelete.TabIndex = 2;
            // 
            // txt_Delete
            // 
            this.txt_Delete.Location = new System.Drawing.Point(457, 5);
            this.txt_Delete.Name = "txt_Delete";
            this.txt_Delete.Size = new System.Drawing.Size(100, 20);
            this.txt_Delete.TabIndex = 3;
            // 
            // bt_Delete
            // 
            this.bt_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Delete.Location = new System.Drawing.Point(563, 3);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(132, 23);
            this.bt_Delete.TabIndex = 4;
            this.bt_Delete.Text = "Удалить сотрудника";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите код сотрудника, которого хотите удалить";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bt_Delete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Delete);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 30);
            this.panel1.TabIndex = 6;
            // 
            // DeleteEmployeesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(698, 399);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Grid_EmployeesDelete);
            this.Name = "DeleteEmployeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удалить сотрудника";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeleteEmployeesForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_EmployeesDelete)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid_EmployeesDelete;
        private System.Windows.Forms.TextBox txt_Delete;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}