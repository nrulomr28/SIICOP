<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio_sesion.aspx.cs" Inherits="SIICOP_V1._2.Inicio.inicio_sesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Inicio de sesión</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" />
    <link rel="stylesheet" runat="server" id="GeneralCss" href="~/Content/css/GeneralSSP.css" />

    <style>
        :root {
            /*COLOR PRINCIPAL ES VINO*/
            --color-principal: #7A1737;
            --color-principa80: rgb(122,23,55, .8);
            --color-principa60: rgb(122,23,55, .6);
            --color-principa40: rgb(122,23,55, .4);
            --color-principa20: rgb(122,23,55, .2);
            /*COLOR SECUNDARIO ES ROJO*/
            --color-secundario: #A8253C;
            --color-secundario80: rgb(168,37,60, .8);
            --color-secundario60: rgb(168,37,60, .6);
            --color-secundario40: rgb(168,37,60, .4);
            --color-secundario20: rgb(168,37,60, .2);

            /*COLOR DORADO*/
            --color-dorado: #B28854;
            --color-dorad80: rgb(178,136,84, .8);
            --color-dorad60: rgb(178,136,84, .6);
            --color-dorado40: rgb(178,136,84, .4);
            --color-dorad20: rgb(178,136,84, .2);

              /*COLOR BAGE*/
            --color-bage: #DAC195;
            --color-bage80: rgb(218,193,149, .8);
            --color-bage60: rgb(218,193,149, .6);
            --color-bage40: rgb(218,193,149, .4);
            --color-bage20: rgb(218,193,149, .2);

              /*COLOR MELON*/
            --color-melon: #EDD1AA;
            --color-melon80: rgb(237,209,170, .8);
            --color-melon60: rgb(237,209,170, .6);
            --color-melon40: rgb(237,209,170, .4);
            --color-melon20: rgb(237,209,170, .2);

             /*COLOR GRAFITO*/
            --color-grafito: #696968;
            --color-grafito80: rgb(105,105,104, .8);
            --color-grafito60: rgb(105,105,104, .6);
            --color-grafito40: rgb(105,105,104, .4);
            --color-grafito20: rgb(105,105,104, .2);

             /*COLOR GRIS*/
            --color-gris: #A8253C;
            --color-gris80: rgb(192,192,192, .8);
            --color-gris60: rgb(192,192,192, .6);
            --color-gris40: rgb(192,192,192, .4);
            --color-gris20: rgb(192,192,192, .2);
        }

        html {
            min-height: 100%;
            position: relative;
        }

        /*LOGIN*/
        .login-container {
    min-height: 80vh;
    display: flex;
    align-items: center;
    justify-content: center;
}


        /* Simple CSS3 Fade-in-down Animation */
        .fadeInDown {
            -webkit-animation-name: fadeInDown;
            animation-name: fadeInDown;
            -webkit-animation-duration: 1s;
            animation-duration: 1s;
            -webkit-animation-fill-mode: both;
            animation-fill-mode: both;
        }

        @-webkit-keyframes fadeInDown {
            0% {
                opacity: 0;
                -webkit-transform: translate3d(0, -100%, 0);
                transform: translate3d(0, -100%, 0);
            }

            100% {
                opacity: 1;
                -webkit-transform: none;
                transform: none;
            }
        }

        @keyframes fadeInDown {
            0% {
                opacity: 0;
                -webkit-transform: translate3d(0, -100%, 0);
                transform: translate3d(0, -100%, 0);
            }

            100% {
                opacity: 1;
                -webkit-transform: none;
                transform: none;
            }
        }

        /*FIN DEL LOGIN*/

        .text-titulo {
            color: var(--color-principal)
        }

        .btn-principal {
            color: white;
            background-color:  var(--color-principal)
        }

            .btn-principal:hover {
                color: white;
                background-color: var( --color-dorado)
            }

        .icono-c {
            color: var( --color-dorado)
        }


        /*FOOTER*/
        .footer {
            position: fixed;
            left: 0px;
            bottom: 0px;
            height: 20dvh;
            width: 100dvw;
            background-color: var(--color-principal);
        }

        .logo-card {
            /*width: 20dvw;*/
             width: 100%;
            object-fit: cover;
            object-position: bottom;
        }
        /*FIN FOOTER*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container login-container">
            <div class="row justify-content-center card-login ">
                <div class="col-8">
                    <div class="shadow p-3 mb-5 bg-body-tertiary rounded fadeInDown">
                        <div class="row">
                            <div class="col-md-6 ">
                                <img src="../Imagenes/SIICOP_2.png" class="logo-card" />
                            </div>
                            <div class="col-md-4 container text-center ">
                                <div class="row align-items-center">
                                    <h4 class="text-titulo">INICIAR SESIÓN</h4>
                                    <asp:Login ID="Login" runat="server" OnLoggedIn="Login_LoggedIn" OnAuthenticate="Login_Authenticate">
                                        <LayoutTemplate>
                                            <span style="color:red; font-weight:bold;">
                                                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                            </span>
                                            <!-- Login Form -->
                                            <div class="input-group flex-nowrap p-2">
                                                <span class="input-group-text" id="addon-wrapping"><i class="fas fa-user icono-c"></i></span>
                                                <asp:TextBox runat="server" ID="UserName" class="form-control" placeholder="Usuario" required autocomplete="off"> </asp:TextBox>
                                            </div>
                                            <div class="input-group flex-nowrap p-2">
                                                <span class="input-group-text" id="addon-wrapping"><i class="fas fa-lock icono-c"></i></span>
                                                <asp:TextBox runat="server" ID="Password" class="form-control" placeholder="Contraseña" TextMode="Password" required autocomplete="off"> </asp:TextBox>
                                            </div>


                                            <asp:Button ID="LoginButton" CommandName="Login" runat="server" class=" btn col-11 mx-auto btn-principal" ValidationGroup="Login1" Text="Ingresar" />


                                        </LayoutTemplate>
                                    </asp:Login>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="text-center fadeInDown">
                        <img class="avatar" src="~/Imagenes/SSP_Convivencia.png" runat="server" style="width: 40%" />

                    </div>

                </div>
            </div>

        </div>
        <footer class="footer card pt-2">
            <div class="container">
                <div class="row">

                    <div class="col-sm-12 col-md-12" style="color: white">
                        <p class="align-self-center text-center">Se prohíbe la reproducción total o parcial contenida en este sistema informático sin el consentimiento expreso y por escrito de la Secretaría de Seguridad Pública del Estado de Veracruz. Esta plataforma digital deberá ser utilizada únicamente por el personal autorizado. El acceso no autorizado a sistemas informáticos es un delito grave.. </p>
                        <p class="align-self-center text-center">
                            &copy; <%: DateTime.Now.Year %> - GOBIERNO DEL ESTADO DE VERACRUZ / SECRETARÍA DE SEGURIDAD PÚBLICA/ DERECHOS RESERVADOS.
                        </p>
                        <p class="align-self-center text-center">
                            VERACRUZ.GOB.MX
                        </p>
                    </div>
                </div>
            </div>
        </footer>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
    </form>
</body>
</html>
