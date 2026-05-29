using Microsoft.Win32;
using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Datos.Repositorio;
using System;
using System.Collections.Generic;
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



        protected void Page_Load(object sender, EventArgs e)
        {


            if (!UsuarioTieneAcceso())
            {
                RedirigirInicio();
                return;
            }

            programasID = Convert.ToInt32(Session["programasID"]);

            if (programasID == 0)
            {
                PanelCoordinacion.Visible = false;
                PanelMunicipiosPrioritarios.Visible = false;
                PanelRAVI.Visible = false;

            }
            else
            {
                PanelCoordinacion.Visible = true;
                PanelMunicipiosPrioritarios.Visible = true;
                PanelRAVI.Visible = true;
            }


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
            determinarAccion();
        }

        private void ConfigurarPaneles()
        {

            bool imagenSeleccioneda = Session["ImagenSeleccionada"] != null;
            PanelAccionImplentada.Visible = imagenSeleccioneda;
            PanelListados.Visible = !imagenSeleccioneda;

        }

        private void RedirigirInicio()
        {
            Response.Redirect("~/TotalAccionesBeneficiados.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void MostrarPrograma(int? programasID)
        {
            var query = from p in ctx.tb_programa
                        where p.programasID == programasID
                        select p.NombrePrograma;

            if (query != null)
            {
                lblPrograma.Text = "" + ctx.tb_programa.Where(p => p.programasID == programasID).Select(p => p.NombrePrograma).FirstOrDefault();
            }
            else
            {
                lblPrograma.Text = "";
            }

        }


        #region ***** DETERMINACION DE LA ACCIÓN DEL REPOTE YA SEA CREAR NUEVO O EDITAR Y LLENAR REPORTE
        protected void determinarAccion()
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





        protected void lnkbtnGuardar_Click(object sender, EventArgs e)
        {

            programasID = Session["programasID"] != null ? (int?)Session["programasID"] : null;


            bool valido = true;
            string textoValidacion = "<ul>";
            int r = 0;
            int tamanoarchivo;
            string fileName = "";
            string contentType = "";
            bool actividadfueradefecha = Convert.ToBoolean(Session["actividades_fuera_tiempo"]);
            if (file.HasFile)
            {
                foreach (HttpPostedFile postedFile in (IEnumerable<HttpPostedFile>)this.file.PostedFiles)
                {
                    fileName = file.FileName;
                    Validaciones.Imagenes vl = new Validaciones.Imagenes();


                    if (vl.ValidateVideoExtension(fileName) == false)
                    {
                        textoValidacion += "<li>Solo permite subir imagenes, en formatos PNG Y JPG</li>";
                        valido = false;
                    }


                    r += postedFile.ContentLength;
                }
                //tamanoarchivo = Server.HtmlDecode.postedFile.ContentLength;
                if (r >= 3000000)
                {
                    textoValidacion += "<li>El tamaño maximo permitido por archivo es de " + "3 " + " MB</li>";
                    valido = false;
                }
            }
            else
            {
                textoValidacion += "<li>Es obigatorio por lo menos 1 Imagen</li>";
                valido = false;
            }

            if (actividadfueradefecha == true)
            {

                textoValidacion += "<li>La actividad esta fuera de tiempo, si quieres guardar la actividad debe ser con el mes que esta en curso</li>";
                txtFecha.Focus();
                txtFecha.BorderColor = System.Drawing.Color.Red;
                valido = false;

            }
            if (string.IsNullOrEmpty(txtFecha.Text))
            {
                textoValidacion += "<li>Es obligatorio la fecha del reporte</li>";
                txtFecha.Focus();
                txtFecha.BorderColor = System.Drawing.Color.Red;
                valido = false;
            }
            if (string.IsNullOrEmpty(lati.Value) || string.IsNullOrEmpty(longi.Value))
            {
                textoValidacion += "<li>Por favor ingresar una dirección correcta no cuenta con coordenadas para hacer el punteo </ li>";
                valido = false;
            }
            //if (string.IsNullOrEmpty(route.Value) || string.IsNullOrEmpty(entrecalle1.Value) || string.IsNullOrEmpty(entrecalle2.Value) || string.IsNullOrEmpty(colony.Value))
            //{
            //    textoValidacion += "<li>Es obligatorio la calle, las entre calles y la colonia </ li>";
            //    valido = false;
            //}
            if (ddlMuNICIPIO.SelectedIndex == 0 || string.IsNullOrEmpty(ddlMuNICIPIO.SelectedValue))
            {
                textoValidacion += "<li>Es obligatorio el municipio</li>";
                valido = false;
            }
            if (ddlLocalidad.SelectedIndex == 0 || string.IsNullOrEmpty(ddlLocalidad.SelectedValue))
            {
                textoValidacion += "<li>Es obligatorio la localidad</li>";
                valido = false;
            }

            //if (ddlsubprograma.SelectedIndex == 0 || string.IsNullOrEmpty(ddlsubprograma.SelectedValue))
            //{
            //    textoValidacion += "<li>Es obligatorio el Subprograma</li>";
            //    valido = false;
            //}

            //if (ddlAcciones.SelectedIndex == 0 || string.IsNullOrEmpty(ddlAcciones.SelectedValue))
            //{
            //    textoValidacion += "<li>Es obligatorio Seleccioner una acción</li>";
            //    valido = false;
            //}
            //if (string.IsNullOrEmpty(txtnombreescuela.Text))
            //{
            //    textoValidacion += "<li>Es obligatorio ingresar la esceula donde ralizaron la actividad </li>";
            //    txtnombreescuela.Focus();
            //    txtnombreescuela.BorderColor = System.Drawing.Color.Red;
            //    valido = false;
            //}
            if (string.IsNullOrEmpty(txtnombrecontacto.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar el nombre del contacto </li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar el numero del contacto </li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtDescripcionActividad.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar una descripción de la actividad </li>";
                valido = false;
            }

            if (txtatendiosH.Text == "" || (txtatendiosM.Text == ""))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados </li>";
                valido = false;
            }

            if (!valido)
            {
                textoValidacion += "</ul>";
                lblValidacionesTxt.Text = textoValidacion;

                //ScriptManager.RegisterStartupScript(this, GetType(), "CamposObligatorios", "CamposObligatorios('" + textoValidacion  + "');", true);



                ScriptManager.RegisterStartupScript(this, GetType(), "openModalvalidador", "openModalvalidador();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "sumar", "sumar();", true);

            }
            else
            {
                int area;
                string coordinacion;
                nino = 0;
                nina = 0;
                padresH = 0;
                padresM = 0;
                TotalA = 0;

                sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var ID = ctx.Personales.Where(x => x.login == this.sUsuarioActual).FirstOrDefault();
                personalID = ID.Personalid;
                area = Convert.ToInt32(ID.cat_areaidarea);

                if (area == 1022 || area == 7 || area == 4 || area == 6 || area == 8 || area == 5 || area == 3 || area == 1023 || area == 1025)
                {
                    coordinacion = "CONURBACION XALAPA XX";
                }
                else
                {
                    if (area == 1020)
                    {
                        coordinacion = "CONURBACION VERACRUZ XXIII";

                    }
                    else
                    {
                        if (area == 1012)
                        {
                            coordinacion = "CONURBACION POZA RICA";

                        }
                        else
                        {
                            if (area == 1011)
                            {
                                coordinacion = "COORDINACION CORDOBA";

                            }
                            else
                            {
                                if (area == 1009)
                                {
                                    coordinacion = "COORDINACION COATZACOALCOS";

                                }
                                else
                                {
                                    coordinacion = "ENLACES";
                                }
                            }
                        }
                    }
                }
                try
                {
                    string claveF = "";
                    Guid IdResumenGuid = Guid.NewGuid();
                    Session["idresumen"] = IdResumenGuid;
                    tb_Reporte_Diario NuevoRegistros = new tb_Reporte_Diario();
                    NuevoRegistros.idResumenDiario = IdResumenGuid;
                    NuevoRegistros.Personalid = personalID;
                    NuevoRegistros.fechacaptura = DateTime.Now;
                    NuevoRegistros.fecha = new DateTime?(Convert.ToDateTime(this.txtFecha.Text));


                    NuevoRegistros.coordinador = string.IsNullOrWhiteSpace(txtCoordinador.Text) ? "" : txtCoordinador.Text.Trim();

                    NuevoRegistros.idzona = int.TryParse(ddlZona.SelectedValue, out var valor) ? valor : (int?)null;

                    NuevoRegistros.idcoordinacion = int.TryParse(ddlCoordinacion.SelectedValue, out var coord) ? (int?)coord : null;


                    NuevoRegistros.programasID = programasID;
                    NuevoRegistros.subprogramaId = new int?(this.ddlsubprograma.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlsubprograma.SelectedValue));

                    // NuevoRegistros.AccionesID = new int?(this.ddlAcciones.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlAcciones.SelectedValue));
                    NuevoRegistros.AccionesID = string.IsNullOrEmpty(ddlAcciones.SelectedValue) ? 0 : Convert.ToInt32(ddlAcciones.SelectedValue);


                    NuevoRegistros.accion_implementada = txtAccionImplementada.Text == string.Empty ? "" : txtAccionImplementada.Text.ToUpper();

                    NuevoRegistros.descripcion_actividad = this.txtDescripcionActividad.Text == string.Empty ? "" : this.txtDescripcionActividad.Text.ToUpper();
                    NuevoRegistros.personal_atendio_actividad = this.txtpersonal_atendio_actividad.Text == string.Empty ? "" : this.txtpersonal_atendio_actividad.Text.ToUpper();                    
                    NuevoRegistros.seguimiento = this.txtSeguimiento.Text == string.Empty ? "" : this.txtSeguimiento.Text.ToUpper();

                    int MODE = Convert.ToInt32(ddlAmbito.SelectedValue);

                    int Hombres = 0;
                    int Mujeres = 0;


                    if (this.txnina.Value != "")
                        nina = int.Parse(this.txnina.Value, (IFormatProvider)CultureInfo.InvariantCulture);
                    if (this.txnino.Value != "")
                        nino = int.Parse(this.txnino.Value, (IFormatProvider)CultureInfo.InvariantCulture);
                    if (this.txhombres.Value != "")
                        padresH = int.Parse(this.txhombres.Value, (IFormatProvider)CultureInfo.InvariantCulture);
                    if (this.txmujeres.Value != "")
                        padresM = int.Parse(this.txmujeres.Value, (IFormatProvider)CultureInfo.InvariantCulture);


                    Hombres = nino + padresH;
                    Mujeres = nina + padresM;
                    TotalA = Mujeres + Hombres;
                    NuevoRegistros.TotalHombresAtendidos = new int?(Hombres);
                    NuevoRegistros.TotalMujeresAtendidas = new int?(Mujeres);
                    NuevoRegistros.total_atendidos = new int?(TotalA);

                    //    NuevoRegistros.total_atendidos = new int?(this.txtatendiosH.Text == string.Empty ? 0 : Convert.ToInt32(this.txtatendiosH.Text));

                    // NuevoRegistros.total_atendidos = new int?(this.txtatendiosH.Text == string.Empty ? 0 : Convert.ToInt32(this.txtatendiosH.Text));
                    NuevoRegistros.capturaAPP = "NO";
                    NuevoRegistros.DelegacionOcoonurbacion = coordinacion;
                    ctx.tb_Reporte_Diario.Add(NuevoRegistros);

                    ctx.tb_DireccionReporte.Add(new tb_DireccionReporte()
                    {
                        idResumenDiario = IdResumenGuid,
                        Latitud = this.lati.Value,
                        Longitud = this.longi.Value,
                        calle = this.route.Value == string.Empty ? "" : this.route.Value,
                        coloni = this.colony.Value == string.Empty ? "" : this.colony.Value,
                        //  Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                        //  Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,
                        //    RegionID = new int?(this.ddlRegion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlRegion.SelectedValue)),
                        //   DelegacionID = new int?(this.ddlDelegacion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlDelegacion.SelectedValue)),
                        MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                        LocalidadID = new int?(Convert.ToInt32(this.ddlLocalidad.SelectedValue)),

                        mpio_prioritario = ddlMunicipioPrioritario.SelectedValue == "1" ? true : false,
                        mpio_homicidio = ddlMunicipioHomicidio.SelectedValue == "1" ? true : false,
                        col_prioritario = ddlColoniaPrioritaria.SelectedValue == "1" ? true : false,
                        mpio_indigena = ddlMunicipioIndigena.SelectedValue == "1" ? true : false,
                        programa_istmo = ddlProgramaIstmo.SelectedValue == "1" ? true : false

                    });

                    TB_DatosGralReporte nuevoDatosGral = new TB_DatosGralReporte();
                    nuevoDatosGral.idResumenDiario = IdResumenGuid;
                    nuevoDatosGral.NombreLugar_Escuela = this.ddlnombreescuela.SelectedValue;
                    nuevoDatosGral.NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper();
                    nuevoDatosGral.telcel = this.txtTelefono.Text;
                    nuevoDatosGral.ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper();
                    nuevoDatosGral.Nivel = this.ddlNivel.SelectedValue;
                    nuevoDatosGral.Ambito = Convert.ToInt32(ddlAmbito.SelectedValue);
                    nuevoDatosGral.EjeId = Convert.ToInt32(ddlEje.SelectedValue);


                    nuevoDatosGral.niñas = new int?(this.txnina.Value == "" ? 0 : Convert.ToInt32(this.txnina.Value));
                    nuevoDatosGral.niños = new int?(this.txnino.Value == "" ? 0 : Convert.ToInt32(this.txnino.Value));
                    nuevoDatosGral.hombres = new int?(this.txhombres.Value == "" ? 0 : Convert.ToInt32(this.txhombres.Value));
                    nuevoDatosGral.mujeres = new int?(this.txmujeres.Value == "" ? 0 : Convert.ToInt32(this.txmujeres.Value));


                    nuevoDatosGral.plantel_diagnosticado = ddlPlantelDiagnosticado.SelectedValue == "1" ? true : false;
                    nuevoDatosGral.inst_participantes = this.txtInstitucionesParticipantes.Text == string.Empty ? "" : this.txtInstitucionesParticipantes.Text.ToUpper();
                    nuevoDatosGral.tema_impartido = this.txtTemaImpartido.Text == string.Empty ? "" : this.txtTemaImpartido.Text.ToUpper();
                    nuevoDatosGral.casos_ravi = ddlCasosRavi.SelectedValue == "1" ? true : false;
                    nuevoDatosGral.nocasos_ravi = new int?(this.txtNoCasosRavi.Text == "" ? 0 : Convert.ToInt32(this.txtNoCasosRavi.Text));
                    nuevoDatosGral.dirigido = this.txtDirigidoA.Text == string.Empty ? "" : this.txtDirigidoA.Text.ToUpper();
                    nuevoDatosGral.giro_comercios = this.txtGiroComercio.Text == string.Empty ? "" : this.txtGiroComercio.Text.ToUpper();

                    nuevoDatosGral.no_acciones_dgpvi = int.TryParse(ddlNoaccionesDGPVI.SelectedValue, out var val) ? val : (int?)null;
                    nuevoDatosGral.no_acciones_institucionales = int.TryParse(ddlNoAccionesInstitucionales.SelectedValue, out var val2) ? val2 : (int?)null;
                    nuevoDatosGral.total_acciones_ravi = txtTotalAccionesRAVI.Text == "" ? (int?)null : Convert.ToInt32(txtTotalAccionesRAVI.Text);
                    nuevoDatosGral.ofrecieron_segurichat = ddlOfrecioSegurichat.SelectedValue == "1" ? true : false;
                    nuevoDatosGral.segurichat = this.txtSegurichat.Text == string.Empty ? "" : this.txtSegurichat.Text.ToUpper();



                    ctx.TB_DatosGralReporte.Add(nuevoDatosGral);

                    tbAuditoria audit = new tbAuditoria()
                    {
                        auditoriaGuid = new Guid?(Guid.NewGuid()),
                        fecha = new DateTime?(DateTime.Now),
                        area = this.txtArea.Text,
                        idTipomodificacion = new int?(1),
                        PagModificacion = this.Page.Title,
                        Descripcion = "Nuevo registro de nuevas capturas",
                        usuario = this.txtResponsable.Text,
                        IdABC = Convert.ToString(IdResumenGuid)
                    };
                    ctx.tbAuditoria.Add(audit);
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
                                        foto.idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario);
                                        ctx.tb_fotografia.Add(foto);
                                    }

                                }
                            }
                        }
                    }
                    ctx.SaveChanges();
                    //ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "redirect", "alert('Datos guardados con exito'); window.location='" + this.Request.ApplicationPath + "TotalAccionesBeneficiados.aspx';", true);
                    claveF = "RVCPZ-DVI";
                    Guid id = IdResumenGuid;
                    var folio = ctx.sp_folio_actividad(id, claveF, extencion).ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "openGuardadoExito", "openGuardadoExito();", true);
                    Session["actividades_fuera_tiempo"] = null;

                    Session["ImagenSeleccioneda"] = null;
                    Session["programasID"] = null;

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('ERRO AL GUARDAR LOS DATOS')", true);

                }

            }
        }


        //private bool ValidateVideoExtension(string nombreImg)
        //{
        //    FileInfo info = new FileInfo(nombreImg);
        //    switch (info.Extension.ToLower())
        //    {
        //        case ".png":
        //        case ".PNG":
        //        case ".jpg":
        //        case ".JPG":
        //        case ".bmp":
        //            return true;
        //        default:
        //            return false;
        //    }
        // }

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
        protected void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            Guid idExpediente = Guid.Parse(HiddenField1cn.Value);
            int r = 0;
            int tamanoarchivo;
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
                /// GUARDAR LOS DATOS DE GOOGLE 
                tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
                if (direccionReporte != null)
                {
                    direccionReporte.Latitud = this.lati.Value;
                    direccionReporte.Longitud = this.longi.Value;
                    direccionReporte.calle = this.route.Value == string.Empty ? "" : this.route.Value;
                    direccionReporte.coloni = this.colony.Value == string.Empty ? "" : this.colony.Value;
                    // direccionReporte.Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value;
                    // direccionReporte.Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value;
                    //  direccionReporte.RegionID = new int?(this.ddlRegion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlRegion.SelectedValue));
                    // direccionReporte.DelegacionID = new int?(this.ddlDelegacion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlDelegacion.SelectedValue));
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
                        //   Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                        //   Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,
                        //   RegionID = new int?(this.ddlRegion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlRegion.SelectedValue)),
                        //   DelegacionID = new int?(this.ddlDelegacion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlDelegacion.SelectedValue)),
                        MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                        LocalidadID = new int?(this.ddlLocalidad.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                    });
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
                    // nuevoDatosGral.NombreLugar_Escuela = this.ddlnombreescuela.Text == string.Empty ? "" : this.ddlnombreescuela.Text.ToUpper();
                    nuevoDatosGral.NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper();
                    nuevoDatosGral.telcel = this.txtTelefono.Text;
                    nuevoDatosGral.ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper();
                    //   nuevoDatosGral.Nivel = this.ddlNivel.Text == string.Empty ? "" : this.ddlNivel.Text.ToUpper();
                    nuevoDatosGral.Ambito = Convert.ToInt32(ddlAmbito.SelectedValue);
                    nuevoDatosGral.EjeId = Convert.ToInt32(ddlEje.SelectedValue);
                    nuevoDatosGral.niñas = new int?(this.txnina.Value == "" ? 0 : Convert.ToInt32(this.txnina.Value));
                    nuevoDatosGral.niños = new int?(this.txnino.Value == "" ? 0 : Convert.ToInt32(this.txnino.Value));
                    nuevoDatosGral.hombres = new int?(this.txhombres.Value == "" ? 0 : Convert.ToInt32(this.txhombres.Value));
                    nuevoDatosGral.mujeres = new int?(this.txmujeres.Value == "" ? 0 : Convert.ToInt32(this.txmujeres.Value));
                    ctx.TB_DatosGralReporte.Add(nuevoDatosGral);

                }
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
                ctx.SaveChanges();
                String claveF = "RVCPZ-DVI";
                Guid id = idExpediente;
                var folio = ctx.sp_folio_actividad(id, claveF, extencion).ToString();
                tbAuditoria entity = new tbAuditoria()
                {
                    auditoriaGuid = new Guid?(Guid.NewGuid()),
                    fecha = new DateTime?(DateTime.Now),
                    area = this.txtArea.Text,
                    idTipomodificacion = new int?(2),
                    PagModificacion = this.Page.Title,
                    Descripcion = "Se edito el registro de reporte de actividades ,SEGURIDAD CIUDADANA Y PAZ SOCIAL EN ENTORNO EDUCATIVO",
                    usuario = this.txtResponsable.Text,
                    IdABC = Convert.ToString((object)idExpediente)
                };
                ctx.tbAuditoria.Add(entity);
                ctx.SaveChanges();
                this.HiddenField1cn.Value = (string)null;
                this.btnGuardarEdicion.Visible = false;
                this.btnSalir.Visible = false;
                this.Session["idExpediente_Accion"] = (object)null;
                this.Session["AccionExpediente"] = (object)null;
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "redirect", "alert('DATOS GUARDADOS CON EXITO'); window.location='" + this.Request.ApplicationPath + "TotalAccionesBeneficiados.aspx';", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('¡Error al guardar los datos!')", true);
            }


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
                //lblError.Text = "Ocurrió un error al cargar municipios";
                //lblError.Visible = true;

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
                // Mostrar mensaje amigable
                //lblError.Text = "Ocurrió un error al cargar municipios";
                //lblError.Visible = true;
                // (opcional) log
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


        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int municipioId = int.Parse(ddlMuNICIPIO.SelectedValue);

            if (municipioId > 0)
            {
                CargarLocalidades(municipioId);
            }
            else
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione localidad --", "0"));
            }


            MostrarMunicipiosPrioridad(municipioId);
            MostrarPoblacionIndigena(municipioId);
            MostrarProgramaISTMO(municipioId);
            MostrarColoniasPrioridad(municipioId);

        }

        protected void MostrarMunicipiosPrioridad(int municipioId)
        {
            var repo = new UbicacionRepository();
            var prioridad = repo.ObtenerMunicipiosPrioridad(municipioId);

            if (prioridad == true)
            {
                ddlMunicipioPrioritario.SelectedValue = "True";
            }
            else if (prioridad == false)
            {
                ddlMunicipioPrioritario.SelectedValue = "False";
            }
            else
            {

                ddlMunicipioPrioritario.SelectedValue = "-1";
            }

        }


        protected void MostrarPoblacionIndigena(int municipioId)
        {
            var repo = new UbicacionRepository();
            var prioridad = repo.ObtenerPoblacionIndigena(municipioId);

            if (prioridad == true)
            {
                ddlMunicipioIndigena.SelectedValue = "True";
            }
            else if (prioridad == false)
            {
                ddlMunicipioIndigena.SelectedValue = "False";
            }
            else
            {

                ddlMunicipioIndigena.SelectedValue = "-1";
            }

        }

        protected void MostrarProgramaISTMO(int municipioId)
        {
            var repo = new UbicacionRepository();
            var prioridad = repo.ObtenerProgramaISTMO(municipioId);

            if (prioridad == true)
            {
                ddlProgramaIstmo.SelectedValue = "True";
            }
            else if (prioridad == false)
            {
                ddlProgramaIstmo.SelectedValue = "False";
            }
            else
            {

                ddlProgramaIstmo.SelectedValue = "-1";
            }

        }


        protected void MostrarColoniasPrioridad(int municipioId)
        {
            var repo = new UbicacionRepository();
            var prioridad = repo.ObtenerColoniasPrioridad(municipioId);

            if (prioridad == true)
            {
                ddlColoniaPrioritaria.SelectedValue = "True";
            }
            else if (prioridad == false)
            {
                ddlColoniaPrioritaria.SelectedValue = "False";
            }
            else
            {

                ddlColoniaPrioritaria.SelectedValue = "-1";
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
            //else
            //{

            //    ddlZona.Items.Insert(0, new ListItem("-- Seleccione localidad --", "0"));
            //}
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