
namespace QuanLyNhanSu
{
    partial class Main
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
            this.mpanelChinh = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // mpanelChinh
            // 
            this.mpanelChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mpanelChinh.HorizontalScrollbarBarColor = true;
            this.mpanelChinh.HorizontalScrollbarHighlightOnWheel = false;
            this.mpanelChinh.HorizontalScrollbarSize = 11;
            this.mpanelChinh.Location = new System.Drawing.Point(27, 75);
            this.mpanelChinh.Margin = new System.Windows.Forms.Padding(4);
            this.mpanelChinh.Name = "mpanelChinh";
            this.mpanelChinh.Size = new System.Drawing.Size(1058, 591);
            this.mpanelChinh.TabIndex = 0;
            this.mpanelChinh.VerticalScrollbarBarColor = true;
            this.mpanelChinh.VerticalScrollbarHighlightOnWheel = false;
            this.mpanelChinh.VerticalScrollbarSize = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 691);
            this.Controls.Add(this.mpanelChinh);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(27, 75, 27, 25);
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mpanelChinh;
    }
}

