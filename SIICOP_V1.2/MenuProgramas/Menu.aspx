<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


       <style>
       /* FontAwesome for working BootSnippet :> */

       @import url('https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css');

       #team {
           background: #eee !important;
       }

       .btn-primary:hover,
       .btn-primary:focus {
           background-color: #108d6f;
           border-color: #108d6f;
           box-shadow: none;
           outline: none;
       }

       .btn-primary {
           color: #fff;
           background-color: #007b5e;
           border-color: #007b5e;
       }

       section {
           padding: 60px 0;
       }

       section .section-title {
               text-align: center;
               color: #007b5e;
               margin-bottom: 50px;
               text-transform: uppercase;
       }

       #team .card {
           border: none;
           background: #ffffff;
       }

       .image-flip:hover .backside,
       .image-flip.hover .backside {
           -webkit-transform: rotateY(0deg);
           -moz-transform: rotateY(0deg);
           -o-transform: rotateY(0deg);
           -ms-transform: rotateY(0deg);
           transform: rotateY(0deg);
           border-radius: .25rem;
       }

       .image-flip:hover .frontside,
       .image-flip.hover .frontside {
           -webkit-transform: rotateY(180deg);
           -moz-transform: rotateY(180deg);
           -o-transform: rotateY(180deg);
           transform: rotateY(180deg);
       }

       .mainflip {
           -webkit-transition: 1s;
           -webkit-transform-style: preserve-3d;
           -ms-transition: 1s;
           -moz-transition: 1s;
           -moz-transform: perspective(1000px);
           -moz-transform-style: preserve-3d;
           -ms-transform-style: preserve-3d;
           transition: 1s;
           transform-style: preserve-3d;
           position: relative;
       }

       .frontside {
           position: relative;
           -webkit-transform: rotateY(0deg);
           -ms-transform: rotateY(0deg);
           z-index: 2;
           margin-bottom: 30px;
       }

       .backside {
           position: absolute;
           top: 0;
           left: 0;
           background: white;
           -webkit-transform: rotateY(-180deg);
           -moz-transform: rotateY(-180deg);
           -o-transform: rotateY(-180deg);
           -ms-transform: rotateY(-180deg);
           transform: rotateY(-180deg);
           -webkit-box-shadow: 5px 7px 9px -4px rgb(158, 158, 158);
           -moz-box-shadow: 5px 7px 9px -4px rgb(158, 158, 158);
           box-shadow: 5px 7px 9px -4px rgb(158, 158, 158);
       }

       .frontside,
       .backside {
           -webkit-backface-visibility: hidden;
           -moz-backface-visibility: hidden;
           -ms-backface-visibility: hidden;
           backface-visibility: hidden;
           -webkit-transition: 1s;
           -webkit-transform-style: preserve-3d;
           -moz-transition: 1s;
           -moz-transform-style: preserve-3d;
           -o-transition: 1s;
           -o-transform-style: preserve-3d;
           -ms-transition: 1s;
           -ms-transform-style: preserve-3d;
           transition: 1s;
           transform-style: preserve-3d;
       }

           .frontside .card,
           .backside .card {
               min-height: 312px;
           }

               .backside .card a {
                   font-size: 18px;
                   color: #007b5e !important;
               }

               .frontside .card .card-title,
               .backside .card .card-title {
                   color: #007b5e !important;
               }

               .frontside .card .card-body img {
                   width: 120px;
                   height: 120px;
                   border-radius: 50%;
               }

       }
   </style>
   <section id="team" class="pb-5">
       <div class="container">
           <h5 class="section-title h1" style="text-align: center; font-size: 2.2EM; color: #851717; font-weight: bold">Reporte de actividades de la DVI</h5>
           <div class="row">
               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" id="atencion_integral" href="~/Captura/Atencion_Integral.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                               <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-01.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #932E2F !important">ATENCION INTEGRAL DE PREVENCION ESCOLAR</h4>
                                           <p class="card-text" style="color: black">
                                             
                                           </p>
                                       </div>
                                   </div>
                               </div>

                               <div class="backside">
                                   <div class="card">
                                       <br />
                                       <br />
                                       <div class="card-body text-center mt-4">
                                           <h4 class="card-title" style="color: #932E2F !important">&nbsp;&nbsp;&nbsp;&nbsp;Subprograma: FOMENTO DE LA SEGURIDAD CIUDADANA &nbsp;&nbsp;&nbsp;&nbsp;</h4>
                                           <br />
                                           <h4 class="card-title" style="color: #932E2F !important">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subprograma: EDUCANDO PARA LA PAZ PREVENIMOS&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h4>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->
               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" href="~/Captura/Prevencion_Atencion.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                               <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-02.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #AA1D74 !important">PREVENCION Y ATENCION PARA LA INCLUSION</h4>
                                           <br />

                                           <p class="card-text" style="color: black">
                                          
                                          </p>
                                       </div>
                                   </div>
                               </div>
                               <div class="backside">
                                   <div class="card">
                                       <br />
                                       <div class="card-body text-center mt-4">
                                           <h4 class="card-title" style="color: #AA1D74 !important">Subprograma:  PREVENCION Y ATENCION PARA LA INCLUSION </h4>
                                           <br />
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->
               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" href="~/Captura/Protectores_Vida.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                               <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-03.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #1D8DC6 !important">PROTECTORES DE VIDA CONTRA LAS ADICCIONES</h4>
                                           <p class="card-text" style="color: black">
                                           </p>
                                       </div>
                                   </div>
                               </div>
                               <div class="backside">
                                   <div class="card">
                                       <div class="card-body text-center mt-4">
                                           <div class="card">
                                               <br />
                                               <div class="card-body text-center mt-4">
                                                   <h4 class="card-title" style="color: #1D8DC6 !important">Subprograma: PREVENCION DE ADICCIONES</h4>
                                                   <br />                                              
                                               </div>
                                           </div>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->
               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" id="deporteCultura" href="~/Captura/Atencion_Empresarial.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                               <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-05.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #D6C42E !important">ATENCION INTEGRAL DE PREVENCION EMPRESARIAL </h4>
                                        </div>
                                   </div>
                               </div>
                               <div class="backside">
                                   <div class="card">
                                       <br />
                                       <br />
                                       <div class="card-body text-center mt-4">
                                           <h4 class="card-title" style="color: #D6C42E !important">Subprograma: VINCULACION INTEGRAL EMPRESARIAL</h4>
                                           <br />
                                            <h4 class="card-title" style="color: #D6C42E !important">Subprograma: DIGNIFICACION POLICIAL </h4>
                                     
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->
               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" id="Genero" href="~/Captura/Redes_Atencion_vecinal.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                               <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-06.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #306233 !important">REDES DE ATENCION VECINAL </h4>
                                          </div>
                                   </div>
                               </div>
                               <div class="backside">
                                   <div class="card">
                                       <div class="card-body text-center mt-4">
                                           <div class="card">
                                               <br />
                                               <br />
                                               <div class="card-body text-center mt-4">
                                                   <h4 class="card-title" style="color: #306233 !important">Subprograma: REDES VECINALES</h4>
                                         
                                               </div>
                                           </div>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->
               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" id="FOROS" href="~/Captura/Fortalecimiento_Emocional.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                               <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-07.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #BE5F24 !important">FORTALECIMIENTO EMOCIONAL CON DEPORTE Y CULTURA </h4>
                                           <p class="card-text" style="color: black">
                                             </p>
                                       </div>
                                   </div>
                               </div>
                               <div class="backside">
                                   <div class="card">
                                       <div class="card-body text-center mt-4">                              
                                           <br />
                                           <div class="card-body text-center mt-4">
                                               <h4 class="card-title" style="color: #BE5F24 !important">Subprograma: MENTE Y CUERPO EN MOVIMIENTO</h4>
                                               <br />
                                               <h4 class="card-title" style="color: #BE5F24 !important">Subprograma: JORNADAS ALTERNATIVAS QUE TRANSFORMAN</h4>
                                                <br />
                                               <h4 class="card-title" style="color: #BE5F24 !important">Subprograma: ACCION PARTICIPACION Y CONVIVENCIA</h4>
                                                <br />
                                               <h4 class="card-title" style="color: #BE5F24 !important">Subprograma: CULTURA SEGURA</h4>
                                             
                                           </div>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->

               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" id="A1" href="~/Captura/Violencia_Genero.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                               <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-08.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #002C78 !important">PREVENCION DE LA VIOLENCIA DE GENERO</h4>
                                        </div>
                                   </div>
                               </div>
                               <div class="backside">
                                   <div class="card">
                                       <div class="card-body text-center mt-4">
                                           <h4 class="card-title">Subprograma: VIOLENCIA DE GENERO</h4>
                                           <p class="card-text"></p>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->
               <!-- Team member -->
               <div class="col-xs-12 col-sm-6 col-md-4">
                   <a runat="server" id="Culturaincluyente" href="~/Captura/Festival_vive_seguro.aspx" style="text-decoration: none">
                       <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                           <div class="mainflip">
                               <div class="frontside">
                                   <div class="card">
                                       <div class="card-body text-center">
                                           <p>
                                           <img class=" img-fluid" src="../Imagenes/PinesReporte/Icono-09.png" alt="card image">
                                           </p>
                                           <h4 class="card-title" style="color: #6B5027 !important">FESTIVAL VIVE SEGURO 
                                            <br />
                                           </h4>
                                           </div>
                                   </div>
                               </div>
                               <div class="backside">
                                   <div class="card">
                                       <div class="card-body text-center mt-4">
                                           <div class="card">
                                               <div class="card-body text-center mt-4">
                                                   <br />
                                                   <br />
                                                   <div class="card-body text-center mt-4">
                                                       <h4 class="card-title" style="color: #6B5027 !important">Subprograma: FOROS/FERIAS</h4>
                                                       <br />
                                                       <h4 class="card-title" style="color: #6B5027 !important">Subprograma: DIFUSION</h4>
                                                   </div>
                                               </div>
                                           </div>
                                       </div>
                                   </div>
                               </div>
                           </div>
                       </div>
                   </a>
               </div>
               <!-- ./Team member -->



           </div>
       </div>
   </section>

</asp:Content>
