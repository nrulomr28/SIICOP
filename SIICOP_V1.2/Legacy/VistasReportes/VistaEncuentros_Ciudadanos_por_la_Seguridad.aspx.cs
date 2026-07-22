using SIICOP_V1._2.Datos;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.VistasReportes
{
    public partial class VistaForosFerias : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        private int iduser;
        private static DataTable dtPrincipal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Cap_FF"))
                {

                    if (this.User.IsInRole("SYSADMIN") || this.User.IsInRole("Admin_Empresarial"))
                    {

                        this.GvForosFerias.Visible = false;
                        this.GvForosFeriasadmin.Visible = true;
                        this.bottonExcel.Visible = true;
                    }
                    else
                    {
                        string sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                        var i = ctx.PersonalUsuario.Where(x => x.Login == sUsuarioActual).FirstOrDefault();
                        var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                        if (i != null)
                        {
                            Session["responsable"] = a.Personalid;
                        }
                        else
                        {
                            Session["responsable"] = -1;
                            Response.Redirect("TotalAccionesBeneficiados.aspx");
                        }
                        GvForosFerias.Visible = true;
                        lkbtnexcel.Visible = false;
                        GvForosFeriasadmin.Visible = false;
                        GvForosFerias.DataBind();

                    }
                    this.conteoactividadesAdmin();
                }
                else
                {
                    this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
                }
            }
        }
        protected void conteoactividadesAdmin()
        {
            if (this.Session["responsable"] != null)
            {
                this.iduser = int.Parse(this.Session["responsable"].ToString());
            }

            if (this.txtFInicialC.Text == string.Empty)
            {
                if (this.iduser != 0)
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.programasID == 11 && x.Personalid == this.iduser).Count();

                }
                else
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.programasID == 11).Count();

                }


            }
            else
            {
                DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
                DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
                if (this.iduser != 0)
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.programasID == 11 && x.Personalid == this.iduser).Count();

                }
                else
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.programasID == 11).Count();

                }
            }

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime result = new DateTime();
            if (DateTime.TryParse(this.txtFInicialC.Text, out result))
            {
                this.Session["fInicialC"] = (object)result.ToShortDateString();
            }
            else
                this.Session["fInicialC"] = (object)null;
            if (DateTime.TryParse(this.txtfechafin.Text, out result))
                this.Session["fFinalC"] = (object)result.ToShortDateString();
            else
                this.Session["fFinalC"] = (object)null;
            this.conteoactividadesAdmin();
        }

        protected void lkbtnexcel_Click(object sender, EventArgs e)
        {

        }

        protected void GvForosFerias_DataBound(object sender, EventArgs e)
        {

        }

        protected void GvForosFerias_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvForosFeriasadmin_DataBound(object sender, EventArgs e)
        {

        }

        protected void GvForosFeriasadmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void PageDropDownListAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GvForosFerias_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int valor;
                    valor = (int)DataBinder.Eval(e.Row.DataItem, "fotos");
                    Image img = (Image)e.Row.FindControl("imgCap");




                    if (valor == 1)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/check.png";
                    }
                    if (valor == 0)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/cross.png";
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GvForosFeriasadmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int valor;
                    valor = (int)DataBinder.Eval(e.Row.DataItem, "fotos");
                    Image img = (Image)e.Row.FindControl("imgAdmin");




                    if (valor == 1)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/check.png";
                    }
                    if (valor == 0)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/cross.png";
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}