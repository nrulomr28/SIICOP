using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Captura.DGRS
{
    public partial class Actividades_DGRS : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        public enum AccionReporte { Creacion, Edicion, Visualizacion }
        string sUsuarioActual;

        #region ### BENEFICIADOS
        //alumnos
        int Alumh_0_4 = 0;
        int Alumm_0_4 = 0;
        int Alumh_5_8 = 0;
        int Alumm_5_8 = 0;
        int Alumh_9_12 = 0;
        int Alumm_9_12 = 0;
        int Alumh_13_15 = 0;
        int Alumm_13_15 = 0;
        int Alumh_16_18 = 0;
        int Alumm_16_18 = 0;
        int Alumh_19_22 = 0;
        int Alumm_19_22 = 0;
        int Alumh_23_60 = 0;
        int Alumm_23_60 = 0;
        int Alumh_61_ano = 0;
        int Alumm_61_ano = 0;

        // PADRES Y DOCENTES
        int Padres_doceh_0_4 = 0;
        int Padres_docem_0_4 = 0;
        int Padres_doceh_5_8 = 0;
        int Padres_docem_5_8 = 0;
        int Padres_doceh_9_12 = 0;
        int Padres_docem_9_12 = 0;
        int Padres_doceh_13_15 = 0;
        int Padres_docem_13_15 = 0;
        int Padres_doceh_16_18 = 0;
        int Padres_docem_16_18 = 0;
        int Padres_doceh_19_22 = 0;
        int Padres_docem_19_22 = 0;
        int Padres_doceh_23_60 = 0;
        int Padres_docem_23_60 = 0;
        int Padres_doceh_61_ano = 0;
        int Padres_docem_61_ano = 0;

        //Personal de institución Publica y privada
        int Insti_Publi_Privah_0_4 = 0;
        int Insti_Publi_Privam_0_4 = 0;
        int Insti_Publi_Privah_5_8 = 0;
        int Insti_Publi_Privam_5_8 = 0;
        int Insti_Publi_Privah_9_12 = 0;
        int Insti_Publi_Privam_9_12 = 0;
        int Insti_Publi_Privah_13_15 = 0;
        int Insti_Publi_Privam_13_15 = 0;
        int Insti_Publi_Privah_16_18 = 0;
        int Insti_Publi_Privam_16_18 = 0;
        int Insti_Publi_Privah_19_22 = 0;
        int Insti_Publi_Privam_19_22 = 0;
        int Insti_Publi_Privah_23_60 = 0;
        int Insti_Publi_Privam_23_60 = 0;
        int Insti_Publi_Privah_61_ano = 0;
        int Insti_Publi_Privam_61_ano = 0;

        //Internos
        int Internosh_0_4 = 0;
        int Internosm_0_4 = 0;
        int Internosh_5_8 = 0;
        int Internosm_5_8 = 0;
        int Internosh_9_12 = 0;
        int Internosm_9_12 = 0;
        int Internosh_13_15 = 0;
        int Internosm_13_15 = 0;
        int Internosh_16_18 = 0;
        int Internosm_16_18 = 0;
        int Internosh_19_22 = 0;
        int Internosm_19_22 = 0;
        int Internosh_23_60 = 0;
        int Internosm_23_60 = 0;
        int Internosh_61_ano = 0;
        int Internosm_61_ano = 0;

        //Familar Internos
        int Familiarh_0_4 = 0;
        int Familiarm_0_4 = 0;
        int Familiarh_5_8 = 0;
        int Familiarm_5_8 = 0;
        int Familiarh_9_12 = 0;
        int Familiarm_9_12 = 0;
        int Familiarh_13_15 = 0;
        int Familiarm_13_15 = 0;
        int Familiarh_16_18 = 0;
        int Familiarm_16_18 = 0;
        int Familiarh_19_22 = 0;
        int Familiarm_19_22 = 0;
        int Familiarh_23_60 = 0;
        int Familiarm_23_60 = 0;
        int Familiarh_61_ano = 0;
        int Familiarm_61_ano = 0;


        //Hijos Internos
        int Hijosh_0_4 = 0;
        int Hijosm_0_4 = 0;
        int Hijosh_5_8 = 0;
        int Hijosm_5_8 = 0;
        int Hijosh_9_12 = 0;
        int Hijosm_9_12 = 0;
        int Hijosh_13_15 = 0;
        int Hijosm_13_15 = 0;
        int Hijosh_16_18 = 0;
        int Hijosm_16_18 = 0;
        int Hijosh_19_22 = 0;
        int Hijosm_19_22 = 0;
        int Hijosh_23_60 = 0;
        int Hijosm_23_60 = 0;
        int Hijosh_61_ano = 0;
        int Hijosm_61_ano = 0;

        //Preliverado 
        int Preliveradoh_0_4 = 0;
        int Preliveradom_0_4 = 0;
        int Preliveradoh_5_8 = 0;
        int Preliveradom_5_8 = 0;
        int Preliveradoh_9_12 = 0;
        int Preliveradom_9_12 = 0;
        int Preliveradoh_13_15 = 0;
        int Preliveradom_13_15 = 0;
        int Preliveradoh_16_18 = 0;
        int Preliveradom_16_18 = 0;
        int Preliveradoh_19_22 = 0;
        int Preliveradom_19_22 = 0;
        int Preliveradoh_23_60 = 0;
        int Preliveradom_23_60 = 0;
        int Preliveradoh_61_ano = 0;
        int Preliveradom_61_ano = 0;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("DGRS"))
                {

                    this.determinarAccion();
                }
                else
                {

                    MembershipUser user = Membership.GetUser(false);
                    Membership.UpdateUser(user);
                    //ctx.SaveChanges();
                    Session.Clear();
                    Session.Abandon();
                    FormsAuthentication.RedirectToLoginPage();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Inicio/Inicio_Sesion.aspx");
                }
            }
        }

        #region ## DETERMINACION DEL FORMULAREO YA SEA CREACIÓN , EDICIÓN  Y Visualización
        protected void determinarAccion()
        {
            Session["ProgramaId"] = null;
            Session["IdProCompartido"] = null;
            if (Session["idReporte_Accion"] != null && Session["AccionReporte"] != null)
            {
                AccionReporte accion = (AccionReporte)Session["AccionReporte"];
                switch ((int)accion)
                {
                    case (int)AccionReporte.Creacion:
                        if (Session["idPrograma_Accion"] != null)
                        {
                            int idPrograma = int.Parse(Session["idPrograma_Accion"].ToString());

                            var Subcompartido = ctx.TB_subprograma.Where(o => o.ProgramaCompartidoID == idPrograma).FirstOrDefault();
                            if (Subcompartido != null)
                            {
                                Session["IdProCompartido"] = Convert.ToInt32(Subcompartido.ProgramaCompartidoID);
                                ddlsubprograma.DataBind();
                            }
                            else
                            {
                                Session["ProgramaId"] = idPrograma;
                                ddlsubprograma.DataBind();

                            }
                            sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                            var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                            txtResponsable.Text = a.Nombre + " " + a.paterno + " " + a.materno;
                            txtArea.Text = a.AreaTrabajo;
                            lnkbtnGuardar.Visible = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "nuevoreporte", "nuevoreporte();", true);
                        }
                        else
                        {
                            this.Response.Redirect("~/Bienvenido_DGRS.aspx");
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
                this.Response.Redirect("~/Bienvenido_DGRS.aspx");
            }
            //Session["idPrograma_Accion"] = null;
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
            Wv_DatosReportesHistorico reportesHistorico = ctx.Wv_DatosReportesHistorico.Where(g => g.idResumenDiario == idReporte).FirstOrDefault();
            if (reportesHistorico != null)
            {
                HDFactividad.Value = idReporte.ToString();
                this.txtResponsable.Text = reportesHistorico.nombrecompleto != null ? reportesHistorico.nombrecompleto : "";
                this.txtArea.Text = reportesHistorico.AreaTrabajo != null ? reportesHistorico.AreaTrabajo : "";
                this.txtFecha.Text = string.Format("{0:dd/MM/yyyy}", (object)reportesHistorico.fecha);
                Session["subpro"] = reportesHistorico.subprogramaId;
                ddlsubprograma.SelectedValue = Convert.ToInt32(Session["subpro"]).ToString();
                ddlsubprograma.DataBind();

                Session["accion"] = reportesHistorico.AccionesID;
                ddlAcciones.SelectedValue = Convert.ToInt32(Session["accion"]).ToString();
                ddlAcciones.DataBind();

                this.txtDescripcionActividad.Text = reportesHistorico.descripcion_actividad != null ? reportesHistorico.descripcion_actividad : "";
                this.txtpersonal_atendio_actividad.Text = reportesHistorico.personal_atendio_actividad != null ? reportesHistorico.personal_atendio_actividad : "";

                this.txtBeneficiado.Text = reportesHistorico.total_atendidos != 0 ? reportesHistorico.total_atendidos.ToString() : "0";
            }

            tb_DireccionReporte direccionReporte = ctx.tb_DireccionReporte.Where(t => t.idResumenDiario == idReporte).FirstOrDefault();
            if (direccionReporte != null)
            {
                this.HDFactividad.Value = Convert.ToString((object)idReporte);
                this.lati.Value = direccionReporte.Latitud != null ? direccionReporte.Latitud : "";
                this.longi.Value = direccionReporte.Longitud != null ? direccionReporte.Longitud : "";
                this.route.Value = direccionReporte.calle != null ? direccionReporte.calle : "";
                this.colony.Value = direccionReporte.coloni != null ? direccionReporte.coloni : "";
               // this.entrecalle1.Value = direccionReporte.Entrecalle1 != null ? direccionReporte.Entrecalle1 : "";
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

                this.txtclave.Text = datosGralReporte.ClavePlantel != null ? datosGralReporte.ClavePlantel : "";
                this.ddlNivel.Text = datosGralReporte.Nivel != null ? datosGralReporte.Nivel : "";
                this.ddlTurno.Text = datosGralReporte.Turno != null ? datosGralReporte.Turno : "";


            }


            tb_Beneficiados_dgprs datosBeneficiados = ctx.tb_Beneficiados_dgprs.Where(t => t.idResumenDiario == idReporte).FirstOrDefault();
            if (datosBeneficiados != null)
            {

                #region ##  BENEFICIADOS Alumnos

                txtAlu_H_0_4.Value = datosBeneficiados.AlumH_0_4 != 0 ? datosBeneficiados.AlumH_0_4.ToString() : "0";
                txtAlu_M_0_4.Value = datosBeneficiados.AlummM_0_4 != 0 ? datosBeneficiados.AlummM_0_4.ToString() : "0";
                txtAlu_H_5_8.Value = datosBeneficiados.AlumH_5_8 != 0 ? datosBeneficiados.AlumH_5_8.ToString() : "0";
                txtAlu_M_5_8.Value = datosBeneficiados.AlumM_5_8 != 0 ? datosBeneficiados.AlumM_5_8.ToString() : "0";
                txtAlu_H_9_12.Value = datosBeneficiados.AlumH_9_12 != 0 ? datosBeneficiados.AlumH_9_12.ToString() : "0";
                txtAlu_M_9_12.Value = datosBeneficiados.AlumM_9_12 != 0 ? datosBeneficiados.AlumM_9_12.ToString() : "0";
                txtAlu_H_13_15.Value = datosBeneficiados.AlumH_13_15 != 0 ? datosBeneficiados.AlumH_13_15.ToString() : "0";
                txtAlu_M_13_15.Value = datosBeneficiados.AlumM_13_15 != 0 ? datosBeneficiados.AlumM_13_15.ToString() : "0";
                txtAlu_H_16_18.Value = datosBeneficiados.AlumH_16_18 != 0 ? datosBeneficiados.AlumH_16_18.ToString() : "0";
                txtAlu_M_16_18.Value = datosBeneficiados.AlumM_16_18 != 0 ? datosBeneficiados.AlumM_16_18.ToString() : "0";
                txtAlu_H_19_22.Value = datosBeneficiados.AlumH_19_22 != 0 ? datosBeneficiados.AlumH_19_22.ToString() : "0";
                txtAlu_M_19_22.Value = datosBeneficiados.AlumM_19_22 != 0 ? datosBeneficiados.AlumM_19_22.ToString() : "0";
                txtAlu_H_23_60.Value = datosBeneficiados.AlumH_23_60 != 0 ? datosBeneficiados.AlumH_23_60.ToString() : "0";
                txtAlu_M_23_60.Value = datosBeneficiados.AlumM_23_60 != 0 ? datosBeneficiados.AlumM_23_60.ToString() : "0";
                txtAlu_H_61_mas.Value = datosBeneficiados.AlumH_61_mas != 0 ? datosBeneficiados.AlumH_61_mas.ToString() : "0";
                txtAlu_M_61_mas.Value = datosBeneficiados.AlumM_61_mas != 0 ? datosBeneficiados.AlumM_61_mas.ToString() : "0";
                #endregion

                #region ##  BENEFICIADOS PADRES Y DOCENTES

                txtPadreDoc_H_0_4.Value = datosBeneficiados.Padre_Docent_H_0_4 != 0 ? datosBeneficiados.Padre_Docent_H_0_4.ToString() : "0";
                txtPadreDoc_M_0_4.Value = datosBeneficiados.Padre_Docent_M_0_4 != 0 ? datosBeneficiados.Padre_Docent_M_0_4.ToString() : "0";
                txtPadreDoc_H_5_8.Value = datosBeneficiados.Padre_Docent_H_5_8 != 0 ? datosBeneficiados.Padre_Docent_H_5_8.ToString() : "0";
                txtPadreDoc_M_5_8.Value = datosBeneficiados.Padre_Docent_M_5_8 != 0 ? datosBeneficiados.Padre_Docent_M_5_8.ToString() : "0";
                txtPadreDoc_H_9_12.Value = datosBeneficiados.Padre_Docent_H_9_12 != 0 ? datosBeneficiados.Padre_Docent_H_9_12.ToString() : "0";
                txtPadreDoc_M_9_12.Value = datosBeneficiados.Padre_Docent_M_9_12 != 0 ? datosBeneficiados.Padre_Docent_M_9_12.ToString() : "0";
                txtPadreDoc_H_13_15.Value = datosBeneficiados.Padre_Docent_H_13_15 != 0 ? datosBeneficiados.Padre_Docent_H_13_15.ToString() : "0";
                txtPadreDoc_M_13_15.Value = datosBeneficiados.Padre_Docent_M_13_15 != 0 ? datosBeneficiados.Padre_Docent_M_13_15.ToString() : "0";
                txtPadreDoc_H_16_18.Value = datosBeneficiados.Padre_Docent_H_16_18 != 0 ? datosBeneficiados.Padre_Docent_H_16_18.ToString() : "0";
                txtPadreDoc_M_16_18.Value = datosBeneficiados.Padre_Docent_M_16_18 != 0 ? datosBeneficiados.Padre_Docent_M_16_18.ToString() : "0";
                txtPadreDoc_H_19_22.Value = datosBeneficiados.Padre_Docent_H_19_22 != 0 ? datosBeneficiados.Padre_Docent_H_19_22.ToString() : "0";
                txtPadreDoc_M_19_22.Value = datosBeneficiados.Padre_Docent_M_19_22 != 0 ? datosBeneficiados.Padre_Docent_M_19_22.ToString() : "0";
                txtPadreDoc_H_23_60.Value = datosBeneficiados.Padre_Docent_H_23_60 != 0 ? datosBeneficiados.Padre_Docent_H_23_60.ToString() : "0";
                txtPadreDoc_M_23_60.Value = datosBeneficiados.Padre_Docent_M_23_60 != 0 ? datosBeneficiados.Padre_Docent_M_23_60.ToString() : "0";
                txtPadreDoc_H_61_mas.Value = datosBeneficiados.Padre_Docent_H_61_mas != 0 ? datosBeneficiados.Padre_Docent_H_61_mas.ToString() : "0";
                txtPadreDoc_M_61_mas.Value = datosBeneficiados.Padre_Docent_M_61_mas != 0 ? datosBeneficiados.Padre_Docent_M_61_mas.ToString() : "0";
                #endregion

                #region ## VALOR DE LOS BENEFICIADOS INSTITUCIÓN PÚBLICA Y PRIVADA
                InstPubli_Pri_H_0_4.Value = datosBeneficiados.Per_Publi_Priva_H_0_4 != 0 ? datosBeneficiados.Per_Publi_Priva_H_0_4.ToString() : "0";
                InstPubli_Pri_M_0_4.Value = datosBeneficiados.Per_Publi_Priva_M_0_4 != 0 ? datosBeneficiados.Per_Publi_Priva_M_0_4.ToString() : "0";
                InstPubli_Pri_H_5_8.Value = datosBeneficiados.Per_Publi_Priva_H_5_8 != 0 ? datosBeneficiados.Per_Publi_Priva_H_5_8.ToString() : "0";
                InstPubli_Pri_M_5_8.Value = datosBeneficiados.Per_Publi_Priva_M_5_8 != 0 ? datosBeneficiados.Per_Publi_Priva_M_5_8.ToString() : "0";
                InstPubli_Pri_H_9_12.Value = datosBeneficiados.Per_Publi_Priva_H_9_12 != 0 ? datosBeneficiados.Per_Publi_Priva_H_9_12.ToString() : "0";
                InstPubli_Pri_M_9_12.Value = datosBeneficiados.Per_Publi_Priva_M_9_12 != 0 ? datosBeneficiados.Per_Publi_Priva_M_9_12.ToString() : "0";
                InstPubli_Pri_H_13_15.Value = datosBeneficiados.Per_Publi_Priva_H_13_15 != 0 ? datosBeneficiados.Per_Publi_Priva_H_13_15.ToString() : "0";
                InstPubli_Pri_M_13_15.Value = datosBeneficiados.Per_Publi_Priva_M_13_15 != 0 ? datosBeneficiados.Per_Publi_Priva_M_13_15.ToString() : "0";
                InstPubli_Pri_H_16_18.Value = datosBeneficiados.Per_Publi_Priva_H_16_18 != 0 ? datosBeneficiados.Per_Publi_Priva_H_16_18.ToString() : "0";
                InstPubli_Pri_M_16_18.Value = datosBeneficiados.Per_Publi_Priva_M_16_18 != 0 ? datosBeneficiados.Per_Publi_Priva_M_16_18.ToString() : "0";
                InstPubli_Pri_H_19_22.Value = datosBeneficiados.Per_Publi_Priva_H_19_22 != 0 ? datosBeneficiados.Per_Publi_Priva_H_19_22.ToString() : "0";
                InstPubli_Pri_M_19_22.Value = datosBeneficiados.Per_Publi_Priva_M_19_22 != 0 ? datosBeneficiados.Per_Publi_Priva_M_19_22.ToString() : "0";
                InstPubli_Pri_H_23_60.Value = datosBeneficiados.Per_Publi_Priva_H_23_60 != 0 ? datosBeneficiados.Per_Publi_Priva_H_23_60.ToString() : "0";
                InstPubli_Pri_M_23_60.Value = datosBeneficiados.Per_Publi_Priva_M_23_60 != 0 ? datosBeneficiados.Per_Publi_Priva_M_23_60.ToString() : "0";
                InstPubli_Pri_H_61_mas.Value = datosBeneficiados.Per_Publi_Priva_H_61_mas != 0 ? datosBeneficiados.Per_Publi_Priva_H_61_mas.ToString() : "0";
                InstPubli_Pri_M_61_mas.Value = datosBeneficiados.Per_Publi_Priva_M_61_mas != 0 ? datosBeneficiados.Per_Publi_Priva_M_61_mas.ToString() : "0";
                #endregion

                #region ##  BENEFICIADOS INTERNOS
                Internos_H_0_4.Value = datosBeneficiados.Interno_H_0_4 != 0 ? datosBeneficiados.Interno_H_0_4.ToString() : "0";
                Internos_M_0_4.Value = datosBeneficiados.Interno_M_0_4 != 0 ? datosBeneficiados.Interno_M_0_4.ToString() : "0";
                Internos_H_5_8.Value = datosBeneficiados.Interno_H_5_8 != 0 ? datosBeneficiados.Interno_H_5_8.ToString() : "0";
                Internos_M_5_8.Value = datosBeneficiados.Interno_M_5_8 != 0 ? datosBeneficiados.Interno_M_5_8.ToString() : "0";
                Internos_H_9_12.Value = datosBeneficiados.Interno_H_9_12 != 0 ? datosBeneficiados.Interno_H_9_12.ToString() : "0";
                Internos_M_9_12.Value = datosBeneficiados.Interno_M_9_12 != 0 ? datosBeneficiados.Interno_M_9_12.ToString() : "0";
                Internos_H_13_15.Value = datosBeneficiados.Interno_H_13_15 != 0 ? datosBeneficiados.Interno_H_13_15.ToString() : "0";
                Internos_M_13_15.Value = datosBeneficiados.Interno_M_13_15 != 0 ? datosBeneficiados.Interno_M_13_15.ToString() : "0";
                Internos_H_16_18.Value = datosBeneficiados.Interno_H_16_18 != 0 ? datosBeneficiados.Interno_H_16_18.ToString() : "0";
                Internos_M_16_18.Value = datosBeneficiados.Interno_M_16_18 != 0 ? datosBeneficiados.Interno_M_16_18.ToString() : "0";
                Internos_H_19_22.Value = datosBeneficiados.Interno_H_19_22 != 0 ? datosBeneficiados.Interno_H_19_22.ToString() : "0";
                Internos_M_19_22.Value = datosBeneficiados.Interno_M_19_22 != 0 ? datosBeneficiados.Interno_M_19_22.ToString() : "0";
                Internos_H_23_60.Value = datosBeneficiados.Interno_H_23_60 != 0 ? datosBeneficiados.Interno_H_23_60.ToString() : "0";
                Internos_M_23_60.Value = datosBeneficiados.Interno_M_23_60 != 0 ? datosBeneficiados.Interno_M_23_60.ToString() : "0";
                Internos_H_61_mas.Value = datosBeneficiados.Interno_H_61_mas != 0 ? datosBeneficiados.Interno_H_61_mas.ToString() : "0";
                Internos_M_61_mas.Value = datosBeneficiados.Interno_M_61_mas != 0 ? datosBeneficiados.Interno_M_61_mas.ToString() : "0";
                #endregion

                #region ## BENEFICIADOS FAMILIARES INTERNOS
                FamInt_H_0_4.Value = datosBeneficiados.Familiar_H_0_4 != 0 ? datosBeneficiados.Familiar_H_0_4.ToString() : "0";
                FamInt_M_0_4.Value = datosBeneficiados.Familiar_M_0_4 != 0 ? datosBeneficiados.Familiar_M_0_4.ToString() : "0";
                FamInt_H_5_8.Value = datosBeneficiados.Familiar_H_5_8 != 0 ? datosBeneficiados.Familiar_H_5_8.ToString() : "0";
                FamInt_M_5_8.Value = datosBeneficiados.Familiar_M_5_8 != 0 ? datosBeneficiados.Familiar_M_5_8.ToString() : "0";
                FamInt_H_9_12.Value = datosBeneficiados.Familiar_H_9_12 != 0 ? datosBeneficiados.Familiar_H_9_12.ToString() : "0";
                FamInt_M_9_12.Value = datosBeneficiados.Familiar_M_9_12 != 0 ? datosBeneficiados.Familiar_M_9_12.ToString() : "0";
                FamInt_H_13_15.Value = datosBeneficiados.Familiar_H_13_15 != 0 ? datosBeneficiados.Familiar_H_13_15.ToString() : "0";
                FamInt_M_13_15.Value = datosBeneficiados.Familiar_M_13_15 != 0 ? datosBeneficiados.Familiar_M_13_15.ToString() : "0";
                FamInt_H_16_18.Value = datosBeneficiados.Familiar_H_16_18 != 0 ? datosBeneficiados.Familiar_H_16_18.ToString() : "0";
                FamInt_M_16_18.Value = datosBeneficiados.Familiar_M_16_18 != 0 ? datosBeneficiados.Familiar_M_16_18.ToString() : "0";
                FamInt_H_19_22.Value = datosBeneficiados.Familiar_H_19_22 != 0 ? datosBeneficiados.Familiar_H_19_22.ToString() : "0";
                FamInt_M_19_22.Value = datosBeneficiados.Familiar_M_19_22 != 0 ? datosBeneficiados.Familiar_M_19_22.ToString() : "0";
                FamInt_H_23_60.Value = datosBeneficiados.Familiar_H_23_60 != 0 ? datosBeneficiados.Familiar_H_23_60.ToString() : "0";
                FamInt_M_23_60.Value = datosBeneficiados.Familiar_M_23_60 != 0 ? datosBeneficiados.Familiar_M_23_60.ToString() : "0";
                FamInt_H_61_mas.Value = datosBeneficiados.Familiar_H_61_mas != 0 ? datosBeneficiados.Familiar_H_61_mas.ToString() : "0";
                FamInt_M_61_mas.Value = datosBeneficiados.Familiar_M_61_mas != 0 ? datosBeneficiados.Familiar_M_61_mas.ToString() : "0";
                #endregion



                #region ## BENEFICIADOS HIJOS INTERNAS 

                txtHijos_H_0_4.Value = datosBeneficiados.HijosInter_H_0_4 != 0 ? datosBeneficiados.HijosInter_H_0_4.ToString() : "0";
                txtHijos_M_0_4.Value = datosBeneficiados.HijosInter_M_0_4 != 0 ? datosBeneficiados.HijosInter_M_0_4.ToString() : "0";
                txtHijos_H_5_8.Value = datosBeneficiados.HijosInter_H_5_8 != 0 ? datosBeneficiados.HijosInter_H_5_8.ToString() : "0";
                txtHijos_M_5_8.Value = datosBeneficiados.HijosInter_M_5_8 != 0 ? datosBeneficiados.HijosInter_M_5_8.ToString() : "0";
                txtHijos_H_9_12.Value = datosBeneficiados.HijosInter_H_9_12 != 0 ? datosBeneficiados.HijosInter_H_9_12.ToString() : "0";
                txtHijos_M_9_12.Value = datosBeneficiados.HijosInter_M_9_12 != 0 ? datosBeneficiados.HijosInter_M_9_12.ToString() : "0";
                txtHijos_H_13_15.Value = datosBeneficiados.HijosInter_H_13_15 != 0 ? datosBeneficiados.HijosInter_H_13_15.ToString() : "0";
                txtHijos_M_13_15.Value = datosBeneficiados.HijosInter_M_13_15 != 0 ? datosBeneficiados.HijosInter_M_13_15.ToString() : "0";
                txtHijos_H_16_18.Value = datosBeneficiados.HijosInter_H_16_18 != 0 ? datosBeneficiados.HijosInter_H_16_18.ToString() : "0";
                txtHijos_M_16_18.Value = datosBeneficiados.HijosInter_M_16_18 != 0 ? datosBeneficiados.HijosInter_M_16_18.ToString() : "0";
                txtHijos_H_19_22.Value = datosBeneficiados.HijosInter_H_19_22 != 0 ? datosBeneficiados.HijosInter_H_19_22.ToString() : "0";
                txtHijos_M_19_22.Value = datosBeneficiados.HijosInter_M_19_22 != 0 ? datosBeneficiados.HijosInter_M_19_22.ToString() : "0";
                txtHijos_H_23_60.Value = datosBeneficiados.HijosInter_H_23_60 != 0 ? datosBeneficiados.HijosInter_H_23_60.ToString() : "0";
                txtHijos_M_23_60.Value = datosBeneficiados.HijosInter_M_23_60 != 0 ? datosBeneficiados.HijosInter_M_23_60.ToString() : "0";
                txtHijos_H_61_mas.Value = datosBeneficiados.HijosInter_H_61_mas != 0 ? datosBeneficiados.HijosInter_H_61_mas.ToString() : "0";
                txtHijos_M_61_mas.Value = datosBeneficiados.HijosInter_M_61_mas != 0 ? datosBeneficiados.HijosInter_M_61_mas.ToString() : "0";

                #endregion

                #region ##BENEFICIADOS PRELIBERADOS 

                txtPreli_H_0_4.Value = datosBeneficiados.Prelibera_H_0_4 != 0 ? datosBeneficiados.Prelibera_H_0_4.ToString() : "0";
                txtPreli_M_0_4.Value = datosBeneficiados.Prelibera_M_0_4 != 0 ? datosBeneficiados.Prelibera_M_0_4.ToString() : "0";
                txtPreli_H_5_8.Value = datosBeneficiados.Prelibera_H_5_8 != 0 ? datosBeneficiados.Prelibera_H_5_8.ToString() : "0";
                txtPreli_M_5_8.Value = datosBeneficiados.Prelibera_M_5_8 != 0 ? datosBeneficiados.Prelibera_M_5_8.ToString() : "0";
                txtPreli_H_9_12.Value = datosBeneficiados.Prelibera_H_9_12 != 0 ? datosBeneficiados.Prelibera_H_9_12.ToString() : "0";
                txtPreli_M_9_12.Value = datosBeneficiados.Prelibera_M_9_12 != 0 ? datosBeneficiados.Prelibera_M_9_12.ToString() : "0";
                txtPreli_H_13_15.Value = datosBeneficiados.Prelibera_H_13_15 != 0 ? datosBeneficiados.Prelibera_H_13_15.ToString() : "0";
                txtPreli_M_13_15.Value = datosBeneficiados.Prelibera_M_13_15 != 0 ? datosBeneficiados.Prelibera_M_13_15.ToString() : "0";
                txtPreli_H_16_18.Value = datosBeneficiados.Prelibera_H_16_18 != 0 ? datosBeneficiados.Prelibera_H_16_18.ToString() : "0";
                txtPreli_M_16_18.Value = datosBeneficiados.Prelibera_M_16_18 != 0 ? datosBeneficiados.Prelibera_M_16_18.ToString() : "0";
                txtPreli_H_19_22.Value = datosBeneficiados.Prelibera_H_19_22 != 0 ? datosBeneficiados.Prelibera_H_19_22.ToString() : "0";
                txtPreli_M_19_22.Value = datosBeneficiados.Prelibera_M_19_22 != 0 ? datosBeneficiados.Prelibera_M_19_22.ToString() : "0";
                txtPreli_H_23_60.Value = datosBeneficiados.Prelibera_H_23_60 != 0 ? datosBeneficiados.Prelibera_H_23_60.ToString() : "0";
                txtPreli_M_23_60.Value = datosBeneficiados.Prelibera_M_23_60 != 0 ? datosBeneficiados.Prelibera_M_23_60.ToString() : "0";
                txtPreli_H_61_mas.Value = datosBeneficiados.Prelibera_H_61_mas != 0 ? datosBeneficiados.Prelibera_H_61_mas.ToString() : "0";
                txtPreli_M_61_mas.Value = datosBeneficiados.Prelibera_M_61_mas != 0 ? datosBeneficiados.Prelibera_M_61_mas.ToString() : "0";
                #endregion

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

        #region BOTON PARA SALIR DE LA EDICIÓN 
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            this.Session["idReporte_Accion"] = (object)null;
            this.Session["AccionReporte"] = (object)null;
            this.Session["idPrograma_Accion"] = (object)null;
            this.Session["ProgramaId"] = (object)null;
            Session["subpro"] = null;
            this.Response.Redirect("~/Bienvenido_DGPRS.aspx");
            this.HDFactividad.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }

        #endregion

        #region BOTON PARA GUARDAR REPORTE
        protected void lnkbtnGuardar_Click(object sender, EventArgs e)
        {
            string claveF = "";
            int idPrograma = int.Parse(Session["idPrograma_Accion"].ToString());



            if (idPrograma == 29)
            {
                claveF = "IPD-DGRS";
            }
            if (idPrograma == 30)
            {
                claveF = "MRS-DGRS";
            }
            if (idPrograma == 31)
            {
                claveF = "CSPTI-DGRS";
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

                    #region ## VALOR DE LOS BENEFICIADOS Alumnos
                    if (this.txtAlu_H_0_4.Value != "") { Alumh_0_4 = int.Parse(txtAlu_H_0_4.Value); }
                    if (this.txtAlu_M_0_4.Value != "") { Alumm_0_4 = int.Parse(txtAlu_M_0_4.Value); }
                    if (this.txtAlu_H_5_8.Value != "") { Alumh_5_8 = int.Parse(txtAlu_H_5_8.Value); }
                    if (this.txtAlu_M_5_8.Value != "") { Alumm_5_8 = int.Parse(txtAlu_M_5_8.Value); }
                    if (this.txtAlu_H_9_12.Value != "") { Alumh_9_12 = int.Parse(txtAlu_H_9_12.Value); }
                    if (this.txtAlu_M_9_12.Value != "") { Alumm_9_12 = int.Parse(txtAlu_M_9_12.Value); }
                    if (this.txtAlu_H_13_15.Value != "") { Alumh_13_15 = int.Parse(txtAlu_H_13_15.Value); }
                    if (this.txtAlu_M_13_15.Value != "") { Alumm_13_15 = int.Parse(txtAlu_M_13_15.Value); }
                    if (this.txtAlu_H_16_18.Value != "") { Alumh_16_18 = int.Parse(txtAlu_H_16_18.Value); }
                    if (this.txtAlu_M_16_18.Value != "") { Alumm_16_18 = int.Parse(txtAlu_M_16_18.Value); }
                    if (this.txtAlu_H_19_22.Value != "") { Alumh_19_22 = int.Parse(txtAlu_H_19_22.Value); }
                    if (this.txtAlu_M_19_22.Value != "") { Alumm_19_22 = int.Parse(txtAlu_M_19_22.Value); }
                    if (this.txtAlu_H_23_60.Value != "") { Alumh_23_60 = int.Parse(txtAlu_H_23_60.Value); }
                    if (this.txtAlu_M_23_60.Value != "") { Alumm_23_60 = int.Parse(txtAlu_M_23_60.Value); }
                    if (this.txtAlu_H_61_mas.Value != "") { Alumh_61_ano = int.Parse(txtAlu_H_61_mas.Value); }
                    if (this.txtAlu_M_61_mas.Value != "") { Alumm_61_ano = int.Parse(txtAlu_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS PADRES Y DOCENTES
                    if (this.txtPadreDoc_H_0_4.Value != "") { Padres_doceh_0_4 = int.Parse(txtPadreDoc_H_0_4.Value); }
                    if (this.txtPadreDoc_M_0_4.Value != "") { Padres_docem_0_4 = int.Parse(txtPadreDoc_M_0_4.Value); }
                    if (this.txtPadreDoc_H_5_8.Value != "") { Padres_doceh_5_8 = int.Parse(txtPadreDoc_H_5_8.Value); }
                    if (this.txtPadreDoc_M_5_8.Value != "") { Padres_docem_5_8 = int.Parse(txtPadreDoc_M_5_8.Value); }
                    if (this.txtPadreDoc_H_9_12.Value != "") { Padres_doceh_9_12 = int.Parse(txtPadreDoc_H_9_12.Value); }
                    if (this.txtPadreDoc_M_9_12.Value != "") { Padres_docem_9_12 = int.Parse(txtPadreDoc_M_9_12.Value); }
                    if (this.txtPadreDoc_H_13_15.Value != "") { Padres_doceh_13_15 = int.Parse(txtPadreDoc_H_13_15.Value); }
                    if (this.txtPadreDoc_M_13_15.Value != "") { Padres_docem_13_15 = int.Parse(txtPadreDoc_M_13_15.Value); }
                    if (this.txtPadreDoc_H_16_18.Value != "") { Padres_doceh_16_18 = int.Parse(txtPadreDoc_H_16_18.Value); }
                    if (this.txtPadreDoc_M_16_18.Value != "") { Padres_docem_16_18 = int.Parse(txtPadreDoc_M_16_18.Value); }
                    if (this.txtPadreDoc_H_19_22.Value != "") { Padres_doceh_19_22 = int.Parse(txtPadreDoc_H_19_22.Value); }
                    if (this.txtPadreDoc_M_19_22.Value != "") { Padres_docem_19_22 = int.Parse(txtPadreDoc_M_19_22.Value); }
                    if (this.txtPadreDoc_H_23_60.Value != "") { Padres_doceh_23_60 = int.Parse(txtPadreDoc_H_23_60.Value); }
                    if (this.txtPadreDoc_M_23_60.Value != "") { Padres_docem_23_60 = int.Parse(txtPadreDoc_M_23_60.Value); }
                    if (this.txtPadreDoc_H_61_mas.Value != "") { Padres_doceh_61_ano = int.Parse(txtPadreDoc_H_61_mas.Value); }
                    if (this.txtPadreDoc_M_61_mas.Value != "") { Padres_docem_61_ano = int.Parse(txtPadreDoc_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS INSTITUCIÓN PÚBLICA Y PRIVADA
                    if (this.InstPubli_Pri_H_0_4.Value != "") { Insti_Publi_Privah_0_4 = int.Parse(InstPubli_Pri_H_0_4.Value); }
                    if (this.InstPubli_Pri_M_0_4.Value != "") { Insti_Publi_Privam_0_4 = int.Parse(InstPubli_Pri_M_0_4.Value); }
                    if (this.InstPubli_Pri_H_5_8.Value != "") { Insti_Publi_Privah_5_8 = int.Parse(InstPubli_Pri_H_5_8.Value); }
                    if (this.InstPubli_Pri_M_5_8.Value != "") { Insti_Publi_Privam_5_8 = int.Parse(InstPubli_Pri_M_5_8.Value); }
                    if (this.InstPubli_Pri_H_9_12.Value != "") { Insti_Publi_Privah_9_12 = int.Parse(InstPubli_Pri_H_9_12.Value); }
                    if (this.InstPubli_Pri_M_9_12.Value != "") { Insti_Publi_Privam_9_12 = int.Parse(InstPubli_Pri_M_9_12.Value); }
                    if (this.InstPubli_Pri_H_13_15.Value != "") { Insti_Publi_Privah_13_15 = int.Parse(InstPubli_Pri_H_13_15.Value); }
                    if (this.InstPubli_Pri_M_13_15.Value != "") { Insti_Publi_Privam_13_15 = int.Parse(InstPubli_Pri_M_13_15.Value); }
                    if (this.InstPubli_Pri_H_16_18.Value != "") { Insti_Publi_Privah_16_18 = int.Parse(InstPubli_Pri_H_16_18.Value); }
                    if (this.InstPubli_Pri_M_16_18.Value != "") { Insti_Publi_Privam_16_18 = int.Parse(InstPubli_Pri_M_16_18.Value); }
                    if (this.InstPubli_Pri_H_19_22.Value != "") { Insti_Publi_Privah_19_22 = int.Parse(InstPubli_Pri_H_19_22.Value); }
                    if (this.InstPubli_Pri_M_19_22.Value != "") { Insti_Publi_Privam_19_22 = int.Parse(InstPubli_Pri_M_19_22.Value); }
                    if (this.InstPubli_Pri_H_23_60.Value != "") { Insti_Publi_Privah_23_60 = int.Parse(InstPubli_Pri_H_23_60.Value); }
                    if (this.InstPubli_Pri_M_23_60.Value != "") { Insti_Publi_Privam_23_60 = int.Parse(InstPubli_Pri_M_23_60.Value); }
                    if (this.InstPubli_Pri_H_61_mas.Value != "") { Insti_Publi_Privah_61_ano = int.Parse(InstPubli_Pri_H_61_mas.Value); }
                    if (this.InstPubli_Pri_M_61_mas.Value != "") { Insti_Publi_Privam_61_ano = int.Parse(InstPubli_Pri_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS INTERNOS
                    if (this.Internos_H_0_4.Value != "") { Internosh_0_4 = int.Parse(Internos_H_0_4.Value); }
                    if (this.Internos_M_0_4.Value != "") { Internosm_0_4 = int.Parse(Internos_M_0_4.Value); }
                    if (this.Internos_H_5_8.Value != "") { Internosh_5_8 = int.Parse(Internos_H_5_8.Value); }
                    if (this.Internos_M_5_8.Value != "") { Internosm_5_8 = int.Parse(Internos_M_5_8.Value); }
                    if (this.Internos_H_9_12.Value != "") { Internosh_9_12 = int.Parse(Internos_H_9_12.Value); }
                    if (this.Internos_M_9_12.Value != "") { Internosm_9_12 = int.Parse(Internos_M_9_12.Value); }
                    if (this.Internos_H_13_15.Value != "") { Internosh_13_15 = int.Parse(Internos_H_13_15.Value); }
                    if (this.Internos_M_13_15.Value != "") { Internosm_13_15 = int.Parse(Internos_M_13_15.Value); }
                    if (this.Internos_H_16_18.Value != "") { Internosh_16_18 = int.Parse(Internos_H_16_18.Value); }
                    if (this.Internos_M_16_18.Value != "") { Internosm_16_18 = int.Parse(Internos_M_16_18.Value); }
                    if (this.Internos_H_19_22.Value != "") { Internosh_19_22 = int.Parse(Internos_H_19_22.Value); }
                    if (this.Internos_M_19_22.Value != "") { Internosm_19_22 = int.Parse(Internos_M_19_22.Value); }
                    if (this.Internos_H_23_60.Value != "") { Internosh_23_60 = int.Parse(Internos_H_23_60.Value); }
                    if (this.Internos_M_23_60.Value != "") { Internosm_23_60 = int.Parse(Internos_M_23_60.Value); }
                    if (this.Internos_H_61_mas.Value != "") { Internosh_61_ano = int.Parse(Internos_H_61_mas.Value); }
                    if (this.Internos_M_61_mas.Value != "") { Internosm_61_ano = int.Parse(Internos_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS FAMILIARES INTERNOS
                    if (this.FamInt_H_0_4.Value != "") { Familiarh_0_4 = int.Parse(FamInt_H_0_4.Value); }
                    if (this.FamInt_M_0_4.Value != "") { Familiarm_0_4 = int.Parse(FamInt_M_0_4.Value); }
                    if (this.FamInt_H_5_8.Value != "") { Familiarh_5_8 = int.Parse(FamInt_H_5_8.Value); }
                    if (this.FamInt_M_5_8.Value != "") { Familiarm_5_8 = int.Parse(FamInt_M_5_8.Value); }
                    if (this.FamInt_H_9_12.Value != "") { Familiarh_9_12 = int.Parse(FamInt_H_9_12.Value); }
                    if (this.FamInt_M_9_12.Value != "") { Familiarm_9_12 = int.Parse(FamInt_M_9_12.Value); }
                    if (this.FamInt_H_13_15.Value != "") { Familiarh_13_15 = int.Parse(FamInt_H_13_15.Value); }
                    if (this.FamInt_M_13_15.Value != "") { Familiarm_13_15 = int.Parse(FamInt_M_13_15.Value); }
                    if (this.FamInt_H_16_18.Value != "") { Familiarh_16_18 = int.Parse(FamInt_H_16_18.Value); }
                    if (this.FamInt_M_16_18.Value != "") { Familiarm_16_18 = int.Parse(FamInt_M_16_18.Value); }
                    if (this.FamInt_H_19_22.Value != "") { Familiarh_19_22 = int.Parse(FamInt_H_19_22.Value); }
                    if (this.FamInt_M_19_22.Value != "") { Familiarm_19_22 = int.Parse(FamInt_M_19_22.Value); }
                    if (this.FamInt_H_23_60.Value != "") { Familiarh_23_60 = int.Parse(FamInt_H_23_60.Value); }
                    if (this.FamInt_M_23_60.Value != "") { Familiarm_23_60 = int.Parse(FamInt_M_23_60.Value); }
                    if (this.FamInt_H_61_mas.Value != "") { Familiarh_61_ano = int.Parse(FamInt_H_61_mas.Value); }
                    if (this.FamInt_M_61_mas.Value != "") { Familiarm_61_ano = int.Parse(FamInt_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS HIJOS INTERNAS 
                    if (this.txtHijos_H_0_4.Value != "") { Hijosh_0_4 = int.Parse(txtHijos_H_0_4.Value); }
                    if (this.txtHijos_M_0_4.Value != "") { Hijosm_0_4 = int.Parse(txtHijos_M_0_4.Value); }
                    if (this.txtHijos_H_5_8.Value != "") { Hijosh_5_8 = int.Parse(txtHijos_H_5_8.Value); }
                    if (this.txtHijos_M_5_8.Value != "") { Hijosm_5_8 = int.Parse(txtHijos_M_5_8.Value); }
                    if (this.txtHijos_H_9_12.Value != "") { Hijosh_9_12 = int.Parse(txtHijos_H_9_12.Value); }
                    if (this.txtHijos_M_9_12.Value != "") { Hijosm_9_12 = int.Parse(txtHijos_M_9_12.Value); }
                    if (this.txtHijos_H_13_15.Value != "") { Hijosh_13_15 = int.Parse(txtHijos_H_13_15.Value); }
                    if (this.txtHijos_M_13_15.Value != "") { Hijosm_13_15 = int.Parse(txtHijos_M_13_15.Value); }
                    if (this.txtHijos_H_16_18.Value != "") { Hijosh_16_18 = int.Parse(txtHijos_H_16_18.Value); }
                    if (this.txtHijos_M_16_18.Value != "") { Hijosm_16_18 = int.Parse(txtHijos_M_16_18.Value); }
                    if (this.txtHijos_H_19_22.Value != "") { Hijosh_19_22 = int.Parse(txtHijos_H_19_22.Value); }
                    if (this.txtHijos_M_19_22.Value != "") { Hijosm_19_22 = int.Parse(txtHijos_M_19_22.Value); }
                    if (this.txtHijos_H_23_60.Value != "") { Hijosh_23_60 = int.Parse(txtHijos_H_23_60.Value); }
                    if (this.txtHijos_M_23_60.Value != "") { Hijosm_23_60 = int.Parse(txtHijos_M_23_60.Value); }
                    if (this.txtHijos_H_61_mas.Value != "") { Hijosh_61_ano = int.Parse(txtHijos_H_61_mas.Value); }
                    if (this.txtHijos_M_61_mas.Value != "") { Hijosm_61_ano = int.Parse(txtHijos_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS PRELIBERADOS 
                    if (this.txtPreli_H_0_4.Value != "") { Preliveradoh_0_4 = int.Parse(txtPreli_H_0_4.Value); }
                    if (this.txtPreli_M_0_4.Value != "") { Preliveradom_0_4 = int.Parse(txtPreli_M_0_4.Value); }
                    if (this.txtPreli_H_5_8.Value != "") { Preliveradoh_5_8 = int.Parse(txtPreli_H_5_8.Value); }
                    if (this.txtPreli_M_5_8.Value != "") { Preliveradom_5_8 = int.Parse(txtPreli_M_5_8.Value); }
                    if (this.txtPreli_H_9_12.Value != "") { Preliveradoh_9_12 = int.Parse(txtPreli_H_9_12.Value); }
                    if (this.txtPreli_M_9_12.Value != "") { Preliveradom_9_12 = int.Parse(txtPreli_M_9_12.Value); }
                    if (this.txtPreli_H_13_15.Value != "") { Preliveradoh_13_15 = int.Parse(txtPreli_H_13_15.Value); }
                    if (this.txtPreli_M_13_15.Value != "") { Preliveradom_13_15 = int.Parse(txtPreli_M_13_15.Value); }
                    if (this.txtPreli_H_16_18.Value != "") { Preliveradoh_16_18 = int.Parse(txtPreli_H_16_18.Value); }
                    if (this.txtPreli_M_16_18.Value != "") { Preliveradom_16_18 = int.Parse(txtPreli_M_16_18.Value); }
                    if (this.txtPreli_H_19_22.Value != "") { Preliveradoh_19_22 = int.Parse(txtPreli_H_19_22.Value); }
                    if (this.txtPreli_M_19_22.Value != "") { Preliveradom_19_22 = int.Parse(txtPreli_M_19_22.Value); }
                    if (this.txtPreli_H_23_60.Value != "") { Preliveradoh_23_60 = int.Parse(txtPreli_H_23_60.Value); }
                    if (this.txtPreli_M_23_60.Value != "") { Preliveradom_23_60 = int.Parse(txtPreli_M_23_60.Value); }
                    if (this.txtPreli_H_61_mas.Value != "") { Preliveradoh_61_ano = int.Parse(txtPreli_H_61_mas.Value); }
                    if (this.txtPreli_M_61_mas.Value != "") { Preliveradom_61_ano = int.Parse(txtPreli_M_61_mas.Value); }
                    #endregion


                    int Hombre_0_4 = Alumh_0_4 + Padres_doceh_0_4 + Insti_Publi_Privah_0_4 + Internosh_0_4 + Familiarh_0_4 + Hijosh_0_4 + Preliveradoh_0_4;
                    int Hombre_5_8 = Alumh_5_8 + Padres_doceh_5_8 + Insti_Publi_Privah_5_8 + Internosh_5_8 + Familiarh_5_8 + Hijosh_5_8 + Preliveradoh_5_8;
                    int Hombre_9_12 = Alumh_9_12 + Padres_doceh_9_12 + Insti_Publi_Privah_9_12 + Internosh_9_12 + Familiarh_9_12 + Hijosh_9_12 + Preliveradoh_9_12;
                    int Hombre_13_15 = Alumh_13_15 + Padres_doceh_13_15 + Insti_Publi_Privah_13_15 + Internosh_13_15 + Familiarh_13_15 + Hijosh_13_15 + Preliveradoh_13_15;
                    int Hombre_16_18 = Alumh_16_18 + Padres_doceh_16_18 + Insti_Publi_Privah_16_18 + Internosh_16_18 + Familiarh_16_18 + Hijosh_16_18 + Preliveradoh_16_18;
                    int Hombre_19_22 = Alumh_19_22 + Padres_doceh_19_22 + Insti_Publi_Privah_19_22 + Internosh_19_22 + Familiarh_19_22 + Hijosh_19_22 + Preliveradoh_19_22;
                    int Hombre_23_60 = Alumh_23_60 + Padres_doceh_23_60 + Insti_Publi_Privah_23_60 + Internosh_23_60 + Familiarh_23_60 + Hijosh_23_60 + Preliveradoh_23_60;
                    int Hombre_60_mas = Alumh_61_ano + Padres_doceh_61_ano + Insti_Publi_Privah_61_ano + Internosh_61_ano + Familiarh_61_ano + Hijosh_61_ano + Preliveradoh_61_ano;


                    int Mujeres_0_4 = Alumm_0_4 + Padres_docem_0_4 + Insti_Publi_Privam_0_4 + Internosm_0_4 + Familiarm_0_4 + Hijosm_0_4 + Preliveradom_0_4;
                    int Mujeres_5_8 = Alumm_5_8 + Padres_docem_5_8 + Insti_Publi_Privam_5_8 + Internosm_5_8 + Familiarm_5_8 + Hijosm_5_8 + Preliveradom_5_8;
                    int Mujeres_9_12 = Alumm_9_12 + Padres_docem_9_12 + Insti_Publi_Privam_9_12 + Internosm_9_12 + Familiarm_9_12 + Hijosm_9_12 + Preliveradom_9_12;
                    int Mujeres_13_15 = Alumm_13_15 + Padres_docem_13_15 + Insti_Publi_Privam_13_15 + Internosm_13_15 + Familiarm_13_15 + Hijosm_13_15 + Preliveradom_13_15;
                    int Mujeres_16_18 = Alumm_16_18 + Padres_docem_16_18 + Insti_Publi_Privam_16_18 + Internosm_16_18 + Familiarm_16_18 + Hijosm_16_18 + Preliveradom_16_18;
                    int Mujeres_19_22 = Alumm_19_22 + Padres_docem_19_22 + Insti_Publi_Privam_19_22 + Internosm_19_22 + Familiarm_19_22 + Hijosm_19_22 + Preliveradom_19_22;
                    int Mujeres_23_60 = Alumm_23_60 + Padres_docem_23_60 + Insti_Publi_Privam_23_60 + Internosm_23_60 + Familiarm_23_60 + Hijosm_23_60 + Preliveradom_23_60;
                    int Mujeres_60_mas = Alumm_61_ano + Padres_docem_61_ano + Insti_Publi_Privam_61_ano + Internosm_61_ano + Familiarm_61_ano + Hijosm_61_ano + Preliveradom_61_ano;

                    int total0_4 = Hombre_0_4 + Mujeres_0_4;
                    int total5_8 = Hombre_5_8 + Mujeres_5_8;
                    int total9_12 = Hombre_9_12 + Mujeres_9_12;
                    int total13_15 = Hombre_13_15 + Mujeres_13_15;
                    int total16_18 = Hombre_16_18 + Mujeres_16_18;
                    int total19_22 = Hombre_19_22 + Mujeres_19_22;
                    int total23_60 = Hombre_23_60 + Mujeres_23_60;
                    int total60_mas = Hombre_60_mas + Mujeres_60_mas;


                    int Total_Hombres = Hombre_0_4 + Hombre_5_8 + Hombre_9_12 + Hombre_13_15 + Hombre_16_18 + Hombre_19_22 + Hombre_23_60 + Hombre_60_mas;

                    int Total_Mujeres = Mujeres_0_4 + Mujeres_5_8 + Mujeres_9_12 + Mujeres_13_15 + Mujeres_16_18 + Mujeres_19_22 + Mujeres_23_60 + Mujeres_60_mas;

                    NuevoRegistros.TotalHombresAtendidos = new int?(Total_Hombres);
                    NuevoRegistros.TotalMujeresAtendidas = new int?(Total_Mujeres);

                    int totalBeneficiados = Total_Hombres + Total_Mujeres;
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
                       // Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                       // Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,
                        DelegacionID = buscardelega.DelegacionID,
                        RegionID = region.RegionID,
                        MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                        LocalidadID = new int?(Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                    });


                    ctx.TB_DatosGralReporte.Add(new TB_DatosGralReporte()
                    {
                        idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),
                        Nivel = this.ddlNivel.Text == string.Empty ? "" : this.ddlNivel.Text,
                        Turno = this.ddlTurno.Text == string.Empty ? "" : this.ddlTurno.Text,
                        NombreLugar_Escuela = this.txtnombreescuela.Text == string.Empty ? "" : this.txtnombreescuela.Text.ToUpper(),
                        NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper(),
                        telcel = this.txtTelefono.Text,
                        ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper(),
                    });

                    ctx.tb_Beneficiados_dgprs.Add(new tb_Beneficiados_dgprs()
                    {
                        idResumenDiario = new Guid?(NuevoRegistros.idResumenDiario),
                        #region ##  BENEFICIADOS Alumnos
                        AlumH_0_4 = new int?(this.txtAlu_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_0_4.Value)),
                        AlummM_0_4 = new int?(this.txtAlu_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_0_4.Value)),
                        AlumH_5_8 = new int?(this.txtAlu_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_5_8.Value)),
                        AlumM_5_8 = new int?(this.txtAlu_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_5_8.Value)),
                        AlumH_9_12 = new int?(this.txtAlu_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_9_12.Value)),
                        AlumM_9_12 = new int?(this.txtAlu_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_9_12.Value)),
                        AlumH_13_15 = new int?(this.txtAlu_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_13_15.Value)),
                        AlumM_13_15 = new int?(this.txtAlu_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_13_15.Value)),
                        AlumH_16_18 = new int?(this.txtAlu_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_16_18.Value)),
                        AlumM_16_18 = new int?(this.txtAlu_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_16_18.Value)),
                        AlumH_19_22 = new int?(this.txtAlu_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_19_22.Value)),
                        AlumM_19_22 = new int?(this.txtAlu_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_19_22.Value)),
                        AlumH_23_60 = new int?(this.txtAlu_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_23_60.Value)),
                        AlumM_23_60 = new int?(this.txtAlu_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_23_60.Value)),
                        AlumH_61_mas = new int?(this.txtAlu_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_61_mas.Value)),
                        AlumM_61_mas = new int?(this.txtAlu_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_61_mas.Value)),
                        #endregion

                        #region ##  BENEFICIADOS PADRES Y DOCENTES
                        Padre_Docent_H_0_4 = new int?(this.txtPadreDoc_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_0_4.Value)),
                        Padre_Docent_M_0_4 = new int?(this.txtPadreDoc_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_0_4.Value)),
                        Padre_Docent_H_5_8 = new int?(this.txtPadreDoc_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_5_8.Value)),
                        Padre_Docent_M_5_8 = new int?(this.txtPadreDoc_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_5_8.Value)),
                        Padre_Docent_H_9_12 = new int?(this.txtPadreDoc_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_9_12.Value)),
                        Padre_Docent_M_9_12 = new int?(this.txtPadreDoc_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_9_12.Value)),
                        Padre_Docent_H_13_15 = new int?(this.txtPadreDoc_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_13_15.Value)),
                        Padre_Docent_M_13_15 = new int?(this.txtPadreDoc_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_13_15.Value)),
                        Padre_Docent_H_16_18 = new int?(this.txtPadreDoc_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_16_18.Value)),
                        Padre_Docent_M_16_18 = new int?(this.txtPadreDoc_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_16_18.Value)),
                        Padre_Docent_H_19_22 = new int?(this.txtPadreDoc_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_19_22.Value)),
                        Padre_Docent_M_19_22 = new int?(this.txtPadreDoc_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_19_22.Value)),
                        Padre_Docent_H_23_60 = new int?(this.txtPadreDoc_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_23_60.Value)),
                        Padre_Docent_M_23_60 = new int?(this.txtPadreDoc_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_23_60.Value)),
                        Padre_Docent_H_61_mas = new int?(this.txtPadreDoc_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_61_mas.Value)),
                        Padre_Docent_M_61_mas = new int?(this.txtPadreDoc_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_61_mas.Value)),
                        #endregion

                        #region ## VALOR DE LOS BENEFICIADOS INSTITUCIÓN PÚBLICA Y PRIVADA
                        Per_Publi_Priva_H_0_4 = new int?(this.InstPubli_Pri_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_0_4.Value)),
                        Per_Publi_Priva_M_0_4 = new int?(this.InstPubli_Pri_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_0_4.Value)),
                        Per_Publi_Priva_H_5_8 = new int?(this.InstPubli_Pri_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_5_8.Value)),
                        Per_Publi_Priva_M_5_8 = new int?(this.InstPubli_Pri_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_5_8.Value)),
                        Per_Publi_Priva_H_9_12 = new int?(this.InstPubli_Pri_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_9_12.Value)),
                        Per_Publi_Priva_M_9_12 = new int?(this.InstPubli_Pri_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_9_12.Value)),
                        Per_Publi_Priva_H_13_15 = new int?(this.InstPubli_Pri_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_13_15.Value)),
                        Per_Publi_Priva_M_13_15 = new int?(this.InstPubli_Pri_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_13_15.Value)),
                        Per_Publi_Priva_H_16_18 = new int?(this.InstPubli_Pri_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_16_18.Value)),
                        Per_Publi_Priva_M_16_18 = new int?(this.InstPubli_Pri_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_16_18.Value)),
                        Per_Publi_Priva_H_19_22 = new int?(this.InstPubli_Pri_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_19_22.Value)),
                        Per_Publi_Priva_M_19_22 = new int?(this.InstPubli_Pri_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_19_22.Value)),
                        Per_Publi_Priva_H_23_60 = new int?(this.InstPubli_Pri_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_23_60.Value)),
                        Per_Publi_Priva_M_23_60 = new int?(this.InstPubli_Pri_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_23_60.Value)),
                        Per_Publi_Priva_H_61_mas = new int?(this.InstPubli_Pri_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_61_mas.Value)),
                        Per_Publi_Priva_M_61_mas = new int?(this.InstPubli_Pri_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_61_mas.Value)),
                        #endregion

                        #region ##  BENEFICIADOS INTERNOS

                        Interno_H_0_4 = new int?(this.Internos_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_0_4.Value)),
                        Interno_M_0_4 = new int?(this.Internos_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_0_4.Value)),
                        Interno_H_5_8 = new int?(this.Internos_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_5_8.Value)),
                        Interno_M_5_8 = new int?(this.Internos_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_5_8.Value)),
                        Interno_H_9_12 = new int?(this.Internos_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_9_12.Value)),
                        Interno_M_9_12 = new int?(this.Internos_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_9_12.Value)),
                        Interno_H_13_15 = new int?(this.Internos_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_13_15.Value)),
                        Interno_M_13_15 = new int?(this.Internos_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_13_15.Value)),
                        Interno_H_16_18 = new int?(this.Internos_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_16_18.Value)),
                        Interno_M_16_18 = new int?(this.Internos_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_16_18.Value)),
                        Interno_H_19_22 = new int?(this.Internos_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_19_22.Value)),
                        Interno_M_19_22 = new int?(this.Internos_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_19_22.Value)),
                        Interno_H_23_60 = new int?(this.Internos_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_23_60.Value)),
                        Interno_M_23_60 = new int?(this.Internos_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_23_60.Value)),
                        Interno_H_61_mas = new int?(this.Internos_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_61_mas.Value)),
                        Interno_M_61_mas = new int?(this.Internos_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_61_mas.Value)),
                        #endregion

                        #region ## BENEFICIADOS FAMILIARES INTERNOS
                        Familiar_H_0_4 = new int?(this.FamInt_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_0_4.Value)),
                        Familiar_M_0_4 = new int?(this.FamInt_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_0_4.Value)),
                        Familiar_H_5_8 = new int?(this.FamInt_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_5_8.Value)),
                        Familiar_M_5_8 = new int?(this.FamInt_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_5_8.Value)),
                        Familiar_H_9_12 = new int?(this.FamInt_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_9_12.Value)),
                        Familiar_M_9_12 = new int?(this.FamInt_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_9_12.Value)),
                        Familiar_H_13_15 = new int?(this.FamInt_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_13_15.Value)),
                        Familiar_M_13_15 = new int?(this.FamInt_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_13_15.Value)),
                        Familiar_H_16_18 = new int?(this.FamInt_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_16_18.Value)),
                        Familiar_M_16_18 = new int?(this.FamInt_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_16_18.Value)),
                        Familiar_H_19_22 = new int?(this.FamInt_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_19_22.Value)),
                        Familiar_M_19_22 = new int?(this.FamInt_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_19_22.Value)),
                        Familiar_H_23_60 = new int?(this.FamInt_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_23_60.Value)),
                        Familiar_M_23_60 = new int?(this.FamInt_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_23_60.Value)),
                        Familiar_H_61_mas = new int?(this.FamInt_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_61_mas.Value)),
                        Familiar_M_61_mas = new int?(this.FamInt_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_61_mas.Value)),

                        #endregion

                        #region ## BENEFICIADOS HIJOS INTERNAS 
                        HijosInter_H_0_4 = new int?(this.txtHijos_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_0_4.Value)),
                        HijosInter_M_0_4 = new int?(this.txtHijos_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_0_4.Value)),
                        HijosInter_H_5_8 = new int?(this.txtHijos_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_5_8.Value)),
                        HijosInter_M_5_8 = new int?(this.txtHijos_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_5_8.Value)),
                        HijosInter_H_9_12 = new int?(this.txtHijos_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_9_12.Value)),
                        HijosInter_M_9_12 = new int?(this.txtHijos_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_9_12.Value)),
                        HijosInter_H_13_15 = new int?(this.txtHijos_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_13_15.Value)),
                        HijosInter_M_13_15 = new int?(this.txtHijos_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_13_15.Value)),
                        HijosInter_H_16_18 = new int?(this.txtHijos_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_16_18.Value)),
                        HijosInter_M_16_18 = new int?(this.txtHijos_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_16_18.Value)),
                        HijosInter_H_19_22 = new int?(this.txtHijos_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_19_22.Value)),
                        HijosInter_M_19_22 = new int?(this.txtHijos_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_19_22.Value)),
                        HijosInter_H_23_60 = new int?(this.txtHijos_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_23_60.Value)),
                        HijosInter_M_23_60 = new int?(this.txtHijos_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_23_60.Value)),
                        HijosInter_H_61_mas = new int?(this.txtHijos_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_61_mas.Value)),
                        HijosInter_M_61_mas = new int?(this.txtHijos_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_61_mas.Value)),

                        #endregion

                        #region ##BENEFICIADOS PRELIBERADOS 
                        Prelibera_H_0_4 = new int?(this.txtPreli_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_0_4.Value)),
                        Prelibera_M_0_4 = new int?(this.txtPreli_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_0_4.Value)),
                        Prelibera_H_5_8 = new int?(this.txtPreli_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_5_8.Value)),
                        Prelibera_M_5_8 = new int?(this.txtPreli_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_5_8.Value)),
                        Prelibera_H_9_12 = new int?(this.txtPreli_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_9_12.Value)),
                        Prelibera_M_9_12 = new int?(this.txtPreli_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_9_12.Value)),
                        Prelibera_H_13_15 = new int?(this.txtPreli_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_13_15.Value)),
                        Prelibera_M_13_15 = new int?(this.txtPreli_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_13_15.Value)),
                        Prelibera_H_16_18 = new int?(this.txtPreli_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_16_18.Value)),
                        Prelibera_M_16_18 = new int?(this.txtPreli_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_16_18.Value)),
                        Prelibera_H_19_22 = new int?(this.txtPreli_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_19_22.Value)),
                        Prelibera_M_19_22 = new int?(this.txtPreli_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_19_22.Value)),
                        Prelibera_H_23_60 = new int?(this.txtPreli_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_23_60.Value)),
                        Prelibera_M_23_60 = new int?(this.txtPreli_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_23_60.Value)),
                        Prelibera_H_61_mas = new int?(this.txtPreli_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_61_mas.Value)),
                        Prelibera_M_61_mas = new int?(this.txtPreli_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_61_mas.Value)),
                        #endregion


                        Total_H_0_4 = new int?(Hombre_0_4 == 0 ? 0 : Convert.ToInt32(Hombre_0_4)),
                        Total_M_0_4 = new int?(Mujeres_0_4 == 0 ? 0 : Convert.ToInt32(Mujeres_0_4)),
                        Total_0_4 = new int?(total0_4 == 0 ? 0 : Convert.ToInt32(total0_4)),

                        Total_H_5_8 = new int?(Hombre_5_8 == 0 ? 0 : Convert.ToInt32(Hombre_5_8)),
                        Total_M_5_8 = new int?(Mujeres_5_8 == 0 ? 0 : Convert.ToInt32(Mujeres_5_8)),
                        Total_5_8 = new int?(total5_8 == 0 ? 0 : Convert.ToInt32(total5_8)),

                        Total_H_9_12 = new int?(Hombre_9_12 == 0 ? 0 : Convert.ToInt32(Hombre_9_12)),
                        Total_M_9_12 = new int?(Mujeres_9_12 == 0 ? 0 : Convert.ToInt32(Mujeres_9_12)),
                        Total_9_12 = new int?(total9_12 == 0 ? 0 : Convert.ToInt32(total9_12)),

                        Total_H_13_15 = new int?(Hombre_13_15 == 0 ? 0 : Convert.ToInt32(Hombre_13_15)),
                        Total_M_13_15 = new int?(Mujeres_13_15 == 0 ? 0 : Convert.ToInt32(Mujeres_13_15)),
                        Total_13_15 = new int?(total13_15 == 0 ? 0 : Convert.ToInt32(total13_15)),

                        Total_H_16_18 = new int?(Hombre_16_18 == 0 ? 0 : Convert.ToInt32(Hombre_16_18)),
                        Total_M_16_18 = new int?(Mujeres_16_18 == 0 ? 0 : Convert.ToInt32(Mujeres_16_18)),
                        Total_16_18 = new int?(total16_18 == 0 ? 0 : Convert.ToInt32(total16_18)),

                        Total_H_19_22 = new int?(Hombre_19_22 == 0 ? 0 : Convert.ToInt32(Hombre_19_22)),
                        Total_M_19_22 = new int?(Mujeres_19_22 == 0 ? 0 : Convert.ToInt32(Mujeres_19_22)),
                        Total_19_22 = new int?(total19_22 == 0 ? 0 : Convert.ToInt32(total19_22)),

                        Total_H_23_60 = new int?(Hombre_23_60 == 0 ? 0 : Convert.ToInt32(Hombre_23_60)),
                        Total_M_23_60 = new int?(Mujeres_23_60 == 0 ? 0 : Convert.ToInt32(Mujeres_23_60)),
                        Total_23_60 = new int?(total23_60 == 0 ? 0 : Convert.ToInt32(total23_60)),

                        Total_H_61_mas = new int?(Hombre_60_mas == 0 ? 0 : Convert.ToInt32(Hombre_60_mas)),
                        Total_M_61_mas = new int?(Mujeres_60_mas == 0 ? 0 : Convert.ToInt32(Mujeres_60_mas)),
                        Total_61_mas = new int?(total60_mas == 0 ? 0 : Convert.ToInt32(total60_mas)),

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
                        Descripcion = "Nuevo registro de reporte de actividades DGPRS",
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


        #region ## BOTON PARA GUARDAR LA EDICION
        protected void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            Guid idExpediente = Guid.Parse(HDFactividad.Value);

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


                    #region ## VALOR DE LOS BENEFICIADOS Alumnos
                    if (this.txtAlu_H_0_4.Value != "") { Alumh_0_4 = int.Parse(txtAlu_H_0_4.Value); }
                    if (this.txtAlu_M_0_4.Value != "") { Alumm_0_4 = int.Parse(txtAlu_M_0_4.Value); }
                    if (this.txtAlu_H_5_8.Value != "") { Alumh_5_8 = int.Parse(txtAlu_H_5_8.Value); }
                    if (this.txtAlu_M_5_8.Value != "") { Alumm_5_8 = int.Parse(txtAlu_M_5_8.Value); }
                    if (this.txtAlu_H_9_12.Value != "") { Alumh_9_12 = int.Parse(txtAlu_H_9_12.Value); }
                    if (this.txtAlu_M_9_12.Value != "") { Alumm_9_12 = int.Parse(txtAlu_M_9_12.Value); }
                    if (this.txtAlu_H_13_15.Value != "") { Alumh_13_15 = int.Parse(txtAlu_H_13_15.Value); }
                    if (this.txtAlu_M_13_15.Value != "") { Alumm_13_15 = int.Parse(txtAlu_M_13_15.Value); }
                    if (this.txtAlu_H_16_18.Value != "") { Alumh_16_18 = int.Parse(txtAlu_H_16_18.Value); }
                    if (this.txtAlu_M_16_18.Value != "") { Alumm_16_18 = int.Parse(txtAlu_M_16_18.Value); }
                    if (this.txtAlu_H_19_22.Value != "") { Alumh_19_22 = int.Parse(txtAlu_H_19_22.Value); }
                    if (this.txtAlu_M_19_22.Value != "") { Alumm_19_22 = int.Parse(txtAlu_M_19_22.Value); }
                    if (this.txtAlu_H_23_60.Value != "") { Alumh_23_60 = int.Parse(txtAlu_H_23_60.Value); }
                    if (this.txtAlu_M_23_60.Value != "") { Alumm_23_60 = int.Parse(txtAlu_M_23_60.Value); }
                    if (this.txtAlu_H_61_mas.Value != "") { Alumh_61_ano = int.Parse(txtAlu_H_61_mas.Value); }
                    if (this.txtAlu_M_61_mas.Value != "") { Alumm_61_ano = int.Parse(txtAlu_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS PADRES Y DOCENTES
                    if (this.txtPadreDoc_H_0_4.Value != "") { Padres_doceh_0_4 = int.Parse(txtPadreDoc_H_0_4.Value); }
                    if (this.txtPadreDoc_M_0_4.Value != "") { Padres_docem_0_4 = int.Parse(txtPadreDoc_M_0_4.Value); }
                    if (this.txtPadreDoc_H_5_8.Value != "") { Padres_doceh_5_8 = int.Parse(txtPadreDoc_H_5_8.Value); }
                    if (this.txtPadreDoc_M_5_8.Value != "") { Padres_docem_5_8 = int.Parse(txtPadreDoc_M_5_8.Value); }
                    if (this.txtPadreDoc_H_9_12.Value != "") { Padres_doceh_9_12 = int.Parse(txtPadreDoc_H_9_12.Value); }
                    if (this.txtPadreDoc_M_9_12.Value != "") { Padres_docem_9_12 = int.Parse(txtPadreDoc_M_9_12.Value); }
                    if (this.txtPadreDoc_H_13_15.Value != "") { Padres_doceh_13_15 = int.Parse(txtPadreDoc_H_13_15.Value); }
                    if (this.txtPadreDoc_M_13_15.Value != "") { Padres_docem_13_15 = int.Parse(txtPadreDoc_M_13_15.Value); }
                    if (this.txtPadreDoc_H_16_18.Value != "") { Padres_doceh_16_18 = int.Parse(txtPadreDoc_H_16_18.Value); }
                    if (this.txtPadreDoc_M_16_18.Value != "") { Padres_docem_16_18 = int.Parse(txtPadreDoc_M_16_18.Value); }
                    if (this.txtPadreDoc_H_19_22.Value != "") { Padres_doceh_19_22 = int.Parse(txtPadreDoc_H_19_22.Value); }
                    if (this.txtPadreDoc_M_19_22.Value != "") { Padres_docem_19_22 = int.Parse(txtPadreDoc_M_19_22.Value); }
                    if (this.txtPadreDoc_H_23_60.Value != "") { Padres_doceh_23_60 = int.Parse(txtPadreDoc_H_23_60.Value); }
                    if (this.txtPadreDoc_M_23_60.Value != "") { Padres_docem_23_60 = int.Parse(txtPadreDoc_M_23_60.Value); }
                    if (this.txtPadreDoc_H_61_mas.Value != "") { Padres_doceh_61_ano = int.Parse(txtPadreDoc_H_61_mas.Value); }
                    if (this.txtPadreDoc_M_61_mas.Value != "") { Padres_docem_61_ano = int.Parse(txtPadreDoc_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS INSTITUCIÓN PÚBLICA Y PRIVADA
                    if (this.InstPubli_Pri_H_0_4.Value != "") { Insti_Publi_Privah_0_4 = int.Parse(InstPubli_Pri_H_0_4.Value); }
                    if (this.InstPubli_Pri_M_0_4.Value != "") { Insti_Publi_Privam_0_4 = int.Parse(InstPubli_Pri_M_0_4.Value); }
                    if (this.InstPubli_Pri_H_5_8.Value != "") { Insti_Publi_Privah_5_8 = int.Parse(InstPubli_Pri_H_5_8.Value); }
                    if (this.InstPubli_Pri_M_5_8.Value != "") { Insti_Publi_Privam_5_8 = int.Parse(InstPubli_Pri_M_5_8.Value); }
                    if (this.InstPubli_Pri_H_9_12.Value != "") { Insti_Publi_Privah_9_12 = int.Parse(InstPubli_Pri_H_9_12.Value); }
                    if (this.InstPubli_Pri_M_9_12.Value != "") { Insti_Publi_Privam_9_12 = int.Parse(InstPubli_Pri_M_9_12.Value); }
                    if (this.InstPubli_Pri_H_13_15.Value != "") { Insti_Publi_Privah_13_15 = int.Parse(InstPubli_Pri_H_13_15.Value); }
                    if (this.InstPubli_Pri_M_13_15.Value != "") { Insti_Publi_Privam_13_15 = int.Parse(InstPubli_Pri_M_13_15.Value); }
                    if (this.InstPubli_Pri_H_16_18.Value != "") { Insti_Publi_Privah_16_18 = int.Parse(InstPubli_Pri_H_16_18.Value); }
                    if (this.InstPubli_Pri_M_16_18.Value != "") { Insti_Publi_Privam_16_18 = int.Parse(InstPubli_Pri_M_16_18.Value); }
                    if (this.InstPubli_Pri_H_19_22.Value != "") { Insti_Publi_Privah_19_22 = int.Parse(InstPubli_Pri_H_19_22.Value); }
                    if (this.InstPubli_Pri_M_19_22.Value != "") { Insti_Publi_Privam_19_22 = int.Parse(InstPubli_Pri_M_19_22.Value); }
                    if (this.InstPubli_Pri_H_23_60.Value != "") { Insti_Publi_Privah_23_60 = int.Parse(InstPubli_Pri_H_23_60.Value); }
                    if (this.InstPubli_Pri_M_23_60.Value != "") { Insti_Publi_Privam_23_60 = int.Parse(InstPubli_Pri_M_23_60.Value); }
                    if (this.InstPubli_Pri_H_61_mas.Value != "") { Insti_Publi_Privah_61_ano = int.Parse(InstPubli_Pri_H_61_mas.Value); }
                    if (this.InstPubli_Pri_M_61_mas.Value != "") { Insti_Publi_Privam_61_ano = int.Parse(InstPubli_Pri_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS INTERNOS
                    if (this.Internos_H_0_4.Value != "") { Internosh_0_4 = int.Parse(Internos_H_0_4.Value); }
                    if (this.Internos_M_0_4.Value != "") { Internosm_0_4 = int.Parse(Internos_M_0_4.Value); }
                    if (this.Internos_H_5_8.Value != "") { Internosh_5_8 = int.Parse(Internos_H_5_8.Value); }
                    if (this.Internos_M_5_8.Value != "") { Internosm_5_8 = int.Parse(Internos_M_5_8.Value); }
                    if (this.Internos_H_9_12.Value != "") { Internosh_9_12 = int.Parse(Internos_H_9_12.Value); }
                    if (this.Internos_M_9_12.Value != "") { Internosm_9_12 = int.Parse(Internos_M_9_12.Value); }
                    if (this.Internos_H_13_15.Value != "") { Internosh_13_15 = int.Parse(Internos_H_13_15.Value); }
                    if (this.Internos_M_13_15.Value != "") { Internosm_13_15 = int.Parse(Internos_M_13_15.Value); }
                    if (this.Internos_H_16_18.Value != "") { Internosh_16_18 = int.Parse(Internos_H_16_18.Value); }
                    if (this.Internos_M_16_18.Value != "") { Internosm_16_18 = int.Parse(Internos_M_16_18.Value); }
                    if (this.Internos_H_19_22.Value != "") { Internosh_19_22 = int.Parse(Internos_H_19_22.Value); }
                    if (this.Internos_M_19_22.Value != "") { Internosm_19_22 = int.Parse(Internos_M_19_22.Value); }
                    if (this.Internos_H_23_60.Value != "") { Internosh_23_60 = int.Parse(Internos_H_23_60.Value); }
                    if (this.Internos_M_23_60.Value != "") { Internosm_23_60 = int.Parse(Internos_M_23_60.Value); }
                    if (this.Internos_H_61_mas.Value != "") { Internosh_61_ano = int.Parse(Internos_H_61_mas.Value); }
                    if (this.Internos_M_61_mas.Value != "") { Internosm_61_ano = int.Parse(Internos_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS FAMILIARES INTERNOS
                    if (this.FamInt_H_0_4.Value != "") { Familiarh_0_4 = int.Parse(FamInt_H_0_4.Value); }
                    if (this.FamInt_M_0_4.Value != "") { Familiarm_0_4 = int.Parse(FamInt_M_0_4.Value); }
                    if (this.FamInt_H_5_8.Value != "") { Familiarh_5_8 = int.Parse(FamInt_H_5_8.Value); }
                    if (this.FamInt_M_5_8.Value != "") { Familiarm_5_8 = int.Parse(FamInt_M_5_8.Value); }
                    if (this.FamInt_H_9_12.Value != "") { Familiarh_9_12 = int.Parse(FamInt_H_9_12.Value); }
                    if (this.FamInt_M_9_12.Value != "") { Familiarm_9_12 = int.Parse(FamInt_M_9_12.Value); }
                    if (this.FamInt_H_13_15.Value != "") { Familiarh_13_15 = int.Parse(FamInt_H_13_15.Value); }
                    if (this.FamInt_M_13_15.Value != "") { Familiarm_13_15 = int.Parse(FamInt_M_13_15.Value); }
                    if (this.FamInt_H_16_18.Value != "") { Familiarh_16_18 = int.Parse(FamInt_H_16_18.Value); }
                    if (this.FamInt_M_16_18.Value != "") { Familiarm_16_18 = int.Parse(FamInt_M_16_18.Value); }
                    if (this.FamInt_H_19_22.Value != "") { Familiarh_19_22 = int.Parse(FamInt_H_19_22.Value); }
                    if (this.FamInt_M_19_22.Value != "") { Familiarm_19_22 = int.Parse(FamInt_M_19_22.Value); }
                    if (this.FamInt_H_23_60.Value != "") { Familiarh_23_60 = int.Parse(FamInt_H_23_60.Value); }
                    if (this.FamInt_M_23_60.Value != "") { Familiarm_23_60 = int.Parse(FamInt_M_23_60.Value); }
                    if (this.FamInt_H_61_mas.Value != "") { Familiarh_61_ano = int.Parse(FamInt_H_61_mas.Value); }
                    if (this.FamInt_M_61_mas.Value != "") { Familiarm_61_ano = int.Parse(FamInt_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS HIJOS INTERNAS 
                    if (this.txtHijos_H_0_4.Value != "") { Hijosh_0_4 = int.Parse(txtHijos_H_0_4.Value); }
                    if (this.txtHijos_M_0_4.Value != "") { Hijosm_0_4 = int.Parse(txtHijos_M_0_4.Value); }
                    if (this.txtHijos_H_5_8.Value != "") { Hijosh_5_8 = int.Parse(txtHijos_H_5_8.Value); }
                    if (this.txtHijos_M_5_8.Value != "") { Hijosm_5_8 = int.Parse(txtHijos_M_5_8.Value); }
                    if (this.txtHijos_H_9_12.Value != "") { Hijosh_9_12 = int.Parse(txtHijos_H_9_12.Value); }
                    if (this.txtHijos_M_9_12.Value != "") { Hijosm_9_12 = int.Parse(txtHijos_M_9_12.Value); }
                    if (this.txtHijos_H_13_15.Value != "") { Hijosh_13_15 = int.Parse(txtHijos_H_13_15.Value); }
                    if (this.txtHijos_M_13_15.Value != "") { Hijosm_13_15 = int.Parse(txtHijos_M_13_15.Value); }
                    if (this.txtHijos_H_16_18.Value != "") { Hijosh_16_18 = int.Parse(txtHijos_H_16_18.Value); }
                    if (this.txtHijos_M_16_18.Value != "") { Hijosm_16_18 = int.Parse(txtHijos_M_16_18.Value); }
                    if (this.txtHijos_H_19_22.Value != "") { Hijosh_19_22 = int.Parse(txtHijos_H_19_22.Value); }
                    if (this.txtHijos_M_19_22.Value != "") { Hijosm_19_22 = int.Parse(txtHijos_M_19_22.Value); }
                    if (this.txtHijos_H_23_60.Value != "") { Hijosh_23_60 = int.Parse(txtHijos_H_23_60.Value); }
                    if (this.txtHijos_M_23_60.Value != "") { Hijosm_23_60 = int.Parse(txtHijos_M_23_60.Value); }
                    if (this.txtHijos_H_61_mas.Value != "") { Hijosh_61_ano = int.Parse(txtHijos_H_61_mas.Value); }
                    if (this.txtHijos_M_61_mas.Value != "") { Hijosm_61_ano = int.Parse(txtHijos_M_61_mas.Value); }
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS PRELIBERADOS 
                    if (this.txtPreli_H_0_4.Value != "") { Preliveradoh_0_4 = int.Parse(txtPreli_H_0_4.Value); }
                    if (this.txtPreli_M_0_4.Value != "") { Preliveradom_0_4 = int.Parse(txtPreli_M_0_4.Value); }
                    if (this.txtPreli_H_5_8.Value != "") { Preliveradoh_5_8 = int.Parse(txtPreli_H_5_8.Value); }
                    if (this.txtPreli_M_5_8.Value != "") { Preliveradom_5_8 = int.Parse(txtPreli_M_5_8.Value); }
                    if (this.txtPreli_H_9_12.Value != "") { Preliveradoh_9_12 = int.Parse(txtPreli_H_9_12.Value); }
                    if (this.txtPreli_M_9_12.Value != "") { Preliveradom_9_12 = int.Parse(txtPreli_M_9_12.Value); }
                    if (this.txtPreli_H_13_15.Value != "") { Preliveradoh_13_15 = int.Parse(txtPreli_H_13_15.Value); }
                    if (this.txtPreli_M_13_15.Value != "") { Preliveradom_13_15 = int.Parse(txtPreli_M_13_15.Value); }
                    if (this.txtPreli_H_16_18.Value != "") { Preliveradoh_16_18 = int.Parse(txtPreli_H_16_18.Value); }
                    if (this.txtPreli_M_16_18.Value != "") { Preliveradom_16_18 = int.Parse(txtPreli_M_16_18.Value); }
                    if (this.txtPreli_H_19_22.Value != "") { Preliveradoh_19_22 = int.Parse(txtPreli_H_19_22.Value); }
                    if (this.txtPreli_M_19_22.Value != "") { Preliveradom_19_22 = int.Parse(txtPreli_M_19_22.Value); }
                    if (this.txtPreli_H_23_60.Value != "") { Preliveradoh_23_60 = int.Parse(txtPreli_H_23_60.Value); }
                    if (this.txtPreli_M_23_60.Value != "") { Preliveradom_23_60 = int.Parse(txtPreli_M_23_60.Value); }
                    if (this.txtPreli_H_61_mas.Value != "") { Preliveradoh_61_ano = int.Parse(txtPreli_H_61_mas.Value); }
                    if (this.txtPreli_M_61_mas.Value != "") { Preliveradom_61_ano = int.Parse(txtPreli_M_61_mas.Value); }
                    #endregion


                    int Hombre_0_4 = Alumh_0_4 + Padres_doceh_0_4 + Insti_Publi_Privah_0_4 + Internosh_0_4 + Familiarh_0_4 + Hijosh_0_4 + Preliveradoh_0_4;
                    int Hombre_5_8 = Alumh_5_8 + Padres_doceh_5_8 + Insti_Publi_Privah_5_8 + Internosh_5_8 + Familiarh_5_8 + Hijosh_5_8 + Preliveradoh_5_8;
                    int Hombre_9_12 = Alumh_9_12 + Padres_doceh_9_12 + Insti_Publi_Privah_9_12 + Internosh_9_12 + Familiarh_9_12 + Hijosh_9_12 + Preliveradoh_9_12;
                    int Hombre_13_15 = Alumh_13_15 + Padres_doceh_13_15 + Insti_Publi_Privah_13_15 + Internosh_13_15 + Familiarh_13_15 + Hijosh_13_15 + Preliveradoh_13_15;
                    int Hombre_16_18 = Alumh_16_18 + Padres_doceh_16_18 + Insti_Publi_Privah_16_18 + Internosh_16_18 + Familiarh_16_18 + Hijosh_16_18 + Preliveradoh_16_18;
                    int Hombre_19_22 = Alumh_19_22 + Padres_doceh_19_22 + Insti_Publi_Privah_19_22 + Internosh_19_22 + Familiarh_19_22 + Hijosh_19_22 + Preliveradoh_19_22;
                    int Hombre_23_60 = Alumh_23_60 + Padres_doceh_23_60 + Insti_Publi_Privah_23_60 + Internosh_23_60 + Familiarh_23_60 + Hijosh_23_60 + Preliveradoh_23_60;
                    int Hombre_60_mas = Alumh_61_ano + Padres_doceh_61_ano + Insti_Publi_Privah_61_ano + Internosh_61_ano + Familiarh_61_ano + Hijosh_61_ano + Preliveradoh_61_ano;


                    int Mujeres_0_4 = Alumm_0_4 + Padres_docem_0_4 + Insti_Publi_Privam_0_4 + Internosm_0_4 + Familiarm_0_4 + Hijosm_0_4 + Preliveradom_0_4;
                    int Mujeres_5_8 = Alumm_5_8 + Padres_docem_5_8 + Insti_Publi_Privam_5_8 + Internosm_5_8 + Familiarm_5_8 + Hijosm_5_8 + Preliveradom_5_8;
                    int Mujeres_9_12 = Alumm_9_12 + Padres_docem_9_12 + Insti_Publi_Privam_9_12 + Internosm_9_12 + Familiarm_9_12 + Hijosm_9_12 + Preliveradom_9_12;
                    int Mujeres_13_15 = Alumm_13_15 + Padres_docem_13_15 + Insti_Publi_Privam_13_15 + Internosm_13_15 + Familiarm_13_15 + Hijosm_13_15 + Preliveradom_13_15;
                    int Mujeres_16_18 = Alumm_16_18 + Padres_docem_16_18 + Insti_Publi_Privam_16_18 + Internosm_16_18 + Familiarm_16_18 + Hijosm_16_18 + Preliveradom_16_18;
                    int Mujeres_19_22 = Alumm_19_22 + Padres_docem_19_22 + Insti_Publi_Privam_19_22 + Internosm_19_22 + Familiarm_19_22 + Hijosm_19_22 + Preliveradom_19_22;
                    int Mujeres_23_60 = Alumm_23_60 + Padres_docem_23_60 + Insti_Publi_Privam_23_60 + Internosm_23_60 + Familiarm_23_60 + Hijosm_23_60 + Preliveradom_23_60;
                    int Mujeres_60_mas = Alumm_61_ano + Padres_docem_61_ano + Insti_Publi_Privam_61_ano + Internosm_61_ano + Familiarm_61_ano + Hijosm_61_ano + Preliveradom_61_ano;

                    int total0_4 = Hombre_0_4 + Mujeres_0_4;
                    int total5_8 = Hombre_5_8 + Mujeres_5_8;
                    int total9_12 = Hombre_9_12 + Mujeres_9_12;
                    int total13_15 = Hombre_13_15 + Mujeres_13_15;
                    int total16_18 = Hombre_16_18 + Mujeres_16_18;
                    int total19_22 = Hombre_19_22 + Mujeres_19_22;
                    int total23_60 = Hombre_23_60 + Mujeres_23_60;
                    int total60_mas = Hombre_60_mas + Mujeres_60_mas;


                    int Total_Hombres = Hombre_0_4 + Hombre_5_8 + Hombre_9_12 + Hombre_13_15 + Hombre_16_18 + Hombre_19_22 + Hombre_23_60 + Hombre_60_mas;

                    int Total_Mujeres = Mujeres_0_4 + Mujeres_5_8 + Mujeres_9_12 + Mujeres_13_15 + Mujeres_16_18 + Mujeres_19_22 + Mujeres_23_60 + Mujeres_60_mas;

                    tbReporteDiario.TotalHombresAtendidos = new int?(Total_Hombres);
                    tbReporteDiario.TotalMujeresAtendidas = new int?(Total_Mujeres);

                    int totalBeneficiados = Total_Hombres + Total_Mujeres;
                    tbReporteDiario.total_atendidos = totalBeneficiados;


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
                    //direccionReporte.Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value;
                    //direccionReporte.Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value;
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
                        //Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                        //Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,
                        DelegacionID = buscardelega.DelegacionID,
                        RegionID = region.RegionID,
                        MunicipioID = new int?(this.ddlMuNICIPIO.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlMuNICIPIO.SelectedValue)),
                        LocalidadID = new int?(this.ddlLocalidad.SelectedValue == null ? 0 : Convert.ToInt32(this.ddlLocalidad.SelectedValue))
                    });

                TB_DatosGralReporte datosGralReporte = ctx.TB_DatosGralReporte.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
                if (datosGralReporte != null)
                {
                    datosGralReporte.Nivel = this.ddlNivel.Text == string.Empty ? "" : this.ddlNivel.Text;
                    datosGralReporte.Turno = this.ddlTurno.Text == string.Empty ? "" : this.ddlTurno.Text;
                    datosGralReporte.NombreLugar_Escuela = this.txtnombreescuela.Text == string.Empty ? "" : this.txtnombreescuela.Text.ToUpper();
                    datosGralReporte.NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper();
                    datosGralReporte.telcel = this.txtTelefono.Text;
                    datosGralReporte.ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper();


                }
                else
                    ctx.TB_DatosGralReporte.Add(new TB_DatosGralReporte()
                    {
                        idResumenDiario = new Guid?(idExpediente),
                        Nivel = this.ddlNivel.Text == string.Empty ? "" : this.ddlNivel.Text,
                        Turno = this.ddlTurno.Text == string.Empty ? "" : this.ddlTurno.Text,
                        NombreLugar_Escuela = this.txtnombreescuela.Text == string.Empty ? "" : this.txtnombreescuela.Text.ToUpper(),
                        NombreContacto = this.txtnombrecontacto.Text == string.Empty ? "" : this.txtnombrecontacto.Text.ToUpper(),
                        telcel = this.txtTelefono.Text,
                        ClavePlantel = this.txtclave.Text == string.Empty ? "" : this.txtclave.Text.ToUpper(),

                    });
                tb_Beneficiados_dgprs datosGralBenefi = ctx.tb_Beneficiados_dgprs.Where(t => t.idResumenDiario == idExpediente).FirstOrDefault();
                if (datosGralBenefi != null)
                {


                    #region ##  BENEFICIADOS Alumnos
                    datosGralBenefi.AlumH_0_4 = new int?(this.txtAlu_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_0_4.Value));
                    datosGralBenefi.AlummM_0_4 = new int?(this.txtAlu_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_0_4.Value));
                    datosGralBenefi.AlumH_5_8 = new int?(this.txtAlu_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_5_8.Value));
                    datosGralBenefi.AlumM_5_8 = new int?(this.txtAlu_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_5_8.Value));
                    datosGralBenefi.AlumH_9_12 = new int?(this.txtAlu_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_9_12.Value));
                    datosGralBenefi.AlumM_9_12 = new int?(this.txtAlu_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_9_12.Value));
                    datosGralBenefi.AlumH_13_15 = new int?(this.txtAlu_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_13_15.Value));
                    datosGralBenefi.AlumM_13_15 = new int?(this.txtAlu_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_13_15.Value));
                    datosGralBenefi.AlumH_16_18 = new int?(this.txtAlu_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_16_18.Value));
                    datosGralBenefi.AlumM_16_18 = new int?(this.txtAlu_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_16_18.Value));
                    datosGralBenefi.AlumH_19_22 = new int?(this.txtAlu_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_19_22.Value));
                    datosGralBenefi.AlumM_19_22 = new int?(this.txtAlu_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_19_22.Value));
                    datosGralBenefi.AlumH_23_60 = new int?(this.txtAlu_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_23_60.Value));
                    datosGralBenefi.AlumM_23_60 = new int?(this.txtAlu_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_23_60.Value));
                    datosGralBenefi.AlumH_61_mas = new int?(this.txtAlu_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_H_61_mas.Value));
                    datosGralBenefi.AlumM_61_mas = new int?(this.txtAlu_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtAlu_M_61_mas.Value));
                    #endregion

                    #region ##  BENEFICIADOS PADRES Y DOCENTES
                    datosGralBenefi.Padre_Docent_H_0_4 = new int?(this.txtPadreDoc_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_0_4.Value));
                    datosGralBenefi.Padre_Docent_M_0_4 = new int?(this.txtPadreDoc_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_0_4.Value));
                    datosGralBenefi.Padre_Docent_H_5_8 = new int?(this.txtPadreDoc_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_5_8.Value));
                    datosGralBenefi.Padre_Docent_M_5_8 = new int?(this.txtPadreDoc_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_5_8.Value));
                    datosGralBenefi.Padre_Docent_H_9_12 = new int?(this.txtPadreDoc_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_9_12.Value));
                    datosGralBenefi.Padre_Docent_M_9_12 = new int?(this.txtPadreDoc_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_9_12.Value));
                    datosGralBenefi.Padre_Docent_H_13_15 = new int?(this.txtPadreDoc_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_13_15.Value));
                    datosGralBenefi.Padre_Docent_M_13_15 = new int?(this.txtPadreDoc_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_13_15.Value));
                    datosGralBenefi.Padre_Docent_H_16_18 = new int?(this.txtPadreDoc_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_16_18.Value));
                    datosGralBenefi.Padre_Docent_M_16_18 = new int?(this.txtPadreDoc_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_16_18.Value));
                    datosGralBenefi.Padre_Docent_H_19_22 = new int?(this.txtPadreDoc_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_19_22.Value));
                    datosGralBenefi.Padre_Docent_M_19_22 = new int?(this.txtPadreDoc_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_19_22.Value));
                    datosGralBenefi.Padre_Docent_H_23_60 = new int?(this.txtPadreDoc_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_23_60.Value));
                    datosGralBenefi.Padre_Docent_M_23_60 = new int?(this.txtPadreDoc_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_23_60.Value));
                    datosGralBenefi.Padre_Docent_H_61_mas = new int?(this.txtPadreDoc_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_H_61_mas.Value));
                    datosGralBenefi.Padre_Docent_M_61_mas = new int?(this.txtPadreDoc_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPadreDoc_M_61_mas.Value));
                    #endregion

                    #region ## VALOR DE LOS BENEFICIADOS INSTITUCIÓN PÚBLICA Y PRIVADA
                    datosGralBenefi.Per_Publi_Priva_H_0_4 = new int?(this.InstPubli_Pri_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_0_4.Value));
                    datosGralBenefi.Per_Publi_Priva_M_0_4 = new int?(this.InstPubli_Pri_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_0_4.Value));
                    datosGralBenefi.Per_Publi_Priva_H_5_8 = new int?(this.InstPubli_Pri_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_5_8.Value));
                    datosGralBenefi.Per_Publi_Priva_M_5_8 = new int?(this.InstPubli_Pri_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_5_8.Value));
                    datosGralBenefi.Per_Publi_Priva_H_9_12 = new int?(this.InstPubli_Pri_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_9_12.Value));
                    datosGralBenefi.Per_Publi_Priva_M_9_12 = new int?(this.InstPubli_Pri_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_9_12.Value));
                    datosGralBenefi.Per_Publi_Priva_H_13_15 = new int?(this.InstPubli_Pri_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_13_15.Value));
                    datosGralBenefi.Per_Publi_Priva_M_13_15 = new int?(this.InstPubli_Pri_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_13_15.Value));
                    datosGralBenefi.Per_Publi_Priva_H_16_18 = new int?(this.InstPubli_Pri_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_16_18.Value));
                    datosGralBenefi.Per_Publi_Priva_M_16_18 = new int?(this.InstPubli_Pri_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_16_18.Value));
                    datosGralBenefi.Per_Publi_Priva_H_19_22 = new int?(this.InstPubli_Pri_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_19_22.Value));
                    datosGralBenefi.Per_Publi_Priva_M_19_22 = new int?(this.InstPubli_Pri_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_19_22.Value));
                    datosGralBenefi.Per_Publi_Priva_H_23_60 = new int?(this.InstPubli_Pri_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_23_60.Value));
                    datosGralBenefi.Per_Publi_Priva_M_23_60 = new int?(this.InstPubli_Pri_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_23_60.Value));
                    datosGralBenefi.Per_Publi_Priva_H_61_mas = new int?(this.InstPubli_Pri_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_H_61_mas.Value));
                    datosGralBenefi.Per_Publi_Priva_M_61_mas = new int?(this.InstPubli_Pri_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.InstPubli_Pri_M_61_mas.Value));
                    #endregion

                    #region ##  BENEFICIADOS INTERNOS

                    datosGralBenefi.Interno_H_0_4 = new int?(this.Internos_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_0_4.Value));
                    datosGralBenefi.Interno_M_0_4 = new int?(this.Internos_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_0_4.Value));
                    datosGralBenefi.Interno_H_5_8 = new int?(this.Internos_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_5_8.Value));
                    datosGralBenefi.Interno_M_5_8 = new int?(this.Internos_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_5_8.Value));
                    datosGralBenefi.Interno_H_9_12 = new int?(this.Internos_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_9_12.Value));
                    datosGralBenefi.Interno_M_9_12 = new int?(this.Internos_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_9_12.Value));
                    datosGralBenefi.Interno_H_13_15 = new int?(this.Internos_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_13_15.Value));
                    datosGralBenefi.Interno_M_13_15 = new int?(this.Internos_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_13_15.Value));
                    datosGralBenefi.Interno_H_16_18 = new int?(this.Internos_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_16_18.Value));
                    datosGralBenefi.Interno_M_16_18 = new int?(this.Internos_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_16_18.Value));
                    datosGralBenefi.Interno_H_19_22 = new int?(this.Internos_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_19_22.Value));
                    datosGralBenefi.Interno_M_19_22 = new int?(this.Internos_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_19_22.Value));
                    datosGralBenefi.Interno_H_23_60 = new int?(this.Internos_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_23_60.Value));
                    datosGralBenefi.Interno_M_23_60 = new int?(this.Internos_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_23_60.Value));
                    datosGralBenefi.Interno_H_61_mas = new int?(this.Internos_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.Internos_H_61_mas.Value));
                    datosGralBenefi.Interno_M_61_mas = new int?(this.Internos_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.Internos_M_61_mas.Value));
                    #endregion

                    #region ## BENEFICIADOS FAMILIARES INTERNOS
                    datosGralBenefi.Familiar_H_0_4 = new int?(this.FamInt_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_0_4.Value));
                    datosGralBenefi.Familiar_M_0_4 = new int?(this.FamInt_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_0_4.Value));
                    datosGralBenefi.Familiar_H_5_8 = new int?(this.FamInt_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_5_8.Value));
                    datosGralBenefi.Familiar_M_5_8 = new int?(this.FamInt_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_5_8.Value));
                    datosGralBenefi.Familiar_H_9_12 = new int?(this.FamInt_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_9_12.Value));
                    datosGralBenefi.Familiar_M_9_12 = new int?(this.FamInt_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_9_12.Value));
                    datosGralBenefi.Familiar_H_13_15 = new int?(this.FamInt_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_13_15.Value));
                    datosGralBenefi.Familiar_M_13_15 = new int?(this.FamInt_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_13_15.Value));
                    datosGralBenefi.Familiar_H_16_18 = new int?(this.FamInt_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_16_18.Value));
                    datosGralBenefi.Familiar_M_16_18 = new int?(this.FamInt_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_16_18.Value));
                    datosGralBenefi.Familiar_H_19_22 = new int?(this.FamInt_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_19_22.Value));
                    datosGralBenefi.Familiar_M_19_22 = new int?(this.FamInt_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_19_22.Value));
                    datosGralBenefi.Familiar_H_23_60 = new int?(this.FamInt_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_23_60.Value));
                    datosGralBenefi.Familiar_M_23_60 = new int?(this.FamInt_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_23_60.Value));
                    datosGralBenefi.Familiar_H_61_mas = new int?(this.FamInt_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.FamInt_H_61_mas.Value));
                    datosGralBenefi.Familiar_M_61_mas = new int?(this.FamInt_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.FamInt_M_61_mas.Value));

                    #endregion

                    #region ## BENEFICIADOS HIJOS INTERNAS 
                    datosGralBenefi.HijosInter_H_0_4 = new int?(this.txtHijos_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_0_4.Value));
                    datosGralBenefi.HijosInter_M_0_4 = new int?(this.txtHijos_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_0_4.Value));
                    datosGralBenefi.HijosInter_H_5_8 = new int?(this.txtHijos_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_5_8.Value));
                    datosGralBenefi.HijosInter_M_5_8 = new int?(this.txtHijos_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_5_8.Value));
                    datosGralBenefi.HijosInter_H_9_12 = new int?(this.txtHijos_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_9_12.Value));
                    datosGralBenefi.HijosInter_M_9_12 = new int?(this.txtHijos_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_9_12.Value));
                    datosGralBenefi.HijosInter_H_13_15 = new int?(this.txtHijos_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_13_15.Value));
                    datosGralBenefi.HijosInter_M_13_15 = new int?(this.txtHijos_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_13_15.Value));
                    datosGralBenefi.HijosInter_H_16_18 = new int?(this.txtHijos_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_16_18.Value));
                    datosGralBenefi.HijosInter_M_16_18 = new int?(this.txtHijos_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_16_18.Value));
                    datosGralBenefi.HijosInter_H_19_22 = new int?(this.txtHijos_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_19_22.Value));
                    datosGralBenefi.HijosInter_M_19_22 = new int?(this.txtHijos_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_19_22.Value));
                    datosGralBenefi.HijosInter_H_23_60 = new int?(this.txtHijos_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_23_60.Value));
                    datosGralBenefi.HijosInter_M_23_60 = new int?(this.txtHijos_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_23_60.Value));
                    datosGralBenefi.HijosInter_H_61_mas = new int?(this.txtHijos_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_H_61_mas.Value));
                    datosGralBenefi.HijosInter_M_61_mas = new int?(this.txtHijos_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtHijos_M_61_mas.Value));

                    #endregion

                    #region ##BENEFICIADOS PRELIBERADOS 
                    datosGralBenefi.Prelibera_H_0_4 = new int?(this.txtPreli_H_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_0_4.Value));
                    datosGralBenefi.Prelibera_M_0_4 = new int?(this.txtPreli_M_0_4.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_0_4.Value));
                    datosGralBenefi.Prelibera_H_5_8 = new int?(this.txtPreli_H_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_5_8.Value));
                    datosGralBenefi.Prelibera_M_5_8 = new int?(this.txtPreli_M_5_8.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_5_8.Value));
                    datosGralBenefi.Prelibera_H_9_12 = new int?(this.txtPreli_H_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_9_12.Value));
                    datosGralBenefi.Prelibera_M_9_12 = new int?(this.txtPreli_M_9_12.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_9_12.Value));
                    datosGralBenefi.Prelibera_H_13_15 = new int?(this.txtPreli_H_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_13_15.Value));
                    datosGralBenefi.Prelibera_M_13_15 = new int?(this.txtPreli_M_13_15.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_13_15.Value));
                    datosGralBenefi.Prelibera_H_16_18 = new int?(this.txtPreli_H_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_16_18.Value));
                    datosGralBenefi.Prelibera_M_16_18 = new int?(this.txtPreli_M_16_18.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_16_18.Value));
                    datosGralBenefi.Prelibera_H_19_22 = new int?(this.txtPreli_H_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_19_22.Value));
                    datosGralBenefi.Prelibera_M_19_22 = new int?(this.txtPreli_M_19_22.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_19_22.Value));
                    datosGralBenefi.Prelibera_H_23_60 = new int?(this.txtPreli_H_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_23_60.Value));
                    datosGralBenefi.Prelibera_M_23_60 = new int?(this.txtPreli_M_23_60.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_23_60.Value));
                    datosGralBenefi.Prelibera_H_61_mas = new int?(this.txtPreli_H_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_H_61_mas.Value));
                    datosGralBenefi.Prelibera_M_61_mas = new int?(this.txtPreli_M_61_mas.Value == "" ? 0 : Convert.ToInt32(this.txtPreli_M_61_mas.Value));
                    #endregion

                    int Hombre_0_4 = Alumh_0_4 + Padres_doceh_0_4 + Insti_Publi_Privah_0_4 + Internosh_0_4 + Familiarh_0_4 + Hijosh_0_4 + Preliveradoh_0_4;
                    int Hombre_5_8 = Alumh_5_8 + Padres_doceh_5_8 + Insti_Publi_Privah_5_8 + Internosh_5_8 + Familiarh_5_8 + Hijosh_5_8 + Preliveradoh_5_8;
                    int Hombre_9_12 = Alumh_9_12 + Padres_doceh_9_12 + Insti_Publi_Privah_9_12 + Internosh_9_12 + Familiarh_9_12 + Hijosh_9_12 + Preliveradoh_9_12;
                    int Hombre_13_15 = Alumh_13_15 + Padres_doceh_13_15 + Insti_Publi_Privah_13_15 + Internosh_13_15 + Familiarh_13_15 + Hijosh_13_15 + Preliveradoh_13_15;
                    int Hombre_16_18 = Alumh_16_18 + Padres_doceh_16_18 + Insti_Publi_Privah_16_18 + Internosh_16_18 + Familiarh_16_18 + Hijosh_16_18 + Preliveradoh_16_18;
                    int Hombre_19_22 = Alumh_19_22 + Padres_doceh_19_22 + Insti_Publi_Privah_19_22 + Internosh_19_22 + Familiarh_19_22 + Hijosh_19_22 + Preliveradoh_19_22;
                    int Hombre_23_60 = Alumh_23_60 + Padres_doceh_23_60 + Insti_Publi_Privah_23_60 + Internosh_23_60 + Familiarh_23_60 + Hijosh_23_60 + Preliveradoh_23_60;
                    int Hombre_60_mas = Alumh_61_ano + Padres_doceh_61_ano + Insti_Publi_Privah_61_ano + Internosh_61_ano + Familiarh_61_ano + Hijosh_61_ano + Preliveradoh_61_ano;


                    int Mujeres_0_4 = Alumm_0_4 + Padres_docem_0_4 + Insti_Publi_Privam_0_4 + Internosm_0_4 + Familiarm_0_4 + Hijosm_0_4 + Preliveradom_0_4;
                    int Mujeres_5_8 = Alumm_5_8 + Padres_docem_5_8 + Insti_Publi_Privam_5_8 + Internosm_5_8 + Familiarm_5_8 + Hijosm_5_8 + Preliveradom_5_8;
                    int Mujeres_9_12 = Alumm_9_12 + Padres_docem_9_12 + Insti_Publi_Privam_9_12 + Internosm_9_12 + Familiarm_9_12 + Hijosm_9_12 + Preliveradom_9_12;
                    int Mujeres_13_15 = Alumm_13_15 + Padres_docem_13_15 + Insti_Publi_Privam_13_15 + Internosm_13_15 + Familiarm_13_15 + Hijosm_13_15 + Preliveradom_13_15;
                    int Mujeres_16_18 = Alumm_16_18 + Padres_docem_16_18 + Insti_Publi_Privam_16_18 + Internosm_16_18 + Familiarm_16_18 + Hijosm_16_18 + Preliveradom_16_18;
                    int Mujeres_19_22 = Alumm_19_22 + Padres_docem_19_22 + Insti_Publi_Privam_19_22 + Internosm_19_22 + Familiarm_19_22 + Hijosm_19_22 + Preliveradom_19_22;
                    int Mujeres_23_60 = Alumm_23_60 + Padres_docem_23_60 + Insti_Publi_Privam_23_60 + Internosm_23_60 + Familiarm_23_60 + Hijosm_23_60 + Preliveradom_23_60;
                    int Mujeres_60_mas = Alumm_61_ano + Padres_docem_61_ano + Insti_Publi_Privam_61_ano + Internosm_61_ano + Familiarm_61_ano + Hijosm_61_ano + Preliveradom_61_ano;

                    int total0_4 = Hombre_0_4 + Mujeres_0_4;
                    int total5_8 = Hombre_5_8 + Mujeres_5_8;
                    int total9_12 = Hombre_9_12 + Mujeres_9_12;
                    int total13_15 = Hombre_13_15 + Mujeres_13_15;
                    int total16_18 = Hombre_16_18 + Mujeres_16_18;
                    int total19_22 = Hombre_19_22 + Mujeres_19_22;
                    int total23_60 = Hombre_23_60 + Mujeres_23_60;
                    int total60_mas = Hombre_60_mas + Mujeres_60_mas;

                    datosGralBenefi.Total_H_0_4 = new int?(Hombre_0_4 == 0 ? 0 : Convert.ToInt32(Hombre_0_4));
                    datosGralBenefi.Total_M_0_4 = new int?(Mujeres_0_4 == 0 ? 0 : Convert.ToInt32(Mujeres_0_4));
                    datosGralBenefi.Total_0_4 = new int?(total0_4 == 0 ? 0 : Convert.ToInt32(total0_4));

                    datosGralBenefi.Total_H_5_8 = new int?(Hombre_5_8 == 0 ? 0 : Convert.ToInt32(Hombre_5_8));
                    datosGralBenefi.Total_M_5_8 = new int?(Mujeres_5_8 == 0 ? 0 : Convert.ToInt32(Mujeres_5_8));
                    datosGralBenefi.Total_5_8 = new int?(total5_8 == 0 ? 0 : Convert.ToInt32(total5_8));

                    datosGralBenefi.Total_H_9_12 = new int?(Hombre_9_12 == 0 ? 0 : Convert.ToInt32(Hombre_9_12));
                    datosGralBenefi.Total_M_9_12 = new int?(Mujeres_9_12 == 0 ? 0 : Convert.ToInt32(Mujeres_9_12));
                    datosGralBenefi.Total_9_12 = new int?(total9_12 == 0 ? 0 : Convert.ToInt32(total9_12));

                    datosGralBenefi.Total_H_13_15 = new int?(Hombre_13_15 == 0 ? 0 : Convert.ToInt32(Hombre_13_15));
                    datosGralBenefi.Total_M_13_15 = new int?(Mujeres_13_15 == 0 ? 0 : Convert.ToInt32(Mujeres_13_15));
                    datosGralBenefi.Total_13_15 = new int?(total13_15 == 0 ? 0 : Convert.ToInt32(total13_15));

                    datosGralBenefi.Total_H_16_18 = new int?(Hombre_16_18 == 0 ? 0 : Convert.ToInt32(Hombre_16_18));
                    datosGralBenefi.Total_M_16_18 = new int?(Mujeres_16_18 == 0 ? 0 : Convert.ToInt32(Mujeres_16_18));
                    datosGralBenefi.Total_16_18 = new int?(total16_18 == 0 ? 0 : Convert.ToInt32(total16_18));

                    datosGralBenefi.Total_H_19_22 = new int?(Hombre_19_22 == 0 ? 0 : Convert.ToInt32(Hombre_19_22));
                    datosGralBenefi.Total_M_19_22 = new int?(Mujeres_19_22 == 0 ? 0 : Convert.ToInt32(Mujeres_19_22));
                    datosGralBenefi.Total_19_22 = new int?(total19_22 == 0 ? 0 : Convert.ToInt32(total19_22));

                    datosGralBenefi.Total_H_23_60 = new int?(Hombre_23_60 == 0 ? 0 : Convert.ToInt32(Hombre_23_60));
                    datosGralBenefi.Total_M_23_60 = new int?(Mujeres_23_60 == 0 ? 0 : Convert.ToInt32(Mujeres_23_60));
                    datosGralBenefi.Total_23_60 = new int?(total23_60 == 0 ? 0 : Convert.ToInt32(total23_60));

                    datosGralBenefi.Total_H_61_mas = new int?(Hombre_60_mas == 0 ? 0 : Convert.ToInt32(Hombre_60_mas));
                    datosGralBenefi.Total_M_61_mas = new int?(Mujeres_60_mas == 0 ? 0 : Convert.ToInt32(Mujeres_60_mas));
                    datosGralBenefi.Total_61_mas = new int?(total60_mas == 0 ? 0 : Convert.ToInt32(total60_mas));

                }

                ctx.SaveChanges();
                tbAuditoria entity = new tbAuditoria()
                {
                    auditoriaGuid = new Guid?(Guid.NewGuid()),
                    fecha = new DateTime?(DateTime.Now),
                    area = this.txtArea.Text,
                    idTipomodificacion = new int?(2),
                    PagModificacion = this.Page.Title,
                    Descripcion = "Se edito el registro de reporte de actividades ,DGPRS",
                    usuario = this.txtResponsable.Text,
                    IdABC = Convert.ToString((object)idExpediente)
                };
                ctx.tbAuditoria.Add(entity);
                ctx.SaveChanges();


                this.HDFactividad.Value = (string)null;
                this.btnGuardarEdicion.Visible = false;
                this.btnSalir.Visible = false;
                this.Session["idReporte_Accion"] = (object)null;
                this.Session["AccionReporte"] = (object)null;
                this.Session["idPrograma_Accion"] = (object)null;
                Session["subpro"] = null;
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "redirect", "alert('DATOS GUARDADOS CON EXITO'); window.location='" + this.Request.ApplicationPath + "Bienvenido_DGPRS.aspx';", true);

            }
            catch (Exception EX)
            {

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
            this.Response.Redirect("~/VistasReportes/DGRS/Vista_de_datos_DGPRS.aspx");
            this.HDFactividad.Value = (string)null;
            this.btnGuardarEdicion.Visible = false;
            this.btnSalir.Visible = false;
        }
        #endregion
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