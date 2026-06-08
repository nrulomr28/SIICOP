<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TotalAccionesBeneficiados.aspx.cs" Inherits="SIICOP_V1._2.TotalAccionesBeneficiados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <style>
        .custom-grid {
            border-radius: 12px;
            overflow: hidden;
        }

        /* Encabezado elegante */
        .custom-header th {
            background-color: #f8f9fa !important;
            color: #2f6fb2;
            font-weight: 600;
            text-align: center;
            border-bottom: 2px solid #2f6fb2;
        }

        /* Filas */
        .custom-grid tbody tr {
            border-bottom: 1px solid #eef1f5;
            transition: 0.2s;
        }

            /* Hover */
            .custom-grid tbody tr:hover {
                background-color: #f7fbff;
            }

        /* Celdas */
        .custom-grid td {
            text-align: center;
            vertical-align: middle;
        }
    </style>

    <div class="container mt-4">

        <div class="text-center mb-4">
            <h3 class="fw-bold text-dark" style="letter-spacing: 1px;">ACCIONES Y BENEFICIADOS
            </h3>
            <span class="text-muted">Resumen del mes actual</span>
        </div>

        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-body p-4">

                <div class="table-responsive">

                    <asp:GridView ID="gvTotalAcciones" runat="server"
                        AutoGenerateColumns="False"
                        CssClass="table table-hover align-middle custom-grid"
                        AllowPaging="True" PageSize="10"
                        GridLines="None">

                        <HeaderStyle CssClass="custom-header" />

                        <Columns>


                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <span class="badge bg-light text-dark border rounded-pill px-3 py-1">
                                        <%# Container.DataItemIndex + 1 %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:BoundField DataField="NombrePrograma" HeaderText="Programa">
                                <ItemStyle CssClass="text-start fw-semibold small" />
                            </asp:BoundField>


                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <span class="fw-bold text-success fs-5">
                                        <%# Eval("TotalAcciones") %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Hombres">
                                <ItemTemplate>
                                    <span class="fw-bold text-primary fs-5">
                                        <%# Eval("TotalHombres") %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Mujeres">
                                <ItemTemplate>
                                    <span class="fw-bold text-danger fs-5">
                                        <%# Eval("TotalMujeres") %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <span class="fw-bold text-danger fs-5">
                                        <%# Eval("TotalAtendidos") %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>

                    </asp:GridView>

                </div>

            </div>
        </div>

    </div>

</asp:Content>
