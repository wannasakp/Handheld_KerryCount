namespace ASSET_HH
{
    partial class frmInput
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
            this.btn_Asback = new System.Windows.Forms.Button();
            this.dataGridItem = new System.Windows.Forms.DataGrid();
            this.txt_ctcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ascode = new System.Windows.Forms.TextBox();
            this.lb_asset = new System.Windows.Forms.Label();
            this.lb_Lcinput = new System.Windows.Forms.Label();
            this.lb_Location = new System.Windows.Forms.Label();
            this.DTPS = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_stcode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Asback
            // 
            this.btn_Asback.Location = new System.Drawing.Point(68, 263);
            this.btn_Asback.Name = "btn_Asback";
            this.btn_Asback.Size = new System.Drawing.Size(105, 29);
            this.btn_Asback.TabIndex = 23;
            this.btn_Asback.Text = "กลับ";
            this.btn_Asback.Click += new System.EventHandler(this.btn_Asback_Click);
            // 
            // dataGridItem
            // 
            this.dataGridItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridItem.Location = new System.Drawing.Point(24, 114);
            this.dataGridItem.Name = "dataGridItem";
            this.dataGridItem.Size = new System.Drawing.Size(204, 139);
            this.dataGridItem.TabIndex = 22;
            this.dataGridItem.DoubleClick += new System.EventHandler(this.dataGridItem_DoubleClick);
            // 
            // txt_ctcode
            // 
            this.txt_ctcode.Location = new System.Drawing.Point(166, 87);
            this.txt_ctcode.Name = "txt_ctcode";
            this.txt_ctcode.Size = new System.Drawing.Size(62, 21);
            this.txt_ctcode.TabIndex = 21;
            this.txt_ctcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ctcode_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(161, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.Text = "ผู้ถือครอง";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.Text = "วันที่";
            // 
            // txt_ascode
            // 
            this.txt_ascode.Location = new System.Drawing.Point(24, 87);
            this.txt_ascode.Name = "txt_ascode";
            this.txt_ascode.Size = new System.Drawing.Size(115, 21);
            this.txt_ascode.TabIndex = 20;
            this.txt_ascode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ascode_KeyPress);
            // 
            // lb_asset
            // 
            this.lb_asset.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_asset.Location = new System.Drawing.Point(24, 64);
            this.lb_asset.Name = "lb_asset";
            this.lb_asset.Size = new System.Drawing.Size(67, 20);
            this.lb_asset.Text = "สินทรัพย์";
            // 
            // lb_Lcinput
            // 
            this.lb_Lcinput.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Lcinput.Location = new System.Drawing.Point(90, 38);
            this.lb_Lcinput.Name = "lb_Lcinput";
            this.lb_Lcinput.Size = new System.Drawing.Size(39, 20);
            // 
            // lb_Location
            // 
            this.lb_Location.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_Location.Location = new System.Drawing.Point(13, 38);
            this.lb_Location.Name = "lb_Location";
            this.lb_Location.Size = new System.Drawing.Size(89, 20);
            this.lb_Location.Text = "แผนก/สาขา";
            // 
            // DTPS
            // 
            this.DTPS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPS.Location = new System.Drawing.Point(78, 11);
            this.DTPS.Name = "DTPS";
            this.DTPS.Size = new System.Drawing.Size(150, 22);
            this.DTPS.TabIndex = 19;
            this.DTPS.ValueChanged += new System.EventHandler(this.DTPS_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(135, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.Text = "ผู้ตรวจ";
            // 
            // lb_stcode
            // 
            this.lb_stcode.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lb_stcode.Location = new System.Drawing.Point(180, 38);
            this.lb_stcode.Name = "lb_stcode";
            this.lb_stcode.Size = new System.Drawing.Size(48, 20);
            // 
            // frmInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(248, 304);
            this.Controls.Add(this.lb_stcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Asback);
            this.Controls.Add(this.dataGridItem);
            this.Controls.Add(this.txt_ctcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ascode);
            this.Controls.Add(this.lb_asset);
            this.Controls.Add(this.lb_Lcinput);
            this.Controls.Add(this.lb_Location);
            this.Controls.Add(this.DTPS);
            this.Name = "frmInput";
            this.Text = "frmInput";
            this.Load += new System.EventHandler(this.frmInput_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Asback;
        private System.Windows.Forms.DataGrid dataGridItem;
        private System.Windows.Forms.TextBox txt_ctcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ascode;
        private System.Windows.Forms.Label lb_asset;
        private System.Windows.Forms.Label lb_Lcinput;
        private System.Windows.Forms.Label lb_Location;
        internal System.Windows.Forms.DateTimePicker DTPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_stcode;
    }
}