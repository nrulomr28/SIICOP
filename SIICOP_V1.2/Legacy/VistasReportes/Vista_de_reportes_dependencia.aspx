<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vista_de_reportes_dependencia.aspx.cs" Inherits="SIICOP_V1._2.VistasReportes.Vista_de_reportes_dependencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="container" style="padding-top:3%">
        <div class="row">
            <div id="sidebar" style="background-color: #7A6F44; padding-top: 20px; padding-bottom: 20px; border-radius: 15px;">
                <div class="sosmed">
                    <div class="user">
                        <div class="user-head">
                            <h1 style="text-align: center; color: white"><span>VISTA DE DATOS DE LAS ACTIVIDADES CAPTURADAS</span></h1>
                            <div class="hr-center"></div>
                            <h3 style="color: #feff00; text-align: center" id="dependencia" runat="server"></h3>
                        </div>
                        <div class="link-me">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />

    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-2">
                <div class="form-group has-feedback">
                    <div class="input-group">
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                        <asp:TextBox ID="txtFInicialC" runat="server" CssClass="form-control" placeholder="Fecha inicial"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="ceFIC" runat="server" TargetControlID="txtFInicialC" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
            </div>
            <div class="col-lg-2">
                <div class="form-group has-feedback">
                    <div class="input-group">
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                        <asp:TextBox ID="txtfechafin" runat="server" CssClass="form-control" placeholder="Fecha final"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechafin" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="txtBusquedaFolio" CssClass="form-control" placeholder="Busqueda por descripción.."></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-2">

                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-warning" Text="Buscar" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12 offset-md-3">
                <asp:GridView runat="server" ID="gvActividadesDepen"
                    EmptyDataText="No se encontraron datos."
                    CssClass="table table-bordered " CellPadding="5" AllowPaging="True"
                    AutoGenerateColumns="False" DataKeyNames="idResumenDiario" DataSourceID="edsActividadesCap"
                    OnRowDataBound="gvActividadesDepen_RowDataBound"
                    OnRowCommand="gvActividadesDepen_RowCommand">
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <Columns>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" DataFormatString="{0:dddd-dd-MMMM-yyyy}"></asp:BoundField>
                        <asp:BoundField DataField="nombrecompleto" HeaderText="Capturista" SortExpression="nombrecompleto"></asp:BoundField>
                        <asp:BoundField DataField="AreaTrabajo" HeaderText="Dependencia" SortExpression="AreaTrabajo"></asp:BoundField>
                        <asp:BoundField DataField="NombrePrograma" HeaderText="Programa" SortExpression="NombrePrograma"></asp:BoundField>
                        <asp:BoundField DataField="NombreSubPrograma" HeaderText="Subprograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                        <asp:BoundField DataField="AccionesNombre" HeaderText="Acción implementada" SortExpression="AccionesNombre"></asp:BoundField>
                        <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                        <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                        <asp:BoundField DataField="total_atendidos" HeaderText="Total beneficiados" SortExpression="total_atendidos"></asp:BoundField>
                        <asp:BoundField DataField="descripcion_actividad" HeaderText="Descripción de la actividad" SortExpression="descripcion_actividad"></asp:BoundField>
                        <asp:TemplateField HeaderText="¿Fotos cargadas?">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" AlternateText='<%# Eval("fotos") %>' ID="imgpato" Width="25" Height="25" CommandArgument='<%# Eval("idResumenDiario") %>' CommandName="VERFOTO" ToolTip="Ver fotos" />
                                <%--<asp:Image ></asp:Image>--%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Editar" CommandName="Editar" CausesValidation="False" ID="lkbEditar" ToolTip="Editar" CommandArgument='<%# Eval("idResumenDiario") %>'>
                                    <i class="fas fa-edit" style="font-size:1.8em; color:#7A6F44"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
                <asp:EntityDataSource runat="server" ID="edsActividadesCap" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico"
                    Where="((@fInicialC IS NULL OR it.fecha >= @fInicialC) AND (@fFinalC IS NULL OR it.fecha <= @fFinalC) AND (it.Personalid == @resp) and (@Folio is null or it.descripcion_actividad like '%' + @Folio + '%'))">

                    <WhereParameters>
                        <asp:SessionParameter DefaultValue="0" Name="resp" SessionField="responsable" DbType="Int32" />
                        <asp:SessionParameter SessionField="fInicialC" Name="fInicialC" Type="DateTime" />
                        <asp:SessionParameter SessionField="fFinalC" Name="fFinalC" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtBusquedaFolio" Name="Folio" PropertyName="Text" Type="String" DefaultValue="" />
                    </WhereParameters>
                </asp:EntityDataSource>
            </div>
        </div>
    </div>



    <!-- MODAL PARA VER IMAGENES -->
    <div class="modal fade" id="myModalConsultariMG" tabindex="-1" role="dialog" aria-labelledby="myModalLabelConsultaIMG">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabelConsultaiMG" style="text-align: center">EVIDENCIA FOTOGRAFICA.</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <asp:UpdatePanel ID="updPanel" runat="server">
                            <ContentTemplate>
                                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                    <!-- Indicators -->
                                    <ol class="carousel-indicators">
                                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                                        <li data-target="#myCarousel" data-slide-to="1" runat="server" id="foto1" visible="false"></li>
                                        <li data-target="#myCarousel" data-slide-to="2" runat="server" id="foto2" visible="false"></li>
                                        <li data-target="#myCarousel" data-slide-to="3" runat="server" id="foto3" visible="false"></li>
                                    </ol>

                                    <!-- Wrapper for slides -->
                                    <div class="carousel-inner">
                                        <div class="item active" runat="server" id="foto11" visible="false">
                                            <asp:Image ID="ImagenEvidencia1" runat="server" CssClass="tamañoImgCarru" />
                                        </div>
                                        <div class="item" runat="server" id="foto22" visible="false">
                                            <asp:Image ID="ImagenEvidencia2" CssClass="tamañoImgCarru" runat="server" />
                                        </div>

                                        <div class="item" runat="server" id="foto33" visible="false">
                                            <asp:Image ID="ImagenEvidencia3" runat="server" CssClass="tamañoImgCarru" />
                                        </div>
                                        <div class="item" runat="server" id="foto34" visible="false">
                                            <asp:Image ID="ImagenEvidencia4" runat="server" CssClass="tamañoImgCarru" />

                                        </div>
                                    </div>

                                    <!-- Left and right controls -->
                                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                                        <span class="glyphicon glyphicon-chevron-left"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                                        <span class="glyphicon glyphicon-chevron-right"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>


                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">

        function AbrirModalFotos() {
            $('#myModalConsultariMG').modal();
            return false;
        }
    </script>
</asp:Content>
