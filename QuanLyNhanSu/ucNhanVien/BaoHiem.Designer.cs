
namespace QuanLyNhanSu.ucNhanVien
{
    partial class BaoHiem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtSoBH = new System.Windows.Forms.TextBox();
            this.txtNoiKham = new System.Windows.Forms.TextBox();
            this.txtNoiCap = new System.Windows.Forms.TextBox();
            this.dtpNgayCap = new System.Windows.Forms.DateTimePicker();
            this.btnXacNhanBH = new System.Windows.Forms.Button();
            this.btnHuyBH = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã NV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số BH:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày cấp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 176);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nơi cấp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nơi khám";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(146, 74);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(110, 20);
            this.txtMaNV.TabIndex = 1;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            this.txtMaNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaNV_KeyPress);
            // 
            // txtSoBH
            // 
            this.txtSoBH.Location = new System.Drawing.Point(146, 106);
            this.txtSoBH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoBH.Name = "txtSoBH";
            this.txtSoBH.Size = new System.Drawing.Size(110, 20);
            this.txtSoBH.TabIndex = 1;
            this.txtSoBH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoBH_KeyPress);
            // 
            // txtNoiKham
            // 
            this.txtNoiKham.Location = new System.Drawing.Point(146, 210);
            this.txtNoiKham.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNoiKham.Name = "txtNoiKham";
            this.txtNoiKham.Size = new System.Drawing.Size(110, 20);
            this.txtNoiKham.TabIndex = 1;
            // 
            // txtNoiCap
            // 
            this.txtNoiCap.Location = new System.Drawing.Point(146, 172);
            this.txtNoiCap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNoiCap.Name = "txtNoiCap";
            this.txtNoiCap.Size = new System.Drawing.Size(110, 20);
            this.txtNoiCap.TabIndex = 1;
            // 
            // dtpNgayCap
            // 
            this.dtpNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayCap.Location = new System.Drawing.Point(146, 143);
            this.dtpNgayCap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpNgayCap.Name = "dtpNgayCap";
            this.dtpNgayCap.Size = new System.Drawing.Size(110, 20);
            this.dtpNgayCap.TabIndex = 2;
            // 
            // btnXacNhanBH
            // 
            this.btnXacNhanBH.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnXacNhanBH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanBH.Location = new System.Drawing.Point(75, 265);
            this.btnXacNhanBH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXacNhanBH.Name = "btnXacNhanBH";
            this.btnXacNhanBH.Size = new System.Drawing.Size(86, 25);
            this.btnXacNhanBH.TabIndex = 3;
            this.btnXacNhanBH.Text = "Xác nhận";
            this.btnXacNhanBH.UseVisualStyleBackColor = true;
            // 
            // btnHuyBH
            // 
            this.btnHuyBH.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyBH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBH.Location = new System.Drawing.Point(165, 265);
            this.btnHuyBH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHuyBH.Name = "btnHuyBH";
            this.btnHuyBH.Size = new System.Drawing.Size(90, 25);
            this.btnHuyBH.TabIndex = 3;
            this.btnHuyBH.Text = "Hủy";
            this.btnHuyBH.UseVisualStyleBackColor = true;
            // 
            // BaoHiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 329);
            this.Controls.Add(this.btnHuyBH);
            this.Controls.Add(this.btnXacNhanBH);
            this.Controls.Add(this.dtpNgayCap);
            this.Controls.Add(this.txtNoiCap);
            this.Controls.Add(this.txtNoiKham);
            this.Controls.Add(this.txtSoBH);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BaoHiem";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 16);
            this.Text = "Thông tin bảo hiểm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtSoBH;
        private System.Windows.Forms.TextBox txtNoiKham;
        private System.Windows.Forms.TextBox txtNoiCap;
        private System.Windows.Forms.DateTimePicker dtpNgayCap;
        private System.Windows.Forms.Button btnXacNhanBH;
        private System.Windows.Forms.Button btnHuyBH;
    }
}