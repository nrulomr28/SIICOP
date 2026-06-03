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

        body {
            margin: 0;
            padding: 0;
            font-family: Segoe UI, Arial, sans-serif;
            background-color: #f5f7fa;
        }

        .contenedor {
            max-width: 850px;
            margin: 80px auto;
            background: white;
            border-radius: 10px;
            padding: 40px;
            text-align: center;
            box-shadow: 0 2px 12px rgba(0,0,0,.10);
        }

        .codigo {
            font-size: 90px;
            font-weight: bold;
            color: #dc3545;
            margin: 0;
        }

        .titulo {
            font-size: 30px;
            color: #333;
            margin-top: 10px;
        }

        .mensaje {
            font-size: 18px;
            color: #666;
            margin-top: 20px;
            line-height: 1.7;
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

        .botones {
            margin-top: 35px;
        }

        .btn {
            display: inline-block;
            padding: 12px 25px;
            margin: 5px;
            text-decoration: none;
            border-radius: 5px;
            font-weight: bold;
        }

        .btn-primary {
            background-color: #004b87;
            color: white;
        }

        .btn-primary:hover {
            background-color: #00345d;
        }

        .btn-secondary {
            background-color: #6c757d;
            color: white;
        }

        .btn-secondary:hover {
            background-color: #565e64;
        }
        

    </style>

</head>
<body>

<form id="form1" runat="server">

    <div class="contenedor">

        <div class="sistema">
            SIICOP
            <br />
            <span style="font-size:14px;font-weight:normal;">
                Sistema Integral de Control Operativo de Planteles
            </span>
        </div>

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

        <div class="footer">
            Código de error: 500 - Internal Server Error
        </div>

    </div>

</form>

</body>
</html>