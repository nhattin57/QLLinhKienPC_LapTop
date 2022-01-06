
namespace QLLinhKien
{
    partial class frmNhaCungCap
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
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnNoSave = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lsvSupplier = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtNumberPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameSupplier = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdderssSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtIdSupplier = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(344, 79);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 47);
            this.btnExcel.TabIndex = 104;
            this.btnExcel.Text = "xuất excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnNoSave
            // 
            this.btnNoSave.Location = new System.Drawing.Point(236, 495);
            this.btnNoSave.Name = "btnNoSave";
            this.btnNoSave.Size = new System.Drawing.Size(75, 46);
            this.btnNoSave.TabIndex = 102;
            this.btnNoSave.Text = "Không Lưu";
            this.btnNoSave.UseVisualStyleBackColor = true;
            this.btnNoSave.Click += new System.EventHandler(this.btnNoSave_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(344, 495);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 46);
            this.btnSave.TabIndex = 103;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lsvSupplier
            // 
            this.lsvSupplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvSupplier.FullRowSelect = true;
            this.lsvSupplier.GridLines = true;
            this.lsvSupplier.HideSelection = false;
            this.lsvSupplier.Location = new System.Drawing.Point(16, 192);
            this.lsvSupplier.Name = "lsvSupplier";
            this.lsvSupplier.Size = new System.Drawing.Size(412, 283);
            this.lsvSupplier.TabIndex = 101;
            this.lsvSupplier.UseCompatibleStateImageBehavior = false;
            this.lsvSupplier.View = System.Windows.Forms.View.Details;
            this.lsvSupplier.SelectedIndexChanged += new System.EventHandler(this.lsvSupplier_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhà cung cấp";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên nhà cung cấp";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số Điện Thoại";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Địa Chỉ";
            this.columnHeader4.Width = 200;
            // 
            // txtNumberPhone
            // 
            this.txtNumberPhone.Location = new System.Drawing.Point(176, 142);
            this.txtNumberPhone.Name = "txtNumberPhone";
            this.txtNumberPhone.Size = new System.Drawing.Size(154, 20);
            this.txtNumberPhone.TabIndex = 94;
            this.txtNumberPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberPhone_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 93;
            this.label4.Text = "Số điện thoại";
            // 
            // txtNameSupplier
            // 
            this.txtNameSupplier.Location = new System.Drawing.Point(176, 52);
            this.txtNameSupplier.Name = "txtNameSupplier";
            this.txtNameSupplier.Size = new System.Drawing.Size(154, 20);
            this.txtNameSupplier.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 24);
            this.label3.TabIndex = 91;
            this.label3.Text = "Tên nhà cung cấp";
            // 
            // txtAdderssSupplier
            // 
            this.txtAdderssSupplier.Location = new System.Drawing.Point(176, 93);
            this.txtAdderssSupplier.Name = "txtAdderssSupplier";
            this.txtAdderssSupplier.Size = new System.Drawing.Size(154, 20);
            this.txtAdderssSupplier.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 89;
            this.label2.Text = "Địa chỉ ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 24);
            this.label1.TabIndex = 87;
            this.label1.Text = "Mã nhà cung cấp";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(344, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 46);
            this.btnAdd.TabIndex = 100;
            this.btnAdd.Text = "thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(90, 521);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(105, 20);
            this.txtSearch.TabIndex = 99;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(445, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 46);
            this.btnEdit.TabIndex = 98;
            this.btnEdit.Text = "sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(9, 495);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 46);
            this.btnSearch.TabIndex = 97;
            this.btnSearch.Text = "tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(445, 82);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 46);
            this.btnExit.TabIndex = 96;
            this.btnExit.Text = "thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtIdSupplier
            // 
            this.txtIdSupplier.Location = new System.Drawing.Point(176, 12);
            this.txtIdSupplier.Name = "txtIdSupplier";
            this.txtIdSupplier.Size = new System.Drawing.Size(154, 20);
            this.txtIdSupplier.TabIndex = 88;
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 580);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnNoSave);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lsvSupplier);
            this.Controls.Add(this.txtNumberPhone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNameSupplier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAdderssSupplier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtIdSupplier);
            this.Name = "frmNhaCungCap";
            this.Text = "frmNhaCungCap";
            this.Load += new System.EventHandler(this.frmNhaCungCap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnNoSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lsvSupplier;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtNumberPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdderssSupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtIdSupplier;
    }
}