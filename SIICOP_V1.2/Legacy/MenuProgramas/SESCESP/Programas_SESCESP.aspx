<%@ Page Title="Proramas de SESCESP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programas_SESCESP.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.SESCESP.Programas_SESCESP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <link runat="server" href="../../Content/Menu_Programas.css" rel="stylesheet" type="text/css" />

    <section id="team" class="pb-5">
        <div class="container">
            <h5 class="section-title h1" style="text-align: center; font-size: 2.2EM; color: #851717; font-weight: bold">Reporte de actividades de SESCESP</h5>
            <div class="row">
                 <!-- Team member -->
                <div class="col-xs-12 col-sm-2 col-md-2"></div>
                <!-- Team member -->
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkbtnCoordinacionCMSPyCPC" OnClick="lnkbtnCoordinacionCMSPyCPC_Click">
                    <%--<a runat="server" id="empresarial"  href="~/Captura/Enlace_con_el_Sector_Empresarial.aspx" style="text-decoration: none">--%>
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center" style="text-decoration:none !important">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/CVcMyCPC/Icono/01.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #2054b2  !important; text-decoration:none !important">Enlace y Coordinación con los CMSPyCPC</h4>
                                            <p class="card-text" style="color: black; text-decoration:none !important">
                                             Establecer los mecanismos que propicien la instalación y operación de los Consejos Municipales de Seguridad Pública y Comités de Participación Ciudadana  (CMSPyCPC).
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
                                                <li style="color: #2054b2  !important">SubPrograma: Instalación de los CMSPyCPC </li>
                                                <li style="color: #2054b2  !important">SubPrograma: reinstalación de los CMSPyCPC  </li>
                                                <li style="color: #2054b2  !important">SubPrograma: Supervisión a la Operatividad de los CMSPyCPC  </li>
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
                    <asp:LinkButton runat="server" ID="lnkbtnVIC"  OnClick="lnkbtnVIC_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/CVcMyCPC/Icono/02.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #4b2b10 !important">Vinculación Interinstitucional y Ciudadanía  </h4>
                                            <br />

                                            <p class="card-text" style="color: black">
                                               Coordinar esfuerzos e impulsar mecanismos permanentes de comunicación, a partir de asesoramientos en materia de seguridad y programas de prevención del delito, que promuevan la participación proactiva de los servidores públicos y la ciudadanía.
                                             </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <div class="card-body text-center mt-4">
                                              <ul class="car-tittle"> 
                                                 <li style="color:  #4b2b10 !important">SubPrograma: Prevención de la Violencia de Género </li>
                                                <li style="color:  #4b2b10 !important">SubPrograma: Trata de personas</li>
                                                <li style="color:  #4b2b10 !important">SubPrograma: Derechos Humanos en México organizada</li>
                                                <li style="color:  #4b2b10 !important">SubPrograma: Participación de la Sociedad Civil organizada</li>
                                                <li style="color:  #4b2b10 !important">SubPrograma: Formación ciudadana hacia una cultura de la legalidad y valores</li>
                                                <li style="color:  #4b2b10 !important">SubPrograma: Derecho a la Igualdad y a la No Discriminación</li>
                                               
                                                  </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:LinkButton>
                </div>
                <!-- ./Team member -->
             
        
                <!-- ./Team member -->
                <div class="col-xs-12 col-sm-2 col-md-2"></div>
            </div>
        </div>
    </section>



</asp:Content>
