using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

using BLL;
namespace CustomReports
{
    public partial class Report22 : System.Web.UI.Page
    {
        private ReportManager objReportManager = new ReportManager();
        private static int MyReportID = 122;
        protected string selProjectOptions22 = "";
        public string htmlGlobalReportTable22;
        protected void Page_Load(object sender, EventArgs e)
        {
            selProjectOptions22 = objReportManager.BindChoicesProjectSpaces();
            htmlGlobalReportTable22 = "";
        }

        [WebMethod]
        public static string RefreshGlobalReport22(string selectedProjectsStr)
        {
            ReportManager.DeleteTmpData();
            ReportManager.insertTmpData(selectedProjectsStr);
            return ReportManager.GetReport22_HTML();
        }

        // 导出报表使用
        public void exportReportToExcel(Object sender, EventArgs e)
        {

        }

    }
}