<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Error404.aspx.cs"
    Inherits="SIICOP_V1._2.Error.Error404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>SIICOP - Página no encontrada</title>

    <style>

        body {
            margin: 0;
            padding: 0;
            font-family: Segoe UI, Arial, sans-serif;
            background-color: #f5f7fa;
        }

        .contenedor {
            max-width: 800px;
            margin: 80px auto;
            background: white;
            border-radius: 10px;
            padding: 40px;
            text-align: center;
            box-shadow: 0 2px 12px rgba(0,0,0,.10);
        }

        .codigo {
            font-size: 100px;
            font-weight: bold;
            color: #d9534f;
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
            line-height: 1.6;
        }

        .sistema {
            margin-bottom: 30px;
            color: #004b87;
            font-size: 22px;
            font-weight: 600;
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
            transition: .2s;
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

        .footer {
            margin-top: 40px;
            font-size: 12px;
            color: #999;
        }

    </style>

</head>
<body>

    <form id="form1" runat="server">

        <div class="contenedor">

            <div class="sistema">
                SIICOP
            </div>

            <h1 class="codigo">404</h1>

            <div class="titulo">
                Página no encontrada
            </div>

            <div class="mensaje">

                La página que intenta consultar no existe,
                fue movida o la dirección es incorrecta.

                <br /><br />

                Verifique la dirección o regrese al sistema.

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
                Sistema Integral de Control Operativo de Planteles
            </div>

        </div>

    </form>

</body>
</html>