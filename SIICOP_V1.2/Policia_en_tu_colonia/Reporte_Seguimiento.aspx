<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte_Seguimiento.aspx.cs" Inherits="SIICOP_V1._2.Policia_en_tu_colonia.Reporte_Seguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/PoliCss.css" rel="stylesheet" />
    <script src="../Scripts/easyResponsiveTabs.js"></script>
    <style>
        .modal-lg {
            width: 80% !important;
        }

        .pac-container {
            z-index: 1051 !important;
        }
    </style>
    <script src="<%= ResolveUrl("~/Scripts/sweetalert2.all.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function error() {
            swal({
                title: "Error!",
                text: "Problema al guardar el reporte cheque bien los campos",
                icon: "error",
                button: "Aceptar",

            });
            return false
        }



        function Correcto() {
            swal({
                title: "Correcto!",
                text: "El reporte se guardo correctamente",
                icon: "success",
                type: "success"
            }).then(okay => {
                if (okay) {
                    window.location.href = "Reporte_Seguimiento.aspx";
                }
            });

        }
    </script>



    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="contentt">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="numbers">
                                    <h2 style="text-align: center">
                                        <asp:Image runat="server" ID="poli" src="../Imagenes/PinesReporte/Icono-04.png" Width="5%" />&nbsp;&nbsp;<small style="font-size: 1.4em">Formulario de seguimiento</small></h2>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="row">
                    <%--  <div class="col-lg-1 col-md-6 col-sm-6"></div>--%>
                    <%--           <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="info-box info">
                            <a href="#exampleModalLong" data-toggle="modal">
                                <i class="fa fa-map-marker"></i></a>
                            <div class="count">Cuadrantes</div>
                            <div class="title">Agregar Nuevo</div>
                            <div class="desc">Editar, agregar y elimnar cuadrantes</div>
                        </div>
                        <!--/.info-box-->
                    </div>--%>
                    <!--/.col-->

                    <%-- <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="info-box warning">
                            <a href="#exampleModalguar" data-toggle="modal">
                                <i class="fa fa-object-group"></i></a>
                            <div class="count">Enlace</div>
                            <div class="title">Agregar Nuevo</div>
                            <div class="desc">Editar, agregar y elimnar Enlace</div>
                        </div>
                    </div>--%>
                    <!--/.col-->

                    <%--        <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="info-box success">
                            <a href="#exampleModaCCP" data-toggle="modal">
                                <i class="fa fa-users"></i></a>
                            <div class="count">C.C.P</div>
                            <div class="title">Agregar Nuevo</div>
                            <div class="desc">Editar, agregar y elimnar C.C.P</div>
                        </div>
                    </div>--%>
                    <!--/.col-->

                    <div class="col-lg-3 col-md-3 col-sm-6">
                        <div class="info-box danger">
                            <i>
                                <asp:ImageButton ID="imgPeticion" ImageUrl="~/Imagenes/file_add.png" OnClick="imgPeticion_Click" Width="70%" runat="server" ToolTip="Agrear petición" /></i>
                            <div class="count">Petición</div>
                            <div class="title">Agregar Nuevo</div>
                            <div class="desc">Formulario para agregar una nueva petión ciudadana</div>
                        </div>
                        <!--/.info-box-->
                    </div>
                    <!--/.col-->

                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <div class="info-box success" style="text-decoration: none">
                            <asp:LinkButton runat="server" ID="lkbProximidadnuevo" OnClick="lkbProximidad_Click1">
                                <i class="fa fa-users"></i>
                                <div class="count" style="text-decoration: none; color: white">Captura</div>
                                <div class="count" style="text-decoration: none; color: white">proximidad</div>

                                <div class="desc" style="text-decoration: none; color: white">Formulario de registro de reporte</div>

                            </asp:LinkButton>
                        </div>
                    </div>
                    <!--/.col-->
                </div>
                <br />
                <div class="container-fluid">
                    <div class="row">
                        <div class="marketing">
                            <hr class="half">
                            <div class="span12">
                                <div class="well">
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <div class="form-group has-feedback">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                    <asp:TextBox ID="txtFInicialC" runat="server" CssClass="form-control" placeholder="Buscar por Fecha inicial..."></asp:TextBox>
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
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtfechafin" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3" runat="server" id="busquedadescripcion" visible="false">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtbusquedadescripcion" runat="server" placeholder="Descripción.." class="input-sm form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-1" runat="server" id="bsuquedafolio" visible="true">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtfolioBusque" runat="server" placeholder="Folio.." class="input-sm form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="RESPONSA" runat="server">

                                            <div class="col-lg-1">

                                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
                                            </div>

                                        </div>

                                        <div class="col-lg-1" runat="server" id="btnexcelpeticion" visible="true">

                                            <asp:LinkButton ID="lkexcel" runat="server" CssClass="btn btn-success" Style="font-size: 1.8em" Text="EXCEL" title="Exportar" OnClick="lkmapa_Click"><span class="fa fa-file-excel"></span>&nbsp;</asp:LinkButton>
                                        </div>
                                        <div class="col-lg-1" runat="server" id="btnProxi" visible="true">

                                            <asp:LinkButton ID="lkbproximidad" runat="server" CssClass="btn btn-primary" Style="font-size: 1.8em" Text="PROXIMIDAD" title="PROXIMIDAD" OnClick="lkbproximidad_Click"><span class="  fas fa-handshake"></span>&nbsp;</asp:LinkButton>
                                        </div>
                                        <div class="col-lg-1" runat="server" id="btnPetiicon" visible="false">

                                            <asp:LinkButton ID="lkbPeticiones" runat="server" CssClass="btn btn-primary" Style="font-size: 1.8em" Text="Peticiones" title="PETICIONES" OnClick="lkbPeticiones_Click"><span class=" fas fa-clipboard-list"></span>&nbsp;</asp:LinkButton>
                                        </div>


                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="row pull-left">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <h4 runat="server" id="peticionestexto" visible="true"><strong style="font-weight: bold">Captura de datos de peticiones</strong></h4>
                                <h4 runat="server" id="proxitexto" visible="false"><strong style="font-weight: bold">Captura de datos de proximidad</strong></h4>

                            </div>
                        </div>

                    </div>
                    <div class="row pull-right">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:Label ID="lblTotalRegistros" Visible="true" runat="server" CssClass="label label-warning  pull-right" Font-Size="18px" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblTotalRegistrosProximidad" Visible="false" runat="server" CssClass="label label-warning  pull-right" Font-Size="18px" Font-Bold="true"></asp:Label>
                            </div>
                        </div>

                    </div>
                </div>
                <%-- filtros de busqueda --%>

                <div class="row" runat="server" id="grvPetiticoness" visible="true">
                    <asp:GridView ID="gvPeticiones" runat="server" CssClass="table table-striped  table-bordered  table-sm table-responsive"
                        AutoGenerateColumns="False" DataKeyNames="IdCaptura" DataSourceID="edsVistaDePeticiones"
                        CellPadding="3" AllowPaging="True" AllowSorting="True"
                        OnDataBound="gvPeticiones_DataBound" OnRowCommand="gvPeticiones_RowCommand"
                        OnRowDataBound="gvPeticiones_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="NUM.">
                                <ItemTemplate>
                                    <%# (gvPeticiones.PageSize * gvPeticiones.PageIndex) + Container.DisplayIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="Consecuti" HeaderText="No" ReadOnly="True" SortExpression="Consecuti"></asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Folio" SortExpression="Folio">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Folio") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Folio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Capturista" SortExpression="Capturista">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Personalid") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Personales.Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fecha" SortExpression="FechaActual">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FechaCpturaEvento") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToDateTime(Eval("FechaCpturaEvento")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Municipios" SortExpression="IdMunicipio">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("IdMunicipio") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("tcMunicipiosPoliColonia.MunicipioNombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdPrioridad" HeaderText="Prioridad" SortExpression="IdPrioridad" />

                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" />

                            <%--<asp:BoundField DataField="tcEnlaceAreaI.NombreEnlace" HeaderText="Enlace Interno" ReadOnly="True" SortExpression="tcEnlaceAreaI.NombreEnlace"></asp:BoundField>--%>

                            <%--   <asp:TemplateField ShowHeader="TRUE">
                                <ItemTemplate>
                                    <asp:ImageButton ID="LinkButton1" runat="server" CommandName="Select" CausesValidation="False" ImageUrl="~/Content/imagenes/Editar.png" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <%--boton dle reporte--%>


                            <%-- <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnReport" runat="server" ImageUrl="~/Content/imagenes/Oficio.png"  CommandName="Report" CommandArgument='<%# Eval("Folio") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                    <%--    </asp:TemplateField>--%>


                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="Editar" CommandName="Editar" CausesValidation="False" ID="lkbEditar" ToolTip="Editar" CommandArgument='<%# Eval("IdCaptura") %>'>
                                    <i class="fas fa-edit" style="font-size:1.8em"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-2 col-md-3" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownList" runat="server" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" /></h3>
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-primary" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                    <asp:EntityDataSource runat="server" ID="edsVistaDePeticiones" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                        EnableFlattening="False" EntitySetName="tc_PoliciaenTucolonia" Include="tcMunicipiosPoliColonia,Personales" OrderBy="it.[FechaCpturaEvento] desc"
                        Where="(@fInicialC IS NULL OR it.FechaCpturaEvento == @fInicialC) AND (@Folioo IS NULL OR it.Folio == @Folioo)">
                        <WhereParameters>
                            <asp:SessionParameter SessionField="fInicialC" Name="fInicialC" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtfolioBusque" Name="Folioo" PropertyName="Text" Type="Int32" DefaultValue="" ConvertEmptyStringToNull="true" />
                        </WhereParameters>
                    </asp:EntityDataSource>
                </div>


                <div class="row" runat="server" id="GrdPromixi" visible="false">
                    <asp:GridView runat="server" ID="grvProximidad" AutoGenerateColumns="False"
                        CssClass="table table-striped  table-bordered  table-sm table-responsive"
                        DataKeyNames="idResumenDiario" DataSourceID="edsPromixi"
                        OnRowDataBound="grvProximidad_RowDataBound"
                        OnDataBound="grvProximidad_DataBound"
                        OnRowCommand="grvProximidad_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" DataFormatString="{0:dddd-dd-MMMM-yyyy}"></asp:BoundField>
                            <asp:BoundField DataField="Personales.Nombre" HeaderText="Nombre" SortExpression="Personales.Nombre"></asp:BoundField>
                            <asp:BoundField DataField="hora" HeaderText="Hora" SortExpression="hora"></asp:BoundField>
                            <asp:BoundField DataField="AccionesID" HeaderText="Tipo acción" SortExpression="AccionesID"></asp:BoundField>
                            <asp:BoundField DataField="descripcion_actividad" HeaderText="Hechos" SortExpression="descripcion_actividad"></asp:BoundField>
                            <asp:BoundField DataField="personal_atendio_actividad" HeaderText="Oficiales" SortExpression="personal_atendio_actividad"></asp:BoundField>
                            <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                            <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                            <asp:BoundField DataField="total_atendidos" HeaderText="Total" SortExpression="total_atendidos"></asp:BoundField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="Editar" CommandName="Editar" CausesValidation="False" ID="lkbEditar" ToolTip="Editar" CommandArgument='<%# Eval("idResumenDiario") %>'>
                                    <i class="fas fa-edit" style="font-size:1.8em"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div class="row" style="margin-top: 20px;">
                                <div class="col-lg-1" style="text-align: right;">
                                    <h5>
                                        <asp:Label ID="MessageLabel" Text="Pág." runat="server" /></h5>
                                </div>
                                <div class="col-lg-2 col-md-3" style="text-align: left;">
                                    <asp:DropDownList ID="PageDropDownListProxi" runat="server" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownListProxi_SelectedIndexChanged" /></h3>
                                </div>
                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="CurrentPageLabelproxi" runat="server" CssClass="label label-primary" /></h3>
                                </div>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                    <asp:EntityDataSource runat="server" ID="edsPromixi" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                        EnableFlattening="False" EntitySetName="tb_Reporte_Diario" Where="it.programasID==15" Include="Personales">
                    </asp:EntityDataSource>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
    </div>




    <div class="modal fade bd-example-modal-lg" id="myModalImgArchivos" tabindex="-1" role="dialog" aria-labelledby="myModalImgArchivo"
        data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalImgArchivoss" style="text-align: center">Registro de seguimiento</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <asp:UpdatePanel ID="MODELO" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <div id="datoscap">
                                        <div class="row">

                                            <h2 class="center standart-h2title "><span class="large-text"><span class="main-color">Datos Generales </span></span>
                                            </h2>
                                            &nbsp;<div class="col-md-1">
                                                <asp:TextBox runat="server" ID="foliorest" disabled="disabled" CssClass=" form-control" ForeColor="red" Text="0"></asp:TextBox>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="row">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Municipios</label>
                                                    <div class="input-group input-group-md">
                                                        <asp:DropDownList ID="ddlMunicipio" runat="server" class="form-control" AutoPostBack="true" DataSourceID="edasMuni" DataTextField="MunicipioNombre" DataValueField="IdMunicipio"
                                                            OnDataBound="ddlMunicipio_DataBound">
                                                        </asp:DropDownList>
                                                        <asp:EntityDataSource runat="server" ID="edasMuni" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="tcMunicipiosPoliColonia" EntityTypeFilter="tcMunicipiosPoliColonia"></asp:EntityDataSource>
                                                        <span class="input-group-addon" id="MuniREVI" runat="server" visible="false">
                                                            <span id="MunIicono" runat="server" class=""></span>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <%-- <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Tipo de Enlace</label>
                                                    <asp:DropDownList ID="ddlTipoEnlacee" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-garroup">
                                                    <label for="ejemplo_email_1">Enlace Area</label>
                                                    <asp:DropDownList ID="ddlEnlacearea" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>

                                                </div>
                                            </div>--%>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Prioridad de la peticion</label>
                                                    <asp:DropDownList ID="ddlPrioridaD" runat="server" class="form-control">
                                                        <asp:ListItem Text="-SELECCIONE POR FAVOR-" Value="0" />
                                                        <asp:ListItem Value="1">Inmediata</asp:ListItem>
                                                        <asp:ListItem Value="2">Medio</asp:ListItem>
                                                        <asp:ListItem Value="3">Baja</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Estatus de la peticion</label>
                                                    <div class="input-group input-group-md">
                                                        <asp:DropDownList ID="ddlEstatus" runat="server" class="form-control">
                                                            <asp:ListItem Text="-SELECCIONE POR FAVOR-" Value="0" />
                                                            <asp:ListItem Value="Inicio">Inicio</asp:ListItem>
                                                            <asp:ListItem Value="En Proceso">En Proceso</asp:ListItem>
                                                            <asp:ListItem Value="Finalizada">Finalizada</asp:ListItem>
                                                            <asp:ListItem Value="Cancelada">Cancelada</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">
                                            <%--   <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Nombre enlace</label>
                                                    <asp:DropDownList ID="ddlexternoDatos" runat="server" class="form-control" AutoPostBack="true">
                                                    </asp:DropDownList>

                                                </div>
                                                <asp:Label runat="server" ID="lblNombre" Visible="false"></asp:Label>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Correo del enlace</label>
                                                    <div class="input-group input-group-md">
                                                        <span class="input-group-addon" id="sizing-addon1">@</span>

                                                        <asp:DropDownList ID="ddlCOrreoExt" AutoPostBack="true" runat="server" class="form-control"></asp:DropDownList>

                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <div id="datosFormylario">
                                        <br />
                                        <div class="row">

                                            <h2 class="center standart-h2title "><span class="large-text"><span class="main-color">Datos de  la petición</span></span>
                                            </h2>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-5">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Nombre del ciudadano</label>
                                                    <asp:TextBox ID="txtNombreCIudadano" runat="server" class="form-control" placeholder="Nombre del ciudadano"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="col-md-1">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Edad</label>
                                                    <asp:TextBox ID="txtEdad" runat="server" class="form-control" MaxLength="2" placeholder="Edad"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-1">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Sexo</label>
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rbFemenino" runat="server" name="sexo" readonly="readonly" value="true" GroupName="Genero" />Femenino
                                                        </label>
                                                    </div>
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rbMasculino" runat="server" name="sexo" readonly="readonly" value="false" GroupName="Genero" />Masculino
                                                        </label>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group">
                                                    <label for="ejemplo_email_1">Cuadrante</label>
                                                    <asp:DropDownList ID="ddlCuadrante" runat="server" class="form-control" DataSourceID="edscuadrante" DataTextField="CuadranteNombre" DataValueField="IdCuadrante"
                                                        OnDataBound="ddlCuadrante_DataBound" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:EntityDataSource runat="server" ID="edscuadrante" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                                                        EnableFlattening="False" EntitySetName="tcCuadrantes" EntityTypeFilter="" Select="" Where="" AutoGenerateWhereClause="True">
                                                        <WhereParameters>
                                                            <asp:ControlParameter ControlID="ddlMunicipio" DbType="Int32" Name="IdMunicipio" PropertyName="SelectedValue" DefaultValue="" />
                                                        </WhereParameters>
                                                    </asp:EntityDataSource>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="form-group">
                                                                <label for="ejemplo_email_1">Colonia</label>
                                                                <asp:DropDownList runat="server" ID="ddlColonia" DataSourceID="edsColonia" DataTextField="NombreColonia" DataValueField="ColoniasId"
                                                                    CssClass="form-control" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:EntityDataSource runat="server" ID="edsColonia" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                                                                    EnableFlattening="False" EntitySetName="tcPoliciaColonias" AutoGenerateWhereClause="True">
                                                                    <WhereParameters>
                                                                        <asp:ControlParameter ControlID="ddlCuadrante" DbType="Int32" Name="IdCuadrante" PropertyName="SelectedValue" DefaultValue="" />
                                                                    </WhereParameters>
                                                                </asp:EntityDataSource>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="row" id="callecolor" runat="server">
                                                            <div class="form-group">
                                                                <label for="ejemplo_email_1">Calle</label>
                                                                <asp:TextBox ID="txtCalle" runat="server" class="form-control" placeholder="Calle"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="form-group">
                                                                <label for="ejemplo_email_1">Referencia</label>
                                                                <asp:TextBox ID="txtReferencia" runat="server" class="form-control" placeholder="Referencia"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="form-group">
                                                            <label for="ejemplo_email_1">Fecha</label>
                                                            <div class='input-group ' id='date3'>
                                                                <asp:TextBox ID="txtFechaDenunciaDato" runat="server" CssClass="form-control" placeholder="Dia/ Mes/ Año"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDenunciaDato" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                                <span class="input-group-addon">
                                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="form-group">
                                                            <label for="ejemplo_email_1">Telefono</label>
                                                            <asp:TextBox ID="txtTelefono" runat="server" class="form-control" MaxLength="14" placeholder="Telefono..."></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="form-group">
                                                            <label for="ejemplo_email_1">Correo</label>
                                                            <div class="input-group input-group-md">
                                                                <span class="input-group-addon" id="iconoarrobaCorreoCiudadano" runat="server">@</span>
                                                                <asp:TextBox ID="txtCorreoCiudadano" runat="server" class="form-control" placeholder="Correo"></asp:TextBox>
                                                                <span class="input-group-addon" id="correociudadano" runat="server" visible="false">
                                                                    <span id="afirma" runat="server" class=""></span>
                                                                </span>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>



                                        </div>


                                        <br />
                                    </div>
                                </div>
                                <div class="col-md-1"></div>

                            </div>

                            <!--Vertical Tab-->
                            <div class="row">
                                <div class="col-md-12">
                                    <h1 style="font-size: 2.3em; text-align: center">¿Qué problematica (s) identifica en su colonia?</h1>
                                </div>

                            </div>
                            <div id="parentVerticalTab">
                                <ul class="resp-tabs-list hor_1">
                                    <li>Seguridad</li>
                                    <li>Vialidad</li>
                                    <li>Municipales</li>
                                    <li>Percepción de seguridad ciudadana</li>
                                    <li>Programas de la Dirección de Vinculación Institucional</li>
                                </ul>
                                <div class="resp-tabs-container hor_1">
                                    <div>
                                        <div id="seguridad">
                                            <div class="row">
                                                <div class="col-lg-4"></div>
                                                <div class="col-lg-2">

                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rdAplicaSEGU" runat="server" name="seguridad" value="true" GroupName="Seguri" Font-Size="1.8em" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                            Si Apica
         
                                                        </label>
                                                    </div>

                                                </div>

                                                <div class="col-lg-2">

                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rdNoapliSEGU" runat="server" name="seguridad" value="false" GroupName="Seguri" Font-Size="1.8em" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-remove-circle"></i></span>
                                                            No aplixa
                                                        </label>
                                                    </div>

                                                </div>
                                                <div class="col-lg-4"></div>
                                            </div>
                                            <div id="datosSeguridad" runat="server">
                                                <h2 style="font-size: 1.3em; text-align: center">Marca &nbsp;<code><span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span></code>&nbsp;las problematicas que identifiques tu colonia</h2>
                                                <hr />
                                                <div class="row">
                                                    <div class="control-group">
                                                        <div class="col-md-4">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="robo" runat="server" value="" />
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    ROBO
         
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="homicidios" runat="server" value="" />
                                                                    <%--<input type="checkbox" value="" runat="server" id="homicidios">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    HOMICIDIOS
         
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="consumos" runat="server" value="" />
                                                                    <%-- <input type="checkbox" value="" runat="server" id="consumos">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    CONSUMO DE ALCOHOL EN LAS CALLES 
         
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="col-sm-12">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="pandillerismo" runat="server" value="" />
                                                                    <%-- <input type="checkbox" value="" runat="server" id="pandillerismo">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    PANDILLERISMO
         
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="grafiti" runat="server" value="" />
                                                                    <%-- <input type="checkbox" value="" runat="server" id="grafiti">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    GRAFITIS
         
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="narcomenudeo" runat="server" value="" />
                                                                    <%--<input type="checkbox" value="" runat="server" id="narcomenudeo">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    NARCO MENUDEO
         
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="col-sm-12">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="cristalazo" runat="server" value="" />
                                                                    <%--<input type="checkbox" value="" runat="server" id="cristalazo">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    CRISTALAZOS
         
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="conflictosvecinales" runat="server" value="" />
                                                                    <%--<input type="checkbox" value="" runat="server" id="conflictosvecinales">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    CONFLICTOS VECINALES
         
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="conflictosescuelass" runat="server" value="" />
                                                                    <%--  <input type="checkbox" value="" runat="server" id="recorridos">--%>
                                                                    <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                    CONFLITOS AL REDOR DE LA ESCUELA
         
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-1"></div>
                                                    <div class="col-md-10">
                                                        <asp:TextBox runat="server" ID="txtEspecifiqueSeguridad" CssClass="form-control" TextMode="MultiLine" placeholder="Especifique:"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1"></div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-1"></div>
                                                    <div class="col-md-10">
                                                        <asp:TextBox runat="server" ID="txtubicacionsegur" CssClass="form-control" TextMode="MultiLine" placeholder="Ubicación:"></asp:TextBox>
                                                    </div>
                                                    <div class="col-md-1"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div id="vl">
                                            <div class="row">
                                                <div class="col-lg-4"></div>
                                                <div class="col-lg-2">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rdbVialiapli" runat="server" name="vialidad" value="true" GroupName="viali" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                            Apica
         
                                                        </label>
                                                    </div>

                                                </div>

                                                <div class="col-lg-2">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rdbvialiNoapli" runat="server" name="vialidad" value="false" GroupName="viali" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                            No aplixa
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4"></div>
                                            </div>
                                            <h2 style="font-size: 1.3em; text-align: center">Marca &nbsp;<code><span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span></code>&nbsp;las problematicas que identifiques tu colonia</h2>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="autosmace" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="autosmace">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                AUTOS MACETAS
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="reductores" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="reductores">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                FALTA DE REDUCTORES DE VIALIDAD
         
                                                            </label>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="autosdobles" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="autosdobles">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                AUTOS EN DOBLE CARRIL
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="convehi" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="baches">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                CONGESTIÓN VEHICULAR
         
                                                            </label>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="faltadeseñales" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="faltadeseñales">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                FALTA DE SEÑALIZACIONES VIALES
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="otro" runat="server" value="" />
                                                                <%--<input type="checkbox" value="" runat="server" id="otro">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                OTROS
         
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <br />
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-10">
                                                    <asp:TextBox runat="server" ID="txtespecifiqueVialidad" CssClass="form-control" TextMode="MultiLine" placeholder="Especifique:"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-10">
                                                    <asp:TextBox runat="server" ID="txtUbicacionVialidad" CssClass="form-control" TextMode="MultiLine" placeholder="Ubicación:"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </div>

                                    </div>
                                    <div>
                                        <div id="muni">
                                            <div class="row">
                                                <div class="col-lg-4"></div>
                                                <div class="col-lg-2">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rdbAplicaMuni" runat="server" name="municipal" value="true" GroupName="muni" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                            Apica
         
                                                        </label>
                                                    </div>

                                                </div>

                                                <div class="col-lg-2">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rdbNoapliMuni" runat="server" name="municipal" value="false" GroupName="muni" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                            No aplixa
                                                        </label>
                                                    </div>
                                                </div>
                                                <div class="col-lg-4"></div>
                                            </div>
                                            <h2 style="font-size: 1.3em; text-align: center">Marca &nbsp;<code><span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span></code>&nbsp;las problematicas que identifiques tu colonia</h2>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="limpiapublica" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="limpiapublica">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                LIMPIA PÚBLICA DEFICIENTE
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="alumbradoi" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="alumbradoi">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                FALTA DE ALUMBRADO PÚBLICO
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="parques" runat="server" value="" />
                                                                <%--  <input type="checkbox" value="" runat="server" id="parques">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                PARQUES Y JARDINES DEN DETERIODO
         
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="drenaje" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="drenaje">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                DRENAJE EXPUESTO
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="animales" runat="server" value="" />
                                                                <%--<input type="checkbox" value="" runat="server" id="animales">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                ANIMALES CALLEJEROS
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="abulantaje" runat="server" value="" />
                                                                <%--  <input type="checkbox" value="" runat="server" id="abulantaje">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                AMBULANTAJE
         
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="fugaAgua" runat="server" value="" />
                                                                <%--  <input type="checkbox" value="" runat="server" id="fugaAgua">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                FUGA DE AGUA POTABLE
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="coladeras" runat="server" value="" />
                                                                <%--<input type="checkbox" value="" runat="server" id="coladeras">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                COLADERAS TAPADAS
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="montemaleza" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="montemaleza">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                MONTE/MALEZA
         
                                                            </label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />

                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-10">
                                                    <asp:TextBox runat="server" ID="txtEspecifiqueMuni" CssClass="form-control" TextMode="MultiLine" placeholder="Especifique:"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-10">
                                                    <asp:TextBox runat="server" ID="txtUbicacionMuni" CssClass="form-control" TextMode="MultiLine" placeholder="Ubicación:"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div id="percepcionseguridad">
                                            <h2 style="font-size: 1.3em; text-align: center">Marca con &nbsp;<code><span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span></code>&nbsp;"si aplica", en terminos de delincuencia considera que vivir en su colonia es....</h2>
                                            <hr />
                                            <div class="row">
                                                <div class="control-group">
                                                    <div class="col-md-3"></div>
                                                    <div class="col-md-2">
                                                        <div class="radio">
                                                            <label>
                                                                <asp:RadioButton ID="rbseguro" runat="server" name="seguro" value="1" GroupName="segu" />
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                                Seguro
         
                                                            </label>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="radio">
                                                            <label>
                                                                <asp:RadioButton ID="rbinseguro" runat="server" name="seguro" value="2" GroupName="segu" />
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                                Inseguro
         
                                                            </label>
                                                        </div>


                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="radio">
                                                            <label>
                                                                <asp:RadioButton ID="rbnoseguro" runat="server" name="seguro" value="3" GroupName="segu" />
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                                No seguro
         
                                                            </label>
                                                        </div>


                                                    </div>


                                                    <div class="col-md-3"></div>
                                                </div>
                                                <hr />

                                                <h2 style="font-size: 1.3em; text-align: center">Entermino de delincuencia usted se siente seguro o inseguro marca con <span>"1" Seguro</span>, <span>"2" Inseguro</span>, "3" No sabe</h2>


                                                <hr />
                                                <div class="row">
                                                    <div class="form-horizontal" role="form">
                                                        <div class="col-md-1"></div>
                                                        <div class="col-md-10">
                                                            <div class="row">

                                                                <div class="form-group">
                                                                    <label class="control-label col-sm-2">Su casa</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtCasaseuri" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">La escuela</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtEscuela" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">Transporte Publico</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txttrasporte" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">Centro comercial</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtcentro" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="form-group">
                                                                    <label class="control-label col-sm-2">Parque o centro recreativo</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtparque" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">Su trabajo</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txttrabajo" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">La calle</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtcalleseguri" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">Bnaco</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtbanco" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="form-group">
                                                                    <label class="control-label col-sm-2">Automóvil</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtauto" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">Cajero automatico</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtcajero" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">Carretera</label>
                                                                    <div class="col-md-1">
                                                                        <asp:TextBox ID="txtcarretera" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="row">

                                                                <div class="form-group">
                                                                    <label class="control-label col-sm-5">¿Se han organizado los vecinos para autoprotegerse o resolver problemas de esta zona?</label>
                                                                    <div class="col-md-1">
                                                                        <div class="form-group">
                                                                            <div class="radio">
                                                                                <label>
                                                                                    <asp:RadioButton ID="rbproblesi" runat="server" name="veci" value="true" AutoPostBack="false" GroupName="vecino" />SI
                                                                                </label>
                                                                            </div>
                                                                            <div class="radio">
                                                                                <label>
                                                                                    <asp:RadioButton ID="rbprobleno" runat="server" name="veci" value="false" AutoPostBack="FALSE" GroupName="vecino" />NO
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="form-group">
                                                                    <label class="control-label col-sm-5">¿Usted o alguine de su familia ha sido victima de la delincuencia?</label>
                                                                    <div class="col-md-2">
                                                                        <div class="form-group">
                                                                            <div class="radio">
                                                                                <label>
                                                                                    <asp:RadioButton ID="rbVictimasi" runat="server" name="sexo" value="true" AutoPostBack="false" GroupName="victima" />SI
                                                                                </label>
                                                                            </div>
                                                                            <div class="radio">
                                                                                <label>
                                                                                    <asp:RadioButton ID="rbVictimano" runat="server" name="sexo" value="false" AutoPostBack="FALSE" GroupName="victima" />NO
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <label class="control-label col-sm-2">Año</label>
                                                                    <div class="col-md-2">
                                                                        <asp:TextBox runat="server" ID="txtanodeli" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="form-group">
                                                                    <label class="control-label col-sm-5">¿Cual fue su delito?</label>
                                                                    <div class="col-md-4">
                                                                        <asp:TextBox runat="server" ID="txtcualfuedelito" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-1"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div id="programadvi">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label class="control-label col-sm-12">¿Usted conoce los progranmas de la Dirección de Vinculación Istitucional?</label>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rbprogrmadgviSI" runat="server" name="PRO" value="true" AutoPostBack="false" GroupName="PROGRAMADGVI" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                            SI
         
                                                        </label>
                                                    </div>

                                                </div>

                                                <div class="col-lg-2">
                                                    <div class="radio">
                                                        <label>
                                                            <asp:RadioButton ID="rbprogrmadgviNO" runat="server" name="PRO" value="false" AutoPostBack="FALSE" GroupName="PROGRAMADGVI" />
                                                            <span class="cr"><i class="cr-icon glyphicon glyphicon-ok-sign"></i></span>
                                                            NO
                                                        </label>
                                                    </div>
                                                </div>


                                            </div>

                                            <h2 style="font-size: 1.3em; text-align: center">Marca &nbsp;<code><span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span></code>&nbsp;si conoces algun programa</h2>
                                            <hr />
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkescuelasegu" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="autosmace">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                Escuela Segura
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkredesveci" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="reductores">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                Redes Vecinales
                                                            </label>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkdeportivocultu" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="autosdobles">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                Fomento deportivo y cultural
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkciolenciamujer" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="baches">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                Prevencion de la Violencia contra la mujer
         
                                                            </label>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-sm-12">
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chkempresarial" runat="server" value="" />
                                                                <%-- <input type="checkbox" value="" runat="server" id="faltadeseñales">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                Empresa segura
         
                                                            </label>
                                                        </div>
                                                        <div class="checkbox">
                                                            <label>
                                                                <asp:CheckBox ID="chklimpiezapubli" runat="server" value="" />
                                                                <%--<input type="checkbox" value="" runat="server" id="aceras">--%>
                                                                <span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span>
                                                                Limpieza de espacios públicos
                                                            </label>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="control-group">
                                                    <label class="control-label col-md-10">¿Cuáles son o cuales le gustará conocer?(mencionar fecha,hora,lugar,tel, para agendar)</label>

                                                    <div class="col-md-10">
                                                        <asp:TextBox runat="server" ID="txtcualessonculeslesguataria" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="nested-tabInfo2">
                                Selected tab: <span class="tabName"></span>
                            </div>


                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <h1 style="font-size: 2.3em; text-align: center">Observaciones y/o propuestas del ciudadano</h1>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="txtpeticion" CssClass="form-control" TextMode="MultiLine" placeholder="Redacte su petición"></asp:TextBox>

                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-2"></div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="ejemplo_email_1">Nombre oficial 1</label>
                                                <asp:TextBox ID="txtOficialuno" class="form-control" runat="server" placeholder="Nombre oficial 1..."></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="ejemplo_email_1">Distintivo oficial 1</label>
                                                <asp:TextBox ID="txtdisitntivoOfiuno" class="form-control" runat="server" placeholder="Distintivo oficial 1..."></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2"></div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2"></div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="ejemplo_email_1">Nombre ofcial 2</label>
                                                <asp:TextBox ID="txtOficialdos" class="form-control" runat="server" placeholder="Nombre ofcial 2..."></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="ejemplo_email_1">Distitivo oficial 2</label>
                                                <asp:TextBox ID="txtdisitintivoOfi2" class="form-control" runat="server" placeholder="Distitivo oficial 2..."></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-2"></div>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                        </div>
                        <br />
                        <div class="modal-footer">
                            <div class="row">
                                <div class="col-md-4">
                                    <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>--%>
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                </div>
                                <div class="col-md-4">
                                    <%--<asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />--%>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="IbtnGuardar" runat="server" class="btn btn-success" Text="Guardar" OnClick="IbtnGuardar_Click" />
                                </div>

                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


    <div class="modal fade bd-example-modal-lg" id="myModaLProximidad" tabindex="-1" role="dialog" aria-labelledby="myModalImgArchivo" data-backdrop="static" data-keyboard="false" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalProximidad" style="text-align: center">Registro de proximidad</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-2">
                                <label>Fecha</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtfecxhaven" runat="server" TextMode="Date" placeholder="Fecha" class="input-sm form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <label>Tipo de captura</label>
                                <div class="form-group">
                                    <asp:DropDownList runat="server" ID="ddltipoaccion" CssClass=" form-control">
                                        <asp:ListItem Text="-SELECCIONE POR FAVOR-" Value="0" />
                                        <asp:ListItem Value="1">Interacciones</asp:ListItem>
                                        <asp:ListItem Value="2">Detenciones</asp:ListItem>
                                        <asp:ListItem Value="3">Revisiones</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Hora </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txthora" runat="server" placeholder="Hora" class="input-sm form-control"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Unidad del cuadrante </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUnidad" runat="server" placeholder="Unidad de despliegue " class="input-sm form-control"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <label class="col-md-9 control-label">Buscar la dirección</label>
                                            <div class="label">
                                                <input id="autocomplete" class="form-control" style="width: 100% !important" placeholder="Ingresa la dirección" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <label class="col-md-6">Calle</label>
                                            <input class="form-control" id="route" type="text" runat="server" clientidmode="Static" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group form-group-sm">
                                            <label class="col-md-11 control-label">Coordenadas </label>
                                            <div class="wideField" colspan="2">
                                                <input class="field form-control" type="text" id="latlng" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="col-md-6">Latitud</label>
                                            <div class="wideField" colspan="2">

                                                <input class="field form-control" runat="server" type="text" id="lati" />

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group form-group-sm">
                                            <label class="col-md-3 control-label">Longitud</label>
                                            <div class="wideField" colspan="2">
                                                <input class="field form-control" type="text" id="longi" runat="server" />

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <asp:UpdatePanel runat="server" ID="updCuadrantes">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Municipio</label>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="ddlmuniproxi" runat="server" class="form-control" AutoPostBack="true" DataSourceID="edsMuniproxi" DataTextField="MunicipioNombre" DataValueField="IdMunicipio"
                                                        OnDataBound="ddlMunicipio_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:EntityDataSource runat="server" ID="edsMuniproxi" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="tcMunicipiosPoliColonia" EntityTypeFilter="tcMunicipiosPoliColonia"></asp:EntityDataSource>
                                                    <span class="input-group-addon" id="Span1" runat="server" visible="false">
                                                        <span id="Span2" runat="server" class=""></span>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <label>cuadrante</label>
                                                <div class="form-group">
                                                    <asp:DropDownList ID="ddlcuadranteproxi" runat="server" class="form-control" DataSourceID="edscuadranteproxi" DataTextField="CuadranteNombre" DataValueField="IdCuadrante"
                                                        OnDataBound="ddlCuadrante_DataBound" >
                                                    </asp:DropDownList>
                                                    <asp:EntityDataSource runat="server" ID="edscuadranteproxi" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                                                        EnableFlattening="False" EntitySetName="tcCuadrantes" EntityTypeFilter="" Select="" Where="" AutoGenerateWhereClause="True">
                                                        <WhereParameters>
                                                            <asp:ControlParameter ControlID="ddlmuniproxi" DbType="Int32" Name="IdMunicipio" PropertyName="SelectedValue" DefaultValue="" />
                                                        </WhereParameters>
                                                    </asp:EntityDataSource>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <label>Colonia</label>
                                                <div class="form-group">
                                                    <asp:DropDownList runat="server" ID="ddlcoloniacuadrante" DataSourceID="dsccoloniacuadrante" DataTextField="NombreColonia" DataValueField="ColoniasId"
                                                        CssClass="form-control" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:EntityDataSource runat="server" ID="dsccoloniacuadrante" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                                                        EnableFlattening="False" EntitySetName="tcPoliciaColonias" AutoGenerateWhereClause="True">
                                                        <WhereParameters>
                                                            <asp:ControlParameter ControlID="ddlcuadranteproxi" DbType="Int32" Name="IdCuadrante" PropertyName="SelectedValue" DefaultValue="" />
                                                        </WhereParameters>
                                                    </asp:EntityDataSource>
                                                </div>
                                            </div>

                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="col-md-8">
                                <div class="row">
                                    <script type="text/javascript">
                                        // This example displays an address form, using the autocomplete feature
                                        // of the Google Places API to help users fill in the information.
                                        var dir = "";
                                        var placeSearch, autocomplete;
                                        var componentForm = {
                                            street_number: 'short_name',
                                            colony: 'long_name',
                                            route: 'long_name',
                                            locality: 'long_name',
                                            administrative_area_level_1: 'short_name',
                                            country: 'long_name',
                                            postal_code: 'short_name'

                                        };
                                        var marcadorClicMapa;


                                        function initMap() {
                                            var map = new google.maps.Map(document.getElementById('map'), {
                                                center: { lat: 19.145168196205297, lng: -96.1248779296875 },
                                                zoom: 10,

                                            });

                                            var input = /** @type {!HTMLInputElement} */(
                                                document.getElementById('autocomplete'));


                                            var autocomplete = new google.maps.places.Autocomplete(input);
                                            autocomplete.bindTo('bounds', map);

                                            var infowindow = new google.maps.InfoWindow();
                                            var marker = new google.maps.Marker({
                                                map: map,

                                                anchorPoint: new google.maps.Point(0, -29)
                                            });

                                            autocomplete.addListener('place_changed', function () {
                                                infowindow.close();
                                                marker.setVisible(false);
                                                var place = autocomplete.getPlace();
                                                if (!place.geometry) {
                                                    // User entered the name of a Place that was not suggested and
                                                    // pressed the Enter key, or the Place Details request failed.
                                                    window.alert("No details available for input: '" + place.name + "'");
                                                    return;
                                                }

                                                // If the place has a geometry, then present it on a map.
                                                if (place.geometry.viewport) {
                                                    map.fitBounds(place.geometry.viewport);
                                                } else {
                                                    map.setCenter(place.geometry.location);
                                                    map.setZoom(17);  // Why 17? Because it looks good.
                                                }
                                                marker.setIcon(/** @type {google.maps.Icon} */({
                                                    url: place.icon,
                                                    size: new google.maps.Size(71, 71),
                                                    origin: new google.maps.Point(0, 0),
                                                    anchor: new google.maps.Point(17, 34),
                                                    scaledSize: new google.maps.Size(35, 35)
                                                }));
                                                marker.setPosition(place.geometry.location);
                                                marker.setVisible(true);



                                                document.getElementById('latlng').value = place.geometry.location;
                                                var dir = document.getElementById('autocomplete').value;



                                                coordenada = place.geometry.location;
                                                coordenada = coordenada.toString();
                                                arregloDeSubCadenas = separarCoord(coordenada);
                                                //se cambio de esta manera por que asi es como le puedes poner un runat server
                                                //document.getElementById(component).value = '';
                                                $("[id*='" + 'lati' + "']").val(arregloDeSubCadenas[0]);
                                                $("[id*='" + 'lati' + "']").removeAttr('disabled');
                                                console.log("--cuarta ENCUENTRO = " + 'lati' + arregloDeSubCadenas[0]);



                                                //se cambio de esta manera por que asi es como le puedes poner un runat server
                                                //document.getElementById('longi').value = arregloDeSubCadenas[1];
                                                $("[id*='" + 'longi' + "']").val(arregloDeSubCadenas[1]);
                                                $("[id*='" + 'longi' + "']").removeAttr('disabled');
                                                console.log("--quinto ENCUENTRO = " + 'longi' + arregloDeSubCadenas[1]);


                                                var address = '';
                                                if (place.address_components) {
                                                    address = [
                                                        (place.address_components[0] && place.address_components[0].short_name || ''),
                                                        (place.address_components[1] && place.address_components[1].short_name || ''),
                                                        (place.address_components[2] && place.address_components[2].short_name || '')
                                                    ].join(' ');

                                                }

                                                infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
                                                infowindow.open(map, marker);



                                                //document.getElementById('txtdireccomple').value = dir;
                                                //alert(document.getElementById('txtdireccomple').value);
                                                //$("[id*='" + 'txtdireccomple' + "']").val(dir);
                                                $("[id*='" + 'txtdireccomple' + "']").removeAttr('disabled');
                                                //console.log("--primer ENCUENTRO = " + 'txtdireccomple' + dir);


                                                var array = dir.split(',');
                                                document.getElementById('route').value = array[0];
                                                $("[id*='" + 'route' + "']").val(array[0]);
                                                $("[id*='" + 'route' + "']").removeAttr('disabled');
                                                console.log("--segundo ENCUENTRO = " + 'route' + array[0]);

                                                document.getElementById('colony').value = array[1];
                                                $("[id*='" + 'colony' + "']").val(array[1]);
                                                $("[id*='" + 'colony' + "']").removeAttr('disabled');
                                                console.log("--TERCER ENCUENTRO = " + 'colony' + array[1]);

                                                document.getElementById('locality').value = array[2];
                                                $("[id*='" + 'locality' + "']").val(array[2]);
                                                $("[id*='" + 'locality' + "']").removeAttr('disabled');
                                                console.log("--cuarto ENCUENTRO = " + 'locality' + array[2]);

                                                document.getElementById('administrative_area_level_1').value = array[3];
                                                $("[id*='" + 'administrative_area_level_1' + "']").val(array[3]);
                                                $("[id*='" + 'administrative_area_level_1' + "']").removeAttr('disabled');
                                                console.log("--se ENCUENTRO = " + 'administrative_area_level_1' + array[3]);
                                            });
                                            google.maps.event.addListener(map, "click", function (event) {
                                                var geocoder = new google.maps.Geocoder;
                                                geocoder.geocode({ 'location': event.latLng }, function (results, status) {
                                                    if (status === google.maps.GeocoderStatus.OK) {

                                                        if (results[1]) {
                                                            if (marcadorClicMapa != null)
                                                                marcadorClicMapa.setMap(null);
                                                            marcadorClicMapa = new google.maps.Marker({
                                                                position: event.latLng,
                                                                map: map,
                                                                title: 'Punto Seleccionado'

                                                            });
                                                            var infowindow = new google.maps.InfoWindow({
                                                                content: results[0].formatted_address,
                                                                maxWidth: 200
                                                            });
                                                            console.log("lating" + event.latLng);
                                                            coordenadaXpunto = event.latLng;
                                                            coordenadaXpunto = coordenadaXpunto.toString();
                                                            arregloDeSubCadenasXpunto = separarCoord(coordenadaXpunto);

                                                            $("[id*='" + 'lati' + "']").val(arregloDeSubCadenasXpunto[0]);
                                                            $("[id*='" + 'lati' + "']").removeAttr('disabled');

                                                            $("[id*='" + 'longi' + "']").val(arregloDeSubCadenasXpunto[1]);
                                                            $("[id*='" + 'longi' + "']").removeAttr('disabled');


                                                            console.log("geo" + results[0].formatted_address);
                                                            var direcMarker = results[0].formatted_address;
                                                            var arrayDireccion = direcMarker.split(',');
                                                            document.getElementById('route').value = arrayDireccion[0];
                                                            $("[id*='" + 'route' + "']").val(arrayDireccion[0]);
                                                            $("[id*='" + 'route' + "']").removeAttr('disabled');


                                                            document.getElementById('colony').value = arrayDireccion[1];
                                                            $("[id*='" + 'colony' + "']").val(arrayDireccion[1]);
                                                            $("[id*='" + 'colony' + "']").removeAttr('disabled');




                                                            marcadorClicMapa.metadata = { "txt": results[0].formatted_address };
                                                            infowindow.open(map, marcadorClicMapa);
                                                            marcadorClicMapa.addListener('click', function () {
                                                                infowindow.open(map, marcadorClicMapa);
                                                            });
                                                        } else {
                                                            //alert('No results found');
                                                        }
                                                    } else {
                                                        //alert('Geocoder failed due to: ' + status);
                                                    }
                                                });
                                            }); //end addListener
                                        }

                                        function separarCoord(str) {
                                            str = str.replace("(", "");
                                            str = str.replace(")", "");
                                            str = str.replace(" ", "");
                                            str = str.split(",");

                                            return str;
                                        }
                                    </script>

                                    <%--termina--%>
                                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBtMOICdi8PuJCFk_vxF0EH4fxRI-hzlNw&libraries=places&callback=initMap" async defer></script>
                                    <div id="map" style="height: 450px; width: 750px"></div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Descripción</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtdescripcionporxi" runat="server" TextMode="MultiLine" placeholder="Descripción" class="input-sm form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Oficiales participantes</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtoficialesproxi" runat="server" TextMode="MultiLine" placeholder="Oficiales" class="input-sm form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <div class="container">
                                            <div class="span9">
                                                <div class="form-horizontal">
                                                    <div class="row">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-2 control-label">Adolecentes Hombres</label>
                                                            <div class="col-md-2">
                                                                <div class='input-group date' id='TotaldeAHombresatendidos'>
                                                                    <asp:TextBox ID="txtadoleH" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtadoleH_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                                                                    <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                    <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-2 control-label">Adolescentes Mujeres</label>
                                                            <div class="col-md-2">
                                                                <div class='input-group date' id='TotaldeaAMujeresatendidos'>
                                                                    <asp:TextBox ID="txtadolM" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtadolM_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                                                                    <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                    <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-2 control-label">Hombres</label>
                                                            <div class="col-md-2">
                                                                <div class='input-group date' id='TotaldeHombresatendidos'>
                                                                    <asp:TextBox ID="txttotlaHombres" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txttotlaHombres_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                                                                    <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                    <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-2 control-label">Mujeres</label>
                                                            <div class="col-md-2">
                                                                <div class='input-group date' id='TotaldeMujeresatendidos'>
                                                                    <asp:TextBox ID="txtmujer" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtmujer_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
                                                                    <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                    <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />

                                                </div>
                                            </div>
                                        </div>
                                        <br />

                                        <div class="container">
                                            <%--<div class="col-md-1">
                                        </div>--%>
                                            <div class="span9">
                                                <div class="form-horizontal">

                                                    <div class="form-group">
                                                        <span class="col-md-2 control-label">Total de atendidos</span>
                                                        <div class="col-md-6">

                                                            <div class=" row">

                                                                <div class=" col-xs-6 col-md-4">
                                                                    <asp:TextBox ID="txtatendios" runat="server" CssClass="form-control" Enabled="false" placeholder="0"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="col-md-8">
                                <div class="row">
                                    <div class="col-md-12">
                                        <%--  <asp:TextBox runat="server" ID="txtDomicilioTESTI" CssClass="form-control" TextMode="MultiLine" placeholder="Domicilio"></asp:TextBox>--%>
                                        <asp:FileUpload CssClass="file" runat="server" ID="file" AllowMultiple="true" type="file" date-min-file-count="1" />

                                    </div>
                                    <br />

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col-md-4">
                            <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>--%>
                            <asp:Button ID="btncancelarproxi" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btncancelarproxi_Click" />
                        </div>
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="btnGuardarProxi" runat="server" class="btn btn-success" Text="Guardar" OnClick="btnGuardarProxi_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function openModal() {
            //$('#myModalImgArchivos').modal('show');
            $('#myModalImgArchivos').modal();
            return false;
        }
        function closeModal() {
            //$('#myModalImgArchivos').modal('show');
            $('#myModalImgArchivos').modal('hide');
            return false;
        }
        function closeProxi() {
            //$('#myModalImgArchivos').modal('show');
            $('#myModaLProximidad').modal('hide');
            return false;
        }

        function copenProxi() {
            //$('#myModalImgArchivos').modal('show');
            $('#myModaLProximidad').modal();
            return false;
        }
    </script>
    <script type="text/javascript">
        //$(document).ready(function () {
        Sys.Application.add_load(function () {
            //Horizontal Tab
            $('#parentHorizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion
                width: 'auto', //auto or any width like 600px
                fit: true, // 100% fit in a container
                tabidentify: 'hor_1', // The tab groups identifier
                activate: function (event) { // Callback function if tab is switched
                    var $tab = $(this);
                    var $info = $('#nested-tabInfo');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });

            // Child Tab
            $('#ChildVerticalTab_1').easyResponsiveTabs({
                type: 'vertical',
                width: 'auto',
                fit: true,
                tabidentify: 'ver_1', // The tab groups identifier
                activetab_bg: '#fff', // background color for active tabs in this group
                inactive_bg: '#F5F5F5', // background color for inactive tabs in this group
                active_border_color: '#c1c1c1', // border color for active tabs heads in this group
                active_content_border_color: '#5AB1D0' // border color for active tabs contect in this group so that it matches the tab head border
            });

            //Vertical Tab
            $('#parentVerticalTab').easyResponsiveTabs({
                type: 'vertical', //Types: default, vertical, accordion
                width: 'auto', //auto or any width like 600px
                fit: true, // 100% fit in a container
                closed: 'accordion', // Start closed if in accordion view
                tabidentify: 'hor_1', // The tab groups identifier
                activate: function (event) { // Callback function if tab is switched
                    var $tab = $(this);
                    var $info = $('#nested-tabInfo2');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });
        });
</script>
    <style>
        /*********************************************************************************************/
        .card {
            border-radius: 8px;
            box-shadow: 0 9px 9px rgba(204, 197, 185, 0.5);
            background-color: #FFFFFF;
            color: #252422;
            margin-bottom: 20px;
            position: relative;
            z-index: 1;
        }

            .card .contentt {
                padding: 15px 15px 10px 15px;
            }


        .info-box.danger {
            background: brown !important;
            border: 1px solid brown !important;
        }

        .info-box.info {
            background: #67c2ef;
            border: 1px solid #39afea;
        }

        .info-box.warning {
            background: #fabb3d;
            border: 1px solid #f9aa0b;
        }

        .info-box.success {
            background: #79c447;
            border: 1px solid #61a434;
        }

        .info-box.danger {
            background: #ff5454;
            border: 1px solid #ff2121;
        }

        .info-box {
            min-height: 20%;
            border: 1px solid black;
            margin-bottom: 30px;
            padding: 7px;
            color: white;
            -webkit-box-shadow: inset 0 0 1px 1px rgba(255, 255, 255, 0.35), 0 3px 1px -1px rgba(0, 0, 0, 0.1);
            -moz-box-shadow: inset 0 0 1px 1px rgba(255, 255, 255, 0.35), 0 3px 1px -1px rgba(0, 0, 0, 0.1);
            box-shadow: inset 0 0 1px 1px rgba(255, 255, 255, 0.35), 0 3px 1px -1px rgba(0, 0, 0, 0.1);
        }

            .info-box .count {
                margin-top: -10px;
                font-size: 34px;
                font-weight: 700;
            }

            .info-box .title {
                font-size: 12px;
                text-transform: uppercase;
                font-weight: 600;
            }

            .info-box .desc {
                margin-top: 10px;
                font-size: 12px;
            }

            .info-box i {
                display: block;
                height: 100px;
                font-size: 60px;
                line-height: 100px;
                width: 100px;
                float: left;
                text-align: center;
                border-right: 2px solid rgba(255, 255, 255, 0.5);
                margin-right: 20px;
                padding-right: 20px;
                color: rgba(255, 255, 255, 0.75);
            }


        /**los semaforos de el grid de las etiquetas */
        .label.label-danger {
            background-color: #ff5454 !important;
            margin-top: 15px;
            display: inline-block;
            margin-left: 20px;
        }

        .label.label-warning {
            background-color: #fabb3d;
            margin-top: 15px;
            display: inline-block;
            margin-left: 20px;
        }

        .label.label-default {
            background-color: #d4d4d4;
            color: #484848;
            margin-top: 15px;
            display: inline-block;
            margin-left: 20px;
        }

        .label.label-success {
            background-color: #79c447;
            margin-top: 15px;
            display: inline-block;
            margin-left: 20px;
        }


        .input-group-addon.danger {
            color: rgb(217, 83, 79) !important;
            background-color: rgb(255, 255, 255) !important;
            border-color: rgb(212, 63, 58) !important;
        }

        .input-group-addon.success {
            color: rgb(92, 184, 92) !important;
            background-color: rgb(255, 255, 255) !important;
            border-color: rgb(76, 174, 76) !important;
        }
    </style>
</asp:Content>
