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
    public partial class frmInput : Form
    {
        string strcon = "Data Source=" + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data\\Master.sdf;";
        string DPCODE_ = string.Empty;
        string STCODE_ = string.Empty;
        string DPNAME_ = string.Empty;
        string NAME = string.Empty;

        public frmInput(string DPCODE,string STCODE)
        {
            DPCODE_ = DPCODE;
            STCODE_ = STCODE;
            InitializeComponent();
        }

        public void loaddata()
        {
            string sdate = string.Empty;
            if (DTPS.Value.Year > 2550)
            {
                sdate = (DTPS.Value.Year - 543).ToString() + "." + DTPS.Value.Month.ToString() + "." + DTPS.Value.Day.ToString();
            }
            else
            {
                sdate = DTPS.Value.Year.ToString() + "." + DTPS.Value.Month.ToString() + "." + DTPS.Value.Day.ToString();
            }
            SqlCeConnection con = new SqlCeConnection(strcon);
            try
            {
                con.Open();
                string sql = "select *  from REPORT WHERE location = " + DPCODE_ + " AND workdate = '" + sdate + "' order by ID desc";

                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, con);

                dataGridItem.DataSource = null;

                DataSet ds = new DataSet();

                da.Fill(ds, "tt");
                DataTable dt = ds.Tables["tt"];

                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = dt.TableName;

                DataGridTextBoxColumn column = new DataGridTextBoxColumn();
                column.MappingName = "ID";
                column.HeaderText = "ID";
                column.Width = 0;
                tableStyle.GridColumnStyles.Add(column);

                DataGridTextBoxColumn column2 = new DataGridTextBoxColumn();
                column2.MappingName = "assetid";
                column2.HeaderText = "รหัส";
                column2.Width = 90;
                tableStyle.GridColumnStyles.Add(column2);

                DataGridTextBoxColumn column3 = new DataGridTextBoxColumn();
                column3.MappingName = "name";
                column3.HeaderText = "ชื่อทรัพย์สิน";
                column3.Width = 170;
                tableStyle.GridColumnStyles.Add(column3);

                DataGridTextBoxColumn column4 = new DataGridTextBoxColumn();
                column4.MappingName = "ctcode";
                column4.HeaderText = "ถือครอง";
                column4.Width = 100;
                tableStyle.GridColumnStyles.Add(column4);

                dataGridItem.DataSource = dt;
                dataGridItem.TableStyles.Clear();
                dataGridItem.TableStyles.Add(tableStyle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            finally
            {
                con.Close();
            }
        }

        private void frmInput_Load(object sender, EventArgs e)
        {
            loaddata();
            lb_Lcinput.Text = DPCODE_;
            lb_stcode.Text = STCODE_;
            txt_ascode.Focus();
        }

        private void txt_ascode_KeyPress(object sender, KeyPressEventArgs e)
        {
            NAME = string.Empty;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txt_ascode.Text == null || txt_ascode.Text == "")
                {
                    MessageBox.Show("ใส่ข้อมูลไม่ครบ");
                }
                else
                {
                    try
                    {
                        string ASSETID = txt_ascode.Text.ToString();
                        txt_ctcode.Focus();
                        using (SqlCeConnection con = new SqlCeConnection(strcon))
                        {
                            con.Open();
                            string sql_check = @"SELECT NAME FROM MAS_ASSET WHERE ASSETID = '" + ASSETID + "'";
                            using (SqlCeCommand command = new SqlCeCommand(sql_check, con))
                            {
                                using (SqlCeDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        NAME = (reader["NAME"].ToString());
                                    }
                                }
                            }
                            con.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void txt_ctcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string sdate = string.Empty;
                if (DTPS.Value.Year > 2550)
                {
                    sdate = (DTPS.Value.Year - 543).ToString() + "." + DTPS.Value.Month.ToString() + "." + DTPS.Value.Day.ToString();
                }
                else
                {
                    sdate = DTPS.Value.Year.ToString() + "." + DTPS.Value.Month.ToString() + "." + DTPS.Value.Day.ToString();
                }
                using (SqlCeConnection con = new SqlCeConnection(strcon))
                {
                    //if (NAME == null || NAME == "")
                    //{
                    //    MessageBox.Show("ไม่มีสินทรัพย์นี้");
                    //    txt_ascode.Text = string.Empty;
                    //    txt_ctcode.Text = string.Empty;
                    //    txt_ascode.Focus();
                    //}
                    //else
                    //{
                    //    //progress insert
                    //}


                    int check = 0;
                    con.Open();
                    string sqlCheck = @"SELECT ID FROM REPORT WHERE assetid = '" + txt_ascode.Text + "' AND location = '" + DPCODE_ + "' AND workdate = '" + sdate + "'";
                    using (SqlCeCommand command = new SqlCeCommand(sqlCheck, con))
                    {
                        using (SqlCeDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                check = Convert.ToInt32(reader["ID"].ToString());
                            }
                        }
                    }
                    if (check == 0)
                    {
                        string sql = @"INSERT REPORT (workdate,location,assetid,ctcode,name,stcode) VALUES ('" + sdate + "','" + DPCODE_ + "','" + txt_ascode.Text + "','" + txt_ctcode.Text + "','" + NAME + "','" + STCODE_ + "')";
                        SqlCeCommand cm = new SqlCeCommand(sql, con);
                        cm.ExecuteNonQuery();
                        con.Close();
                        txt_ascode.Text = string.Empty;
                        txt_ctcode.Text = string.Empty;
                        txt_ascode.Focus();

                        loaddata();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("ยิงสินทรัพย์นี้ไปแล้ว");
                        txt_ascode.Text = string.Empty;
                        txt_ctcode.Text = string.Empty;
                        txt_ascode.Focus();
                    }
                    
                }
            }
        }

        private void btn_Asback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridItem_DoubleClick(object sender, EventArgs e)
        {

            string ID = this.dataGridItem[this.dataGridItem.CurrentRowIndex, 0].ToString();
            string ASSETID = this.dataGridItem[this.dataGridItem.CurrentRowIndex, 1].ToString();
            string ASSETNAME = this.dataGridItem[this.dataGridItem.CurrentRowIndex, 2].ToString();
            DialogResult dialogResult = MessageBox.Show("ยืนยันการลบ \n" + ASSETID + "\n", "ลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            string sdate = string.Empty;
            if (DTPS.Value.Year > 2550)
            {
                sdate = (DTPS.Value.Year - 543).ToString() + "." + DTPS.Value.Month.ToString() + "." + DTPS.Value.Day.ToString();
            }
            else
            {
                sdate = DTPS.Value.Year.ToString() + "." + DTPS.Value.Month.ToString() + "." + DTPS.Value.Day.ToString();
            }
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlCeConnection con = new SqlCeConnection(strcon))
                    {
                        con.Open();

                        //string sql = @"DELETE REPORT WHERE ID = " + ID + "AND workdate = '" + sdate + "', AND location = '" + DPCODE_ + "";
                        string sql = @"DELETE REPORT WHERE ID = " + ID;
                        SqlCeCommand cm = new SqlCeCommand(sql, con);
                        cm.ExecuteNonQuery();
                        con.Close();

                        loaddata();
                        txt_ascode.Text = string.Empty;
                        txt_ctcode.Text = string.Empty;
                        txt_ascode.Focus();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        
        }

        private void DTPS_ValueChanged(object sender, EventArgs e)
        {
            loaddata();
            txt_ascode.Text = string.Empty;
            txt_ctcode.Text = string.Empty;
            txt_ascode.Focus();
        }
    }
}