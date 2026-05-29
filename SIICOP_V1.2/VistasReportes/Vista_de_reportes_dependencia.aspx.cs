using SIICOP_V1._2.Captura;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.VistasReportes
{
    public partial class Vista_de_reportes_dependencia : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Dependencias"))
                {


                    string sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                    var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                    if (a != null)
                    {
                        Session["responsable"] = a.Personalid;
                        Session["Dependencia"] = a.Dependencia;

                    }
                    else
                    {
                        Session["responsable"] = -1;
                        Response.Redirect("TotalAccionesBeneficiados.aspx");
                    }
                    gvActividadesDepen.Visible = true;
                    gvActividadesDepen.DataBind();


                }
                else
                {
                    this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
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
        }

        #region ##COMPONENTES DEL GRID VIEW
        protected void gvActividadesDepen_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int valor;
                    valor = (int)DataBinder.Eval(e.Row.DataItem, "fotos");
                    Image img = (Image)e.Row.FindControl("imgpato");




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
        protected void gvActividadesDepen_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Editar")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Session["AccionExpediente"] = Captura_Dependencias.AccionExpediente.Edicion;
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;
                    Response.Redirect("~/Captura/Captura_Dependencias.aspx");
                }
            }
            if (e.CommandName == "VERFOTO")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;

                    ImagenEvidencia1.ImageUrl = "";
                    ImagenEvidencia2.ImageUrl = "";
                    ImagenEvidencia3.ImageUrl = "";
                    ImagenEvidencia4.ImageUrl = "";
                    List<tb_fotografia> foto = ctx.tb_fotografia.Where(x => x.idResumenDiario == idExped).ToList();

                    foreach (var fotografia in foto)
                    {

                        Byte[] bytes = fotografia.image;

                        if (ImagenEvidencia1.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia1.ImageUrl = "data:image/png;base64," + base64String;

                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);
                            }
                            foto1.Visible = true;
                            foto11.Visible = true;
                        }
                        else
                            if (ImagenEvidencia2.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia2.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);

                            }

                            //ImagenEvidencia2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                            foto2.Visible = true;
                            foto22.Visible = true;

                        }
                        else
                            if (ImagenEvidencia3.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia3.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia3.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);

                            }

                            foto3.Visible = true;
                            foto33.Visible = true;

                        }
                        else
                        {
                            if (ImagenEvidencia4.ImageUrl == "")
                            {
                                if (bytes == null)
                                {
                                    string base64String = fotografia.ImgBase64;
                                    ImagenEvidencia4.ImageUrl = "data:image/png;base64," + base64String;
                                }
                                else
                                {
                                    Byte[] fotoVer = fotografia.image;
                                    ImagenEvidencia4.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);
                                }
                                foto34.Visible = true;
                            }
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalFotos", "AbrirModalFotos();", true);
                    }



                }
            }
        }
        #endregion


    }
}