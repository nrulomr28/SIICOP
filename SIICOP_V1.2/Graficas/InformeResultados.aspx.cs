using Microsoft.Reporting.WebForms;
using SIICOP_V1._2.Datos;
using SIICOP_V1._2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.Graficas
{
    public partial class InformeResultados : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        bool valido = true;
        string textoValidacion = "<ul>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Visualizador") || User.IsInRole("Operador"))
                {

                }
                else
                {
                    RedirectHelper.Redirect(this.Response,"~/TotalAccionesBeneficiados.aspx");
                }
            }
        }
        public void totalAcciones()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.TotalAcx.InnerText = ctx.tb_Reporte_Diario.Where(u => u.fecha >= fechainicial && u.fecha <= fechaFinal).Select(u => u.AccionesID).Count().ToString();

        }

        public void totalatendidoss()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);

            //TotalGeneralAten.InnerText = ctx.tb_Reporte_Diario.Where(p => p.fecha >= fechainicial && p.fecha <= fechaFinal).Sum(x => x.total_atendidos.Value).ToString();
            this.TotalGeneralAten.InnerText = (from c in ctx.tb_Reporte_Diario
                                               where c.fecha >= fechainicial && c.fecha <= fechaFinal
                                               select c.total_atendidos).Sum().ToString();
        }

        public void totalMunicipios()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.totalMunii.InnerText = (from s in ctx.tb_Reporte_Diario
                                         join std in ctx.tb_DireccionReporte
                                         on s.idResumenDiario equals std.idResumenDiario
                                         where s.fecha >= fechainicial && s.fecha <= fechaFinal
                                         select std.MunicipioID).Distinct().Count().ToString();
        }


        public class datoGraficaPaste
        {
            public int Cantidad { get; set; }
            public string etiquetaR { get; set; }
            public datoGraficaPaste() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPaste> GetChartData(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();
            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPaste> listaDatos = new List<datoGraficaPaste>();

                datoGraficaPaste nuevoDG = new datoGraficaPaste();

                //var obtenerAcciones = ctx.Cat_Acciones.Select(a => new
                //{
                //    Accion = a.AccionesNombre,
                //    TotalAcciones = ctx.tb_Reporte_Diario.Where(r => r.AccionesID == a.AccionesID).Count()
                //}).ToList();

                var resultado = (from a in ctx.tb_Reporte_Diario
                                 join b in ctx.Cat_Acciones on a.AccionesID equals b.AccionesID
                                 where a.fecha >= fechainicial && a.fecha <= fechaFinal
                                 group b by b.AccionesNombre into g
                                 select new
                                 {
                                     AccionesNombre = g.Key,
                                     AccionesID = g.Count(),

                                 });


                foreach (var data in resultado)
                {
                    nuevoDG = new datoGraficaPaste();

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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFechaini.Text) || string.IsNullOrEmpty(this.txtDateFin.Text))
            {
                textoValidacion += "<li> Es necesario ingresar las fechas para poder generar el reporte. </ li>";
                valido = false;
                this.imprimir.Visible = false;
                this.Resultados.Visible = false;

            }
            if (!valido)
            {
                textoValidacion += "</ul>";
                validadottxt.Text = textoValidacion;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalValidador", "AbrirModalValidador();", true);

            }


            else
            {
                this.totalAcciones();
                this.totalatendidoss();
                this.totalMunicipios();
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsulTotalAcciones", "ConsulTotalAcciones();", true);
                this.totalAccionesNorte();
                this.totalatendidossNorte();
                this.totalMunicipiosNorte();
                this.gvaccionesnorte();
                this.totalAccionesCentro();
                this.totalatendidosscentro();
                this.totalMunicipioscentro();
                this.gvaccionescentr();
                this.totalAccionesSur();
                this.totalatendidosssur();
                this.totalMunicipiossur();
                this.gvaccionessur();
                this.Resultados.Visible = true;
                this.imprimir.Visible = true;
            }
        }

        protected void btnInprimirReporte_Click(object sender, EventArgs e)
        {
            this.ReportePdf.Visible = true;
            this.Resultados.Visible = false;
            this.imprimir.Visible = false;
            this.cancelar.Visible = true;
            this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            this.ReportViewer1.ServerReport.ReportPath = "/SIICOP/Infrome_ejecutivo_semanal";
            //this.ReportViewer1.ServerReport.ReportPath = "/SIICOP/INFORME_EJECUTIVO_DE_ACCIONES";
            this.ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.8.3.199/reportserver");
            ReportParameter[] parametros = new ReportParameter[2];
            parametros[0] = new ReportParameter("fecha1", txtFechaini.Text);
            parametros[1] = new ReportParameter("fecha2", txtDateFin.Text);



            ReportViewer1.ServerReport.SetParameters(parametros);
            ReportViewer1.ServerReport.Refresh();
        }

        #region zona norte************************************************************************

        public void totalAccionesNorte()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);

            this.AccionesZonaNorte.InnerText = (from a in ctx.tb_Reporte_Diario
                                                join b in ctx.tb_DireccionReporte
                                                on a.idResumenDiario equals b.idResumenDiario
                                                where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == 1
                                                select a.AccionesID).Count().ToString();

        }

        public void totalatendidossNorte()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);

            this.AtendidosZonaNorte.InnerText = (from c in ctx.tb_Reporte_Diario
                                                 join d in ctx.tb_DireccionReporte
                                                 on c.idResumenDiario equals d.idResumenDiario
                                                 where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == 1
                                                 select c.total_atendidos).Sum().ToString();

        }

        public void totalMunicipiosNorte()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);

            this.MuniZonaNorte.InnerText = (from e in ctx.tb_Reporte_Diario
                                            join f in ctx.tb_DireccionReporte
                                            on e.idResumenDiario equals f.idResumenDiario
                                            where e.fecha >= fechainicial && e.fecha <= fechaFinal && f.RegionID == 1
                                            select f.MunicipioID).Distinct().Count().ToString();
        }

        public void gvaccionesnorte()
        {
            try
            {
                if (this.txtFechaini.Text != null)
                {
                    DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
                    DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
                    this.gvzonanorte.DataSource = (from g in ctx.tb_Reporte_Diario
                                                   join i in ctx.tb_programa
                                                    on g.programasID equals i.programasID
                                                   join j in ctx.tb_DireccionReporte
                                                   on g.idResumenDiario equals j.idResumenDiario
                                                   join h in ctx.Municipios
                                                   on j.MunicipioID equals h.MunicipioID
                                                   where g.fecha >= fechainicial && g.fecha <= fechaFinal && j.RegionID == 1
                                                   group g by new { h.MUNICIPIO, i.NombrePrograma } into gps
                                                   select new
                                                   {
                                                       ProgramaNomb = gps.Key.NombrePrograma,
                                                       Municipios = gps.Key.MUNICIPIO,
                                                       totalPprMun = gps.Count()
                                                   }).ToList();

                    this.gvzonanorte.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void gvzonanorte_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = gvzonanorte.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabel");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= gvzonanorte.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == gvzonanorte.PageIndex)
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
                    int currentPage = gvzonanorte.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + gvzonanorte.PageCount.ToString();

                }


            }
            catch
            {
            }
        }
        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow pagerRow = gvzonanorte.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
            // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            gvzonanorte.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...

            this.gvaccionesnorte();
            this.gvzonanorte.DataBind();

        }
        #endregion********************************************************************************

        #region ZONA CENTRO *************************************************************************
        public void totalAccionesCentro()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.AccionesCentro.InnerText = (from k in ctx.tb_Reporte_Diario
                                             join l in ctx.tb_DireccionReporte
                                             on k.idResumenDiario equals l.idResumenDiario
                                             where k.fecha >= fechainicial && k.fecha <= fechaFinal && l.RegionID == 2
                                             select k.AccionesID).Count().ToString();
        }

        public void totalatendidosscentro()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.personasCentro.InnerText = (from m in ctx.tb_Reporte_Diario
                                             join n in ctx.tb_DireccionReporte
                                             on m.idResumenDiario equals n.idResumenDiario
                                             where m.fecha >= fechainicial && m.fecha <= fechaFinal && n.RegionID == 2
                                             select m.total_atendidos).Sum().ToString();
        }

        public void totalMunicipioscentro()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.MunicipiosCentro.InnerText = (from o in ctx.tb_Reporte_Diario
                                               join p in ctx.tb_DireccionReporte
                                               on o.idResumenDiario equals p.idResumenDiario
                                               where o.fecha >= fechainicial && o.fecha <= fechaFinal && p.RegionID == 2
                                               select p.MunicipioID).Distinct().Count().ToString();

        }

        public void gvaccionescentr()
        {
            try
            {
                if (this.txtFechaini.Text == null)
                    return;
                DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
                DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
                this.gvZonaCentro.DataSource =
                    (from q in ctx.tb_Reporte_Diario
                     join r in ctx.tb_programa
                      on q.programasID equals r.programasID
                     join t in ctx.tb_DireccionReporte
                     on q.idResumenDiario equals t.idResumenDiario
                     join s in ctx.Municipios
                     on t.MunicipioID equals s.MunicipioID
                     where q.fecha >= fechainicial && q.fecha <= fechaFinal && t.RegionID == 2
                     group q by new { s.MUNICIPIO, r.NombrePrograma } into gps
                     select new
                     {
                         ProgramaNomb = gps.Key.NombrePrograma,
                         Municipios = gps.Key.MUNICIPIO,
                         totalPprMun = gps.Count()
                     }).ToList();

                this.gvZonaCentro.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
        protected void gvZonaCentro_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = gvZonaCentro.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("pddZonaCentro");
                Label pageLabel = (Label)pagerRow.FindControl("cplZonaCentro");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= gvZonaCentro.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == gvZonaCentro.PageIndex)
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
                    int currentPage = gvZonaCentro.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + gvZonaCentro.PageCount.ToString();

                }


            }
            catch
            {
            }
        }

        protected void pddZonaCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                GridViewRow pagerRow = gvZonaCentro.BottomPagerRow;
                // Recupera el control DropDownList...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("pddZonaCentro");
                // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
                gvZonaCentro.PageIndex = pageList.SelectedIndex;
                //Quita el mensaje de información si lo hubiera...

                this.gvaccionescentr();
                this.gvZonaCentro.DataBind();
            }
        }

        #endregion***********************************************************************************



        #region zona sur ****************************************************************************

        public void totalAccionesSur()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.accionesSur.InnerText = (from w in ctx.tb_Reporte_Diario
                                          join x in ctx.tb_DireccionReporte
                                          on w.idResumenDiario equals x.idResumenDiario
                                          where w.fecha >= fechainicial && w.fecha <= fechaFinal && x.RegionID == 3
                                          select w.AccionesID).Count().ToString();
        }

        public void totalatendidosssur()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.personasSur.InnerText = (from ma in ctx.tb_Reporte_Diario
                                          join nr in ctx.tb_DireccionReporte
                                          on ma.idResumenDiario equals nr.idResumenDiario
                                          where ma.fecha >= fechainicial && ma.fecha <= fechaFinal && nr.RegionID == 3
                                          select ma.total_atendidos).Sum().ToString();

        }

        public void totalMunicipiossur()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
            this.MunicipiosSur.InnerText = (from oq in ctx.tb_Reporte_Diario
                                            join pr in ctx.tb_DireccionReporte
                                            on oq.idResumenDiario equals pr.idResumenDiario
                                            where oq.fecha >= fechainicial && oq.fecha <= fechaFinal && pr.RegionID == 3
                                            select pr.MunicipioID).Distinct().Count().ToString();
        }

        public void gvaccionessur()
        {
            try
            {
                if (this.txtFechaini.Text != null)
                {
                    DateTime fechainicial = Convert.ToDateTime(this.txtFechaini.Text);
                    DateTime fechaFinal = Convert.ToDateTime(this.txtDateFin.Text);
                    this.GvProgramaSur.DataSource = (from qe in ctx.tb_Reporte_Diario
                                                     join rr in ctx.tb_programa
                                                      on qe.programasID equals rr.programasID
                                                     join tm in ctx.tb_DireccionReporte
                                                     on qe.idResumenDiario equals tm.idResumenDiario
                                                     join sa in ctx.Municipios
                                                     on tm.MunicipioID equals sa.MunicipioID
                                                     where qe.fecha >= fechainicial && qe.fecha <= fechaFinal && tm.RegionID == 3
                                                     group qe by new { sa.MUNICIPIO, rr.NombrePrograma } into gps
                                                     select new
                                                     {
                                                         ProgramaNomb = gps.Key.NombrePrograma,
                                                         Municipios = gps.Key.MUNICIPIO,
                                                         totalPprMun = gps.Count()
                                                     }).ToList();

                    this.GvProgramaSur.DataBind();
                }
            }
            catch (Exception ex)
            {
            }
        }


        protected void GvProgramaSur_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = GvProgramaSur.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("pddZonasur");
                Label pageLabel = (Label)pagerRow.FindControl("cplZonasur");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvProgramaSur.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvProgramaSur.PageIndex)
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
                    int currentPage = GvProgramaSur.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvProgramaSur.PageCount.ToString();

                }


            }
            catch
            {
            }
        }

        protected void pddZonasur_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow pagerRow = GvProgramaSur.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.FindControl("pddZonasur");
            // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            GvProgramaSur.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...

            this.gvaccionesnorte();
            this.GvProgramaSur.DataBind();

        }
        #endregion **********************************************************************************







        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            this.ReportePdf.Visible = false;
            this.Resultados.Visible = true;
            this.cancelar.Visible = false;
            this.imprimir.Visible = true;
        }
    }
}