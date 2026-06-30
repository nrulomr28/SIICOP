<%@ Page Title="Bienvenidos DGPRS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bienvenido_DGPRS.aspx.cs" Inherits="SIICOP_V1._2.Bienvenido_DGPRS" %>
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
               
            </ol>
            <div class="carousel-inner" role="listbox">
             <div class="item active">
                    <img class="second-slide" runat="server" id="img2" src="~/Imagenes/Banner/DGPRS/Impulsando_prevencion_educa.jpg" alt="Second slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>
                <div class="item">
                    <img class="third-slide" runat="server" id="img3" src="~/Imagenes/Banner/DGPRS/Motivando_reinsercion_social.jpg" alt="Third slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
                    </div>
                </div>

                <div class="item">
                    <img class="third-slide" runat="server" id="img4" src="~/Imagenes/Banner/DGPRS/prevencion_atraves_info.jpg" alt="Third slide">
                    <div class="container">
                        <div class="carousel-caption">
                        </div>
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
   
    <hr  style="font-size:2.3em"/>
</asp:Content>
