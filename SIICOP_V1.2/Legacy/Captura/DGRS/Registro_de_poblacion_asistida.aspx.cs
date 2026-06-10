using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Captura.DGPRS
{
    public partial class Registro_de_poblacion_asistida : System.Web.UI.Page
    {
            SIICOBEntities ctx = new SIICOBEntities();
            public enum AccionReporte { Creacion, Edicion, Visualizacion }
            string sUsuarioActual;
            #region ### BENEFICIADOS
            //alumnos
            int Alum_h_0_4;
            int Alum_m_0_4;
            int Alum_h_5_8;
            int Alum_m_5_8;
            int Alum_h_9_12;
            int Alum_m_9_12;
            int Alum_h_13_15;
            int Alum_m_13_15;
            int Alum_h_16_18;
            int Alum_m_16_18;
            int Alum_h_19_22;
            int Alum_m_19_22;
            int Alum_h_23_60;
            int Alum_m_23_60;
            int Alum_h_61_ano;
            int Alum_m_61_ano;

            // PADRES Y DOCENTES
            int Padres_doce_h_0_4;
            int Padres_doce_m_0_4;
            int Padres_doce_h_5_8;
            int Padres_doce_m_5_8;
            int Padres_doce_h_9_12;
            int Padres_doce_m_9_12;
            int Padres_doce_h_13_15;
            int Padres_doce_m_13_15;
            int Padres_doce_h_16_18;
            int Padres_doce_m_16_18;
            int Padres_doce_h_19_22;
            int Padres_doce_m_19_22;
            int Padres_doce_h_23_60;
            int Padres_doce_m_23_60;
            int Padres_doce_h_61_ano;
            int Padres_doce_m_61_ano;

            //Personal de institución Publica y privada
            int Insti_Publi_Priva_h_0_4;
            int Insti_Publi_Priva_m_0_4;
            int Insti_Publi_Priva_h_5_8;
            int Insti_Publi_Priva_m_5_8;
            int Insti_Publi_Priva_h_9_12;
            int Insti_Publi_Priva_m_9_12;
            int Insti_Publi_Priva_h_13_15;
            int Insti_Publi_Priva_m_13_15;
            int Insti_Publi_Priva_h_16_18;
            int Insti_Publi_Priva_m_16_18;
            int Insti_Publi_Priva_h_19_22;
            int Insti_Publi_Priva_m_19_22;
            int Insti_Publi_Priva_h_23_60;
            int Insti_Publi_Priva_m_23_60;
            int Insti_Publi_Priva_h_61_ano;
            int Insti_Publi_Priva_m_61_ano;

            //Internos
            int Internos_h_0_4;
            int Internos_m_0_4;
            int Internos_h_5_8;
            int Internos_m_5_8;
            int Internos_h_9_12;
            int Internos_m_9_12;
            int Internos_h_13_15;
            int Internos_m_13_15;
            int Internos_h_16_18;
            int Internos_m_16_18;
            int Internos_h_19_22;
            int Internos_m_19_22;
            int Internos_h_23_60;
            int Internos_m_23_60;
            int Internos_h_61_ano;
            int Internos_m_61_ano;

            //Familar Internos
            int Familiar_h_0_4;
            int Familiar_m_0_4;
            int Familiar_h_5_8;
            int Familiar_m_5_8;
            int Familiar_h_9_12;
            int Familiar_m_9_12;
            int Familiar_h_13_15;
            int Familiar_m_13_15;
            int Familiar_h_16_18;
            int Familiar_m_16_18;
            int Familiar_h_19_22;
            int Familiar_m_19_22;
            int Familiar_h_23_60;
            int Familiar_m_23_60;
            int Familiar_h_61_ano;
            int Familiar_m_61_ano;


            //Hijos Internos
            int Hijos_h_0_4;
            int Hijos_m_0_4;
            int Hijos_h_5_8;
            int Hijos_m_5_8;
            int Hijos_h_9_12;
            int Hijos_m_9_12;
            int Hijos_h_13_15;
            int Hijos_m_13_15;
            int Hijos_h_16_18;
            int Hijos_m_16_18;
            int Hijos_h_19_22;
            int Hijos_m_19_22;
            int Hijos_h_23_60;
            int Hijos_m_23_60;
            int Hijos_h_61_ano;
            int Hijos_m_61_ano;

            //Preliverado 
            int Preliverado_h_0_4;
            int Preliverado_m_0_4;
            int Preliverado_h_5_8;
            int Preliverado_m_5_8;
            int Preliverado_h_9_12;
            int Preliverado_m_9_12;
            int Preliverado_h_13_15;
            int Preliverado_m_13_15;
            int Preliverado_h_16_18;
            int Preliverado_m_16_18;
            int Preliverado_h_19_22;
            int Preliverado_m_19_22;
            int Preliverado_h_23_60;
            int Preliverado_m_23_60;
            int Preliverado_h_61_ano;
            int Preliverado_m_61_ano;

            #endregion
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    //Primera vez que se carga la pàgina o le dieron un F5
                    if (User.IsInRole("SYSADMIN") || User.IsInRole("Administrador") || User.IsInRole("DGPRS"))
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
                                    //Session["ProgramaId"] = Convert.ToInt32(Subcompartido.programasID);
                                    //ddlsubprograma.DataBind();Session["IdProCompartido"] = Convert.ToInt32(Subcompartido.ProgramaCompartidoID);
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
                                this.Response.Redirect("~/Bienvenido_DGPRS.aspx");
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
                    this.Response.Redirect("~/Bienvenido_DGPRS.aspx");
                }
                Session["idPrograma_Accion"] = null;
            }


            protected void expediente_Edicion_Visualizacion()
            {
                if (Session["idReporte_Accion"] != null)
                {
                    try
                    {
                        Guid idExpediente = Guid.Parse(Session["idReporte_Accion"].ToString());
                        //expediente_Llenar(idExpediente);
                    }
                    catch (Exception ex) { /*salidaBandeja();*/ }
                }
                else
                {
                    //salidaBandeja();
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

                #region ## BENEFICIADOS
                Alum_h_0_4 = 0;
                Alum_m_0_4 = 0;
                Alum_h_5_8 = 0;
                Alum_m_5_8 = 0;
                Alum_h_9_12 = 0;
                Alum_m_9_12 = 0;
                Alum_h_13_15 = 0;
                Alum_m_13_15 = 0;
                Alum_h_16_18 = 0;
                Alum_m_16_18 = 0;
                Alum_h_19_22 = 0;
                Alum_m_19_22 = 0;
                Alum_h_23_60 = 0;
                Alum_m_23_60 = 0;
                Alum_h_61_ano = 0;
                Alum_m_61_ano = 0;

                // PADRES Y DOCENTES
                Padres_doce_h_0_4 = 0;
                Padres_doce_m_0_4 = 0;
                Padres_doce_h_5_8 = 0;
                Padres_doce_m_5_8 = 0;
                Padres_doce_h_9_12 = 0;
                Padres_doce_m_9_12 = 0;
                Padres_doce_h_13_15 = 0;
                Padres_doce_m_13_15 = 0;
                Padres_doce_h_16_18 = 0;
                Padres_doce_m_16_18 = 0;
                Padres_doce_h_19_22 = 0;
                Padres_doce_m_19_22 = 0;
                Padres_doce_h_23_60 = 0;
                Padres_doce_m_23_60 = 0;
                Padres_doce_h_61_ano = 0;
                Padres_doce_m_61_ano = 0;

                //Personal de institución Publica y privada
                Insti_Publi_Priva_h_0_4 = 0;
                Insti_Publi_Priva_m_0_4 = 0;
                Insti_Publi_Priva_h_5_8 = 0;
                Insti_Publi_Priva_m_5_8 = 0;
                Insti_Publi_Priva_h_9_12 = 0;
                Insti_Publi_Priva_m_9_12 = 0;
                Insti_Publi_Priva_h_13_15 = 0;
                Insti_Publi_Priva_m_13_15 = 0;
                Insti_Publi_Priva_h_16_18 = 0;
                Insti_Publi_Priva_m_16_18 = 0;
                Insti_Publi_Priva_h_19_22 = 0;
                Insti_Publi_Priva_m_19_22 = 0;
                Insti_Publi_Priva_h_23_60 = 0;
                Insti_Publi_Priva_m_23_60 = 0;
                Insti_Publi_Priva_h_61_ano = 0;
                Insti_Publi_Priva_m_61_ano = 0;

                //Internos
                Internos_h_0_4 = 0;
                Internos_m_0_4 = 0;
                Internos_h_5_8 = 0;
                Internos_m_5_8 = 0;
                Internos_h_9_12 = 0;
                Internos_m_9_12 = 0;
                Internos_h_13_15 = 0;
                Internos_m_13_15 = 0;
                Internos_h_16_18 = 0;
                Internos_m_16_18 = 0;
                Internos_h_19_22 = 0;
                Internos_m_19_22 = 0;
                Internos_h_23_60 = 0;
                Internos_m_23_60 = 0;
                Internos_h_61_ano = 0;
                Internos_m_61_ano = 0;

                //Familar Internos
                Familiar_h_0_4 = 0;
                Familiar_m_0_4 = 0;
                Familiar_h_5_8 = 0;
                Familiar_m_5_8 = 0;
                Familiar_h_9_12 = 0;
                Familiar_m_9_12 = 0;
                Familiar_h_13_15 = 0;
                Familiar_m_13_15 = 0;
                Familiar_h_16_18 = 0;
                Familiar_m_16_18 = 0;
                Familiar_h_19_22 = 0;
                Familiar_m_19_22 = 0;
                Familiar_h_23_60 = 0;
                Familiar_m_23_60 = 0;
                Familiar_h_61_ano = 0;
                Familiar_m_61_ano = 0;


                //Hijos Internos
                Hijos_h_0_4 = 0;
                Hijos_m_0_4 = 0;
                Hijos_h_5_8 = 0;
                Hijos_m_5_8 = 0;
                Hijos_h_9_12 = 0;
                Hijos_m_9_12 = 0;
                Hijos_h_13_15 = 0;
                Hijos_m_13_15 = 0;
                Hijos_h_16_18 = 0;
                Hijos_m_16_18 = 0;
                Hijos_h_19_22 = 0;
                Hijos_m_19_22 = 0;
                Hijos_h_23_60 = 0;
                Hijos_m_23_60 = 0;
                Hijos_h_61_ano = 0;
                Hijos_m_61_ano = 0;

                //Preliverado 
                Preliverado_h_0_4 = 0;
                Preliverado_m_0_4 = 0;
                Preliverado_h_5_8 = 0;
                Preliverado_m_5_8 = 0;
                Preliverado_h_9_12 = 0;
                Preliverado_m_9_12 = 0;
                Preliverado_h_13_15 = 0;
                Preliverado_m_13_15 = 0;
                Preliverado_h_16_18 = 0;
                Preliverado_m_16_18 = 0;
                Preliverado_h_19_22 = 0;
                Preliverado_m_19_22 = 0;
                Preliverado_h_23_60 = 0;
                Preliverado_m_23_60 = 0;
                Preliverado_h_61_ano = 0;
                Preliverado_m_61_ano = 0;

                #endregion ## BENEFICIADOS


                if (idPrograma == 29)
                {
                    claveF = "IPD-DGPRS";
                }
                if (idPrograma == 30)
                {
                    claveF = "MRS-DGPRS";
                }
                if (idPrograma == 31)
                {
                    claveF = "CSPTI-DGPRS";
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
                if (string.IsNullOrEmpty(route.Value) || string.IsNullOrEmpty(entrecalle1.Value) || string.IsNullOrEmpty(entrecalle2.Value) || string.IsNullOrEmpty(colony.Value))
                {
                    textoValidacion += "<li>Es obligatorio la calle, las entre calles y la colonia </ li>";
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
                        if (this.txtAlu_H_0_4.Value != "") { Alum_h_0_4 = int.Parse(txtAlu_H_0_4.Value); }
                        if (this.txtAlu_M_0_4.Value != "") { Alum_m_0_4 = int.Parse(txtAlu_M_0_4.Value); }
                        if (this.txtAlu_H_5_8.Value != "") { Alum_h_5_8 = int.Parse(txtAlu_H_5_8.Value); }
                        if (this.txtAlu_M_5_8.Value != "") { Alum_m_5_8 = int.Parse(txtAlu_M_5_8.Value); }
                        if (this.txtAlu_H_9_12.Value != "") { Alum_h_9_12 = int.Parse(txtAlu_H_9_12.Value); }
                        if (this.txtAlu_M_9_12.Value != "") { Alum_m_9_12 = int.Parse(txtAlu_M_9_12.Value); }
                        if (this.txtAlu_H_13_15.Value != "") { Alum_h_13_15 = int.Parse(txtAlu_H_13_15.Value); }
                        if (this.txtAlu_M_13_15.Value != "") { Alum_m_13_15 = int.Parse(txtAlu_M_13_15.Value); }
                        if (this.txtAlu_H_16_18.Value != "") { Alum_h_16_18 = int.Parse(txtAlu_H_16_18.Value); }
                        if (this.txtAlu_M_16_18.Value != "") { Alum_m_16_18 = int.Parse(txtAlu_M_16_18.Value); }
                        if (this.txtAlu_H_19_22.Value != "") { Alum_h_19_22 = int.Parse(txtAlu_H_19_22.Value); }
                        if (this.txtAlu_M_19_22.Value != "") { Alum_m_19_22 = int.Parse(txtAlu_M_19_22.Value); }
                        if (this.txtAlu_H_23_60.Value != "") { Alum_h_23_60 = int.Parse(txtAlu_H_23_60.Value); }
                        if (this.txtAlu_M_23_60.Value != "") { Alum_m_23_60 = int.Parse(txtAlu_M_23_60.Value); }
                        if (this.txtAlu_H_61_mas.Value != "") { Alum_h_61_ano = int.Parse(txtAlu_H_61_mas.Value); }
                        if (this.txtAlu_M_61_mas.Value != "") { Alum_m_61_ano = int.Parse(txtAlu_M_61_mas.Value); }
                        #endregion

                        #region ## VALOR DE LOS BENEFICIADOS PADRES Y DOCENTES
                        if (this.txtPadreDoc_H_0_4.Value != "") { Padres_doce_h_0_4 = int.Parse(txtPadreDoc_H_0_4.Value); }
                        if (this.txtPadreDoc_M_0_4.Value != "") { Padres_doce_m_0_4 = int.Parse(txtPadreDoc_M_0_4.Value); }
                        if (this.txtPadreDoc_H_5_8.Value != "") { Padres_doce_h_5_8 = int.Parse(txtPadreDoc_H_5_8.Value); }
                        if (this.txtPadreDoc_M_5_8.Value != "") { Padres_doce_m_5_8 = int.Parse(txtPadreDoc_M_5_8.Value); }
                        if (this.txtPadreDoc_H_9_12.Value != "") { Padres_doce_h_9_12 = int.Parse(txtPadreDoc_H_9_12.Value); }
                        if (this.txtPadreDoc_M_9_12.Value != "") { Padres_doce_m_9_12 = int.Parse(txtPadreDoc_M_9_12.Value); }
                        if (this.txtPadreDoc_H_13_15.Value != "") { Padres_doce_h_13_15 = int.Parse(txtPadreDoc_H_13_15.Value); }
                        if (this.txtPadreDoc_M_13_15.Value != "") { Padres_doce_m_13_15 = int.Parse(txtPadreDoc_M_13_15.Value); }
                        if (this.txtPadreDoc_H_16_18.Value != "") { Padres_doce_h_16_18 = int.Parse(txtPadreDoc_H_16_18.Value); }
                        if (this.txtPadreDoc_M_16_18.Value != "") { Padres_doce_m_16_18 = int.Parse(txtPadreDoc_M_16_18.Value); }
                        if (this.txtPadreDoc_H_19_22.Value != "") { Padres_doce_h_19_22 = int.Parse(txtPadreDoc_H_19_22.Value); }
                        if (this.txtPadreDoc_M_19_22.Value != "") { Padres_doce_m_19_22 = int.Parse(txtPadreDoc_M_19_22.Value); }
                        if (this.txtPadreDoc_H_23_60.Value != "") { Padres_doce_h_23_60 = int.Parse(txtPadreDoc_H_23_60.Value); }
                        if (this.txtPadreDoc_M_23_60.Value != "") { Padres_doce_m_23_60 = int.Parse(txtPadreDoc_M_23_60.Value); }
                        if (this.txtPadreDoc_H_61_mas.Value != "") { Padres_doce_h_61_ano = int.Parse(txtPadreDoc_H_61_mas.Value); }
                        if (this.txtPadreDoc_M_61_mas.Value != "") { Padres_doce_m_61_ano = int.Parse(txtPadreDoc_M_61_mas.Value); }
                        #endregion

                        #region ## VALOR DE LOS BENEFICIADOS INSTITUCIÓN PÚBLICA Y PRIVADA
                        if (this.InstPubli_Pri_H_0_4.Value != "") { Insti_Publi_Priva_h_0_4 = int.Parse(InstPubli_Pri_H_0_4.Value); }
                        if (this.InstPubli_Pri_M_0_4.Value != "") { Insti_Publi_Priva_m_0_4 = int.Parse(InstPubli_Pri_M_0_4.Value); }
                        if (this.InstPubli_Pri_H_5_8.Value != "") { Insti_Publi_Priva_h_5_8 = int.Parse(InstPubli_Pri_H_5_8.Value); }
                        if (this.InstPubli_Pri_M_5_8.Value != "") { Insti_Publi_Priva_m_5_8 = int.Parse(InstPubli_Pri_M_5_8.Value); }
                        if (this.InstPubli_Pri_H_9_12.Value != "") { Insti_Publi_Priva_h_9_12 = int.Parse(InstPubli_Pri_H_9_12.Value); }
                        if (this.InstPubli_Pri_M_9_12.Value != "") { Insti_Publi_Priva_m_9_12 = int.Parse(InstPubli_Pri_M_9_12.Value); }
                        if (this.InstPubli_Pri_H_13_15.Value != "") { Insti_Publi_Priva_h_13_15 = int.Parse(InstPubli_Pri_H_13_15.Value); }
                        if (this.InstPubli_Pri_M_13_15.Value != "") { Insti_Publi_Priva_m_13_15 = int.Parse(InstPubli_Pri_M_13_15.Value); }
                        if (this.InstPubli_Pri_H_16_18.Value != "") { Insti_Publi_Priva_h_16_18 = int.Parse(InstPubli_Pri_H_16_18.Value); }
                        if (this.InstPubli_Pri_M_16_18.Value != "") { Insti_Publi_Priva_m_16_18 = int.Parse(InstPubli_Pri_M_16_18.Value); }
                        if (this.InstPubli_Pri_H_19_22.Value != "") { Insti_Publi_Priva_h_19_22 = int.Parse(InstPubli_Pri_H_19_22.Value); }
                        if (this.InstPubli_Pri_M_19_22.Value != "") { Insti_Publi_Priva_m_19_22 = int.Parse(InstPubli_Pri_M_19_22.Value); }
                        if (this.InstPubli_Pri_H_23_60.Value != "") { Insti_Publi_Priva_h_23_60 = int.Parse(InstPubli_Pri_H_23_60.Value); }
                        if (this.InstPubli_Pri_M_23_60.Value != "") { Insti_Publi_Priva_m_23_60 = int.Parse(InstPubli_Pri_M_23_60.Value); }
                        if (this.InstPubli_Pri_H_61_mas.Value != "") { Insti_Publi_Priva_h_61_ano = int.Parse(InstPubli_Pri_H_61_mas.Value); }
                        if (this.InstPubli_Pri_M_61_mas.Value != "") { Insti_Publi_Priva_m_61_ano = int.Parse(InstPubli_Pri_M_61_mas.Value); }
                        #endregion

                        #region ## VALOR DE LOS BENEFICIADOS INTERNOS
                        if (this.Internos_H_0_4.Value != "") { Internos_h_0_4 = int.Parse(Internos_H_0_4.Value); }
                        if (this.Internos_M_0_4.Value != "") { Internos_m_0_4 = int.Parse(Internos_M_0_4.Value); }
                        if (this.Internos_H_5_8.Value != "") { Internos_h_5_8 = int.Parse(Internos_H_5_8.Value); }
                        if (this.Internos_M_5_8.Value != "") { Internos_m_5_8 = int.Parse(Internos_M_5_8.Value); }
                        if (this.Internos_H_9_12.Value != "") { Internos_h_9_12 = int.Parse(Internos_H_9_12.Value); }
                        if (this.Internos_M_9_12.Value != "") { Internos_m_9_12 = int.Parse(Internos_M_9_12.Value); }
                        if (this.Internos_H_13_15.Value != "") { Internos_h_13_15 = int.Parse(Internos_H_13_15.Value); }
                        if (this.Internos_M_13_15.Value != "") { Internos_m_13_15 = int.Parse(Internos_M_13_15.Value); }
                        if (this.Internos_H_16_18.Value != "") { Internos_h_16_18 = int.Parse(Internos_H_16_18.Value); }
                        if (this.Internos_M_16_18.Value != "") { Internos_m_16_18 = int.Parse(Internos_M_16_18.Value); }
                        if (this.Internos_H_19_22.Value != "") { Internos_h_19_22 = int.Parse(Internos_H_19_22.Value); }
                        if (this.Internos_M_19_22.Value != "") { Internos_m_19_22 = int.Parse(Internos_M_19_22.Value); }
                        if (this.Internos_H_23_60.Value != "") { Internos_h_23_60 = int.Parse(Internos_H_23_60.Value); }
                        if (this.Internos_M_23_60.Value != "") { Internos_m_23_60 = int.Parse(Internos_M_23_60.Value); }
                        if (this.Internos_H_61_mas.Value != "") { Internos_h_61_ano = int.Parse(Internos_H_61_mas.Value); }
                        if (this.Internos_M_61_mas.Value != "") { Internos_m_61_ano = int.Parse(Internos_M_61_mas.Value); }
                        #endregion

                        #region ## VALOR DE LOS BENEFICIADOS FAMILIARES INTERNOS
                        if (this.FamInt_H_0_4.Value != "") { Familiar_h_0_4 = int.Parse(FamInt_H_0_4.Value); }
                        if (this.FamInt_M_0_4.Value != "") { Familiar_m_0_4 = int.Parse(FamInt_M_0_4.Value); }
                        if (this.FamInt_H_5_8.Value != "") { Familiar_h_5_8 = int.Parse(FamInt_H_5_8.Value); }
                        if (this.FamInt_M_5_8.Value != "") { Familiar_m_5_8 = int.Parse(FamInt_M_5_8.Value); }
                        if (this.FamInt_H_9_12.Value != "") { Familiar_h_9_12 = int.Parse(FamInt_H_9_12.Value); }
                        if (this.FamInt_M_9_12.Value != "") { Familiar_m_9_12 = int.Parse(FamInt_M_9_12.Value); }
                        if (this.FamInt_H_13_15.Value != "") { Familiar_h_13_15 = int.Parse(FamInt_H_13_15.Value); }
                        if (this.FamInt_M_13_15.Value != "") { Familiar_m_13_15 = int.Parse(FamInt_M_13_15.Value); }
                        if (this.FamInt_H_16_18.Value != "") { Familiar_h_16_18 = int.Parse(FamInt_H_16_18.Value); }
                        if (this.FamInt_M_16_18.Value != "") { Familiar_m_16_18 = int.Parse(FamInt_M_16_18.Value); }
                        if (this.FamInt_H_19_22.Value != "") { Familiar_h_19_22 = int.Parse(FamInt_H_19_22.Value); }
                        if (this.FamInt_M_19_22.Value != "") { Familiar_m_19_22 = int.Parse(FamInt_M_19_22.Value); }
                        if (this.FamInt_H_23_60.Value != "") { Familiar_h_23_60 = int.Parse(FamInt_H_23_60.Value); }
                        if (this.FamInt_M_23_60.Value != "") { Familiar_m_23_60 = int.Parse(FamInt_M_23_60.Value); }
                        if (this.FamInt_H_61_mas.Value != "") { Familiar_h_61_ano = int.Parse(FamInt_H_61_mas.Value); }
                        if (this.FamInt_M_61_mas.Value != "") { Familiar_m_61_ano = int.Parse(FamInt_M_61_mas.Value); }
                        #endregion

                        #region ## VALOR DE LOS BENEFICIADOS HIJOS INTERNAS 
                        if (this.txtHijos_H_0_4.Value != "") { Hijos_h_0_4 = int.Parse(txtHijos_H_0_4.Value); }
                        if (this.txtHijos_M_0_4.Value != "") { Hijos_m_0_4 = int.Parse(txtHijos_M_0_4.Value); }
                        if (this.txtHijos_H_5_8.Value != "") { Hijos_h_5_8 = int.Parse(txtHijos_H_5_8.Value); }
                        if (this.txtHijos_M_5_8.Value != "") { Hijos_m_5_8 = int.Parse(txtHijos_M_5_8.Value); }
                        if (this.txtHijos_H_9_12.Value != "") { Hijos_h_9_12 = int.Parse(txtHijos_H_9_12.Value); }
                        if (this.txtHijos_M_9_12.Value != "") { Hijos_m_9_12 = int.Parse(txtHijos_M_9_12.Value); }
                        if (this.txtHijos_H_13_15.Value != "") { Hijos_h_13_15 = int.Parse(txtHijos_H_13_15.Value); }
                        if (this.txtHijos_M_13_15.Value != "") { Hijos_m_13_15 = int.Parse(txtHijos_M_13_15.Value); }
                        if (this.txtHijos_H_16_18.Value != "") { Hijos_h_16_18 = int.Parse(txtHijos_H_16_18.Value); }
                        if (this.txtHijos_M_16_18.Value != "") { Hijos_m_16_18 = int.Parse(txtHijos_M_16_18.Value); }
                        if (this.txtHijos_H_19_22.Value != "") { Hijos_h_19_22 = int.Parse(txtHijos_H_19_22.Value); }
                        if (this.txtHijos_M_19_22.Value != "") { Hijos_m_19_22 = int.Parse(txtHijos_M_19_22.Value); }
                        if (this.txtHijos_H_23_60.Value != "") { Hijos_h_23_60 = int.Parse(txtHijos_H_23_60.Value); }
                        if (this.txtHijos_M_23_60.Value != "") { Hijos_m_23_60 = int.Parse(txtHijos_M_23_60.Value); }
                        if (this.txtHijos_H_61_mas.Value != "") { Hijos_h_61_ano = int.Parse(txtHijos_H_61_mas.Value); }
                        if (this.txtHijos_M_61_mas.Value != "") { Hijos_m_61_ano = int.Parse(txtHijos_M_61_mas.Value); }
                        #endregion

                        #region ## VALOR DE LOS BENEFICIADOS PRELIBERADOS 
                        if (this.txtPreli_H_0_4.Value != "") { Preliverado_h_0_4 = int.Parse(txtPreli_H_0_4.Value); }
                        if (this.txtPreli_M_0_4.Value != "") { Preliverado_m_0_4 = int.Parse(txtPreli_M_0_4.Value); }
                        if (this.txtPreli_H_5_8.Value != "") { Preliverado_h_5_8 = int.Parse(txtPreli_H_5_8.Value); }
                        if (this.txtPreli_M_5_8.Value != "") { Preliverado_m_5_8 = int.Parse(txtPreli_M_5_8.Value); }
                        if (this.txtPreli_H_9_12.Value != "") { Preliverado_h_9_12 = int.Parse(txtPreli_H_9_12.Value); }
                        if (this.txtPreli_M_9_12.Value != "") { Preliverado_m_9_12 = int.Parse(txtPreli_M_9_12.Value); }
                        if (this.txtPreli_H_13_15.Value != "") { Preliverado_h_13_15 = int.Parse(txtPreli_H_13_15.Value); }
                        if (this.txtPreli_M_13_15.Value != "") { Preliverado_m_13_15 = int.Parse(txtPreli_M_13_15.Value); }
                        if (this.txtPreli_H_16_18.Value != "") { Preliverado_h_16_18 = int.Parse(txtPreli_H_16_18.Value); }
                        if (this.txtPreli_M_16_18.Value != "") { Preliverado_m_16_18 = int.Parse(txtPreli_M_16_18.Value); }
                        if (this.txtPreli_H_19_22.Value != "") { Preliverado_h_19_22 = int.Parse(txtPreli_H_19_22.Value); }
                        if (this.txtPreli_M_19_22.Value != "") { Preliverado_m_19_22 = int.Parse(txtPreli_M_19_22.Value); }
                        if (this.txtPreli_H_23_60.Value != "") { Preliverado_h_23_60 = int.Parse(txtPreli_H_23_60.Value); }
                        if (this.txtPreli_M_23_60.Value != "") { Preliverado_m_23_60 = int.Parse(txtPreli_M_23_60.Value); }
                        if (this.txtPreli_H_61_mas.Value != "") { Preliverado_h_61_ano = int.Parse(txtPreli_H_61_mas.Value); }
                        if (this.txtPreli_M_61_mas.Value != "") { Preliverado_m_61_ano = int.Parse(txtPreli_M_61_mas.Value); }
                        #endregion

                        int Hombre_0_4 = Alum_h_0_4 + Padres_doce_h_0_4 + Insti_Publi_Priva_h_0_4 + Internos_h_0_4 + Familiar_h_0_4 + Hijos_h_0_4 + Preliverado_h_0_4;
                        int Hombre_5_8 = Alum_h_5_8 + Padres_doce_h_5_8 + Insti_Publi_Priva_h_5_8 + Internos_h_5_8 + Familiar_h_5_8 + Hijos_h_5_8 + Preliverado_h_5_8;
                        int Hombre_9_12 = Alum_h_9_12 + Padres_doce_h_9_12 + Insti_Publi_Priva_h_9_12 + Internos_h_9_12 + Familiar_h_9_12 + Hijos_h_9_12 + Preliverado_h_9_12;
                        int Hombre_13_15 = Alum_h_13_15 + Padres_doce_h_13_15 + Insti_Publi_Priva_h_13_15 + Internos_h_13_15 + Familiar_h_13_15 + Hijos_h_13_15 + Preliverado_h_13_15;
                        int Hombre_16_18 = Alum_h_16_18 + Padres_doce_h_16_18 + Insti_Publi_Priva_h_16_18 + Internos_h_16_18 + Familiar_h_16_18 + Hijos_h_16_18 + Preliverado_h_16_18;
                        int Hombre_19_22 = Alum_h_19_22 + Padres_doce_h_19_22 + Insti_Publi_Priva_h_19_22 + Internos_h_19_22 + Familiar_h_19_22 + Hijos_h_19_22 + Preliverado_h_19_22;
                        int Hombre_23_60 = Alum_h_23_60 + Padres_doce_h_23_60 + Insti_Publi_Priva_h_23_60 + Internos_h_23_60 + Familiar_h_23_60 + Hijos_h_23_60 + Preliverado_h_23_60;
                        int Hombre_60_mas = Alum_h_61_ano + Padres_doce_h_61_ano + Insti_Publi_Priva_h_61_ano + Internos_h_61_ano + Familiar_h_61_ano + Hijos_h_61_ano + Preliverado_h_61_ano;


                        int Mujeres_0_4 = Alum_m_0_4 + Padres_doce_m_0_4 + Insti_Publi_Priva_m_0_4 + Internos_m_0_4 + Familiar_m_0_4 + Hijos_m_0_4 + Preliverado_m_0_4;
                        int Mujeres_5_8 = Alum_m_5_8 + Padres_doce_m_5_8 + Insti_Publi_Priva_m_5_8 + Internos_m_5_8 + Familiar_m_5_8 + Hijos_m_5_8 + Preliverado_m_5_8;
                        int Mujeres_9_12 = Alum_m_9_12 + Padres_doce_m_9_12 + Insti_Publi_Priva_m_9_12 + Internos_m_9_12 + Familiar_m_9_12 + Hijos_m_9_12 + Preliverado_m_9_12;
                        int Mujeres_13_15 = Alum_m_13_15 + Padres_doce_m_13_15 + Insti_Publi_Priva_m_13_15 + Internos_m_13_15 + Familiar_m_13_15 + Hijos_m_13_15 + Preliverado_m_13_15;
                        int Mujeres_16_18 = Alum_m_16_18 + Padres_doce_m_16_18 + Insti_Publi_Priva_m_16_18 + Internos_m_16_18 + Familiar_m_16_18 + Hijos_m_16_18 + Preliverado_m_16_18;
                        int Mujeres_19_22 = Alum_m_19_22 + Padres_doce_m_19_22 + Insti_Publi_Priva_m_19_22 + Internos_m_19_22 + Familiar_m_19_22 + Hijos_m_19_22 + Preliverado_m_19_22;
                        int Mujeres_23_60 = Alum_m_23_60 + Padres_doce_m_23_60 + Insti_Publi_Priva_m_23_60 + Internos_m_23_60 + Familiar_m_23_60 + Hijos_m_23_60 + Preliverado_m_23_60;
                        int Mujeres_60_mas = Alum_m_61_ano + Padres_doce_m_61_ano + Insti_Publi_Priva_m_61_ano + Internos_m_61_ano + Familiar_m_61_ano + Hijos_m_61_ano + Preliverado_m_61_ano;

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
                            Entrecalle1 = this.entrecalle1.Value == string.Empty ? "" : this.entrecalle1.Value,
                            Entrecalle2 = this.entrecalle2.Value == string.Empty ? "" : this.entrecalle2.Value,
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
                this.Response.Redirect("~/VistasReportes/DGPRS/Vista_de_datos_DGPRS.aspx");
                this.HDFactividad.Value = (string)null;
                this.btnGuardarEdicion.Visible = false;
                this.btnSalir.Visible = false;
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

            protected void btnGuardarEdicion_Click(object sender, EventArgs e)
            {

            }
        }
    }