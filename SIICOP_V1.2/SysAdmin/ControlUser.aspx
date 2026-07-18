
<%@ Page Title="Administración de usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlUser.aspx.cs" Inherits="SIICOP_V1._2.SysAdmin.ControlUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
 
    <script type="text/javascript">
        function Correcto() {
          
            Swal.fire({
                title: "¡Correcto!",
                text: "Operación realizada con éxito",
                icon: "success",
                confirmButtonText: "Aceptar" 
            });
            return false;
        }  
        function openModalpassword(loginValue) {
            $('#myModalPassword').modal('show');         
        }      
        function openModalNuevoUser() {
            $('#ModalCrearUser').modal('show');
        }
        function openModalEditUser() {
            $('#myModalEditUser').modal('show');
        }
    </script>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <h3 style="text-align: center"><span>Administración y control de usuarios</span></h3>
                <asp:LinkButton runat="server" ID="lnkbtnAgregarUser" CssClass="btn btn-success pull-right" 
                    OnClientClick="openModalNuevoUser(); return false;">
                    Agregar usuario <i class="fas fa-user-plus"></i>
                </asp:LinkButton>
                <br />  
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:GridView runat="server" CssClass="table table-bordered" ID="gvuser" AutoGenerateColumns="False" 
                    DataKeyNames="Personalid, guidUsuario"
                    CellPadding="3" AllowPaging="True"
                    OnDataBound="gvuser_DataBound"
                    OnRowCommand="gvuser_RowCommand"
                    OnPageIndexChanging="gvuser_PageIndexChanging" EnableViewState="false"
                    PagerSettings-PageButtonCount="5" PageSize="10">
                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    <PagerTemplate>
                        <div class="row" style="width:100%; padding:10px;">
                            <div class="col-md-6 text-right">
                                <asp:Label ID="CurrentPageLabelt" runat="server" CssClass="fw-bold"></asp:Label>
                            </div>
                            <div class="col-md-6 text-left">
                                Ir a página: 
                                <asp:DropDownList ID="PageDropDownListAdmin" AutoPostBack="true" 
                                    OnSelectedIndexChanged="PageDropDownListAdmin_SelectedIndexChanged" 
                                    runat="server" 
                                    CssClass="form-control d-inline-block w-auto" />
                            </div>
                        </div>
                    </PagerTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Nombre") %>' ID="Label1"></asp:Label>&nbsp;
                                <asp:Label runat="server" Text='<%# Bind("paterno") %>' ID="Label2"></asp:Label>&nbsp;
                                <asp:Label runat="server" Text='<%# Bind("materno") %>' ID="Label3"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AreaTrabajo" HeaderText="Área de trabajo" SortExpression="AreaTrabajo"></asp:BoundField>
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
                </asp:GridView>
              </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <%-- MODAL: CAMBIAR CONTRASEÑA --%>
    <div class="modal fade" id="myModalPassword" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="updModalPassword" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="$('#myModalPassword').modal('hide');">
                             <span aria-hidden="true">&times;</span>
                     </button>
                    <h4 class="modal-title">Cambiar contraseña.</h4>
                </div>
                <div class="modal-body">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                        <asp:TextBox runat="server" ID="txtLogin" CssClass="form-control" ReadOnly="true"></asp:TextBox>                        
                        <asp:HiddenField runat="server" ID="hfUsuarioSeleccionado" />
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-key fa-fw"></i></span>
                        <asp:TextBox runat="server" ID="txtpassword" CssClass="form-control" placeholder="Nueva contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="$('#myModalPassword').modal('hide');">Cerrar</button>
                    <asp:LinkButton runat="server" ID="lkbGuardarContraseña" CssClass="btn btn-success" OnClick="lkbGuardarContraseña_Click">
                        <i class="fas fa-save"></i> Guardar
                    </asp:LinkButton>
                </div>
              </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <%-- MODAL: EDITAR USUARIO --%>
    <div class="modal fade" id="myModalEditUser" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="updModaleditaruserm" runat="server" UpdateMode="Conditional">
                 <ContentTemplate>
                <div class="modal-header">
                     <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="$('#myModalEditUser').modal('hide');">
                             <span aria-hidden="true">&times;</span>
                     </button>
                      <h4 class="modal-title">Editar usuario.</h4>
                </div>
                <div class="modal-body">
                    <div class="input-group">
                     <span class="input-group-addon"><i class="fa fa-user"></i></span>
                     <asp:TextBox runat="server" ID="txtNombreEdit" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hfNombreUser" />
                    </div>
                    <br />
                    <asp:TextBox runat="server" ID="txtApaterno" CssClass="form-control" placeholder="Apellido Paterno"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hfApaterno" />
                    <br />
                    <asp:TextBox runat="server" ID="txtAmaterno" CssClass="form-control" placeholder="Apellido Materno"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hfAMaterno" />
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase"></i></span>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase" style="color: RED"></i></span>
                        <asp:DropDownList ID="ddldepen_edit" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="$('#myModalEditUser').modal('hide');">Cerrar</button>
                    <asp:LinkButton runat="server" ID="lnkbEditUser" CssClass="btn btn-success" OnClick="lnkbEditUser_Click">
                        <i class="fas fa-save"></i> Guardar
                    </asp:LinkButton>
                </div>
                   </ContentTemplate>
            </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <%-- MODAL: CREAR USUARIO --%>
    <div class="modal fade" id="ModalCrearUser" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
              <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="$('#ModalCrearUser').modal('hide');">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title">Crear usuario.</h4>
              </div>
                <div class="modal-body">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fa fa-user" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtNombreNuevo" CssClass="form-control" placeholder="Nombre de usuario"></asp:TextBox>
                    </div>
                    <br />
                    <asp:TextBox runat="server" ID="txtapellidopaternoNuevo" CssClass="form-control" placeholder="Apellido paterno"></asp:TextBox>
                    <br />
                    <asp:TextBox runat="server" ID="txtapellidomaternoNuevo" CssClass="form-control" placeholder="Apellido materno"></asp:TextBox>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase" style="color: RED"></i></span>
                        <asp:DropDownList ID="ddlAreaNuevo" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <br />
                   <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-briefcase" style="color: RED"></i></span>
                        <asp:DropDownList ID="ddldepndencia" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">--Seleccione una dependencia--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-user-secret" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtUsuarioLogin" CssClass="form-control" placeholder="Login"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-user-lock" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtcontraseñanueva" TextMode="Password" class="form-control" placeholder="Contraseña" />
                    </div>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtcontraseñanueva"
                        CssClass="field-validation-error" ErrorMessage="Contraseña requerida*" ValidationGroup="CrearNuevoUsuario" ForeColor="Red" Display="Dynamic" />
                    <br />
                    <div class="input-group">
                        <span class="input-group-addon"><i class="fas fa-user-lock" style="color: RED"></i></span>
                        <asp:TextBox runat="server" ID="txtConfirmaPassword" TextMode="Password" class="form-control" placeholder="Confirmar contraseña" />
                    </div>
                    <asp:CompareValidator runat="server" ControlToCompare="txtcontraseñanueva" ControlToValidate="txtConfirmaPassword"
                        CssClass="field-validation-error" Display="Dynamic" ErrorMessage="La contraseña no coincide" ForeColor="Red" ValidationGroup="CrearNuevoUsuario" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal" onclick="$('#ModalCrearUser').modal('hide');">Cerrar</button>
                    <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-info" OnClick="lnkCrearUser_Click" ValidationGroup="CrearNuevoUsuario">
                        <i class="fas fa-save"></i> Guardar
                    </asp:LinkButton>
                </div>       
            </div>
        </div>
    </div>
</asp:Content>