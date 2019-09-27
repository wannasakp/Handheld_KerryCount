using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace ASSET_HH
{
    public partial class frmDoclist : Form
    {
        string strcon = "Data Source=" + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data\\Master.sdf;";

        public frmDoclist()
        {
            InitializeComponent();
        }

        private void get_listDoc()
        {
            //string strcon = "Data Source=" + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data\\Master.sdf;";
            SqlCeConnection con = new SqlCeConnection(strcon);
            string up = string.Empty;
            try
            {
                con.Open();
                string sql = "select DPID,DPNAME  from Department";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, con);

                DataSet ds = new DataSet();
                da.Fill(ds, "tt");
                DataTable dt = ds.Tables["tt"];

                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = dt.TableName;

                DataGridTextBoxColumn column = new DataGridTextBoxColumn();
                column.MappingName = "DPID";
                column.HeaderText = "รหัส";
                column.Width = 60;
                tableStyle.GridColumnStyles.Add(column);

                DataGridTextBoxColumn column2 = new DataGridTextBoxColumn();
                column2.MappingName = "DPNAME";
                column2.HeaderText = "ชื่อแผนก";
                column2.Width = 280;
                tableStyle.GridColumnStyles.Add(column2);

                dgDocList.DataSource = dt;
                dgDocList.TableStyles.Add(tableStyle);
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_stcode.Text == null || txt_stcode.Text == "")
            {
                MessageBox.Show("กรุณากรอกรหัสผู้ตรวจ");
            }
            else
            {
                if(txt_location.Text == null || txt_location.Text == "")
                {
                    MessageBox.Show("กรุณากรอกรหัสแผนก/สาขา");
                }
                else
                {
                    string DPCODE = txt_location.Text;
                    string STCODE = txt_stcode.Text;
                    frmInput frm = new frmInput(DPCODE, STCODE);
                    frm.ShowDialog();
                }
                
            }

            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoclist_Load(object sender, EventArgs e)
        {
            get_listDoc();
            txt_stcode.Focus();
        }

        private void dgDocList_Click(object sender, EventArgs e)
        {
            string DPID = this.dgDocList[this.dgDocList.CurrentRowIndex, 0].ToString();
            string DPNAME = this.dgDocList[this.dgDocList.CurrentRowIndex, 1].ToString();

            txt_location.Text = DPID;
        }
    }
}