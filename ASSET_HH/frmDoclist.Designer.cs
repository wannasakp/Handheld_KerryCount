namespace ASSET_HH
{
    partial class frmDoclist
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
            this.dgDocList = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.txt_stcode = new System.Windows.Forms.TextBox();
            this.lb_stcode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.Text = "แผนก / สาขา";
            // 
            // dgDocList
            // 
            this.dgDocList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDocList.Location = new System.Drawing.Point(17, 58);
            this.dgDocList.Name = "dgDocList";
            this.dgDocList.Size = new System.Drawing.Size(211, 171);
            this.dgDocList.TabIndex = 2;
            this.dgDocList.Click += new System.EventHandler(this.dgDocList_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "ยืนยัน";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_location
            // 
            this.txt_location.Location = new System.Drawing.Point(150, 32);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(78, 21);
            this.txt_location.TabIndex = 4;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(133, 246);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(81, 38);
            this.btn_back.TabIndex = 5;
            this.btn_back.Text = "กลับ";
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // txt_stcode
            // 
            this.txt_stcode.Location = new System.Drawing.Point(151, 5);
            this.txt_stcode.Name = "txt_stcode";
            this.txt_stcode.Size = new System.Drawing.Size(76, 21);
            this.txt_stcode.TabIndex = 7;
            // 
            // lb_stcode
            // 
            this.lb_stcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lb_stcode.Location = new System.Drawing.Point(41, 6);
            this.lb_stcode.Name = "lb_stcode";
            this.lb_stcode.Size = new System.Drawing.Size(95, 20);
            this.lb_stcode.Text = "รหัสผู้ตรวจ";
            // 
            // frmDoclist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(248, 304);
            this.Controls.Add(this.lb_stcode);
            this.Controls.Add(this.txt_stcode);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgDocList);
            this.Controls.Add(this.label1);
            this.Name = "frmDoclist";
            this.Text = "frmDoclist";
            this.Load += new System.EventHandler(this.frmDoclist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dgDocList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.TextBox txt_stcode;
        private System.Windows.Forms.Label lb_stcode;
    }
}