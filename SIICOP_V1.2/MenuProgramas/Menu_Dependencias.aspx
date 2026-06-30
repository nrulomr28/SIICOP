<%@ Page Title="Menú de dependencias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_Dependencias.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.Menu_Dependencias" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <style>
        .contenedor {
            position: relative; /* permite superponer elementos */
            display: inline-block;
        }

            .contenedor .img-responsive {
                width: 100%;
                height: auto;
            }

        .titulo {
            position: absolute;
            top: 50%; /* centra verticalmente */
            left: 50%; /* centra horizontalmente */
            transform: translate(-50%, -50%);
            background-color: rgba(0,0,0,0.6); /* fondo negro semitransparente */
            color: #fff; /* texto blanco */
            padding: 15px 15px;
            border-radius: 6px;
            font-size: 28px;
            font-weight: bold;
            text-align: center;
        }
    </style>


    <br />
    <br />
    <div class="container">
        <div class="row">
            <article id="post-69889" class="post-69889 page type-page status-publish hentry">
                <div class="separator-container">
                    <h2 style="text-align: center;">Áreas adscritas</h2>
                </div>
                <div class="nota-contenido-page">

                    <div class="row ex1">

                        <div class="col-md-6 col-sm-6 text-center contenedor">
                            <asp:ImageButton ID="ImageButton5" runat="server"
                                ImageUrl="~/Imagenes/Menudependencia/DGVI.png"
                                CommandArgument=""
                                OnCommand="Imagen_Click" class="img-responsive img-thumbnail opacar" />
                            <h3 class="fw-bold titulo">DGPVI</h3>
                        </div>

                        <div class="visible-xs"></div>

                        <div class="col-md-6 col-sm-6 text-center contenedor">
                            <asp:ImageButton ID="ImageButton4" runat="server"
                                ImageUrl="~/Imagenes/Menudependencia/EstrategiadeSeguridad.jpg"
                                CommandArgument="Estrategia"
                                OnCommand="Imagen_Click" class="img-responsive img-thumbnail opacar" />
                            <%--<h3 class="fw-bold titulo">Estrategia Interinstitucional</h3>--%>
                        </div>


                     
                    </div>


                  

                    <div class="row ex1">
                    </div>



                </div>


                <!-- .entry-content -->
            </article>
            <!-- #post-## -->
        </div>
    </div>
    <br />
</asp:Content>
