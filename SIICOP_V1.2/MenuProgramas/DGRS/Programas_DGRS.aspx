<%@ Page Title="Menú de programas DGPRS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programas_DGRS.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.DGPRS.Programas_DGPRS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link runat="server" href="../../Content/Menu_Programas.css" rel="stylesheet" type="text/css" />


    <section id="team" class="pb-5">
        <div class="container">
            <h5 class="section-title h1" style="text-align: center; font-size: 2.2EM; color: #851717; font-weight: bold">Reporte de actividades de DGPRS</h5>
            <div class="row">

                <!-- Team member -->
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkbtnPrevenDeli" OnClick="lnkbtnPrevenDeli_Click">
                    <%--<a runat="server" id="empresarial"  href="~/Captura/Enlace_con_el_Sector_Empresarial.aspx" style="text-decoration: none">--%>
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center" style="text-decoration:none !important">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/DGPRS/Iconos/Clases.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #2054b2  !important; text-decoration:none !important">Impulsando la Prevención en la Educación</h4>
                                            <p class="card-text" style="color: black; text-decoration:none !important">
                                            Una de las funciones principales de la Subdirección Para la Prevención del Delito es, concientizar sobre las diversas causas  y consecuencias de la comisión de conductas antisociales a la población penitenciaria, familiares, sectores educativos y social, con la finalidad de prevenir la incidencia delictiva, fomentando la mejora en la calidad de vida y el bienestar social.  

                                            </p>
                                        </div>
                                    </div>
                                </div>

                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <br />
                                        <div class="card-body  ter mt-4">
                                            <ul class="car-tittle">
                                                <li style="color: #2054b2  !important">SubPrograma: Autoestima </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Valores </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Violencia en el noviazgo  </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Prevención de Conductas Delictivas  </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Redes Sociales </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Proyecto de vida  </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Comportamiento Adictivo  </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Síndrome Cutting </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Solución de Conflictos </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Acoso Escolar </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Prevención de delitos sexuales </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Auto Cuidado</li>
                                                <li style="color: #2054b2  !important">SubPrograma: Trabajo en equipo</li>
                                                <li style="color: #2054b2  !important">SubPrograma: Sentido de la Responsabilidad</li>
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
                    <asp:LinkButton runat="server" ID="lnkBtnMotivacionSociaL" OnClick="lnkBtnMotivacionSociaL_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/DGPRS/Iconos/Ejercicios.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #ff6a00 !important">Motivando a la reinserción social</h4>
                                            <br />

                                            <p class="card-text" style="color: black">
                                             Se realizan ponencias con las PERSONAS PRIVADAS DE SU LIBERTAD, a fin de concientizar y motivar para un cambio positivo dentro de un Centro Penitenciario así como a su reencuentro a la sociedad. Con los diversos temas como:                                             </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <div class="card-body  mt-4">
                                              <ul class="car-tittle"> 
                                                  <li style="color: black !important">Subprograma:</li>
                                                 <li style="color:  #ff6a00 !important">Platicas de Valores </li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Autoestima</li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Perdonando mi pasado</li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Control del Estrés</li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Respeto y Tolerancia</li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Autocontrol</li>
                                                 <li style="color:  #ff6a00 !important"> Platicas de Comportamiento Adictivo</li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Emociones</li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Revisando el pasado, para construir el futuro</li>
                                                <li style="color:  #ff6a00 !important"> Platicas de Comunicación Asertiva</li>
                                               
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
                    <asp:LinkButton runat="server" ID="lnkBtnCampañaPreven" OnClick="lnkBtnCampañaPreven_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/DGPRS/Iconos/IMotivacionalpx.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #342865 !important">Campañas sociales la prevención a través de la información  </h4>
                                            <br />

                                            <p class="card-text" style="color: black">
                                              Una de las funciones principales de la Subdirección Para la Prevención del Delito es, concientizar sobre las diversas causas  y consecuencias de la comisión de conductas antisociales a la población penitenciaria, familiares, sectores educativos y social, con la finalidad de prevenir la incidencia delictiva, fomentando la mejora en la calidad de vida y el bienestar social.  
                                             </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <div class="card-body  mt-4">
                                              <ul class="car-tittle"> 
                                                 <li style="color: black !important">Subprograma:</li>
                                                 <li style="color:  #342865 !important"> Que mi historia ayude a tu vida </li>
                                                <li style="color:  #342865 !important"> Prevenir el delito es cuestión de todos</li>
                                               
                                                  </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <!-- ./Team member -->
            </div>
        </div>
    </section>

</asp:Content>
