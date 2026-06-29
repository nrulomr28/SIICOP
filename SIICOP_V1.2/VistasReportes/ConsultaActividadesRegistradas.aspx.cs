using ICSharpCode.SharpZipLib.Zip;
using OfficeOpenXml;
using SIICOP_V1._2.Captura;
using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Datos.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.VistasReportes
{
    public partial class ConsultaActividadesRegistradas : System.Web.UI.Page
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
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Visualizador") || User.IsInRole("Operador"))
                {

                    CargarProgramas();
                    CargarZonas();
                }
                else
                {
                    this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
                }
            }
        }

        private (DateTime? FechaInicial,
         DateTime? FechaFinal,
         int? Zona,
         int? Programa,
         string Institucion) ObtenerFiltrosReporte()
        {
            DateTime? fechaInicial = null;
            DateTime? fechaFinal = null;

            if (DateTime.TryParse(txtFInicialC.Text, out DateTime fi))
                fechaInicial = fi;

            if (DateTime.TryParse(txtfechafin.Text, out DateTime ff))
                fechaFinal = ff;

            int? programa = null;

            if (ddlProgramas.SelectedValue != "0")
                programa = Convert.ToInt32(ddlProgramas.SelectedValue);

            int? zona = null;

            if (ddlZona.SelectedValue != "0")
                zona = Convert.ToInt32(ddlZona.SelectedValue);

            string institucion = null;

            if (!string.IsNullOrWhiteSpace(txtInstitucionesParticipantes.Text))
                institucion = txtInstitucionesParticipantes.Text.Trim();

            return (
                fechaInicial,
                fechaFinal,
                zona,
                programa,
                institucion);

        }

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
                DateTime result = new DateTime();
                if (DateTime.TryParse(this.txtFInicialC.Text, out result))
                {
                    this.Session["fInicialC"] = (object)result.ToShortDateString();
                }

                if (DateTime.TryParse(this.txtfechafin.Text, out result))
                {
                    this.Session["fFinalC"] = (object)result.ToShortDateString();
                }
            }
            CargarDatosReporte();
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
                DateTime fechaObjIni = Convert.ToDateTime(this.txtFInicialC.Text).Date;
                DateTime fechaObjFin = Convert.ToDateTime(this.txtfechafin.Text).Date;

                string fechainicial = fechaObjIni.ToString("yyyy-MM-dd");
                string fechaFinal = fechaObjFin.ToString("yyyy-MM-dd");
                int tiprograma = Convert.ToInt32(ddlProgramas.SelectedValue);
                int regionid = Convert.ToInt32(ddlZona.SelectedValue);


                ExcelPackage.License.SetNonCommercialOrganization("SSP");

                ExcelPackage excel = new ExcelPackage(); ;

                #region *** descrgar excel por medio de fechas
                var filtros = ObtenerFiltrosReporte();

                var repository = new ReporteRepository();

                var informe = repository
                    .ObtenerDatosReporte(
                        filtros.FechaInicial,
                        filtros.FechaFinal,
                        null,
                        filtros.Zona,
                        filtros.Programa,
                        null,
                        null,
                        filtros.Institucion).Select(a =>
                            new
                            {
                                Fecha = a.fecha,
                                Nombre_capturista = a.nombrecompleto,
                                Zona = a.RegionNombre,
                                Delegación = a.DelegacionNombre,
                                Municipio = a.MUNICIPIO,
                                Clave_Municipio = a.calveMuni,
                                Localidad = a.Localidad,
                                Clave_Localidad = a.clavelocali,
                                Nombre_Programa = a.NombrePrograma,
                                Nombre_Subprograma = a.NombreSubPrograma,
                                Nombre_Acciones = a.AccionesNombre,
                                Niños_Beneficiados = a.niños,
                                Niñas_Beneficiadas = a.niñas,
                                Hombres_Beneficiados = a.hombres,
                                Mujeres_Beneficiadas = a.mujeres,
                                Docentes_Hombres_Beneficiados = a.docentesH,
                                Docentes_Mujeres_Beneficiadas = a.docentesM,
                                Total_Hombres_Beneficiados = a.TotalHombresAtendidos,
                                Total_Mujeres_Beneficiadas = a.TotalMujeresAtendidas,
                                Total_Beficiados = a.total_atendidos,
                                Nombre_Contacto = a.NombreContacto,
                                Teléfono = a.telcel,
                                Nombre_Lugar_o_Escuela = a.NombreLugar_Escuela,
                                Clave_Plantel = a.ClavePlantel,
                       //      Turno = a.Turno,
                                Nivel_Educativo = a.Nivel,
                                Dirección = "Calle:" + " " + a.calle + "Colonia:" + " " + a.coloni,
                                Latitud = a.Latitud,
                                Longitud = a.Longitud,
                                Folio_Actividad = a.FolioActividad,
                                Folio_Alternativo = a.idResumenDiario,
                                Coordinación = a.DelegacionOcoonurbacion
                            }).ToList();
                #endregion
                var workSheet = excel.Workbook.Worksheets.Add("Hoja1");
                workSheet.Cells[1, 1].LoadFromCollection(informe, true);


                using (var memoryStream = new MemoryStream())
                {
                    excel.SaveAs(memoryStream);

                    Response.Clear();
                    Response.Buffer = true;

                    Response.ContentType =
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    Response.AddHeader(
                        "content-disposition",
                        "attachment; filename=Total_Activides.xlsx");

                    Response.BinaryWrite(memoryStream.ToArray());

                    Response.Flush();

                    Response.SuppressContent = true;

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
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

        protected void GvPCAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
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

                if (Reporte != null)
                {
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

            }

            if (e.CommandName == "VERFOTO")
            {
                Guid numFila;
                bool f1 = false;
                bool f2 = false;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;

                    ImagenEvidencia1.ImageUrl = "";
                    ImagenEvidencia2.ImageUrl = "";
                    ImagenEvidencia3.ImageUrl = "";
                    List<tb_fotografia> foto = ctx.tb_fotografia.Where(x => x.idResumenDiario == idExped).ToList();

                    foreach (var fotografia in foto)
                    {
                        Byte[] bytes = fotografia.image;
                        var numero = foto.ToArray().Count();
                        foreach (var r in numero.ToString())
                        {

                        }

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
                                f1 = true;
                            }


                            foto1.Visible = true;
                            fotouno.Visible = true;


                        }

                        if (f1 == true)
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

                            foto2.Visible = true;
                            fotodos.Visible = true;

                        }
                        if (f2 == true)
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
                            fototres.Visible = true;

                        }

                        updPanel.Update();

                        ScriptManager.RegisterStartupScript(
                                        Page,
                                        Page.GetType(),
                                        Guid.NewGuid().ToString(),
                                        "setTimeout(function(){ AbrirModalFotos(); }, 50);",
                                        true);
                    }
                }

            }


            if (e.CommandName == "Eliminar")
            {
                Guid idExped = Guid.Parse(e.CommandArgument.ToString());
                string sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                string area = a.AreaTrabajo;
                var Eliminardatos = ctx.sp_Elimninar_Actividades(idExped, sUsuarioActual, area).ToString();

                if (Eliminardatos == "1")
                {
                    //entro
                    tbAuditoria entity = new tbAuditoria()
                    {
                        auditoriaGuid = new Guid?(Guid.NewGuid()),
                        fecha = new DateTime?(DateTime.Now),
                        area = area,
                        idTipomodificacion = new int?(4),
                        PagModificacion = this.Page.Title,
                        Descripcion = "Se elimino la actividad por el usuario: " + sUsuarioActual,
                        usuario = sUsuarioActual,
                        IdABC = Convert.ToString((object)idExped)
                    };
                    ctx.tbAuditoria.Add(entity);
                    ctx.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('SE ELIMINO CON ÉXITO LA ACTIVIDAD.');", true);
                    GvPCAdmin.DataBind();
                    CargarDatosReporte();


                }
                else
                { //no entro
                    ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('ERROR AL ELIMINAR LA ACTIVIDAD.');", true);

                }
            }
        }
        protected void PageDropDownListAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                GridViewRow pagerRow = GvPCAdmin.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                GvPCAdmin.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...
                //lblInfo.Text = "";
            }
        }
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModal", "openModal();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarPlanteles", "MostrarPlanteles();", true);
            }
        }
        protected void GvPCAdmin_RowDataBound(
                    object sender,
                    GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }

            #region Programa

            var programa = DataBinder.Eval(
                e.Row.DataItem,
                "programasID");

            var imgPrograma =
                e.Row.FindControl("imgpato") as Image;

            if (programa != null &&
                programa != DBNull.Value &&
                imgPrograma != null)
            {
                switch (Convert.ToInt32(programa))
                {
                    case 7:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/ConstrucionCultura.png";
                        break;

                    case 8:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/RedesVecinales.png";
                        break;

                    case 9:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/Escolar.png";
                        break;

                    case 10:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/ViolenciaGenero.png";
                        break;

                    case 11:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/EncuentroCiudadano.png";
                        break;

                    case 12:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/DeporteYcultura.png";
                        break;

                    case 13:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/Empresarial.png";
                        break;

                    case 14:
                        imgPrograma.ImageUrl =
                            "~/Imagenes/PinesReporte/RedesVerPorLaPaz.png";
                        break;
                }
            }

            #endregion

            #region Fotografías

            var fotos = DataBinder.Eval(
                e.Row.DataItem,
                "fotos");

            var imgFotos =
                e.Row.FindControl("imgfoto") as Image;

            if (fotos != null &&
                fotos != DBNull.Value &&
                imgFotos != null)
            {
                imgFotos.ImageUrl =
                    Convert.ToInt32(fotos) == 1
                        ? "~/Imagenes/PinesReporte/check.png"
                        : "~/Imagenes/PinesReporte/cross.png";
            }

            #endregion

            #region Seguridad

            e.Row.Cells[15].Visible =
                User.IsInRole("SysAdmin")
                || User.IsInRole("Administrador")
                || User.IsInRole("Visualizador");

            #endregion

            #region Correcciones de Delegación

            switch (e.Row.Cells[5].Text)
            {
                case "Sector Empresarial":
                case "Sector Escolar":
                case "Violencia contra la Mujer":
                case "Departamento de Redes Vecinales":
                case "Departamento de Deporte y Cultura":
                case "Inclusión de personas en situación de vunerabilidad":

                    e.Row.Cells[5].Text =
                        "Conurbación Xalapa";
                    break;
            }

            #endregion
        }

        #region****************METODO EXPORTACIÓN DE EXCEL CEDULAS
        protected void lnBtnExpCedula_Click1(object sender, EventArgs e)
        {

            String plantillaIndicador1;
            plantillaIndicador1 = Server.MapPath("~/Formatos/") + "Avance_de_indicadores_DVI.xlsx";

            String plantillaIndicador2;
            plantillaIndicador2 = Server.MapPath("~/Formatos/") + "T_Avance_de_indicadores_DVI.xlsx";
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(plantillaIndicador1)))
            {
                OfficeOpenXml.ExcelPackage PackageB = null;
                PackageB = new ExcelPackage(new FileInfo(plantillaIndicador2));

                //Get a WorkSheet by index. Note that EPPlus indexes are base 1, not base 0!
                ExcelWorkbook eexcelWorkBook = PackageB.Workbook;
                //Get a WorkSheet by name. If the worksheet doesn't exist, throw an exeption
                var XlworkSheet = eexcelWorkBook.Worksheets["indicador 1"];
                LlenaHojaBeni(XlworkSheet);

                var XlworkSheetFF = eexcelWorkBook.Worksheets["indicador 2"];
                LlenaHojaAC_FF(XlworkSheetFF);

                var XlworkSheetConvenios = eexcelWorkBook.Worksheets["indicador 3"];
                LlenaHojaAC_Convenios(XlworkSheetConvenios);

                var XlworkSheetredes = eexcelWorkBook.Worksheets["indicador 4"];
                LlenaHojaAC_Redes(XlworkSheetredes);

                var XlworkSheetEscolar = eexcelWorkBook.Worksheets["indicador 5"];
                LlenaHojaAC_Escolar(XlworkSheetEscolar);

                var XlworkSheetDeporte = eexcelWorkBook.Worksheets["indicador 6"];
                LlenaHojaAC_Deporte(XlworkSheetDeporte);

                var XlworkSheetGenero = eexcelWorkBook.Worksheets["indicador 7"];
                LlenaHojaAC_Genero(XlworkSheetGenero);

                var XlworkSheetEmpresarial = eexcelWorkBook.Worksheets["indicador 8"];
                LlenaHojaAC_Empresarial(XlworkSheetEmpresarial);


                var XlworkSheetInclusion = eexcelWorkBook.Worksheets["indicador 9"];
                LlenaHojaAC_Inclusion(XlworkSheetInclusion);

                PackageB.Save();
                Response.Clear();
            }

            Response.ContentType = "Application/x-msexcel";
            string ArchivoPath = Server.MapPath("~/Formatos/") + "T_Avance_de_indicadores_DVI.xlsx";
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = ContentType;
            Response.AddHeader("Content-disposition", "attachment;filename=T_Avance_de_indicadores_DVI.xlsx" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx");
            Response.WriteFile(ArchivoPath);
            Response.Flush();

        }
        private void LlenaHojaBeni(OfficeOpenXml.ExcelWorksheet XlworkSheet)
        {
            try
            {
                DataTable dtPrincipalBeneficiados = null;
                int Renglon;
                if (Session["dtPrincipalBeneficiados"] == null)
                {

                    List<vw_Indicadores_Beneficiados> listaReportes_B = ctx.vw_Indicadores_Beneficiados.ToList();
                    dtPrincipalBeneficiados = ConvertToDataTable(listaReportes_B);

                    for (Renglon = 0; Renglon < dtPrincipalBeneficiados.Rows.Count; Renglon++)
                    {
                        XlworkSheet.Cells[Renglon + 11, 6].Value = dtPrincipalBeneficiados.Rows[Renglon]["ENERO_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 7].Value = dtPrincipalBeneficiados.Rows[Renglon]["FEBRERO_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 8].Value = dtPrincipalBeneficiados.Rows[Renglon]["MARZO_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 9].Value = dtPrincipalBeneficiados.Rows[Renglon]["ABRIL_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 10].Value = dtPrincipalBeneficiados.Rows[Renglon]["MAYO_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 11].Value = dtPrincipalBeneficiados.Rows[Renglon]["JUNIO_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 12].Value = dtPrincipalBeneficiados.Rows[Renglon]["JULIO_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 13].Value = dtPrincipalBeneficiados.Rows[Renglon]["AGOSTO_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 14].Value = dtPrincipalBeneficiados.Rows[Renglon]["SEPTIEMBRE_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 15].Value = dtPrincipalBeneficiados.Rows[Renglon]["OCTUBRE_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 16].Value = dtPrincipalBeneficiados.Rows[Renglon]["NOVIEMBRE_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 17].Value = dtPrincipalBeneficiados.Rows[Renglon]["DICIEMBRE_OBTENIDO_B"];
                        XlworkSheet.Cells[Renglon + 11, 18].Value = dtPrincipalBeneficiados.Rows[Renglon]["Suma_Obtenidos_B"];

                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }
        }
        private void LlenaHojaAC_FF(OfficeOpenXml.ExcelWorksheet XlworkSheetFF)
        {
            try
            {
                DataTable dtPrincipalAC_FF = null;
                int Renglon;
                if (Session["dtPrincipalAC_FF"] == null)
                {

                    List<vw_Indicadores_Acciones> listaReportes_AC_FF = ctx.vw_Indicadores_Acciones.Where(RT => RT.programasID == 11).ToList();
                    dtPrincipalAC_FF = ConvertToDataTable(listaReportes_AC_FF);

                    for (Renglon = 0; Renglon < dtPrincipalAC_FF.Rows.Count; Renglon++)
                    {
                        XlworkSheetFF.Cells[Renglon + 11, 6].Value = dtPrincipalAC_FF.Rows[Renglon]["ENERO"];
                        XlworkSheetFF.Cells[Renglon + 11, 7].Value = dtPrincipalAC_FF.Rows[Renglon]["FEBRERO"];
                        XlworkSheetFF.Cells[Renglon + 11, 8].Value = dtPrincipalAC_FF.Rows[Renglon]["MARZO"];
                        XlworkSheetFF.Cells[Renglon + 11, 9].Value = dtPrincipalAC_FF.Rows[Renglon]["ABRIL"];
                        XlworkSheetFF.Cells[Renglon + 11, 10].Value = dtPrincipalAC_FF.Rows[Renglon]["MAYO"];
                        XlworkSheetFF.Cells[Renglon + 11, 11].Value = dtPrincipalAC_FF.Rows[Renglon]["JUNIO"];
                        XlworkSheetFF.Cells[Renglon + 11, 12].Value = dtPrincipalAC_FF.Rows[Renglon]["JULIO"];
                        XlworkSheetFF.Cells[Renglon + 11, 13].Value = dtPrincipalAC_FF.Rows[Renglon]["AGOSTO"];
                        XlworkSheetFF.Cells[Renglon + 11, 14].Value = dtPrincipalAC_FF.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetFF.Cells[Renglon + 11, 15].Value = dtPrincipalAC_FF.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetFF.Cells[Renglon + 11, 16].Value = dtPrincipalAC_FF.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetFF.Cells[Renglon + 11, 17].Value = dtPrincipalAC_FF.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }
        }
        private void LlenaHojaAC_Redes(OfficeOpenXml.ExcelWorksheet XlworkSheetredes)
        {
            try
            {
                DataTable dtPrincipalAC_redes = null;
                int Renglon;
                if (Session["dtPrincipalAC_redes"] == null)
                {

                    List<vw_Indicadores_Acciones> listaReportes_AC_redes = ctx.vw_Indicadores_Acciones.Where(RT => RT.programasID == 8).ToList();
                    dtPrincipalAC_redes = ConvertToDataTable(listaReportes_AC_redes);

                    for (Renglon = 0; Renglon < dtPrincipalAC_redes.Rows.Count; Renglon++)
                    {
                        XlworkSheetredes.Cells[Renglon + 11, 6].Value = dtPrincipalAC_redes.Rows[Renglon]["ENERO"];
                        XlworkSheetredes.Cells[Renglon + 11, 7].Value = dtPrincipalAC_redes.Rows[Renglon]["FEBRERO"];
                        XlworkSheetredes.Cells[Renglon + 11, 8].Value = dtPrincipalAC_redes.Rows[Renglon]["MARZO"];
                        XlworkSheetredes.Cells[Renglon + 11, 9].Value = dtPrincipalAC_redes.Rows[Renglon]["ABRIL"];
                        XlworkSheetredes.Cells[Renglon + 11, 10].Value = dtPrincipalAC_redes.Rows[Renglon]["MAYO"];
                        XlworkSheetredes.Cells[Renglon + 11, 11].Value = dtPrincipalAC_redes.Rows[Renglon]["JUNIO"];
                        XlworkSheetredes.Cells[Renglon + 11, 12].Value = dtPrincipalAC_redes.Rows[Renglon]["JULIO"];
                        XlworkSheetredes.Cells[Renglon + 11, 13].Value = dtPrincipalAC_redes.Rows[Renglon]["AGOSTO"];
                        XlworkSheetredes.Cells[Renglon + 11, 14].Value = dtPrincipalAC_redes.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetredes.Cells[Renglon + 11, 15].Value = dtPrincipalAC_redes.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetredes.Cells[Renglon + 11, 16].Value = dtPrincipalAC_redes.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetredes.Cells[Renglon + 11, 17].Value = dtPrincipalAC_redes.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }
        }
        private void LlenaHojaAC_Escolar(OfficeOpenXml.ExcelWorksheet XlworkSheetEscolar)
        {
            try
            {
                DataTable dtPrincipalAC_Escolar = null;
                int Renglon;
                if (Session["dtPrincipalAC_Escolar"] == null)
                {

                    List<vw_Indicadores_Acciones> listaReportes_AC_Escolar = ctx.vw_Indicadores_Acciones.Where(RT => RT.programasID == 9).ToList();
                    dtPrincipalAC_Escolar = ConvertToDataTable(listaReportes_AC_Escolar);

                    for (Renglon = 0; Renglon < dtPrincipalAC_Escolar.Rows.Count; Renglon++)
                    {
                        XlworkSheetEscolar.Cells[Renglon + 11, 6].Value = dtPrincipalAC_Escolar.Rows[Renglon]["ENERO"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 7].Value = dtPrincipalAC_Escolar.Rows[Renglon]["FEBRERO"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 8].Value = dtPrincipalAC_Escolar.Rows[Renglon]["MARZO"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 9].Value = dtPrincipalAC_Escolar.Rows[Renglon]["ABRIL"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 10].Value = dtPrincipalAC_Escolar.Rows[Renglon]["MAYO"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 11].Value = dtPrincipalAC_Escolar.Rows[Renglon]["JUNIO"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 12].Value = dtPrincipalAC_Escolar.Rows[Renglon]["JULIO"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 13].Value = dtPrincipalAC_Escolar.Rows[Renglon]["AGOSTO"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 14].Value = dtPrincipalAC_Escolar.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 15].Value = dtPrincipalAC_Escolar.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 16].Value = dtPrincipalAC_Escolar.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetEscolar.Cells[Renglon + 11, 17].Value = dtPrincipalAC_Escolar.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }
        }
        private void LlenaHojaAC_Deporte(OfficeOpenXml.ExcelWorksheet XlworkSheetDeporte)
        {
            try
            {
                DataTable dtPrincipalAC_Deporte = null;
                int Renglon;
                if (Session["dtPrincipalAC_Deporte"] == null)
                {

                    List<vw_Indicadores_Acciones> listaReportes_AC_Deporte = ctx.vw_Indicadores_Acciones.Where(RT => RT.programasID == 12).ToList();
                    dtPrincipalAC_Deporte = ConvertToDataTable(listaReportes_AC_Deporte);

                    for (Renglon = 0; Renglon < dtPrincipalAC_Deporte.Rows.Count; Renglon++)
                    {
                        XlworkSheetDeporte.Cells[Renglon + 11, 6].Value = dtPrincipalAC_Deporte.Rows[Renglon]["ENERO"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 7].Value = dtPrincipalAC_Deporte.Rows[Renglon]["FEBRERO"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 8].Value = dtPrincipalAC_Deporte.Rows[Renglon]["MARZO"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 9].Value = dtPrincipalAC_Deporte.Rows[Renglon]["ABRIL"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 10].Value = dtPrincipalAC_Deporte.Rows[Renglon]["MAYO"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 11].Value = dtPrincipalAC_Deporte.Rows[Renglon]["JUNIO"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 12].Value = dtPrincipalAC_Deporte.Rows[Renglon]["JULIO"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 13].Value = dtPrincipalAC_Deporte.Rows[Renglon]["AGOSTO"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 14].Value = dtPrincipalAC_Deporte.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 15].Value = dtPrincipalAC_Deporte.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 16].Value = dtPrincipalAC_Deporte.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetDeporte.Cells[Renglon + 11, 17].Value = dtPrincipalAC_Deporte.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }
        }
        private void LlenaHojaAC_Genero(OfficeOpenXml.ExcelWorksheet XlworkSheetGenero)
        {
            try
            {
                DataTable dtPrincipalAC_Genero = null;
                int Renglon;
                if (Session["dtPrincipalAC_Genero"] == null)
                {

                    List<vw_Indicadores_Acciones> listaReportes_AC_Genero = ctx.vw_Indicadores_Acciones.Where(RT => RT.programasID == 10).ToList();
                    dtPrincipalAC_Genero = ConvertToDataTable(listaReportes_AC_Genero);

                    for (Renglon = 0; Renglon < dtPrincipalAC_Genero.Rows.Count; Renglon++)
                    {
                        XlworkSheetGenero.Cells[Renglon + 11, 6].Value = dtPrincipalAC_Genero.Rows[Renglon]["ENERO"];
                        XlworkSheetGenero.Cells[Renglon + 11, 7].Value = dtPrincipalAC_Genero.Rows[Renglon]["FEBRERO"];
                        XlworkSheetGenero.Cells[Renglon + 11, 8].Value = dtPrincipalAC_Genero.Rows[Renglon]["MARZO"];
                        XlworkSheetGenero.Cells[Renglon + 11, 9].Value = dtPrincipalAC_Genero.Rows[Renglon]["ABRIL"];
                        XlworkSheetGenero.Cells[Renglon + 11, 10].Value = dtPrincipalAC_Genero.Rows[Renglon]["MAYO"];
                        XlworkSheetGenero.Cells[Renglon + 11, 11].Value = dtPrincipalAC_Genero.Rows[Renglon]["JUNIO"];
                        XlworkSheetGenero.Cells[Renglon + 11, 12].Value = dtPrincipalAC_Genero.Rows[Renglon]["JULIO"];
                        XlworkSheetGenero.Cells[Renglon + 11, 13].Value = dtPrincipalAC_Genero.Rows[Renglon]["AGOSTO"];
                        XlworkSheetGenero.Cells[Renglon + 11, 14].Value = dtPrincipalAC_Genero.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetGenero.Cells[Renglon + 11, 15].Value = dtPrincipalAC_Genero.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetGenero.Cells[Renglon + 11, 16].Value = dtPrincipalAC_Genero.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetGenero.Cells[Renglon + 11, 17].Value = dtPrincipalAC_Genero.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }
        }
        private void LlenaHojaAC_Empresarial(OfficeOpenXml.ExcelWorksheet XlworkSheetEmpresarial)
        {
            try
            {
                DataTable dtPrincipalAC_Empre = null;
                int Renglon;
                if (Session["dtPrincipalAC_Empre"] == null)
                {

                    List<vw_Indicadores_Acciones> listaReportes_AC_Empre = ctx.vw_Indicadores_Acciones.Where(RT => RT.programasID == 13).ToList();
                    dtPrincipalAC_Empre = ConvertToDataTable(listaReportes_AC_Empre);

                    for (Renglon = 0; Renglon < dtPrincipalAC_Empre.Rows.Count; Renglon++)
                    {
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 6].Value = dtPrincipalAC_Empre.Rows[Renglon]["ENERO"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 7].Value = dtPrincipalAC_Empre.Rows[Renglon]["FEBRERO"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 8].Value = dtPrincipalAC_Empre.Rows[Renglon]["MARZO"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 9].Value = dtPrincipalAC_Empre.Rows[Renglon]["ABRIL"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 10].Value = dtPrincipalAC_Empre.Rows[Renglon]["MAYO"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 11].Value = dtPrincipalAC_Empre.Rows[Renglon]["JUNIO"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 12].Value = dtPrincipalAC_Empre.Rows[Renglon]["JULIO"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 13].Value = dtPrincipalAC_Empre.Rows[Renglon]["AGOSTO"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 14].Value = dtPrincipalAC_Empre.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 15].Value = dtPrincipalAC_Empre.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 16].Value = dtPrincipalAC_Empre.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetEmpresarial.Cells[Renglon + 11, 17].Value = dtPrincipalAC_Empre.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {
                //lblError.Text = exe.Message;
            }
        }
        private void LlenaHojaAC_Convenios(OfficeOpenXml.ExcelWorksheet XlworkSheetConvenios)
        {
            try
            {
                DataTable dtPrincipalAC_Emprecon = null;
                int Renglon;
                if (Session["dtPrincipalAC_Emprecon"] == null)
                {

                    List<vw_Indicadores_Acciones_Convenios> listaReportes_AC_Empre_Convenios = ctx.vw_Indicadores_Acciones_Convenios.Where(RT => RT.programasID == 13).ToList();
                    dtPrincipalAC_Emprecon = ConvertToDataTable(listaReportes_AC_Empre_Convenios);

                    for (Renglon = 0; Renglon < dtPrincipalAC_Emprecon.Rows.Count; Renglon++)
                    {
                        XlworkSheetConvenios.Cells[Renglon + 11, 6].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["ENERO"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 7].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["FEBRERO"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 8].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["MARZO"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 9].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["ABRIL"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 10].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["MAYO"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 11].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["JUNIO"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 12].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["JULIO"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 13].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["AGOSTO"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 14].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 15].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 16].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetConvenios.Cells[Renglon + 11, 17].Value = dtPrincipalAC_Emprecon.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {

            }
        }
        private void LlenaHojaAC_Inclusion(OfficeOpenXml.ExcelWorksheet XlworkSheetInclusion)
        {
            try
            {
                DataTable dtPrincipalAC_inclusion = null;
                int Renglon;
                if (Session["dtPrincipalAC_inclusion"] == null)
                {

                    List<vw_Indicadores_Acciones> listaReportes_AC_Inclu = ctx.vw_Indicadores_Acciones.Where(RT => RT.programasID == 7).ToList();
                    dtPrincipalAC_inclusion = ConvertToDataTable(listaReportes_AC_Inclu);

                    for (Renglon = 0; Renglon < dtPrincipalAC_inclusion.Rows.Count; Renglon++)
                    {
                        XlworkSheetInclusion.Cells[Renglon + 10, 5].Value = dtPrincipalAC_inclusion.Rows[Renglon]["ENERO"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 6].Value = dtPrincipalAC_inclusion.Rows[Renglon]["FEBRERO"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 7].Value = dtPrincipalAC_inclusion.Rows[Renglon]["MARZO"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 8].Value = dtPrincipalAC_inclusion.Rows[Renglon]["ABRIL"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 9].Value = dtPrincipalAC_inclusion.Rows[Renglon]["MAYO"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 10].Value = dtPrincipalAC_inclusion.Rows[Renglon]["JUNIO"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 11].Value = dtPrincipalAC_inclusion.Rows[Renglon]["JULIO"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 12].Value = dtPrincipalAC_inclusion.Rows[Renglon]["AGOSTO"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 13].Value = dtPrincipalAC_inclusion.Rows[Renglon]["SEPTIEMBRE"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 14].Value = dtPrincipalAC_inclusion.Rows[Renglon]["OCTUBRE"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 15].Value = dtPrincipalAC_inclusion.Rows[Renglon]["NOVIEMBRE"];
                        XlworkSheetInclusion.Cells[Renglon + 10, 16].Value = dtPrincipalAC_inclusion.Rows[Renglon]["DICIEMBRE"];

                    }
                }
            }
            catch (Exception exe)
            {

            }
        }

        #endregion

        protected void GvPCAdmin_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                foreach (TableCell tc in e.Row.Cells)
                {
                    if (tc.HasControls())
                    {
                        LinkButton lb = (LinkButton)tc.Controls[0];
                        if (lb != null)
                        {
                            Image icon = new Image();
                            icon.ImageUrl = "~/Imagenes/sort-" + (GvPCAdmin.SortDirection == SortDirection.Ascending ? "asc" : "desc") + ".png";
                            if (GvPCAdmin.SortExpression == lb.CommandArgument)
                            {
                                tc.Controls.Add(new LiteralControl(" "));
                                tc.Controls.Add(icon);
                            }
                        }
                    }
                }
            }
        }

        private void CargarProgramas()
        {
            try
            {
                var repo = new ProgramaRepository();

                ddlProgramas.DataSource = repo.ObtenerProgramas();
                ddlProgramas.DataTextField = "NombrePrograma";
                ddlProgramas.DataValueField = "programasID";
                ddlProgramas.DataBind();

                ddlProgramas.Items.Insert(0, new ListItem("-- Selecciona --", "0"));
            }

            catch (Exception ex)
            {

            }

        }
        private void CargarZonas()
        {
            try
            {
                var repo = new UbicacionRepository();

                ddlZona.DataSource = repo.ObtenerZonas();
                ddlZona.DataTextField = "zona";
                ddlZona.DataValueField = "idzona";
                ddlZona.DataBind();

                ddlZona.Items.Insert(0, new ListItem("-- Selecciona --", "0"));
            }

            catch (Exception ex)
            {

            }

        }

        private void CargarMunicipiosPorZona(int idZona)
        {
            try
            {
                var repo = new UbicacionRepository();

                ddlMunicipio.DataSource = repo.ObtenerMunicipiosByZona(idZona);
                ddlMunicipio.DataTextField = "MUNICIPIO";
                ddlMunicipio.DataValueField = "MunicipioID";
                ddlMunicipio.DataBind();

                ddlMunicipio.Items.Insert(0, new ListItem("-- Selecciona --", "0"));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        protected void CargarDatosReporte()
        {
            try
            {
                GvPCAdmin.DataSource = null;
                GvPCAdmin.DataBind();

                var filtros = ObtenerFiltrosReporte();

                var repository = new ReporteRepository();

                var datos = repository.ObtenerDatosReporte(
                    filtros.FechaInicial,
                    filtros.FechaFinal,
                    null,
                    filtros.Zona,
                    filtros.Programa,
                    null,
                    null,
                    filtros.Institucion);

                GvPCAdmin.DataSource = datos;
                GvPCAdmin.DataBind();

                lblTotalRegistros.Text =
                    $"Total de registros: {datos.Count}";
            }
            catch (Exception)
            {
                throw;
            }
        }


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

            int programa = Convert.ToInt32(ddlProgramas.SelectedValue);



            if (programa == 0)
            {
                var consulta = (from Item1 in ctx.tb_Reporte_Diario
                                join Item2 in ctx.tb_fotografia
                                on Item1.idResumenDiario equals Item2.idResumenDiario
                                join Item3 in ctx.Personales
                                on Item1.Personalid equals Item3.Personalid
                                where Item1.fecha >= fechainicial && Item1.fecha <= fechaFinal && Item3.Dependencia == "SSP DVI"
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

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int municipioId = int.Parse(ddlMunicipio.SelectedValue);

            if (municipioId > 0)
            {
                CargarLocalidades(municipioId);
            }
            else
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("-- Selecciona localidad --", "0"));
            }
        }
        private void CargarLocalidades(int municipioId)
        {
            try
            {
                var repo = new UbicacionRepository();

                var localidades = repo.ObtenerLocalidades(municipioId);

                ddlLocalidad.DataSource = localidades;
                ddlLocalidad.DataTextField = "Localidad";
                ddlLocalidad.DataValueField = "LocalidadID"; // o ID si tienes uno
                ddlLocalidad.DataBind();

                ddlLocalidad.Items.Insert(0, new ListItem("-- Selecciona localidad --", "0"));
            }

            catch (Exception)
            {
                //lblError.Text = "Error al cargar localidades";
                //lblError.Visible = true;
            }

        }
        protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int zonaId = int.Parse(ddlZona.SelectedValue);

            if (zonaId > 0)
            {
                CargarMunicipiosPorZona(zonaId);
            }
            else
            {
                ddlMunicipio.Items.Clear();
                ddlMunicipio.Items.Insert(0, new ListItem("-- Selecciona municipio --", "0"));

                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("-- Selecciona localidad --", "0"));
            }

        }

    }
}
    
    
#endregion


