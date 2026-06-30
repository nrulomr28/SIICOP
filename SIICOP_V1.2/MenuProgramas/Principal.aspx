<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .panel-custom {
            border-radius: 8px;
        }

            .panel-custom > .panel-heading {
                font-size: 18px;
                font-weight: bold;
                text-align: center;
            }

        .grid-wrapper {
            display: flex;
            justify-content: center;
        }

        .table-custom {
            max-width: 600px;
            width: 100%;
            margin: 0 auto;
            background-color: #fff;
        }

            .table-custom th {
                text-align: center;
                background-color: #337ab7;
                color: white;
            }

            .table-custom td {
                text-align: center;
                vertical-align: middle !important;
            }

        .program-link {
            font-weight: bold;
            color: #337ab7;
            text-decoration: none;
        }

            .program-link:hover {
                text-decoration: underline;
                color: #23527c;
            }

        .badge-custom {
            background-color: #777;
        }
    </style>

    <div class="container">
        <br />
        <br />
        <div class="row mt-3">
            <div class="col-md-8 col-md-offset-2">
                <h3 class="text-center">
                    <strong>
                        <i class="fas fa-tasks"></i>
                        Crear Reporte de actividades de la DVI
                    </strong>
                </h3>
            </div>
        </div>


        <div class="row mt-3">

            <div class="col-md-8 col-md-offset-2">

                <%--<div class="panel panel-primary panel-custom">--%>


                <div class="panel-body">

                    <div class="grid-wrapper">

                        <asp:GridView ID="gvProgramas" runat="server"
                            AutoGenerateColumns="False"
                            DataKeyNames="programasID"
                            CssClass="table table-striped table-bordered table-hover table-custom"
                            GridLines="None"
                            BorderStyle="None"
                            OnSelectedIndexChanged="gvProgramas_SelectedIndexChanged">

                            <Columns>

                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Width="60px" />
                                    <ItemTemplate>
                                        <span class="badge badge-custom">
                                            <%# Container.DataItemIndex + 1 %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="programasID"
                                    Visible="false" />

                                <asp:TemplateField HeaderText="Programa">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPrograma" runat="server"
                                            Text='<%# Eval("NombrePrograma") %>'
                                            CommandName="Select"
                                            CssClass="program-link">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                        </asp:GridView>

                    </div>

                </div>

                <%--  </div>--%>
            </div>
        </div>
    </div>

    <%--  <asp:EntityDataSource ID="edsProgramas" runat="server"
        ConnectionString="name=SIICOPEntities"
        DefaultContainerName="SIICOPEntities"
        EnableFlattening="False"
        EnableUpdate="True"
        EntitySetName="tb_programa"
        Where="it.activo = true">
    </asp:EntityDataSource>--%>

    <%--<asp:EntityDataSource 
    ID="edsProgramas" 
    runat="server"
    ConnectionString="name=SIICOPEntities"
    DefaultContainerName="SIICOPEntities"    
    ContextTypeName="SIICOP_V1._2.Datos.SIICOPEntities"
    EntitySetName="tb_programa"
    Where="it.activo = true">
</asp:EntityDataSource>--%>


    <br />
</asp:Content>
