<%@ Page Title="Administración de usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlUser.aspx.cs" Inherits="SIICOP_V1._2.SysAdmin.ControlUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <script src="<%= ResolveUrl("~/Scripts/sweetalert2.all.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function Correcto() {
            swal({
                title: "Correcto!",
                text: "El usuario se creó con exito",
                icon: "success",
                button: "Aceptar",

            });
            return false
        }

    </script>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 ">
                <h3 style="text-align: center"><span>Administración y control de usuarios</span></h3>
                <asp:LinkButton runat="server" ID="lnkbtnAgregarUser" CssClass="btn btn-success pull-right" OnClick="lnkbtnAgregarUser_Click">Agregar usuario <i class="fas fa-user-plus"></i></asp:LinkButton>
                <br />
                <asp:GridView runat="server" CssClass="table table-bordered" ID="gvuser" AutoGenerateColumns="False" DataKeyNames="Personalid, guidUsuario"
                    CellPadding="3" AllowPaging="True"
                    OnDataBound="gvuser_DataBound"
                    OnRowCommand="gvuser_RowCommand"
                    DataSourceID="edsUser"
                    PagerSettings-PageButtonCount="5" PageSize="10">
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Nombre") %>' ID="Label1"></asp:Label>&nbsp;<asp:Label runat="server" Text='<%# Bind("paterno") %>' ID="Label2"></asp:Label>&nbsp;<asp:Label runat="server" Text='<%# Bind("materno") %>' ID="Label3"></asp:Label>&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AreaTrabajo" HeaderText="Area de trabajo" SortExpression="AreaTrabajo"></asp:BoundField>
                        <asp:BoundField DataField="fechacrecion" HeaderText="Fecha de creación" SortExpression="fechacrecion"></asp:BoundField>
                        <asp:BoundField DataField="login" HeaderText="Login" SortExpression="login"></asp:BoundField>
                        <asp:BoundField DataField="Dependencia" HeaderText="Dependencia" SortExpression="Dependencia"></asp:BoundField>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="ResetPassword" CommandName="ResetPassword" CssClass="btn btn-info" CausesValidation="False" ID="lnkbtnCambiarContraseña" ToolTip="Editar contraseña" CommandArgument='<%# Eval("guidUsuario") %>'>
                                 <i class="fas fa-lock"></i>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" Text="Editaruser" CommandName="EditarUser" class="btn btn-warning" CausesValidation="False" ID="lnkbtnEdirUser" ToolTip="Editar usuarios" CommandArgument='<%# Eval("Personalid") %>'>
                                    <i class="fas fa-user-edit"></i>
                                </asp:LinkButton>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>

                        </asp:TemplateField>
                    </Columns>
                    <%--<PagerTemplate>
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
                                    <asp:Label ID="CurrentPageLabelt" runat="server" CssClass="label label-info" /></h3>
                            </div>
                        </div>
                    </PagerTemplate>--%>
                </asp:GridView>
                <asp:EntityDataSource runat="server" ID="edsUser" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Personales" OrderBy="it.fechacrecion desc"></asp:EntityDataSource>
            </div>
        </div>
    </div>


    <div class="modal fade" id="myModalPassword" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Cambiar contraseña.</h4>
                </div>
                <div class="modal-body">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:TextBox runat="server" ID="txtLogin" CssClass=" form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-key fa-fw"></i></span>
                        <asp:TextBox runat="server" ID="txtpassword" CssClass=" form-control" placeholder="Nueva contraseña"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:LinkButton runat="server" ID="lkbGuardarContraseña" CssClass=" btn btn-success" OnClick="lkbGuardarContraseña_Click">
                        <i class="fas fa-save" ></i> Guardar
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="myModalEditUser" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabelEdit">Editar usuario.</h4>
                </div>
                <div class="modal-body">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:TextBox runat="server" ID="txtNombreEdit" CssClass=" form-control"></asp:TextBox>
                    </div>
                    <br />
                    <asp:TextBox runat="server" ID="txtApaterno" CssClass=" form-control"></asp:TextBox>
                    <br />
                    <asp:TextBox runat="server" ID="txtAmaterno" CssClass=" form-control"></asp:TextBox>
                    <br />

                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase"></i></span>
                        <asp:DropDownList runat="server" ID="ddlArea" DataSourceID="edsArea" CssClass="form-control" DataTextField="area_nombre" DataValueField="idarea"></asp:DropDownList>
                        <asp:EntityDataSource runat="server" ID="edsArea" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Cat_area"></asp:EntityDataSource>
                    </div>
                    <br />
                     <br />
                     <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase" style="color: RED"></i></span>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddldepen_edit" DataSourceID="edsDependencia2" DataTextField="DependenciaNombre" DataValueField="DependenciaId" OnDataBound="ddldepen_edit_DataBound"></asp:DropDownList>
                        <asp:EntityDataSource runat="server" ID="edsDependencia2" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Cat_Dependencias"></asp:EntityDataSource>
                    </div>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:LinkButton runat="server" ID="lnkbEditUser" CssClass=" btn btn-success" OnClick="lnkbEditUser_Click">
                        <i class="fas fa-save" ></i> Guardar
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ModalCrearUser" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabelCrearUser">Crear usuario.</h4>
                </div>
                <div class="modal-body">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtNombreNuevo" CssClass=" form-control" placeholder="Nombre de usuario"></asp:TextBox>
                    </div>
                    <br />
                    <asp:TextBox runat="server" ID="txtapellidopaternoNuevo" CssClass=" form-control" placeholder="Apellido paterno"></asp:TextBox>
                    <br />
                    <asp:TextBox runat="server" ID="txtapellidomaternoNuevo" CssClass=" form-control" placeholder="Apellido materno"></asp:TextBox>
                    <br />
                     <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase" style="color: RED"></i></span>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddldepndencia" DataSourceID="edsDependencia" DataTextField="DependenciaNombre" DataValueField="DependenciaId"></asp:DropDownList>
                        <asp:EntityDataSource runat="server" ID="edsDependencia" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Cat_Dependencias"></asp:EntityDataSource>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase" style="color: RED"></i></span>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlAreaNuevo" DataSourceID="edsarea" DataTextField="area_nombre" DataValueField="idarea"></asp:DropDownList>
                        <asp:EntityDataSource runat="server" ID="EntityDataSource1" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Cat_area"></asp:EntityDataSource>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-user-secret" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtUsuarioLogin" CssClass=" form-control" placeholder="Login"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-user-lock" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtcontraseñanueva" TextMode="Password" class="form-control" placeholder="Contraseña" />

                    </div>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcontraseñanueva"
                        CssClass="field-validation-error" ErrorMessage="*" ValidationGroup="CrearNuevoUsuario" ForeColor="Red" />
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-user-lock" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtConfirmaPassword" TextMode="Password" class="form-control" placeholder="Confirmar contraseña" />
                        <asp:CompareValidator runat="server" ControlToCompare="txtcontraseñanueva" ControlToValidate="txtConfirmaPassword"
                            CssClass="field-validation-error" Display="Dynamic" ErrorMessage="La contraseña no coincide, noooo cabrón" />
                    </div>
                </div>
                <br />
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <asp:LinkButton runat="server" ID="lnkCrearUser" CssClass=" btn btn-info" OnClick="lnkCrearUser_Click">
                        <i class="fas fa-save" ></i> Guardar
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function openModalNuevoUser() {
            $('#ModalCrearUser').modal();
        }
        function openModalpassword() {
            $('#myModalPassword').modal();
        }
        function openModalEditUser() {
            $('#myModalEditUser').modal();
        }
    </script>
</asp:Content>
