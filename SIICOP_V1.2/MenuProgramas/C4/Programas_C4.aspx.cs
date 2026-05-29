using SIICOP_V1._2.Captura.C4;
using SIICOP_V1._2.Datos;
using System;
using System.Web.Security;

namespace SIICOP_V1._2.MenuProgramas.C4
{
    public partial class Programas_C4 : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("c4"))
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



        protected void lnkbtnEscolar_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_promocion_difusion.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 16;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/C4/Ficha_promocion_difusion.aspx");
        }
        protected void lnkempre_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_promocion_difusion.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 17;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/C4/Ficha_promocion_difusion.aspx");
        }
        protected void lnkbtnIP_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_promocion_difusion.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 18;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/C4/Ficha_promocion_difusion.aspx");
        }
        protected void lnkbtnRedesV_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_promocion_difusion.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 19;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/C4/Ficha_promocion_difusion.aspx");
        }

        protected void lnkBtnEventos_Click(object sender, EventArgs e)
        {
            this.Session["AccionReporte"] = Ficha_promocion_difusion.AccionReporte.Creacion;
            this.Session["idPrograma_Accion"] = 20;
            this.Session["idReporte_Accion"] = 1;
            this.Response.Redirect("~/Captura/C4/Ficha_promocion_difusion.aspx");
        }
    }
}