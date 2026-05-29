<%@ Page Title="Menú de dependencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_2026.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.Menu_Dependencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="row">
            <article id="post-69889" class="post-69889 page type-page status-publish hentry">
                <div class="separator-container">
                    <h2 style="text-align: center;">Áreas adscritas</h2>
                </div>
                <div class="nota-contenido-page">
                    <div class="row ex1">
                        <div class="col-md-4 col-sm-4">
                            <a runat="server" href="MenuProgramasEn.aspx">
                                <img runat="server" src="~/Imagenes/Menudependencia/DVI.jpg" class="img-responsive img-thumbnail opacar"></a>
                        </div>
                        <div class="visible-xs"></div>
                        <div class="col-md-4 col-sm-4">
                            <a runat="server" href="~/MenuProgramas/C4/Programas_C4.aspx" target="_blank">
                                <img runat="server" src="~/Imagenes/Menudependencia/C4.jpg" class="img-responsive img-thumbnail opacar"></a>
                        </div>
                        <div class="visible-xs"></div>
                        <div class="col-md-4 col-sm-4">
                            <a href="DGPRS/Programas_DGPRS.aspx" target="_blank">
                                <img runat="server" src="~/Imagenes/Menudependencia/DGPRS.jpg" class="img-responsive img-thumbnail opacar"></a>
                        </div>
                    </div>
                    <div class="row ex1">
                        <div class="col-md-4 col-sm-4">
                            <%--<a href="#" target="_blank">--%>
                            <asp:LinkButton runat="server" OnClick="lnkbtnDGTVS_Click" id="lnkbtnDGTVS">
                             <img runat="server" src="~/Imagenes/Menudependencia/DGTV.jpg" class="img-responsive img-thumbnail opacar">
                            </asp:LinkButton>
                            <%--</a>--%>
                        </div>
                        <div class="visible-xs"></div>
                        <div class="col-md-4 col-sm-4">
                            <a runat="server" href="/MenuProgramas/CREPREVIDE/Programa_CEPREVIDE.aspx" target="_blank">
                                <img runat="server" src="~/Imagenes/Menudependencia/CEPREVIDE.jpg" class="img-responsive img-thumbnail opacar"></a>
                        </div>
                        <div class="visible-xs"></div>
                        <div class="col-md-4 col-sm-4">
                            <a runat="server" href="~/MenuProgramas/SESCESP/Programas_SESCESP.aspx" target="_blank">
                                <img runat="server" src="~/Imagenes/Menudependencia/SES.jpg" class="img-responsive img-thumbnail opacar"></a>
                        </div>
                    </div>


                </div>
                <!-- .entry-content -->
            </article>
            <!-- #post-## -->
        </div>
    </div>
</asp:Content>
