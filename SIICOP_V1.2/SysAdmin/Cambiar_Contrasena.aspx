<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cambiar_Contrasena.aspx.cs" Inherits="SIICOP_V1._2.SysAdmin.Cambiar_Contrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <section class="col-md-15 col-xs-6">
            <table class="container">
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="lblUsuario" runat="server" Text="USUARIO A MODIFICAR:" />
                        <br />
                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="NUEVA CONTRASEÑA:" />
                        <br />
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" OnClick="btnCambiar_Click"  /></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </section>
    </div>


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
