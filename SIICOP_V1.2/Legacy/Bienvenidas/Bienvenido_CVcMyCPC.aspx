<%@ Page Title="Bienvenidos SESCESP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bienvenido_CVcMyCPC.aspx.cs" Inherits="SIICOP_V1._2.Bienvenido_CVcMyCPC" %>
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
           
            </ol>
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img class="first-slide" runat="server" id="img1" src="~/Imagenes/Banner/CVcMyCPC/Banner_Consejo-01.jpg" alt="First slide">
                    <div class="container">
                        <div class="carousel-caption">

                        </div>
                    </div>
                </div>
                <div class="item ">
                    <img class="second-slide" runat="server" id="img2" src="~/Imagenes/Banner/CVcMyCPC/Banner_Consejo-02.jpg" alt="Second slide">
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
