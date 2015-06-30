using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using Vietbait.Lablink.TestInformation.UI.Forms;
using VNS.Libs;

namespace Lis.GiaoDien.Forms
{
    public partial class frmPrintBarcode : Form
    {
        public frmPrintBarcode()
        {
            InitializeComponent();
        }

        public int sobatdau = 0;
        public int soketthuc = 0;
        private void frmPrintBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                if (PrinterSettings.InstalledPrinters.Count > 0)
                {
                    foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                    {
                        cboPrinters.Items.Add(strPrinter);
                    }
                }
                if (cboPrinters.Items.Count == 0)
                {
                    MessageBox.Show(
                        "Không có máy in nào trong hệ thống\r\n" +
                        "Hoặc máy in chưa được kết nối với máy tính", "Thông Báo", MessageBoxButtons.OK);
                }
              
            }
            catch (Exception ex) 
            {
              
            }
        }

        public NumericUpDown NmrFrom
        {
            get { return nmrFrom; }
            set { nmrFrom = value; }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //sobatdau = Utility.Int16Dbnull(NmrFrom.Value);
                //soketthuc = Utility.Int16Dbnull(NmrTo.Value);
                FrmDangKyTraCuuNew a = new FrmDangKyTraCuuNew();
                if (chk4so.Checked)
                {
                    a.chk4so = true;
                }
                else
                {
                    a.chk4so = false;
                }
                a.sobatdau = Utility.Int16Dbnull(nmrFrom.Value);
                a.Soketthuc = Utility.Int16Dbnull(nmrTo.Value);
                a.Printbarcode();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
        }
    }
}
