using Microsoft.Reporting.WebForms;
using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Graficas
{
    public partial class Monitoreo_de_acciones : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        bool valido = true;
        string textoValidacion = "<ul>";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Visualizador") || User.IsInRole("Operador"))
                {

                }
                else
                {
                    RedirectHelper.Redirect(this.Response,"~/TotalAccionesBeneficiados.aspx");
                }
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFechaini.Text) || string.IsNullOrEmpty(this.txtDateFin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder generar el reporte. </ li>";
                valido = false;

                this.Resultados.Visible = false;

            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }
            else
            {


                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                this.ReportViewer1.ServerReport.ReportPath = "/SIICOP/Monitoreo_de_acciones";
                this.ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.8.3.199/reportserver");
                ReportParameter[] parametros = new ReportParameter[2];
                parametros[0] = new ReportParameter("fecha1", txtFechaini.Text);
                parametros[1] = new ReportParameter("fecha2", txtDateFin.Text);
                ReportViewer1.ServerReport.SetParameters(parametros);
                ReportViewer1.ServerReport.Refresh();
                this.Resultados.Visible = true;
            }
        }
    }
}