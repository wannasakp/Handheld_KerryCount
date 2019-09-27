using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Data.SqlServerCe;
using System.Threading;

namespace ASSET_HH
{
    public partial class frmMain : Form
    {
        string strcon = "Data Source=" + Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data\\Master.sdf;";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btn_checkCount_Click(object sender, EventArgs e)
        {
            sync_asset.Enabled = false;
            sync_senddata.Enabled = false;
            this.BackColor = Color.LightGray;

            frmDoclist frm = new frmDoclist();
            frm.ShowDialog();
        }

        private void sync_asset_Click(object sender, EventArgs e)
        {
            sync_asset.Enabled = false;
            sync_senddata.Enabled = false;
            btn_checkCount.Enabled = false;
            btn_checkNet.Enabled = false;
            btn_exit.Enabled = false;
            lbl_wait.Visible = true;
            Application.DoEvents();
            calldatawithapi();
            lbl_wait.Visible = false;
            sync_asset.Enabled = true;
            sync_senddata.Enabled = true;
            btn_checkCount.Enabled = true;
            btn_checkNet.Enabled = true;
            btn_exit.Enabled = true;
        }

        private void calldatawithapi()
        {
            try
            {
                DateTime dt1 = DateTime.Now;

                var request = (HttpWebRequest)WebRequest.Create("http://5cosmeda.homeunix.com:89/ApiAx/api/Ax/GetAsset");
                request.Timeout = 40000;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var Listitem = JsonConvert.DeserializeObject<RetItems>(responseString);

                    using (SqlCeConnection con = new SqlCeConnection(strcon))
                    {
                        int i = 0;
                        con.Open();
                        SqlCeTransaction tx = con.BeginTransaction();
                        try
                        {
                            
                            if (Listitem.ListAssets.Count > 0)
                            {
                                string sqldelete = @"DELETE FROM MAS_ASSET";
                                SqlCeCommand cmdelete = new SqlCeCommand(sqldelete, con);
                                
                                cmdelete.ExecuteNonQuery();
                                string ASSETID = string.Empty;

                                foreach (var item in Listitem.ListAssets)
                                {
                                    string NAME = item.NAME.Replace("'", "");
                                    string sql = @"INSERT MAS_ASSET (ASSETID,NAME) VALUES ('" + item.ASSETID + "','" + NAME + "');";
                                    SqlCeCommand cm = new SqlCeCommand(sql, con);
                                    cm.Transaction = tx;
                                    cm.ExecuteNonQuery();
                                    i++;
                                    
                                }
                                tx.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            var x = i;
                            MessageBox.Show(ex.ToString() + "รับข้อมูลผิดพลาด");
                        }
                        con.Close();
                    }
                }
                //********************************************************

                var requestdepart = (HttpWebRequest)WebRequest.Create("http://5cosmeda.homeunix.com:89/ApiAx/api/Ax/GetDepartmentAsset");
                requestdepart.Timeout = 5000;

                using (var responsedepart = (HttpWebResponse)requestdepart.GetResponse())
                {
                    var responseString = new StreamReader(responsedepart.GetResponseStream()).ReadToEnd();
                    var Listitem = JsonConvert.DeserializeObject<RetItems>(responseString);

                    using (SqlCeConnection con = new SqlCeConnection(strcon))
                    {
                        con.Open();
                        try
                        {
                            if (Listitem.ListDepartmentAsset.Count > 0)
                            {
                                string sqldelete = @"DELETE FROM Department";
                                SqlCeCommand cmdelete = new SqlCeCommand(sqldelete, con);
                                cmdelete.ExecuteNonQuery();
                                string DPID = string.Empty;

                                foreach (var item in Listitem.ListDepartmentAsset)
                                {
                                    string NAME = item.NAME.Replace("'", "");
                                    string sql = @"INSERT Department (DPID,DPNAME) VALUES ('" + item.CODE + "','" + NAME + "');";
                                    SqlCeCommand cm = new SqlCeCommand(sql, con);
                                    cm.ExecuteNonQuery();
                                }
                            }
                            MessageBox.Show("รับข้อมูลสินทรัพย์เรียบร้อย");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString() + "รับข้อมูลผิดพลาด");
                        }
                        con.Close();
                    }
                }
                DateTime dt2 = DateTime.Now;
                string timea = "ใช้เวลา " + timeDiff(dt1, dt2);
                MessageBox.Show(timea);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด" + ex.Message);
            }
        }

