using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Captura
{
    public partial class Captura_Dependencias : System.Web.UI.Page
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
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("Dependencias"))
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
                        if (!User.IsInRole("SysAdmin") && !User.IsInRole("Administrador") || User.IsInRole("Dependencias"))
                        {
                            //Response.Redirect("~/VistasReportes/VistaForosFerias.aspx");
                        }
                        break;
                    case (int)AccionExpediente.Edicion:

                        expediente_Edicion_Visualizacion();
                        break;

                }
            }
            else
            {
                sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                txtResponsable.Text = a.Nombre + " " + a.paterno + " " + a.materno;
                txtArea.Text = a.AreaTrabajo;
                dependencia.InnerText = a.Dependencia;
                lnkbtnGuardar.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('CREACIÓN DE UN NUEVO REPORTE')", true);
                return;


            }
            Session["idExpediente_Accion"] = null;
        }

        #region metodos de edicion y visualizar datos del reporte
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
            this.lnkbtnGuardarEdicion.Visible = true;
            this.lnkbtnSalir.Visible = true;
            Guid idReporte = idExpediente;
            Wv_DatosReportesHistorico reportesHistorico = ctx.Wv_DatosReportesHistorico.Find((object)idReporte);
            HiddenField1.Value = idReporte.ToString();

            this.txtResponsable.Text = reportesHistorico.nombrecompleto != null ? reportesHistorico.nombrecompleto : "";
            this.txtArea.Text = reportesHistorico.AreaTrabajo != null ? reportesHistorico.AreaTrabajo : "";
            this.txtFecha.Text = string.Format("{0:dd/MM/yyyy}", (object)reportesHistorico.fecha);
            ddlsubprograma.SelectedValue = reportesHistorico.subprogramaId != 0 ? reportesHistorico.subprogramaId.ToString() : "0";
            ddlsubprograma.DataBind();
            ddlAcciones.SelectedValue = reportesHistorico.AccionesID != 0 ? reportesHistorico.AccionesID.ToString().Trim() : "0";
            this.txtatendios.Text = reportesHistorico.total_atendidos.ToString();
            this.txtDescripcionActividad.Text = reportesHistorico.descripcion_actividad != null ? reportesHistorico.descripcion_actividad : "";
            this.txtpersonal_atendio_actividad.Text = reportesHistorico.personal_atendio_actividad != null ? reportesHistorico.personal_atendio_actividad : "";
            this.txttotlaHombres.Text = reportesHistorico.TotalHombresAtendidos != 0 ? reportesHistorico.TotalHombresAtendidos.ToString() : "0";
            this.txtmujer.Text = reportesHistorico.TotalMujeresAtendidas != 0 ? reportesHistorico.TotalMujeresAtendidas.ToString() : "0";
            this.txtatendios.Text = reportesHistorico.total_atendidos != 0 ? reportesHistorico.total_atendidos.ToString() : "0";


            tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idReporte).FirstOrDefault();
            if (direccionReporte != null)
            {
                this.HiddenField1.Value = Convert.ToString((object)idReporte);
                this.lati.Value = direccionReporte.Latitud != null ? direccionReporte.Latitud : "";
                this.longi.Value = direccionReporte.Longitud != null ? direccionReporte.Longitud : "";
                this.route.Value = direccionReporte.calle != null ? direccionReporte.calle : "";
                this.colony.Value = direccionReporte.coloni != null ? direccionReporte.coloni : "";
               // this.entrecalle1.Value = direccionReporte.Entrecalle1 != null ? direccionReporte.Entrecalle1 : "";
              //   this.entrecalle2.Value = direccionReporte.Entrecalle2 != null ? direccionReporte.Entrecalle2 : "";
                //ddlRegion.SelectedValue = direccionReporte.RegionID.ToString();
                //ddlDelegacion.SelectedValue = direccionReporte.DelegacionID != null ? direccionReporte.DelegacionID.ToString() : "0";
                ddlMuNICIPIO.SelectedValue = direccionReporte.MunicipioID.ToString().Trim();
                ddlMuNICIPIO.DataBind();
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
        #endregion

        #region######## sumar los beneficiados
        protected void txttotlaHombres_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalAles();
        }

        protected void txtmujer_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalAles();
        }
        protected void CalcularTotalAles()
        {
            try
            {
                int Hombre = 0;
                int Mujer = 0;
                if (this.txttotlaHombres.Text != "")
                {
                    Hombre = int.Parse(this.txttotlaHombres.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                }

                if (this.txtmujer.Text != "")
                {
                    Mujer = int.Parse(this.txtmujer.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                    this.txtatendios.Text = (Hombre + Mujer).ToString();
                }
            }
            catch (Exception ex)
            {
                this.CalcularTotalAles();
            }
        }
        #endregion

        #region *****BOTON DE GUARDADO DE LA NUEVA ACTIVIDAD
        protected void lnkbtnGuardar_Click(object sender, EventArgs e)
        {
            bool valido = true;
            string textoValidacion = "<ul>";
            if (string.IsNullOrEmpty(txtFecha.Text))
            {
                textoValidacion += "<li>Es obligatorio la fecha</li>";
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
            if (string.IsNullOrEmpty(txttotlaHombres.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados hombres en el caso de no contar con ello porner 0</li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtmujer.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados mujeres en el caso de no contar con ello porner 0 </li>";
                valido = false;
            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                lblValidacionesTxt.Text = textoValidacion;
                ScriptManager.RegisterStartupScript(this, GetType(), "openModalvalidador", "openModalvalidador();", true);
            }
            else
            {
                //va el codigo de guardado
                int area;
                sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var ID = ctx.Personales.Where(x => x.login == this.sUsuarioActual).FirstOrDefault();
                personalID = ID.Personalid;
                area = Convert.ToInt32(ID.cat_areaidarea);
                try
                {
                    tb_Reporte_Diario NuevoRegistros = new tb_Reporte_Diario();
                    NuevoRegistros.idResumenDiario = Guid.NewGuid();
                    NuevoRegistros.Personalid = personalID;
                    NuevoRegistros.fechacaptura = DateTime.Now;
                    NuevoRegistros.fecha = new DateTime?(Convert.ToDateTime(this.txtFecha.Text));
                    //NuevoRegistros.programasID = 13;
                    NuevoRegistros.subprogramaId = new int?(this.ddlsubprograma.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlsubprograma.SelectedValue));
                    NuevoRegistros.AccionesID = new int?(this.ddlAcciones.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlAcciones.SelectedValue));
                    NuevoRegistros.descripcion_actividad = this.txtDescripcionActividad.Text == string.Empty ? "" : this.txtDescripcionActividad.Text.ToUpper();
                    NuevoRegistros.personal_atendio_actividad = this.txtpersonal_atendio_actividad.Text == string.Empty ? "" : this.txtpersonal_atendio_actividad.Text.ToUpper();
                    NuevoRegistros.TotalHombresAtendidos = new int?(this.txttotlaHombres.Text == string.Empty ? 0 : Convert.ToInt32(this.txttotlaHombres.Text));
                    NuevoRegistros.TotalMujeresAtendidas = new int?(this.txtmujer.Text == string.Empty ? 0 : Convert.ToInt32(this.txtmujer.Text));
                    NuevoRegistros.total_atendidos = new int?(this.txtatendios.Text == string.Empty ? 0 : Convert.ToInt32(this.txtatendios.Text));
                    NuevoRegistros.capturaAPP = "NO";
                    //NuevoRegistros.DelegacionOcoonurbacion = coordinacion;

                    ctx.tb_Reporte_Diario.Add(NuevoRegistros);


                    int idMuni = Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue);
                    var buscardelega = ctx.Municipios.Where(p => p.MunicipioID == idMuni).FirstOrDefault();
                    ctx.tb_DireccionReporte.Add(new tb_DireccionReporte()
                    {
                        idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),
                        Latitud = this.lati.Value,
                        Longitud = this.longi.Value,
                        calle = this.route.Value == string.Empty ? "" : this.route.Value,
                        coloni = this.colony.Value == string.Empty ? "" : this.colony.Value,
                       // Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                      //  Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,

                        DelegacionID = buscardelega.DelegacionID,
                        RegionID = buscardelega.ZonaID,
                        //RegionID = new int?(this.ddlRegion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlRegion.SelectedValue)),
                        //DelegacionID = new int?(this.ddlDelegacion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlDelegacion.SelectedValue)),
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
                        Descripcion = "Nuevo registro de reporte de actividades",
                        usuario = this.txtResponsable.Text,
                        IdABC = Convert.ToString((object)NuevoRegistros.idResumenDiario)
                    };
                    ctx.tbAuditoria.Add(audit);

                    if (this.file.HasFile)
                    {
                        foreach (HttpPostedFile postedFile in (IEnumerable<HttpPostedFile>)this.file.PostedFiles)
                        {
                            string fileName = Path.GetFileName(postedFile.FileName);
                            string contentType = postedFile.ContentType;
                            using (Stream inputStream = postedFile.InputStream)
                            {
                                using (BinaryReader binaryReader = new BinaryReader(inputStream))
                                {
                                    byte[] numArray = binaryReader.ReadBytes((int)inputStream.Length);
                                    string base64String = Convert.ToBase64String(numArray);
                                    tb_fotografia foto = new tb_fotografia()
                                    {
                                        contentType = contentType,
                                        ImagenSubida = new DateTime?(DateTime.Now),
                                        FileName = fileName,
                                        //image = numArray,
                                        ImgBase64 = base64String

                                    };
                                    foto.idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario);
                                    ctx.tb_fotografia.Add(foto);
                                }
                            }
                        }
                    }

                    ctx.SaveChanges();
                    ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "redirect", "alert('Datos guardados con exito'); window.location='" + this.Request.ApplicationPath + "TotalAccionesBeneficiados.aspx';", true);
                    HiddenField1.Value = null;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('ERRO AL GUARDAR LOS DATOS')", true);

                }
            }
        }

        #endregion

        #region *******BOTON DE GUARDADO DE EDICIÓN DEL REPORTE
        protected void lnkbtnGuardarEdicion_Click(object sender, EventArgs e)
        {
            Guid idExpediente = Guid.Parse(HiddenField1.Value);
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
                    tbReporteDiario.TotalHombresAtendidos = new int?(this.txttotlaHombres.Text == string.Empty ? 0 : Convert.ToInt32(this.txttotlaHombres.Text));
                    tbReporteDiario.TotalMujeresAtendidas = new int?(this.txtmujer.Text == string.Empty ? 0 : Convert.ToInt32(this.txtmujer.Text));
                    tbReporteDiario.total_atendidos = new int?(this.txtatendios.Text == string.Empty ? 0 : Convert.ToInt32(this.txtatendios.Text));
                    tbReporteDiario.fechacaptura = new DateTime?(DateTime.Now);
                }

                int idMuni = Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue);
                var buscardelega = ctx.Municipios.Where(p => p.MunicipioID == idMuni).FirstOrDefault();
                tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
                if (direccionReporte != null)
                {
                    direccionReporte.Latitud = this.lati.Value;
                    direccionReporte.Longitud = this.longi.Value;
                    direccionReporte.calle = this.route.Value == string.Empty ? "" : this.route.Value;
                    direccionReporte.coloni = this.colony.Value == string.Empty ? "" : this.colony.Value;
                 //   direccionReporte.Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value;
                //    direccionReporte.Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value;
                    direccionReporte.DelegacionID = buscardelega.DelegacionID;
                    direccionReporte.RegionID = buscardelega.ZonaID;

                    //direccionReporte.RegionID = new int?(this.ddlRegion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlRegion.SelectedValue));
                    //direccionReporte.DelegacionID = new int?(this.ddlDelegacion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlDelegacion.SelectedValue));
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
                        RegionID = buscardelega.ZonaID,
                        //RegionID = new int?(this.ddlRegion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlRegion.SelectedValue)),
                        //DelegacionID = new int?(this.ddlDelegacion.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlDelegacion.SelectedValue)),
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


                if (this.file.HasFile)
                {
                    foreach (HttpPostedFile postedFile in (IEnumerable<HttpPostedFile>)this.file.PostedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        string contentType = postedFile.ContentType;
                        using (Stream inputStream = postedFile.InputStream)
                        {
                            using (BinaryReader binaryReader = new BinaryReader(inputStream))
                            {
                                byte[] numArray = binaryReader.ReadBytes((int)inputStream.Length);
                                string base64String = Convert.ToBase64String(numArray);

                                tb_fotografia foto = new tb_fotografia()
                                {
                                    contentType = contentType,
                                    ImagenSubida = new DateTime?(DateTime.Now),
                                    FileName = fileName,
                                    //image = numArray
                                    ImgBase64 = base64String

                                };
                                foto.idResumenDiario = idExpediente;
                                ctx.tb_fotografia.Add(foto);
                            }
                        }
                    }
                }
                ctx.SaveChanges();
                tbAuditoria entity = new tbAuditoria()
                {
                    auditoriaGuid = new Guid?(Guid.NewGuid()),
                    fecha = new DateTime?(DateTime.Now),
                    area = this.txtArea.Text,
                    idTipomodificacion = new int?(2),
                    PagModificacion = this.Page.Title,
                    Descripcion = "Se edito el registro de reporte de actividades",
                    usuario = this.txtResponsable.Text,
                    IdABC = Convert.ToString((object)idExpediente)
                };
                ctx.tbAuditoria.Add(entity);
                ctx.SaveChanges();
                this.HiddenField1.Value = (string)null;
                this.lnkbtnGuardarEdicion.Visible = false;
                this.lnkbtnSalir.Visible = false;
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

        #region #### items de los ddl al seleccionar 


        protected void ddlMuNICIPIO_DataBound(object sender, EventArgs e)
        {
            this.ddlMuNICIPIO.Items.Insert(0, new ListItem("--Seleccione un municipio--", "0"));
        }

        protected void ddlLocalidad_DataBound(object sender, EventArgs e)
        {
            this.ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));
        }

        #endregion

        protected void lnkbtnSalir_Click(object sender, EventArgs e)
        {
            this.Session["idExpediente_Accion"] = (object)null;
            this.Session["AccionExpediente"] = (object)null;
            this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
            this.HiddenField1.Value = (string)null;
            this.lnkbtnGuardarEdicion.Visible = false;
            this.lnkbtnSalir.Visible = false;
        }
    }
}