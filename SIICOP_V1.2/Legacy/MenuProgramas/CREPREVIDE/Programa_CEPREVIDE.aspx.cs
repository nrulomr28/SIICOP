using SIICOP_V1._2.Captura.CEPREVIDE;
using SIICOP_V1._2.Datos;
using System;
using System.Web.Security;

namespace SIICOP_V1._2.MenuProgramas.CREPREVIDE
{
    public partial class Programa_CEPREVIDE : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("CEPREVIDE"))
                {


                }
                else
                {
                    MembershipUser user = Membership.GetUser(false);
                    Membership.UpdateUser(user);
                    ctx.SaveChanges();
                    Session.Clear();
                    Session.Abandon();
                    FormsAuthentication.RedirectToLoginPage();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Inicio/Inicio.aspx");
                }
            }
        }

        protected void lnkbtnPartiCiuda_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Reporte_CEPREVIDE.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 22;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/CEPREVIDE/Reporte_CEPREVIDE.aspx");
        }

        protected void lnkbtnEscolar_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Reporte_CEPREVIDE.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 23;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/CEPREVIDE/Reporte_CEPREVIDE.aspx");
        }

        protected void lnkbtnGrupoV_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Reporte_CEPREVIDE.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 24;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/CEPREVIDE/Reporte_CEPREVIDE.aspx");
        }

        protected void lnkbtnCulturaLd_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Reporte_CEPREVIDE.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 25;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/CEPREVIDE/Reporte_CEPREVIDE.aspx");
        }

        protected void lnkBtnREspaciosP_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Reporte_CEPREVIDE.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 26;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/CEPREVIDE/Reporte_CEPREVIDE.aspx");
        }
    }
}