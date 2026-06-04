using ICSharpCode.SharpZipLib.Zip;
using OfficeOpenXml;
using SIICOP_V1._2.Captura.DGRS;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SIICOP_V1._2.VistasReportes.DGRS
{

    public partial class Vista_de_datos_DGRS : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();

        private static DataTable dtPrincipal;
        bool valido = true;
        string textoValidacion = "<ul>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("DGPRS"))
                {

                    this.conteoactividadesAdmin();

                    //GvPCAdmin.Rows[0].Visible = false;
                }
                else
                {
                    this.Response.Redirect("~/Bienvenido_DGPRS.aspx");
                }
            }
        }

        #region metodo para buscar
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder generar el reporte. </ li>";
                valido = false;

            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }

            else
            {
            }
            this.conteoactividadesAdmin();
        }
        #endregion

        #region ####  CONTEO DE ACTIVIDADES
        protected void conteoactividadesAdmin()
        {
            if (this.txtFInicialC.Text == string.Empty)
            {
                this.lblTotalRegistros.Text = "Registros:" + ctx.Wv_DatosReportesHistorico.Where(ñ => ñ.Dependencia == "DGPRS").Count();
                //this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Count();
            }
            else
            {
                DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
                DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);

                int tiprograma = Convert.ToInt32(ddlProgramas.SelectedValue);
                int Zona = Convert.ToInt32(ddlZona.SelectedValue);

                if (Zona == 0 && tiprograma == 0)
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.Wv_DatosReportesHistorico.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.Dependencia == "DGPRS").Count();

                }
                else
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.Wv_DatosReportesHistorico.Where(x => ((x.fecha >= fechainicial && x.fecha <= fechaFinal) && (x.Dependencia == "DGPRS") && (x.RegionID == Zona || x.programasID == tiprograma))).Count();

                }


            }
        }

        #endregion

        protected void lkmapa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder generar el reporte. </ li>";
                valido = false;
            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }
            else
            {

                //string sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                //var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                hfDependencia.Value = "DGPRS";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModal", "openModal();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarActDependencias", "MostrarActDependencias();", true);
            }
        }

        protected void ddlProgramas_DataBound(object sender, EventArgs e)
        {
            this.ddlProgramas.Items.Insert(0, new ListItem("--Seleccione un programa--", "0"));

        }

        #region MEOTODO PARA VER SI LA ACTIVIDAD TIENE FOTO Y QUE PIN TINE LA ACTIVIDAD
        protected void GvPCAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int valor;
                    valor = (int)DataBinder.Eval(e.Row.DataItem, "programasID");
                    Image img = (Image)e.Row.FindControl("imgpato");




                    if (valor == 29)
                    {
                        img.ImageUrl = "~/Imagenes/Banner/DGPRS/Pines/Clases.png";
                    }
                    if (valor == 30)
                    {
                        img.ImageUrl = "~/Imagenes/Banner/DGPRS/Pines/Motivacional.png";
                    }
                    if (valor == 31)
                    {
                        img.ImageUrl = "~/Imagenes/Banner/DGPRS/Pines/Ejercicios.png";
                    }


                    int valorft;
                    valorft = (int)DataBinder.Eval(e.Row.DataItem, "fotos");
                    Image imgft = (Image)e.Row.FindControl("imgfoto");
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
        #endregion

        protected void GvPCAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int prevencion = 29;
            int motivando = 30;
            int campaña = 31;



            if (e.CommandName == "Editar")
            {
                Guid idExped = Guid.Parse(e.CommandArgument.ToString());

                tb_Reporte_Diario Reporte = ctx.tb_Reporte_Diario.Where(t => t.idResumenDiario == idExped).FirstOrDefault();
                int Progrmaid = Convert.ToInt32(Reporte.programasID);

                if (prevencion == Progrmaid)
                {
                    this.Session["AccionReporte"] = Actividades_DGRS.AccionReporte.Edicion;
                    this.Session["idReporte_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/DGPRS/Actividades_DGPRS.aspx");
                }

                if (campaña == Progrmaid)
                {
                    this.Session["AccionReporte"] = Actividades_DGRS.AccionReporte.Edicion;
                    this.Session["idReporte_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/DGPRS/Actividades_DGPRS.aspx");
                }
                if (motivando == Progrmaid)
                {
                    this.Session["AccionReporte"] = Actividades_DGRS.AccionReporte.Edicion;
                    this.Session["idReporte_Accion"] = (object)idExped;
                    this.Response.Redirect("~/Captura/DGPRS/Actividades_DGPRS.aspx");
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

        #region****************METODO EXPORTACIÓN DE EXCEL GENERAL DE ACTIVIDADES
        protected void lkbtnexcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder generar el reporte. </ li>";
                valido = false;

            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }
            else
            {
                //exportar_img();


                String Plantilla;
                OfficeOpenXml.ExcelPackage package = null;
                var fileStream = new MemoryStream();
                Plantilla = Server.MapPath("~/Formatos/") + "Actividades_Total.xlsx";
                FileStream ArchivoStream = File.OpenRead(Plantilla);
                package = new ExcelPackage(new FileInfo(Plantilla));
                ExcelWorkbook excelWorkBook = package.Workbook;
                var xlWorkSheetGral = excelWorkBook.Worksheets["ActividadesTotal"];

                LlenaHoja(xlWorkSheetGral);

                fileStream = new MemoryStream();
                package.SaveAs(fileStream);

                fileStream.Position = 0;
                File.WriteAllBytes(Server.MapPath("~/Formatos/") + "Total_Activides.xlsx", fileStream.ToArray());
                Response.ContentType = "Application/x-msexcel";
                string FilePath = Server.MapPath("~/Formatos/") + "Total_Activides.xlsx";
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = ContentType;
                Response.AddHeader("Content-disposition", "attachment;filename=Total_Activides.xlsx" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx");
                Response.WriteFile(FilePath);
                Response.Flush();
                fileStream.Close();
                package.Dispose();
            }
        }

        private void LlenaHoja(OfficeOpenXml.ExcelWorksheet xlWorkSheetGral)
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
                    int tiprograma = Convert.ToInt32(ddlProgramas.SelectedValue);

                    if (tiprograma == 0)
                    {
                        List<Wv_DatosReportesHistorico> listaReportes = ctx.Wv_DatosReportesHistorico.Where(R => (((convertidoFI && R.fecha >= fechaInicial) || !convertidoFI) && ((convertidoFF && R.fecha <= fechaFinal) || !convertidoFF) && (R.Dependencia == "DGPRS"))).ToList();
                        dtPrincipal = ConvertToDataTable(listaReportes);
                    }
                    else
                    {
                        List<Wv_DatosReportesHistorico> listaReportes = ctx.Wv_DatosReportesHistorico.Where(R => (((convertidoFI && R.fecha >= fechaInicial) || !convertidoFI) && ((convertidoFF && R.fecha <= fechaFinal) || !convertidoFF) && (R.Dependencia == "DGPRS") && R.programasID == tiprograma)).ToList();
                        dtPrincipal = ConvertToDataTable(listaReportes);
                    }


                    for (Renglon = 0; Renglon < dtPrincipal.Rows.Count; Renglon++)
                    {
                        xlWorkSheetGral.Cells[Renglon + 2, 1].Value = dtPrincipal.Rows[Renglon]["fecha"];
                        xlWorkSheetGral.Cells[Renglon + 2, 2].Value = dtPrincipal.Rows[Renglon]["RegionNombre"];
                        xlWorkSheetGral.Cells[Renglon + 2, 3].Value = dtPrincipal.Rows[Renglon]["DelegacionNombre"];
                        xlWorkSheetGral.Cells[Renglon + 2, 4].Value = dtPrincipal.Rows[Renglon]["MUNICIPIO"];
                        xlWorkSheetGral.Cells[Renglon + 2, 5].Value = dtPrincipal.Rows[Renglon]["calveMuni"];
                        xlWorkSheetGral.Cells[Renglon + 2, 6].Value = dtPrincipal.Rows[Renglon]["Localidad"];
                        xlWorkSheetGral.Cells[Renglon + 2, 7].Value = dtPrincipal.Rows[Renglon]["clavelocali"];
                        xlWorkSheetGral.Cells[Renglon + 2, 8].Value = dtPrincipal.Rows[Renglon]["NombrePrograma"];
                        xlWorkSheetGral.Cells[Renglon + 2, 9].Value = dtPrincipal.Rows[Renglon]["NombreSubPrograma"];
                        xlWorkSheetGral.Cells[Renglon + 2, 10].Value = dtPrincipal.Rows[Renglon]["AccionesNombre"];
                        xlWorkSheetGral.Cells[Renglon + 2, 11].Value = dtPrincipal.Rows[Renglon]["niños"];
                        xlWorkSheetGral.Cells[Renglon + 2, 12].Value = dtPrincipal.Rows[Renglon]["niñas"];
                        xlWorkSheetGral.Cells[Renglon + 2, 13].Value = dtPrincipal.Rows[Renglon]["hombres"];
                        xlWorkSheetGral.Cells[Renglon + 2, 14].Value = dtPrincipal.Rows[Renglon]["mujeres"];
                        xlWorkSheetGral.Cells[Renglon + 2, 15].Value = dtPrincipal.Rows[Renglon]["docentesH"];
                        xlWorkSheetGral.Cells[Renglon + 2, 16].Value = dtPrincipal.Rows[Renglon]["docentesM"];
                        xlWorkSheetGral.Cells[Renglon + 2, 17].Value = dtPrincipal.Rows[Renglon]["TotalHombresAtendidos"];
                        xlWorkSheetGral.Cells[Renglon + 2, 18].Value = dtPrincipal.Rows[Renglon]["TotalMujeresAtendidas"];
                        xlWorkSheetGral.Cells[Renglon + 2, 19].Value = dtPrincipal.Rows[Renglon]["total_atendidos"];
                        xlWorkSheetGral.Cells[Renglon + 2, 20].Value = dtPrincipal.Rows[Renglon]["calle"];
                        xlWorkSheetGral.Cells[Renglon + 2, 21].Value = dtPrincipal.Rows[Renglon]["coloni"];
                        xlWorkSheetGral.Cells[Renglon + 2, 22].Value = dtPrincipal.Rows[Renglon]["NombreLugar_Escuela"];
                        xlWorkSheetGral.Cells[Renglon + 2, 23].Value = dtPrincipal.Rows[Renglon]["ClavePlantel"];
                        xlWorkSheetGral.Cells[Renglon + 2, 24].Value = dtPrincipal.Rows[Renglon]["Turno"];
                        xlWorkSheetGral.Cells[Renglon + 2, 25].Value = dtPrincipal.Rows[Renglon]["Nivel"];
                        xlWorkSheetGral.Cells[Renglon + 2, 26].Value = dtPrincipal.Rows[Renglon]["NombreContacto"];
                        xlWorkSheetGral.Cells[Renglon + 2, 27].Value = dtPrincipal.Rows[Renglon]["telcel"];
                        xlWorkSheetGral.Cells[Renglon + 2, 28].Value = dtPrincipal.Rows[Renglon]["Latitud"];
                        xlWorkSheetGral.Cells[Renglon + 2, 29].Value = dtPrincipal.Rows[Renglon]["Longitud"];
                        xlWorkSheetGral.Cells[Renglon + 2, 30].Value = dtPrincipal.Rows[Renglon]["FolioActividad"];
                        xlWorkSheetGral.Cells[Renglon + 2, 31].Value = dtPrincipal.Rows[Renglon]["idResumenDiario"];
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

        #region ## FORMATO DE EXPORTACION DE IMAGENES A ZIP
        public void ExportaImagenesZip()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);

            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + $"FOTOGRAFÍAS_ACTIVIDADES" + ".zip");
            Response.ContentType = "application/zip";
            Response.Cookies.Add(new HttpCookie("downloadStarted", "1") { Expires = DateTime.Now.AddSeconds(40) });
            string nombreArchivo = "";
            //List<tb_fotografia> foto = ctx.tb_fotografia.Where(x => x.idResumenDiario == idExped).ToList();
            int programa = Convert.ToInt32(ddlProgramas.SelectedValue);



            if (programa == 0)
            {
                var consulta = (from Item1 in ctx.tb_Reporte_Diario
                                join Item2 in ctx.tb_fotografia
                                on Item1.idResumenDiario equals Item2.idResumenDiario
                                join Item3 in ctx.Personales
                                on Item1.Personalid equals Item3.Personalid
                                where Item1.fecha >= fechainicial && Item1.fecha <= fechaFinal && Item3.Dependencia == "DGPRS"
                                select new
                                {
                                    Item2.idResumenDiario,
                                    Item2.ImgBase64,
                                    Item2.FileName,
                                    Item2.image,
                                    Item1.FolioActividad,
                                    Item2.idfotgrafia


                                }).ToList();


                using (var zipStream = new ZipOutputStream(Response.OutputStream))
                {
                    foreach (var item in consulta)
                    {
                        Guid valor = item.idResumenDiario.Value;
                        string NombreFoto = item.FileName;
                        Byte[] bytes;
                        string base64StringImg = item.ImgBase64;
                        string fol1 = item.idfotgrafia + "-" + item.FolioActividad;
                        string folio2 = item.idfotgrafia + "-" + item.idResumenDiario;

                        if (item.image == null)
                        {
                            bytes = Convert.FromBase64String(base64StringImg);

                        }
                        else
                        {
                            bytes = item.image;
                        }

                        if (NombreFoto != null)
                        {

                            var x = NombreFoto.Split('.');

                            if (item.FolioActividad == null)
                            {
                                nombreArchivo = $"{folio2}.{x[x.Length - 1]}";

                            }
                            else
                            {
                                nombreArchivo = $"{fol1}.{x[x.Length - 1]}";

                            }

                            //nombreArchivo = FOlio;
                            var fileEntry = new ZipEntry(nombreArchivo)
                            {


                                Size = bytes.Length
                            };

                            zipStream.PutNextEntry(fileEntry);
                            zipStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                    Response.End();
                    zipStream.Flush();
                    zipStream.Close();
                }
            }
            else
            {
                var consulta = (from Item1 in ctx.tb_Reporte_Diario
                                join Item2 in ctx.tb_fotografia
                                on Item1.idResumenDiario equals Item2.idResumenDiario
                                where Item1.fecha >= fechainicial && Item1.fecha <= fechaFinal && Item1.programasID == programa
                                select new
                                {
                                    Item2.idResumenDiario,
                                    Item2.ImgBase64,
                                    Item2.FileName,
                                    Item2.image,
                                    Item1.FolioActividad,
                                    Item2.idfotgrafia

                                }).ToList();


                using (var zipStream = new ZipOutputStream(Response.OutputStream))
                {
                    foreach (var item in consulta)
                    {
                        Guid valor = item.idResumenDiario.Value;
                        string NombreFoto = item.FileName;
                        Byte[] bytes;
                        string base64StringImg = item.ImgBase64;
                        string fol1 = item.idfotgrafia + "-" + item.FolioActividad;
                        string folio2 = item.idfotgrafia + "-" + item.idResumenDiario;

                        if (item.image == null)
                        {
                            bytes = Convert.FromBase64String(base64StringImg);

                        }
                        else
                        {
                            bytes = item.image;
                        }

                        if (NombreFoto != null)
                        {

                            var x = NombreFoto.Split('.');

                            if (item.FolioActividad == null)
                            {
                                nombreArchivo = $"{folio2}.{x[x.Length - 1]}";

                            }
                            else
                            {
                                nombreArchivo = $"{fol1}.{x[x.Length - 1]}";

                            }

                            //nombreArchivo = FOlio;
                            var fileEntry = new ZipEntry(nombreArchivo)
                            {


                                Size = bytes.Length
                            };

                            zipStream.PutNextEntry(fileEntry);
                            zipStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                    Response.End();
                    zipStream.Flush();
                    zipStream.Close();
                }
            }




        }

        protected void lnkbtnZip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder descargar las imagenes. </ li>";
                valido = false;
            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }
            else
            {
                ExportaImagenesZip();
            }
        }
        #endregion

    }
}