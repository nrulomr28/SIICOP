<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SIICOP_V1._2.Inicio.Inicio" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/login.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css"  />
    <title>Inicio de sesión</title>
    <script src="<%= ResolveUrl("~/Scripts/sweetalert2.all.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        function error() {
            swal({
                title: "Error!",
                text: "El usuario y la contraseña no son correctos",
                icon: "error",
                button: "Aceptar",

            });
            return false
        }
    </script>
    <style>
        #logo {
            margin-left: 10px;
        }

        #logo2 {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server" ID="v"></asp:ScriptManager>
  
        <div class="container">
            <div class="row">
                <div class="wrapper fadeInDown">

                    <asp:Login ID="Login" runat="server" OnLoggedIn="Login_LoggedIn" OnAuthenticate="Login_Authenticate">
                        <LayoutTemplate>
                            <div id="formContent">
                                <br />
                                <!-- Tabs Titles -->
                                <!-- Icon -->
                                <div class="fadeIn first">
                                    <img src="../Imagenes/LogotipoSIICOP_2.jpg" style="display: block; width: 50%; margin: 10px auto;" />

                                </div>
                                <br />


                                <!-- Login Form -->
                                <asp:TextBox runat="server" ID="UserName" class="fadeIn second" placeholder=" Usuario" required autocomplete="off"> </asp:TextBox>
                                <br />
                                <asp:TextBox runat="server" ID="Password" CssClass="fadeIn second" placeholder=" Contraseña" TextMode="Password" required autocomplete="off"></asp:TextBox>
                                <br />
                                <asp:Button ID="LoginButton" CommandName="Login" runat="server" class="login100-form-btn btn-success pt-4" ValidationGroup="Login1" Text="Inicio de sesi&#243;n" />

                                <!-- Remind Passowrd -->

                                <div id="formFooter">
                                    <img class="avatar" src="~/Imagenes/Convivencia_Escudos.png" runat="server" style="width:100%"/>
                                </div>
                            </div>
                        </LayoutTemplate>
                    </asp:Login>

                </div>
            </div>
        </div>
        <br />
        <footer class="footer p-2  card" style="background-color: #AA983F;">
            <div class="container-fluid float-md-start">
                <div class="row">
                    <%--                    <div class=" col-sm-12 col-md-1">
                        <img src="../Images/veracruz_orgullo.png" id="escudo" width="100%" />
                    </div>--%>
                    <div class="col-sm-12 col-md-12" style="color: white">
                        <p class="align-self-center text-center">Se prohíbe la reproducción total o parcial contenida en este sistema informático sin el consentimiento expreso y por escrito de la Secretaría de Seguridad Pública de Estado de Veracruz. Esta plataforma digital deberá ser utilizada únicamente por el personal autorizado y debidamente certificado de esta Secretaría. Cualquier violación de la integridad del sistema será castigado severamente. </p>
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
    </form>
    <%--    <form id="form1" runat="server">

        <div class="container-fluid sin-padding-xs">
            <nav class="white sticky_nav" role="navigation">
                <div class="nav-wrapper container-fluid">
                    <div class="row">
                        <div class="col xl6 l6 m6 s12">
                            <a id="logo-container" href="#" class="hidden-xs">
                                <img src="http://www.veracruz.gob.mx/wp-content/uploads/2018/11/logo_veracruz.png" />
                            </a>
                            <a id="sublogo-container" href="#" class="logo-dependencia">
                                <img src="http://www.veracruz.gob.mx/seguridad/wp-content/uploads/sites/18/2018/11/ssp.png" />
                            </a>
                            <a id="sublogo-container-child" href="#" class="brand-sublogo hidden-xs">
                                <img src="http://www.veracruz.gob.mx/seguridad/wp-content/themes/veracruz2017/themefix/img/veracruz_orgullo.png" />
                            </a>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </nav>
        </div>
        <div style="background-image: url(../Imagenes/Loguin5.jpg) !important; background-repeat: no-repeat; width: 100%; background-position: 0% 0%;">
            <br />
            <br />
            <br />
            <br />


            <div class="container center-block">
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <asp:Login ID="Login" runat="server" OnLoggedIn="Login_LoggedIn" OnAuthenticate="Login_Authenticate">
                            <LayoutTemplate>
                                <div class="modal-dialog modal-login">

                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <img src="../Imagenes/Logo SIICOP.png" style="display: block; width: 50%; margin: 10px auto;" />

                                            <h4 class="modal-title">Inicio de sesión</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div action="#" method="post">
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" placeholder="Usuario" name="Usuario" type="UserName" required autofocus />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                                        <asp:TextBox runat="server" ID="Password" CssClass="form-control" placeholder="Contraseña" TextMode="Password" required autofocus />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <asp:Button runat="server" ID="Entrar" CssClass="btn btn-primary btn-block btn-lg" CommandName="Login" Text="Entrar" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </LayoutTemplate>
                        </asp:Login>
                    </div>
                    <div class="col-md-3"></div>
                </div>
            </div>

            <br />
            <br />
        </div>
        <div id="footer-content" class="back-footer">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-2 col-lg-2">
                        <div class="row mapa-sitio">
                            <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12 center">
                                <img src="http://www.veracruz.gob.mx/seguridad/wp-content/themes/veracruz2017/images/logo-footer.png" class="responsive-img center-block" />
                            </div>

                        </div>
                    </div>
                    <div class="col-lg-10 col-md-10 col-xs-12">
                        <p style="color: white">
                            Se prohíbe la reproducción total o parcial contenida en este sistema informático sin el consentimiento expreso y por escrito de la 
                                               Secretaría de Seguridad Pública del Estado de Veracruz.
                        Esta plataforma digital deberá ser utilizada unicamente por el personal autorizado y debidamente certificado de esta Secretaría. Cualquier violacion de la integridad del sistema será castigado severamente.
                        </p>
                        <p style="color: white">&copy; <%: DateTime.Now.Year %> GOBIERNO DEL ESTADO DE VERACRUZ / SECRETARÍA DE SEGURIDAD PÚBLICA DERECHOS RESERVADOS</p>
                    </div>
                    <div class="col-lg-2 col-md-2 col-xs-12">
                    </div>
                </div>
            </div>

            <div class="title-page-footer">
                <p>VERACRUZ<span class="gob-mx">.GOB.MX</span></p>
            </div>
            <div class="container-slider hidden-less-600">
                <div class="content-copyright">
                </div>
            </div>
        </div>

    </form>--%>
</body>

</html>

