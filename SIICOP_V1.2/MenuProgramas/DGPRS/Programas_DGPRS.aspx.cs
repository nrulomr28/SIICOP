using SIICOP_V1._2.Captura.DGPRS;
using SIICOP_V1._2.Datos;
using System;
using System.Web.Security;

namespace SIICOP_V1._2.MenuProgramas.DGPRS
{
    public partial class Programas_DGPRS : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("DGPRS"))
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

        protected void lnkbtnPrevenDeli_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Actividades_DGPRS.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 29;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/DGPRS/Actividades_DGPRS.aspx");
        }
        protected void lnkBtnMotivacionSociaL_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Actividades_DGPRS.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 30;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/DGPRS/Actividades_DGPRS.aspx");
        }
        protected void lnkBtnCampañaPreven_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Actividades_DGPRS.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 31;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/DGPRS/Actividades_DGPRS.aspx");
        }


    }
}