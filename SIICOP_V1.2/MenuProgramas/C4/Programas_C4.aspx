<%@ Page Title="Programas del C4" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programas_C4.aspx.cs" Inherits="SIICOP_V1._2.MenuProgramas.C4.Programas_C4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <link runat="server" href="../../Content/Menu_Programas.css" rel="stylesheet" type="text/css" />

    <section id="team" class="pb-5">
        <div class="container">
            <h5 class="section-title h1" style="text-align: center; font-size: 2.2EM; color: #851717; font-weight: bold">Reporte de actividades del C4</h5>
            <div class="row">
                <!-- Team member -->
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkempre" OnClick="lnkempre_Click">
                    <%--<a runat="server" id="empresarial"  href="~/Captura/Enlace_con_el_Sector_Empresarial.aspx" style="text-decoration: none">--%>
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center" style="text-decoration:none !important">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/C4/Iconos/Empresarial.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #932E2F !important; text-decoration:none !important">Empresarial</h4>
                                            <p class="card-text" style="color: black; text-decoration:none !important">
                                                Es un programa dirigido a empresas de todo el estado, en donde se enfocan los esfuerzos para comprender la importancia de los servicios del C4 ante situaciones de emergencias, el cual se atiende la siguiente manera.
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
                                                <li style="color: #932E2F !important">Acciones: Denuncia Anónima 089</li>
                                                <li style="color: #932E2F !important">Acciones: Número único de emergencias 9-1-1</li>
                                                <li style="color: #932E2F !important">Acciones: Asesoría contra Engaño Telefónico</li>
                                                <li style="color: #932E2F !important">Acciones: Policía Científica Preventiva</li>
                                                <li style="color: #932E2F !important">Acciones: Aplicaciones para móviles Mujer Alerta</li>
                                                <li style="color: #932E2F !important">Acciones: Alerta Empresarial</li>
                                                <li style="color: #932E2F !important">Acciones: Uso responsable de servicios de C4</li>
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
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/C4/Iconos/Escolar.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #2895b9 !important">Escolar</h4>
                                            <br />

                                            <p class="card-text" style="color: black">
                                                Es un programa dirigido a escuelas de todos los niveles educativos, en el cual se busca que las y los estudiantes conozcan la importancia del uso responsable de los servicios de emergencias, resaltando aquellos temas que son más relevantes de acuerdo al nivel educativo al que nos dirigimos.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <div class="card-body text-center mt-4">
                                              <ul class="car-tittle"> 
                                                 <li style="color:  #2895b9 !important">Acciones: Número único de emergencias 9-1-1</li>
                                                <li style="color:  #2895b9 !important">Acciones: Denuncia Anónima 089</li>
                                                <li style="color:  #2895b9 !important">Acciones: Asesoría contra Engaño Telefónico</li>
                                                <li style="color: #2895b9 !important">Acciones: Policía Científica Preventiva</li>
                                                <li style="color:  #2895b9 !important">Acciones: Aplicaciones para móviles Mujer Alerta</li>
                                                <li style="color:  #2895b9 !important">Acciones: Uso responsable de servicios de C4</li>
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
                    <asp:LinkButton runat="server" ID="lnkbtnRedesV" OnClick="lnkbtnRedesV_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/C4/Iconos/RedesVecinales.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #1D8DC6 !important">Redes Vecinales</h4>
                                            <p class="card-text" style="color: black">
                                                Se brinda información relevante a redes vecinales en los 212 municipios del estado para que conozcan los servicios de emergencias con los que se cuentan para que hagan un buen uso de estos ante situaciones de emergencias.
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
                                                <li style="color: #1D8DC6 !important">Acciones: Número único de emergencias 9-1-1</li>
                                                <li style="color: #1D8DC6 !important">Acciones: Denuncia Anónima 089</li>
                                                <li style="color: #1D8DC6 !important">Acciones: Asesoría contra Engaño Telefónico</li>
                                                <li style="color: #1D8DC6 !important">Acciones: Policía Científica Preventiva</li>
                                                <li style="color: #1D8DC6 !important">Acciones: Aplicaciones para móviles Mujer Alerta</li>
                                                <li style="color: #1D8DC6 !important">Acciones: Uso responsable de servicios de C4</li>
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
           
               
                <div class="col-xs-12 col-sm-6 col-md-4">
                    <asp:LinkButton runat="server" ID="lnkbtnIP" OnClick="lnkbtnIP_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/C4/Iconos/Inst_Pública.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #653d16 !important">Institución pública</h4>
                                            <p class="card-text" style="color: black">
                                                Es un programa dirigido a instituciones pertenecientes a Gobierno del Estado para que los trabajadores conozcan los servicios a los que se tiene acceso de manera totalmente gratuita.
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="backside">
                                    <div class="card">
                                        <br />
                                        <br />
                                        <div class="card-body text-center mt-4">
                                             <ul class="car-tittle"> 
                                                <li style="color: #653d16 !important">Acciones: Número único de emergencias 9-1-1</li>
                                                <li style="color: #653d16 !important">Acciones: Denuncia Anónima 089</li>
                                                <li style="color: #653d16 !important">Acciones: Asesoría contra Engaño Telefónico</li>
                                                <li style="color: #653d16 !important">Acciones: Policía Científica Preventiva</li>
                                                <li style="color: #653d16 !important">Acciones: Aplicaciones para móviles Mujer Alerta</li>
                                                <li style="color: #653d16 !important">Acciones: Uso responsable de servicios de C4</li>
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
                    <asp:LinkButton runat="server" ID="lnkBtnEventos" OnClick="lnkBtnEventos_Click">
                        <div class="image-flip" ontouchstart="this.classList.toggle('hover');">
                            <div class="mainflip">
                                <div class="frontside">
                                    <div class="card">
                                        <div class="card-body text-center">
                                            <p>
                                                <img runat="server" class=" img-fluid" src="~/Imagenes/Banner/C4/Iconos/Eventos.png" alt="card image">
                                            </p>
                                            <h4 class="card-title" style="color: #cfbd2f !important">Eventos</h4>
                                            <p class="card-text" style="color: black">
                                                Se cuenta con participación en diferentes eventos para hacer difusión de los servicios de emergencias a la población en general, con el objetivo de dar a conocer los servicios con los que cuenta la ciudadanía de manera gratuita.

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
                                                <li style="color: #cfbd2f !important">Acciones: Número único de emergencias 9-1-1</li>
                                                <li style="color: #cfbd2f !important">Acciones: Denuncia Anónima 089</li>
                                                <li style="color: #cfbd2f !important">Acciones: Asesoría contra Engaño Telefónico</li>
                                                <li style="color: #cfbd2f !important">Acciones: Policía Científica Preventiva</li>
                                                <li style="color: #cfbd2f !important">Acciones: Aplicaciones para móviles Mujer Alerta</li>
                                                <li style="color: #cfbd2f !important">Acciones: Uso responsable de servicios de C4</li>
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
               
            </div>
        </div>
    </section>
</asp:Content>
