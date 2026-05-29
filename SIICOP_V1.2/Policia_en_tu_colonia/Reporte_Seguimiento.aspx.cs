using OfficeOpenXml;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Policia_en_tu_colonia
{


    public partial class Reporte_Seguimiento : System.Web.UI.Page
    {
        private static DataTable dtPrincipal;
        int personalID;
        int TotalAtendidos;
        int nino;
        int nina;
        int padresH;
        int padresM;
        SIICOPEntities ctx = new SIICOPEntities();


        public enum AccionExpediente { Creacion, Edicion, Visualizacion }

        string sUsuarioActual;
        private int b;
        private int foliooo;
        Guid folioEditar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Cap_Policiac"))
                {
                    this.contadorregistros();

                }
                else
                {
                    ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "redirect", "alert('NO TIENES LOS PERMISOS NECESARIOS PARA INGRESAR A LA PÁGINA'); window.location='" + this.Request.ApplicationPath + "TotalAccionesBeneficiados.aspx';", true);

                    //this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
                }
            }
        }

        #region DATOS DE CAPTURA, VISTA ,REPORTES , EDITAR DE FORMULARIO DE PETICIONES
        private void FolioReporte()
        {
            DataSet dataSet = new DataSet();
            int num1 = (int)dataSet.ReadXml(this.Server.MapPath("~/Inicio/Countter.xml"));
            int num2 = int.Parse(dataSet.Tables[0].Rows[0]["hits"].ToString()) + 1;
            dataSet.Tables[0].Rows[0]["hits"] = (object)num2.ToString();
            dataSet.WriteXml(this.Server.MapPath("~/Inicio/Countter.xml"));
            this.Session["foliooo"] = (object)num2.ToString();
            this.foliorest.Text = num2.ToString();
        }

        private void FolioReportecancelar()
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(Server.MapPath("~/Account/Countter.xml"));
            int hits = Int32.Parse(dataSet.Tables[0].Rows[0]["hits"].ToString());

            hits -= 1;

            dataSet.Tables[0].Rows[0]["hits"] = hits.ToString();

            dataSet.WriteXml(Server.MapPath("~/Account/Countter.xml"));
        }


        protected void gvPeticiones_DataBound(object sender, EventArgs e)
        {
            try
            {
                // Recupera la el PagerRow...
                GridViewRow pagerRow = gvPeticiones.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabel");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= gvPeticiones.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == gvPeticiones.PageIndex)
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
                    int currentPage = gvPeticiones.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + gvPeticiones.PageCount.ToString();

                }

            }
            catch
            {
            }
        }

        protected void gvPeticiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    this.Session["AccionExpediente"] = (object)AccionExpediente.Edicion;
                    Guid folio = Guid.Parse(numFila.ToString());
                    this.Session["folioEditar"] = (object)folio;
                    tc_PoliciaenTucolonia policiaenTucolonia = this.ctx.tc_PoliciaenTucolonia.Where(x => x.IdCaptura == folio).FirstOrDefault();
                    int? nullable1;
                    if (policiaenTucolonia != null)
                    {
                        this.foliorest.Text = Convert.ToString((object)policiaenTucolonia.Folio);
                        DropDownList ddlMunicipio = this.ddlMunicipio;
                        nullable1 = policiaenTucolonia.IdMunicipio;
                        string str1 = nullable1.ToString();
                        ddlMunicipio.SelectedValue = str1;
                        DropDownList ddlPrioridaD = this.ddlPrioridaD;
                        nullable1 = policiaenTucolonia.IdPrioridad;
                        string str2 = nullable1.ToString();
                        ddlPrioridaD.SelectedValue = str2;
                        this.ddlEstatus.SelectedValue = policiaenTucolonia.Estatus.ToString();
                    }
                    tc_Seguimiento tcSeguimiento = this.ctx.tc_Seguimiento.Where(r => r.IdCaptura == (Guid?)folio).FirstOrDefault();
                    if (tcSeguimiento != null)
                    {
                        this.txtNombreCIudadano.Text = tcSeguimiento.NombreCompleto;
                        this.txtEdad.Text = Convert.ToString((object)tcSeguimiento.edad);
                        this.txtCalle.Text = tcSeguimiento.calle != null ? tcSeguimiento.calle : "";
                        this.txtFechaDenunciaDato.Text = string.Format("{0:dd/MM/yyyy}", (object)tcSeguimiento.fechaRepor);
                        this.txtReferencia.Text = tcSeguimiento.Referencia;
                        ddlCuadrante.Items.Clear();
                        this.ddlColonia.SelectedValue = tcSeguimiento.Colonia.ToString();
                        this.ddlCuadrante.SelectedValue = tcSeguimiento.IdCuadrante.ToString();
                        this.txtCorreoCiudadano.Text = tcSeguimiento.Correo;
                        this.txtTelefono.Text = tcSeguimiento.telefono;
                    }
                    tcProblematicaSeguridad problematicaSeguridad = this.ctx.tcProblematicaSeguridad.Where(t => t.IdCaptura == (Guid?)folio).FirstOrDefault();
                    bool? nullable2;
                    if (problematicaSeguridad != null)
                    {
                        this.rdAplicaSEGU.Checked = true;
                        this.robo.Checked = problematicaSeguridad.Robos.Value;
                        this.homicidios.Checked = problematicaSeguridad.Homicidios.Value;
                        CheckBox consumos = this.consumos;
                        nullable2 = problematicaSeguridad.ConsumoAlcohol;
                        int num1 = nullable2.Value ? 1 : 0;
                        consumos.Checked = num1 != 0;
                        CheckBox pandillerismo = this.pandillerismo;
                        nullable2 = problematicaSeguridad.Pandillerismo;
                        int num2 = nullable2.Value ? 1 : 0;
                        pandillerismo.Checked = num2 != 0;
                        CheckBox grafiti = this.grafiti;
                        nullable2 = problematicaSeguridad.Grafitis;
                        int num3 = nullable2.Value ? 1 : 0;
                        grafiti.Checked = num3 != 0;
                        CheckBox narcomenudeo = this.narcomenudeo;
                        nullable2 = problematicaSeguridad.Narcomenudeo;
                        int num4 = nullable2.Value ? 1 : 0;
                        narcomenudeo.Checked = num4 != 0;
                        CheckBox cristalazo = this.cristalazo;
                        nullable2 = problematicaSeguridad.Cristalazos;
                        int num5 = nullable2.Value ? 1 : 0;
                        cristalazo.Checked = num5 != 0;
                        CheckBox conflictosvecinales = this.conflictosvecinales;
                        nullable2 = problematicaSeguridad.ConflictosVecinales;
                        int num6 = nullable2.Value ? 1 : 0;
                        conflictosvecinales.Checked = num6 != 0;
                        CheckBox conflictosescuelass = this.conflictosescuelass;
                        nullable2 = problematicaSeguridad.conflictosescuelas;
                        int num7 = nullable2.Value ? 1 : 0;
                        conflictosescuelass.Checked = num7 != 0;
                        this.txtubicacionsegur.Text = problematicaSeguridad.ubicacionseguridad;
                        this.txtEspecifiqueSeguridad.Text = problematicaSeguridad.Especifique;
                    }
                    else
                        this.rdNoapliSEGU.Checked = true;
                    tcProblematicaVialidad problematicaVialidad = this.ctx.tcProblematicaVialidad.Where(z => z.IdCaptura == (Guid?)folio).FirstOrDefault();
                    if (problematicaVialidad != null)
                    {
                        this.rdbVialiapli.Checked = true;
                        CheckBox autosmace = this.autosmace;
                        nullable2 = problematicaVialidad.AutosMacetas;
                        int num1 = nullable2.Value ? 1 : 0;
                        autosmace.Checked = num1 != 0;
                        CheckBox reductores = this.reductores;
                        nullable2 = problematicaVialidad.FaltaReductoresVelocidad;
                        int num2 = nullable2.Value ? 1 : 0;
                        reductores.Checked = num2 != 0;
                        CheckBox autosdobles = this.autosdobles;
                        nullable2 = problematicaVialidad.AutosDobleCarril;
                        int num3 = nullable2.Value ? 1 : 0;
                        autosdobles.Checked = num3 != 0;
                        CheckBox convehi = this.convehi;
                        nullable2 = problematicaVialidad.congestionvehicular;
                        int num4 = nullable2.Value ? 1 : 0;
                        convehi.Checked = num4 != 0;
                        CheckBox faltadeseñales = this.faltadeseñales;
                        nullable2 = problematicaVialidad.FaltaSeñalizaciones;
                        int num5 = nullable2.Value ? 1 : 0;
                        faltadeseñales.Checked = num5 != 0;
                        CheckBox otro = this.otro;
                        nullable2 = problematicaVialidad.otros;
                        int num6 = nullable2.Value ? 1 : 0;
                        otro.Checked = num6 != 0;
                    }
                    else
                        this.rdbvialiNoapli.Checked = true;
                    tcProblematicaMunicipal problematicaMunicipal = this.ctx.tcProblematicaMunicipal.Where(n => n.IdCaptura == (Guid?)folio).FirstOrDefault();
                    if (problematicaMunicipal != null)
                    {
                        this.rdbAplicaMuni.Checked = true;
                        CheckBox limpiapublica = this.limpiapublica;
                        nullable2 = problematicaMunicipal.LimpiaPublicaDeficiente;
                        int num1 = nullable2.Value ? 1 : 0;
                        limpiapublica.Checked = num1 != 0;
                        CheckBox alumbradoi = this.alumbradoi;
                        nullable2 = problematicaMunicipal.FaltaAlumbradoPublico;
                        int num2 = nullable2.Value ? 1 : 0;
                        alumbradoi.Checked = num2 != 0;
                        CheckBox parques = this.parques;
                        nullable2 = problematicaMunicipal.ParquesJardinesEnDeterioro;
                        int num3 = nullable2.Value ? 1 : 0;
                        parques.Checked = num3 != 0;
                        CheckBox drenaje = this.drenaje;
                        nullable2 = problematicaMunicipal.DrenajeExpuesto;
                        int num4 = nullable2.Value ? 1 : 0;
                        drenaje.Checked = num4 != 0;
                        CheckBox animales = this.animales;
                        nullable2 = problematicaMunicipal.AnimalesCallejero;
                        int num5 = nullable2.Value ? 1 : 0;
                        animales.Checked = num5 != 0;
                        CheckBox abulantaje = this.abulantaje;
                        nullable2 = problematicaMunicipal.Ambulantaje;
                        int num6 = nullable2.Value ? 1 : 0;
                        abulantaje.Checked = num6 != 0;
                        CheckBox fugaAgua = this.fugaAgua;
                        nullable2 = problematicaMunicipal.FugaAguaPotable;
                        int num7 = nullable2.Value ? 1 : 0;
                        fugaAgua.Checked = num7 != 0;
                        CheckBox coladeras = this.coladeras;
                        nullable2 = problematicaMunicipal.ColaderasTapadas;
                        int num8 = nullable2.Value ? 1 : 0;
                        coladeras.Checked = num8 != 0;
                        CheckBox montemaleza = this.montemaleza;
                        nullable2 = problematicaMunicipal.MonteMaleza;
                        int num9 = nullable2.Value ? 1 : 0;
                        montemaleza.Checked = num9 != 0;
                        this.txtEspecifiqueMuni.Text = problematicaMunicipal.Especifique;
                        this.txtUbicacionMuni.Text = problematicaMunicipal.Ubicacion;
                    }
                    else
                        this.rdbNoapliMuni.Checked = true;
                    tcPeticionCiudadana peticionCiudadana = this.ctx.tcPeticionCiudadana.Where(v => v.IdCaptura == (Guid?)folio).FirstOrDefault();
                    if (peticionCiudadana != null)
                    {
                        nullable1 = peticionCiudadana.seguridadcolonia;
                        int num1 = 1;
                        if (nullable1.GetValueOrDefault() == num1 & nullable1.HasValue)
                            this.rbseguro.Checked = true;
                        nullable1 = peticionCiudadana.seguridadcolonia;
                        int num2 = 2;
                        if (nullable1.GetValueOrDefault() == num2 & nullable1.HasValue)
                            this.rbinseguro.Checked = true;
                        nullable1 = peticionCiudadana.seguridadcolonia;
                        int num3 = 3;
                        if (nullable1.GetValueOrDefault() == num3 & nullable1.HasValue)
                            this.rbnoseguro.Checked = true;
                        this.txtCasaseuri.Text = Convert.ToString((object)peticionCiudadana.casa);
                        this.txtEscuela.Text = Convert.ToString((object)peticionCiudadana.escuela);
                        this.txttrasporte.Text = Convert.ToString((object)peticionCiudadana.TransportePublico);
                        this.txtcentro.Text = Convert.ToString((object)peticionCiudadana.centrocomercial);
                        this.txtparque.Text = Convert.ToString((object)peticionCiudadana.Parques);
                        this.txttrabajo.Text = Convert.ToString((object)peticionCiudadana.trabajo);
                        this.txtcalleseguri.Text = Convert.ToString((object)peticionCiudadana.calle);
                        this.txtbanco.Text = Convert.ToString((object)peticionCiudadana.banco);
                        this.txtauto.Text = Convert.ToString((object)peticionCiudadana.automovil);
                        this.txtcajero.Text = Convert.ToString((object)peticionCiudadana.cajeroauto);
                        this.txtcarretera.Text = Convert.ToString((object)peticionCiudadana.carretera);
                        nullable2 = peticionCiudadana.protebentrevecinos;
                        if (nullable2.Value)
                            this.rbproblesi.Checked = true;
                        else
                            this.rbprobleno.Checked = true;
                        nullable2 = peticionCiudadana.victima_delito;
                        if (nullable2.Value)
                            this.rbVictimasi.Checked = true;
                        else
                            this.rbVictimano.Checked = true;
                        this.txtanodeli.Text = peticionCiudadana.ano;
                        this.txtcualfuedelito.Text = peticionCiudadana.cualfuedelito;
                        nullable2 = peticionCiudadana.conocelosprogramasdgvi;
                        if (nullable2.Value)
                            this.rbprogrmadgviSI.Checked = true;
                        else
                            this.rbprogrmadgviNO.Checked = true;
                        CheckBox chkescuelasegu = this.chkescuelasegu;
                        nullable2 = peticionCiudadana.escuelasegura;
                        int num4 = nullable2.Value ? 1 : 0;
                        chkescuelasegu.Checked = num4 != 0;
                        CheckBox chkredesveci = this.chkredesveci;
                        nullable2 = peticionCiudadana.redesvecinales;
                        int num5 = nullable2.Value ? 1 : 0;
                        chkredesveci.Checked = num5 != 0;
                        CheckBox chkdeportivocultu = this.chkdeportivocultu;
                        nullable2 = peticionCiudadana.fomentodeportivo;
                        int num6 = nullable2.Value ? 1 : 0;
                        chkdeportivocultu.Checked = num6 != 0;
                        CheckBox chkciolenciamujer = this.chkciolenciamujer;
                        nullable2 = peticionCiudadana.prevencionvm;
                        int num7 = nullable2.Value ? 1 : 0;
                        chkciolenciamujer.Checked = num7 != 0;
                        CheckBox chkempresarial = this.chkempresarial;
                        nullable2 = peticionCiudadana.empresasegura;
                        int num8 = nullable2.Value ? 1 : 0;
                        chkempresarial.Checked = num8 != 0;
                        CheckBox chklimpiezapubli = this.chklimpiezapubli;
                        nullable2 = peticionCiudadana.limpiezaespaciospubli;
                        int num9 = nullable2.Value ? 1 : 0;
                        chklimpiezapubli.Checked = num9 != 0;
                        this.txtcualessonculeslesguataria.Text = peticionCiudadana.cualesonfehcahoralugar;
                        this.txtpeticion.Text = peticionCiudadana.observacionpropuesta;
                        this.txtOficialuno.Text = peticionCiudadana.oficial1;
                        this.txtdisitntivoOfiuno.Text = peticionCiudadana.distintivo1;
                        this.txtOficialdos.Text = peticionCiudadana.oficial2;
                        this.txtdisitintivoOfi2.Text = peticionCiudadana.distintivo2;
                    }
                    ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "myModalImgArchivos", "openModal();", true);
                }
            }
        }

        protected void gvPeticiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[6].Text.Equals("Inicio"))
                {
                    e.Row.Cells[6].Attributes["class"] = "label label-danger";
                }
                if (e.Row.Cells[6].Text.Equals("En Proceso"))
                {
                    e.Row.Cells[6].Attributes["class"] = "label label-warning";
                }
                if (e.Row.Cells[6].Text.Equals("Finalizada"))
                {
                    e.Row.Cells[6].Attributes["class"] = "label label-success";
                }
                if (e.Row.Cells[6].Text.Equals("Cancelada"))
                {
                    e.Row.Cells[6].Attributes["class"] = "label label-default";
                }
                if (e.Row.Cells[5].Text.Equals("1"))
                {
                    e.Row.Cells[5].Text = "Inmediata";
                }
                if (e.Row.Cells[5].Text.Equals("2"))
                {
                    e.Row.Cells[5].Text = "Medio";
                }
                if (e.Row.Cells[5].Text.Equals("3"))
                {
                    e.Row.Cells[5].Text = "Baja";
                }

            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                GridViewRow pagerRow = gvPeticiones.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                gvPeticiones.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...
                //lblInfo.Text = "";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Session["AccionExpediente"] = (object)null;
            this.Session["folioEditar"] = (object)null;
            ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "myModalImgArchivos", "closeModal();", true);
            Response.Redirect("~/Policia_en_tu_colonia/Reporte_Seguimiento.aspx");

        }

        protected void IbtnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Session["AccionExpediente"] != null)
            {
                AccionExpediente accion = (AccionExpediente)Session["AccionExpediente"];

                switch ((int)accion)
                {
                    case (int)AccionExpediente.Creacion:

                        this.sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;

                        this.GuardaRegistro();

                        break;
                    case (int)AccionExpediente.Edicion:
                        this.GuardarEdicion(Guid.Parse(this.Session["folioEditar"].ToString()));
                        break;
                        //case (int)AccionExpediente.Visualizacion:
                        //    expediente_Edicion_Visualizacion();
                        //    break;
                }
            }

        }
        protected void GuardaRegistro()
        {
            this.FolioReporte();
            this.foliooo = Convert.ToInt32(this.Session["foliooo"]);
            int foliooo = this.foliooo;
            var user = this.ctx.Personales.Where(x => x.login == this.sUsuarioActual).FirstOrDefault();
            b = user.Personalid;
            try
            {
                tc_PoliciaenTucolonia entity1 = new tc_PoliciaenTucolonia();
                entity1.IdCaptura = Guid.NewGuid();
                entity1.PersonalId = new int?(this.b);
                entity1.Folio = new int?(this.foliooo);
                entity1.Estatus = this.ddlEstatus.Text;
                entity1.IdPrioridad = new int?(Convert.ToInt32(this.ddlPrioridaD.SelectedValue));
                entity1.FechaCpturaEvento = new DateTime?(DateTime.Now);
                if (this.ddlMunicipio.SelectedValue == null || this.ddlMunicipio.SelectedValue.Length == 0)
                {
                    this.MunIicono.Attributes["class"] = "glyphicon glyphicon-remove form-control-feedback";
                    this.MuniREVI.Attributes["class"] = "input-group-addon danger";
                    this.MuniREVI.Visible = true;
                    ScriptManager.RegisterStartupScript((Page)this, typeof(Page), "alerta", string.Format("<script type='text/javascript'>\r\n                            alert('{0}');\r\n                        </script>", (object)"Seleccionar un Municipio"), false);
                }
                else
                    entity1.IdMunicipio = new int?(Convert.ToInt32(this.ddlMunicipio.SelectedValue.ToString()));
                this.ctx.tc_PoliciaenTucolonia.Add(entity1);
                this.Session["capturas"] = (object)entity1.idcapturaInt;
                int idcapturaInt = entity1.idcapturaInt;
                this.ctx.tc_Seguimiento.Add(new tc_Seguimiento()
                {
                    IdSeguimiento = Guid.NewGuid(),
                    IdCaptura = new Guid?(entity1.IdCaptura),
                    idcapturaInt = new int?(idcapturaInt),
                    NombreCompleto = this.txtNombreCIudadano.Text == "" ? "ANONIMO" : this.txtNombreCIudadano.Text,
                    edad = string.IsNullOrEmpty(this.txtEdad.Text) ? new int?() : new int?(Convert.ToInt32(this.txtEdad.Text)),
                    //Colonia = string.IsNullOrEmpty(this.txtColonia.Text) ? "" : this.txtColonia.Text,
                    Colonia = new int?(this.ddlColonia.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlColonia.SelectedValue)),
                    calle = string.IsNullOrEmpty(this.txtCalle.Text) ? "" : this.txtCalle.Text,
                    Referencia = string.IsNullOrEmpty(this.txtReferencia.Text) ? "" : this.txtReferencia.Text,
                    fechaRepor = string.IsNullOrEmpty(this.txtFechaDenunciaDato.Text) ? new DateTime?() : new DateTime?(Convert.ToDateTime(this.txtFechaDenunciaDato.Text)),
                    telefono = string.IsNullOrEmpty(this.txtTelefono.Text) ? "0" : this.txtTelefono.Text,
                    sexo = new bool?(this.rbMasculino.Checked),
                    Correo = string.IsNullOrEmpty(this.txtCorreoCiudadano.Text) ? "" : this.txtCorreoCiudadano.Text,
                    IdCuadrante = new int?(Convert.ToInt32(this.ddlCuadrante.SelectedValue.ToString()))
                });
                if (this.rdAplicaSEGU.Checked)
                    this.ctx.tcProblematicaSeguridad.Add(new tcProblematicaSeguridad()
                    {
                        IdCaptura = new Guid?(entity1.IdCaptura),
                        idcapturaInt = new int?(idcapturaInt),
                        Aplica = new bool?(true),
                        Especifique = string.IsNullOrEmpty(this.txtEspecifiqueSeguridad.Text) ? "" : this.txtEspecifiqueSeguridad.Text,
                        ubicacionseguridad = string.IsNullOrEmpty(this.txtubicacionsegur.Text) ? "" : this.txtubicacionsegur.Text,
                        Robos = !this.robo.Checked ? new bool?(false) : new bool?(true),
                        Homicidios = !this.homicidios.Checked ? new bool?(false) : new bool?(true),
                        ConsumoAlcohol = !this.consumos.Checked ? new bool?(false) : new bool?(true),
                        Pandillerismo = !this.pandillerismo.Checked ? new bool?(false) : new bool?(true),
                        Grafitis = !this.grafiti.Checked ? new bool?(false) : new bool?(true),
                        Narcomenudeo = !this.narcomenudeo.Checked ? new bool?(true) : new bool?(true),
                        Cristalazos = !this.cristalazo.Checked ? new bool?(false) : new bool?(true),
                        ConflictosVecinales = !this.conflictosvecinales.Checked ? new bool?(false) : new bool?(true),
                        conflictosescuelas = !this.conflictosescuelass.Checked ? new bool?(false) : new bool?(true)
                    });
                if (this.rdbVialiapli.Checked)
                {
                    tcProblematicaVialidad entity2 = new tcProblematicaVialidad();
                    entity2.Aplica = new bool?(true);
                    entity1.IdCaptura = entity1.IdCaptura;
                    entity1.idcapturaInt = idcapturaInt;
                    entity2.AutosMacetas = !this.autosmace.Checked ? new bool?(false) : new bool?(true);
                    entity2.FaltaReductoresVelocidad = !this.reductores.Checked ? new bool?(false) : new bool?(true);
                    entity2.AutosDobleCarril = !this.autosdobles.Checked ? new bool?(false) : new bool?(true);
                    entity2.congestionvehicular = !this.convehi.Checked ? new bool?(false) : new bool?(true);
                    entity2.FaltaSeñalizaciones = !this.faltadeseñales.Checked ? new bool?(false) : new bool?(true);
                    entity2.otros = !this.otro.Checked ? new bool?(false) : new bool?(true);
                    entity2.Ubicacion = string.IsNullOrEmpty(this.txtUbicacionVialidad.Text) ? "" : this.txtUbicacionVialidad.Text;
                    entity2.Especifique = string.IsNullOrEmpty(this.txtespecifiqueVialidad.Text) ? "" : this.txtespecifiqueVialidad.Text;
                    this.ctx.tcProblematicaVialidad.Add(entity2);
                }
                if (this.rdbAplicaMuni.Checked)
                    this.ctx.tcProblematicaMunicipal.Add(new tcProblematicaMunicipal()
                    {
                        Aplica = new bool?(true),
                        IdCaptura = new Guid?(entity1.IdCaptura),
                        idcapturaInt = new int?(idcapturaInt),
                        LimpiaPublicaDeficiente = !this.limpiapublica.Checked ? new bool?(false) : new bool?(true),
                        FaltaAlumbradoPublico = !this.alumbradoi.Checked ? new bool?(false) : new bool?(true),
                        ParquesJardinesEnDeterioro = !this.parques.Checked ? new bool?(false) : new bool?(true),
                        DrenajeExpuesto = !this.drenaje.Checked ? new bool?(false) : new bool?(true),
                        AnimalesCallejero = !this.animales.Checked ? new bool?(false) : new bool?(true),
                        Ambulantaje = this.abulantaje.Checked ? new bool?(false) : new bool?(true),
                        FugaAguaPotable = !this.fugaAgua.Checked ? new bool?(false) : new bool?(true),
                        ColaderasTapadas = !this.coladeras.Checked ? new bool?(false) : new bool?(true),
                        MonteMaleza = !this.montemaleza.Checked ? new bool?(false) : new bool?(true),
                        Ubicacion = this.txtUbicacionMuni.Text == "" ? "" : this.txtUbicacionMuni.Text,
                        Especifique = this.txtEspecifiqueMuni.Text == "" ? "" : this.txtEspecifiqueMuni.Text
                    });
                tcPeticionCiudadana entity3 = new tcPeticionCiudadana();
                entity3.IdCaptura = new Guid?(entity1.IdCaptura);
                entity3.idcapturaInt = new int?(idcapturaInt);
                if (this.rbseguro.Checked)
                    entity3.seguridadcolonia = new int?(1);
                if (this.rbinseguro.Checked)
                    entity3.seguridadcolonia = new int?(2);
                if (this.rbnoseguro.Checked)
                    entity3.seguridadcolonia = new int?(3);
                entity3.casa = string.IsNullOrEmpty(this.txtCasaseuri.Text) ? new int?() : new int?(Convert.ToInt32(this.txtCasaseuri.Text));
                entity3.escuela = string.IsNullOrEmpty(this.txtEscuela.Text) ? new int?() : new int?(Convert.ToInt32(this.txtEscuela.Text));
                entity3.TransportePublico = string.IsNullOrEmpty(this.txttrasporte.Text) ? new int?() : new int?(Convert.ToInt32(this.txttrasporte.Text));
                entity3.centrocomercial = string.IsNullOrEmpty(this.txtcentro.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcentro.Text));
                entity3.Parques = string.IsNullOrEmpty(this.txtparque.Text) ? new int?() : new int?(Convert.ToInt32(this.txtparque.Text));
                entity3.trabajo = string.IsNullOrEmpty(this.txttrabajo.Text) ? new int?() : new int?(Convert.ToInt32(this.txttrabajo.Text));
                entity3.calle = string.IsNullOrEmpty(this.txtcalleseguri.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcalleseguri.Text));
                entity3.banco = string.IsNullOrEmpty(this.txtbanco.Text) ? new int?() : new int?(Convert.ToInt32(this.txtbanco.Text));
                entity3.automovil = string.IsNullOrEmpty(this.txtauto.Text) ? new int?() : new int?(Convert.ToInt32(this.txtauto.Text));
                entity3.cajeroauto = string.IsNullOrEmpty(this.txtcajero.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcajero.Text));
                entity3.carretera = string.IsNullOrEmpty(this.txtcarretera.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcarretera.Text));
                entity3.protebentrevecinos = new bool?(this.rbproblesi.Checked);
                entity3.victima_delito = new bool?(this.rbVictimasi.Checked);
                entity3.ano = this.txtanodeli.Text == "" ? "" : this.txtanodeli.Text;
                entity3.cualfuedelito = this.txtcualfuedelito.Text == "" ? "" : this.txtcualfuedelito.Text;
                entity3.conocelosprogramasdgvi = new bool?(this.rbprogrmadgviSI.Checked);
                entity3.escuelasegura = new bool?(this.chkescuelasegu.Checked);
                entity3.redesvecinales = new bool?(this.chkredesveci.Checked);
                entity3.fomentodeportivo = new bool?(this.chkdeportivocultu.Checked);
                entity3.prevencionvm = new bool?(this.chkciolenciamujer.Checked);
                entity3.empresasegura = new bool?(this.chkempresarial.Checked);
                entity3.limpiezaespaciospubli = new bool?(this.chklimpiezapubli.Checked);
                entity3.observacionpropuesta = this.txtpeticion.Text == "" ? "" : this.txtpeticion.Text;
                entity3.oficial1 = this.txtOficialuno.Text == "" ? "" : this.txtOficialuno.Text;
                entity3.distintivo1 = this.txtdisitntivoOfiuno.Text == "" ? "" : this.txtdisitntivoOfiuno.Text;
                entity3.oficial2 = this.txtOficialdos.Text == "" ? "" : this.txtOficialdos.Text;
                entity3.distintivo2 = this.txtdisitintivoOfi2.Text == "" ? "" : this.txtdisitintivoOfi2.Text;
                this.ctx.tcPeticionCiudadana.Add(entity3);
                this.ctx.SaveChanges();
                this.gvPeticiones.DataBind();
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "myModalImgArchivos", "closeModal();", true);
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "Correcto", "Correcto()", true);

                //ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "redirect", "Correcto()'" + this.Request.ApplicationPath + "~/Policia_en_tu_colonia/Reporte_Seguimiento.aspx';", true);

                this.Session["AccionExpediente"] = (object)null;
                //Response.Redirect("~/Policia_en_tu_colonia/Reporte_Seguimiento.aspx");

            }
            catch (Exception ex)
            {
                this.FolioReportecancelar();
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "error", "error()", true);
            }
        }

        protected void GuardarEdicion(Guid idExpediente)
        {
            try
            {
                tc_PoliciaenTucolonia policiaenTucolonia = this.ctx.tc_PoliciaenTucolonia.Where(x => x.IdCaptura == idExpediente).FirstOrDefault();
                policiaenTucolonia.Estatus = this.ddlEstatus.Text;
                policiaenTucolonia.IdPrioridad = new int?(Convert.ToInt32(this.ddlPrioridaD.SelectedValue));
                policiaenTucolonia.IdMunicipio = new int?(Convert.ToInt32(this.ddlMunicipio.SelectedValue.ToString()));
                int idcapturaInt = policiaenTucolonia.idcapturaInt;
                tc_Seguimiento tcSeguimiento = this.ctx.tc_Seguimiento.Where(n => n.IdCaptura == (Guid?)idExpediente).FirstOrDefault();
                if (tcSeguimiento != null)
                {
                    tcSeguimiento.NombreCompleto = this.txtNombreCIudadano.Text == "" ? "ANONIMO" : this.txtNombreCIudadano.Text;
                    tcSeguimiento.idcapturaInt = new int?(idcapturaInt);
                    tcSeguimiento.edad = string.IsNullOrEmpty(this.txtEdad.Text) ? new int?() : new int?(Convert.ToInt32(this.txtEdad.Text));

                    tcSeguimiento.Colonia = new int?(this.ddlColonia.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlColonia.SelectedValue));
                    tcSeguimiento.calle = string.IsNullOrEmpty(this.txtCalle.Text) ? "" : this.txtCalle.Text;
                    tcSeguimiento.Referencia = string.IsNullOrEmpty(this.txtReferencia.Text) ? "" : this.txtReferencia.Text;
                    tcSeguimiento.fechaRepor = string.IsNullOrEmpty(this.txtFechaDenunciaDato.Text) ? new DateTime?() : new DateTime?(Convert.ToDateTime(this.txtFechaDenunciaDato.Text));
                    tcSeguimiento.telefono = string.IsNullOrEmpty(this.txtTelefono.Text) ? "0" : this.txtTelefono.Text;
                    tcSeguimiento.sexo = new bool?(this.rbMasculino.Checked);
                    tcSeguimiento.Correo = string.IsNullOrEmpty(this.txtCorreoCiudadano.Text) ? "" : this.txtCorreoCiudadano.Text;
                    tcSeguimiento.IdCuadrante = new int?(Convert.ToInt32(this.ddlCuadrante.SelectedValue.ToString()));
                    tcSeguimiento.IdCuadrante = new int?(Convert.ToInt32(this.ddlCuadrante.SelectedValue.ToString()));
                }
                tcProblematicaSeguridad problematicaSeguridad = this.ctx.tcProblematicaSeguridad.Where(p => p.IdCaptura == (Guid?)idExpediente).FirstOrDefault();
                if (problematicaSeguridad != null)
                {
                    problematicaSeguridad.idcapturaInt = new int?(idcapturaInt);
                    problematicaSeguridad.Aplica = new bool?(true);
                    problematicaSeguridad.Especifique = string.IsNullOrEmpty(this.txtEspecifiqueSeguridad.Text) ? "" : this.txtEspecifiqueSeguridad.Text;
                    problematicaSeguridad.ubicacionseguridad = string.IsNullOrEmpty(this.txtubicacionsegur.Text) ? "" : this.txtubicacionsegur.Text;
                    problematicaSeguridad.Robos = !this.robo.Checked ? new bool?(false) : new bool?(true);
                    problematicaSeguridad.Homicidios = !this.homicidios.Checked ? new bool?(false) : new bool?(true);
                    problematicaSeguridad.ConsumoAlcohol = !this.consumos.Checked ? new bool?(false) : new bool?(true);
                    problematicaSeguridad.Pandillerismo = !this.pandillerismo.Checked ? new bool?(false) : new bool?(true);
                    problematicaSeguridad.Grafitis = !this.grafiti.Checked ? new bool?(false) : new bool?(true);
                    problematicaSeguridad.Narcomenudeo = !this.narcomenudeo.Checked ? new bool?(true) : new bool?(true);
                    problematicaSeguridad.Cristalazos = !this.cristalazo.Checked ? new bool?(false) : new bool?(true);
                    problematicaSeguridad.ConflictosVecinales = !this.conflictosvecinales.Checked ? new bool?(false) : new bool?(true);
                    problematicaSeguridad.conflictosescuelas = !this.conflictosescuelass.Checked ? new bool?(false) : new bool?(true);
                }
                else if (this.rdAplicaSEGU.Checked)
                    this.ctx.tcProblematicaSeguridad.Add(new tcProblematicaSeguridad()
                    {
                        IdCaptura = new Guid?(idExpediente),
                        idcapturaInt = new int?(idcapturaInt),
                        Aplica = new bool?(true),
                        Especifique = string.IsNullOrEmpty(this.txtEspecifiqueSeguridad.Text) ? "" : this.txtEspecifiqueSeguridad.Text,
                        ubicacionseguridad = string.IsNullOrEmpty(this.txtubicacionsegur.Text) ? "" : this.txtubicacionsegur.Text,
                        Robos = !this.robo.Checked ? new bool?(false) : new bool?(true),
                        Homicidios = !this.homicidios.Checked ? new bool?(false) : new bool?(true),
                        ConsumoAlcohol = !this.consumos.Checked ? new bool?(false) : new bool?(true),
                        Pandillerismo = !this.pandillerismo.Checked ? new bool?(false) : new bool?(true),
                        Grafitis = !this.grafiti.Checked ? new bool?(false) : new bool?(true),
                        Narcomenudeo = !this.narcomenudeo.Checked ? new bool?(true) : new bool?(true),
                        Cristalazos = !this.cristalazo.Checked ? new bool?(false) : new bool?(true),
                        ConflictosVecinales = !this.conflictosvecinales.Checked ? new bool?(false) : new bool?(true),
                        conflictosescuelas = !this.conflictosescuelass.Checked ? new bool?(false) : new bool?(true)
                    });
                tcProblematicaVialidad problematicaVialidad = this.ctx.tcProblematicaVialidad.Where(q => q.IdCaptura == (Guid?)idExpediente).FirstOrDefault();
                if (problematicaVialidad != null)
                {
                    problematicaVialidad.AutosMacetas = !this.autosmace.Checked ? new bool?(false) : new bool?(true);
                    problematicaVialidad.FaltaReductoresVelocidad = !this.reductores.Checked ? new bool?(false) : new bool?(true);
                    problematicaVialidad.AutosDobleCarril = !this.autosdobles.Checked ? new bool?(false) : new bool?(true);
                    problematicaVialidad.congestionvehicular = !this.convehi.Checked ? new bool?(false) : new bool?(true);
                    problematicaVialidad.FaltaSeñalizaciones = !this.faltadeseñales.Checked ? new bool?(false) : new bool?(true);
                    problematicaVialidad.otros = !this.otro.Checked ? new bool?(false) : new bool?(true);
                    problematicaVialidad.Ubicacion = string.IsNullOrEmpty(this.txtUbicacionVialidad.Text) ? "" : this.txtUbicacionVialidad.Text;
                    problematicaVialidad.Especifique = string.IsNullOrEmpty(this.txtespecifiqueVialidad.Text) ? "" : this.txtespecifiqueVialidad.Text;
                }
                else if (this.rdbVialiapli.Checked)
                    this.ctx.tcProblematicaVialidad.Add(new tcProblematicaVialidad()
                    {
                        Aplica = new bool?(true),
                        IdCaptura = new Guid?(idExpediente),
                        idcapturaInt = new int?(idcapturaInt),
                        AutosMacetas = !this.autosmace.Checked ? new bool?(false) : new bool?(true),
                        FaltaReductoresVelocidad = !this.reductores.Checked ? new bool?(false) : new bool?(true),
                        AutosDobleCarril = !this.autosdobles.Checked ? new bool?(false) : new bool?(true),
                        congestionvehicular = !this.convehi.Checked ? new bool?(false) : new bool?(true),
                        FaltaSeñalizaciones = !this.faltadeseñales.Checked ? new bool?(false) : new bool?(true),
                        otros = !this.otro.Checked ? new bool?(false) : new bool?(true),
                        Ubicacion = string.IsNullOrEmpty(this.txtUbicacionVialidad.Text) ? "" : this.txtUbicacionVialidad.Text,
                        Especifique = string.IsNullOrEmpty(this.txtespecifiqueVialidad.Text) ? "" : this.txtespecifiqueVialidad.Text
                    });
                tcProblematicaMunicipal problematicaMunicipal = this.ctx.tcProblematicaMunicipal.Where(a => a.IdCaptura == (Guid?)idExpediente).FirstOrDefault();
                if (problematicaMunicipal != null)
                {
                    problematicaMunicipal.LimpiaPublicaDeficiente = !this.limpiapublica.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.FaltaAlumbradoPublico = !this.alumbradoi.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.ParquesJardinesEnDeterioro = !this.parques.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.DrenajeExpuesto = !this.drenaje.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.AnimalesCallejero = !this.animales.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.Ambulantaje = this.abulantaje.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.FugaAguaPotable = !this.fugaAgua.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.ColaderasTapadas = !this.coladeras.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.MonteMaleza = !this.montemaleza.Checked ? new bool?(false) : new bool?(true);
                    problematicaMunicipal.Ubicacion = this.txtUbicacionMuni.Text == "" ? "" : this.txtUbicacionMuni.Text;
                    problematicaMunicipal.Especifique = this.txtEspecifiqueMuni.Text == "" ? "" : this.txtEspecifiqueMuni.Text;
                }
                else if (this.rdbAplicaMuni.Checked)
                    this.ctx.tcProblematicaMunicipal.Add(new tcProblematicaMunicipal()
                    {
                        Aplica = new bool?(true),
                        IdCaptura = new Guid?(idExpediente),
                        idcapturaInt = new int?(idcapturaInt),
                        LimpiaPublicaDeficiente = !this.limpiapublica.Checked ? new bool?(false) : new bool?(true),
                        FaltaAlumbradoPublico = !this.alumbradoi.Checked ? new bool?(false) : new bool?(true),
                        ParquesJardinesEnDeterioro = !this.parques.Checked ? new bool?(false) : new bool?(true),
                        DrenajeExpuesto = !this.drenaje.Checked ? new bool?(false) : new bool?(true),
                        AnimalesCallejero = !this.animales.Checked ? new bool?(false) : new bool?(true),
                        Ambulantaje = this.abulantaje.Checked ? new bool?(false) : new bool?(true),
                        FugaAguaPotable = !this.fugaAgua.Checked ? new bool?(false) : new bool?(true),
                        ColaderasTapadas = !this.coladeras.Checked ? new bool?(false) : new bool?(true),
                        MonteMaleza = !this.montemaleza.Checked ? new bool?(false) : new bool?(true),
                        Ubicacion = this.txtUbicacionMuni.Text == "" ? "" : this.txtUbicacionMuni.Text,
                        Especifique = this.txtEspecifiqueMuni.Text == "" ? "" : this.txtEspecifiqueMuni.Text
                    });
                tcPeticionCiudadana peticionCiudadana = this.ctx.tcPeticionCiudadana.Where(z => z.IdCaptura == (Guid?)idExpediente).FirstOrDefault();
                if (peticionCiudadana != null)
                {
                    if (this.rbseguro.Checked)
                        peticionCiudadana.seguridadcolonia = new int?(1);
                    if (this.rbinseguro.Checked)
                        peticionCiudadana.seguridadcolonia = new int?(2);
                    if (this.rbnoseguro.Checked)
                        peticionCiudadana.seguridadcolonia = new int?(3);
                    peticionCiudadana.casa = string.IsNullOrEmpty(this.txtCasaseuri.Text) ? new int?() : new int?(Convert.ToInt32(this.txtCasaseuri.Text));
                    peticionCiudadana.escuela = string.IsNullOrEmpty(this.txtEscuela.Text) ? new int?() : new int?(Convert.ToInt32(this.txtEscuela.Text));
                    peticionCiudadana.TransportePublico = string.IsNullOrEmpty(this.txttrasporte.Text) ? new int?() : new int?(Convert.ToInt32(this.txttrasporte.Text));
                    peticionCiudadana.centrocomercial = string.IsNullOrEmpty(this.txtcentro.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcentro.Text));
                    peticionCiudadana.Parques = string.IsNullOrEmpty(this.txtparque.Text) ? new int?() : new int?(Convert.ToInt32(this.txtparque.Text));
                    peticionCiudadana.trabajo = string.IsNullOrEmpty(this.txttrabajo.Text) ? new int?() : new int?(Convert.ToInt32(this.txttrabajo.Text));
                    peticionCiudadana.calle = string.IsNullOrEmpty(this.txtcalleseguri.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcalleseguri.Text));
                    peticionCiudadana.banco = string.IsNullOrEmpty(this.txtbanco.Text) ? new int?() : new int?(Convert.ToInt32(this.txtbanco.Text));
                    peticionCiudadana.automovil = string.IsNullOrEmpty(this.txtauto.Text) ? new int?() : new int?(Convert.ToInt32(this.txtauto.Text));
                    peticionCiudadana.cajeroauto = string.IsNullOrEmpty(this.txtcajero.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcajero.Text));
                    peticionCiudadana.carretera = string.IsNullOrEmpty(this.txtcarretera.Text) ? new int?() : new int?(Convert.ToInt32(this.txtcarretera.Text));
                    peticionCiudadana.protebentrevecinos = new bool?(this.rbproblesi.Checked);
                    peticionCiudadana.victima_delito = new bool?(this.rbVictimasi.Checked);
                    peticionCiudadana.ano = this.txtanodeli.Text == "" ? "" : this.txtanodeli.Text;
                    peticionCiudadana.cualfuedelito = this.txtcualfuedelito.Text == "" ? "" : this.txtcualfuedelito.Text;
                    peticionCiudadana.conocelosprogramasdgvi = new bool?(this.rbprogrmadgviSI.Checked);
                    peticionCiudadana.escuelasegura = new bool?(this.chkescuelasegu.Checked);
                    peticionCiudadana.redesvecinales = new bool?(this.chkredesveci.Checked);
                    peticionCiudadana.fomentodeportivo = new bool?(this.chkdeportivocultu.Checked);
                    peticionCiudadana.prevencionvm = new bool?(this.chkciolenciamujer.Checked);
                    peticionCiudadana.empresasegura = new bool?(this.chkempresarial.Checked);
                    peticionCiudadana.limpiezaespaciospubli = new bool?(this.chklimpiezapubli.Checked);
                    peticionCiudadana.observacionpropuesta = this.txtpeticion.Text == "" ? "" : this.txtpeticion.Text;
                    peticionCiudadana.oficial1 = this.txtOficialuno.Text == "" ? "" : this.txtOficialuno.Text;
                    peticionCiudadana.distintivo1 = this.txtdisitntivoOfiuno.Text == "" ? "" : this.txtdisitntivoOfiuno.Text;
                    peticionCiudadana.oficial2 = this.txtOficialdos.Text == "" ? "" : this.txtOficialdos.Text;
                    peticionCiudadana.distintivo2 = this.txtdisitintivoOfi2.Text == "" ? "" : this.txtdisitintivoOfi2.Text;
                }
                this.ctx.SaveChanges();
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "myModalImgArchivos", "closeModal();", true);
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "Correcto", "Correcto()", true);
                this.Session["AccionExpediente"] = (object)null;
                this.Session[nameof(idExpediente)] = (object)null;
                this.gvPeticiones.DataBind();
                //Response.Redirect("~/Policia_en_tu_colonia/Reporte_Seguimiento.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "error", "error()", true);
            }

        }
        protected void ddlMunicipio_DataBound(object sender, EventArgs e)
        {
            this.ddlMunicipio.Items.Insert(0, new ListItem("Seleccione un municipio", "0"));
        }

        protected void ddlCuadrante_DataBound(object sender, EventArgs e)
        {
            this.ddlCuadrante.Items.Insert(0, new ListItem("Seleccione un cuadrante", "0"));
        }

        protected void contadorregistros()
        {
            this.gvPeticiones.DataBind();
            int num = 0;
            if (this.gvPeticiones.PageCount > 0)
            {
                num = this.gvPeticiones.PageSize * (this.gvPeticiones.PageCount - 1);
                this.gvPeticiones.PageIndex = this.gvPeticiones.PageCount - 1;
            }
            int count = this.gvPeticiones.Rows.Count;
            this.lblTotalRegistros.Text = "Total de peticiones: " + (num + count).ToString();
            this.gvPeticiones.PageIndex = 0;


            /// CONTEO DE REGISTROS DE LA TABLA DE PROXIMIDAD
            this.grvProximidad.DataBind();
            int numPROXI = 0;
            if (this.grvProximidad.PageCount > 0)
            {
                num = this.grvProximidad.PageSize * (this.grvProximidad.PageCount - 1);
                this.grvProximidad.PageIndex = this.grvProximidad.PageCount - 1;
            }
            int countporx = this.grvProximidad.Rows.Count;
            this.lblTotalRegistrosProximidad.Text = "Total de peticiones: " + (numPROXI + countporx).ToString();
            this.grvProximidad.PageIndex = 0;
            /// 

        }

        protected void lkmapa_Click(object sender, EventArgs e)
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
                Plantilla = Server.MapPath("~/Formatos/") + "Formulario_Seguimeinto_PoliciaProximidad.xlsx";
                FileStream ArchivoStream = File.OpenRead(Plantilla);
                package = new ExcelPackage(new FileInfo(Plantilla));
                ExcelWorkbook excelWorkBook = package.Workbook;
                var xlWorkSheet = excelWorkBook.Worksheets["Hoja2"];

                LlenaHoja(xlWorkSheet);

                fileStream = new MemoryStream();
                package.SaveAs(fileStream);

                fileStream.Position = 0;
                File.WriteAllBytes(Server.MapPath("~/Formatos/") + "T_Formulario_Seguimeinto_PoliciaProximidad.xlsx", fileStream.ToArray());
                Response.ContentType = "Application/x-msexcel";
                string FilePath = Server.MapPath("~/Formatos/") + "T_Formulario_Seguimeinto_PoliciaProximidad.xlsx";
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = ContentType;
                Response.AddHeader("Content-disposition", "attachment;filename=T_Formulario_Seguimeinto_PoliciaProximidad.xlsx" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx");
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




                    List<wv_PeticionesForPoliciaIntegralProxi> listaReportes = ctx.wv_PeticionesForPoliciaIntegralProxi.Where(R => (((convertidoFI && R.fechaRepor >= fechaInicial) || !convertidoFI) && ((convertidoFF && R.fechaRepor <= fechaFinal) || !convertidoFF))).ToList();
                    dtPrincipal = ConvertToDataTable(listaReportes);

                    for (Renglon = 0; Renglon < dtPrincipal.Rows.Count; Renglon++)
                    {

                        xlWorkSheet.Cells[Renglon + 4, 1].Value = dtPrincipal.Rows[Renglon]["Folio"];
                        xlWorkSheet.Cells[Renglon + 4, 2].Value = dtPrincipal.Rows[Renglon]["fechaRepor"];
                        xlWorkSheet.Cells[Renglon + 4, 3].Value = dtPrincipal.Rows[Renglon]["NombreCompleto"];
                        xlWorkSheet.Cells[Renglon + 4, 4].Value = dtPrincipal.Rows[Renglon]["edad"];
                        xlWorkSheet.Cells[Renglon + 4, 5].Value = dtPrincipal.Rows[Renglon]["sexo"];
                        xlWorkSheet.Cells[Renglon + 4, 6].Value = dtPrincipal.Rows[Renglon]["Correo"];
                        xlWorkSheet.Cells[Renglon + 4, 7].Value = dtPrincipal.Rows[Renglon]["telefono"];
                        xlWorkSheet.Cells[Renglon + 4, 8].Value = dtPrincipal.Rows[Renglon]["MunicipioNombre"];
                        xlWorkSheet.Cells[Renglon + 4, 9].Value = dtPrincipal.Rows[Renglon]["CuadranteNombre"];
                        xlWorkSheet.Cells[Renglon + 4, 10].Value = dtPrincipal.Rows[Renglon]["NombreColonia"];
                        xlWorkSheet.Cells[Renglon + 4, 11].Value = dtPrincipal.Rows[Renglon]["AplicaSeguridad"];
                        xlWorkSheet.Cells[Renglon + 4, 12].Value = dtPrincipal.Rows[Renglon]["Robos"];
                        xlWorkSheet.Cells[Renglon + 4, 13].Value = dtPrincipal.Rows[Renglon]["Homicidios"];
                        xlWorkSheet.Cells[Renglon + 4, 14].Value = dtPrincipal.Rows[Renglon]["ConsumoAlcohol"];
                        xlWorkSheet.Cells[Renglon + 4, 15].Value = dtPrincipal.Rows[Renglon]["Pandillerismo"];
                        xlWorkSheet.Cells[Renglon + 4, 16].Value = dtPrincipal.Rows[Renglon]["Grafitis"];
                        xlWorkSheet.Cells[Renglon + 4, 17].Value = dtPrincipal.Rows[Renglon]["Narcomenudeo"];
                        xlWorkSheet.Cells[Renglon + 4, 18].Value = dtPrincipal.Rows[Renglon]["Cristalazos"];
                        xlWorkSheet.Cells[Renglon + 4, 19].Value = dtPrincipal.Rows[Renglon]["ConflictosVecinales"];
                        xlWorkSheet.Cells[Renglon + 4, 20].Value = dtPrincipal.Rows[Renglon]["conflictosescuelas"];
                        xlWorkSheet.Cells[Renglon + 4, 21].Value = dtPrincipal.Rows[Renglon]["ubicacionseguridad"];
                        xlWorkSheet.Cells[Renglon + 4, 22].Value = dtPrincipal.Rows[Renglon]["Especifique"];

                        xlWorkSheet.Cells[Renglon + 4, 23].Value = dtPrincipal.Rows[Renglon]["AplicaVilidad"];
                        xlWorkSheet.Cells[Renglon + 4, 24].Value = dtPrincipal.Rows[Renglon]["AutosMacetas"];
                        xlWorkSheet.Cells[Renglon + 4, 25].Value = dtPrincipal.Rows[Renglon]["FaltaReductoresVelocidad"];
                        xlWorkSheet.Cells[Renglon + 4, 26].Value = dtPrincipal.Rows[Renglon]["AutosDobleCarril"];
                        xlWorkSheet.Cells[Renglon + 4, 27].Value = dtPrincipal.Rows[Renglon]["congestionvehicular"];
                        xlWorkSheet.Cells[Renglon + 4, 28].Value = dtPrincipal.Rows[Renglon]["FaltaSeñalizaciones"];
                        xlWorkSheet.Cells[Renglon + 4, 29].Value = dtPrincipal.Rows[Renglon]["otros"];
                        xlWorkSheet.Cells[Renglon + 4, 30].Value = dtPrincipal.Rows[Renglon]["Ubicacion"];
                        xlWorkSheet.Cells[Renglon + 4, 31].Value = dtPrincipal.Rows[Renglon]["EspecifiqueViali"];

                        xlWorkSheet.Cells[Renglon + 4, 32].Value = dtPrincipal.Rows[Renglon]["AplicaMunicipal"];
                        xlWorkSheet.Cells[Renglon + 4, 33].Value = dtPrincipal.Rows[Renglon]["LimpiaPublicaDeficiente"];
                        xlWorkSheet.Cells[Renglon + 4, 34].Value = dtPrincipal.Rows[Renglon]["FaltaAlumbradoPublico"];
                        xlWorkSheet.Cells[Renglon + 4, 35].Value = dtPrincipal.Rows[Renglon]["ParquesJardinesEnDeterioro"];
                        xlWorkSheet.Cells[Renglon + 4, 36].Value = dtPrincipal.Rows[Renglon]["DrenajeExpuesto"];
                        xlWorkSheet.Cells[Renglon + 4, 37].Value = dtPrincipal.Rows[Renglon]["AnimalesCallejero"];
                        xlWorkSheet.Cells[Renglon + 4, 38].Value = dtPrincipal.Rows[Renglon]["Ambulantaje"];
                        xlWorkSheet.Cells[Renglon + 4, 39].Value = dtPrincipal.Rows[Renglon]["FugaAguaPotable"];
                        xlWorkSheet.Cells[Renglon + 4, 40].Value = dtPrincipal.Rows[Renglon]["ColaderasTapadas"];
                        xlWorkSheet.Cells[Renglon + 4, 41].Value = dtPrincipal.Rows[Renglon]["MonteMaleza"];
                        xlWorkSheet.Cells[Renglon + 4, 42].Value = dtPrincipal.Rows[Renglon]["baches"];
                        xlWorkSheet.Cells[Renglon + 4, 43].Value = dtPrincipal.Rows[Renglon]["acerasdeterioradas"];
                        xlWorkSheet.Cells[Renglon + 4, 44].Value = dtPrincipal.Rows[Renglon]["EspecifiqueMuni"];
                        xlWorkSheet.Cells[Renglon + 4, 45].Value = dtPrincipal.Rows[Renglon]["UbicacionMuni"];
                        xlWorkSheet.Cells[Renglon + 4, 46].Value = dtPrincipal.Rows[Renglon]["seguridadcolonia"];
                        xlWorkSheet.Cells[Renglon + 4, 47].Value = dtPrincipal.Rows[Renglon]["casa"];
                        xlWorkSheet.Cells[Renglon + 4, 48].Value = dtPrincipal.Rows[Renglon]["escuela"];
                        xlWorkSheet.Cells[Renglon + 4, 49].Value = dtPrincipal.Rows[Renglon]["mercado"];
                        xlWorkSheet.Cells[Renglon + 4, 50].Value = dtPrincipal.Rows[Renglon]["centrocomercial"];
                        xlWorkSheet.Cells[Renglon + 4, 51].Value = dtPrincipal.Rows[Renglon]["TransportePublico"];
                        xlWorkSheet.Cells[Renglon + 4, 52].Value = dtPrincipal.Rows[Renglon]["Parques"];
                        xlWorkSheet.Cells[Renglon + 4, 53].Value = dtPrincipal.Rows[Renglon]["trabajo"];
                        xlWorkSheet.Cells[Renglon + 4, 54].Value = dtPrincipal.Rows[Renglon]["calle"];
                        xlWorkSheet.Cells[Renglon + 4, 55].Value = dtPrincipal.Rows[Renglon]["banco"];
                        xlWorkSheet.Cells[Renglon + 4, 56].Value = dtPrincipal.Rows[Renglon]["automovil"];
                        xlWorkSheet.Cells[Renglon + 4, 57].Value = dtPrincipal.Rows[Renglon]["cajeroauto"];
                        xlWorkSheet.Cells[Renglon + 4, 58].Value = dtPrincipal.Rows[Renglon]["carretera"];
                        xlWorkSheet.Cells[Renglon + 4, 59].Value = dtPrincipal.Rows[Renglon]["transporte"];
                        xlWorkSheet.Cells[Renglon + 4, 60].Value = dtPrincipal.Rows[Renglon]["protebentrevecinos"];
                        xlWorkSheet.Cells[Renglon + 4, 61].Value = dtPrincipal.Rows[Renglon]["victima_delito"];
                        xlWorkSheet.Cells[Renglon + 4, 62].Value = dtPrincipal.Rows[Renglon]["ano"];
                        xlWorkSheet.Cells[Renglon + 4, 63].Value = dtPrincipal.Rows[Renglon]["cualfuedelito"];
                        xlWorkSheet.Cells[Renglon + 4, 64].Value = dtPrincipal.Rows[Renglon]["conocelosprogramasdgvi"];
                        xlWorkSheet.Cells[Renglon + 4, 65].Value = dtPrincipal.Rows[Renglon]["escuelasegura"];
                        xlWorkSheet.Cells[Renglon + 4, 66].Value = dtPrincipal.Rows[Renglon]["fomentodeportivo"];
                        xlWorkSheet.Cells[Renglon + 4, 67].Value = dtPrincipal.Rows[Renglon]["redesvecinales"];
                        xlWorkSheet.Cells[Renglon + 4, 68].Value = dtPrincipal.Rows[Renglon]["prevencionvm"];
                        xlWorkSheet.Cells[Renglon + 4, 69].Value = dtPrincipal.Rows[Renglon]["empresasegura"];
                        xlWorkSheet.Cells[Renglon + 4, 70].Value = dtPrincipal.Rows[Renglon]["limpiezaespaciospubli"];
                        xlWorkSheet.Cells[Renglon + 4, 71].Value = dtPrincipal.Rows[Renglon]["cualesonfehcahoralugar"];
                        xlWorkSheet.Cells[Renglon + 4, 72].Value = dtPrincipal.Rows[Renglon]["observacionpropuesta"];
                        xlWorkSheet.Cells[Renglon + 4, 73].Value = dtPrincipal.Rows[Renglon]["oficial1"];
                        xlWorkSheet.Cells[Renglon + 4, 74].Value = dtPrincipal.Rows[Renglon]["distintivo1"];
                        xlWorkSheet.Cells[Renglon + 4, 75].Value = dtPrincipal.Rows[Renglon]["oficial2"];
                        xlWorkSheet.Cells[Renglon + 4, 76].Value = dtPrincipal.Rows[Renglon]["distintivo2"];
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
        protected void imgPeticion_Click(object sender, ImageClickEventArgs e)
        {
            this.Session["AccionExpediente"] = (object)AccionExpediente.Creacion;
            ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "myModalImgArchivos", "openModal();", true);
        }
        #endregion


        #region DATOS DE CAPTURA, VISTA ,REPORTES , EDITAR DE FORMULARIO DE PROXIMIDAD
        protected void txtadoleH_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalAles();
        }

        protected void txtadolM_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalAles();
        }

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
                int adolemujer = 0;
                int tadoleH = 0;
                TotalAtendidos = 0;

                if (this.txtadoleH.Text != "")
                {
                    tadoleH = int.Parse(this.txtadoleH.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                }
                if (this.txtadolM.Text != "")
                {
                    adolemujer = int.Parse(this.txtadolM.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                }
                if (this.txttotlaHombres.Text != "")
                {
                    Hombre = int.Parse(this.txttotlaHombres.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                }

                if (this.txtmujer.Text != "")
                {
                    Mujer = int.Parse(this.txtmujer.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                }

                this.TotalAtendidos = tadoleH + adolemujer + Mujer + Hombre;
                this.txtatendios.Text = TotalAtendidos.ToString();


            }
            catch (Exception ex)
            {
                this.CalcularTotalAles();
            }
        }
        protected void btncancelarproxi_Click(object sender, EventArgs e)
        {
            this.Session["AccionExpediente"] = (object)null;
            this.Session["AccionProximidad"] = (object)null;
            this.Session["folioEditar"] = (object)null;
            ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "closeProxi", "closeProxi();", true);
        }

        protected void btnGuardarProxi_Click(object sender, EventArgs e)
        {
            if (this.Session["AccionProximidad"] != null)
            {
                AccionExpediente accion = (AccionExpediente)Session["AccionProximidad"];

                switch ((int)accion)
                {
                    case (int)AccionExpediente.Creacion:

                        this.sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;

                        this.GuardaRegistroproxi();

                        break;
                    case (int)AccionExpediente.Edicion:
                        this.GuardarEdicionproxi(Guid.Parse(this.Session["folioEditar"].ToString()));
                        break;

                }
            }
        }

        protected void GuardaRegistroproxi()
        {
            nino = 0;
            nina = 0;
            padresH = 0;
            padresM = 0;
            sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
            var ID = ctx.Personales.Where(x => x.login == this.sUsuarioActual).FirstOrDefault();
            personalID = ID.Personalid;
            try
            {
                tb_Reporte_Diario NuevoRegistros = new tb_Reporte_Diario();
                NuevoRegistros.idResumenDiario = Guid.NewGuid();
                NuevoRegistros.Personalid = personalID;
                NuevoRegistros.fechacaptura = DateTime.Now;
                NuevoRegistros.fecha = new DateTime?(Convert.ToDateTime(this.txtfecxhaven.Text));
                NuevoRegistros.programasID = 15;
                NuevoRegistros.AccionesID = Convert.ToInt32(ddltipoaccion.SelectedValue);
                NuevoRegistros.descripcion_actividad = txtdescripcionporxi.Text;
                NuevoRegistros.personal_atendio_actividad = txtoficialesproxi.Text;
                if (this.txtadolM.Text != "")
                    nina = int.Parse(this.txtadolM.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                if (this.txtadoleH.Text != "")
                    nino = int.Parse(this.txtadoleH.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                if (this.txttotlaHombres.Text != "")
                    padresH = int.Parse(this.txttotlaHombres.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                if (this.txtmujer.Text != "")
                    padresM = int.Parse(this.txtmujer.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                int Hombres = nino + padresH;
                int Mujeres = nina + padresM;
                NuevoRegistros.TotalHombresAtendidos = new int?(Hombres);
                NuevoRegistros.TotalMujeresAtendidas = new int?(Mujeres);
                NuevoRegistros.total_atendidos = new int?(this.txtatendios.Text == string.Empty ? 0 : Convert.ToInt32(this.txtatendios.Text));
                string timeSalida = txthora.Text;
                TimeSpan time2 = TimeSpan.Parse(timeSalida);
                NuevoRegistros.hora = time2.ToString("hh:mm tt");
                NuevoRegistros.capturaAPP = "NO";
                ctx.tb_Reporte_Diario.Add(NuevoRegistros);


                ctx.tb_DireccionReporte.Add(new tb_DireccionReporte()
                {
                    idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),
                    Latitud = this.lati.Value,
                    Longitud = this.longi.Value,
                    calle = this.route.Value == string.Empty ? "" : this.route.Value,
                    coloni = ddlcoloniacuadrante.Text,
                    RegionID = 2,
                    DelegacionID = 20,
                    MunicipioID = 87,
                    Cuadrante = Convert.ToInt32(ddlcuadranteproxi.SelectedValue),
                });
                ctx.TB_DatosGralReporte.Add(new TB_DatosGralReporte()
                {
                    idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),

                    NombreLugar_Escuela = this.txtUnidad.Text == string.Empty ? "" : this.txtUnidad.Text.ToUpper(),
                    niñas = new int?(this.txtadolM.Text == "" ? 0 : Convert.ToInt32(this.txtadolM.Text)),
                    niños = new int?(this.txtadoleH.Text == "" ? 0 : Convert.ToInt32(this.txtadoleH.Text)),
                    hombres = new int?(this.txttotlaHombres.Text == "" ? 0 : Convert.ToInt32(this.txttotlaHombres.Text)),
                    mujeres = new int?(this.txtmujer.Text == "" ? 0 : Convert.ToInt32(this.txtmujer.Text)),

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
                                tb_fotografia foto = new tb_fotografia()
                                {
                                    contentType = contentType,
                                    ImagenSubida = new DateTime?(DateTime.Now),
                                    FileName = fileName,
                                    image = numArray
                                };
                                foto.idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario);
                                ctx.tb_fotografia.Add(foto);
                            }
                        }
                    }
                }


                ctx.SaveChanges();
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "Correcto", "Correcto();", true);
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "closeProxi", "closeProxi()", true);
            }

            catch (Exception ex)
            {

            }


        }
        protected void GuardarEdicionproxi(Guid idExpediente)
        {
            nino = 0;
            nina = 0;
            padresH = 0;
            padresM = 0;

            try
            {
                tb_Reporte_Diario editRegistros = this.ctx.tb_Reporte_Diario.Where(n => n.idResumenDiario == (Guid?)idExpediente).FirstOrDefault();
                if (editRegistros != null)
                {
                    editRegistros.fecha = new DateTime?(Convert.ToDateTime(this.txtfecxhaven.Text));
                    editRegistros.AccionesID = Convert.ToInt32(ddltipoaccion.SelectedValue);
                    editRegistros.descripcion_actividad = txtdescripcionporxi.Text;
                    editRegistros.personal_atendio_actividad = txtoficialesproxi.Text;
                    if (this.txtadolM.Text != "")
                        nina = int.Parse(this.txtadolM.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                    if (this.txtadoleH.Text != "")
                        nino = int.Parse(this.txtadoleH.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                    if (this.txttotlaHombres.Text != "")
                        padresH = int.Parse(this.txttotlaHombres.Text, (IFormatProvider)CultureInfo.InvariantCulture);
                    if (this.txtmujer.Text != "")
                        padresM = int.Parse(this.txtmujer.Text, (IFormatProvider)CultureInfo.InvariantCulture);

                    int Hombres = nino + padresH;
                    int Mujeres = nina + padresM;
                    editRegistros.TotalHombresAtendidos = Hombres;
                    editRegistros.TotalMujeresAtendidas = Mujeres;
                    editRegistros.total_atendidos = new int?(this.txtatendios.Text == string.Empty ? 0 : Convert.ToInt32(this.txtatendios.Text));

                    editRegistros.hora = txthora.Text;
                }



                tb_DireccionReporte editRegistrodirec = this.ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == (Guid?)idExpediente).FirstOrDefault();
                if (editRegistrodirec != null)
                {
                    editRegistrodirec.Latitud = this.lati.Value;
                    editRegistrodirec.Longitud = this.longi.Value;
                    editRegistrodirec.calle = this.route.Value == string.Empty ? "" : this.route.Value;
                    editRegistrodirec.coloni = ddlcoloniacuadrante.Text;
                    editRegistrodirec.RegionID = 2;
                    editRegistrodirec.DelegacionID = 20;
                    editRegistrodirec.MunicipioID = 87;
                    editRegistrodirec.Cuadrante = Convert.ToInt32(ddlcuadranteproxi.SelectedValue);
                }

                TB_DatosGralReporte editRegistroGral = this.ctx.TB_DatosGralReporte.Where(q => q.idResumenDiario == (Guid?)idExpediente).FirstOrDefault();
                if (editRegistroGral != null)
                {
                    editRegistroGral.niñas = new int?(this.txtadolM.Text == "" ? 0 : Convert.ToInt32(this.txtadolM.Text));
                    editRegistroGral.niños = new int?(this.txtadoleH.Text == "" ? 0 : Convert.ToInt32(this.txtadoleH.Text));
                    editRegistroGral.hombres = new int?(this.txttotlaHombres.Text == "" ? 0 : Convert.ToInt32(this.txttotlaHombres.Text));
                    editRegistroGral.mujeres = new int?(this.txtmujer.Text == "" ? 0 : Convert.ToInt32(this.txtmujer.Text));
                }




                ctx.SaveChanges();
                grvProximidad.DataBind();

                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "Correcto", "Correcto();", true);
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "closeProxi", "closeProxi()", true);
                btnexcelpeticion.Visible = false;
                peticionestexto.Visible = false;
                grvPetiticoness.Visible = false;
                lblTotalRegistros.Visible = false;
                btnProxi.Visible = false;
                bsuquedafolio.Visible = false;

                proxitexto.Visible = true;
                GrdPromixi.Visible = true;
                btnPetiicon.Visible = true;
                busquedadescripcion.Visible = true;
                lblTotalRegistrosProximidad.Visible = true;
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "error", "error();", true);

            }
        }

        protected void grvProximidad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.Cells[3].Text.Equals("1"))
                {
                    e.Row.Cells[3].Text = "Intereacciones";
                }
                if (e.Row.Cells[3].Text.Equals("2"))
                {
                    e.Row.Cells[3].Text = "Detenciones";
                }
                if (e.Row.Cells[3].Text.Equals("3"))
                {
                    e.Row.Cells[3].Text = "Revisiones";
                }
            }
        }

        protected void lkbproximidad_Click(object sender, EventArgs e)
        {
            btnexcelpeticion.Visible = false;
            peticionestexto.Visible = false;
            grvPetiticoness.Visible = false;
            lblTotalRegistros.Visible = false;
            btnProxi.Visible = false;
            bsuquedafolio.Visible = false;

            proxitexto.Visible = true;
            GrdPromixi.Visible = true;
            btnPetiicon.Visible = true;
            busquedadescripcion.Visible = true;
            lblTotalRegistrosProximidad.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('CAMBIO A VISTA DE DATOS DE PROXIMIDAD')", true);


        }

        protected void lkbPeticiones_Click(object sender, EventArgs e)
        {
            btnexcelpeticion.Visible = true;
            peticionestexto.Visible = true;
            grvPetiticoness.Visible = true;
            lblTotalRegistros.Visible = true;
            btnProxi.Visible = true;
            bsuquedafolio.Visible = true;


            proxitexto.Visible = false;
            GrdPromixi.Visible = false;
            btnPetiicon.Visible = false;
            busquedadescripcion.Visible = false;
            lblTotalRegistrosProximidad.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('CAMBIO A VISTA DE DATOS A FORMULARIO DE PETICIONES ')", true);

        }

        protected void PageDropDownListProxi_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                GridViewRow pagerRow = grvProximidad.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListProxi");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                grvProximidad.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...
                //lblInfo.Text = "";
            }
        }

        protected void grvProximidad_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = grvProximidad.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListProxi");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabelproxi");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= grvProximidad.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == grvProximidad.PageIndex)
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
                    int currentPage = grvProximidad.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + grvProximidad.PageCount.ToString();

                }


            }
            catch
            {
            }
        }


        protected void grvProximidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    try
                    {
                        this.Session["AccionProximidad"] = (object)AccionExpediente.Edicion;
                        Guid folio = Guid.Parse(numFila.ToString());
                        this.Session["folioEditar"] = (object)folio;
                        tb_Reporte_Diario verCap = ctx.tb_Reporte_Diario.Where(t => t.idResumenDiario == folio).FirstOrDefault();


                        DateTime f1 = Convert.ToDateTime(verCap.fecha);
                        txtfecxhaven.Text = string.Format("{0:yyyy-MM-dd}", f1);

                        txthora.Text = verCap.hora;
                        //Now.ToString("hh:mm:ss" , f2);

                        //this.ddlAcciones.SelectedValue = verCap.AccionesID != 0 ? verCap.AccionesID.ToString() : "0";
                        this.txtdescripcionporxi.Text = verCap.descripcion_actividad != null ? verCap.descripcion_actividad : "";
                        this.txtoficialesproxi.Text = verCap.personal_atendio_actividad != null ? verCap.personal_atendio_actividad : "";
                        this.txtatendios.Text = verCap.total_atendidos != 0 ? verCap.total_atendidos.ToString() : "0";
                        int accion = Convert.ToInt32(verCap.AccionesID);

                        switch (accion)
                        {
                            case 1:
                                this.ddltipoaccion.SelectedValue = accion.ToString();
                                break;
                            case 2:
                                this.ddltipoaccion.SelectedValue = accion.ToString();
                                break;
                            default:
                                this.ddltipoaccion.SelectedValue = accion.ToString();
                                break;
                        }

                        tb_DireccionReporte verCapdirec = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == folio).FirstOrDefault();
                        if (verCapdirec != null)
                        {
                            this.lati.Value = verCapdirec.Latitud != null ? verCapdirec.Latitud : "";
                            this.longi.Value = verCapdirec.Longitud != null ? verCapdirec.Longitud : "";
                            this.route.Value = verCapdirec.calle != null ? verCapdirec.calle : "";
                            //ddlcuadranteproxi.Items.Clear();
                            this.ddlcuadranteproxi.SelectedValue = verCapdirec.Cuadrante != null ? verCapdirec.Cuadrante.ToString() : "0";
                            this.ddlColonia.SelectedValue = verCapdirec.coloni != null ? verCapdirec.coloni : "";

                            //ddlMuNICIPIO.SelectedValue = direccionReporte.MunicipioID != null ? direccionReporte.MunicipioID.ToString() : "0";
                        }

                        TB_DatosGralReporte verCapGeneral = ctx.TB_DatosGralReporte.Where(t => t.idResumenDiario == folio).FirstOrDefault();
                        if (verCapGeneral != null)
                        {
                            this.txtUnidad.Text = verCapGeneral.NombreLugar_Escuela != null ? verCapGeneral.NombreLugar_Escuela : "";
                            this.txtadolM.Text = verCapGeneral.niñas != null ? verCapGeneral.niñas.ToString() : "0";
                            this.txtadoleH.Text = verCapGeneral.niños != null ? verCapGeneral.niños.ToString() : "0";
                            this.txttotlaHombres.Text = verCapGeneral.hombres != null ? verCapGeneral.hombres.ToString() : "0";
                            this.txtmujer.Text = verCapGeneral.mujeres != null ? verCapGeneral.mujeres.ToString() : "0";

                        }


                        ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "copenProxi", "copenProxi();", true);
                    }
                    catch (Exception ex)
                    {

                    }


                }
            }
        }



        #endregion

        protected void lkbProximidad_Click1(object sender, EventArgs e)
        {
            this.Session["AccionProximidad"] = (object)AccionExpediente.Creacion;

            ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "copenProxi", "copenProxi();", true);

        }
    }

}