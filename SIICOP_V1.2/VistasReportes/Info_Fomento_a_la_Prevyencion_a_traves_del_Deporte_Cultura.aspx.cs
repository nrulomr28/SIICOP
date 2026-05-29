using OfficeOpenXml;
using SIICOP_V1._2.Captura;
using SIICOP_V1._2.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIICOP_V1._2.VistasReportes

{
    public partial class Info_Fomento_a_la_Prevyencion_a_traves_del_Deporte_Cultura : System.Web.UI.Page
    {
        SIICOPEntities ctx = new SIICOPEntities();
        private int iduser;
        int progragr;
        private static DataTable dtPrincipal;
        String fechaMes;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Primera vez que se carga la pàgina o le dieron un F5
                if (User.IsInRole("SysAdmin") || User.IsInRole("Administrador") || User.IsInRole("Admin_FDC"))
                {

                    if (this.User.IsInRole("SYSADMIN") || this.User.IsInRole("Admin_FDC"))
                    {

                        this.GVICcap.Visible = false;
                        this.GvICadmin.Visible = true;
                        this.bottonExcel.Visible = true;
                    }
                    else
                    {
                        string sUsuarioActual = System.Web.Security.Membership.GetUser().UserName;
                        var i = ctx.PersonalUsuario.Where(x => x.Login == sUsuarioActual).FirstOrDefault();
                        var a = ctx.Personales.Where(x => x.login == sUsuarioActual).FirstOrDefault();
                        if (i != null)
                        {
                            Session["responsable"] = a.Personalid;
                        }
                        else
                        {
                            Session["responsable"] = -1;
                            Response.Redirect("TotalAccionesBeneficiados.aspx");
                        }
                        GVICcap.Visible = true;
                        lkbtnexcel.Visible = false;
                        GvICadmin.Visible = false;
                        GVICcap.DataBind();

                    }
                    this.conteoactividadesAdmin();
                }
                else
                {
                    this.Response.Redirect("~/TotalAccionesBeneficiados.aspx");
                }
            }
        }

        protected void GVICcap_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = GVICcap.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabel");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GVICcap.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GVICcap.PageIndex)
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
                    int currentPage = GVICcap.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GVICcap.PageCount.ToString();

                }


            }
            catch
            {
            }
        }

        protected void GVICcap_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Session["AccionExpediente"] = PrevencionVecinal.AccionExpediente.Edicion;
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;
                    Response.Redirect("~/Captura/Fomento_a_la_Prevyencion_a_traves_del_Deporte_Cultura.aspx");
                }
            }

            if (e.CommandName == "VERFOTO")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;

                    ImagenEvidencia1.ImageUrl = "";
                    ImagenEvidencia2.ImageUrl = "";
                    ImagenEvidencia3.ImageUrl = "";
                    ImagenEvidencia4.ImageUrl = "";
                    List<tb_fotografia> foto = ctx.tb_fotografia.Where(x => x.idResumenDiario == idExped).ToList();

                    foreach (var fotografia in foto)
                    {

                        Byte[] bytes = fotografia.image;

                        if (ImagenEvidencia1.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia1.ImageUrl = "data:image/png;base64," + base64String;

                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);
                            }
                            foto1.Visible = true;
                            foto11.Visible = true;
                        }
                        else
                            if (ImagenEvidencia2.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia2.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);

                            }

                            //ImagenEvidencia2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                            foto2.Visible = true;
                            foto22.Visible = true;

                        }
                        else
                            if (ImagenEvidencia3.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia3.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia3.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);

                            }

                            foto3.Visible = true;
                            foto33.Visible = true;

                        }
                        else
                        {
                            if (ImagenEvidencia4.ImageUrl == "")
                            {
                                if (bytes == null)
                                {
                                    string base64String = fotografia.ImgBase64;
                                    ImagenEvidencia4.ImageUrl = "data:image/png;base64," + base64String;
                                }
                                else
                                {
                                    Byte[] fotoVer = fotografia.image;
                                    ImagenEvidencia4.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);
                                }
                                foto34.Visible = true;
                            }
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalFotos", "AbrirModalFotos();", true);
                    }



                }
            }

        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow pagerRow = GVICcap.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownList");
            // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            GVICcap.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            //lblInfo.Text = "";

        }

        protected void GvICadmin_DataBound(object sender, EventArgs e)
        {
            try
            {

                // Recupera la el PagerRow...
                GridViewRow pagerRow = GvICadmin.BottomPagerRow;
                // Recupera los controles DropDownList y label...
                DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");
                Label pageLabel = (Label)pagerRow.FindControl("CurrentPageLabelt");
                if ((pageList != null))
                {
                    // Se crean los valores del DropDownList tomando el número total de páginas... 
                    int i = 0;
                    for (i = 0; i <= GvICadmin.PageCount - 1; i++)
                    {
                        // Se crea un objeto ListItem para representar la �gina...
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());
                        if (i == GvICadmin.PageIndex)
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
                    int currentPage = GvICadmin.PageIndex + 1;
                    // Actualiza el Label control con la �gina actual.
                    pageLabel.Text = "Página " + currentPage.ToString() + " de " + GvICadmin.PageCount.ToString();

                }


            }
            catch
            {
            }
        }

        protected void PageDropDownListAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow pagerRow = GvICadmin.BottomPagerRow;
            // Recupera el control DropDownList...
            DropDownList pageList = (DropDownList)pagerRow.FindControl("PageDropDownListAdmin");
            // Se Establece la propiedad PageIndex para visualizar la página seleccionada...
            GvICadmin.PageIndex = pageList.SelectedIndex;
            //Quita el mensaje de información si lo hubiera...
            //lblInfo.Text = "";
        }
        protected void GvICadmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Session["AccionExpediente"] = PrevencionVecinal.AccionExpediente.Edicion;
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;
                    Response.Redirect("~/Captura/Fomento_a_la_Prevyencion_a_traves_del_Deporte_Cultura.aspx");
                }
            }

            if (e.CommandName == "VERFOTO")
            {
                Guid numFila;
                if (Guid.TryParse(e.CommandArgument.ToString(), out numFila))
                {
                    Guid idExped = Guid.Parse(numFila.ToString());
                    Session["idExpediente_Accion"] = idExped;

                    ImagenEvidencia1.ImageUrl = "";
                    ImagenEvidencia2.ImageUrl = "";
                    ImagenEvidencia3.ImageUrl = "";
                    ImagenEvidencia4.ImageUrl = "";
                    List<tb_fotografia> foto = ctx.tb_fotografia.Where(x => x.idResumenDiario == idExped).ToList();

                    foreach (var fotografia in foto)
                    {

                        Byte[] bytes = fotografia.image;

                        if (ImagenEvidencia1.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia1.ImageUrl = "data:image/png;base64," + base64String;

                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);
                            }
                            foto1.Visible = true;
                            foto11.Visible = true;
                        }
                        else
                            if (ImagenEvidencia2.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia2.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);

                            }

                            //ImagenEvidencia2.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
                            foto2.Visible = true;
                            foto22.Visible = true;

                        }
                        else
                            if (ImagenEvidencia3.ImageUrl == "")
                        {
                            if (bytes == null)
                            {
                                string base64String = fotografia.ImgBase64;
                                ImagenEvidencia3.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            else
                            {
                                Byte[] fotoVer = fotografia.image;
                                ImagenEvidencia3.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);

                            }

                            foto3.Visible = true;
                            foto33.Visible = true;

                        }
                        else
                        {
                            if (ImagenEvidencia4.ImageUrl == "")
                            {
                                if (bytes == null)
                                {
                                    string base64String = fotografia.ImgBase64;
                                    ImagenEvidencia4.ImageUrl = "data:image/png;base64," + base64String;
                                }
                                else
                                {
                                    Byte[] fotoVer = fotografia.image;
                                    ImagenEvidencia4.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(fotoVer);
                                }
                                foto34.Visible = true;
                            }
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalFotos", "AbrirModalFotos();", true);
                    }



                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime result = new DateTime();
            if (DateTime.TryParse(this.txtFInicialC.Text, out result))
            {
                this.Session["fInicialC"] = (object)result.ToShortDateString();
            }
            else
                this.Session["fInicialC"] = (object)null;
            if (DateTime.TryParse(this.txtfechafin.Text, out result))
                this.Session["fFinalC"] = (object)result.ToShortDateString();
            else
                this.Session["fFinalC"] = (object)null;
            this.conteoactividadesAdmin();
        }

        protected void lkbtnexcel_Click(object sender, EventArgs e)
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
                Plantilla = Server.MapPath("~/Formatos/") + "Actividades_Programa.xlsx";
                FileStream ArchivoStream = File.OpenRead(Plantilla);
                package = new ExcelPackage(new FileInfo(Plantilla));
                ExcelWorkbook excelWorkBook = package.Workbook;
                var xlWorkSheet = excelWorkBook.Worksheets["Hoja1"];

                LlenaHoja(xlWorkSheet);

                fileStream = new MemoryStream();
                package.SaveAs(fileStream);

                fileStream.Position = 0;
                File.WriteAllBytes(Server.MapPath("~/Formatos/") + "Total_Actividades_Programa.xlsx", fileStream.ToArray());
                Response.ContentType = "Application/x-msexcel";
                string FilePath = Server.MapPath("~/Formatos/") + "Total_Actividades_Programa.xlsx";
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = ContentType;
                Response.AddHeader("Content-disposition", "attachment;filename=Total_Actividades_Programa.xlsx" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx");
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


                    int PROGRA = 12;


                    List<wv_reportesGeneralExcel> listaReportes = ctx.wv_reportesGeneralExcel.Where(R => (((convertidoFI && R.fecha >= fechaInicial) || !convertidoFI) && ((convertidoFF && R.fecha <= fechaFinal) || !convertidoFF) &&
                                                                                               (R.programasID == PROGRA))).ToList();

                    dtPrincipal = ConvertToDataTable(listaReportes);

                    for (Renglon = 0; Renglon < dtPrincipal.Rows.Count; Renglon++)
                    {

                        xlWorkSheet.Cells[Renglon + 2, 1].Value = dtPrincipal.Rows[Renglon]["fecha"];
                        xlWorkSheet.Cells[Renglon + 2, 2].Value = dtPrincipal.Rows[Renglon]["RegionNombre"];
                        xlWorkSheet.Cells[Renglon + 2, 3].Value = dtPrincipal.Rows[Renglon]["DelegacionNombre"];
                        xlWorkSheet.Cells[Renglon + 2, 4].Value = dtPrincipal.Rows[Renglon]["MUNICIPIO"];
                        xlWorkSheet.Cells[Renglon + 2, 5].Value = dtPrincipal.Rows[Renglon]["Localidad"];
                        xlWorkSheet.Cells[Renglon + 2, 6].Value = dtPrincipal.Rows[Renglon]["NombrePrograma"];
                        xlWorkSheet.Cells[Renglon + 2, 7].Value = dtPrincipal.Rows[Renglon]["NombreSubPrograma"];
                        xlWorkSheet.Cells[Renglon + 2, 8].Value = dtPrincipal.Rows[Renglon]["AccionesNombre"];
                        xlWorkSheet.Cells[Renglon + 2, 9].Value = dtPrincipal.Rows[Renglon]["TotalHombresAtendidos"];
                        xlWorkSheet.Cells[Renglon + 2, 10].Value = dtPrincipal.Rows[Renglon]["TotalMujeresAtendidas"];
                        xlWorkSheet.Cells[Renglon + 2, 11].Value = dtPrincipal.Rows[Renglon]["total_atendidos"];
                        xlWorkSheet.Cells[Renglon + 2, 12].Value = dtPrincipal.Rows[Renglon]["calle"];
                        xlWorkSheet.Cells[Renglon + 2, 13].Value = dtPrincipal.Rows[Renglon]["coloni"];
                        xlWorkSheet.Cells[Renglon + 2, 14].Value = dtPrincipal.Rows[Renglon]["NombreLugar_Escuela"];
                        xlWorkSheet.Cells[Renglon + 2, 15].Value = dtPrincipal.Rows[Renglon]["NombreContacto"];
                        xlWorkSheet.Cells[Renglon + 2, 16].Value = dtPrincipal.Rows[Renglon]["telcel"];
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

        protected void edsEstadistico_Selected(object sender, EntityDataSourceSelectedEventArgs e)
        {
            //Session["dtPrincipal"] = e.Results;
            List<wv_reportesGeneralExcel> listado = e.Results.Cast<wv_reportesGeneralExcel>().ToList();

            Session["dtPrincipal"] = listado;


        }
        protected void conteoactividadesAdmin()
        {
            if (this.Session["responsable"] != null)
            {
                this.iduser = int.Parse(this.Session["responsable"].ToString());
            }

            if (this.txtFInicialC.Text == string.Empty)
            {
                if (this.iduser != 0)
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.programasID == 12 && x.Personalid == this.iduser).Count();

                }
                else
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.programasID == 12).Count();

                }


            }
            else
            {
                DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
                DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
                if (this.iduser != 0)
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.programasID == 12 && x.Personalid == this.iduser).Count();

                }
                else
                {
                    this.lblTotalRegistros.Text = "Registros:" + ctx.tb_Reporte_Diario.Where(x => x.fecha >= fechainicial && x.fecha <= fechaFinal && x.programasID == 12).Count();

                }
            }

        }


        protected void lkmapa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('Favor de ingresar los campos de fecha para poder puntear el mapa.');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModal", "openModal();", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "initMap", "initMap();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MostrarPlanteles", "MostrarPlanteles();", true);
            }
        }

        protected void lkGraficas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFInicialC.Text) || string.IsNullOrEmpty(this.txtfechafin.Text))
            {
                ScriptManager.RegisterClientScriptBlock((Page)this, this.GetType(), "alertMessage", "alert('Favor de ingresar los campos de fecha para poder mostrar las graficas.');", true);
            }
            else
            {
                this.totalAtendidos();
                this.totalAcciones();
                this.totalporZonas();
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaHombresXacciones", "ConsultaHombresXacciones();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMuniNorte", "ConsultaMuniNorte();", true);

                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionescentroTtotal", "AccionescentroTtotal();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunicentro", "ConsultaMunicentro();", true);

                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "AccionesSurTtotal", "AccionesSurTtotal();", true);
                ScriptManager.RegisterStartupScript((Page)this, this.GetType(), "ConsultaMunisur", "ConsultaMunisur();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openModalGrafi", "openModalGrafi();", true);
            }
        }

        public void totalporZonas()
        {

            //Municipios atendidos por zonas y general 
            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
            this.progragr = 12;


            this.MuniTtoatl.InnerText = (from sp in ctx.tb_Reporte_Diario
                                         join stdr in ctx.tb_DireccionReporte
                                         on sp.idResumenDiario equals stdr.idResumenDiario
                                         where sp.fecha >= fechainicial && sp.fecha <= fechaFinal && sp.programasID == progragr
                                         select stdr.MunicipioID).Distinct().Count().ToString();



            int zonaNorte = 1;
            int ZonaCentroo = 2;
            int ZonaSur = 3;

            this.ZonaNorte.InnerText = (from s in ctx.tb_Reporte_Diario
                                        join std in ctx.tb_DireccionReporte
                                        on s.idResumenDiario equals std.idResumenDiario
                                        where s.fecha >= fechainicial && s.fecha <= fechaFinal && std.RegionID == zonaNorte && s.programasID == progragr
                                        select std.MunicipioID).Distinct().Count().ToString();

            this.ZonaCentro.InnerText = (from a in ctx.tb_Reporte_Diario
                                         join b in ctx.tb_DireccionReporte
                                         on a.idResumenDiario equals b.idResumenDiario
                                         where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == ZonaCentroo && a.programasID == progragr
                                         select b.MunicipioID).Distinct().Count().ToString();

            this.ZonaSurRR.InnerText = (from c in ctx.tb_Reporte_Diario
                                        join d in ctx.tb_DireccionReporte
                                        on c.idResumenDiario equals d.idResumenDiario
                                        where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == ZonaSur && c.programasID == progragr
                                        select d.MunicipioID).Distinct().Count().ToString();

        }
        public void totalAtendidos()
        {
            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);


            this.progragr = 12;

            //Beneficiados
            this.H2MombresBeneficiados.InnerText = (from c in ctx.tb_Reporte_Diario
                                                    join d in ctx.tb_DireccionReporte
                                                    on c.idResumenDiario equals d.idResumenDiario
                                                    where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.programasID == progragr
                                                    select c.TotalHombresAtendidos).Sum().ToString();

            this.H2MujeresBeneficiadas.InnerText = (from c in ctx.tb_Reporte_Diario
                                                    join d in ctx.tb_DireccionReporte
                                                    on c.idResumenDiario equals d.idResumenDiario
                                                    where c.fecha >= fechainicial && c.fecha <= fechaFinal && c.programasID == progragr
                                                    select c.TotalMujeresAtendidas).Sum().ToString();

            //termino de beneficiados


            this.TotalGeneralAten.InnerText = ctx.tb_Reporte_Diario.Where(p => p.fecha >= fechainicial && p.fecha <= fechaFinal & p.programasID == progragr).Sum(x => x.total_atendidos.Value).ToString();

            this.PersonasZonaNorte.InnerText = (from c in ctx.tb_Reporte_Diario
                                                join d in ctx.tb_DireccionReporte
                                                on c.idResumenDiario equals d.idResumenDiario
                                                where c.fecha >= fechainicial && c.fecha <= fechaFinal && d.RegionID == 1 && c.programasID == progragr
                                                select c.total_atendidos).Sum().ToString();

            this.PersonasAtendidasZonaCentro.InnerText = (from m in ctx.tb_Reporte_Diario
                                                          join n in ctx.tb_DireccionReporte
                                                          on m.idResumenDiario equals n.idResumenDiario
                                                          where m.fecha >= fechainicial && m.fecha <= fechaFinal && n.RegionID == 2 && m.programasID == progragr
                                                          select m.total_atendidos).Sum().ToString();

            this.personasAtendidasZonaSur.InnerText = (from ma in ctx.tb_Reporte_Diario
                                                       join nr in ctx.tb_DireccionReporte
                                                       on ma.idResumenDiario equals nr.idResumenDiario
                                                       where ma.fecha >= fechainicial && ma.fecha <= fechaFinal && nr.RegionID == 3 && ma.programasID == progragr
                                                       select ma.total_atendidos).Sum().ToString();

        }
        public void totalAcciones()
        {
            this.progragr = 12;

            DateTime fechainicial = Convert.ToDateTime(this.txtFInicialC.Text);
            DateTime fechaFinal = Convert.ToDateTime(this.txtfechafin.Text);
            this.TotalAcx.InnerText = ctx.tb_Reporte_Diario.Where(u => u.fecha >= fechainicial && u.fecha <= fechaFinal && u.programasID == progragr).Select(u => u.AccionesID).Count().ToString();

            this.AccionesZonaNorte.InnerText = (from a in ctx.tb_Reporte_Diario
                                                join b in ctx.tb_DireccionReporte
                                                on a.idResumenDiario equals b.idResumenDiario
                                                where a.fecha >= fechainicial && a.fecha <= fechaFinal && b.RegionID == 1 && a.programasID == progragr
                                                select a.AccionesID).Count().ToString();


            this.accionesRealizadasZonaCentro.InnerText = (from k in ctx.tb_Reporte_Diario
                                                           join l in ctx.tb_DireccionReporte
                                                           on k.idResumenDiario equals l.idResumenDiario
                                                           where k.fecha >= fechainicial && k.fecha <= fechaFinal && l.RegionID == 2 && k.programasID == progragr
                                                           select k.AccionesID).Count().ToString();

            this.AccionesRealizadasSur.InnerText = (from w in ctx.tb_Reporte_Diario
                                                    join x in ctx.tb_DireccionReporte
                                                    on w.idResumenDiario equals x.idResumenDiario
                                                    where w.fecha >= fechainicial && w.fecha <= fechaFinal && x.RegionID == 3 && w.programasID == progragr
                                                    select w.AccionesID).Count().ToString();
        }

        #region Norte *********************************
        public class datoGraficaPasteNorte
        {
            public int Cantidad { get; set; }
            public string etiquetaR { get; set; }
            public datoGraficaPasteNorte() { }

        }

        [WebMethod(true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<datoGraficaPasteNorte> ChartDataNorteAccionesta(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPasteNorte> listaDatos = new List<datoGraficaPasteNorte>();

                datoGraficaPasteNorte nuevoDG = new datoGraficaPasteNorte();


                var resultado = (from ar in ctx.tb_Reporte_Diario
                                 join bz in ctx.Cat_Acciones on ar.AccionesID equals bz.AccionesID
                                 join xr in ctx.tb_DireccionReporte on ar.idResumenDiario equals xr.idResumenDiario
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && ar.programasID == 12
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
        public static List<datoGraficabarteNorte> datoGraficabarteNorteMuni(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabarteNorte> listaDatos = new List<datoGraficabarteNorte>();

                datoGraficabarteNorte nuevoDG = new datoGraficabarteNorte();


                var resultado = (from ar in ctx.tb_Reporte_Diario
                                 join xr in ctx.tb_DireccionReporte on ar.idResumenDiario equals xr.idResumenDiario
                                 join bz in ctx.Municipios on xr.MunicipioID equals bz.MunicipioID
                                 where ar.fecha >= fechainicial && ar.fecha <= fechaFinal && xr.RegionID == 1 && ar.programasID == 12
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
        public static List<datoGraficaPastecentro> ChartDataCentroAccionesta(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPastecentro> listaDatos = new List<datoGraficaPastecentro>();

                datoGraficaPastecentro nuevoDG = new datoGraficaPastecentro();


                var resultado = (from bc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bc.idResumenDiario equals nb.idResumenDiario
                                 where bc.fecha >= fechainicial && bc.fecha <= fechaFinal && nb.RegionID == 2 && bc.programasID == 12
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
        public static List<datoGraficabartecentro> datoGraficabarteCentroMuni(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabartecentro> listaDatos = new List<datoGraficabartecentro>();

                datoGraficabartecentro nuevoDG = new datoGraficabartecentro();


                var resultado = (from arx in ctx.tb_Reporte_Diario
                                 join xry in ctx.tb_DireccionReporte on arx.idResumenDiario equals xry.idResumenDiario
                                 join bzt in ctx.Municipios on xry.MunicipioID equals bzt.MunicipioID
                                 where arx.fecha >= fechainicial && arx.fecha <= fechaFinal && xry.RegionID == 2 && arx.programasID == 12
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
        public static List<datoGraficaPasteSur> ChartDataSurAccionesta(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficaPasteSur> listaDatos = new List<datoGraficaPasteSur>();

                datoGraficaPasteSur nuevoDG = new datoGraficaPasteSur();


                var resultado = (from bxc in ctx.tb_Reporte_Diario
                                 join rt in ctx.Cat_Acciones on bxc.AccionesID equals rt.AccionesID
                                 join nb in ctx.tb_DireccionReporte on bxc.idResumenDiario equals nb.idResumenDiario
                                 where bxc.fecha >= fechainicial && bxc.fecha <= fechaFinal && nb.RegionID == 3 && bxc.programasID == 12
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
        public static List<datoGraficabartesur> datoGraficabartesurMuni(string x, string fechaInicial, string fechafinal)
        {
            SIICOPEntities ctx = new SIICOPEntities();

            DateTime fechainicial = Convert.ToDateTime(fechaInicial);
            DateTime fechaFinal = Convert.ToDateTime(fechafinal);
            try
            {
                List<datoGraficabartesur> listaDatos = new List<datoGraficabartesur>();

                datoGraficabartesur nuevoDG = new datoGraficabartesur();


                var resultado = (from xxx in ctx.tb_Reporte_Diario
                                 join rrr in ctx.tb_DireccionReporte on xxx.idResumenDiario equals rrr.idResumenDiario
                                 join tt in ctx.Municipios on rrr.MunicipioID equals tt.MunicipioID
                                 where xxx.fecha >= fechainicial && xxx.fecha <= fechaFinal && rrr.RegionID == 3 & xxx.programasID == 12
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

        protected void GVICcap_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int valor;
                    valor = (int)DataBinder.Eval(e.Row.DataItem, "fotos");
                    Image img = (Image)e.Row.FindControl("imgCap");




                    if (valor == 1)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/check.png";
                    }
                    if (valor == 0)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/cross.png";
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GvICadmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {


                    int valor;
                    valor = (int)DataBinder.Eval(e.Row.DataItem, "fotos");
                    Image img = (Image)e.Row.FindControl("imgAdmin");




                    if (valor == 1)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/check.png";
                    }
                    if (valor == 0)
                    {
                        img.ImageUrl = "~/Imagenes/PinesReporte/cross.png";
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkbtnCarga_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AbrirModalCargasTrabajo", "AbrirModalCargasTrabajo();", true);
            Conteo_A_B_TB_X_Cargadetrabajo();

        }

        #region ***********CARGAS DE TRABAJO PARA ADMINISTRADORES
        private void Conteo_A_B_TB_X_Cargadetrabajo()
        {
            //** CONTEO CARGA DE TRABAJO XALAPA
            fechaMes = Convert.ToString(DateTime.Now.Month);
            int mesactual = DateTime.Now.Month;
            //ACCIONES
            tbCarga_trabajo_Dele AccionesXareaObjXAL = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "CONURBACION XALAPA XX" && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            MesActividdesGral.InnerText = AccionesXareaObjXAL.Mes_letra;
            spanAccionXareaObjeXAL.InnerText = Convert.ToString(AccionesXareaObjXAL.cifra);


            this.spanAccionXareaObjtXAL.InnerText = (from s in ctx.tb_Reporte_Diario
                                                     join std in ctx.tb_DireccionReporte
                                                     on s.idResumenDiario equals std.idResumenDiario
                                                     where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "CONURBACION XALAPA XX" && s.programasID == 12
                                                     select s.programasID).Count().ToString();

            double totalGralXAL = 0;
            double vamosGraldXAL = 0;
            double.TryParse(Convert.ToString(AccionesXareaObjXAL.cifra), out totalGralXAL);
            double.TryParse(Convert.ToString(spanAccionXareaObjtXAL.InnerText), out vamosGraldXAL);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompleteg = (int)(0.5f + ((100f * vamosGraldXAL) / totalGralXAL));

            if (percentCompleteg >= 75 || percentCompleteg >= 100)
            {
                ArribagralAccionXAL.Visible = true;
            }
            else
            {
                if (percentCompleteg <= 49)
                {
                    AbajoagralAccionXAL.Visible = true;
                }
                else
                {
                    if (percentCompleteg == 50 || percentCompleteg <= 72)
                    {
                        mediogralAccionXAL.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 


            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosGralxmesdOBJXAL = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "CONURBACION XALAPA XX" && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            spanBeniTotalXareaObjeXAL.InnerText = Convert.ToString(beneficiadosGralxmesdOBJXAL.cifra);


            this.spanBeniTotalXareaObjtXAL.InnerText = (from s in ctx.tb_Reporte_Diario
                                                        join std in ctx.tb_DireccionReporte
                                                        on s.idResumenDiario equals std.idResumenDiario
                                                        where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "CONURBACION XALAPA XX" && s.programasID == 12
                                                        select s.total_atendidos).Sum().ToString();
            //**
            //*********************************************************************************************************************
            //*********************************************************************************************************************


            //** CONTEO CARGA DE TRABAJO CONURBACION VERACRUZ XXIII

            //ACCIONES
            tbCarga_trabajo_Dele AccionesXareaObjVER = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "CONURBACION VERACRUZ XXIII" && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            spanAccionXareaObjeVER.InnerText = Convert.ToString(AccionesXareaObjVER.cifra);


            this.spanAccionXareaObjtVER.InnerText = (from s in ctx.tb_Reporte_Diario
                                                     join std in ctx.tb_DireccionReporte
                                                     on s.idResumenDiario equals std.idResumenDiario
                                                     where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "CONURBACION VERACRUZ XXIII" && s.programasID == 12
                                                     select s.programasID).Count().ToString();

            double totalGralVER = 0;
            double vamosGraldVER = 0;
            double.TryParse(Convert.ToString(AccionesXareaObjVER.cifra), out totalGralVER);
            double.TryParse(Convert.ToString(spanAccionXareaObjtVER.InnerText), out vamosGraldVER);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompletegVER = (int)(0.5f + ((100f * vamosGraldVER) / totalGralVER));

            if (percentCompletegVER >= 75 || percentCompletegVER >= 100)
            {
                ArribagralAccionver.Visible = true;
            }
            else
            {
                if (percentCompletegVER <= 49)
                {
                    AbajogralAccionver.Visible = true;
                }
                else
                {
                    if (percentCompletegVER == 50 || percentCompletegVER <= 72)
                    {
                        MediogralAccionver.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 


            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosGralxmesdOBJVER = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "CONURBACION VERACRUZ XXIII" && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            spanBeniTotalXareaObjeVER.InnerText = Convert.ToString(beneficiadosGralxmesdOBJVER.cifra);


            this.spanBeniTotalXareaObtVER.InnerText = (from s in ctx.tb_Reporte_Diario
                                                       join std in ctx.tb_DireccionReporte
                                                       on s.idResumenDiario equals std.idResumenDiario
                                                       where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "CONURBACION VERACRUZ XXIII" && s.programasID == 12
                                                       select s.total_atendidos).Sum().ToString();
            //**
            //************************************************************************************************
            //************************************************************************************************

            //** CONTEO CARGA DE TRABAJO CONURBACION POZA RICA

            //ACCIONES
            tbCarga_trabajo_Dele AccionesXareaObjPOZA = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "CONURBACION POZA RICA" && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            spanAccionXareaObjePOZA.InnerText = Convert.ToString(AccionesXareaObjPOZA.cifra);


            this.spanAccionXareaObjtPOZA.InnerText = (from s in ctx.tb_Reporte_Diario
                                                      join std in ctx.tb_DireccionReporte
                                                      on s.idResumenDiario equals std.idResumenDiario
                                                      where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "CONURBACION POZA RICA" && s.programasID == 12
                                                      select s.programasID).Count().ToString();

            double totalGralPOZA = 0;
            double vamosGraldPOZA = 0;
            double.TryParse(Convert.ToString(AccionesXareaObjPOZA.cifra), out totalGralPOZA);
            double.TryParse(Convert.ToString(spanAccionXareaObjtPOZA.InnerText), out vamosGraldPOZA);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompletegPOZA = (int)(0.5f + ((100f * vamosGraldPOZA) / totalGralPOZA));

            if (percentCompletegPOZA >= 75 || percentCompletegPOZA >= 100)
            {
                ArribagralAccionPOZA.Visible = true;
            }
            else
            {
                if (percentCompletegPOZA <= 49)
                {
                    AbajogralAccionPOZA.Visible = true;
                }
                else
                {
                    if (percentCompletegPOZA == 50 || percentCompletegPOZA <= 72)
                    {
                        MediogralAccionPOZA.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 


            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosGralxmesdOBJPOZA = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "CONURBACION POZA RICA" && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            spanBeniTotalXareaObjePOZA.InnerText = Convert.ToString(beneficiadosGralxmesdOBJPOZA.cifra);


            this.spanBeniTotalXareaObjtPOZA.InnerText = (from s in ctx.tb_Reporte_Diario
                                                         join std in ctx.tb_DireccionReporte
                                                         on s.idResumenDiario equals std.idResumenDiario
                                                         where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "CONURBACION POZA RICA" && s.programasID == 12
                                                         select s.total_atendidos).Sum().ToString();
            //**

            //************************************************************************************************
            //************************************************************************************************

            //** CONTEO CARGA DE TRABAJO COORDINACION CORDOBA

            //ACCIONES
            tbCarga_trabajo_Dele AccionesXareaObjCOR = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "COORDINACION CORDOBA" && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            spanAccionXareaObjeCOR.InnerText = Convert.ToString(AccionesXareaObjCOR.cifra);


            this.spanAccionXareaObjTCOR.InnerText = (from s in ctx.tb_Reporte_Diario
                                                     join std in ctx.tb_DireccionReporte
                                                     on s.idResumenDiario equals std.idResumenDiario
                                                     where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "COORDINACION CORDOBA" && s.programasID == 12
                                                     select s.programasID).Count().ToString();

            double totalGralCOR = 0;
            double vamosGraldCOR = 0;
            double.TryParse(Convert.ToString(AccionesXareaObjCOR.cifra), out totalGralCOR);
            double.TryParse(Convert.ToString(spanAccionXareaObjTCOR.InnerText), out vamosGraldCOR);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompletegCOR = (int)(0.5f + ((100f * vamosGraldCOR) / totalGralCOR));

            if (percentCompletegCOR >= 75 || percentCompletegCOR >= 100)
            {
                ArribagralAccionCOR.Visible = true;
            }
            else
            {
                if (percentCompletegCOR <= 49)
                {
                    AbajogralAccionCOR.Visible = true;
                }
                else
                {
                    if (percentCompletegCOR == 50 || percentCompletegCOR <= 72)
                    {
                        MediogralAccionCOR.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 


            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosGralxmesdOBJCOR = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "COORDINACION CORDOBA" && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            spanBeniTotalXareaObjeCOR.InnerText = Convert.ToString(beneficiadosGralxmesdOBJCOR.cifra);


            this.spanBeniTotalXareaObjtCOR.InnerText = (from s in ctx.tb_Reporte_Diario
                                                        join std in ctx.tb_DireccionReporte
                                                        on s.idResumenDiario equals std.idResumenDiario
                                                        where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "COORDINACION CORDOBA" && s.programasID == 12
                                                        select s.total_atendidos).Sum().ToString();
            //**

            //************************************************************************************************
            //************************************************************************************************

            //** CONTEO CARGA DE TRABAJO COORDINACION COATZACOALCOS

            //ACCIONES
            tbCarga_trabajo_Dele AccionesXareaObjCOATZA = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "COORDINACION COATZACOALCOS" && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            spanAccionXareaObjeCOATZA.InnerText = Convert.ToString(AccionesXareaObjCOATZA.cifra);


            this.spanAccionXareaObjtCOATZA.InnerText = (from s in ctx.tb_Reporte_Diario
                                                        join std in ctx.tb_DireccionReporte
                                                        on s.idResumenDiario equals std.idResumenDiario
                                                        where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "COORDINACION COATZACOALCOS" && s.programasID == 12
                                                        select s.programasID).Count().ToString();

            double totalGralCOATZA = 0;
            double vamosGraldCOATZA = 0;
            double.TryParse(Convert.ToString(AccionesXareaObjCOATZA.cifra), out totalGralCOATZA);
            double.TryParse(Convert.ToString(spanAccionXareaObjtCOATZA.InnerText), out vamosGraldCOATZA);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompletegCOATZA = (int)(0.5f + ((100f * vamosGraldCOATZA) / totalGralCOATZA));

            if (percentCompletegCOATZA >= 75 || percentCompletegCOATZA >= 100)
            {
                ArribagralAccionCOATZA.Visible = true;
            }
            else
            {
                if (percentCompletegCOATZA <= 49)
                {
                    AbajogralAccionCOATZA.Visible = true;
                }
                else
                {
                    if (percentCompletegCOATZA == 50 || percentCompletegCOATZA <= 72)
                    {
                        MediogralAccionCOATZA.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 


            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosGralxmesdOBJCOATZA = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "COORDINACION COATZACOALCOS" && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            spanBeniTotalXareaObjeCOATZA.InnerText = Convert.ToString(beneficiadosGralxmesdOBJCOATZA.cifra);


            this.spanBeniTotalXareaObjtCOATZA.InnerText = (from s in ctx.tb_Reporte_Diario
                                                           join std in ctx.tb_DireccionReporte
                                                           on s.idResumenDiario equals std.idResumenDiario
                                                           where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "COORDINACION COATZACOALCOS" && s.programasID == 12
                                                           select s.total_atendidos).Sum().ToString();
            //**

            //************************************************************************************************
            //************************************************************************************************

            //** CONTEO CARGA DE TRABAJO ENLACES

            //ACCIONES
            tbCarga_trabajo_Dele AccionesXareaObjENLACE = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "Enlace" && x.Tipo_TA_BA_TB == 1).FirstOrDefault();
            spanAccionXareaObjeENLACE.InnerText = Convert.ToString(AccionesXareaObjENLACE.cifra);


            this.spanAccionXareaObjtENLACE.InnerText = (from s in ctx.tb_Reporte_Diario
                                                        join std in ctx.tb_DireccionReporte
                                                        on s.idResumenDiario equals std.idResumenDiario
                                                        where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "ENLACES" && s.programasID == 12
                                                        select s.programasID).Count().ToString();

            double totalGralENLACE = 0;
            double vamosGraldENLACE = 0;
            double.TryParse(Convert.ToString(AccionesXareaObjENLACE.cifra), out totalGralENLACE);
            double.TryParse(Convert.ToString(spanAccionXareaObjtENLACE.InnerText), out vamosGraldENLACE);
            //string porcentaje = (vamos  / total * 100).ToString("N2") + " %";
            int percentCompletegENLACE = (int)(0.5f + ((100f * vamosGraldENLACE) / totalGralENLACE));

            if (percentCompletegENLACE >= 75 || percentCompletegENLACE >= 100)
            {
                ArribagralAccionENLACE.Visible = true;
            }
            else
            {
                if (percentCompletegENLACE <= 49)
                {
                    AbajogralAccionENLACE.Visible = true;
                }
                else
                {
                    if (percentCompletegENLACE == 50 || percentCompletegENLACE <= 72)
                    {
                        MediogralAccionENLACE.Visible = true;
                    }
                }

            }
            // TERMINA EL CONTEO DE ACCIONES 


            //CONTEO DE BENEFICIADOS POR MES 
            tbCarga_trabajo_Dele beneficiadosGralxmesdOBJENLACE = this.ctx.tbCarga_trabajo_Dele.Where(x => x.programa == 12 && x.Mes_Num == mesactual && x.Delegacion == "Enlace" && x.Tipo_TA_BA_TB == 3).FirstOrDefault();
            spanBeniTotalXareaObjeENLACE.InnerText = Convert.ToString(beneficiadosGralxmesdOBJENLACE.cifra);


            this.spanBeniTotalXareaObjtENLACE.InnerText = (from s in ctx.tb_Reporte_Diario
                                                           join std in ctx.tb_DireccionReporte
                                                           on s.idResumenDiario equals std.idResumenDiario
                                                           where s.fecha.Value.Month >= mesactual && s.DelegacionOcoonurbacion == "ENLACES" && s.programasID == 12
                                                           select s.total_atendidos).Sum().ToString();
            //**
        }
        #endregion
    }
}