using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Graficas
{
    public partial class Cargas_de_trabajo : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        int añoBus = Convert.ToInt32(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                totalMunicipios();
                BeneficiadosPordelegciones();
                ano.InnerText = Convert.ToString(DateTime.Now.Year);
                stronAnoBeni.InnerText = Convert.ToString(DateTime.Now.Year);
            }
        }

        #region ### FUNCIONES Y METODOS DE ACCIONES POR DELEGACION
        #region ### METODO PARA LLENAR LOS GRID DE ACCIONES
        public void totalMunicipios()

        {
            var tipos = new Int32[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            var data = (from a in ctx.tbCarga_trabajo_Dele
                        join b in ctx.tb_programa on a.programa equals b.programasID
                        where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 1 && a.Delegacion == "CONURBACION XALAPA XX" && a.Año == añoBus
                        group new { a, b } by a.programa into g
                        select new
                        {

                            CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                            progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                            dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                            Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                            //ENERO = a.Where(T => T.Mes_Num == 1).Sum(r => r.cifra),
                            FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                            MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                            ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                            MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                            JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                            JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                            AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                            SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                            OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                            NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                            DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                        }).ToList();

            gvAcciones.DataSource = data;
            gvAcciones.DataBind();



            var AccionesPoza = (from a in ctx.tbCarga_trabajo_Dele
                                join b in ctx.tb_programa on a.programa equals b.programasID
                                where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 1 && a.Delegacion == "CONURBACION POZA RICA" && a.Año == añoBus
                                group new { a, b } by a.programa into g
                                select new
                                {
                                    CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                    progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                    dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                    Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                    FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                    MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                    ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                    MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                    JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                    JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                    AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                    SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                    OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                    NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                    DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                }).ToList();

            gvAccionePoza.DataSource = AccionesPoza;
            gvAccionePoza.DataBind();


            var AccionesVERACRUZ = (from a in ctx.tbCarga_trabajo_Dele
                                    join b in ctx.tb_programa on a.programa equals b.programasID
                                    where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 1 && a.Delegacion == "CONURBACION VERACRUZ XXIII" && a.Año == añoBus
                                    group new { a, b } by a.programa into g
                                    select new
                                    {
                                        CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                        progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                        dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                        Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                        FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                        MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                        ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                        MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                        JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                        JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                        AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                        SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                        OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                        NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                        DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                    }).ToList();

            gvAccionesVera.DataSource = AccionesVERACRUZ;
            gvAccionesVera.DataBind();



            var AccionesCoatza = (from a in ctx.tbCarga_trabajo_Dele
                                  join b in ctx.tb_programa on a.programa equals b.programasID
                                  where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 1 && a.Delegacion == "COORDINACION COATZACOALCOS" && a.Año == añoBus
                                  group new { a, b } by a.programa into g
                                  select new
                                  {
                                      CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                      progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                      dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                      Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                      FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                      MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                      ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                      MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                      JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                      JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                      AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                      SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                      OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                      NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                      DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                  }).ToList();

            gvAccionesCoatza.DataSource = AccionesCoatza;
            gvAccionesCoatza.DataBind();


            var AccionesCordoba = (from a in ctx.tbCarga_trabajo_Dele
                                   join b in ctx.tb_programa on a.programa equals b.programasID
                                   where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 1 && a.Delegacion == "COORDINACION CORDOBA" && a.Año == añoBus
                                   group new { a, b } by a.programa into g
                                   select new
                                   {
                                       CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                       progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                       dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                       Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                       FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                       MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                       ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                       MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                       JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                       JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                       AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                       SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                       OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                       NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                       DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                   }).ToList();

            gvAccionesCordoba.DataSource = AccionesCordoba;
            gvAccionesCordoba.DataBind();



            var AccionesEnlace = (from a in ctx.tbCarga_trabajo_Dele
                                  join b in ctx.tb_programa on a.programa equals b.programasID
                                  where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 1 && a.Delegacion == "Enlace" && a.Año == añoBus
                                  group new { a, b } by a.programa into g
                                  select new
                                  {
                                      CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                      progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                      dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                      Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                      FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                      MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                      ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                      MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                      JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                      JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                      AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                      SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                      OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                      NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                      DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                  }).ToList();

            gvAccionesEnlaces.DataSource = AccionesEnlace;
            gvAccionesEnlaces.DataBind();

        }
        #endregion

        #region METODOS DE LOS DROP PARA LA SELECCION DE LOS DATABOUND
        protected void ddlDelegación_DataBound(object sender, EventArgs e)
        {
            this.ddlDelegación.Items.Insert(0, new ListItem("--Seleccione una delegación--", "0"));
        }

        protected void ddlprograma_DataBound(object sender, EventArgs e)
        {
            this.ddlprograma.Items.Insert(0, new ListItem("--Seleccione un programa--", "0"));

        }
        #endregion

        #region Boton para guardar las Acciones 
        protected void btnGuardarCargaAcciones_Click(object sender, EventArgs e)
        {
            bool valido = true;
            string textoValidacion = "<ul>";
            int progra = Convert.ToInt32(ddlprograma.SelectedValue);
            string dele = Convert.ToString(ddlDelegación.SelectedItem).ToString();
            int anño = Convert.ToInt32(DateTime.Now.Year);
            tbCarga_trabajo_Dele checarProgra = ctx.tbCarga_trabajo_Dele.Where(x => x.programa == progra && x.Año == anño && x.Delegacion == dele).FirstOrDefault();
            if (checarProgra != null)
            {
                textoValidacion += "No se puede cargar las acciones del programa por que ya esta registrado";
                ScriptManager.RegisterStartupScript(this, GetType(), "CamposObligatorios", "CamposObligatorios('" + textoValidacion + "');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "openModalAccion", "openModalAccion();", true);
            }
            else
            {

                if (ddlprograma.SelectedIndex == 0 || string.IsNullOrEmpty(ddlprograma.SelectedValue))
                {
                    textoValidacion += "<li>Es obligatorio el programa</li>";
                    ddlprograma.Focus();
                    ddlprograma.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (ddlDelegación.SelectedIndex == 0 || string.IsNullOrEmpty(ddlDelegación.SelectedValue))
                {
                    textoValidacion += "<li>Es obligatorio la delegación</li>";
                    ddlDelegación.Focus();
                    ddlDelegación.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }


                if (string.IsNullOrEmpty(txtenero.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Enero</li>";
                    txtenero.Focus();
                    txtenero.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtFebrero.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Febrero</li>";
                    txtFebrero.Focus();
                    txtFebrero.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtMarzo.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Marzo</li>";
                    txtMarzo.Focus();
                    txtMarzo.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }

                if (string.IsNullOrEmpty(txtAbril.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Abril</li>";
                    txtAbril.Focus();
                    txtAbril.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtMayo.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Mayo</li>";
                    txtMayo.Focus();
                    txtMayo.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtJunio.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Junio</li>";
                    txtJunio.Focus();
                    txtJunio.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtJulio.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Julio</li>";
                    txtJulio.Focus();
                    txtJulio.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtAgosto.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Agosto</li>";
                    txtAgosto.Focus();
                    txtAgosto.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtSeptiembre.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Septiembre</li>";
                    txtSeptiembre.Focus();
                    txtSeptiembre.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtOctubre.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Octubre</li>";
                    txtOctubre.Focus();
                    txtOctubre.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtNoviembre.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Nomviembre</li>";
                    txtNoviembre.Focus();
                    txtNoviembre.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtDiciembre.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Diciembre</li>";
                    txtDiciembre.Focus();
                    txtDiciembre.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (!valido)
                {
                    textoValidacion += "</ul>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "CamposObligatorios", "CamposObligatorios('" + textoValidacion + "');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "openModalAccion", "openModalAccion();", true);

                }
                else
                {
                    try
                    {
                        tbCarga_trabajo_Dele nuevo = new tbCarga_trabajo_Dele();
                        int progrid = Convert.ToInt32(ddlprograma.SelectedValue);
                        int mesid = DateTime.Now.Month;
                        int tipo = 1;
                        string dela = ddlDelegación.Text;
                        int años = DateTime.Now.Year;

                        var cifras = new List<int> { Convert.ToInt32(txtenero.Text), Convert.ToInt32(txtFebrero.Text), Convert.ToInt32(txtMarzo.Text), Convert.ToInt32(txtAbril.Text), Convert.ToInt32(txtMayo.Text), Convert.ToInt32(txtJunio.Text), Convert.ToInt32(txtJulio.Text), Convert.ToInt32(txtAgosto.Text), Convert.ToInt32(txtSeptiembre.Text), Convert.ToInt32(txtOctubre.Text), Convert.ToInt32(txtNoviembre.Text), Convert.ToInt32(txtDiciembre.Text) };
                        var numeromes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                        var numbersAndWords = cifras.Zip(numeromes, (n, w) => new { cifras = n, numeromes = w });
                        foreach (var item in numbersAndWords)
                        {
                            nuevo.cifra = item.cifras;
                            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                            string nombreMes = formatoFecha.GetMonthName(item.numeromes).ToUpper();
                            nuevo.Mes_letra = nombreMes;
                            nuevo.Mes_Num = item.numeromes;
                            nuevo.programa = progrid;
                            nuevo.Tipo_TA_BA_TB = tipo;
                            nuevo.Delegacion = dela;
                            nuevo.Año = años;

                            ctx.tbCarga_trabajo_Dele.Add(nuevo);
                            ctx.SaveChanges();

                        }
                        gvAcciones.DataBind();
                        gvAccionePoza.DataBind();
                        gvAccionesVera.DataBind();
                        gvAccionesCordoba.DataBind();
                        gvAccionesCoatza.DataBind();
                        gvAccionesEnlaces.DataBind();
                        ScriptManager.RegisterStartupScript(this, GetType(), "GuardadoConExito", "GuardadoConExito();", true);
                        txtenero.Text = "";
                        txtFebrero.Text = "";
                        txtMarzo.Text = "";
                        txtAbril.Text = "";
                        txtMayo.Text = "";
                        txtJunio.Text = "";
                        txtJulio.Text = "";
                        txtAgosto.Text = "";
                        txtSeptiembre.Text = "";
                        txtOctubre.Text = "";
                        txtNoviembre.Text = "";
                        txtDiciembre.Text = "";
                        RedirectHelper.Redirect(this.Response, "~/Graficas/Cargas_de_trabajo.aspx");

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "error();", true);

                    }

                }
            }


        }
        #endregion
        #endregion


        #region FUNCIONES Y METODOS PARA LOS BENEFICIADOS POR DELEGACIÓN
        #region ### METODO PARA LLENAR LOS GRID DE ACCIONES
        public void BeneficiadosPordelegciones()

        {
            var tipos = new Int32[] { 7, 8, 9, 10, 11, 12, 13, 14 };
            var BeneficiadosXalapa = (from a in ctx.tbCarga_trabajo_Dele
                                      join b in ctx.tb_programa on a.programa equals b.programasID
                                      where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 3 && a.Delegacion == "CONURBACION XALAPA XX" && a.Año == añoBus
                                      group new { a, b } by a.programa into g
                                      select new
                                      {

                                          CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                          progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                          dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                          Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                          //ENERO = a.Where(T => T.Mes_Num == 1).Sum(r => r.cifra),
                                          FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                          MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                          ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                          MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                          JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                          JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                          AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                          SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                          OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                          NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                          DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                      }).ToList();

            gvBenificiadosXalapa.DataSource = BeneficiadosXalapa;
            gvBenificiadosXalapa.DataBind();



            var BeneficiadosPoza = (from a in ctx.tbCarga_trabajo_Dele
                                    join b in ctx.tb_programa on a.programa equals b.programasID
                                    where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 3 && a.Delegacion == "CONURBACION POZA RICA" && a.Año == añoBus
                                    group new { a, b } by a.programa into g
                                    select new
                                    {
                                        CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                        progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                        dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                        Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                        FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                        MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                        ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                        MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                        JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                        JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                        AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                        SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                        OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                        NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                        DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                    }).ToList();

            gvBenificiadosPoza.DataSource = BeneficiadosPoza;
            gvBenificiadosPoza.DataBind();


            var BeneficiadosVERACRUZ = (from a in ctx.tbCarga_trabajo_Dele
                                        join b in ctx.tb_programa on a.programa equals b.programasID
                                        where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 3 && a.Delegacion == "CONURBACION VERACRUZ XXIII" && a.Año == añoBus
                                        group new { a, b } by a.programa into g
                                        select new
                                        {
                                            CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                            progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                            dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                            Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                            FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                            MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                            ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                            MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                            JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                            JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                            AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                            SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                            OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                            NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                            DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                        }).ToList();

            gvBeneficiadosVeracruz.DataSource = BeneficiadosVERACRUZ;
            gvBeneficiadosVeracruz.DataBind();



            var BeneficiadosCoatza = (from a in ctx.tbCarga_trabajo_Dele
                                      join b in ctx.tb_programa on a.programa equals b.programasID
                                      where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 3 && a.Delegacion == "COORDINACION COATZACOALCOS" && a.Año == añoBus
                                      group new { a, b } by a.programa into g
                                      select new
                                      {
                                          CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                          progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                          dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                          Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                          FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                          MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                          ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                          MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                          JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                          JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                          AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                          SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                          OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                          NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                          DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                      }).ToList();

            gvBeneficiadosCoatza.DataSource = BeneficiadosCoatza;
            gvBeneficiadosCoatza.DataBind();


            var BeneficiadosCordoba = (from a in ctx.tbCarga_trabajo_Dele
                                       join b in ctx.tb_programa on a.programa equals b.programasID
                                       where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 3 && a.Delegacion == "COORDINACION CORDOBA" && a.Año == añoBus
                                       group new { a, b } by a.programa into g
                                       select new
                                       {
                                           CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                           progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                           dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                           Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                           FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                           MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                           ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                           MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                           JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                           JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                           AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                           SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                           OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                           NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                           DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                       }).ToList();

            gvBeneficiadosCordoba.DataSource = BeneficiadosCordoba;
            gvBeneficiadosCordoba.DataBind();



            var BeneficiadosEnlace = (from a in ctx.tbCarga_trabajo_Dele
                                      join b in ctx.tb_programa on a.programa equals b.programasID
                                      where tipos.Any(y => y == a.programa) && a.Tipo_TA_BA_TB == 3 && a.Delegacion == "Enlace" && a.Año == añoBus
                                      group new { a, b } by a.programa into g
                                      select new
                                      {
                                          CargaTrabjaoId = g.Select(t => t.a.CargaTrabjaoId).FirstOrDefault(),
                                          progra = g.Select(t => t.b.NombrePrograma).FirstOrDefault(),
                                          dela = g.Select(t => t.a.Delegacion).FirstOrDefault(),
                                          Enero = g.Where(T => T.a.Mes_Num == 1).Sum(r => r.a.cifra),
                                          FEBRERO = g.Where(T => T.a.Mes_Num == 2).Sum(r => r.a.cifra),
                                          MARZO = g.Where(T => T.a.Mes_Num == 3).Sum(r => r.a.cifra),
                                          ABRIL = g.Where(T => T.a.Mes_Num == 4).Sum(r => r.a.cifra),
                                          MAYO = g.Where(T => T.a.Mes_Num == 5).Sum(r => r.a.cifra),
                                          JUNIO = g.Where(T => T.a.Mes_Num == 6).Sum(r => r.a.cifra),
                                          JULIO = g.Where(T => T.a.Mes_Num == 7).Sum(r => r.a.cifra),
                                          AGOSTO = g.Where(T => T.a.Mes_Num == 8).Sum(r => r.a.cifra),
                                          SEPTIEMBRE = g.Where(T => T.a.Mes_Num == 9).Sum(r => r.a.cifra),
                                          OCTUBRE = g.Where(T => T.a.Mes_Num == 10).Sum(r => r.a.cifra),
                                          NOVIEMBRE = g.Where(T => T.a.Mes_Num == 11).Sum(r => r.a.cifra),
                                          DICIEMBRE = g.Where(T => T.a.Mes_Num == 12).Sum(r => r.a.cifra),


                                      }).ToList();

            gvBeneficiadosEnlace.DataSource = BeneficiadosEnlace;
            gvBeneficiadosEnlace.DataBind();



        }
        #endregion

        #region METODOS DE LOS DROP PARA LA SELECCION DE LOS DATABOUND
        protected void ddlProgramaBeni_DataBound(object sender, EventArgs e)
        {
            this.ddlProgramaBeni.Items.Insert(0, new ListItem("--Seleccione un programa--", "0"));
        }

        protected void ddlDelegbeni_DataBound(object sender, EventArgs e)
        {
            this.ddlDelegbeni.Items.Insert(0, new ListItem("--Seleccione una delegación--", "0"));
        }

        #endregion

        #region Boton para guardar los beneficiados 
        protected void lnkBtnGuardarBeni_Click(object sender, EventArgs e)
        {
            bool valido = true;
            string textoValidacion = "<ul>";
            int progra = Convert.ToInt32(ddlprograma.SelectedValue);
            int anño = Convert.ToInt32(DateTime.Now.Year);
            tbCarga_trabajo_Dele checarProgra = ctx.tbCarga_trabajo_Dele.Where(x => x.programa == progra && x.Año == anño).FirstOrDefault();
            if (checarProgra != null)
            {
                textoValidacion += "No se puede cargar los beneficiados del programa por que ya esta registrado";
                ScriptManager.RegisterStartupScript(this, GetType(), "CamposObligatorios", "CamposObligatorios('" + textoValidacion + "');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "openModalAccion", "openModalAccion();", true);
            }
            else
            {

                if (ddlProgramaBeni.SelectedIndex == 0 || string.IsNullOrEmpty(ddlProgramaBeni.SelectedValue))
                {
                    textoValidacion += "<li>Es obligatorio el programa</li>";
                    ddlProgramaBeni.Focus();
                    ddlProgramaBeni.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (ddlDelegbeni.SelectedIndex == 0 || string.IsNullOrEmpty(ddlDelegbeni.SelectedValue))
                {
                    textoValidacion += "<li>Es obligatorio la delegación</li>";
                    ddlDelegbeni.Focus();
                    ddlDelegbeni.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }


                if (string.IsNullOrEmpty(txtEneroB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Enero</li>";
                    txtEneroB.Focus();
                    txtEneroB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtFebreroB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Febrero</li>";
                    txtFebreroB.Focus();
                    txtFebreroB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtMarzoB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Marzo</li>";
                    txtMarzoB.Focus();
                    txtMarzoB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }

                if (string.IsNullOrEmpty(txtAbrilB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Abril</li>";
                    txtAbrilB.Focus();
                    txtAbrilB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtMayoB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Mayo</li>";
                    txtMayoB.Focus();
                    txtMayoB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtJunioB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Junio</li>";
                    txtJunioB.Focus();
                    txtJunioB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtJulioB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Julio</li>";
                    txtJulioB.Focus();
                    txtJulioB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtAgostoB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Agosto</li>";
                    txtAgostoB.Focus();
                    txtAgostoB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtSeptiembreB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Septiembre</li>";
                    txtSeptiembreB.Focus();
                    txtSeptiembreB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtOctubreB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Octubre</li>";
                    txtOctubreB.Focus();
                    txtOctubreB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtNoviembreB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Nomviembre</li>";
                    txtNoviembreB.Focus();
                    txtNoviembreB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (string.IsNullOrEmpty(txtDiciembreB.Text))
                {
                    textoValidacion += "<li>Es obligatorio ingresar el mes Diciembre</li>";
                    txtDiciembreB.Focus();
                    txtDiciembreB.BorderColor = System.Drawing.Color.Red;
                    valido = false;
                }
                if (!valido)
                {
                    textoValidacion += "</ul>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "CamposObligatorios", "CamposObligatorios('" + textoValidacion + "');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "openModalBeneficiados", "openModalBeneficiados();", true);

                }
                else
                {
                    try
                    {
                        tbCarga_trabajo_Dele nuevo = new tbCarga_trabajo_Dele();
                        int progrid = Convert.ToInt32(ddlprograma.SelectedValue);
                        int mesid = DateTime.Now.Month;
                        int tipo = 3;
                        string dela = ddlDelegación.Text;
                        int años = DateTime.Now.Year;

                        var cifras = new List<int> { Convert.ToInt32(txtEneroB.Text), Convert.ToInt32(txtFebreroB.Text), Convert.ToInt32(txtMarzoB.Text), Convert.ToInt32(txtAbrilB.Text), Convert.ToInt32(txtMayoB.Text), Convert.ToInt32(txtJunioB.Text), Convert.ToInt32(txtJulioB.Text), Convert.ToInt32(txtAgostoB.Text), Convert.ToInt32(txtSeptiembreB.Text), Convert.ToInt32(txtOctubreB.Text), Convert.ToInt32(txtNoviembreB.Text), Convert.ToInt32(txtDiciembreB.Text) };
                        var numeromes = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                        var numbersAndWords = cifras.Zip(numeromes, (n, w) => new { cifras = n, numeromes = w });
                        foreach (var item in numbersAndWords)
                        {
                            nuevo.cifra = item.cifras;
                            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                            string nombreMes = formatoFecha.GetMonthName(item.numeromes).ToUpper();
                            nuevo.Mes_letra = nombreMes;
                            nuevo.Mes_Num = item.numeromes;
                            nuevo.programa = progrid;
                            nuevo.Tipo_TA_BA_TB = tipo;
                            nuevo.Delegacion = dela;
                            nuevo.Año = años;

                            ctx.tbCarga_trabajo_Dele.Add(nuevo);
                            ctx.SaveChanges();
                            gvBenificiadosXalapa.DataBind();
                            gvBenificiadosPoza.DataBind();
                            gvBeneficiadosVeracruz.DataBind();
                            gvBeneficiadosCordoba.DataBind();
                            gvBeneficiadosCoatza.DataBind();
                            gvBeneficiadosEnlace.DataBind();
                        }

                        ScriptManager.RegisterStartupScript(this, GetType(), "GuardadoConExito", "GuardadoConExito();", true);

                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error", "error();", true);

                    }
                }
            }
        }
        #endregion
        #endregion

    }
}