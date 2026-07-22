using SIICOP_V1._2.Captura;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.VistasReportes
{
    public partial class Vista_Datos_Foraneo : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        private int iduser;
        private int Zona;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Foráneo"))
                {


                    string sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                    var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                    if (a != null)
                    {
                        Session["responsable"] = a.Personalid;
                        HDFUSERID.Value = Convert.ToInt32(a.Personalid).ToString();

                        Zona = Convert.ToInt32(a.RegionId);
                        HDFRegion.Value = Convert.ToInt32(Zona).ToString();
                    }
                    else
                    {
                        Session["responsable"] = -1;
                        Response.Redirect("TotalAccionesBeneficiados.aspx");
                    }
                    GvInformeResultados.Visible = true;
                    GvInformeResultados.DataBind();


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
                this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.Personalid == this.iduser).Count();
            }
            else
            {
                DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
                DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
                this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.Personalid == this.iduser).Count();

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

        protected void GvInformeResultados_DataBound(object sender, EventArgs e)
        {

            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = GvInformeResultados.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabel");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvInformeResultados.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvInformeResultados.PageIndex)
                        {
                            item.Selected = true;
                        }
                        // Se añade el ListItem a la colección de Items del DropDownList...
                        pageList.Items.Add(item);
                    }
                }
                if ((pageLabel != null))
                {
                    // Calcula el nº de �gina actual...
                    int currentPage = GvInformeResultados.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvInformeResultados.PageCount.ToString();

                }


            }
            catch
            {
            }
        }

        protected void GvInformeResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int empresarialv = 1;
            int PART_CIUDAv = 2;
            int ESCUELAv = 3;
            int VCMv = 4;
            int FFv = 5;
            int ic = 6;

            int inclusionpersonas = 7;
            int Redesvecinales = 8;
            int ESCUELA = 9;
            int VCM = 10;
            int encuentrociudadano = 11;
            int fomentodeporte = 12;
            int empresarial = 13;
            int resdesXpaz = 14;

            if (e.CommandName == "Editar")
            {
                Guid idExped = Guid.Parse(e.CommandArgument.ToString());

                tb_Reporte_Diario Reporte = ctx.tb_Reporte_Diario.Where(t => t.idResumenDiario == idExped).FirstOrDefault();
                int Progrmaid = Convert.ToInt32(Reporte.programasID);

                if (inclusionpersonas == Progrmaid)
                {
                    this.Session["AccionExpediente"] = SectorEmpresarial.AccionExpediente.Edicion;
                    this.Session["idExpediente_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/Construccion_Cultura_Incluyente.aspx");
                }

                if (empresarial == Progrmaid)
                {
                    this.Session["AccionExpediente"] = SectorEmpresarial.AccionExpediente.Edicion;
                    this.Session["idExpediente_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/Enlace_con_el_Sector_Empresarial.aspx");
                }
                if (Redesvecinales == Progrmaid)
                {
                    this.Session["AccionExpediente"] = PrevencionVecinal.AccionExpediente.Edicion;
                    this.Session["idExpediente_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/Redes_vecinales.aspx");
                }
                if (ESCUELA == Progrmaid)
                {
                    this.Session["AccionExpediente"] = EscuelaSegura.AccionExpediente.Edicion;
                    this.Session["idExpediente_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/Seguridad_social_paz_social_entorno_educativo.aspx");
                }
                if (VCM == Progrmaid)
                {
                    this.Session["AccionExpediente"] = PrevenciondelaVM.AccionExpediente.Edicion;
                    this.Session["idExpediente_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/Prevención_de_la_Violencia_por_Razones_de_Género.aspx");
                }
                if (encuentrociudadano == Progrmaid)
                {
                    this.Session["AccionExpediente"] = ForosFerias.AccionExpediente.Edicion;
                    this.Session["idExpediente_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/Encuentros_Ciudadanos_por_la_Seguridad.aspx");
                }
                if (fomentodeporte == Progrmaid)
                {
                    this.Session["AccionExpediente"] = Prevencion_traves_Deporte_Cultura.AccionExpediente.Edicion;
                    this.Session["idExpediente_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/Fomento_a_la_Prevyencion_a_traves_del_Deporte_Cultura.aspx");
                }

                if (empresarialv == Progrmaid || PART_CIUDAv == Progrmaid || ESCUELAv == Progrmaid || VCMv == Progrmaid || FFv == Progrmaid || ic == Progrmaid)
                {
                    ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('No se puede mostrar la información por el cambio de programas.');", true);

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


        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                GridViewRow pagerRow = GvInformeResultados.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                GvInformeResultados.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...
                //lblInfo.Text = "";
            }
        }

        protected void lkmapa_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('Favor de ingresar los campos de fecha para poder puntear el mapa.');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModal", "openModal();", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "initMap", "initMap();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarPlanteles", "MostrarPlanteles();", true);
            }
        }

        protected void lkGraficas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('Favor de ingresar los campos de fecha para poder mostrar las graficas.');", true);
            }
            else
            {

                int Xzona = Convert.ToInt32(HDFRegion.Value);

                if (Xzona == 1)
                {

                    zoonaNorte.Visible = true;
                    zoonaCentro.Visible = false;
                    zoonaSur.Visible = false;
                    ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaHombresXacciones", "ConsultaHombresXacciones();", true);
                    ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMuniNorte", "ConsultaMuniNorte();", true);
                }
                else
                {
                    if (Xzona == 2)
                    {
                        zoonaNorte.Visible = false;
                        zoonaCentro.Visible = true;
                        zoonaSur.Visible = false;
                        ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionescentroTtotal", "AccionescentroTtotal();", true);
                        ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunicentro", "ConsultaMunicentro();", true);
                    }
                    else
                    {
                        zoonaNorte.Visible = false;
                        zoonaCentro.Visible = false;
                        zoonaSur.Visible = true;

                        ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionTotalSur", "AccionTotalSur();", true);
                        ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunisur", "ConsultaMunisur();", true);
                    }
                }
                this.totalAtendidos();
                this.totalAcciones();
                this.totalporZonas();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModalGrafi", "openModalGrafi();", true);
            }
        }

        public void totalporZonas()
        {
            this.iduser = int.Parse(this.Session["responsable"].ToString());

            int Xzona = Convert.ToInt32(HDFRegion.Value);
            //Municipios atendidos por zonas y general 
            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);




            if (Xzona == 1)
            {
                this.ZonaNorte.InnerText = (from s in ctx.tb_Reporte_Diario
                                            join std in ctx.tb_DireccionReporte
                                            on s.idResumenDiario equals std.idResumenDiario
                                            where s.fecha >= fechainicial && s.fecha <= fechaFinal && std.RegionID == Xzona && s.Personalid == iduser
                                            select std.MunicipioID).Distinct().Count().ToString();
            }
            else
            {
                if (Xzona == 2)
                {
                    this.ZonaCentro.InnerText = (from a in ctx.tb_Reporte_Diario
                                                 join b in ctx.tb_DireccionReporte
                                                 on a.idResumenDiario equals b.idResumenDiario
                                                 where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == Xzona && a.Personalid == iduser
                                                 select b.MunicipioID).Distinct().Count().ToString();
                }
                else
                {
                    this.ZonaSurRR.InnerText = (from c in ctx.tb_Reporte_Diario
                                                join d in ctx.tb_DireccionReporte
                                                on c.idResumenDiario equals d.idResumenDiario
                                                where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == Xzona && c.Personalid == iduser
                                                select d.MunicipioID).Distinct().Count().ToString();
                }
            }


        }



        public void totalAtendidos()
        {
            this.iduser = int.Parse(this.Session["responsable"].ToString());
            int Xzona = Convert.ToInt32(HDFRegion.Value);

            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);



            //Beneficiados
            this.H2MombresBeneficiados.InnerText = (from c in ctx.tb_Reporte_Diario
                                                    join d in ctx.tb_DireccionReporte
                                                    on c.idResumenDiario equals d.idResumenDiario
                                                    where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.Personalid == iduser
                                                    select c.TotalHombresAtendidos).Sum().ToString();

            this.H2MujeresBeneficiadas.InnerText = (from c in ctx.tb_Reporte_Diario
                                                    join d in ctx.tb_DireccionReporte
                                                    on c.idResumenDiario equals d.idResumenDiario
                                                    where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.Personalid == iduser
                                                    select c.TotalMujeresAtendidas).Sum().ToString();

            //termino de beneficiados





            if (Xzona == 1)
            {
                this.PersonasZonaNorte.InnerText = (from c in ctx.tb_Reporte_Diario
                                                    join d in ctx.tb_DireccionReporte
                                                    on c.idResumenDiario equals d.idResumenDiario
                                                    where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == 1 && c.Personalid == iduser
                                                    select c.total_atendidos).Sum().ToString();
            }
            else
            {
                if (Xzona == 2)
                {
                    this.PersonasAtendidasZonaCentro.InnerText = (from m in ctx.tb_Reporte_Diario
                                                                  join n in ctx.tb_DireccionReporte
                                                                  on m.idResumenDiario equals n.idResumenDiario
                                                                  where m.fecha >= fechainicial && m.fecha <= fechaFinal && n.RegionID == 2 && m.Personalid == iduser
                                                                  select m.total_atendidos).Sum().ToString();
                }
                else
                {
                    this.personasAtendidasZonaSur.InnerText = (from ma in ctx.tb_Reporte_Diario
                                                               join nr in ctx.tb_DireccionReporte
                                                               on ma.idResumenDiario equals nr.idResumenDiario
                                                               where ma.fecha >= fechainicial && ma.fecha <= fechaFinal && nr.RegionID == 3 && ma.Personalid == iduser
                                                               select ma.total_atendidos).Sum().ToString();
                }
            }


        }
        public void totalAcciones()
        {
            this.iduser = int.Parse(this.Session["responsable"].ToString());
            int Xzona = Convert.ToInt32(HDFRegion.Value);


            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);

            if (Xzona == 1)
            {
                this.AccionesZonaNorte.InnerText = (from a in ctx.tb_Reporte_Diario
                                                    join b in ctx.tb_DireccionReporte
                                                    on a.idResumenDiario equals b.idResumenDiario
                                                    where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == 1 && a.Personalid == iduser
                                                    select a.AccionesID).Count().ToString();
            }
            else
            {
                if (Xzona == 2)
                {
                    this.accionesRealizadasZonaCentro.InnerText = (from k in ctx.tb_Reporte_Diario
                                                                   join l in ctx.tb_DireccionReporte
                                                                   on k.idResumenDiario equals l.idResumenDiario
                                                                   where k.fecha >= fechainicial && k.fecha <= fechaFinal && l.RegionID == 2 && k.Personalid == iduser
                                                                   select k.AccionesID).Count().ToString();
                }
                else
                {
                    this.AccionesRealizadasSur.InnerText = (from w in ctx.tb_Reporte_Diario
                                                            join x in ctx.tb_DireccionReporte
                                                            on w.idResumenDiario equals x.idResumenDiario
                                                            where w.fecha >= fechainicial && w.fecha <= fechaFinal && x.RegionID == 3 && w.Personalid == iduser
                                                            select w.AccionesID).Count().ToString();
                }
            }

        }

        #region Norte *********************************
        public class datoGraficaPasteNorte
        {
            public int Cantidad { get; set; }
            public string etiquetaR { get; set; }
            public datoGraficaPasteNorte() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPasteNorte> ChartDataNorteAccionesta(string x, string fechaInicial, string fechafinal, int iduser)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPasteNorte> listaDatos = new List<datoGraficaPasteNorte>();

                datoGraficaPasteNorte nuevoDG = new datoGraficaPasteNorte();


                var resultado = (from ar in ctx.tb_Reporte_Diario
                                 join bz in ctx.Cat_Acciones on ar.AccionesID equals bz.AccionesID
                                 join xr in ctx.tb_DireccionReporte on ar.idResumenDiario equals xr.idResumenDiario
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && ar.Personalid == iduser
                                 group bz by bz.AccionesNombre into g
                                 select new
                                 {
                                     AccionesNombre = g.Key,
                                     AccionesID = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficaPasteNorte();

                    nuevoDG.Cantidad = data.AccionesID;
                    nuevoDG.etiquetaR = data.AccionesNombre;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public class datoGraficabarteNorte
        {
            public int CantidadMuni { get; set; }
            public string Municipios { get; set; }
            public datoGraficabarteNorte() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficabarteNorte> datoGraficabarteNorteMuni(string x, string fechaInicial, string fechafinal, int iduser)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabarteNorte> listaDatos = new List<datoGraficabarteNorte>();

                datoGraficabarteNorte nuevoDG = new datoGraficabarteNorte();


                var resultado = (from ar in ctx.tb_Reporte_Diario
                                 join xr in ctx.tb_DireccionReporte on ar.idResumenDiario equals xr.idResumenDiario
                                 join bz in ctx.Municipios on xr.MunicipioID equals bz.MunicipioID
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && ar.Personalid == iduser
                                 group bz by bz.MUNICIPIO into g
                                 select new
                                 {
                                     Municipios = g.Key,
                                     municipiosid = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficabarteNorte();

                    nuevoDG.CantidadMuni = data.municipiosid;
                    nuevoDG.Municipios = data.Municipios;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ************************************



        #region centro ***********************************
        public class datoGraficaPastecentro
        {
            public int Cantidadcentro { get; set; }
            public string etiquetaRcentro { get; set; }
            public datoGraficaPastecentro() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPastecentro> ChartDataCentroAccionesta(string x, string fechaInicial, string fechafinal, string IdUser)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            int personalid = Convert.ToInt32(IdUser);

            try
            {
                List<datoGraficaPastecentro> listaDatos = new List<datoGraficaPastecentro>();

                datoGraficaPastecentro nuevoDG = new datoGraficaPastecentro();


                var resultado = (from bc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bc.idResumenDiario equals nb.idResumenDiario
                                 where bc.fecha >= fechainicial && bc.fecha <= fechaFinal && nb.RegionID == 2 && bc.Personalid == personalid
                                 group bc by rt.AccionesNombre into g
                                 select new
                                 {
                                     AccionesNombre = g.Key,
                                     AccionesID = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficaPastecentro();

                    nuevoDG.Cantidadcentro = data.AccionesID;
                    nuevoDG.etiquetaRcentro = data.AccionesNombre;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public class datoGraficabartecentro
        {
            public int CantidadMunicentro { get; set; }
            public string Municipioscentro { get; set; }
            public datoGraficabartecentro() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficabartecentro> datoGraficabarteCentroMuni(string x, string fechaInicial, string fechafinal, string IdUser)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            int personalid = Convert.ToInt32(IdUser);

            try
            {
                List<datoGraficabartecentro> listaDatos = new List<datoGraficabartecentro>();

                datoGraficabartecentro nuevoDG = new datoGraficabartecentro();


                var resultado = (from arx in ctx.tb_Reporte_Diario
                                 join xry in ctx.tb_DireccionReporte on arx.idResumenDiario equals xry.idResumenDiario
                                 join bzt in ctx.Municipios on xry.MunicipioID equals bzt.MunicipioID
                                 where arx.fecha >= fechainicial && arx.fecha <= fechaFinal && xry.RegionID == 2 && arx.Personalid == personalid
                                 group bzt by bzt.MUNICIPIO into g
                                 select new
                                 {
                                     Municipios = g.Key,
                                     municipiosid = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficabartecentro();

                    nuevoDG.CantidadMunicentro = data.municipiosid;
                    nuevoDG.Municipioscentro = data.Municipios;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion****************************************


        #region ZONA SUR ******************************

        public class datoGraficaPasteSur
        {
            public int CantidadSur { get; set; }
            public string etiquetaRSur { get; set; }
            public datoGraficaPasteSur() { }

        }
        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPasteSur> DtAccionesSUR(string x, string fechaInicial, string fechafinal, string IdUser)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            int personalid = Convert.ToInt32(IdUser);

            try
            {
                List<datoGraficaPasteSur> listaDatos = new List<datoGraficaPasteSur>();

                datoGraficaPasteSur nuevoDG = new datoGraficaPasteSur();


                var resultado = (from bxc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bxc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bxc.idResumenDiario equals nb.idResumenDiario
                                 where bxc.fecha >= fechainicial && bxc.fecha <= fechaFinal && nb.RegionID == 3 && bxc.Personalid == personalid
                                 group bxc by rt.AccionesNombre into g
                                 select new
                                 {
                                     AccionesNombre = g.Key,
                                     AccionesID = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficaPasteSur();

                    nuevoDG.CantidadSur = data.AccionesID;
                    nuevoDG.etiquetaRSur = data.AccionesNombre;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public class datoGraficabartesur
        {
            public int CantidadMunisur { get; set; }
            public string Municipiossuro { get; set; }
            public datoGraficabartesur() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficabartesur> datoGraficabartesurMuni(string x, string fechaInicial, string fechafinal, string IdUser)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            int personalid = Convert.ToInt32(IdUser);
            try
            {
                List<datoGraficabartesur> listaDatos = new List<datoGraficabartesur>();

                datoGraficabartesur nuevoDG = new datoGraficabartesur();


                var resultado = (from xxx in ctx.tb_Reporte_Diario
                                 join rrr in ctx.tb_DireccionReporte on xxx.idResumenDiario equals rrr.idResumenDiario
                                 join tt in ctx.Municipios on rrr.MunicipioID equals tt.MunicipioID
                                 where xxx.fecha >= fechainicial && xxx.fecha <= fechaFinal && rrr.RegionID == 3 & xxx.Personalid == personalid
                                 group tt by tt.MUNICIPIO into g
                                 select new
                                 {
                                     Municipios = g.Key,
                                     municipiosid = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficabartesur();

                    nuevoDG.CantidadMunisur = data.municipiosid;
                    nuevoDG.Municipiossuro = data.Municipios;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion*************************************

        protected void GvInformeResultados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int valor;
                    valor = (int)DataBinder.Eval(e.Row.DataItem, "programasID");
                    Image img = (Image)e.Row.FindControl("imgpato");

                    if (valor == 1)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/Empresarial.png";
                    }
                    if (valor == 2)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/RedesVecinales.png";
                    }
                    if (valor == 3)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/Escolar.png";
                    }
                    if (valor == 4)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/ViolenciaGenero.png";
                    }
                    if (valor == 5)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/EncuentroCiudadano.png";
                    }


                    if (valor == 7)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/ConstrucionCultura.png";
                    }
                    if (valor == 8)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/RedesVecinales.png";
                    }
                    if (valor == 9)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/Escolar.png";
                    }
                    if (valor == 10)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/ViolenciaGenero.png";
                    }
                    if (valor == 11)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/EncuentroCiudadano.png";
                    }
                    if (valor == 12)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/DeporteYcultura.png";
                    }
                    if (valor == 13)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/ConstrucionCultura.png";
                    }


                    int valorft;
                    valorft = (int)DataBinder.Eval(e.Row.DataItem, "fotos");
                    Image imgft = (Image)e.Row.FindControl("imgFoto");

                    if (valorft == 1)
                    {
                        imgft.ImageUrl = "~/Imagenes/PinesReporte/check.png";
                    }
                    if (valorft == 0)
                    {
                        imgft.ImageUrl = "~/Imagenes/PinesReporte/cross.png";
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}