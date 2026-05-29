<%@ Page Title="Programas de CEPREVIDE" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programa_CEPREVIDE.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.CREPREVIDE.Programa_CEPREVIDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

         <link runat="server" href="../../Content/Menu_Programas.css" rel="stylesheet" type="text/css" />

    <section id="team" class="pb-5">
        <div class="container">
            <h5 class="section-title h1" style="text-align: center; font-size: 2.2EM; color: #851717; font-weight: bold">Reporte de actividades de CEPREVIDE</h5>
            <div class="row">
                <!-- Team member -->
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkbtnPartiCiuda" OnClick="lnkbtnPartiCiuda_Click">
                    <%--<a runat="server" id="empresarial"  href="~/Captura/Enlace_con_el_Sector_Empresarial.aspx" style="text-decoration: none">--%>
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center" style="text-decoration:none !important">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/CEPREVIDE/Iconos/ParticipaciónCiudadana.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #ed4d11 !important; text-decoration:none !important">Participación Ciudadana </h4>
                                            <p class="card-text" style="color: black; text-decoration:none !important">
                                             Implementar acciones que generen cohesión comunitaria, con la participación de la sociedad y el gobierno, para  prevenir las causas y factores que generan  violencia y delincuencia. 
                                            </p>
                                        </div>
                                    </div>
                                </div>

                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <br />
                                        <div class="card-body text-cen ter mt-4">
                                            <ul class="car-tittle">
                                                <li style="color: #ed4d11 !important">Subprograma: Participación de la Sociedad Civil Organizada </li>
                                                <li style="color: #ed4d11 !important">Subprograma: Participación de la Sociedad Civil No Organizada </li>
                                            </ul>
                                          
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    <%--</a>--%>
                    </asp:LinkButton>
                </div>
                <!-- ./Team member -->
                <!-- Team member -->
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkbtnEscolar" OnClick="lnkbtnEscolar_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/CEPREVIDE/Iconos/Escolar.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #85d71d !important">Escolar </h4>
                                            <br />

                                            <p class="card-text" style="color: black">
                                                Fomentar relaciones libres de violencia y la convivencia pacífica, entre la comunidad escolar del estado de Veracruz. 
                                             </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <div class="card-body text-center mt-4">
                                              <ul class="car-tittle"> 
                                                 <li style="color:  #85d71d !important">Subprograma:  Nivel Básico </li>
                                                <li style="color:  #85d71d !important">Subprograma: Nivel Medio</li>
                                                <li style="color:  #85d71d !important">Subprograma: Nivel Superior</li>
                                                  </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <!-- ./Team member -->
                <!-- Team member -->
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkbtnGrupoV" OnClick="lnkbtnGrupoV_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/CEPREVIDE/Iconos/GruposVulnerables.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color:#4d94b7 !important">Grupos Vulnerables </h4>
                                            <p class="card-text" style="color: black">
                                            Implementar acciones de prevención a grupos en situación en riesgo, orientadas a fortalecer su desarrollo y seguridad, mediante mecanismos de participación ciudadana y articulación de acciones entre sociedad y gobierno. 
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
                                                   <ul class="car-tittle"> 
                                                <li style="color: #4d94b7 !important">Subprograma: Género</li>
                                                <li style="color: #4d94b7 !important">Subprograma: Niñas, Niños y Adolescentes</li>
                                                <li style="color: #4d94b7 !important">Subprograma: Población Indígena</li>
                                                <li style="color: #4d94b7 !important">Subprograma: Personas con discapacidad</li>
                                                <li style="color: #4d94b7 !important">Subprograma: Adultos Mayores</li>
                                                <li style="color: #4d94b7 !important">Subprograma: Uso responsable de servicios de C4</li>
                                            </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <!-- ./Team member -->
                <!-- Team member -->
                <div class="col-xs-12 col-sm-2 col-md-2"></div>
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkbtnCulturaLd" OnClick="lnkbtnCulturaLd_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/CEPREVIDE/Iconos/CulturaLegalidadylaDenuncia.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #3d0993 !important"> Cultura de la Legalidad y la Denuncia  </h4>
                                            <p class="card-text" style="color: black">
                                            Fortalecer en la sociedad veracruzana el aprendizaje de los valores, el rechazo a la violencia; así como promover la cultura de la paz, la legalidad y la denuncia.                                             </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <br />
                                        <div class="card-body text-center mt-4">
                                             <ul class="car-tittle"> 
                                                <li style="color: #3d0993 !important">Subprograma: Acciones a Servidores Públicos</li>
                                                <li style="color: #3d0993 !important">Subprograma: Eventos Culturales y Deportivos</li>
                                              
                                                 </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <!-- ./Team member -->
                <!-- Team member -->
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkBtnREspaciosP" OnClick="lnkBtnREspaciosP_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/CEPREVIDE/Iconos/recuperacion.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #007b5e !important">Rehabilitación de Espacios Públicos</h4>
                                            <p class="card-text" style="color: black">
                                               Realizar acciones colectivas, entre ciudadanía y gobierno, de cuidado del entorno físico y del equipamiento urbano, promoviendo la convivencia pacífica y reduciendo los factores de riesgo en los espacios públicos. 
                                             </p>
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
                                                   <ul class="car-tittle"> 
                                                <li style="color: #007b5e !important">Subprograma: Rehabilitación de Espacios Públicos</li>
                                                
                                                 </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <!-- ./Team member -->
                <div class="col-xs-12 col-sm-2 col-md-2"></div>
            </div>
        </div>
    </section>


</asp:Content>
