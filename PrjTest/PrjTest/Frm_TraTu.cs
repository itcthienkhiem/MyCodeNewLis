using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using SubSonic;

namespace PrjTest
{
    public partial class Frm_TraTu : Form
    {
        public Frm_TraTu()
        {
            InitializeComponent();
        }

        private DataTable dttratu = null;

        private void txtTiengAnh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTiengAnh.TextLength > 0)
                {
                    txtTiengViet.Visible = true;
                    foreach (var text in lsttienganh)
                    { 
                         //txtTiengViet.Text = "";
                        if (txtTiengAnh.Text.Trim() == text.tentienganh)
                        {
                           // txtTiengViet.Text = "";
                            txtTiengViet.Text = text.TenTiengViet;
                            return;
                        }
                        else if (txtTiengAnh.Text.Trim() != text.tentienganh)
                        {
                            txtTiengViet.Text = "Đang cập nhật dữ liệu";
                        }
                    }
                  // txtTiengViet=;
                }
                else
                {
                   txtTiengViet.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo");
            }
        }
      
        List<clstentienganh> lsttienganh = new List<clstentienganh>();
        public class clstentienganh
        {
            public int id { get; set; }
            public string tentienganh { get; set; }
            public string TenTiengViet { get; set; }
        }     
        private void Frm_TraTu_Load(object sender, EventArgs e)
        {
            try
            {
               // txtTiengAnh.Focus();
               string xmlFile = "TraTuAnhViet.xml";
              
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFile, XmlReadMode.InferSchema);
                dttratu = dataSet.Tables[0];
                List<DataRow> list = new List<DataRow>();
                for (int j = 0; j < dttratu.Rows.Count; j++)
                {
                    clstentienganh tienganh=new clstentienganh();
                    tienganh.id = Convert.ToInt32(dttratu.Rows[j]["ID"]);
                    tienganh.tentienganh = dttratu.Rows[j]["Goc"].ToString();
                    tienganh.TenTiengViet = dttratu.Rows[j]["Nghia"].ToString();
                    lsttienganh.Add(tienganh);
                }
                txtTiengAnh.TiengAnh(lsttienganh);

                DataTable dt = new Select().From(LPatientInfo.Schema.Name).ExecuteDataSet().Tables[0];
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo");

            }
        }

        private void txtTiengViet_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Frm_TraTu_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void Frm_TraTu_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Escape)
            {
                Dispose(true);
            }
        }
    }
}
