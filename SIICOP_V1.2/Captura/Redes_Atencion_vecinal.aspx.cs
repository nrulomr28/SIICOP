using SIICOP_V1._2.Datos;
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
    public partial class Redes_Atencion_vecinal : System.Web.UI.Page
    {
        int personalID;
        int nino;
        int nina;
        int padresH;
        int padresM;
        int TotalA;
        // int DocentesH;
        // int DocentesM;
        // int EmpreH;
        // int EmpreM;
        // int AgreH;
        // int AgreM;
        // int CiudadanoH;
        // int CiudadanoM;
        // int ActoresH;
        // int ActoresM;
        // int PresiM;
        // int PresiH;
        // int otrosH;
        // int OtrosM;
        SIICOPEntities ctx = new SIICOPEntities();
        string sUsuarioActual;
        public enum AccionExpediente { Creacion, Edicion, Visualizacion }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("Cap_RVCPZ") || User.IsInRole("Admin_RVCPZ"))
                {
                    this.determinarAccion();

                }
                else
                {
                    this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
                }
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
        #region**** ACCIONES DE LOS DROP PARA PONER LEYENDA DE SELECCIONAR
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
        protected void ddlAmbito_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ambitos();
        }

        protected void Ambitos()
        {
            int MODE = Convert.ToInt32(ddlAmbito.SelectedValue);


            if (MODE == 1)
            {
                Escuela.Visible = true;


            }
            else
            {
                Escuela.Visible = false;
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
            if (ddlsubprograma.SelectedIndex == 0 || string.IsNullOrEmpty(ddlsubprograma.SelectedValue))
            {
                textoValidacion += "<li>Es obligatorio el Subprograma</li>";
                valido = false;
            }
            if (ddlAcciones.SelectedIndex == 0 || string.IsNullOrEmpty(ddlAcciones.SelectedValue))
            {
                textoValidacion += "<li>Es obligatorio seleccionar una acción</li>";
                valido = false;
            }
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
                //   DocentesH = 0;
                //DocentesM = 0;
                //PresiH = 0;
                //PresiM = 0;
                //EmpreH = 0;
                //EmpreM = 0;
                //AgreH = 0;
                //AgreM = 0;
                //CiudadanoH = 0;
                //CiudadanoM = 0;
                //ActoresH = 0;
                //ActoresM = 0;
                //personalID = 0;
                //otrosH = 0;
                //OtrosM = 0;
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
                    NuevoRegistros.programasID = 32;
                    NuevoRegistros.subprogramaId = new int?(this.ddlsubprograma.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlsubprograma.SelectedValue));
                    NuevoRegistros.AccionesID = new int?(this.ddlAcciones.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlAcciones.SelectedValue));
                    NuevoRegistros.descripcion_actividad = this.txtDescripcionActividad.Text == string.Empty ? "" : this.txtDescripcionActividad.Text.ToUpper();
                    NuevoRegistros.personal_atendio_actividad = this.txtpersonal_atendio_actividad.Text == string.Empty ? "" : this.txtpersonal_atendio_actividad.Text.ToUpper();

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
                        LocalidadID = new int?(Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                    });

                    TB_DatosGralReporte nuevoDatosGral = new TB_DatosGralReporte();
                    nuevoDatosGral.idResumenDiario = IdResumenGuid;
                    nuevoDatosGral.NombreLugar_Escuela = this.ddlnombreescuela.SelectedValue;
                    nuevoDatosGral.NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper();
                    nuevoDatosGral.telcel = this.txtTelefono.Text;
                    nuevoDatosGral.ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper();
                    nuevoDatosGral.Nivel = this.ddlNivel.SelectedValue;
                    nuevoDatosGral.Ambito = Convert.ToInt32(ddlAmbito.SelectedValue);


                    nuevoDatosGral.niñas = new int?(this.txnina.Value == "" ? 0 : Convert.ToInt32(this.txnina.Value));
                    nuevoDatosGral.niños = new int?(this.txnino.Value == "" ? 0 : Convert.ToInt32(this.txnino.Value));
                    nuevoDatosGral.hombres = new int?(this.txhombres.Value == "" ? 0 : Convert.ToInt32(this.txhombres.Value));
                    nuevoDatosGral.mujeres = new int?(this.txmujeres.Value == "" ? 0 : Convert.ToInt32(this.txmujeres.Value));





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
            //  TotalAtendidos = 0;
            // DocentesH = 0;
            //  DocentesM = 0;
            //  PresiH = 0;
            //  PresiM = 0;
            //   EmpreH = 0;
            //   EmpreM = 0;
            //   AgreH = 0;
            //   AgreM = 0;
            //   CiudadanoH = 0;
            //  CiudadanoM = 0;
            //   ActoresH = 0;
            //  ActoresM = 0;
            //  otrosH = 0;
            //   OtrosM = 0;
            int MODE = 0;
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
    }
}