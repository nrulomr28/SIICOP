<%@ Page Title="Bienvenidos DGTSV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bienvenido_DGTSV.aspx.cs" Inherits="SIICOP_V1._2.Bienvenido_DGTSV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    <div class="row">
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
         <%--       <div class="item">
                    <img class="first-slide" runat="server" id="img1" src="~/Imagenes/Banner/Deporte_y_Cultura.jpg" alt="First slide">
                    <div class="container">
                        <div class="carousel-caption">
                            <h1>Escuela Segura</h1>

                        </div>
                    </div>
                </div>--%>
                <div class="item active">
                    <img class="second-slide" runat="server" id="img2" src="~/Imagenes/Banner/DGTSV/Banner_DGTSV.jpg" alt="Second slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>
             <%--   <div class="item">
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
                    <div class="carousel-caption">
                    </div>
                </div>--%>
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
   
    <hr  style="font-size:2.3em"/>
 
</asp:Content>
