<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlRoles.aspx.cs" Inherits="SIICOP_V1._2.SysAdmin.ControlRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <script type="text/javascript">
       $(document).ready(function () {
           // Inicializa las pestañas
           $('#myRoleTabs a').click(function (e) {
               e.preventDefault();
               $(this).tab('show');
           });
       });

       // Soporte para UpdatePanels
       var prm = Sys.WebForms.PageRequestManager.getInstance();
       prm.add_endRequest(function () {
           $('#myRoleTabs a').click(function (e) {
               e.preventDefault();
               $(this).tab('show');
           });
       });
   </script>
   
    <section>
        <div class="container">       
            <!-- Título -->
            <div class="row mb-4 mt-2">
                <div class="col-12">
                    <h2 class="text-center fw-bold" style="color:#611232;">
                        Administración de Usuarios y Roles
                    </h2>
                    <hr />
                </div>
            </div>
            
            <div class="row">
                <div class="col-12">
                    <!-- 'card' reemplaza al antiguo 'well' -->
                    <div class="card shadow-sm">
                        <div class="card-body p-4">                            
                            <p class="text-center">
                                <asp:Label ID="ActionStatus" runat="server" CssClass="text-danger fw-bold"></asp:Label>
                            </p>
                            <!-- Pestañas modernas Bootstrap -->
                            <ul class="nav nav-tabs" id="myRoleTabs">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#panelUsuarios">Usuarios</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" data-toggle="tab" href="#panelRoles">Roles</a>
                                </li>
                            </ul>
                            <div class="tab-content pt-4">                              
                                <!-- TAB 1: USUARIOS -->
                                <div id="panelUsuarios" class="tab-pane fade show in active">
                                    <div class="mb-4">
                                        <label class="form-label fw-bold">Seleccione el Usuario:</label>
                                        <!-- Se cambió a form-select  -->
                                        <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" 
                                            DataTextField="UserName" DataValueField="UserName" 
                                            OnSelectedIndexChanged="UserList_SelectedIndexChanged" CssClass="form-select">
                                        </asp:DropDownList>
                                    </div>                                    
                                    <div class="ms-2">
                                    <asp:Repeater ID="UsersRoleList" runat="server" OnItemDataBound="UsersRoleList_ItemDataBound">
                                        <ItemTemplate>
                                            <!--  -->
                                            <div class="mb-2">
                                                <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" 
                                                    OnCheckedChanged="RoleCheckBox_CheckChanged" 
                                                    CssClass="d-inline-block me-2" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                </div>
                                <!-- TAB 2: ROLES -->
                                <div id="panelRoles" class="tab-pane fade">
                                    <div class="mb-4">
                                        <label class="form-label fw-bold">Seleccione un Rol:</label>
                                        <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" 
                                            OnSelectedIndexChanged="RoleList_SelectedIndexChanged" CssClass="form-select">
                                        </asp:DropDownList>
                                    </div>                                    
                                    <div class="table-responsive">
                                        <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No hay usuarios asignados a este rol."
                                            OnRowDeleting="RolesUserList_RowDeleting" OnRowDataBound="RolesUserList_RowDataBound"
                                            CssClass="table table-striped table-bordered" UseAccessibleHeader="true">
                                            <Columns>
                                                <asp:CommandField DeleteText="Quitar" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger btn-sm" />
                                                <asp:TemplateField HeaderText="Usuarios">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="UserNameLabel"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>            
        </div>
    </section>
</asp:Content>