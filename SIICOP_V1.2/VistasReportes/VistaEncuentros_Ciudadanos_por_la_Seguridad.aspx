<%@ Page Title="ENCUENTROS CIUDADANOS POR LA SEGURIDAD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaEncuentros_Ciudadanos_por_la_Seguridad.aspx.cs" Inherits="SIICOP_V1._2.VistasReportes.VistaForosFerias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styleFormularios.css" rel="stylesheet" />
    <div class="container" style="padding-top: 3%">
        <div class="row">
            <div id="sidebar">
                <div class="sosmed">
                    <div class="user">
                        <div class="user-head">
                            <h1>VISTA DE DATOS DE LAS ACTIVIDADES CAPTURADAS</h1>
                            <div class="hr-center"></div>
                            <h5 style="color: #feff00">ENCUENTROS CIUDADANOS POR LA SEGURIDAD</h5>
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
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="marketing">
                    <hr class="half">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="well">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <div class="form-group has-feedback">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                    <asp:TextBox ID="txtFInicialC" runat="server" CssClass="form-control" placeholder="Buscar por Fecha"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="ceFIC" runat="server" TargetControlID="txtFInicialC" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
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
                                                <asp:TextBox runat="server" ID="txtBusquedaFolio" CssClass="form-control" placeholder="Busqueda por asunto.."></asp:TextBox>
                                            </div>
                                        </div>


                                        <div id="RESPONSA" runat="server">

                                            <div class="col-lg-2">

                                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
                                            </div>

                                            <div class="col-lg-1" runat="server" id="bottonExcel" visible="false">

                                                <asp:LinkButton ID="lkbtnexcel" runat="server" CssClass="btn btn-success" Style="font-size: 1.8em" Text="excel" title="Exportar" OnClick="lkbtnexcel_Click"><span class="far fa-file-excel"></span>&nbsp;</asp:LinkButton>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />

                            </div>
                        </div>
                    </div>
                    <hr class="half">
                </div>
            </div>
            <div class="col-lg-1"></div>

        </div>
    </div>
    <div class="container-fluid">


        <br />
        <asp:UpdatePanel runat="server" ID="upd">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="col-lg-2 pull-right">
                        <div class="form-group pull-right">
                            <asp:Label ID="lblTotalRegistros" runat="server" CssClass="label label-warning" Font-Size="18px" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div class="well" style="background-color: white">
                        <asp:GridView ID="GvForosFerias" runat="server" CssClass="table table-condensed table-bordered" AutoGenerateColumns="False" DataKeyNames="idResumenDiario"
                            DataSourceID="EdsVistaEscolar" CellPadding="3" AllowPaging="True" Visible="false"
                            OnDataBound="GvForosFerias_DataBound" OnRowCommand="GvForosFerias_RowCommand"
                            OnRowDataBound="GvForosFerias_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="FolioActividad" HeaderText="Folio" HeaderStyle-CssClass="col-md-1" SortExpression="FolioActividad"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" DataFormatString="{0:dddd-dd-MMMM-yyyy}"></asp:BoundField>
                                <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" SortExpression="MUNICIPIO"></asp:BoundField>
                                <asp:BoundField DataField="nombrecompleto" HeaderText="Capturista" SortExpression="nombrecompleto"></asp:BoundField>
                                <asp:BoundField DataField="personal_atendio_actividad" HeaderText="Encargado de actividad" SortExpression="personal_atendio_actividad"></asp:BoundField>
                                <asp:BoundField DataField="NombreSubPrograma" HeaderText="NombreSubPrograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                                <asp:BoundField DataField="AccionesNombre" HeaderText="Acciones" SortExpression="AccionesNombre"></asp:BoundField>
                                <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                                <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                                <asp:BoundField DataField="total_atendidos" HeaderText="Total atendidos" SortExpression="total_atendidos"></asp:BoundField>
                                <asp:BoundField DataField="descripcion_actividad" HeaderText="Descripción" SortExpression="descripcion_actividad"></asp:BoundField>
                                <asp:TemplateField HeaderText="¿Fotos cargadas?">
                                    <ItemTemplate>
                                        <asp:Image runat="server" AlternateText='<%# Eval("fotos") %>' ID="imgCap" Width="25" Height="25"></asp:Image>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
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
                                        <asp:DropDownList ID="PageDropDownList" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                    </div>
                                    <div class="col-lg-10" style="text-align: right;">
                                        <h3>
                                            <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-success" /></h3>
                                    </div>
                                </div>
                            </PagerTemplate>
                        </asp:GridView>
                        <asp:EntityDataSource runat="server" ID="EdsVistaEscolar" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                            EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico"
                            OrderBy="it.[fecha] desc"
                            Where="it.Personalid == @resp || it.nombrecompleto =='0' && it.programasID = 5">
                            <WhereParameters>
                                <asp:SessionParameter DefaultValue="0" Name="resp" SessionField="responsable" DbType="Int32" />
                            </WhereParameters>
                        </asp:EntityDataSource>


                        <%--grid administrativo--%>
                        <asp:GridView ID="GvForosFeriasadmin" runat="server" CssClass="table table-condensed table-bordered" AutoGenerateColumns="False" DataKeyNames="idResumenDiario"
                            DataSourceID="EdsVistaPVMadmin"
                            CellPadding="3" AllowPaging="True" Visible="false"
                            OnDataBound="GvForosFeriasadmin_DataBound"
                            OnRowCommand="GvForosFeriasadmin_RowCommand"
                            OnRowDataBound="GvForosFeriasadmin_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="FolioActividad" HeaderText="Folio" HeaderStyle-CssClass="col-md-1" SortExpression="FolioActividad"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" DataFormatString="{0:dddd-dd-MMMM-yyyy}"></asp:BoundField>
                              <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" SortExpression="MUNICIPIO"></asp:BoundField>
                                <asp:BoundField DataField="nombrecompleto" HeaderText="Capturista" SortExpression="nombrecompleto"></asp:BoundField>
                                <asp:BoundField DataField="personal_atendio_actividad" HeaderText="Encargado de actividad" SortExpression="personal_atendio_actividad"></asp:BoundField>
                                <asp:BoundField DataField="AreaTrabajo" HeaderText="Area" SortExpression="AreaTrabajo"></asp:BoundField>
                                <asp:BoundField DataField="NombreSubPrograma" HeaderText="NombreSubPrograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                                <asp:BoundField DataField="AccionesNombre" HeaderText="Acciones" SortExpression="AccionesNombre"></asp:BoundField>
                                <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                                <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                                <asp:BoundField DataField="total_atendidos" HeaderText="Total atendidos" SortExpression="total_atendidos"></asp:BoundField>
                                <asp:BoundField DataField="descripcion_actividad" HeaderText="Descripción" SortExpression="descripcion_actividad"></asp:BoundField>
                                <asp:TemplateField HeaderText="¿Fotos cargadas?">
                                    <ItemTemplate>
                                        <asp:Image runat="server" AlternateText='<%# Eval("fotos") %>' ID="imgAdmin" Width="25" Height="25"></asp:Image>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
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
                                        <asp:DropDownList ID="PageDropDownListAdmin" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownListAdmin_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                    </div>
                                    <div class="col-lg-10" style="text-align: right;">
                                        <h3>
                                            <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-success" /></h3>
                                    </div>
                                </div>
                            </PagerTemplate>
                        </asp:GridView>
                        <asp:EntityDataSource runat="server" ID="EdsVistaPVMadmin" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                            EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico"
                            OrderBy="it.[fecha] desc" Where="it.programasID = 11">
                            <WhereParameters>
                                <asp:SessionParameter DefaultValue="0" Name="resp" SessionField="responsable" DbType="Int32" />
                            </WhereParameters>
                        </asp:EntityDataSource>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
