<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ControlRoles.aspx.cs" Inherits="SIICOP_V1._2.SysAdmin.ControlRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
   <script type="text/javascript">
       $(document).ready(function () {
           // Inicializa las pestañas de Bootstrap 3 (que es la versión que usa tu Site.Master)
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
        <div>
            <!-- MAIN CONTENT CONTAINER -->
            <div class="container">       
                <div class="row-fluid">
                    <hr class="half">
                    <h2 class="center standart-h2title "><span class="large-text"><span class="main-color">Administración <span></span></span>de usuarios y roles</span>
                    </h2>
                </div>
                <div class="marketing">
                    <hr class="half">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="well">
                                <p align="center">
                                    <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label>
                                </p>
                                <!-- HeaderCssClass="accordionHeader" -->
                    <%--            <p>Agregar Rol</p>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar Rol" />
                                <br />--%>
                               <%-- <ajaxToolkit:Accordion ID="Accordion1" runat="server"
                                    HeaderSelectedCssClass="accordionHeaderSelected" AutoSize="None" FadeTransitions="true"
                                    TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true"
                                    SelectedIndex="-1" Visible="false">
                                    <Panes>
                                        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" HeaderCssClass="accordionHeader"
                                            HeaderSelectedCssClass="accordionHeaderSelected">
                                            <Header>Administrar por Usuarios</Header>
                                            <Content>
                                            </Content>
                                        </ajaxToolkit:AccordionPane>
                                        <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" HeaderCssClass="accordionHeader"
                                            HeaderSelectedCssClass="accordionHeaderSelected">
                                            <Header>Administrar por Roles</Header>
                                            <Content>
                                            </Content>
                                        </ajaxToolkit:AccordionPane>
                                    </Panes>
                                </ajaxToolkit:Accordion>--%>
               



                               <ul class="nav nav-tabs" id="myRoleTabs">
                                    <li class="active"><a data-toggle="tab" href="#panelUsuarios">Usuarios</a></li>
                                    <li><a data-toggle="tab" href="#panelRoles">Roles</a></li>
                                </ul>

                                <div class="tab-content">
                              
                                    <div id="panelUsuarios" class="tab-pane fade in active">
                                        <br />
                                        <div class="form-group">
                                        <b>Seleccione el Usuario:</b>
                                        <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" 
                                            DataTextField="UserName" DataValueField="UserName" 
                                            OnSelectedIndexChanged="UserList_SelectedIndexChanged" CssClass="form-control">
                                        </asp:DropDownList>
                                        <br /><br />
                                            </div>
                                        <asp:Repeater ID="UsersRoleList" runat="server" OnItemDataBound="UsersRoleList_ItemDataBound">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" 
                                                    OnCheckedChanged="RoleCheckBox_CheckChanged" />
                                                <br />
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <div id="panelRoles" class="tab-pane fade">
                                        <br />
                                        <b>Seleccione un Rol:</b>
                                        <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" 
                                            OnSelectedIndexChanged="RoleList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <br /><br />
                                        <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No users belong to this role."
                                            OnRowDeleting="RolesUserList_RowDeleting" OnRowDataBound="RolesUserList_RowDataBound">
                                            <Columns>
                                                <asp:CommandField DeleteText="Quitar" ShowDeleteButton="True" />
                                                <asp:TemplateField HeaderText="Usuarios">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="UserNameLabel"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <br />
                                       <%-- <b>Buscar Usuario:</b>
                                        <asp:TextBox ID="UserNameToAddToRole" runat="server"></asp:TextBox>
                                        <asp:Button ID="AddUserToRoleButton" runat="server" Text="Agregar al rol" 
                                            OnClick="AddUserToRoleButton_Click" CssClass="boton" />--%>
                                    </div>
                                </div>




                      <%--          <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Usuarios" ID="TabPanel1">
                                        <ContentTemplate>
                                            <p>
                                                <b>Seleccione el Usuario :</b>
                                                <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" DataTextField="UserName"
                                                    DataValueField="UserName" OnSelectedIndexChanged="UserList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </p>
                                             <p>                                           
                                                <asp:Repeater ID="UsersRoleList" runat="server" OnItemDataBound="UsersRoleList_ItemDataBound">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" 
                                                        OnCheckedChanged="RoleCheckBox_CheckChanged" />
                                                    <br />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            </p>
                                        </ContentTemplate>

                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Roles">
                                        <ContentTemplate>
                                            <p>
                                                <b>Seleccione un Rol:</b>
                                                <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RoleList_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </p>
                                            <p>        
                                                <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="False" EmptyDataText="No users belong to this role."
                                                    OnRowDeleting="RolesUserList_RowDeleting" OnRowDataBound="RolesUserList_RowDataBound">
                                                    <Columns>
                                                        <asp:CommandField DeleteText="Quitar" ShowDeleteButton="True" />
                                                       <asp:TemplateField HeaderText="Usuarios">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="UserNameLabel"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </p>
                                            <p>
                                                <b>Buscar Usuario:</b>
                                                <asp:TextBox ID="UserNameToAddToRole" runat="server"></asp:TextBox>
                                                <br />
                                                <asp:Button ID="AddUserToRoleButton" runat="server" Text="Agregar al rol" OnClick="AddUserToRoleButton_Click"
                                                CssClass="boton" />
                                            </p>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>--%>

                            </div>
                        </div>
                    </div>
                    <!-- END CALL TO ACTION -->
                    <hr class="half">
                </div>
                <!--- CLIENTS ROTATOR ## -->
        </div>
        </div>
    </section>
</asp:Content>
