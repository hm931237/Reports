using Microsoft.Reporting.WebForms;
using Reports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Configuration;
namespace Reports.Controllers
{
    public class HomeController : Controller
    {
        Context Db = new Context();
        public ActionResult UsersList()
        {
            FundBalance();
            //var Funds = SqlHelper.ExecuteDataset(Context, CommandType.Text, "select * from Funds");
            return View(Db.AspNetUsers.ToList());
        }

        public ActionResult Reports(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/UsersReport.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = Db.AspNetUsers.ToList();
            localReport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtintion;
            if (reportType == "Excel")
            {
                fileNameExtintion = "xlsx";
            }
            if (reportType == "Word")
            {
                fileNameExtintion = "docx";
            }
            if (reportType == "PDF")
            {
                fileNameExtintion = "pdf";
            }
            if (reportType == "Image")
            {
                fileNameExtintion = "jpg";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtintion, out streams, out warnings);
            Response.AddHeader("content-disposition", "inline; filename= Employee_Report."+ fileNameExtintion);
            if (reportType == "PDF")
                return File(renderedByte, "application/pdf");
            else
                return File(renderedByte, fileNameExtintion);

            //return View();
        }

        public ActionResult UsersBranchesReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = (from a in Db.AspNetUsers
                                      join b in Db.Branches on a.BranchId equals b.BranchID
                                      join t in Db.UserGroups on a.GroupId equals t.GroupID
                                      select new
                                      {
                                          UserName = a.FullName,
                                          BranchName = b.Name,
                                          GroupName=t.Name
                                      }).ToList();
            localReport.DataSources.Add(reportDataSource);
            //ReportParameter[] rptParameters = new ReportParameter[0];
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("Name", "Hesham"));
            localReport.SetParameters(parameters);
            //rptParameters=ReportParameter
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtintion;
            if (reportType == "Excel")
            {
                fileNameExtintion = "xlsx";
            }
            if (reportType == "Word")
            {
                fileNameExtintion = "docx";
            }
            if (reportType == "PDF")
            {
                fileNameExtintion = "pdf";
            }
            if (reportType == "Image")
            {
                fileNameExtintion = "jpg";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtintion, out streams, out warnings);
            Response.AddHeader("content-disposition", "inline; filename= Employee_Report." + fileNameExtintion);
            if (reportType == "PDF")
                return File(renderedByte, "application/pdf");
            else
                return File(renderedByte, fileNameExtintion);
        }

        private void FundBalance()
        {
            string totalPos;
            string navDate;
            string fund_id;
            string units;
            string fname;
            var cond = "";
            var Flag = 0;
            var fund_type = "";
            var Fund_Name="";
            Session["userno"] = 22;//Loged In User
            Session["balancefdate"] = "FDate";
            var balancefdate= "FDate";
            Session["balancetdate"] = "TDate";
            var balancetdate= "TDate";
            var druser = SqlHelper.ExecuteDataset("data source=SERVER2;initial catalog=ICP_ABC_DB_Test;persist security info=True;user id=ICpro;password=ICpro!09;MultipleActiveResultSets=True;App=EntityFramework", CommandType.Text, "select BranchId,BranchRight from AspNetUsers where code='" + Session["userno"] + "'");
            var branch_id = druser.Tables[0].Rows[0].ItemArray[0];
            var branch_right = druser.Tables[0].Rows[0].ItemArray[1];
            if(Convert.ToBoolean(branch_right) == true)
            {
                Session["branchno"] = 0;
                Flag = 2;
            }
            else
            {
                Session["branchno"] =Convert.ToInt32(branch_id);
                Flag = 3;
            }
            if(fund_type== "ALL")
            {
                Session["balancefundtype"] = 0;
            }
            else
            {
                Session["balancefundtype"] = fund_type;
            }
            int fundid;
            try
            {
                if (Fund_Name == "" || Fund_Name == "All funds")
                {
                    fundid = 0;
                }
                else
                {
                    fundid = Convert.ToInt32(Fund_Name);
                }
            }
            catch (Exception)
            {

                fundid = 0;
            }
            Session["balancefund"] = fundid;
            if(Convert.ToInt32(Session["balancefund"]) == 0)
            {
                if (Convert.ToInt32(Session["balancefundtype"]) == 0)
                {
                    if (Flag == 1)
                        cond = " and value_date >= '" + Session["balancefdate"] + "' and value_date <= '" + Session["balancetdate"] + "'   ";
                    else if (Flag == 2)
                        cond = " and value_date >= '" + Session["balancefdate"] + "' and value_date <= '" + Session["balancetdate"] + "'  ";
                    else if (Flag == 3)
                        cond = " and value_date >= '" + Session["balancefdate"] + "' and value_date <= '" + Session["balancetdate"] + "' " + " and branch_id=" + Session["branchno"];
                }
                else
                {
                    if (Flag == 1)
                        cond = " and value_date >= '" + Session["balancefdate"] + "' and value_date <= '" + Session["balancetdate"] + "' and cbo_type=" + Session["balancefundtype"] + "   ";
                    else if (Flag == 2)
                        cond = " and value_date >= '" + Session["balancefdate"] + "' and value_date <= '" + Session["balancetdate"] + "' " + " and cbo_type=" + Session["balancefundtype"];
                    else if (Flag == 3)
                        cond = " and value_date >= '" + Session["balancefdate"] + "' and value_date <= '" + Session["balancetdate"] + "' " + " and branch_id=" + Session["branchno"] + " and cbo_type=" + Session["balancefundtype"];
                }
            }
            else
            {
                if (Convert.ToInt32(Session["balancefundtype"]) == 0)
                {
                    if (Flag == 1)
                        cond = " and ReportView.value_date >= '" + Session["balancefdate"] + "' and ReportView.value_date <= '" + Session["balancetdate"] + "' and ReportView.fund_id=" + Session["balancefund"] + "  ";
                    else if (Flag == 2)
                        cond = " and ReportView.value_date >= '" + Session["balancefdate"] + "' and ReportView.value_date <= '" + Session["balancetdate"] + "' " + " and ReportView.fund_id=" + Session["balancefund"];
                    else if (Flag == 3)
                        cond = " and ReportView.value_date >= '" + Session["balancefdate"] + "' and ReportView.value_date <= '" + Session["balancetdate"] + "' " + " and ReportView.branch_id=" + Session["branchno"] + " and ReportView.fund_id=" + Session["balancefund"];
                }
                else
                {
                    if (Flag == 1)
                        cond = " and ReportView.value_date >= '" + Session["balancefdate"] + "' and ReportView.value_date <= '" + Session["balancetdate"] + "' and ReportView.fund_id=" + Session["balancefund"] + " and ReportView.cbo_type=" + Session["balancefundtype"] + "  ";
                    else if (Flag == 2)
                        cond = " and ReportView.value_date >= '" + Session["balancefdate"] + "' and ReportView.value_date <= '" + Session["balancetdate"] + "' " + " and ReportView.fund_id=" + Session["balancefund"] + " and ReportView.cbo_type=" + Session["balancefundtype"];
                    else if (Flag == 3)
                        cond = " and ReportView.value_date >= '" + Session["balancefdate"] + "' and ReportView.value_date <= '" + Session["balancetdate"] + "' " + " and ReportView.branch_id=" + Session["branchno"] + " and ReportView.fund_id=" + Session["balancefund"] + " and ReportView.cbo_type=" + Session["balancefundtype"];
                }

            }
            Flag = 0;
            Session["userid5"] = cond;
            var cond1 = "";
            var FundRight= SqlHelper.ExecuteDataset("data source=SERVER2;initial catalog=ICP_ABC_DB_Test;persist security info=True;user id=ICpro;password=ICpro!09;MultipleActiveResultSets=True;App=EntityFramework", CommandType.Text, "select * from FundRights where GroupID=" + Session["groupid"] + " and Auth=1");
            for (int i = 0; i <= FundRight.Tables[0].Rows.Count - 1; i++)
            {
                cond1 = "  ReportView.fund_id=" + FundRight.Tables[0].Rows[i].ItemArray[3] + " or " + cond1;
            }
            int xx;
            xx = cond1.Length;
            cond1 = Microsoft.VisualBasic.Strings.Left(cond1, xx - 3);
            cond1 = " and (" + cond1 + ")";
            Session["CondFund2"] = cond1;
            var repDS = SqlHelper.ExecuteDataset("data source=SERVER2;initial catalog=ICP_ABC_DB_Test;persist security info=True;user id=ICpro;password=ICpro!09;MultipleActiveResultSets=True;App=EntityFramework", CommandType.Text, "select Sum (total_sub) - Sum (total_red) as units,a.fund_id from (select sum(quantity) as total_sub,fund_id from reportview where pur_sal=0 and auth=1 " + Session["userid5"] + Session["CondFund2"] + " group by fund_id) a full outer join (select sum(quantity) as total_red ,fund_id from reportview where pur_sal=1 and auth=1 " + Session["userid5"] + Session["CondFund2"] + " group by fund_id)b on a.fund_id=b.fund_id group by a.fund_id");
            for (int i = 0; i < repDS.Tables[0].Rows.Count - 1; i++)
            {
                if (repDS.Tables[0].Rows[i].ItemArray[0] != null)
                {
                    units = repDS.Tables[0].Rows[i].ItemArray[0].ToString();
                    fund_id = repDS.Tables[0].Rows[i].ItemArray[1].ToString();
                }
                else
                {
                   var subDS= SqlHelper.ExecuteDataset("data source=SERVER2;initial catalog=ICP_ABC_DB_Test;persist security info=True;user id=ICpro;password=ICpro!09;MultipleActiveResultSets=True;App=EntityFramework", CommandType.Text, "select sum(quantity) as units,fund_id from reportview where pur_sal=0 and auth=1 " + Session["userid5"] + " and fund_id=" + repDS.Tables[0].Rows[i].ItemArray[1] + " group by fund_id");
                    if (subDS.Tables[0].Rows.Count != 0)
                    {
                        units = subDS.Tables[0].Rows[i].ItemArray[0].ToString();
                        fund_id = subDS.Tables[0].Rows[i].ItemArray[1].ToString();
                    }
                    else
                    {
                        fund_id = "0";
                        units = "0";
                    }
                }

                if (fund_id != "0")
                {
                    var fDS= SqlHelper.ExecuteDataset("data source=SERVER2;initial catalog=ICP_ABC_DB_Test;persist security info=True;user id=ICpro;password=ICpro!09;MultipleActiveResultSets=True;App=EntityFramework", CommandType.Text, "select Name from Funds where code=" + repDS.Tables[0].Rows[i].ItemArray[1]);
                    fname = fDS.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    fname = "";
                }

                var pDS= SqlHelper.ExecuteDataset("data source=SERVER2;initial catalog=ICP_ABC_DB_Test;persist security info=True;user id=ICpro;password=ICpro!09;MultipleActiveResultSets=True;App=EntityFramework", CommandType.Text, " select  Price from ICPrices where ICPrices.Date=(select max(Date) from ICPrices where FundId=" + fund_id + ") and FundId=" + fund_id);
                try
                {
                    navDate = pDS.Tables[0].Rows[0].ItemArray[0].ToString();
                }
                catch (Exception)
                {

                    navDate = "0";
                }
                totalPos =( Convert.ToDouble(units) * Convert.ToDouble(navDate)).ToString();
                units = (Convert.ToDouble(units)).ToString();
                //Response.Write("<table border=" + s + "1" + s + " cellpadding=" + s + "0" + s + " cellspacing=" + s + "0" + s + "width=" + s + "1000" + s + " bordercolor=" + s + "black" + s + " style=" + s + "font-weight: bold; font-size: 10pt" + s + "> <tr> <td align=" + s + "center" + s + "style=" + s + "width: 200px; height: 18px;" + s + " rowspan=" + s + "1" + s + ">" + fund_id + "</td> <td align=" + s + "center" + s + "style=" + s + "width: 200px; height: 18px;" + s + " rowspan=" + s + "1" + s + ">" + fname + "</td> <td align=" + s + "center" + s + "style=" + s + "width: 200px; height: 18px;" + s + ">" + units + "</td> <td align=" + s + "center" + s + "style=" + s + "width: 200px; height: 18px;" + s + ">" + navDate + "</td> <td align=" + s + "center" + s + "style=" + s + "width: 200px; height: 18px;" + s + "> " + totalPos + "</td></tr> </table>")

            }
        }
    }
}
//Session["groupid"] User Group
//ReportView Table

//fund_id-fname-units-navDate-totalPos

    //FundName =>Funds
    //Fund Type=>Static