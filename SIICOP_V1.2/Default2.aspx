<%@ Page Title="Bienvenido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="SIICOP_V1._2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <script src="<%= ResolveUrl("~/Scripts/sweetalert2.all.js") %>" type="text/javascript"></script>
    <link href="Content/BotonoesCargaTrabajo.css" rel="stylesheet" />
        <script type="text/javascript">
            function error() {
                swal({
                    title: "Error!",
                    text: "Hubo un error",
                    icon: "error",
                    button: "Aceptar",

                });
                return false
            }
    </script>
    <style>
        body {
            padding-top: 140px;
            padding-bottom: 20px;
        }
    </style>
    <div class="row"  style="padding-top:1%">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <%--<li data-target="#myCarousel" data-slide-to="0" class=""></li>--%>
                <li data-target="#myCarousel" data-slide-to="1" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="2" class=""></li>
                <li data-target="#myCarousel" data-slide-to="3" class=""></li>
                <li data-target="#myCarousel" data-slide-to="4" class=""></li>
                <li data-target="#myCarousel" data-slide-to="5" class=""></li>
                <li data-target="#myCarousel" data-slide-to="6" class=""></li>
            </ol>
            <div class="carousel-inner" role="listbox">
                <div class="item">
                    <img class="first-slide" runat="server" id="img1" src="~/Imagenes/Banner/Deporte_y_Cultura.jpg" alt="First slide">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>Escuela Segura</h1>

                        </div>
                    </div>
                </div>
                <div class="item active">
                    <img class="second-slide" runat="server" id="img2" src="~/Imagenes/Banner/Entornos_Educativos.jpg" alt="Second slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img class="third-slide" runat="server" id="img3" src="~/Imagenes/Banner/Redes_Vecinales.jpg" alt="Third slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>

                <div class="item">
                    <img class="third-slide" runat="server" id="img4" src="~/Imagenes/Banner/Sector_Empresarial.jpg" alt="Third slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img class="third-slide" runat="server" id="img5" src="~/Imagenes/Banner/Violencia.jpg" alt="Third slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img class="third-slide" runat="server" id="img6" src="~/Imagenes/Banner/Inclusion.jpg" alt="Third slide">
                    <%--<div class="container">--%>
                    <div class="carousel-caption">
                    </div>
                </div>
            </div>
        </div>
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <br />
    <div class="row" style="margin-right: 0px !important; margin-left:  0px !important;">
        <div id="resultadosADMIN" runat="server" visible="false">
            <div class="col-md-12">
                <div class="row">
                    <h4 style="text-align: center">ACCIONES Y BENEFICIADOS DEL MES DE: <strong runat="server" id="MesActividdesGral" style="color: forestgreen"></strong></h4>
                    <div class="col-md-12">
                        <div class="row">
                            <%-- EMPRESARIAL --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                <div class="card border-danger ">
                                    <div class="card-body">
                                        <h4 class="card-title" style="color: #932E2F !important; text-align: center; PADDING-TOP: 23px;"><strong>Enlace con el Sector Empresarial</strong></h4>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="social-box ">
                                                    <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="ArribaEmpreAccion" style="color: green" visible="false"></i>
                                                    <i class="fas fa-arrow-down" runat="server" id="abajoaEmpreAccion" style="color: red" visible="false"></i>
                                                    <i class="fas fa-window-minimize" runat="server" id="medioEmpreAccion" style="color: yellow" visible="false"></i>
                                                    <br />
                                                    <strong>ACCIONES</strong>
                                                    <ul>
                                                        <li>
                                                            <strong><span class="count" runat="server" id="spanAccionEmpreObje" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                                <br />
                                                                <span>META</span>
                                                            </strong>
                                                        </li>
                                                        <li>
                                                            <strong><span class="count" runat="server" id="SpanAccionEmpreObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                                <br />
                                                                <span>OBTENIDOS</span>
                                                            </strong>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="social-box ">
                                                    <i class="fas fa-users" id="I43" runat="server"></i>&nbsp;
                                                                  <br />
                                                    <strong>BENEFICIADOS</strong>
                                                    <ul>
                                                        <li>
                                                            <strong><span class="count" runat="server" id="BeneficiadosEmpreObje" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                                <br />
                                                                <span>META</span>
                                                            </strong>
                                                        </li>
                                                        <li>
                                                            <strong><span class="count" runat="server" id="BeneficiadosEmpreObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                                <br />
                                                                <span>OBTENIDOS</span>
                                                            </strong>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- -------------------------------------------- --%>

                            <%-- Seguridad Ciudadana y Paz Social en Entornos Educativos  --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                    <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #AA1D74 !important; text-align: center;PADDING-TOP: 23px;"><strong>Seguridad Ciudadana y Paz Social en Entornos Educativos </strong></h4>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="ArribaEscoAccion" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="AbajoEscoAccion" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="mediEscoAccion" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesEscolarOBJ" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesEscolarOBT" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>m
                                        </div>

                                    </div>
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I55" runat="server"></i>&nbsp;
                                                                   <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosEscolarOBJ" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosEscolarOBT" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                        </div>
                            </div>
                            <%-- -------------------------------------------- --%>

                            <%-- Redes vecinales --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                    <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #1D8DC6 !important; text-align: center;PADDING-TOP: 23px;"><strong>Redes vecinales</strong></h4>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="ArribaRedesAccion" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="AbajoRedesAccion" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="MedioRedesAccion" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesRedesObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesRedesObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I63" runat="server"></i>&nbsp;
                                                                   <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosRedesObj" style="text-align: center; color: forestgreen; font-size: 1.2em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosRedesObt" style="text-align: center; color: forestgreen; font-size: 1.2em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                        </div>
                            </div>
                            <%-- -------------------------------------------- --%>
                        </div>
                        <div class="row">
                            <%-- Fomento a la Prevención a través del Deporte y la Cultura  --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                    <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #D6C42E !important; text-align: center;PADDING-TOP: 23px;"><strong>Fomento a la Prevención a través del Deporte y la Cultura</strong></h4>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="ArribaDeporteAccion" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="AbajoDeporteAccion" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="MedioDeporteAccion" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesDeportesObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesDeportesObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I4" runat="server"></i>&nbsp;
                                                                   <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosDeportesObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosDeportesObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                        </div>
                            </div>
                            <%-- -------------------------------------------- --%>

                            <%-- Prevención de la Violencia por Razones de Género  --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #306233 !important; text-align: center;PADDING-TOP: 23px;"><strong>Prevención de la Violencia por Razones de Género</strong></h4>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="ArribaGeneroAccion" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="AbajoGeneroAccion" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="MedioGeneroAccion" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesGeneroObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesGeneroObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>

                                    </div>
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I11" runat="server"></i>&nbsp;
                                                                 <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosGeneroObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosGeneroObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- -------------------------------------------- --%>
                           
                            <%-- Construción de una cultura incluyente  --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #6B5027 !important; text-align: center;PADDING-TOP: 23px;"><strong>Construción de una cultura incluyente</strong></h4>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="ArribaIgualdadAccion" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="AbajoIgualdadAccion" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="MedioIgualdadAccion" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesIgualdadObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesIgualdadObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I18" runat="server"></i>&nbsp;
                                           
                                            <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosIgualdadObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosIgualdadObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                        </div>
                             </div>
                            </div>
                            <%-- -------------------------------------------- --%>
                        </div>

                        <div class="row">
                                <%-- Prevención de la Violencia por Razones de Género  --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #0141f1 !important; text-align: center;PADDING-TOP: 23px;"><strong>Redes Veracruzanas en la Construcción de la Paz</strong></h4>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="ArribaIRedesVerPazAccion" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="AbajoRedesVerPazAccion" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="MedioRedesVerPazAccion" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesRedesVerPazObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanAccionesRedesVerPazObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>

                                    </div>
                                    <div class="col-md-6">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I7" runat="server"></i>&nbsp;
                                                                 <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosRedesVerPazObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="SpanBeneficiadosRedesVerPazobt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- -------------------------------------------- --%>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </div>

    <div class="row">
        <div id="DivForaneos" runat="server" visible="false">
            <div class="col-md-12">
                <div class="row">
                    <h4 style="text-align: center">ACCIONES Y BENEFICIADOS DEL MES DE: <strong runat="server" id="MesForaneo" style="color: forestgreen"></strong></h4>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #932E2F !important; text-align: center;PADDING-TOP: 23px;""><strong>Enlace con el Sector Empresarial</strong></h4>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="spanArribaForaEmpre" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="spaAbajoForaEmpre" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="spanMedioForaEmpre" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoEmpreObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoEmpreObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I6" runat="server"></i>&nbsp;
                                                                  <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeniPordiaEMpreObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeniPordiaEMpreObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I29" runat="server"></i>&nbsp;
                                                                  <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeniTotalEmpreObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeniTotalEmpreObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- salto --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #AA1D74 !important; text-align: center;PADDING-TOP: 23px;""><strong>Seguridad Ciudadana y Paz Social en Entornos Educativos </strong></h4>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="spanArribaForaESCO" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="spanAbajoForaESCO" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="spanMedioForaESCO" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoEscoObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoEscoObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>

                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I10" runat="server"></i>&nbsp;
                                                                   <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiasForaneoEscoObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiasForaneoEscoObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I30" runat="server"></i>&nbsp;
                                                                  <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneoEscoObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneoEscoObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- salto --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #1D8DC6 !important; text-align: center;PADDING-TOP: 23px;""><strong>Redes vecinales</strong></h4>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="spanArribaForaRedes" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="spanAbajoForaRedes" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="spanMedioForaRedes" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoRedesObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoRedesObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I15" runat="server"></i>&nbsp;
                                                                   <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiasForaneoRedesObj" style="text-align: center; color: forestgreen; font-size: 1.2em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiasForaneoRedesObt" style="text-align: center; color: forestgreen; font-size: 1.2em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I31" runat="server"></i>&nbsp;
                                                                  <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneoRedObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneRedoObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- salto --%>
                        </div>
                        <divConstrución de una cultura incluyente class="row">
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #D6C42E !important; text-align: center;PADDING-TOP: 23px;""><strong>Fomento a la Prevención a través del Deporte y la Cultura</strong></h4>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="spanArribaForaDeporte" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="spanAbajoForaDeporte" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="spanMinibForaDeporte" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoDeporteObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoDeporteObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I20" runat="server"></i>&nbsp;
                                                                   <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiasForaneoDeportesObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiasForaneoDeportesObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I32" runat="server"></i>&nbsp;
                                                                  <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneoDEObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneoDEObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- salto --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #306233 !important; text-align: center;PADDING-TOP: 23px;""><strong>Prevención de la Violencia por Razones de Género</strong></h4>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="spanArribaForaGenero" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="spanAbajoaForaGenero" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="spanMedioForaGenero" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoGneroObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAcionesForaneoGneroObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>

                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I24" runat="server"></i>&nbsp;
                                                                 <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiaForaneoGneroObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosXdiaForaneoGneroObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I33" runat="server"></i>&nbsp;
                                                                  <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneoGneroObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeneficiadosForaneoGneroObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- salto --%>
                            <div class="col-lg-4 col-md-4 col-xs-12">
                                 <div class="card border-danger ">
                                    <div class="card-body">
                                <h4 class="card-title" style="color: #6B5027 !important; text-align: center;PADDING-TOP: 23px;""><strong>Inclusión de personas en situación de vunerabilidad</strong></h4>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-file-invoice"></i>&nbsp;
                                            <i class="fas fa-arrow-up" runat="server" id="spanArribaForaIgualdad" style="color: green" visible="false"></i>
                                            <i class="fas fa-arrow-down" runat="server" id="spanAbajoForaIgualdad" style="color: red" visible="false"></i>
                                            <i class="fas fa-window-minimize" runat="server" id="spanMedioForaIgualdad" style="color: yellow" visible="false"></i>
                                            <br />
                                            <strong>ACCIONES</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoIgualdadObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanAccionesForaneoIgualdadObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I28" runat="server"></i>&nbsp;
                                           
                                            <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeniXidaForaneoIgualdadObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBeniXidaForaneoIgualdadObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="social-box ">
                                            <i class="fas fa-users" id="I34" runat="server"></i>&nbsp;
                                                                  <br />
                                            <strong>BENEFICIADOS</strong>
                                            <ul>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBenificiadosForaneoIgualdadObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>META</span>
                                                    </strong>
                                                </li>
                                                <li>
                                                    <strong><span class="count" runat="server" id="spanBenificiadosForaneoIgualdadObt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                        <br />
                                                        <span>OBTENIDOS</span>
                                                    </strong>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                </div>
                                        </div>
                                     </div>
                            </div>
                            <%-- salto --%>
                        </divConstrución>
                    </div>
                </div>

            </div>
        </div>

    </div>
    <div class="row">
        <div id="resultadoPorAREA" runat="server" visible="false">
            <div class="col-md-4"> 
                <div class="card">
                       <div class="card-body">
                <div class="row">
                    <h4 style="text-align: center">ACCIONES Y BENEFICIADOS EN GENERAL POR PROGRAMA DEL MES DE:<strong runat="server" id="mes" style="color: forestgreen"></strong> </h4>
                    <div class="col-lg-6 col-md-6">
                        <div class="social-box ">
                            <i class="fas fa-file-invoice"></i>&nbsp;
                          <i class="fas fa-arrow-up" runat="server" id="arribaac" style="color: green" visible="false"></i>
                            <i class="fas fa-arrow-down" runat="server" id="abajoac" style="color: red" visible="false"></i>
                            <i class="fas fa-window-minimize" runat="server" id="medioac" style="color: yellow" visible="false"></i>
                            <br />
                            <strong>ACCIONES</strong>
                            <ul>
                                <li>
                                    <strong><span class="count" runat="server" id="accionesObj" style="color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>META</span>
                                    </strong>

                                </li>fen
                                <li>
                                    <strong><span class="count" runat="server" id="accionesdia" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>OBTENIDOS</span>
                                    </strong>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="col-lg-6 col-md-6">
                        <div class="social-box ">
                            <i class="fas fa-users" id="user" runat="server"></i>&nbsp;
                      
                            <br />
                            <strong>BENEFICIADOS</strong>
                            <ul>
                                <li>
                                    <strong><span class="count" runat="server" id="beniObj" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>META</span>
                                    </strong>
                                </li>
                                <li>
                                    <strong><span class="count" runat="server" id="aldiabeni" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>OBTENIDOS</span>
                                    </strong>
                                </li>
                            </ul>
                        </div>

                    </div>
                   </div>
                </div>
                </div>
            </div>
            <div class="col-md-8">
                  <div class="card">
                       <div class="card-body">
                <div class="row">
                    <h4 style="text-align: center">DISTRIBUCIÓN DE CARGA DE TRABAJO POR DELEGACIÓN O COORDINACION DE: <strong runat="server" id="StrongCordinacion" style="color: forestgreen; font-size: 1.1em"></strong>DEL MES DE: <strong runat="server" id="StrongMesCaraga" style="color: forestgreen; font-size: 1.1em"></strong></h4>
                    <div class="col-lg-4 col-md-4">
                        <div class="social-box ">
                            <i class="fas fa-file-invoice"></i>&nbsp;
                          <i class="fas fa-arrow-up" runat="server" id="ArribagralAccion" style="color: green" visible="false"></i>
                            <i class="fas fa-arrow-down" runat="server" id="AbajoagralAccion" style="color: red" visible="false"></i>
                            <i class="fas fa-window-minimize" runat="server" id="mediogralAccion" style="color: yellow" visible="false"></i>
                            <br />
                            <strong>TOTAL DE ACCIONES POR MES<strong runat="server" id="Strong2" style="color: forestgreen"></strong></strong>
                            <ul>
                                <li>
                                    <strong><span class="count" runat="server" id="spanAccionXareaObje" style="color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>META</span>
                                    </strong>

                                </li>
                                <li>
                                    <strong><span class="count" runat="server" id="spanAccionXareaObjt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>OBTENIDOS</span>
                                    </strong>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="social-box ">
                            <i class="fas fa-users" id="I1" runat="server"></i>&nbsp;
                      
                            <br />
                            <strong>BENEFICIADOS POR ACCIÓN</strong>
                            <ul>
                                <li>
                                    <strong><span class="count" runat="server" id="spanBeniXaccionXareaObje" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>META</span>
                                    </strong>
                                </li>
                                <li>
                                    <strong><span class="count" runat="server" id="spanBeniXaccionXareaObjt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>OBTENIDOS</span>
                                    </strong>
                                </li>
                            </ul>
                        </div>

                    </div>
                    <div class="col-lg-4 col-md-4">
                        <div class="social-box ">
                            <i class="fas fa-users"></i>&nbsp;
                      
                            <br />
                            <strong>TOTAL DE BENEFICIADOS POR MES</strong>
                            <ul>
                                <li>
                                    <strong><span class="count" runat="server" id="spanBeniTotalXareaObje" style="color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>META</span>
                                    </strong>

                                </li>
                                <li>
                                    <strong><span class="count" runat="server" id="spanBeniTotalXareaObjt" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                        <br />
                                        <span>OBTENIDOS</span>
                                    </strong>
                                </li>
                            </ul>
                        </div>
                    </div>
                    </div>
                </div>
                      </div>
            </div>
        </div>
</div>    
    <hr  style="font-size:2.3em"/>
 
</asp:Content>
