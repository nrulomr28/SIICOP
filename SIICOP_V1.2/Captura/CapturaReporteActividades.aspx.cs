
using SIICOP_V1._2.Clases.Services;
using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Datos.Repositorio;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Captura
{
    public partial class CapturaReporteActividades : System.Web.UI.Page
    {
        int personalID;
        int nino;
        int nina;
        int padresH;
        int padresM;
        int TotalA;

        int? programasID = null;


        SIICOPEntities ctx = new SIICOPEntities();
        string sUsuarioActual;
        public enum AccionExpediente { Creacion, Edicion, Visualizacion }

        private readonly CatalogoService _catalogoService = new CatalogoService();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!UsuarioTieneAcceso())
            {
                RedirigirInicio();
                return;
            }

            if (!SesionValida())
            {
                Response.Redirect("~/MenuProgramas/SeleccionPrograma.aspx");
                return;
            }

            programasID = (int)Session["programasID"];

            ConfigurarPanelesPrograma();


            if (!IsPostBack)
            {
                InicializarPagina();
                CargarZonas();
                CargarMunicipios();
                CargarProgramas();

                string valor = Request.QueryString["ValorEntorno"];

                if (!string.IsNullOrEmpty(valor))
                {
                    int entornoId = Convert.ToInt32(valor);

                    if (entornoId == 1)
                    {
                        CargarEntorno(entornoId);
                        //CargarEje(entornoId);
                    }
                    else if (entornoId == 2)
                    {
                        CargarEntorno(entornoId);
                        //CargarEje(entornoId);
                    }
                }
                else
                {
                    Response.Redirect("Entorno.aspx");
                }

            }

            ConfigurarPaneles();

        }

        private void ConfigurarPanelesPrograma()
        {
            bool visible = programasID != 0;

            PanelCoordinacion.Visible = visible;
            PanelMunicipiosPrioritarios.Visible = visible;
            PanelRAVI.Visible = visible;
        }


        private bool UsuarioTieneAcceso()
        {
            var rolesPermitidos = new[] { "SYSADMIN", "Administrador", "Cap_RVCPZ", "Admin_RVCPZ" };
            return rolesPermitidos.Any(User.IsInRole);
        }

        private bool SesionValida()
        {
            return Session["programasID"] != null;
        }

        private void InicializarPagina()
        {
            lblPrograma.Text = string.Empty;
            MostrarPrograma(programasID);
            DeterminarAccion();
        }

        private void ConfigurarPaneles()
        {
            bool esEstrategia =
                Session["ImagenSeleccionada"] != null;

            PanelAccionImplentada.Visible =
                esEstrategia;

            PanelListados.Visible =
                !esEstrategia;
        }

        private void RedirigirInicio()
        {
            Response.Redirect("~/TotalAccionesBeneficiados.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void MostrarPrograma(int? programaId)
        {
            lblPrograma.Text =
                            _catalogoService.ObtenerNombrePrograma(programaId)
                            ?? string.Empty;

        }


        #region ***** DETERMINACION DE LA ACCIÓN DEL REPOTE YA SEA CREAR NUEVO O EDITAR Y LLENAR REPORTE
        protected void DeterminarAccion()
        {

            if (Session["idExpediente_Accion"] != null && Session["AccionExpediente"] != null)
            {
                AccionExpediente accion = (AccionExpediente)Session["AccionExpediente"];
                switch ((int)accion)
                {
                    case (int)AccionExpediente.Creacion:
                        if (!User.IsInRole("SysAdmin") && !User.IsInRole("Foraneo") && !User.IsInRole("Cap_RVCPZ") && !User.IsInRole("Admin_RVCPZ"))
                        {
                            Response.Redirect("~/VistasReportes/vista_Redes_Veracruzanas_en_la_Construccion_de_la_Paz.aspx");
                        }
                        break;
                    case (int)AccionExpediente.Edicion:
                        // ddlDelegacion.DataBind();
                        ddlMuNICIPIO.DataBind();
                        ddlsubprograma.DataBind();
                        //   expediente_Edicion_Visualizacion();
                        break;
                        //case (int)AccionExpediente.Visualizacion:
                        //    expediente_Edicion_Visualizacion();
                        //    break;
                }
            }
            else
            {
                sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                txtResponsable.Text = a.Nombre + " " + a.paterno + " " + a.materno;
                txtArea.Text = a.AreaTrabajo;
                lnkbtnGuardar.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('CREACIÓN DE UN NUEVO REPORTE')", true);
                return;


            }
            Session["idExpediente_Accion"] = null;
        }



        #endregion

        #region ****** SELECT DATABOUND PARA LOS DDL
        #region**** ACCIONES DE LOS DROP PARA PONER LEYENDA DE SeleccioneR



        #endregion
        protected void ddlAmbito_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ambitos();
        }

        protected void Ambitos()
        {
            int entornoId = Convert.ToInt32(ddlAmbito.SelectedValue);

            if (entornoId > 0)
            {
                CargarEje(entornoId);
            }
            else
            {
                ddlEje.Items.Clear();
                ddlEje.Items.Insert(0, new ListItem("-- Seleccione localidad --", "0"));
            }

            if (entornoId == 2)
            {
                PanelEscuela.Visible = true;

            }
            else
            {
                PanelEscuela.Visible = false;
            }

        }


        #endregion


        #region BOTON PARA SALIR DEL REPORTE
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            this.Session["idExpediente_Accion"] = (object)null;
            this.Session["AccionExpediente"] = (object)null;
            this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
            this.HiddenField1cn.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }
        #endregion

        #region *** BOTON PARA GUARDAR LA ACTIVIDAD

        protected void lnkbtnGuardar_Click(
    object sender,
    EventArgs e)
        {
            programasID = Session["programasID"] as int?;

            string errores;

            if (!ValidarFormulario(out errores))
            {
                MostrarErrores(errores);
                return;
            }

            GuardarReporte();
        }

        private void GuardarReporte()
        {
            ReiniciarBeneficiarios();

            string fileName = "";
            string contentType = "";

            var usuario = ObtenerUsuarioActual();

            personalID = usuario.Personalid;

            string coordinacion =
                ObtenerCoordinacion(
                    Convert.ToInt32(usuario.cat_areaidarea));

            try
            {
                Guid idResumen = Guid.NewGuid();

                Session["idresumen"] = idResumen;

                var reporte =
                    CrearReporteDiario(
                        idResumen,
                        coordinacion);

                var direccion =
                    CrearDireccionReporte(
                        idResumen);

                var datosGenerales =
                    CrearDatosGenerales(
                        idResumen);

                ctx.tb_Reporte_Diario.Add(reporte);
                ctx.tb_DireccionReporte.Add(direccion);
                ctx.TB_DatosGralReporte.Add(datosGenerales);

                RegistrarAuditoria(idResumen);

                string extension =
                    GuardarFotografias(
                        idResumen,
                        ref fileName,
                        ref contentType);

                ctx.SaveChanges();

                string claveF = "RVCPZ-DVI";

                var folio =
                    ctx.sp_folio_actividad(
                        idResumen,
                        claveF,
                        extension)
                    .ToString();

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "openGuardadoExito",
                    "openGuardadoExito();",
                    true);

                Session["actividades_fuera_tiempo"] = null;
                Session["ImagenSeleccionada"] = null;
                Session["programasID"] = null;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "alertMessage",
                    "alert('ERROR AL GUARDAR EL REGISTRO')",
                    true);
            }
        }

        private tb_Reporte_Diario CrearReporteDiario(
    Guid idResumen,
    string coordinacion)
        {
            var reporte =
                new tb_Reporte_Diario();

            reporte.idResumenDiario = idResumen;
            reporte.Personalid = personalID;
            reporte.fechacaptura = DateTime.Now;
            reporte.fecha = Convert.ToDateTime(txtFecha.Text);

            reporte.coordinador =
                string.IsNullOrWhiteSpace(txtCoordinador.Text)
                    ? ""
                    : txtCoordinador.Text.Trim();

            reporte.idzona =
                int.TryParse(
                    ddlZona.SelectedValue,
                    out var zona)
                    ? zona
                    : (int?)null;

            reporte.idcoordinacion =
                int.TryParse(
                    ddlCoordinacion.SelectedValue,
                    out var coordinacionId)
                    ? coordinacionId
                    : (int?)null;

            reporte.programasID = programasID;

            reporte.subprogramaId =
                string.IsNullOrEmpty(
                    ddlsubprograma.SelectedValue)
                    ? 0
                    : Convert.ToInt32(
                        ddlsubprograma.SelectedValue);

            reporte.AccionesID =
                string.IsNullOrEmpty(
                    ddlAcciones.SelectedValue)
                    ? 0
                    : Convert.ToInt32(
                        ddlAcciones.SelectedValue);

            reporte.accion_implementada =
                txtAccionImplementada.Text
                    .ToUpper();

            reporte.descripcion_actividad =
                txtDescripcionActividad.Text
                    .ToUpper();

            reporte.personal_atendio_actividad =
                txtpersonal_atendio_actividad.Text
                    .ToUpper();

            reporte.seguimiento =
                txtSeguimiento.Text
                    .ToUpper();

            CalcularBeneficiarios();

            reporte.TotalHombresAtendidos =
                nino + padresH;

            reporte.TotalMujeresAtendidas =
                nina + padresM;

            reporte.total_atendidos =
                reporte.TotalHombresAtendidos +
                reporte.TotalMujeresAtendidas;

            reporte.capturaAPP = "NO";
            reporte.DelegacionOcoonurbacion =
                coordinacion;

            return reporte;
        }

        private tb_DireccionReporte CrearDireccionReporte(
    Guid idResumen)
        {
            return new tb_DireccionReporte
            {
                idResumenDiario = idResumen,

                Latitud = lati.Value,
                Longitud = longi.Value,

                calle = route.Value ?? "",
                coloni = colony.Value ?? "",

                MunicipioID =
                    Convert.ToInt32(
                        ddlMuNICIPIO.SelectedValue),

                LocalidadID =
                    Convert.ToInt32(
                        ddlLocalidad.SelectedValue),

                mpio_prioritario =
                    ddlMunicipioPrioritario.SelectedValue == "1",

                mpio_homicidio =
                    ddlMunicipioHomicidio.SelectedValue == "1",

                col_prioritario =
                    ddlColoniaPrioritaria.SelectedValue == "1",

                mpio_indigena =
                    ddlMunicipioIndigena.SelectedValue == "1",

                programa_istmo =
                    ddlProgramaIstmo.SelectedValue == "1"
            };
        }

        private TB_DatosGralReporte CrearDatosGenerales(
    Guid idResumen)
        {
            return new TB_DatosGralReporte
            {
                idResumenDiario = idResumen,

                NombreLugar_Escuela =
                    ddlnombreescuela.SelectedValue,

                NombreContacto =
                    txtnombrecontacto.Text.ToUpper(),

                telcel = txtTelefono.Text,

                ClavePlantel =
                    txtclave.Text.ToUpper(),

                Nivel =
                    ddlNivel.SelectedValue,

                Ambito =
                    Convert.ToInt32(
                        ddlAmbito.SelectedValue),

                EjeId =
                    Convert.ToInt32(
                        ddlEje.SelectedValue),

                niñas =
                    string.IsNullOrEmpty(txnina.Value)
                        ? 0
                        : Convert.ToInt32(txnina.Value),

                niños =
                    string.IsNullOrEmpty(txnino.Value)
                        ? 0
                        : Convert.ToInt32(txnino.Value),

                hombres =
                    string.IsNullOrEmpty(txhombres.Value)
                        ? 0
                        : Convert.ToInt32(txhombres.Value),

                mujeres =
                    string.IsNullOrEmpty(txmujeres.Value)
                        ? 0
                        : Convert.ToInt32(txmujeres.Value),

                plantel_diagnosticado =
                    ddlPlantelDiagnosticado.SelectedValue == "1",

                inst_participantes =
                    txtInstitucionesParticipantes.Text.ToUpper(),

                tema_impartido =
                    txtTemaImpartido.Text.ToUpper(),

                casos_ravi =
                    ddlCasosRavi.SelectedValue == "1",

                nocasos_ravi =
                    string.IsNullOrEmpty(txtNoCasosRavi.Text)
                        ? 0
                        : Convert.ToInt32(txtNoCasosRavi.Text),

                dirigido =
                    txtDirigidoA.Text.ToUpper(),

                giro_comercios =
                    txtGiroComercio.Text.ToUpper(),

                no_acciones_dgpvi =
                    int.TryParse(
                        ddlNoaccionesDGPVI.SelectedValue,
                        out var dgpvi)
                        ? dgpvi
                        : (int?)null,

                no_acciones_institucionales =
                    int.TryParse(
                        ddlNoAccionesInstitucionales.SelectedValue,
                        out var institucionales)
                        ? institucionales
                        : (int?)null,

                total_acciones_ravi =
                    string.IsNullOrEmpty(
                        txtTotalAccionesRAVI.Text)
                        ? (int?)null
                        : Convert.ToInt32(
                            txtTotalAccionesRAVI.Text),

                ofrecieron_segurichat =
                    ddlOfrecioSegurichat.SelectedValue == "1",

                segurichat =
                    txtSegurichat.Text.ToUpper()
            };
        }

        private void CalcularBeneficiarios()
        {
            if (!string.IsNullOrEmpty(txnina.Value))
                nina = int.Parse(txnina.Value);

            if (!string.IsNullOrEmpty(txnino.Value))
                nino = int.Parse(txnino.Value);

            if (!string.IsNullOrEmpty(txhombres.Value))
                padresH = int.Parse(txhombres.Value);

            if (!string.IsNullOrEmpty(txmujeres.Value))
                padresM = int.Parse(txmujeres.Value);

            TotalA =
                (nino + padresH) +
                (nina + padresM);
        }


        private void RegistrarAuditoria(
    Guid idResumen)
        {
            tbAuditoria audit =
                new tbAuditoria()
                {
                    auditoriaGuid =
                        Guid.NewGuid(),

                    fecha =
                        DateTime.Now,

                    area =
                        txtArea.Text,

                    idTipomodificacion = 1,

                    PagModificacion =
                        Page.Title,

                    Descripcion =
                        "Nuevo registro de nuevas capturas",

                    usuario =
                        txtResponsable.Text,

                    IdABC =
                        idResumen.ToString()
                };

            ctx.tbAuditoria.Add(audit);
        }

        private string GuardarFotografias(
    Guid idResumen,
    ref string fileName,
    ref string contentType)
        {
            string extension = "";

            if (!file.HasFile)
                return extension;

            foreach (HttpPostedFile postedFile in file.PostedFiles)
            {
                fileName =
                    Path.GetFileName(
                        postedFile.FileName);

                contentType =
                    postedFile.ContentType;

                extension =
                    Path.GetExtension(
                        postedFile.FileName);

                using (Stream fs =
                    postedFile.InputStream)
                {
                    using (BinaryReader br =
                        new BinaryReader(fs))
                    {
                        byte[] bytes =
                            br.ReadBytes(
                                (int)fs.Length);

                        string base64String =
                            Convert.ToBase64String(
                                bytes);

                        tb_fotografia foto =
                            new tb_fotografia()
                            {
                                contentType =
                                    contentType,

                                ImagenSubida =
                                    DateTime.Now,

                                FileName =
                                    fileName,

                                ImgBase64 =
                                    base64String,

                                ImagenExtencion =
                                    extension,

                                idResumenDiario =
                                    idResumen
                            };

                        ctx.tb_fotografia.Add(
                            foto);
                    }
                }
            }

            return extension;
        }

        private bool ValidarFormulario(out string mensaje)
        {
            bool valido = true;
            string textoValidacion = "<ul>";

            int tamanoTotalArchivos = 0;

            bool actividadFueraDeFecha =
                Convert.ToBoolean(
                    Session["actividades_fuera_tiempo"]);

            if (file.HasFile)
            {
                var validadorImagenes =
                    new Validaciones.Imagenes();

                foreach (HttpPostedFile archivo in file.PostedFiles)
                {
                    string nombreArchivo =
                        archivo.FileName;

                    if (!validadorImagenes
                            .ValidateVideoExtension(
                                nombreArchivo))
                    {
                        textoValidacion +=
                            "<li>Solo permite subir imágenes en formato PNG o JPG</li>";

                        valido = false;
                    }

                    tamanoTotalArchivos +=
                        archivo.ContentLength;
                }

                if (tamanoTotalArchivos >= 3000000)
                {
                    textoValidacion +=
                        "<li>El tamaño máximo permitido por archivo es de 3 MB</li>";

                    valido = false;
                }
            }
            else
            {
                textoValidacion +=
                    "<li>Es obligatorio subir al menos una imagen</li>";

                valido = false;
            }

            if (actividadFueraDeFecha)
            {
                textoValidacion +=
                    "<li>La actividad está fuera de tiempo. Debe registrarse dentro del mes en curso</li>";

                txtFecha.Focus();
                txtFecha.BorderColor =
                    System.Drawing.Color.Red;

                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                textoValidacion +=
                    "<li>Es obligatorio capturar la fecha del reporte</li>";

                txtFecha.Focus();
                txtFecha.BorderColor =
                    System.Drawing.Color.Red;

                valido = false;
            }

            if (string.IsNullOrWhiteSpace(lati.Value) ||
                string.IsNullOrWhiteSpace(longi.Value))
            {
                textoValidacion +=
                    "<li>Debe capturar una dirección válida con coordenadas geográficas</li>";

                valido = false;
            }

            if (ddlMuNICIPIO.SelectedIndex == 0 ||
                string.IsNullOrWhiteSpace(
                    ddlMuNICIPIO.SelectedValue))
            {
                textoValidacion +=
                    "<li>Es obligatorio seleccionar un municipio</li>";

                valido = false;
            }

            if (ddlLocalidad.SelectedIndex == 0 ||
                string.IsNullOrWhiteSpace(
                    ddlLocalidad.SelectedValue))
            {
                textoValidacion +=
                    "<li>Es obligatorio seleccionar una localidad</li>";

                valido = false;
            }

            if (string.IsNullOrWhiteSpace(
                    txtnombrecontacto.Text))
            {
                textoValidacion +=
                    "<li>Es obligatorio ingresar el nombre del contacto</li>";

                valido = false;
            }

            if (string.IsNullOrWhiteSpace(
                    txtTelefono.Text))
            {
                textoValidacion +=
                    "<li>Es obligatorio ingresar el teléfono de contacto</li>";

                valido = false;
            }

            if (string.IsNullOrWhiteSpace(
                    txtDescripcionActividad.Text))
            {
                textoValidacion +=
                    "<li>Es obligatorio ingresar la descripción de la actividad</li>";

                valido = false;
            }

            if (string.IsNullOrWhiteSpace(
                    txtatendiosH.Text) ||
                string.IsNullOrWhiteSpace(
                    txtatendiosM.Text))
            {
                textoValidacion +=
                    "<li>Es obligatorio capturar los beneficiarios</li>";

                valido = false;
            }

            if (!valido)
            {
                textoValidacion += "</ul>";
            }

            mensaje = textoValidacion;

            return valido;
        }


        private void MostrarErrores(string mensaje)
        {
            lblValidacionesTxt.Text = mensaje;

            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "openModalvalidador",
                "openModalvalidador();",
                true);

            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "sumar",
                "sumar();",
                true);
        }

        private Personales ObtenerUsuarioActual()
        {
            string usuarioActual =
                System.Web.Security
                    .Membership
                    .GetUser()
                    .UserName;

            return ctx.Personales
                      .FirstOrDefault(x =>
                            x.login == usuarioActual);
        }

        private string ObtenerCoordinacion(int area)
        {
            switch (area)
            {
                case 1022:
                case 7:
                case 4:
                case 6:
                case 8:
                case 5:
                case 3:
                case 1023:
                case 1025:
                    return "CONURBACION XALAPA XX";

                case 1020:
                    return "CONURBACION VERACRUZ XXIII";

                case 1012:
                    return "CONURBACION POZA RICA";

                case 1011:
                    return "COORDINACION CORDOBA";

                case 1009:
                    return "COORDINACION COATZACOALCOS";

                default:
                    return "ENLACES";
            }
        }


        #endregion

        #region redimensionar_Imagen
        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image ImagenOriginal, int Alto)

        {
            var Radio = (double)Alto / ImagenOriginal.Height;
            var nuevoAncho = (int)(ImagenOriginal.Width * Radio);
            var NuevoAlto = (int)(ImagenOriginal.Height * Radio);
            var NuevaImagenRedimencionada = new Bitmap(nuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaImagenRedimencionada);
            g.DrawImage(ImagenOriginal, 0, 0, nuevoAncho, NuevoAlto);
            return NuevaImagenRedimencionada;

        }

        #endregion

        #region *** BOTON PARA EDITAR ACTIVIDAD
        protected void btnGuardarEdicion_Click(
    object sender,
    EventArgs e)
        {
            Guid idExpediente =
                Guid.Parse(
                    HiddenField1cn.Value);

            string fileName = "";
            string contentType = "";

            nino = 0;
            nina = 0;
            padresH = 0;
            padresM = 0;
            TotalA = 0;

            int MODE = 0;

            try
            {
                MODE =
                    ActualizarReporteDiario(
                        idExpediente,
                        MODE);

                var direccionReporte =
                    ActualizarDireccionReporte(
                        idExpediente);

                MODE =
                    ActualizarDatosGenerales(
                        idExpediente,
                        MODE,
                        direccionReporte);

                string extension =
                    GuardarFotografiasEdicion(
                        idExpediente,
                        ref fileName,
                        ref contentType);

                ctx.SaveChanges();

                string claveF = "RVCPZ-DVI";

                ctx.sp_folio_actividad(
                    idExpediente,
                    claveF,
                    extension);

                RegistrarAuditoriaEdicion(
                    idExpediente);

                ctx.SaveChanges();

                FinalizarEdicion();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.ToString());

                ScriptManager.RegisterClientScriptBlock(
                    this,
                    GetType(),
                    "alertMessage",
                    "alert('¡Error al guardar los datos!')",
                    true);
            }
        }
        private void ReiniciarBeneficiarios()
        {
            nino = 0;
            nina = 0;
            padresH = 0;
            padresM = 0;
            TotalA = 0;
        }

        private void RegistrarAuditoriaEdicion(
    Guid idExpediente)
        {
            var auditoria =
                new tbAuditoria
                {
                    auditoriaGuid =
                        Guid.NewGuid(),

                    fecha =
                        DateTime.Now,

                    area =
                        txtArea.Text,

                    idTipomodificacion = 2,

                    PagModificacion =
                        Page.Title,

                    Descripcion =
                        "Se editó el registro de reporte de actividades",

                    usuario =
                        txtResponsable.Text,

                    IdABC =
                        idExpediente.ToString()
                };

            ctx.tbAuditoria.Add(
                auditoria);
        }

        private void FinalizarEdicion()
        {
            HiddenField1cn.Value = null;

            btnGuardarEdicion.Visible =
                false;

            btnSalir.Visible =
                false;

            Session["idExpediente_Accion"] =
                null;

            Session["AccionExpediente"] =
                null;

            ScriptManager.RegisterStartupScript(
                this,
                GetType(),
                "redirect",
                "alert('DATOS GUARDADOS CON EXITO'); window.location='" +
                Request.ApplicationPath +
                "TotalAccionesBeneficiados.aspx';",
                true);
        }

        private string GuardarFotografiasEdicion(Guid idExpediente, ref string fileName, ref string contentType)
        {
            //// SUBIR LAS FOTOS A LA BD 
            string extencion = "";
            if (this.file.HasFile)
            {
                foreach (HttpPostedFile postedFile in file.PostedFiles)
                {
                    fileName = Path.GetFileName(postedFile.FileName);
                    contentType = postedFile.ContentType;
                    extencion = System.IO.Path.GetExtension(postedFile.FileName);
                    using (Stream fs = postedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            string base64String = Convert.ToBase64String(bytes);
                            {
                                tb_fotografia foto = new tb_fotografia()
                                {
                                    contentType = contentType,
                                    ImagenSubida = new DateTime?(DateTime.Now),
                                    FileName = fileName,
                                    ImgBase64 = base64String,
                                    ImagenExtencion = extencion
                                };
                                foto.idResumenDiario = idExpediente;
                                ctx.tb_fotografia.Add(foto);
                            }


                        }
                    }
                }
            }

            return extencion;
        }

        private int ActualizarDatosGenerales(Guid idExpediente, int MODE, tb_DireccionReporte direccionReporte)
        {
            ////  GUARDAR LOS DATOS GENERALES DEL REPORTE 
            TB_DatosGralReporte datosGralReporte = ctx.TB_DatosGralReporte.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
            if (datosGralReporte != null)
            {
                MODE = Convert.ToInt32(ddlAmbito.SelectedValue);
                datosGralReporte.NombreLugar_Escuela = this.ddlnombreescuela.Text == string.Empty ? "" : this.ddlnombreescuela.Text.ToUpper();
                datosGralReporte.NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper();
                datosGralReporte.telcel = this.txtTelefono.Text;
                datosGralReporte.ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper();
                direccionReporte.MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue));
                //  datosGralReporte.Nivel = this.ddlNivel.Text == string.Empty ? "" : this.ddlNivel.Text;

                datosGralReporte.Ambito = MODE;
                datosGralReporte.niñas = new int?(this.txnina.Value == "" ? 0 : Convert.ToInt32(this.txnina.Value));
                datosGralReporte.niños = new int?(this.txnino.Value == "" ? 0 : Convert.ToInt32(this.txnino.Value));
                datosGralReporte.hombres = new int?(this.txhombres.Value == "" ? 0 : Convert.ToInt32(this.txhombres.Value));
                datosGralReporte.mujeres = new int?(this.txmujeres.Value == "" ? 0 : Convert.ToInt32(this.txmujeres.Value));
            }
            else
            {

                TB_DatosGralReporte nuevoDatosGral = new TB_DatosGralReporte();
                nuevoDatosGral.idResumenDiario = new Guid?(idExpediente);
                nuevoDatosGral.NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper();
                nuevoDatosGral.telcel = this.txtTelefono.Text;
                nuevoDatosGral.ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper();

                nuevoDatosGral.Ambito = Convert.ToInt32(ddlAmbito.SelectedValue);
                nuevoDatosGral.EjeId = Convert.ToInt32(ddlEje.SelectedValue);
                nuevoDatosGral.niñas = new int?(this.txnina.Value == "" ? 0 : Convert.ToInt32(this.txnina.Value));
                nuevoDatosGral.niños = new int?(this.txnino.Value == "" ? 0 : Convert.ToInt32(this.txnino.Value));
                nuevoDatosGral.hombres = new int?(this.txhombres.Value == "" ? 0 : Convert.ToInt32(this.txhombres.Value));
                nuevoDatosGral.mujeres = new int?(this.txmujeres.Value == "" ? 0 : Convert.ToInt32(this.txmujeres.Value));
                ctx.TB_DatosGralReporte.Add(nuevoDatosGral);

            }

            return MODE;
        }

        private tb_DireccionReporte ActualizarDireccionReporte(Guid idExpediente)
        {
            /// GUARDAR LOS DATOS DE GOOGLE 
            tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
            if (direccionReporte != null)
            {
                direccionReporte.Latitud = this.lati.Value;
                direccionReporte.Longitud = this.longi.Value;
                direccionReporte.calle = this.route.Value == string.Empty ? "" : this.route.Value;
                direccionReporte.coloni = this.colony.Value == string.Empty ? "" : this.colony.Value;
                direccionReporte.MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue));
                direccionReporte.LocalidadID = new int?(this.ddlLocalidad.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlLocalidad.SelectedValue));
            }
            else
                ctx.tb_DireccionReporte.Add(new tb_DireccionReporte()
                {
                    idResumenDiario = new Guid?(idExpediente),
                    Latitud = this.lati.Value,
                    Longitud = this.longi.Value,
                    calle = this.route.Value == string.Empty ? "" : this.route.Value,
                    coloni = this.colony.Value == string.Empty ? "" : this.colony.Value,
                    MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                    LocalidadID = new int?(this.ddlLocalidad.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                });
            return direccionReporte;
        }

        private int ActualizarReporteDiario(Guid idExpediente, int MODE)
        {
            tb_Reporte_Diario tbReporteDiario = ctx.tb_Reporte_Diario.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
            if (tbReporteDiario != null)
            {
                tbReporteDiario.descripcion_actividad = this.txtDescripcionActividad.Text == string.Empty ? "" : this.txtDescripcionActividad.Text.ToUpper();
                tbReporteDiario.personal_atendio_actividad = this.txtpersonal_atendio_actividad.Text == string.Empty ? "" : this.txtpersonal_atendio_actividad.Text.ToUpper();
                tbReporteDiario.seguimiento = this.txtSeguimiento.Text == string.Empty ? "" : this.txtSeguimiento.Text.ToUpper();
                tbReporteDiario.AccionesID = new int?(this.ddlAcciones.SelectedValue == "null" ? 0 : Convert.ToInt32(this.ddlAcciones.SelectedValue));
                tbReporteDiario.fecha = new DateTime?(Convert.ToDateTime(this.txtFecha.Text));
                tbReporteDiario.subprogramaId = new int?(this.ddlsubprograma.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlsubprograma.SelectedValue));
                MODE = Convert.ToInt32(ddlAmbito.SelectedValue);

                int Hombres = 0;
                int Mujeres = 0;
                if (MODE == 1)
                {

                    if (this.txnina.Value != "")
                        nina = int.Parse(this.txnina.Value, (IFormatProvider)CultureInfo.InvariantCulture);


                    Hombres = nino + padresH;
                    Mujeres = nina + padresM;
                    // TotalAtendidos = Hombres + Mujeres; 
                }


                tbReporteDiario.TotalHombresAtendidos = new int?(Hombres);
                tbReporteDiario.TotalMujeresAtendidas = new int?(Mujeres);
                tbReporteDiario.total_atendidos = new int?(this.txtatendiosH.Text == string.Empty ? 0 : Convert.ToInt32(this.txtatendiosH.Text));
                tbReporteDiario.fechacaptura = new DateTime?(DateTime.Now);
            }

            return MODE;
        }

        #endregion


        #region ### pasos finales boton de guardado exitoso y generador de folio
        protected void lkbtSalirReporte_Click(object sender, EventArgs e)
        {
            Guid id = Guid.Parse(Session["idresumen"].ToString());
            ScriptManager.RegisterStartupScript(this, GetType(), "openFolio", "openFolio();", true);

            tb_Reporte_Diario fo = ctx.tb_Reporte_Diario.Where(a => a.idResumenDiario == id).FirstOrDefault();
            spnfolioo.InnerText = fo.FolioActividad;
            Session["idresumen"] = null;
        }

        protected void btnaceptar_Click(object sender, EventArgs e)

        {
            this.Session["idExpediente_Accion"] = (object)null;
            this.Session["AccionExpediente"] = (object)null;
            this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
            this.HiddenField1cn.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }


        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador"))
            {
                Session["actividades_fuera_tiempo"] = false;
            }
            else
            {
                string fecha = txtFecha.Text;
                string[] commandArgs = fecha.ToString().Split(new char[] { '/' });
                int diaActividad = Convert.ToInt32(commandArgs[0]);
                int mesActividad = Convert.ToInt32(commandArgs[1]);
                int anoacti = Convert.ToInt32(commandArgs[2]);

                int mes_actual = DateTime.Now.Month;
                int dia = DateTime.Now.Day;
                int ano = DateTime.Now.Year;
                if (mesActividad < mes_actual)

                {
                    if (dia <= 4)
                    {
                        lnkbtnGuardar.Visible = true;
                        Session["actividades_fuera_tiempo"] = false;

                    }
                    else
                    {

                        Session["actividades_fuera_tiempo"] = true;
                    }
                }
                else
                {
                    if (ano == anoacti)
                    {
                        lnkbtnGuardar.Visible = true;
                        Session["actividades_fuera_tiempo"] = false;
                    }
                    else
                    {
                        Session["actividades_fuera_tiempo"] = true;
                    }


                }
            }
        }
        #endregion


        private void CargarProgramas()
        {
            try
            {
                var repo = new ProgramaRepository();

                ddlsubprograma.DataSource = repo.ObtenerSubPrograma(programasID);
                ddlsubprograma.DataTextField = "NombreSubPrograma";   // campo que se muestra
                ddlsubprograma.DataValueField = "subprogramaId";      // campo valor
                ddlsubprograma.DataBind();

                ddlsubprograma.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }

            catch (Exception ex)
            {
                // Mostrar mensaje amigable
                lblError.Text = "Ocurrió un error al cargar municipios";
                lblError.Visible = true;

                // (opcional) log
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        private void CargarSubProgramas()
        {
            try
            {
                var repo = new ProgramaRepository();

                ddlsubprograma.DataSource = repo.ObtenerSubPrograma(programasID);
                ddlsubprograma.DataTextField = "NombreSubPrograma";   // campo que se muestra
                ddlsubprograma.DataValueField = "subprogramaId";      // campo valor
                ddlsubprograma.DataBind();

                ddlsubprograma.Items.Insert(0, new ListItem("-- Seleccione --", "0"));



                ddlAcciones.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                ddlSubAcciones.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }

            catch (Exception ex)
            {
                // Mostrar mensaje amigable
                //lblError.Text = "Ocurrió un error al cargar municipios";
                //lblError.Visible = true;

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }




        private void CargarAcciones(int subprogramaId)
        {
            try
            {
                var repo = new ProgramaRepository();


                ddlAcciones.Items.Clear();
                ddlSubAcciones.Items.Clear();

                ddlAcciones.DataSource = repo.ObtenerAcciones(subprogramaId);
                ddlAcciones.DataTextField = "AccionesNombre";   // campo que se muestra
                ddlAcciones.DataValueField = "AccionesID";      // campo valor
                ddlAcciones.DataBind();

                ddlAcciones.Items.Insert(0, new ListItem("-- Seleccione --", "0"));


            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }


        private void CargarSubaccion(int accionId)
        {
            try
            {
                var repo = new ProgramaRepository();

                ddlSubAcciones.DataSource = repo.ObtenerSubacciones(accionId);
                ddlSubAcciones.DataTextField = "SubAccion";   // campo que se muestra
                ddlSubAcciones.DataValueField = "SubAccionesId";      // campo valor
                ddlSubAcciones.DataBind();

                ddlSubAcciones.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }


        private void CargarMunicipios()
        {
            try
            {
                var repo = new UbicacionRepository();

                ddlMuNICIPIO.DataSource = repo.ObtenerMunicipios();
                ddlMuNICIPIO.DataTextField = "MUNICIPIO";   // campo que se muestra
                ddlMuNICIPIO.DataValueField = "MunicipioID";      // campo valor
                ddlMuNICIPIO.DataBind();

                ddlMuNICIPIO.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }
            catch (Exception ex)
            {                
                System.Diagnostics.Debug.WriteLine(ex.Message);
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

                ddlZona.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }

            catch (Exception ex)
            {

            }

        }


        protected void ddlMunicipio_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            int municipioId =
                int.Parse(
                    ddlMuNICIPIO.SelectedValue);

            if (municipioId > 0)
            {
                CargarLocalidades(
                    municipioId);
            }
            else
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(
                    0,
                    new ListItem(
                        "-- Seleccione localidad --",
                        "0"));
            }

            MostrarMunicipiosPrioridad(
                municipioId);

            MostrarPoblacionIndigena(
                municipioId);

            MostrarProgramaISTMO(
                municipioId);

            MostrarColoniasPrioridad(
                municipioId);
        }

        protected void MostrarMunicipiosPrioridad(
    int municipioId)
        {
            var repo = new UbicacionRepository();

            AsignarValorBooleano(
                ddlMunicipioPrioritario,
                repo.ObtenerMunicipiosPrioridad(
                    municipioId));
        }


        private void AsignarValorBooleano(
    DropDownList ddl,
    bool? valor)
        {
            if (valor == true)
                ddl.SelectedValue = "True";
            else if (valor == false)
                ddl.SelectedValue = "False";
            else
                ddl.SelectedValue = "-1";
        }

        protected void MostrarPoblacionIndigena(
    int municipioId)
        {
            var repo = new UbicacionRepository();

            AsignarValorBooleano(
                ddlMunicipioIndigena,
                repo.ObtenerPoblacionIndigena(
                    municipioId));
        }

        protected void MostrarProgramaISTMO(
            int municipioId)
        {
            var repo = new UbicacionRepository();

            AsignarValorBooleano(
                ddlProgramaIstmo,
                repo.ObtenerProgramaISTMO(
                    municipioId));
        }


        protected void MostrarColoniasPrioridad(
    int municipioId)
        {
            var repo = new UbicacionRepository();

            AsignarValorBooleano(
                ddlColoniaPrioritaria,
                repo.ObtenerColoniasPrioridad(
                    municipioId));
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

                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione localidad --", "0"));
            }

            catch (Exception)
            {
                lblError.Text = "Error al cargar localidades";
                lblError.Visible = true;
            }

        }



        protected void ddlsubprograma_SelectedIndexChanged(object sender, EventArgs e)
        {

            int subprogramaId = int.Parse(ddlsubprograma.SelectedValue);

            if (subprogramaId > 0)
            {
                CargarAcciones(subprogramaId);
            }
            else
            {
                ddlAcciones.Items.Clear();
                ddlAcciones.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                ddlSubAcciones.Items.Clear();
                ddlSubAcciones.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }


        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int accionId = int.Parse(ddlAcciones.SelectedValue);

            if (accionId > 0)
            {
                CargarSubaccion(accionId);
            }
            else
            {
                ddlSubAcciones.Items.Clear();
                ddlSubAcciones.Items.Insert(0, new ListItem("-- Seleccione  --", "0"));
            }

        }



        protected void ddlZona_SelectedIndexChanged(object sender, EventArgs e)
        {

            int zonaId = int.Parse(ddlZona.SelectedValue);

            if (zonaId > 0)
            {
                CargarCoordinacionesPorZona(zonaId);
            }            
        }


        private void CargarCoordinacionesPorZona(int idZona)
        {
            try
            {
                var repo = new UbicacionRepository();

                ddlCoordinacion.DataSource = repo.ObtenerCoordinacionByZona(idZona);
                ddlCoordinacion.DataTextField = "coordinacion";
                ddlCoordinacion.DataValueField = "idcoordinacion";
                ddlCoordinacion.DataBind();

                ddlCoordinacion.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        protected void ddlCasosRavi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCasosRavi.SelectedValue == "1")
            {

                ddlCasosRavi.SelectedValue = "";
            }
            else if (ddlCasosRavi.SelectedValue == "0")
            {

                ddlCasosRavi.SelectedValue = "0";

            }
        }

        protected void ddlNoaccionesDGPVI_SelectedIndexChanged(object sender, EventArgs e)
        {
            int total = SumarAcciones(ddlNoaccionesDGPVI, ddlNoAccionesInstitucionales);
            txtTotalAccionesRAVI.Text = total.ToString();
        }


        private int SumarAcciones(DropDownList ddl1, DropDownList ddl2)
        {
            int val1 = int.TryParse(ddl1.SelectedValue, out var tmp1) ? tmp1 : 0;
            int val2 = int.TryParse(ddl2.SelectedValue, out var tmp2) ? tmp2 : 0;
            return val1 + val2;
        }




        private void CargarEntorno(int EntornoId)
        {
            try
            {
                var repo = new EntornoRepository();

                ddlAmbito.DataSource = repo.ObtenerEntorno(EntornoId);
                ddlAmbito.DataTextField = "Entorno";
                ddlAmbito.DataValueField = "EntornoId";
                ddlAmbito.DataBind();

                ddlAmbito.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }

            catch (Exception ex)
            {

            }
        }

        private void CargarEje(int EntornoId)
        {
            try
            {
                var repo = new EntornoRepository();

                var localidades = repo.ObtenerEje(EntornoId);

                ddlEje.DataSource = localidades;
                ddlEje.DataTextField = "Eje";
                ddlEje.DataValueField = "EjeId";
                ddlEje.DataBind();

                ddlEje.Items.Insert(0, new ListItem("-- Seleccione eje --", "0"));
            }

            catch (Exception)
            {
                lblError.Text = "Error al cargar eje";
                lblError.Visible = true;
            }

        }

    }
}