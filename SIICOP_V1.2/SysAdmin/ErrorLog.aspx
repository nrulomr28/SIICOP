<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorLog.aspx.cs" Inherits="SIICOP_V1._2.SysAdmin.ErrorLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Errores SIICOP</title>
    <style>
        table
{
    width:100%;
    border-collapse:collapse;
}

table th
{
    background:#004b87;
    color:white;
    padding:8px;
}

table td
{
    padding:6px;
    border-bottom:1px solid #ddd;
}

    </style>
</head>
<body>
    <form id="formPrincipal" runat="server"> 
    <asp:TextBox ID="txtUsuario" runat="server" />

<asp:Button ID="btnBuscar"
            runat="server"
            Text="Buscar"
            OnClick="btnBuscar_Click" />

<asp:GridView ID="gvErrores"
              runat="server"
              AutoGenerateColumns="False"
              DataKeyNames="ErrorLogId" GridLines="None" CssClass="table"> 

    <Columns>

        <asp:BoundField
            DataField="Fecha"
            HeaderText="Fecha" />

        <asp:BoundField
            DataField="Usuario"
            HeaderText="Usuario" />

        <asp:BoundField
    DataField="ErrorType"
    HeaderText="Tipo Error">
    <ItemStyle Width="180px" />
</asp:BoundField>

        <asp:BoundField
            DataField="Pagina"
            HeaderText="Página" />

        <asp:BoundField
    DataField="Mensaje"
    HeaderText="Mensaje">
    <ItemStyle Width="600px" />
</asp:BoundField>

        <asp:TemplateField HeaderText="Detalle">

    <ItemTemplate>

        <asp:LinkButton
            ID="lnkDetalle"
            runat="server"
            CommandArgument='<%# Eval("ErrorLogId") %>'
            OnClick="lnkDetalle_Click"
            Text="Ver" />

    </ItemTemplate>

</asp:TemplateField>

    </Columns>

</asp:GridView>


        <asp:Panel ID="pnlDetalle"
           runat="server"
           Visible="false">

    <h3>Detalle del Error</h3>

    <asp:Label ID="lblFecha" runat="server" />
    <br />

    <asp:Label ID="lblUsuario" runat="server" />
    <br />

    <asp:Label ID="lblPagina" runat="server" />
    <br />

    <asp:Label ID="lblTipoError" runat="server" />
    <br />

    <asp:TextBox ID="txtStackTrace"
                 runat="server"
                 TextMode="MultiLine"
                 Rows="15"
                 Width="100%"
                 ReadOnly="true" />

</asp:Panel>

        </form>
</body>
</html>
