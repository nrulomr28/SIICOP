using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Captura.CVcMyCPC
{
    public partial class Reporte_Actividades_SESCESP : System.Web.UI.Page
    {
        public enum AccionReporte { Creacion, Edicion, Visualizacion }
        SIICOPEntities ctx = new SIICOPEntities();
        string sUsuarioActual;
        int nino;
        int nina;
        int padresH;
        int padresM;

        int EmpleadosH;
        int EmpleadosM;
        int CiudadanoH;
        int CiudadanoM;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("SESCESP"))
                {

                    this.determinarAccion();
                }
                else
                {
                    MembershipUser user = Membership.GetUser(false);
                    Membership.UpdateUser(user);
                    ctx.SaveChanges();
                    Session.Clear();
                    Session.Abandon();
                    FormsAuthentication.RedirectToLoginPage();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Inicio/Inicio.aspx");
                }
            }
        }

        #region ## DETERMINACION DEL FORMULAREO YA SEA CREACIÓN , EDICIÓN  Y Visualización
        protected void determinarAccion()
        {
            if (Session["idReporte_Accion"] != null && Session["AccionReporte"] != null)
            {
                AccionReporte accion = (AccionReporte)Session["AccionReporte"];
                switch ((int)accion)
                {
                    case (int)AccionReporte.Creacion:
                        if (Session["idPrograma_Accion"] != null)
                        {
                            int idPrograma = int.Parse(Session["idPrograma_Accion"].ToString());
                            Session["ProgramaId"] = idPrograma;
                            sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                            var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                            txtResponsable.Text = a.Nombre + " " + a.paterno + " " + a.materno;
                            txtArea.Text = a.AreaTrabajo;
                            lnkbtnGuardar.Visible = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "nuevoreporte", "nuevoreporte();", true);


                        }
                        else
                        {
                            this.Response.Redirect("~/MenuProgramas/SESCESP/Programas_SESCESP.aspx");
                        }
                        break;
                    case (int)AccionReporte.Edicion:
                        expediente_Edicion_Visualizacion();
                        break;
                        //case (int)AccionExpediente.Visualizacion:
                        //    expediente_Edicion_Visualizacion();
                        //    break;
                }
            }
            else
            {
                this.Response.Redirect("~/MenuProgramas/SESCESP/Programas_SESCESP.aspx");
            }
            Session["idExpediente_Accion"] = null;
        }

        protected void expediente_Edicion_Visualizacion()
        {
            if (Session["idReporte_Accion"] != null)
            {
                try
                {
                    Guid idExpediente = Guid.Parse(Session["idReporte_Accion"].ToString());
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
            ScriptManager.RegisterStartupScript(this, GetType(), "edicion", "edicion();", true);
            this.btnGuardarEdicion.Visible = true;
            this.btnSalir.Visible = true;
            Session["accion"] = null;
            Session["pro"] = null;
            Session["subprogra"] = null;
            Guid idReporte = idExpediente;
            // Wv_DatosReportesHistorico es una vista de informacion 

            Wv_DatosReportesHistorico reportesHistorico = ctx.Wv_DatosReportesHistorico.Where(g => g.idResumenDiario == idReporte).FirstOrDefault();
            if (reportesHistorico != null)
            {
                HiddenField1.Value = idReporte.ToString();
                this.txtResponsable.Text = reportesHistorico.nombrecompleto != null ? reportesHistorico.nombrecompleto : "";
                this.txtArea.Text = reportesHistorico.AreaTrabajo != null ? reportesHistorico.AreaTrabajo : "";
                this.txtFecha.Text = string.Format("{0:dd/MM/yyyy}", (object)reportesHistorico.fecha);
                Session["subpro"] = reportesHistorico.subprogramaId;
                ddlsubprograma.SelectedValue = Convert.ToInt32(Session["subpro"]).ToString();
                ddlsubprograma.DataBind();

                Session["accion"] = reportesHistorico.AccionesID;
                ddlAcciones.SelectedValue = Convert.ToInt32(Session["accion"]).ToString();
                ddlAcciones.DataBind();

                this.txtatendios.Text = reportesHistorico.total_atendidos.ToString();
                this.txtDescripcionActividad.Text = reportesHistorico.descripcion_actividad != null ? reportesHistorico.descripcion_actividad : "";
                this.txtpersonal_atendio_actividad.Text = reportesHistorico.personal_atendio_actividad != null ? reportesHistorico.personal_atendio_actividad : "";

                this.txtatendios.Text = reportesHistorico.total_atendidos != 0 ? reportesHistorico.total_atendidos.ToString() : "0";
            }
            //// tb_DireccionReporte  es donde se guarda la informacion de las direcciones de google de cada captura. 
            tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idReporte).FirstOrDefault();
            if (direccionReporte != null)
            {
                this.HiddenField1.Value = Convert.ToString((object)idReporte);
                this.lati.Value = direccionReporte.Latitud != null ? direccionReporte.Latitud : "";
                this.longi.Value = direccionReporte.Longitud != null ? direccionReporte.Longitud : "";
                this.route.Value = direccionReporte.calle != null ? direccionReporte.calle : "";
                this.colony.Value = direccionReporte.coloni != null ? direccionReporte.coloni : "";
              //  this.entrecalle1.Value = direccionReporte.Entrecalle1 != null ? direccionReporte.Entrecalle1 : "";
              //  this.entrecalle2.Value = direccionReporte.Entrecalle2 != null ? direccionReporte.Entrecalle2 : "";
                ddlMuNICIPIO.DataBind();
                ddlMuNICIPIO.SelectedValue = direccionReporte.MunicipioID.ToString().Trim();
                ddlLocalidad.SelectedValue = direccionReporte.LocalidadID != null ? direccionReporte.LocalidadID.ToString() : "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "VerDireccionMapa", "VerDireccionMapa();", true);
            }

            TB_DatosGralReporte datosGralReporte = ctx.TB_DatosGralReporte.Where(t => t.idResumenDiario == idReporte).FirstOrDefault();
            if (datosGralReporte != null)
            {

                this.txtnombreescuela.Text = datosGralReporte.NombreLugar_Escuela != null ? datosGralReporte.NombreLugar_Escuela : "";
                this.txtnombrecontacto.Text = datosGralReporte.NombreContacto != null ? datosGralReporte.NombreContacto : "";
                this.txtTelefono.Text = datosGralReporte.telcel != null ? datosGralReporte.telcel : "";

                if (datosGralReporte.MuniSItuaVulnera.Value == true)
                { RDMSVSI.Checked = true; }
                else { this.RDMSVNO.Checked = true; }

                if (datosGralReporte.MuniAlerGene.Value == true)
                { RDMAGSI.Checked = true; }
                else { this.RDMAGNO.Checked = true; }

                if (datosGralReporte.PoblaIndi.Value == true)
                { RDPPISI.Checked = true; }
                else { this.RDPPINO.Checked = true; }


                if (datosGralReporte.Munidelic.Value == true)
                { RDMSIIDSI.Checked = true; }
                else { this.RDMSIIDNO.Checked = true; }


                txtnina.Value = datosGralReporte.niñas != 0 ? datosGralReporte.niñas.ToString() : "0";
                txtnino.Value = datosGralReporte.niños != 0 ? datosGralReporte.niños.ToString() : "0";
                txthombres.Value = datosGralReporte.hombres != 0 ? datosGralReporte.hombres.ToString() : "0";
                txtmujeres.Value = datosGralReporte.mujeres != 0 ? datosGralReporte.mujeres.ToString() : "0";

                txtEmpleadasH.Value = datosGralReporte.EmpreH != 0 ? datosGralReporte.EmpreH.ToString() : "0";
                txtEmpleadasM.Value = datosGralReporte.EmpreM != 0 ? datosGralReporte.EmpreM.ToString() : "0";
                txtCiudadanosH.Value = datosGralReporte.CiudadanoH != 0 ? datosGralReporte.CiudadanoH.ToString() : "0";
                txtCiudadanosM.Value = datosGralReporte.CiudadanoM != 0 ? datosGralReporte.CiudadanoM.ToString() : "0";

            }

        }
        #endregion

        #region METODO PARA LOS DROP
        protected void ddlMuNICIPIO_DataBound(object sender, EventArgs e)
        {
            this.ddlMuNICIPIO.Items.Insert(0, new ListItem("--Seleccione un municipio--", "0"));
        }

        protected void ddlLocalidad_DataBound(object sender, EventArgs e)
        {
            this.ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione una localidad--", "0"));
        }

        protected void ddlAcciones_DataBound(object sender, EventArgs e)
        {
            this.ddlAcciones.Items.Insert(0, new ListItem("--Seleccione una acción--", "0"));
        }

        #endregion


        #region BOTON PARA GUARDAR REPORTE
        protected void lnkbtnGuardar_Click(object sender, EventArgs e)
        {
            string claveF = "";
            int idPrograma = int.Parse(Session["idPrograma_Accion"].ToString());
            nino = 0;
            nina = 0;
            padresH = 0;
            padresM = 0;

            EmpleadosH = 0;
            EmpleadosM = 0;
            CiudadanoH = 0;
            if (idPrograma == 27)
            {
                claveF = "EC-CMSPyCPC-SESCESP";
            }
            if (idPrograma == 28)
            {
                claveF = "VIC-SESCESP";
            }


            bool valido = true;
            string textoValidacion = "<ul>";
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

            if (string.IsNullOrEmpty(txtnombreescuela.Text))
            {
                textoValidacion += "<li>Es obligatorio ingresar la esceula donde ralizaron la actividad </li>";
                txtnombreescuela.Focus();
                txtnombreescuela.BorderColor = System.Drawing.Color.Red;
                valido = false;
            }
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
            if (string.IsNullOrEmpty(txtnino.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados niños en el caso de no contar con ello porner 0</li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtnina.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados niñas en el caso de no contar con ello porner 0 </li>";
                valido = false;
            }


            if (string.IsNullOrEmpty(txthombres.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados padre de familia en el caso de no contar con ello porner 0</li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtmujeres.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados madre de familia en el caso de no contar con ello porner 0 </li>";
                valido = false;
            }

            if (string.IsNullOrEmpty(txtEmpleadasH.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados empleados hombres en el caso de no contar con ello porner 0</li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtEmpleadasM.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados empleados mujeres en el caso de no contar con ello porner 0 </li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtCiudadanosH.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados ciudadanos hombres en el caso de no contar con ello porner 0</li>";
                valido = false;
            }
            if (string.IsNullOrEmpty(txtCiudadanosM.Value))
            {
                textoValidacion += "<li>Es obligatorio ingresar los beneficiados ciudadanos mujeres en el caso de no contar con ello porner 0 </li>";
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

                string coordinacion = "CONURBACION XALAPA XX";
                sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                var ID = ctx.Personales.Where(x => x.login == this.sUsuarioActual).FirstOrDefault();
                int personalID = ID.Personalid;
                int area = Convert.ToInt32(ID.cat_areaidarea);



                try
                {

                    tb_Reporte_Diario NuevoRegistros = new tb_Reporte_Diario();
                    NuevoRegistros.idResumenDiario = Guid.NewGuid();
                    NuevoRegistros.Personalid = personalID;
                    NuevoRegistros.fechacaptura = DateTime.Now;
                    NuevoRegistros.fecha = new DateTime?(Convert.ToDateTime(this.txtFecha.Text));
                    NuevoRegistros.programasID = idPrograma;
                    NuevoRegistros.subprogramaId = new int?(this.ddlsubprograma.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlsubprograma.SelectedValue));
                    NuevoRegistros.AccionesID = new int?(this.ddlAcciones.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlAcciones.SelectedValue));
                    NuevoRegistros.descripcion_actividad = this.txtDescripcionActividad.Text == string.Empty ? "" : this.txtDescripcionActividad.Text.ToUpper();
                    NuevoRegistros.personal_atendio_actividad = this.txtpersonal_atendio_actividad.Text == string.Empty ? "" : this.txtpersonal_atendio_actividad.Text.ToUpper();

                    if (this.txtnino.Value != "") { nino = int.Parse(txtnino.Value); }
                    if (this.txthombres.Value != "") { padresH = int.Parse(txthombres.Value); }
                    if (this.txtEmpleadasH.Value != "") { EmpleadosH = int.Parse(txtEmpleadasH.Value); }
                    if (this.txtCiudadanosH.Value != "") { CiudadanoH = int.Parse(txtCiudadanosH.Value); }

                    if (this.txtnina.Value != "") { nina = int.Parse(txtnina.Value); }
                    if (this.txtmujeres.Value != "") { padresM = int.Parse(txtmujeres.Value); }
                    if (this.txtEmpleadasM.Value != "") { EmpleadosM = int.Parse(txtEmpleadasM.Value); }
                    if (this.txtCiudadanosM.Value != "") { CiudadanoM = int.Parse(txtCiudadanosM.Value); }

                    int Hombres = nino + padresH + EmpleadosH + CiudadanoH;
                    int Mujeres = nina + padresM + EmpleadosM + CiudadanoM;

                    NuevoRegistros.TotalHombresAtendidos = new int?(Hombres);
                    NuevoRegistros.TotalMujeresAtendidas = new int?(Mujeres);

                    int totalBeneficiados = Hombres + Mujeres;
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
                    //    Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                    //    Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,
                        DelegacionID = buscardelega.DelegacionID,
                        RegionID = region.RegionID,
                        MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                        LocalidadID = new int?(Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                    });


                    ctx.TB_DatosGralReporte.Add(new TB_DatosGralReporte()
                    {
                        idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),

                        NombreLugar_Escuela = this.txtnombreescuela.Text == string.Empty ? "" : this.txtnombreescuela.Text.ToUpper(),
                        NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper(),
                        telcel = this.txtTelefono.Text,
                        niñas = new int?(this.txtnina.Value == "" ? 0 : Convert.ToInt32(this.txtnina.Value)),
                        niños = new int?(this.txtnino.Value == "" ? 0 : Convert.ToInt32(this.txtnino.Value)),
                        hombres = new int?(this.txthombres.Value == "" ? 0 : Convert.ToInt32(this.txthombres.Value)),
                        mujeres = new int?(this.txtmujeres.Value == "" ? 0 : Convert.ToInt32(this.txtmujeres.Value)),

                        EmpreH = new int?(this.txtEmpleadasH.Value == "" ? 0 : Convert.ToInt32(this.txtEmpleadasH.Value)),
                        EmpreM = new int?(this.txtEmpleadasM.Value == "" ? 0 : Convert.ToInt32(this.txtEmpleadasM.Value)),
                        CiudadanoH = new int?(this.txtCiudadanosH.Value == "" ? 0 : Convert.ToInt32(this.txtCiudadanosH.Value)),
                        CiudadanoM = new int?(this.txtCiudadanosM.Value == "" ? 0 : Convert.ToInt32(this.txtCiudadanosM.Value)),

                        MuniSItuaVulnera = RDMSVSI.Checked == true ? true : false,
                        MuniAlerGene = RDMAGSI.Checked == true ? true : false,
                        PoblaIndi = RDPPISI.Checked == true ? true : false,
                        Munidelic = RDMSIIDSI.Checked == true ? true : false,


                    });

                    string extencion = "";
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
                                    extencion = System.IO.Path.GetExtension(postedFile.FileName);

                                    tb_fotografia foto = new tb_fotografia()
                                    {
                                        contentType = contentType,
                                        ImagenSubida = new DateTime?(DateTime.Now),
                                        FileName = fileName,
                                        //image = numArray
                                        ImgBase64 = base64String,
                                        ImagenExtencion = extencion


                                    };
                                    foto.idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario);
                                    ctx.tb_fotografia.Add(foto);
                                }
                            }
                        }
                    }


                    tbAuditoria audit = new tbAuditoria()
                    {
                        auditoriaGuid = new Guid?(Guid.NewGuid()),
                        fecha = new DateTime?(DateTime.Now),
                        area = this.txtArea.Text,
                        idTipomodificacion = new int?(1),
                        PagModificacion = this.Page.Title,
                        Descripcion = "Nuevo registro de reporte de actividades SESCESP",
                        usuario = this.txtResponsable.Text,
                        IdABC = Convert.ToString((object)NuevoRegistros.idResumenDiario)
                    };
                    ctx.tbAuditoria.Add(audit);
                    ctx.SaveChanges();
                    Guid id = Guid.Parse(Session["idresumen"].ToString());
                    var folio = ctx.sp_folio_actividad(id, claveF, extencion).ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "openGuardadoExito", "openGuardadoExito();", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "error();", true);

                }
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
            this.Session["idReporte_Accion"] = (object)null;
            this.Session["AccionReporte"] = (object)null;
            this.Session["idPrograma_Accion"] = (object)null;
            this.Session["ProgramaId"] = (object)null;
            Session["accion"] = null;
            Session["pro"] = null;
            Session["subprogra"] = null;
            this.Response.Redirect("~/VistasReportes/CVcMyCPC/Vista_de_datos_SESCESP.aspx");
            this.HiddenField1.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }
        #endregion

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            this.Session["idReporte_Accion"] = (object)null;
            this.Session["AccionReporte"] = (object)null;
            this.Session["idPrograma_Accion"] = (object)null;
            this.Session["ProgramaId"] = (object)null;
            Session["accion"] = null;
            Session["pro"] = null;
            Session["subprogra"] = null;
            this.Response.Redirect("~/Bienvenido_CVcMyCPC.aspx");
            this.HiddenField1.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }


        #region select para seleccionar las acciones del subprograma
        protected void ddlsubprograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int subr = Convert.ToInt32(this.ddlsubprograma.SelectedValue);
            var subrbus = ctx.Cat_Acciones.Where(o => o.subprogramaId == subr).FirstOrDefault();
            Session["pro"] = null;
            Session["subprogra"] = null;
            if (subrbus != null)
            {

                Session["subprogra"] = Convert.ToInt32(subrbus.subprogramaId);
                ddlAcciones.DataBind();
            }
            else
            {
                int idPrograma = int.Parse(Session["idPrograma_Accion"].ToString());
                Session["pro"] = idPrograma;
                ddlAcciones.DataBind();
            }

        }
        #endregion
    }
}