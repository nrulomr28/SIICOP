using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SIICOP_V1._2.Captura
{
    public partial class Prevencion_traves_Deporte_Cultura : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        string sUsuarioActual;
        int personalID;
        public enum AccionExpediente { Creacion, Edicion, Visualizacion }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Foráneo") || User.IsInRole("Administrador") || User.IsInRole("Cap_IC") || User.IsInRole("Admin_FDC"))
                {
                    this.determinarAccion();

                }
                else
                {
                    this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
                }
            }
        }
        protected void determinarAccion()
        {

            if (Session["idExpediente_Accion"] != null && Session["AccionExpediente"] != null)
            {
                AccionExpediente accion = (AccionExpediente)Session["AccionExpediente"];
                switch ((int)accion)
                {
                    case (int)AccionExpediente.Creacion:
                        if (!User.IsInRole("SysAdmin") && !User.IsInRole("Foraneo") && !User.IsInRole("Cap_IC") && !User.IsInRole("Admin_Empresarial"))
                        {
                            Response.Redirect("~/VistasReportes/InfoEmpresarial.aspx");
                        }
                        break;
                    case (int)AccionExpediente.Edicion:
                        ddlMuNICIPIO.DataBind();
                        ddlsubprograma.DataBind();
                        ddlLocalidad.DataBind();
                        expediente_Edicion_Visualizacion();
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

        protected void expediente_Edicion_Visualizacion()
        {
            if (Session["idExpediente_Accion"] != null)
            {
                try
                {
                    Guid idExpediente = Guid.Parse(Session["idExpediente_Accion"].ToString());
                    expediente_Llenar(idExpediente);
                }
                catch (Exception ex) { /*salidaBandeja();*/ }
            }
            else
            {
                //salidaBandeja();
            }
        }
        protected void expediente_Llenar(Guid idExpediente)
        {
            ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('ESTA EN MODO EDICIÓN DEL REPORTE.');", true);
            this.btnGuardarEdicion.Visible = true;
            this.btnSalir.Visible = true;
            Guid idReporte = idExpediente;
            Wv_DatosReportesHistorico reportesHistorico = ctx.Wv_DatosReportesHistorico.Where(g => g.idResumenDiario == idReporte).FirstOrDefault();
            if (reportesHistorico != null)
            {
                HiddenField1.Value = idReporte.ToString();

                this.txtResponsable.Text = reportesHistorico.nombrecompleto != null ? reportesHistorico.nombrecompleto : "";
                this.txtArea.Text = reportesHistorico.AreaTrabajo != null ? reportesHistorico.AreaTrabajo : "";
                this.txtFecha.Text = string.Format("{0:dd/MM/yyyy}", (object)reportesHistorico.fecha);
                ddlsubprograma.DataBind();
                ddlsubprograma.SelectedValue = reportesHistorico.subprogramaId != 0 ? reportesHistorico.subprogramaId.ToString() : "0";
                ddlAcciones.SelectedValue = reportesHistorico.AccionesID != 0 ? reportesHistorico.AccionesID.ToString() : "0";
                this.txtatendios.Text = reportesHistorico.total_atendidos.ToString();
                this.txtDescripcionActividad.Text = reportesHistorico.descripcion_actividad != null ? reportesHistorico.descripcion_actividad : "";
                this.txtpersonal_atendio_actividad.Text = reportesHistorico.personal_atendio_actividad != null ? reportesHistorico.personal_atendio_actividad : "";
                this.txttotlaHombres.Value = reportesHistorico.TotalHombresAtendidos != 0 ? reportesHistorico.TotalHombresAtendidos.ToString() : "0";
                this.txtmujer.Value = reportesHistorico.TotalMujeresAtendidas != 0 ? reportesHistorico.TotalMujeresAtendidas.ToString() : "0";
                this.txtatendios.Text = reportesHistorico.total_atendidos != 0 ? reportesHistorico.total_atendidos.ToString() : "0";
            }

            tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idReporte).FirstOrDefault();
            if (direccionReporte != null)
            {
                this.HiddenField1.Value = Convert.ToString((object)idReporte);
                this.lati.Value = direccionReporte.Latitud != null ? direccionReporte.Latitud : "";
                this.longi.Value = direccionReporte.Longitud != null ? direccionReporte.Longitud : "";
                this.route.Value = direccionReporte.calle != null ? direccionReporte.calle : "";
                this.colony.Value = direccionReporte.coloni != null ? direccionReporte.coloni : "";
                // this.entrecalle1.Value = direccionReporte.Entrecalle1 != null ? direccionReporte.Entrecalle1 : "";
                // this.entrecalle2.Value = direccionReporte.Entrecalle2 != null ? direccionReporte.Entrecalle2 : "";

                ddlMuNICIPIO.DataBind();
                ddlMuNICIPIO.SelectedValue = direccionReporte.MunicipioID.ToString().Trim();
                ddlLocalidad.SelectedValue = direccionReporte.LocalidadID != null ? direccionReporte.LocalidadID.ToString() : "0";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "VerDireccionMapa", "VerDireccionMapa();", true);
            }

            TB_DatosGralReporte datosGralReporte = ctx.TB_DatosGralReporte.Where(t => t.idResumenDiario == idReporte).FirstOrDefault();
            if (datosGralReporte != null)
            {

                this.txtNombrelugar.Text = datosGralReporte.NombreLugar_Escuela != null ? datosGralReporte.NombreLugar_Escuela : "";
                this.txtnombrecontacto.Text = datosGralReporte.NombreContacto != null ? datosGralReporte.NombreContacto : "";
                this.txttel.Text = datosGralReporte.telcel != null ? datosGralReporte.telcel : "";

            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            this.Session["idExpediente_Accion"] = (object)null;
            this.Session["AccionExpediente"] = (object)null;
            this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
            this.HiddenField1.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }

        protected void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            Guid idExpediente = Guid.Parse(HiddenField1.Value);
            int r = 0;
            int tamanoarchivo;
            string fileName = "";
            string contentType = "";
            try
            {
                tb_Reporte_Diario tbReporteDiario = ctx.tb_Reporte_Diario.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
                if (tbReporteDiario != null)
                {
                    tbReporteDiario.descripcion_actividad = this.txtDescripcionActividad.Text == string.Empty ? "" : this.txtDescripcionActividad.Text.ToUpper();
                    tbReporteDiario.personal_atendio_actividad = this.txtpersonal_atendio_actividad.Text == string.Empty ? "" : this.txtpersonal_atendio_actividad.Text.ToUpper();
                    tbReporteDiario.AccionesID = new int?(this.ddlAcciones.SelectedValue == "null" ? 0 : Convert.ToInt32(this.ddlAcciones.SelectedValue));
                    tbReporteDiario.fecha = new DateTime?(Convert.ToDateTime(this.txtFecha.Text));
                    tbReporteDiario.subprogramaId = new int?(this.ddlsubprograma.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlsubprograma.SelectedValue));
                    tbReporteDiario.TotalHombresAtendidos = new int?(this.txttotlaHombres.Value == string.Empty ? 0 : Convert.ToInt32(this.txttotlaHombres.Value));
                    tbReporteDiario.TotalMujeresAtendidas = new int?(this.txtmujer.Value == string.Empty ? 0 : Convert.ToInt32(this.txtmujer.Value));

                    int totalBeneficiados = int.Parse(txttotlaHombres.Value) + int.Parse(txtmujer.Value);
                    tbReporteDiario.total_atendidos = totalBeneficiados;
                    tbReporteDiario.fechacaptura = new DateTime?(DateTime.Now);
                }

                int idMuni = Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue);
                var buscardelega = ctx.Municipios.Where(p => p.MunicipioID == idMuni).FirstOrDefault();
                var region = ctx.Cat_Delegacion.Where(q => q.DelegacionID == buscardelega.DelegacionID).FirstOrDefault();
                tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
                if (direccionReporte != null)
                {
                    direccionReporte.Latitud = this.lati.Value;
                    direccionReporte.Longitud = this.longi.Value;
                    direccionReporte.calle = this.route.Value == string.Empty ? "" : this.route.Value;
                    direccionReporte.coloni = this.colony.Value == string.Empty ? "" : this.colony.Value;
                    //  direccionReporte.Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value;
                    //  direccionReporte.Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value;
                    direccionReporte.DelegacionID = buscardelega.DelegacionID;
                    direccionReporte.RegionID = region.RegionID;
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
                        DelegacionID = buscardelega.DelegacionID,
                        RegionID = region.RegionID,
                        MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                        LocalidadID = new int?(this.ddlLocalidad.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                    });

                TB_DatosGralReporte datosGralReporte = ctx.TB_DatosGralReporte.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
                if (datosGralReporte != null)
                {

                    datosGralReporte.NombreLugar_Escuela = this.txtNombrelugar.Text == string.Empty ? "" : this.txtNombrelugar.Text.ToUpper();
                    datosGralReporte.NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper();
                    datosGralReporte.telcel = this.txttel.Text;

                }
                else
                    ctx.TB_DatosGralReporte.Add(new TB_DatosGralReporte()
                    {
                        idResumenDiario = new Guid?(idExpediente),
                        NombreLugar_Escuela = this.txtNombrelugar.Text == string.Empty ? "" : this.txtNombrelugar.Text.ToUpper(),
                        NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper(),
                        telcel = this.txttel.Text,
                    });
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
                String claveF = "FPDyC-DVI";
                Guid id = idExpediente;
                var folio = ctx.sp_folio_actividad(id, claveF, extencion).ToString();

                tbAuditoria entity = new tbAuditoria()
                {
                    auditoriaGuid = new Guid?(Guid.NewGuid()),
                    fecha = new DateTime?(DateTime.Now),
                    area = this.txtArea.Text,
                    idTipomodificacion = new int?(2),
                    PagModificacion = this.Page.Title,
                    Descripcion = "Se edito el registro de reporte de actividades,Fomento a la Prevención a través del Deporte la Cultura",
                    usuario = this.txtResponsable.Text,
                    IdABC = Convert.ToString((object)idExpediente)
                };
                ctx.tbAuditoria.Add(entity);
                ctx.SaveChanges();
                this.HiddenField1.Value = (string)null;
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


        protected void lnkbtnGuardar_Click(object sender, EventArgs e)
        {
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
                if (r >= 5000000)
                {
                    textoValidacion += "<li>El tamaño maximo permitido por archivo es de " + "5 " + " MB</li>";
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
            if (ddlsubprograma.SelectedIndex == 0 || string.IsNullOrEmpty(ddlsubprograma.SelectedValue))
            {
                textoValidacion += "<li>Es obligatorio el Subprograma</li>";
                valido = false;
            }
            if (ddlAcciones.SelectedIndex == 0 || string.IsNullOrEmpty(ddlAcciones.SelectedValue))
            {
                textoValidacion += "<li>Es obligatorio seleccinoar una acción</li>";
                valido = false;
            }

            if (string.IsNullOrEmpty(txtNombrelugar.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar el lugar donde ralizaron la actividad </li>";
                txtNombrelugar.Focus();
                txtNombrelugar.BorderColor = System.Drawing.Color.Red;
                valido = false;
            }
            if (string.IsNullOrEmpty(txtnombrecontacto.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar el nombre del contacto </li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txttel.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar el numero del contacto </li>";
                valido = false;
            }

            if (string.IsNullOrEmpty(txtDescripcionActividad.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar una descripción de la actividad </li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txttotlaHombres.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados hombres en el caso de no contar con ello porner 0</li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtmujer.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados mujeres en el caso de no contar con ello porner 0 </li>";
                valido = false;
            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                lblValidacionesTxt.Text = textoValidacion;
                ScriptManager.RegisterStartupScript(this, GetType(), "openModalvalidador", "openModalvalidador();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "sumar", "sumar();", true);

            }
            else
            {
                int area;
                string coordinacion;
                sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var ID = ctx.Personales.Where(x => x.login == this.sUsuarioActual).FirstOrDefault();
                personalID = ID.Personalid;
                area = Convert.ToInt32(ID.cat_areaidarea);

                if (area == 1022 || area == 7 || area == 4 || area == 6 || area == 8 || area == 5 || area == 3 || area == 1023)
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
                    tb_Reporte_Diario NuevoRegistros = new tb_Reporte_Diario();
                    NuevoRegistros.idResumenDiario = Guid.NewGuid();
                    NuevoRegistros.Personalid = personalID;
                    NuevoRegistros.fechacaptura = DateTime.Now;
                    NuevoRegistros.fecha = new DateTime?(Convert.ToDateTime(this.txtFecha.Text));
                    NuevoRegistros.programasID = 12;
                    NuevoRegistros.subprogramaId = new int?(this.ddlsubprograma.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlsubprograma.SelectedValue));
                    NuevoRegistros.AccionesID = new int?(this.ddlAcciones.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlAcciones.SelectedValue));
                    NuevoRegistros.descripcion_actividad = this.txtDescripcionActividad.Text == string.Empty ? "" : this.txtDescripcionActividad.Text.ToUpper();
                    NuevoRegistros.personal_atendio_actividad = this.txtpersonal_atendio_actividad.Text == string.Empty ? "" : this.txtpersonal_atendio_actividad.Text.ToUpper();
                    NuevoRegistros.TotalHombresAtendidos = new int?(this.txttotlaHombres.Value == string.Empty ? 0 : Convert.ToInt32(this.txttotlaHombres.Value));
                    NuevoRegistros.TotalMujeresAtendidas = new int?(this.txtmujer.Value == string.Empty ? 0 : Convert.ToInt32(this.txtmujer.Value));

                    int totalBeneficiados = int.Parse(txttotlaHombres.Value) + int.Parse(txtmujer.Value);
                    NuevoRegistros.total_atendidos = totalBeneficiados;

                    NuevoRegistros.capturaAPP = "NO";
                    NuevoRegistros.DelegacionOcoonurbacion = coordinacion;
                    ctx.tb_Reporte_Diario.Add(NuevoRegistros);
                    Session["idresumen"] = new Guid?(NuevoRegistros.idResumenDiario);

                    int idMuni = Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue);
                    var buscardelega = ctx.Municipios.Where(p => p.MunicipioID == idMuni).FirstOrDefault();
                    var region = ctx.Cat_Delegacion.Where(q => q.DelegacionID == buscardelega.DelegacionID).FirstOrDefault();
                    ctx.tb_DireccionReporte.Add(new tb_DireccionReporte()
                    {
                        idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),
                        Latitud = this.lati.Value,
                        Longitud = this.longi.Value,
                        calle = this.route.Value == string.Empty ? "" : this.route.Value,
                        coloni = this.colony.Value == string.Empty ? "" : this.colony.Value,
                        //   Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                        //   Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,
                        DelegacionID = buscardelega.DelegacionID,
                        RegionID = region.RegionID,
                        MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                        LocalidadID = new int?(Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                    });

                    ctx.TB_DatosGralReporte.Add(new TB_DatosGralReporte()
                    {
                        idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),

                        NombreLugar_Escuela = this.txtNombrelugar.Text == string.Empty ? "" : this.txtNombrelugar.Text.ToUpper(),
                        NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper(),
                        telcel = this.txttel.Text,

                    });


                    tbAuditoria audit = new tbAuditoria()
                    {
                        auditoriaGuid = new Guid?(Guid.NewGuid()),
                        fecha = new DateTime?(DateTime.Now),
                        area = this.txtArea.Text,
                        idTipomodificacion = new int?(1),
                        PagModificacion = this.Page.Title,
                        Descripcion = "Nuevo registro de reporte de actividades ,Fomento a la Prevención a través del Deporte la Cultura",
                        usuario = this.txtResponsable.Text,
                        IdABC = Convert.ToString((object)NuevoRegistros.idResumenDiario)
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
                    claveF = "FPDyC-DVI";
                    Guid id = Guid.Parse(Session["idresumen"].ToString());
                    var folio = ctx.sp_folio_actividad(id, claveF, extencion).ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "openGuardadoExito", "openGuardadoExito();", true);
                    HiddenField1.Value = null;
                    Session["actividades_fuera_tiempo"] = null;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "error();", true);

                }
            }
        }

        private bool ValidateVideoExtension(string nombreImg)
        {
            FileInfo info = new FileInfo(nombreImg);
            switch (info.Extension.ToLower())
            {
                case ".png":
                case ".PNG":
                case ".jpg":
                case ".JPG":
                case ".bmp":
                    return true;
                default:
                    return false;
            }
        }

        #region redimencionar_Imagen
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
            this.HiddenField1.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }
        #endregion

        #region*********DATA_BOUND DE LOS DROP PARA PONER LEYENDA
        protected void ddlAcciones_DataBound(object sender, EventArgs e)
        {
            this.ddlAcciones.Items.Insert(0, new ListItem("--Seleccione una acción--", "0"));

        }

        protected void ddlMuNICIPIO_DataBound(object sender, EventArgs e)
        {
            this.ddlMuNICIPIO.Items.Insert(0, new ListItem("--Seleccione un municipio--", "0"));
        }

        protected void ddlLocalidad_DataBound(object sender, EventArgs e)
        {
            this.ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));
        }
        #endregion

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
    }
}