﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Janus.Windows.GridEX;
using LIS.DAL;
using Lis.Report.UI.Reports;
using newLib;
using SubSonic;
using VNS.Libs;
using AggregateFunction = SubSonic.AggregateFunction;

namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_BaoCaoDanhSachBenhNhan_TestTypeVSK : Form
    {
        public frm_BaoCaoDanhSachBenhNhan_TestTypeVSK()
        {
            InitializeComponent();
        }
        private DataTable dt;
        DataTable dtRawResult;
        private DataTable dtdsbenhnhanhoantat = null;
     private DataTable BC_DS_TestType;
     private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

     private void frm_DanhSachBenhNhan_TestType_Load(object sender, EventArgs e)
     {
         try
         {
            btnPrint.Click+= btnPrint_Click;
             cmdReport.Click += cmdReport_Click;
             cmdCancel.Click += cmdCancel_Click;
             DataTable TestType = new Select().From(TTestTypeList.Schema.Name).ExecuteDataSet().Tables[0];
             DataBinding.BindDataCombox(cboTestType,TestType,TTestTypeList.Columns.TestTypeId,
                                        TTestTypeList.Columns.TestTypeName,"----Chọn Xét Nghiệm ----");
         }
         catch (Exception ex)
         {
             Utility.ShowMsg(ex.ToString());
         }
     
     }
        private StoredProcedure BaocaoDSBNtheoTestType(DateTime? pFromDate, DateTime? pToDate, string testType, int check)
        {
            SubSonic.StoredProcedure sp = new StoredProcedure("spBaoCao_DSBN_TestType", DataService.GetInstance("ORM"),"dbo");
            sp.Command.AddParameter("@pFromDate", pFromDate,DbType.DateTime,null,null);
            sp.Command.AddParameter("@pToDate", pToDate,DbType.DateTime,null,null);
            sp.Command.AddParameter("@testType",testType,DbType.String,null,null);
            sp.Command.AddParameter("@Check", check, DbType.Int16, null, null);
            return sp;
        }
     
     private void cmdReport_Click(object sender, EventArgs e)
     {
            try
            {
                dt = new DataTable();
                dt.Columns.Add("PID");
                dt.Columns.Add("Patient_ID");
                dt.Columns.Add("Patient_Name");
                dt.Columns.Add("AGE");
                dt.Columns.Add("Sex");
                dt.Columns.Add("Department");
                dt.Columns.Add("Insurance_Num");
                dt.Columns.Add("Address");
                dt.Columns.Add("Diagnostic");
                dt.Columns.Add("AllResult");
                string testype_id = "";
           
             
                if (chkTongBNHoanTatXN.Checked)
                {
                    dt = BaocaoDSBNtheoTestType(dtpFromDate.Value,
                                                  dtpToDate.Value,"-1",1).
                                                  GetDataSet().Tables[0];
                }
                if (chkChuaHoanTat.Checked)
                {
                    dt = BaocaoDSBNtheoTestType(dtpFromDate.Value,
                                                   dtpToDate.Value, "-1",2).
                                                   GetDataSet().Tables[0];
                    
                }
                if (chkChuaKham.Checked)
                {
                    dt = BaocaoDSBNtheoTestType(dtpFromDate.Value,
                                                   dtpToDate.Value, "-1", 3).
                                                   GetDataSet().Tables[0];

                }
                else if (cboTestType.SelectedValue.ToString() != "-1")
                {
                    chkChuaHoanTat.Checked = false;
                    chkTongBNHoanTatXN.Checked = false;
                    //if (cboTestType.SelectedValue.ToString() == "-1")
                    //{
                    //    //foreach (DataRow item in cboTestType.Items)
                    //    //{
                    //    //    testype_id +=","+ item.ToString();
                    //    //}
                    //    Utility.ShowMsg("Bạn phải chọn loại xét nghiệm để thực hiện");
                    //    cboTestType.Focus();
                    //    return;
                    //}
                    dt = BaocaoDSBNtheoTestType(dtpFromDate.Value,
                                                  dtpToDate.Value,
                                                 cboTestType.SelectedValue.ToString(),0).
                                                  GetDataSet().Tables[0];
                    if (dt.Rows.Count <= 0)
                    {
                        Utility.ShowMsg("Không tồn tại dữ liệu");
                        gridResult.DataSource = dt;
                        btnPrint.Enabled = false;
                        dt.AcceptChanges();
                        return;
                    }

                    var patientResult = new StringBuilder();
                    //dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                    //dtRawResult.Rows[0]["Patient_ID"] = dtRawResult.Rows[1]["Patient_ID"];
                    //dtRawResult.Rows.Add(dtRawResult.NewRow());
                    //for (int i = 1; i <= dtRawResult.Rows.Count - 1; i++)
                    //{
                    //    if (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                    //        Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]))
                    //    {
                    //        var newdr = dt.NewRow();
                    //        newdr["PID"] = dtRawResult.Rows[i - 1]["PID"];
                    //        newdr["CanLamSang_ID"] = dtRawResult.Rows[i - 1]["CanLamSang_ID"];
                    //        newdr["BarcodeXN"] = dtRawResult.Rows[i - 1]["BarcodeXN"];
                    //        newdr["Patient_ID"] = dtRawResult.Rows[i - 1]["Patient_ID"];
                    //        newdr["Patient_Name"] = dtRawResult.Rows[i - 1]["Patient_Name"];
                    //        newdr["AGE"] = dtRawResult.Rows[i - 1]["AGE"];
                    //        newdr["Sex"] = dtRawResult.Rows[i - 1]["Sex"];
                    //        newdr["Address"] = dtRawResult.Rows[i - 1]["Address"];
                    //        newdr["Insurance_Num"] = dtRawResult.Rows[i - 1]["Insurance_Num"];
                    //        newdr["Department"] = dtRawResult.Rows[i - 1]["Department"];
                    //        newdr["Diagnostic"] = dtRawResult.Rows[i - 1]["Diagnostic"];
                    //        //newdr["AllResult"] = patientResult.ToString();
                    //        dt.Rows.Add(newdr);
                    //        patientResult = new StringBuilder();
                    //    }
                    //    //string value;
                    //    //value = string.Format(
                    //    //       Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                    //    //           ? "{0} {1}; "
                    //    //           : "{0} ",
                    //    //       Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                    //    //       dtRawResult.Rows[i]["Test_result"]);
                    //    //patientResult.Append(value);
                    //}
                }
                if(dt.Rows.Count<=0)
                {
                    Utility.ShowMsg("Không có dữ liệu để báo cáo");
                    dt.AcceptChanges();
                    gridResult.DataSource = null;
                    gridResult.Refresh();
                }
                else
                    {
                        gridResult.DataSource = dt;
                        btnPrint.Enabled = true;
                        gridResult.AutoSizeColumns();
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
     }

     private void btnPrint_Click(object sender, EventArgs e)
     {
         try
         {
                  string s ="";
                if (dtpFromDate.Value.Date == dtpToDate.Value.Date)
                {
                    s = string.Format(" Ngày {0} tháng {1} năm {2}",dtCreatePrint.Value.Day,dtCreatePrint.Value.Month,dtCreatePrint.Value.Year);
                }
                else
                {
                    s = string.Format("{0}{1}", s,
                                      string.Format("Thời gian từ ngày {0} đến ngày {1}", dtpFromDate.Value.ToString("dd/MM/yyyy"),
                                                    dtpToDate.Value.ToString("dd/MM/yyyy")));
                }
                string tieude = "", reportname = "";
                string sTitleReport,testtypename="";
             var crpt = new ReportDocument();
             if (chkTongBNHoanTatXN.Checked)
             {
                 crpt = Utility.GetReport("crpt_BaoCaoSoLuongBN_TestType", ref tieude, ref reportname);
            
             }
             else
             {
                 crpt = Utility.GetReport("crpt_BaoCaoSoLuongBN_TestType", ref tieude, ref reportname);
              
             }
             var oForm = new frmPrintPreview("spBaoCao_DSBN_TestType", crpt, true, dt.Rows.Count <= 0 ? false : true);
             Utility.UpdateLogotoDatatable(ref dt);
             crpt.SetDataSource(dt);
             oForm.crptTrinhKyName = Path.GetFileName(reportname);
             crpt.SetParameterValue("TongBenhNhan", dt.Rows.Count);
             if (Utility.Int16Dbnull(cboTestType.SelectedValue)== -1)
             {
                 testtypename = "";
             }
             else
             {
                 testtypename = cboTestType.Text.ToUpper();

             }
             crpt.SetParameterValue("TestType_Name", testtypename);
             crpt.SetParameterValue("strFromDateToDate", s);
             crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
             crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
             crpt.SetParameterValue("sPhone", ManagementUnit.gv_sPhone);
             crpt.SetParameterValue("Address", ManagementUnit.gv_sAddress);
             crpt.SetParameterValue("sCurrentDate", dtCreatePrint.Value);
             oForm.crptViewer.ReportSource = crpt;
             oForm.ShowDialog();
             oForm.Dispose(); 
           
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
     }
      private void frm_DanhSachBenhNhan_TestType_KeyDown(object sender, KeyEventArgs e)
     {
         switch (e.KeyCode)
         {
             case Keys.F1:
                 cmdReport.PerformClick();
                 break;
             case Keys.F2:
                 btnPrint.PerformClick();
                 break;
             case Keys.Escape:
                 cmdCancel.PerformClick();
                 break;
         }
     }

      private void chkTongBNHoanTatXN_CheckedChanged(object sender, EventArgs e)
      {
          if (chkTongBNHoanTatXN.Checked)
          {
              chkChuaHoanTat.Checked = false;
              chkChuaKham.Checked = false;
          }
      }

      private void chkChuaHoanTat_CheckedChanged(object sender, EventArgs e)
      {
          if (chkChuaHoanTat.Checked)
          {
              chkTongBNHoanTatXN.Checked = false;
              chkChuaKham.Checked = false;
          }

      }

      private void btnExportExel_Click(object sender, EventArgs e)
      {
          Stream sw = null;
          try
          {
              var sd = new SaveFileDialog { Filter = "Excel File (*.xls)|*.xls" };
              if (sd.ShowDialog() == DialogResult.OK)
              {
                  sw = new FileStream(sd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                  GrdListExporter.Export(sw);
                  
                  MessageBox.Show("Xuất dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK);
              }

          }
          catch (Exception)
          {
              MessageBox.Show("Có lỗi trong quá trình xuất dữ liệu", "Thông Báo", MessageBoxButtons.OK);
          }
          finally
          {
              if (sw != null)
              {
                  sw.Flush();
                  sw.Close();
                  sw.Dispose();
              }
          }
      }

      private void chkChuaKham_CheckedChanged(object sender, EventArgs e)
      {
          if (chkChuaKham.Checked)
          {
              chkChuaHoanTat.Checked = false;
              chkTongBNHoanTatXN.Checked = false;
          }
      }
    }
}
