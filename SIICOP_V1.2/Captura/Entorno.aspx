<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entorno.aspx.cs" Inherits="SIICOP_V1._2.Captura.Entorno" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />


    <div class="container text-center">

        <h2>Entorno</h2>

        <div class="d-flex justify-content-center mt-5">

            <asp:Button
                ID="btnEscolar"
                runat="server"
                Text="Entorno Escolar"
                CssClass="btn btn-primary btn-lg px-5 py-4 me-5" OnClick="btnEscolar_Click" />

            <asp:Button
                ID="btnComunitario"
                runat="server"
                Text="Entorno Comunitario"
                CssClass="btn btn-primary btn-lg px-5 py-4 ms-5" OnClick="btnComunitario_Click" />

        </div>

    </div>

    <br />
    <br />



</asp:Content>
