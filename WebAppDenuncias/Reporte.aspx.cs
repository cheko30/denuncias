using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace WebAppDenuncias
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                reporte1();
            }
        }

        private void reporte1()
        {
            DataTable dataTable = new DataTable();

            Reportes.DataSet1TableAdapters.spReporteTipoDelitoTableAdapter datos = new Reportes.DataSet1TableAdapters.spReporteTipoDelitoTableAdapter();
            dataTable = datos.GetData();

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.LocalReport.ReportPath = "Reportes/Report1.rdlc";
            ReportViewer1.LocalReport.Refresh();
         }
    }
}