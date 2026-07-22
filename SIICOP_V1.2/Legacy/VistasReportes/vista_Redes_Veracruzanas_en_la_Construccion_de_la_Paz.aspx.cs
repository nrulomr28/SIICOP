using OfficeOpenXml;
using SIICOP_V1._2.Captura;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.VistasReportes
{
    public partial class vista_Redes_Veracruzanas_en_la_Construccion_de_la_Paz : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        private int iduser;
        private static DataTable dtPrincipal;
        int progragr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Cap_RVCPZ") || User.IsInRole("Admin_RVCPZ"))
                {

                    if (this.User.IsInRole("SYSADMIN") || this.User.IsInRole("Admin_RVCPZ"))
                    {

                        this.GvRedesPazCap.Visible = false;
                        this.GvAdminRedesPaz.Visible = true;
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
                        GvRedesPazCap.Visible = true;
                        lkbtnexcel.Visible = false;
                        GvAdminRedesPaz.Visible = false;
                        GvRedesPazCap.DataBind();

                    }
                    this.conteoactividadesAdmin();
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
            this.conteoactividadesAdmin();
        }
        #region**** METODO DE CONTEO DE ACTIVIDADES EN LOS GRID 
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
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.programasID == 14 && x.Personalid == this.iduser).Count();

                }
                else
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.programasID == 14).Count();

                }


            }
            else
            {
                DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
                DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
                if (this.iduser != 0)
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.programasID == 14 && x.Personalid == this.iduser).Count();

                }
                else
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.programasID == 14).Count();

                }
            }

        }
        #endregion

        #region *****  BOTON PARA EXPORTAR EN EXCEL LAS ACTIVIDADES
        protected void lkbtnexcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('Favor de ingresar los campos de fecha para poder exportar en Excel.');", true);
            }
            else
            {
                String Plantilla;
                OfficeOpenXml.ExcelPackage package = null;
                var fileStream = new MemoryStream();
                Plantilla = Server.MapPath("~/Formatos/") + "Actividades_Redes_Veracruzanas_SIICOP.xlsx";
                FileStream ArchivoStream = File.OpenRead(Plantilla);
                package = new ExcelPackage(new FileInfo(Plantilla));
                ExcelWorkbook excelWorkBook = package.Workbook;
                var xlWorkSheet = excelWorkBook.Worksheets["Hoja1"];

                LlenaHoja(xlWorkSheet);

                fileStream = new MemoryStream();
                package.SaveAs(fileStream);

                fileStream.Position = 0;
                File.WriteAllBytes(Server.MapPath("~/Formatos/") + "Total_Actividades_Redes_Veracruzanas_SIICOP.xlsx", fileStream.ToArray());
                Response.ContentType = "Application/x-msexcel";
                string FilePath = Server.MapPath("~/Formatos/") + "Total_Actividades_Redes_Veracruzanas_SIICOP.xlsx";
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = ContentType;
                Response.AddHeader("Content-disposition", "attachment;filename=Total_Actividades_Redes_Veracruzanas_SIICOP.xlsx" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx");
                Response.WriteFile(FilePath);
                Response.Flush();
                fileStream.Close();
                package.Dispose();
            }
        }

        private void LlenaHoja(OfficeOpenXml.ExcelWorksheet xlWorkSheet)
        {
            try
            {
                dtPrincipal = null;
                int Renglon;
                if (Session["dtPrincipal"] == null)
                {
                    bool convertidoFI = false;
                    bool convertidoFF = false;
                    DateTime fechaInicial = new DateTime();
                    convertidoFI = DateTime.TryParse(txtFInicialC.Text, out fechaInicial);
                    DateTime fechaFinal = new DateTime();
                    convertidoFF = DateTime.TryParse(txtfechafin.Text, out fechaFinal);


                    int PROGRA = 14;


                    List<wv_reportesGeneralExcel> listaReportes = ctx.wv_reportesGeneralExcel.Where(R => (((convertidoFI && R.fecha >= fechaInicial) || !convertidoFI) && ((convertidoFF && R.fecha <= fechaFinal) || !convertidoFF) &&
                                                                                             (R.programasID == PROGRA))).ToList();
                    dtPrincipal = ConvertToDataTable(listaReportes);

                    for (Renglon = 0; Renglon < dtPrincipal.Rows.Count; Renglon++)
                    {
                        xlWorkSheet.Cells[Renglon + 2, 1].Value = dtPrincipal.Rows[Renglon]["fechax"];
                        xlWorkSheet.Cells[Renglon + 2, 2].Value = dtPrincipal.Rows[Renglon]["RegionNombre"];
                        xlWorkSheet.Cells[Renglon + 2, 3].Value = dtPrincipal.Rows[Renglon]["DelegacionNombre"];
                        xlWorkSheet.Cells[Renglon + 2, 4].Value = dtPrincipal.Rows[Renglon]["MUNICIPIO"];
                        xlWorkSheet.Cells[Renglon + 2, 5].Value = dtPrincipal.Rows[Renglon]["Localidad"];
                        xlWorkSheet.Cells[Renglon + 2, 6].Value = dtPrincipal.Rows[Renglon]["NombrePrograma"];
                        xlWorkSheet.Cells[Renglon + 2, 7].Value = dtPrincipal.Rows[Renglon]["NombreSubPrograma"];
                        xlWorkSheet.Cells[Renglon + 2, 8].Value = dtPrincipal.Rows[Renglon]["AccionesNombre"];
                        xlWorkSheet.Cells[Renglon + 2, 9].Value = dtPrincipal.Rows[Renglon]["niños"];
                        xlWorkSheet.Cells[Renglon + 2, 10].Value = dtPrincipal.Rows[Renglon]["niñas"];
                        xlWorkSheet.Cells[Renglon + 2, 11].Value = dtPrincipal.Rows[Renglon]["hombres"];
                        xlWorkSheet.Cells[Renglon + 2, 12].Value = dtPrincipal.Rows[Renglon]["mujeres"];
                        xlWorkSheet.Cells[Renglon + 2, 13].Value = dtPrincipal.Rows[Renglon]["docentesH"];
                        xlWorkSheet.Cells[Renglon + 2, 14].Value = dtPrincipal.Rows[Renglon]["docentesM"];

                        xlWorkSheet.Cells[Renglon + 2, 15].Value = dtPrincipal.Rows[Renglon]["EmpreH"];
                        xlWorkSheet.Cells[Renglon + 2, 16].Value = dtPrincipal.Rows[Renglon]["EmpreM"];
                        xlWorkSheet.Cells[Renglon + 2, 17].Value = dtPrincipal.Rows[Renglon]["AgremiadoM"];
                        xlWorkSheet.Cells[Renglon + 2, 18].Value = dtPrincipal.Rows[Renglon]["AgremiadoH"];
                        xlWorkSheet.Cells[Renglon + 2, 19].Value = dtPrincipal.Rows[Renglon]["CiudadanoH"];
                        xlWorkSheet.Cells[Renglon + 2, 20].Value = dtPrincipal.Rows[Renglon]["CiudadanoM"];
                        xlWorkSheet.Cells[Renglon + 2, 21].Value = dtPrincipal.Rows[Renglon]["ActoresSocialH"];
                        xlWorkSheet.Cells[Renglon + 2, 22].Value = dtPrincipal.Rows[Renglon]["ActoresSocialM"];
                        xlWorkSheet.Cells[Renglon + 2, 23].Value = dtPrincipal.Rows[Renglon]["PrecidentemuniH"];
                        xlWorkSheet.Cells[Renglon + 2, 24].Value = dtPrincipal.Rows[Renglon]["PrecidentemuniM"];

                        xlWorkSheet.Cells[Renglon + 2, 25].Value = dtPrincipal.Rows[Renglon]["TotalHombresAtendidos"];
                        xlWorkSheet.Cells[Renglon + 2, 26].Value = dtPrincipal.Rows[Renglon]["TotalMujeresAtendidas"];
                        xlWorkSheet.Cells[Renglon + 2, 27].Value = dtPrincipal.Rows[Renglon]["total_atendidos"];
                        xlWorkSheet.Cells[Renglon + 2, 28].Value = dtPrincipal.Rows[Renglon]["calle"];
                        xlWorkSheet.Cells[Renglon + 2, 29].Value = dtPrincipal.Rows[Renglon]["coloni"];
                        xlWorkSheet.Cells[Renglon + 2, 30].Value = dtPrincipal.Rows[Renglon]["NombreLugar_Escuela"];
                        xlWorkSheet.Cells[Renglon + 2, 31].Value = dtPrincipal.Rows[Renglon]["ClavePlantel"];
                        xlWorkSheet.Cells[Renglon + 2, 32].Value = dtPrincipal.Rows[Renglon]["Turno"];
                        xlWorkSheet.Cells[Renglon + 2, 33].Value = dtPrincipal.Rows[Renglon]["Nivel"];
                        xlWorkSheet.Cells[Renglon + 2, 34].Value = dtPrincipal.Rows[Renglon]["NombreContacto"];
                        xlWorkSheet.Cells[Renglon + 2, 35].Value = dtPrincipal.Rows[Renglon]["telcel"];
                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }

        }


        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        protected void edsEstadistico_Selected(object sender, EntityDataSourceSelectedEventArgs e)
        {
            //Session["dtPrincipal"] = e.Results;
            List<wv_reportesGeneralExcel> listado = e.Results.Cast<wv_reportesGeneralExcel>().ToList();

            Session["dtPrincipal"] = listado;


        }
        #endregion

        #region *** BOTON PARA MANDAR A TRAER EL METODO DEL MAPA Y PINTAR SUS PUNTOS 
        protected void lkmapa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('Favor de ingresar los campos de fecha para poder puntear el mapa.');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModal", "openModal();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarPlanteles", "MostrarPlanteles();", true);
            }
        }

        #endregion

        #region *** BOTON PARA MANDAR A TRAER EL METODO DE LAS GRAFICAS Y CONTEOS DE ANTENDIOS POR ZONAS, MUNICIPIOS, BENEFICIADOS, ACCIONES
        protected void lkGraficas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('Favor de ingresar los campos de fecha para poder mostrar las graficas.');", true);
            }
            else
            {
                this.totalAtendidos();
                this.totalAcciones();
                this.totalporZonas();
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaHombresXacciones", "ConsultaHombresXacciones();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMuniNorte", "ConsultaMuniNorte();", true);

                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionescentroTtotal", "AccionescentroTtotal();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunicentro", "ConsultaMunicentro();", true);

                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionesSurTtotal", "AccionesSurTtotal();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunisur", "ConsultaMunisur();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModalGrafi", "openModalGrafi();", true);
            }



        }

        public void totalporZonas()
        {

            //Municipios atendidos por zonas y general 
            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
            this.progragr = 14;
            this.MuniTtoatl.InnerText = (from sp in ctx.tb_Reporte_Diario
                                         join stdr in ctx.tb_DireccionReporte
                                         on sp.idResumenDiario equals stdr.idResumenDiario
                                         where sp.fecha >= fechainicial && sp.fecha <= fechaFinal && sp.programasID == progragr
                                         select stdr.MunicipioID).Distinct().Count().ToString();
            int zonaNorte = 1;
            int ZonaCentroo = 2;
            int ZonaSur = 3;

            this.ZonaNorte.InnerText = (from s in ctx.tb_Reporte_Diario
                                        join std in ctx.tb_DireccionReporte
                                        on s.idResumenDiario equals std.idResumenDiario
                                        where s.fecha >= fechainicial && s.fecha <= fechaFinal && std.RegionID == zonaNorte && s.programasID == progragr
                                        select std.MunicipioID).Distinct().Count().ToString();

            this.ZonaCentro.InnerText = (from a in ctx.tb_Reporte_Diario
                                         join b in ctx.tb_DireccionReporte
                                         on a.idResumenDiario equals b.idResumenDiario
                                         where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == ZonaCentroo && a.programasID == progragr
                                         select b.MunicipioID).Distinct().Count().ToString();

            this.ZonaSurRR.InnerText = (from c in ctx.tb_Reporte_Diario
                                        join d in ctx.tb_DireccionReporte
                                        on c.idResumenDiario equals d.idResumenDiario
                                        where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == ZonaSur && c.programasID == progragr
                                        select d.MunicipioID).Distinct().Count().ToString();

        }
        public void totalAtendidos()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
            this.progragr = 14;
            //Beneficiados
            this.H2NinasBeneficiadas.InnerText = (from c in ctx.tb_Reporte_Diario
                                                  join d in ctx.tb_DireccionReporte
                                                  on c.idResumenDiario equals d.idResumenDiario
                                                  join pr in ctx.TB_DatosGralReporte
                                                  on c.idResumenDiario equals pr.idResumenDiario
                                                  where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.programasID == progragr
                                                  select pr.niñas).Sum().ToString();

            this.H2NinosBeneficiados.InnerText = (from c in ctx.tb_Reporte_Diario
                                                  join d in ctx.tb_DireccionReporte
                                                  on c.idResumenDiario equals d.idResumenDiario
                                                  join prt in ctx.TB_DatosGralReporte
                                                  on c.idResumenDiario equals prt.idResumenDiario
                                                  where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.programasID == progragr
                                                  select prt.niños).Sum().ToString();

            this.H3PadresFamilia.InnerText = (from c in ctx.tb_Reporte_Diario
                                              join d in ctx.tb_DireccionReporte
                                              on c.idResumenDiario equals d.idResumenDiario
                                              join qpr in ctx.TB_DatosGralReporte
                                              on c.idResumenDiario equals qpr.idResumenDiario
                                              where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.programasID == progragr
                                              select qpr.hombres).Sum().ToString();

            this.H4MadresFamilia.InnerText = (from c in ctx.tb_Reporte_Diario
                                              join d in ctx.tb_DireccionReporte
                                              on c.idResumenDiario equals d.idResumenDiario
                                              join qr in ctx.TB_DatosGralReporte
                                              on c.idResumenDiario equals qr.idResumenDiario
                                              where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == 1 && c.programasID == progragr
                                              select qr.mujeres).Sum().ToString();


            this.H5DocentesH.InnerText = (from c in ctx.tb_Reporte_Diario
                                          join d in ctx.tb_DireccionReporte
                                          on c.idResumenDiario equals d.idResumenDiario
                                          join qpr in ctx.TB_DatosGralReporte
                                          on c.idResumenDiario equals qpr.idResumenDiario
                                          where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.programasID == progragr
                                          select qpr.docentesH).Sum().ToString();

            this.H6DocentesM.InnerText = (from c in ctx.tb_Reporte_Diario
                                          join d in ctx.tb_DireccionReporte
                                          on c.idResumenDiario equals d.idResumenDiario
                                          join qr in ctx.TB_DatosGralReporte
                                          on c.idResumenDiario equals qr.idResumenDiario
                                          where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.programasID == progragr
                                          select qr.docentesM).Sum().ToString();
            //termino de beneficiados


            this.TotalGeneralAten.InnerText = ctx.tb_Reporte_Diario.Where(p => p.fecha >= fechainicial && p.fecha <= fechaFinal & p.programasID == progragr).Sum(x => x.total_atendidos.Value).ToString();

            this.PersonasZonaNorte.InnerText = (from c in ctx.tb_Reporte_Diario
                                                join d in ctx.tb_DireccionReporte
                                                on c.idResumenDiario equals d.idResumenDiario
                                                where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == 1 && c.programasID == progragr
                                                select c.total_atendidos).Sum().ToString();

            this.PersonasAtendidasZonaCentro.InnerText = (from m in ctx.tb_Reporte_Diario
                                                          join n in ctx.tb_DireccionReporte
                                                          on m.idResumenDiario equals n.idResumenDiario
                                                          where m.fecha >= fechainicial && m.fecha <= fechaFinal && n.RegionID == 2 && m.programasID == progragr
                                                          select m.total_atendidos).Sum().ToString();

            this.personasAtendidasZonaSur.InnerText = (from ma in ctx.tb_Reporte_Diario
                                                       join nr in ctx.tb_DireccionReporte
                                                       on ma.idResumenDiario equals nr.idResumenDiario
                                                       where ma.fecha >= fechainicial && ma.fecha <= fechaFinal && nr.RegionID == 3 && ma.programasID == progragr
                                                       select ma.total_atendidos).Sum().ToString();

        }
        public void totalAcciones()
        {
            this.progragr = 14;

            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
            this.TotalAcx.InnerText = ctx.tb_Reporte_Diario.Where(u => u.fecha >= fechainicial && u.fecha <= fechaFinal && u.programasID == progragr).Select(u => u.AccionesID).Count().ToString();

            this.AccionesZonaNorte.InnerText = (from a in ctx.tb_Reporte_Diario
                                                join b in ctx.tb_DireccionReporte
                                                on a.idResumenDiario equals b.idResumenDiario
                                                where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == 1 && a.programasID == progragr
                                                select a.AccionesID).Count().ToString();


            this.accionesRealizadasZonaCentro.InnerText = (from k in ctx.tb_Reporte_Diario
                                                           join l in ctx.tb_DireccionReporte
                                                           on k.idResumenDiario equals l.idResumenDiario
                                                           where k.fecha >= fechainicial && k.fecha <= fechaFinal && l.RegionID == 2 && k.programasID == progragr
                                                           select k.AccionesID).Count().ToString();

            this.AccionesRealizadasSur.InnerText = (from w in ctx.tb_Reporte_Diario
                                                    join x in ctx.tb_DireccionReporte
                                                    on w.idResumenDiario equals x.idResumenDiario
                                                    where w.fecha >= fechainicial && w.fecha <= fechaFinal && x.RegionID == 3 && w.programasID == progragr
                                                    select w.AccionesID).Count().ToString();
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
        public static List<datoGraficaPasteNorte> ChartDataNorteAccionesta(string x, string fechaInicial, string fechafinal)
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
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && ar.programasID == 14
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
        public static List<datoGraficabarteNorte> datoGraficabarteNorteMuni(string x, string fechaInicial, string fechafinal)
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
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && ar.programasID == 14
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
        public static List<datoGraficaPastecentro> ChartDataCentroAccionesta(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPastecentro> listaDatos = new List<datoGraficaPastecentro>();

                datoGraficaPastecentro nuevoDG = new datoGraficaPastecentro();


                var resultado = (from bc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bc.idResumenDiario equals nb.idResumenDiario
                                 where bc.fecha >= fechainicial && bc.fecha <= fechaFinal && nb.RegionID == 2 && bc.programasID == 14
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
        public static List<datoGraficabartecentro> datoGraficabarteCentroMuni(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabartecentro> listaDatos = new List<datoGraficabartecentro>();

                datoGraficabartecentro nuevoDG = new datoGraficabartecentro();


                var resultado = (from arx in ctx.tb_Reporte_Diario
                                 join xry in ctx.tb_DireccionReporte on arx.idResumenDiario equals xry.idResumenDiario
                                 join bzt in ctx.Municipios on xry.MunicipioID equals bzt.MunicipioID
                                 where arx.fecha >= fechainicial && arx.fecha <= fechaFinal && xry.RegionID == 2 && arx.programasID == 14
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
        public static List<datoGraficaPasteSur> ChartDataSurAccionesta(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPasteSur> listaDatos = new List<datoGraficaPasteSur>();

                datoGraficaPasteSur nuevoDG = new datoGraficaPasteSur();


                var resultado = (from bxc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bxc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bxc.idResumenDiario equals nb.idResumenDiario
                                 where bxc.fecha >= fechainicial && bxc.fecha <= fechaFinal && nb.RegionID == 3 && bxc.programasID == 14
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
        public static List<datoGraficabartesur> datoGraficabartesurMuni(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabartesur> listaDatos = new List<datoGraficabartesur>();

                datoGraficabartesur nuevoDG = new datoGraficabartesur();


                var resultado = (from xxx in ctx.tb_Reporte_Diario
                                 join rrr in ctx.tb_DireccionReporte on xxx.idResumenDiario equals rrr.idResumenDiario
                                 join tt in ctx.Municipios on rrr.MunicipioID equals tt.MunicipioID
                                 where xxx.fecha >= fechainicial && xxx.fecha <= fechaFinal && rrr.RegionID == 3 & xxx.programasID == 14
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
        #endregion

        #region**** GRIDVIEW CAPTURISTA
        protected void GvRedesPazCap_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = GvRedesPazCap.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabel");
                Label pageLabel2 = (Label)pagerRow.FindControl("CurrentPageLabel1");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvRedesPazCap.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvRedesPazCap.PageIndex)
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
                    int currentPage = GvRedesPazCap.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvRedesPazCap.PageCount.ToString();
                }

            }
            catch
            {
            }

        }

        protected void GvRedesPazCap_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Session["AccionExpediente"] = Redes_Veracruzanas_en_la_Construccion_de_la_Paz.AccionExpediente.Edicion;
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;
                    Response.Redirect("~/Captura/Redes_Veracruzanas_en_la_Construccion_de_la_Paz.aspx");
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

        protected void GvRedesPazCap_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                GridViewRow pagerRow = GvRedesPazCap.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                GvRedesPazCap.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...
                //lblInfo.Text = "";
            }
        }

        #endregion

        #region**** GRIDVIEW ADMINISTRADOR
        protected void GvAdminRedesPaz_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = GvAdminRedesPaz.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabeles1");

                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvAdminRedesPaz.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvAdminRedesPaz.PageIndex)
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
                    int currentPage = GvAdminRedesPaz.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvAdminRedesPaz.PageCount.ToString();

                }


            }
            catch
            {
            }
        }
        protected void PageDropDownListAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Recupera la fila.

            {
                GridViewRow pagerRow = GvAdminRedesPaz.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                GvAdminRedesPaz.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...
                //lblInfo.Text = "";
            }
        }
        protected void GvAdminRedesPaz_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Session["AccionExpediente"] = Redes_Veracruzanas_en_la_Construccion_de_la_Paz.AccionExpediente.Edicion;
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;
                    Response.Redirect("~/Captura/Redes_Veracruzanas_en_la_Construccion_de_la_Paz.aspx");
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

        protected void GvAdminRedesPaz_RowDataBound(object sender, GridViewRowEventArgs e)
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


        #endregion


    }
}