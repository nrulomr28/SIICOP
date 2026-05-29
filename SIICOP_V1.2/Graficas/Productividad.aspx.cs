using Microsoft.Reporting.WebForms;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Graficas
{

    public partial class Productividad : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();

        int Datos;
        int progragr;
        int inclusion = 0;
        int redesOld = 0;
        int redesOldNew = 0;
        int escolarOld = 0;
        int escolarNew = 0;
        int mujerOld = 0;
        int mujerNew = 0;
        int empreOld = 0;
        int empreNew = 0;
        int deporteNew = 0;
        int forosferiaOld = 0;
        int forosferiaNew = 0;
        int redspaz = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack || this.User.IsInRole("SysAdmin") || (this.User.IsInRole("Administrador") || this.User.IsInRole("Visualizador") || this.User.IsInRole("Operador")))
            {
                //ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "initMap", "initMap();", true);

            }
            else
            {
                this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
            }
        }

        protected void btnbuscar2_Click(object sender, EventArgs e)
        {
            this.busqueda();
        }

        protected void gvDATOS_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = gvDATOS.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabel");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= gvDATOS.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == gvDATOS.PageIndex)
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
                    int currentPage = gvDATOS.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + gvDATOS.PageCount.ToString();

                }


            }
            catch
            {
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                GridViewRow pagerRow = gvDATOS.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                gvDATOS.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...
                //lblInfo.Text = "";
            }
        }


        protected void busqueda()
        {
            bool valido = true;
            string textoValidacion = "<ul>";

            if (string.IsNullOrEmpty(this.txtFechaini.Text) || string.IsNullOrEmpty(this.txtDateFin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder generar el reporte. </ li>";
                valido = false;
            }
            if (!this.ChkEmpresarial.Checked && !this.ChkEscuela.Checked &&
                !this.ChkCiudadano.Checked && !this.ChkMujer.Checked &&
                !this.ChkForesFerias.Checked && !this.ChkInCiudadano.Checked &&
                !this.Chkinclusion.Checked &&
                !this.Chkredspaz.Checked)
            {
                textoValidacion += "<li> Es necesario seleccionar un programa para poder generar el reporte. </ li>";

                valido = false;
            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }
            else
            {

                DateTime result = new DateTime();
                if (DateTime.TryParse(this.txtFechaini.Text, out result))
                    this.Session["fInicialC"] = (object)result.ToShortDateString();
                else
                    this.Session["fInicialC"] = (object)null;
                if (DateTime.TryParse(this.txtDateFin.Text, out result))
                    this.Session["fFinalC"] = (object)result.ToShortDateString();
                else
                    this.Session["fFinalC"] = (object)null;
                DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
                DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);


                inclusion = 0;
                redesOld = 0;
                redesOldNew = 0;
                escolarOld = 0;
                escolarNew = 0;
                mujerOld = 0;
                mujerNew = 0;
                empreOld = 0;
                empreNew = 0;
                deporteNew = 0;
                forosferiaOld = 0;
                forosferiaNew = 0;
                redspaz = 0;


                if (this.Chkinclusion.Checked)
                {
                    inclusion = Convert.ToInt32("7");
                }


                if (this.ChkCiudadano.Checked)
                {
                    redesOld = Convert.ToInt32("2");
                    redesOldNew = Convert.ToInt32("8");
                }

                if (this.ChkEscuela.Checked)
                {
                    escolarOld = Convert.ToInt32("3");
                    escolarNew = Convert.ToInt32("9");
                }

                if (this.ChkMujer.Checked)
                {
                    mujerOld = Convert.ToInt32("4");
                    mujerNew = Convert.ToInt32("10");
                }

                if (this.ChkEmpresarial.Checked)
                {
                    empreOld = Convert.ToInt32("1");
                    empreNew = Convert.ToInt32("13");
                }

                if (this.ChkInCiudadano.Checked)
                {
                    deporteNew = Convert.ToInt32("12");
                }

                if (this.ChkForesFerias.Checked)
                {
                    forosferiaOld = Convert.ToInt32("5");
                    forosferiaNew = Convert.ToInt32("11");
                }


                if (this.Chkredspaz.Checked)
                {
                    redspaz = Convert.ToInt32("14");
                }

                //ctx.Wv_DatosReportesHistorico.Where(x => x.fecha >= (DateTime?)fechainicial && x.fecha <= (DateTime?)fechaFinal && x.programasID == programa).ToList();
                this.HDfinclusion.Value = Convert.ToString(inclusion);
                this.HDfredesOld.Value = Convert.ToString(redesOld);
                this.HDfredesOldNew.Value = Convert.ToString(redesOldNew);
                this.HDfescolarOld.Value = Convert.ToString(escolarOld);
                this.HDfescolarNew.Value = Convert.ToString(escolarNew);
                this.HDfmujerOld.Value = Convert.ToString(mujerOld);
                this.HDfmujerNew.Value = Convert.ToString(mujerNew);
                this.HDfempreOld.Value = Convert.ToString(empreOld);
                this.HDfempreNew.Value = Convert.ToString(empreNew);
                this.HDfdeporteNew.Value = Convert.ToString(deporteNew);
                this.HDfforosferiaOld.Value = Convert.ToString(forosferiaOld);
                this.HDfforosferiaNew.Value = Convert.ToString(forosferiaNew);
                this.HDfredspaz.Value = Convert.ToString(redspaz);

                List<int> programa = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });

                var consulta = ctx.Wv_DatosReportesHistorico.Where(x => x.fecha >= (DateTime?)fechainicial
                && x.fecha <= (DateTime?)fechaFinal && programa.Any(y => y == x.programasID)).ToList();

                gvDATOS.DataSource = consulta;
                gvDATOS.DataBind();

                //Session["pro"] = consulta.ToList();


                //this.Session["pro"] = programa.ToList();
                //this.Session["Datos"] = (object)programa;
                //this.HDfProgramaIdd.Value = Convert.ToString(programa);

                this.totalAtendidos();
                this.totalAcciones();
                this.totalporZonas();
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaHombresXacciones", "ConsultaHombresXacciones();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMuniNorte", "ConsultaMuniNorte();", true);

                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionescentroTtotal", "AccionescentroTtotal();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunicentro", "ConsultaMunicentro();", true);


                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionesSurTtotal", "AccionesSurTtotal();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunisur", "ConsultaMunisur();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "mapapunteo", "mapapunteo();", true);


                this.atendidos.Visible = true;
                this.Griddatos.Visible = true;
                this.Graficas.Visible = true;



            }


        }

        #region #### TOTAL ATENDIDOS
        public void totalAtendidos()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);


            List<int> progragr = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });

            // var BeniZonaNorte  = Convert.ToInt32(ctx.Wv_DatosReportesHistorico.Where(p => p.fecha >= fechainicial && p.fecha <= fechaFinal & progragr.Any(y => y == p.programasID)).Sum(x => x.total_atendidos.Value).ToString());
            //this.TotalGeneralAten.InnerText = BeniZonaNorte;
            this.TotalGeneralAten.InnerText = (from x in ctx.Wv_DatosReportesHistorico
                                               where x.fecha >= fechainicial && x.fecha <= fechaFinal && progragr.Any(ax => ax == (x.programasID))
                                               select x.total_atendidos).Sum().ToString();

            this.PersonasZonaNorte.InnerText = (from c in ctx.Wv_DatosReportesHistorico
                                                join d in ctx.tb_DireccionReporte
                                                on c.idResumenDiario equals d.idResumenDiario
                                                where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == 1 && progragr.Any(x => x == (c.programasID))
                                                select c.total_atendidos).Sum().ToString();

            this.PersonasAtendidasZonaCentro.InnerText = (from m in ctx.tb_Reporte_Diario
                                                          join n in ctx.tb_DireccionReporte
                                                          on m.idResumenDiario equals n.idResumenDiario
                                                          where m.fecha >= fechainicial && m.fecha <= fechaFinal && n.RegionID == 2 && progragr.Any(x => x == (m.programasID))
                                                          select m.total_atendidos).Sum().ToString();

            this.personasAtendidasZonaSur.InnerText = (from ma in ctx.tb_Reporte_Diario
                                                       join nr in ctx.tb_DireccionReporte
                                                       on ma.idResumenDiario equals nr.idResumenDiario
                                                       where ma.fecha >= fechainicial && ma.fecha <= fechaFinal && nr.RegionID == 3 && progragr.Any(x => x == (ma.programasID))
                                                       select ma.total_atendidos).Sum().ToString();
        }
        #endregion

        #region #### TOTAL ACCIONES
        public void totalAcciones()
        {
            //this.progragr = int.Parse(this.Session["Datos"].ToString());
            List<int> progragr = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });


            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.TotalAcx.InnerText = ctx.tb_Reporte_Diario.Where(u => u.fecha >= fechainicial && u.fecha <= fechaFinal && progragr.Any(x => x == (u.programasID))).Select(u => u.AccionesID).Count().ToString();

            this.AccionesZonaNorte.InnerText = (from a in ctx.tb_Reporte_Diario
                                                join b in ctx.tb_DireccionReporte
                                                on a.idResumenDiario equals b.idResumenDiario
                                                where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == 1 && progragr.Any(x => x == (a.programasID))
                                                select a.AccionesID).Count().ToString();


            this.accionesRealizadasZonaCentro.InnerText = (from k in ctx.tb_Reporte_Diario
                                                           join l in ctx.tb_DireccionReporte
                                                           on k.idResumenDiario equals l.idResumenDiario
                                                           where k.fecha >= fechainicial && k.fecha <= fechaFinal && l.RegionID == 2 && progragr.Any(x => x == (k.programasID))
                                                           select k.AccionesID).Count().ToString();

            this.AccionesRealizadasSur.InnerText = (from w in ctx.tb_Reporte_Diario
                                                    join x in ctx.tb_DireccionReporte
                                                    on w.idResumenDiario equals x.idResumenDiario
                                                    where w.fecha >= fechainicial && w.fecha <= fechaFinal && x.RegionID == 3 && progragr.Any(x => x == (w.programasID))
                                                    select w.AccionesID).Count().ToString();
        }
        #endregion

        #region #### TOTAL POR ZONA
        public void totalporZonas()
        {

            //Municipios atendidos por zonas y general 
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            //this.progragr = int.Parse(this.Session["Datos"].ToString());

            List<int> progragr = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });



            this.MuniTtoatl.InnerText = (from sp in ctx.tb_Reporte_Diario
                                         join stdr in ctx.tb_DireccionReporte
                                         on sp.idResumenDiario equals stdr.idResumenDiario
                                         where sp.fecha >= fechainicial && sp.fecha <= fechaFinal && progragr.Any(x => x == (sp.programasID))
                                         select stdr.MunicipioID).Distinct().Count().ToString();



            int zonaNorte = 1;
            int ZonaCentroo = 2;
            int ZonaSur = 3;

            this.ZonaNorte.InnerText = (from s in ctx.tb_Reporte_Diario
                                        join std in ctx.tb_DireccionReporte
                                        on s.idResumenDiario equals std.idResumenDiario
                                        where s.fecha >= fechainicial && s.fecha <= fechaFinal && std.RegionID == zonaNorte && progragr.Any(x => x == (s.programasID))
                                        select std.MunicipioID).Distinct().Count().ToString();

            this.ZonaCentro.InnerText = (from a in ctx.tb_Reporte_Diario
                                         join b in ctx.tb_DireccionReporte
                                         on a.idResumenDiario equals b.idResumenDiario
                                         where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == ZonaCentroo && progragr.Any(x => x == (a.programasID))
                                         select b.MunicipioID).Distinct().Count().ToString();

            this.ZonaSurRR.InnerText = (from c in ctx.tb_Reporte_Diario
                                        join d in ctx.tb_DireccionReporte
                                        on c.idResumenDiario equals d.idResumenDiario
                                        where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == ZonaSur && progragr.Any(x => x == (c.programasID))
                                        select d.MunicipioID).Distinct().Count().ToString();

        }
        #endregion




        #region Norte *********************************
        public class datoGraficaPasteNorte
        {
            public int Cantidad { get; set; }
            public string etiquetaR { get; set; }
            public datoGraficaPasteNorte() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPasteNorte> ChartDataNorteAccionesta(string x, string fechaInicial, string fechafinal, int inclusion, int escolarOld, int escolarNew, int redesOld, int redesOldNew, int empreOld, int empreNew, int mujerOld, int mujerNew, int deporteNew, int forosferiaOld, int forosferiaNew, int redspaz)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);

            List<int> programa = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });


            try
            {
                List<datoGraficaPasteNorte> listaDatos = new List<datoGraficaPasteNorte>();

                datoGraficaPasteNorte nuevoDG = new datoGraficaPasteNorte();


                var resultado = (from ar in ctx.tb_Reporte_Diario
                                 join bz in ctx.Cat_Acciones on ar.AccionesID equals bz.AccionesID
                                 join xr in ctx.tb_DireccionReporte on ar.idResumenDiario equals xr.idResumenDiario
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && programa.Any(w => w == (ar.programasID))
                                 group bz by bz.AccionesNombre into g
                                 select new
                                 {
                                     AccionesNombre = g.Key,
                                     AccionesID = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficaPasteNorte();

                    nuevoDG.Cantidad = data.AccionesID;
                    nuevoDG.etiquetaR = data.AccionesNombre;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }




        public class datoGraficabarteNorte
        {
            public int CantidadMuni { get; set; }
            public string Municipios { get; set; }
            public datoGraficabarteNorte() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficabarteNorte> datoGraficabarteNorteMuni(string x, string fechaInicial, string fechafinal, int inclusion, int escolarOld, int escolarNew, int redesOld, int redesOldNew, int empreOld, int empreNew, int mujerOld, int mujerNew, int deporteNew, int forosferiaOld, int forosferiaNew, int redspaz)
        {
            SIICOPEntities ctx = new SIICOPEntities();
            List<int> programa = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabarteNorte> listaDatos = new List<datoGraficabarteNorte>();

                datoGraficabarteNorte nuevoDG = new datoGraficabarteNorte();


                var resultado = (from ar in ctx.tb_Reporte_Diario
                                 join xr in ctx.tb_DireccionReporte on ar.idResumenDiario equals xr.idResumenDiario
                                 join bz in ctx.Municipios on xr.MunicipioID equals bz.MunicipioID
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && programa.Any(w => w == (ar.programasID))
                                 group bz by bz.MUNICIPIO into g
                                 select new
                                 {
                                     Municipios = g.Key,
                                     municipiosid = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficabarteNorte();

                    nuevoDG.CantidadMuni = data.municipiosid;
                    nuevoDG.Municipios = data.Municipios;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ************************************


        #region centro ***********************************
        public class datoGraficaPastecentro
        {
            public int Cantidadcentro { get; set; }
            public string etiquetaRcentro { get; set; }
            public datoGraficaPastecentro() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPastecentro> ChartDataCentroAccionesta(string x, string fechaInicial, string fechafinal, int inclusion, int escolarOld, int escolarNew, int redesOld, int redesOldNew, int empreOld, int empreNew, int mujerOld, int mujerNew, int deporteNew, int forosferiaOld, int forosferiaNew, int redspaz)
        {
            SIICOPEntities ctx = new SIICOPEntities();
            List<int> programa = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPastecentro> listaDatos = new List<datoGraficaPastecentro>();

                datoGraficaPastecentro nuevoDG = new datoGraficaPastecentro();


                var resultado = (from bc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bc.idResumenDiario equals nb.idResumenDiario
                                 where bc.fecha >= fechainicial && bc.fecha <= fechaFinal && nb.RegionID == 2 && programa.Any(w => w == (bc.programasID))
                                 group bc by rt.AccionesNombre into g
                                 select new
                                 {
                                     AccionesNombre = g.Key,
                                     AccionesID = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficaPastecentro();

                    nuevoDG.Cantidadcentro = data.AccionesID;
                    nuevoDG.etiquetaRcentro = data.AccionesNombre;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public class datoGraficabartecentro
        {
            public int CantidadMunicentro { get; set; }
            public string Municipioscentro { get; set; }
            public datoGraficabartecentro() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficabartecentro> datoGraficabarteCentroMuni(string x, string fechaInicial, string fechafinal, int inclusion, int escolarOld, int escolarNew, int redesOld, int redesOldNew, int empreOld, int empreNew, int mujerOld, int mujerNew, int deporteNew, int forosferiaOld, int forosferiaNew, int redspaz)
        {
            SIICOPEntities ctx = new SIICOPEntities();
            List<int> programa = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabartecentro> listaDatos = new List<datoGraficabartecentro>();

                datoGraficabartecentro nuevoDG = new datoGraficabartecentro();


                var resultado = (from arx in ctx.tb_Reporte_Diario
                                 join xry in ctx.tb_DireccionReporte on arx.idResumenDiario equals xry.idResumenDiario
                                 join bzt in ctx.Municipios on xry.MunicipioID equals bzt.MunicipioID
                                 where arx.fecha >= fechainicial && arx.fecha <= fechaFinal && xry.RegionID == 2 && programa.Any(w => w == (arx.programasID))
                                 group bzt by bzt.MUNICIPIO into g
                                 select new
                                 {
                                     Municipios = g.Key,
                                     municipiosid = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficabartecentro();

                    nuevoDG.CantidadMunicentro = data.municipiosid;
                    nuevoDG.Municipioscentro = data.Municipios;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion****************************************


        #region ZONA SUR ******************************

        public class datoGraficaPasteSur
        {
            public int CantidadSur { get; set; }
            public string etiquetaRSur { get; set; }
            public datoGraficaPasteSur() { }

        }
        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPasteSur> ChartDataSurAccionesta(string x, string fechaInicial, string fechafinal, int inclusion, int escolarOld, int escolarNew, int redesOld, int redesOldNew, int empreOld, int empreNew, int mujerOld, int mujerNew, int deporteNew, int forosferiaOld, int forosferiaNew, int redspaz)
        {
            SIICOPEntities ctx = new SIICOPEntities();
            List<int> programa = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPasteSur> listaDatos = new List<datoGraficaPasteSur>();

                datoGraficaPasteSur nuevoDG = new datoGraficaPasteSur();


                var resultado = (from bxc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bxc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bxc.idResumenDiario equals nb.idResumenDiario
                                 where bxc.fecha >= fechainicial && bxc.fecha <= fechaFinal && nb.RegionID == 3 && programa.Any(w => w == (bxc.programasID))
                                 group bxc by rt.AccionesNombre into g
                                 select new
                                 {
                                     AccionesNombre = g.Key,
                                     AccionesID = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficaPasteSur();

                    nuevoDG.CantidadSur = data.AccionesID;
                    nuevoDG.etiquetaRSur = data.AccionesNombre;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public class datoGraficabartesur
        {
            public int CantidadMunisur { get; set; }
            public string Municipiossuro { get; set; }
            public datoGraficabartesur() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficabartesur> datoGraficabartesurMuni(string x, string fechaInicial, string fechafinal, int inclusion, int escolarOld, int escolarNew, int redesOld, int redesOldNew, int empreOld, int empreNew, int mujerOld, int mujerNew, int deporteNew, int forosferiaOld, int forosferiaNew, int redspaz)
        {
            SIICOPEntities ctx = new SIICOPEntities();
            List<int> programa = new List<int>(new int[] { inclusion, escolarOld, escolarNew, redesOld, redesOldNew, empreOld, empreNew, mujerOld, mujerNew, deporteNew, forosferiaOld, forosferiaNew, redspaz });

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabartesur> listaDatos = new List<datoGraficabartesur>();

                datoGraficabartesur nuevoDG = new datoGraficabartesur();


                var resultado = (from xxx in ctx.tb_Reporte_Diario
                                 join rrr in ctx.tb_DireccionReporte on xxx.idResumenDiario equals rrr.idResumenDiario
                                 join tt in ctx.Municipios on rrr.MunicipioID equals tt.MunicipioID
                                 where xxx.fecha >= fechainicial && xxx.fecha <= fechaFinal && rrr.RegionID == 3 & programa.Any(w => w == (xxx.programasID))
                                 group tt by tt.MUNICIPIO into g
                                 select new
                                 {
                                     Municipios = g.Key,
                                     municipiosid = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficabartesur();

                    nuevoDG.CantidadMunisur = data.municipiosid;
                    nuevoDG.Municipiossuro = data.Municipios;
                    listaDatos.Add(nuevoDG);
                }
                return listaDatos.ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion*************************************

        protected void lnkbtnImprimirReporte_Click(object sender, EventArgs e)
        {

            bool valido = true;
            string textoValidacion = "<ul>";

            if (string.IsNullOrEmpty(this.txtFechaini.Text) || string.IsNullOrEmpty(this.txtDateFin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder generar el reporte. </ li>";
                valido = false;
            }
            if (!this.ChkEmpresarial.Checked && !this.ChkEscuela.Checked && !this.ChkCiudadano.Checked && !this.ChkMujer.Checked && !this.ChkForesFerias.Checked && !this.ChkInCiudadano.Checked && !this.Chkinclusion.Checked)
            {
                textoValidacion += "<li> Es necesario seleccionar un programa para poder generar el reporte. </ li>";

                valido = false;
            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }
            else
            {
                DateTime fech1 = Convert.ToDateTime(this.txtFechaini.Text);
                string fecha1actual = fech1.ToString("dd/MM/yyyy");

                DateTime fech2 = Convert.ToDateTime(this.txtDateFin.Text);
                string fecha2actual = fech2.ToString("dd/MM/yyyy");

                DateTime fecha1anoANTE = Convert.ToDateTime(this.txtFechaini.Text).AddYears(-1);
                string ano1ante = fecha1anoANTE.ToString("dd/MM/yyyy");
                DateTime fecha2anoANTE = Convert.ToDateTime(this.txtDateFin.Text).AddYears(-1);
                string ano2ante = fecha2anoANTE.ToString("dd/MM/yyyy");

                int programa = 0;

                if (this.Chkinclusion.Checked)
                {
                    programa = Convert.ToInt32("7");
                }


                if (this.ChkCiudadano.Checked)
                {

                    programa = Convert.ToInt32("8");
                }

                if (this.ChkEscuela.Checked)
                {

                    programa = Convert.ToInt32("9");
                }

                if (this.ChkMujer.Checked)
                {

                    programa = Convert.ToInt32("10");
                }

                if (this.ChkEmpresarial.Checked)
                {

                    programa = Convert.ToInt32("13");
                }

                if (this.ChkInCiudadano.Checked)
                {
                    programa = Convert.ToInt32("12");
                }

                if (this.ChkForesFerias.Checked)
                {

                    programa = Convert.ToInt32("11");
                }


                if (this.Chkredspaz.Checked)
                {
                    programa = Convert.ToInt32("14");
                }

                string pro = Convert.ToString(programa);

                this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                this.ReportViewer1.ServerReport.ReportPath = "/SIICOP/Reporte_Comparativa_año_programa";
             //   this.ReportViewer1.ServerReport.ReportPath = "/SIICOP/INFORME_EJECUTIVO_DE_ACCIONES";             
                this.ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.8.3.199/reportserver");
                ReportParameter[] parametros = new ReportParameter[5];
                parametros[0] = new ReportParameter("fecha1_añoCurso", fecha1actual);
                parametros[1] = new ReportParameter("fecha2_añoCurso", fecha2actual);
                parametros[2] = new ReportParameter("programa", pro);
                parametros[3] = new ReportParameter("fecha1_añoAnte", ano1ante);
                parametros[4] = new ReportParameter("fecha2_añoAnte", ano2ante);



                ReportViewer1.ServerReport.SetParameters(parametros);
                ReportViewer1.ServerReport.Refresh();

                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AbrirModalReporte", "AbrirModalReporte();", true);
            }
        }
    }
}