        private void callbackdata()
        {
            SqlCeConnection con = new SqlCeConnection(strcon);
            try
            {
                con.Open();
                string sql = "SELECT ID,syscreate,workdate,location,assetid,ctcode,name,stcode  FROM REPORT";

                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, con);

                DataSet ds = new DataSet();
                da.Fill(ds, "tt");
                DataTable dt = ds.Tables["tt"];
                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);

                if (json != "[]")
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://5cosmeda.homeunix.com:89/BeautySystem/API/ReportAsset/InsertAsset");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    ASCIIEncoding encodedData = new ASCIIEncoding();
                    byte[] byteArray = encodedData.GetBytes(json);
                    httpWebRequest.ContentLength = byteArray.Length;
                    Stream newStream = httpWebRequest.GetRequestStream();
                    newStream.Write(byteArray, 0, byteArray.Length);
                    newStream.Close();

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        result = result.Substring(1);
                        result = result.Substring(0, result.Length - 1);
                        if (result == "0")
                        {
                            string sqldelete = @"DELETE FROM REPORT";
                            SqlCeCommand cmdeleteitem = new SqlCeCommand(sqldelete, con);
                            cmdeleteitem.ExecuteNonQuery();
                            MessageBox.Show("รับส่งข้อมูลสำเร็จ");
                        }
                        else
                        {
                            MessageBox.Show("ส่งข้อมูลผิดพลาด" + result);
                        }
                    }
                }
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

        public void Get_connect()
        {
            try
            {
                System.Net.IPHostEntry ipHe =
                    System.Net.Dns.GetHostByName("www.google.com");
                //return true;
                sync_asset.Invoke(new Action(() => sync_asset.Enabled = true));
                sync_senddata.Invoke(new Action(() => sync_senddata.Enabled = true));
                btn_checkNet.Invoke(new Action(() => btn_checkNet.Enabled = true));
                this.Invoke(new Action(() => this.BackColor = Color.Green));
            }
            catch
            {
                //return false;
                Thread.Sleep(100);
                this.Invoke(new Action(() => this.BackColor = Color.Red));
                btn_checkNet.Invoke(new Action(() => btn_checkNet.Enabled = true));
            }
            btn_checkCount.Invoke(new Action(() => btn_checkCount.Enabled = true));
            btn_exit.Invoke(new Action(() => btn_exit.Enabled = true));
        }

        public static string timeDiff(DateTime dt1, DateTime dt2)
        {
            //var diff = dt2.Subtract(dt1);
            TimeSpan diff = dt2.Subtract(dt1);
            var res = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);

            return res.ToString();
        }

        public class ListAssets
        {
            public string ASSETID { get; set; }
            public string NAME { get; set; }
        }

        public class ListDepartmentAsset
        {
            public string CODE { get; set; }
            public string NAME { get; set; }
        }

        public class RetItems
        {
            public string status { get; set; }
            public string message { get; set; }
            public int mint { get; set; }
            public List<ListAssets> ListAssets { get; set; }
            public List<ListDepartmentAsset> ListDepartmentAsset { get; set; }
        }

        private void sync_senddata_Click(object sender, EventArgs e)
        {
            sync_asset.Enabled = false;
            sync_senddata.Enabled = false;
            btn_checkCount.Enabled = false;
            btn_checkNet.Enabled = false;
            btn_exit.Enabled = false;
            lbl_wait.Visible = true;
            Application.DoEvents();
            callbackdata();
            lbl_wait.Visible = false;
            sync_asset.Enabled = true;
            sync_senddata.Enabled = true;
            btn_checkCount.Enabled = true;
            btn_checkNet.Enabled = true;
            btn_exit.Enabled = true;
        }

        private void btn_checkNet_Click(object sender, EventArgs e)
        {
            sync_asset.Invoke(new Action(() => sync_asset.Enabled = false));
            sync_senddata.Invoke(new Action(() => sync_senddata.Enabled = false));
            btn_checkCount.Invoke(new Action(() => btn_checkCount.Enabled = false));
            btn_checkNet.Invoke(new Action(() => btn_checkNet.Enabled = false));
            btn_exit.Invoke(new Action(() => btn_exit.Enabled = false));

            Thread pingThread = new Thread(() => Get_connect());
            pingThread.Start();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btn_checkNet_Click(sender, e);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }
}