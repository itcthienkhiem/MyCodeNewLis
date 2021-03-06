﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lis.BaoCao.XayDung;
using LIS.DAL;
using SubSonic;
using Microsoft.VisualBasic;
using VNS.Libs;
namespace VietBaIT.LABLink.Reports.Form_XD
{
    public partial class frm_XD_BAOCAO_LOAI_XN : Form
    {
        public frm_XD_BAOCAO_LOAI_XN()
        {
            InitializeComponent();
            gridEXExporter1.GridEX = grdList;
            CreateManagementUnit();
        }
        public static void CreateManagementUnit()
        {
            SqlQuery q = new Select().From(SysManagementUnit.Schema);
            var objManagementUnit = q.ExecuteSingle<SysManagementUnit>();
            if (objManagementUnit != null)
            {
                globalVariables.ParentBranch_Name = objManagementUnit.SParentBranchName;
                globalVariables.Branch_Name = objManagementUnit.SName;
                globalVariables.Branch_Phone = objManagementUnit.SPhone;
                globalVariables.Branch_Address = objManagementUnit.SAddress;
            }
        }
        /// <summary>
        /// hàm thực hiện vthoats form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExit_Click(object sender, EventArgs e)
        {
           this.Close();
        }
        /// <summary>
        /// HÀM THỰC HIỆN VIỆC XUẤT RA FILE EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Janus.Windows.GridEX.GridEXRow[] gridExRows = grdList.GetCheckedRows();
                if (grdList.RowCount <= 0)
                {
                    Utility.ShowMsg("Không có dữ liệu", "Thông báo");
                    grdList.Focus();
                    return;
                }
                saveFileDialog1.Filter = "Excel File(*.xls)|*.xls";
                saveFileDialog1.FileName = string.Format("{0}.xls", txtTieuDe.Text);
                //saveFileDialog1.ShowDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string sPath = saveFileDialog1.FileName;
                    FileStream fs = new FileStream(sPath, FileMode.Create);
                    fs.CanWrite.CompareTo(true);
                    fs.CanRead.CompareTo(true);
                    gridEXExporter1.Export(fs);
                    fs.Dispose();
                }
                saveFileDialog1.Dispose();
                saveFileDialog1.Reset();

            }
            catch (Exception exception)
            {

            }
          
        }

        private void cmdInPhieuXN_Click(object sender, EventArgs e)
        {
           

            DataTable v_dtData = new DataTable();
            v_dtData =
                SPs.XaydungBaocaoSluongLoaiXn(
                    chkByDate.Checked ? dtFromDate.Value : Convert.ToDateTime("01/01/1900"),
                    chkByDate.Checked ? dtToDate.Value : Utility.getSysDate(),
                    Utility.Int32Dbnull(cboDoiTuong.SelectedValue, -1),
                    Utility.Int32Dbnull(cboTestType.SelectedValue, -1),
                    Utility.Int32Dbnull(cboHos_Status.SelectedValue, -1), Utility.Int32Dbnull(cboKhoa.SelectedValue, -1)).GetDataSet().Tables[0];
            Utility.AddColumToDataTable(ref v_dtData,"STT",typeof(Int32));
            int stt = 1;
            foreach (DataRow drv in v_dtData.Rows)
            {
                drv["STT"] = stt;
                stt++;
            }
            v_dtData.AcceptChanges();
            grdList.DataSource = v_dtData;

            // SubSonic.StoredProcedure.
            if (v_dtData.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông báo");
                return;
            }
            //string sTungayDenNgay = dtFromDate.Value.Date != dtToDate.Value.Date
            //                         ? string.Format("{0} --- đến --- {1}", Getsday(dtFromDate.Value),
            //                                         Getsday(dtToDate.Value))
            //                         : Getsday(dtFromDate.Value);

            string sTungayDenNgay = string.Format("Từ ngày {0} đến {1} - Đối tượng : {2} - Loại xét nghiệm :{3}-Trạng thái :{4}", dtFromDate.Text, dtToDate.Text,
                                        cboDoiTuong.SelectedIndex >= 0
                                            ? Utility.sDbnull(cboDoiTuong.Text)
                                            : "Tất cả",
                                        cboTestType.SelectedIndex > 0
                                            ? Utility.sDbnull(cboTestType.Text)
                                            : "Tất cả",cboHos_Status.SelectedIndex>0?Utility.sDbnull(cboHos_Status.Text):"Tất cả");
            Utility.UpdateLogotoDatatable(ref v_dtData);
            Lis.BaoCao.XayDung.CRPT_XD_BAOCAO_SLUONG_LOAI_XN crpt = new CRPT_XD_BAOCAO_SLUONG_LOAI_XN();
            var objForm = new VietBaIT.LABLink.Reports.frmPrintPreview(txtTieuDe.Text, crpt, true, true);
            crpt.SetDataSource(v_dtData);
            crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) +
                                                                  "        NGƯỜI LẬP BẢNG KÊ                                                           KẾ TOÁN                "
                                                                      .Replace("#$X$#",
                                                                               Strings.Chr(34) + "&Chr(13)&" +
                                                                               Strings.Chr(34)) +
                                                                  Strings.Chr(34);
            crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
            crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
            crpt.SetParameterValue("sTitleReport", txtTieuDe.Text);
            crpt.SetParameterValue("sTuNgayDenNgay", sTungayDenNgay);
            crpt.SetParameterValue("sCurrentDate", Utility.FormatDateTime(dtNgayInPhieu.Value));
            /// crpt.SetParameterValue("NgayIn", "Ngày " + dtCreatePrint.Value.Day + " tháng " + dtCreatePrint.Value.Month + " năm " + dtCreatePrint.Value.Year);
            // crpt.SetParameterValue("TienBangChu", sMoneyByLetter.sMoneyToLetter(v_dtData.Compute("SUM(TONG)", "1=1").ToString()));
            //  crpt.SetParameterValue("DateTime", "Từ ngày: " + dtFromDate.Value.ToShortDateString() + " đến ngày: " + dtToDate.Value.ToShortDateString());
            objForm.crptViewer.ReportSource = crpt;
            objForm.ShowDialog();
            Utility.DefaultNow(this);
        }
        private void IntitalData()
        {
            SqlQuery sqlQuery = new Select().From(LObjectType.Schema).OrderAsc(LObjectType.Columns.SName);
            DataBinding.BindDataCombobox_Basic(cboDoiTuong, sqlQuery.ExecuteDataSet().Tables[0], LObjectType.Columns.Id,
                                       LObjectType.Columns.SName);
            sqlQuery = new Select().From(LDepartment.Schema).OrderAsc(LDepartment.Columns.SName);
            DataBinding.BindDataCombobox_Basic(cboKhoa, sqlQuery.ExecuteDataSet().Tables[0], LDepartment.Columns.Id,
                                      LDepartment.Columns.SName);
            sqlQuery = new Select().From(TTestTypeList.Schema).OrderAsc(TTestTypeList.Columns.IntOrder);
            DataBinding.BindDataCombobox_Basic(cboTestType, sqlQuery.ExecuteDataSet().Tables[0], TTestTypeList.Columns.TestTypeId,
                                      TTestTypeList.Columns.TestTypeName);


        }
        private void frm_XD_BAOCAO_LOAI_XN_Load(object sender, EventArgs e)
        {
            IntitalData();
        }
    }
}
