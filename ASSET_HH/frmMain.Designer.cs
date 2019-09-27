namespace ASSET_HH
{
    partial class frmMain
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
            this.btn_checkNet = new System.Windows.Forms.Button();
            this.btn_checkCount = new System.Windows.Forms.Button();
            this.sync_senddata = new System.Windows.Forms.Button();
            this.sync_asset = new System.Windows.Forms.Button();
            this.lbl_wait = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_checkNet
            // 
            this.btn_checkNet.Location = new System.Drawing.Point(38, 136);
            this.btn_checkNet.Name = "btn_checkNet";
            this.btn_checkNet.Size = new System.Drawing.Size(168, 48);
            this.btn_checkNet.TabIndex = 7;
            this.btn_checkNet.Text = "เช็คอินเตอร์เน็ต";
            this.btn_checkNet.Click += new System.EventHandler(this.btn_checkNet_Click);
            // 
            // btn_checkCount
            // 
            this.btn_checkCount.Location = new System.Drawing.Point(38, 82);
            this.btn_checkCount.Name = "btn_checkCount";
            this.btn_checkCount.Size = new System.Drawing.Size(168, 48);
            this.btn_checkCount.TabIndex = 6;
            this.btn_checkCount.Text = "ตรวจนับ";
            this.btn_checkCount.Click += new System.EventHandler(this.btn_checkCount_Click);
            // 
            // sync_senddata
            // 
            this.sync_senddata.Location = new System.Drawing.Point(39, 28);
            this.sync_senddata.Name = "sync_senddata";
            this.sync_senddata.Size = new System.Drawing.Size(168, 48);
            this.sync_senddata.TabIndex = 5;
            this.sync_senddata.Text = "ส่งข้อมูลสินทรัพย์";
            this.sync_senddata.Click += new System.EventHandler(this.sync_senddata_Click);
            // 
            // sync_asset
            // 
            this.sync_asset.Location = new System.Drawing.Point(52, 3);
            this.sync_asset.Name = "sync_asset";
            this.sync_asset.Size = new System.Drawing.Size(118, 19);
            this.sync_asset.TabIndex = 4;
            this.sync_asset.Text = "รับข้อมูลสินทรัพย์";
            this.sync_asset.Visible = false;
            this.sync_asset.Click += new System.EventHandler(this.sync_asset_Click);
            // 
            // lbl_wait
            // 
            this.lbl_wait.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_wait.Location = new System.Drawing.Point(70, 258);
            this.lbl_wait.Name = "lbl_wait";
            this.lbl_wait.Size = new System.Drawing.Size(100, 20);
            this.lbl_wait.Text = "Waiting.....";
            this.lbl_wait.Visible = false;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(39, 190);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(168, 48);
            this.btn_exit.TabIndex = 8;
            this.btn_exit.Text = "ปิดโปรแกรม";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(248, 304);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_wait);
            this.Controls.Add(this.btn_checkNet);
            this.Controls.Add(this.btn_checkCount);
            this.Controls.Add(this.sync_senddata);
            this.Controls.Add(this.sync_asset);
            this.Name = "frmMain";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_checkNet;
        private System.Windows.Forms.Button btn_checkCount;
        private System.Windows.Forms.Button sync_senddata;
        private System.Windows.Forms.Button sync_asset;
        private System.Windows.Forms.Label lbl_wait;
        private System.Windows.Forms.Button btn_exit;
    }
}

