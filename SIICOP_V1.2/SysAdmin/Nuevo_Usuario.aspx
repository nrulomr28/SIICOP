<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Nuevo_Usuario.aspx.cs" Inherits="SIICOP_V1._2.SysAdmin.Nuevo_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%= ResolveUrl("~/Scripts/sweetalert2.all.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function Correcto() {
            swal({
                title: "Correcto!",
                text: "El usuario se creo con exito",
                icon: "success",
                button: "Aceptar",

            });
            return false
        }



    </script>
    <style>
        .login-block .auth-box {
            margin: 20px auto 0 auto;
            max-width: 450px !important;
        }

        .card {
            border-radius: 5px;
            -webkit-box-shadow: 0 0 5px 0 rgba(43,43,43,0.1),0 11px 6px -7px rgba(43,43,43,0.1);
            box-shadow: 0 0 5px 0 rgba(43,43,43,0.1),0 11px 6px -7px rgba(43,43,43,0.1);
            border: none;
            margin-bottom: 30px;
            -webkit-transition: all 0.3s ease-in-out;
            transition: all 0.3s ease-in-out;
        }

            .card .card-block {
                padding: 1.25rem;
            }
    </style>
    <!-- MAIN CONTENT CONTAINER -->
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <section class="login-block">
                    <div class="auth-box card">
                        <div class="card-block">
                            <div class="row m-b-20">
                                <div class="col-md-12">
                                    <h3 class="text-center txt-primary">Crear usuario</h3>
                                </div>
                            </div>

                            <br />
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group form-primary">
                                        <asp:TextBox runat="server" ID="txtnombre" class="form-control" />

                                        <span class="form-bar"></span>
                                        <label class="float-label">Nombre</label>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group form-primary">
                                        <asp:TextBox runat="server" ID="txtpaterno" class="form-control" />
                                        <span class="form-bar"></span>
                                        <label class="float-label">A. Paterno</label>
                                    </div>
                                </div>
                                <div class="col-sm-4">
                                    <div class="form-group form-primary">
                                        <asp:TextBox runat="server" ID="txtxmaterno" class="form-control" />
                                        <span class="form-bar"></span>
                                        <label class="float-label">A. Materno</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group form-primary">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlarea" DataSourceID="edsarea" DataTextField="area_nombre" DataValueField="idarea"></asp:DropDownList>
                                <asp:EntityDataSource runat="server" ID="edsarea" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Cat_area"></asp:EntityDataSource>
                                <span class="form-bar"></span>
                                <label class="float-label">Area</label>
                            </div>
                            <div class="form-group form-primary">
                                <asp:TextBox runat="server" ID="txtUsuario" class="form-control" />
                                <span class="form-bar"></span>
                                <label class="float-label">Usuario</label>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group form-primary">
                                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" class="form-control" />
                                        <span class="form-bar"></span>
                                        <label class="float-label">Contraseña</label>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword"
                                            CssClass="field-validation-error" ErrorMessage="*" ValidationGroup="CrearNuevoUsuario" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group form-primary">
                                        <asp:TextBox runat="server" ID="txtConfirmaPassword" TextMode="Password" class="form-control" />
                                        <span class="form-bar"></span>
                                        <label class="float-label">Confirmar Contraseña</label>
                                        <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmaPassword"
                                            CssClass="field-validation-error" Display="Dynamic" ErrorMessage="La contraseña no coincide, noooo cabrón" />
                                    </div>
                                </div>
                            </div>

                            <div class="row m-t-30">
                                <div class="col-md-12">

                                    <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuario" CssClass="btn btn-success btn-md btn-block waves-effect text-center m-b-20" CausesValidation="true" ValidationGroup="CrearNuevoUsuario" OnClick="btnCrearUsuario_Click" />

                                </div>
                            </div>
                            <hr>
                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!---END: CLIENTS ROTATOR ## -->
    </div>
    <!-- END MAIN WRAPPER-->

    <asp:UpdatePanel ID="updPanel_Usuarios" runat="server">
        <ContentTemplate>

            <ajaxToolkit:ModalPopupExtender ID="mpe_msj" runat="server" PopupControlID="pnl_msj" OkControlID="btn_Ok" TargetControlID="btn_dummy" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnl_msj" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                <asp:Label ID="lbl_msj" runat="server"></asp:Label>
                <hr />
                <asp:Button ID="btn_Ok" runat="server" Text="Ok" />
            </asp:Panel>
            <asp:Button ID="btn_dummy" runat="server" Style="display: none" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
