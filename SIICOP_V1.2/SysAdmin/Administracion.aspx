<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="SIICOP_V1._2.sysadmin.Administracion" %>
<asp:Content
    ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="container-fluid">

    <div class="row mb-4">

        <div class="col-md-12">

            <h2 class="fw-bold">
                Administración del Sistema
            </h2>

            <p class="text-muted">
                Usuarios, roles, sesiones, auditoría y monitoreo.
            </p>

        </div>

    </div>

    <ul class="nav nav-tabs mb-4"
        id="adminTabs"
        role="tablist">

        <li class="nav-item">

            <button
                class="nav-link active"
                data-bs-toggle="tab"
                data-bs-target="#usuarios">

                Usuarios

            </button>

        </li>

        <li class="nav-item">

            <button
                class="nav-link"
                data-bs-toggle="tab"
                data-bs-target="#roles">

                Roles

            </button>

        </li>

        <li class="nav-item">

            <button
                class="nav-link"
                data-bs-toggle="tab"
                data-bs-target="#sesiones">

                Sesiones

            </button>

        </li>

        <li class="nav-item">

            <button
                class="nav-link"
                data-bs-toggle="tab"
                data-bs-target="#auditoria">

                Auditoría

            </button>

        </li>

        <li class="nav-item">

            <button
                class="nav-link"
                data-bs-toggle="tab"
                data-bs-target="#errores">

                Errores

            </button>

        </li>

    </ul>

    <div class="tab-content">

        <div class="tab-pane fade show active"
             id="usuarios">

            <div class="card shadow-sm">

                <div class="card-body">

                    <h5>
                        Administración de usuarios
                    </h5>

                    <p class="text-muted">
                        <asp:GridView
    ID="gvUsuarios"
    runat="server"
    CssClass="table table-hover"
    AutoGenerateColumns="False">

    <Columns>

        <asp:BoundField
            DataField="NombreCompleto"
            HeaderText="Nombre" />

        <asp:BoundField
            DataField="Login"
            HeaderText="Login" />

        <asp:BoundField
            DataField="Dependencia"
            HeaderText="Dependencia" />

        <asp:BoundField
            DataField="AreaTrabajo"
            HeaderText="Área" />

        <asp:BoundField
            DataField="FechaCreacion"
            HeaderText="Alta" />

    </Columns>

</asp:GridView>
                    </p>

                </div>

            </div>

        </div>

        <div class="tab-pane fade"
             id="roles">

            <div class="card shadow-sm">

                <div class="card-body">

                    <h5>
                        Administración de roles
                    </h5>

                    <p class="text-muted">
                        Próxima migración desde ControlRoles.aspx
                    </p>

                </div>

            </div>

        </div>

        <div class="tab-pane fade"
             id="sesiones">

            <div class="row">

                <div class="col-md-3">

                    <div class="card text-center shadow-sm">

                        <div class="card-body">

                            <h3>
                                <asp:Label
                                    ID="lblUsuariosActivos"
                                    runat="server"
                                    Text="0" />
                            </h3>

                            <small>
                                Usuarios activos
                            </small>

                        </div>

                    </div>

                </div>

            </div>

        </div>

        <div class="tab-pane fade"
             id="auditoria">

            <div class="card shadow-sm">

                <div class="card-body">

                    Bitácora de auditoría

                </div>

            </div>

        </div>

        <div class="tab-pane fade"
             id="errores">

            <div class="card shadow-sm">

                <div class="card-body">

                    ErrorLog v2

                </div>

            </div>

        </div>

    </div>

</div>

</asp:Content>