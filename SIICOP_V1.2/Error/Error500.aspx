<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Error500.aspx.cs"
    Inherits="SIICOP_V1._2.Error.Error500" %>

<%@ Register Src="~/ControlesCompartidos/ErrorHeader.ascx"
    TagPrefix="uc"
    TagName="ErrorHeader" %>

<%@ Register Src="~/ControlesCompartidos/ErrorFooter.ascx"
    TagPrefix="uc"
    TagName="ErrorFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>SIICOP - Error interno</title>

    <link href="~/Content/Error.css"
      rel="stylesheet"
      runat="server" />

    <style>

              

        .codigo {
    font-size: 90px;
    font-weight: bold;
    color: #dc3545;
    margin: 0;
}

.info {
    margin-top: 30px;
    padding: 15px;
    background: #f8f9fa;
    border-left: 4px solid #dc3545;
    text-align: left;
    font-size: 14px;
    color: #555;
}
        

    </style>

</head>
<body>

<form id="form1" runat="server">

    <div class="contenedor">

        <uc:ErrorHeader
            ID="ErrorHeader1"
            runat="server" />

        <h1 class="codigo">500</h1>

        <div class="titulo">
            Ocurrió un error inesperado
        </div>

        <div class="mensaje">

            El sistema encontró una condición que impidió
            completar la operación solicitada.

            <br /><br />

            El incidente ha sido registrado y puede ser
            revisado por el área de soporte técnico.

        </div>

        <div class="info">

            <strong>¿Qué puede hacer?</strong>

            <ul>
                <li>Intentar nuevamente en unos minutos.</li>
                <li>Verificar que la información capturada sea correcta.</li>
                <li>Contactar al administrador si el problema persiste.</li>
            </ul>

        </div>

        <div class="botones">

            <a href="javascript:history.back();"
                class="btn btn-secondary">
                Regresar
            </a>

            <a href="~/Inicio/inicio_sesion.aspx"
                runat="server"
                class="btn btn-primary">
                Ir al inicio
            </a>

        </div>

        <uc:ErrorFooter
            ID="ErrorFooter1"
            runat="server" />

    </div>

</form>

</body>
</html>