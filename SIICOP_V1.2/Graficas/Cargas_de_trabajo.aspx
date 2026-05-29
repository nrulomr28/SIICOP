<%@ Page Title="Cargas de trabajo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cargas_de_trabajo.aspx.cs" Inherits="SIICOP_V1._2.Graficas.Cargas_de_trabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/alert.js"></script>
    <script>
        function GuardadoConExito() {

            Swal.fire({
                icon: 'success',
                title: 'Exito',
                text: 'Se Guardo correctamente',

            })
        }

        function error() {

            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Hubo un error',

            })

        }
        function CamposObligatorios(textoValidacion) {
            Swal.fire({
                title: '<strong>Campos obligatorios</strong>',
                icon: 'warning',
                html:
                    '<strong > ' + textoValidacion + '</strong>',
                timer: 10000,
                timerProgressBar: true,
            })
        }



        function openModalAccion() {
            $('#ModalAcciones').modal();
            return false;

        }

        function openModalBeneficiados() {
            $('#ModalBENEFICIADOS').modal();
            return false;

        }

    </script>

    <div class="container" style="padding-top:3%">

        <div class="woww">
            <h2 class="center standart-h2title " style="text-align: center"><span class="large-text"><span class="main-color2">Cargas</span><span></span> de trabajo</span></h2>

        </div>
        <hr />
    </div>
    <%-- termina el div del titulo --%>


    <%-- ACCIONES --%>
    <section id="tab-menus">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <h2 class="text-center mt-4 mb-5">Acciones por delegación y mes</h2>
                    <table>
                        <tbody>
                            <tr>
                                <td style="padding-left: 0; width: 100%">
                                <td style="padding-right: 0; text-align: right; white-space: nowrap">
                                    <div>

                                        <asp:LinkButton runat="server" ID="btnCargaTrabajoNuevo" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#ModalAcciones">Agregar acciones</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <!-- Tabs navs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#firstMenu">CONURBACION XALAPA XX</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#secondmenu">CONURBACION POZA RICA</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#thirdmenu">CONURBACION VERACRUZ XXIII</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#fourthmenu">COORDINACION COATZACOALCOS</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#fivehmenu">COORDINACION CORDOBA</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#sixthmenu">ENLACES</a>
                        </li>


                    </ul>

                    <!-- Tabs Content -->
                    <div class="tab-content">
                        <div id="firstMenu" class="tab-pane active">
                            <br />
                            <div class="body">
                                <%-- <asp:UpdatePanel runat="server" ID="upd">
                                    <ContentTemplate>--%>
                                <asp:GridView runat="server" ID="gvAcciones" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                    DataKeyNames="CargaTrabjaoId">
                                    <Columns>
                                        <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                        <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                        <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                        <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                        <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                        <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                        <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                        <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                        <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                        <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                        <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                        <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                        <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                        <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                    </Columns>
                                    <EmptyDataTemplate>
                                        <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <%--  </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                        <div id="secondmenu" class="tab-pane">
                            <br />
                            <div class="body">
                               <%-- <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                    <ContentTemplate>--%>
                                        <asp:GridView runat="server" ID="gvAccionePoza" CssClass="table table-bordered table-sm table-responsive"
                                            AutoGenerateColumns="false" DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                  <%--  </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                        <div id="thirdmenu" class="tab-pane">
                            <br />
                            <div class="body">
                              <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                    <ContentTemplate>--%>
                                        <asp:GridView runat="server" ID="gvAccionesVera" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                  <%--  </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                        <div id="fourthmenu" class="tab-pane">
                            <br />
                            <div class="body">
                               <%-- <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                    <ContentTemplate>--%>
                                        <asp:GridView runat="server" ID="gvAccionesCoatza" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                  <%--  </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                        <div id="fivehmenu" class="tab-pane">
                            <br />
                            <div class="body">
                              <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel4">
                                    <ContentTemplate>--%>
                                        <asp:GridView runat="server" ID="gvAccionesCordoba" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                   <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                        <div id="sixthmenu" class="tab-pane">
                            <br />
                            <div class="body">
                              <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                    <ContentTemplate>--%>
                                        <asp:GridView runat="server" ID="gvAccionesEnlaces" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                  <%--  </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>


    <br />

    <%-- BENEFICIADOS --%>


    <section id="tab-menusBeni">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <h2 class="text-center mt-4 mb-5">Beneficiados por delegación y mes</h2>
                    <table>
                        <tbody>
                            <tr>
                                <td style="padding-left: 0; width: 100%">
                                <td style="padding-right: 0; text-align: right; white-space: nowrap">
                                    <div>

                                        <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-success btn-sm" data-toggle="modal" data-target="#ModalBENEFICIADOS">Cargar beneficiados</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <!-- Tabs navs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#unoMenu">CONURBACION XALAPA XX</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#dosmenu">CONURBACION POZA RICA</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#tresmenu">CONURBACION VERACRUZ XXIII</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#cuatromenu">COORDINACION COATZACOALCOS</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#cincomenu">COORDINACION CORDOBA</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#seismenu">ENLACES</a>
                        </li>


                    </ul>

                    <!-- Tabs Content -->
                    <div class="tab-content">
                        <div id="unoMenu" class="tab-pane active">
                            <br />
                            <div class="body">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvBenificiadosXalapa" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>
                        <div id="dosmenu" class="tab-pane">
                            <br />
                            <div class="body">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel7">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvBenificiadosPoza" CssClass="table table-bordered table-sm table-responsive"
                                            AutoGenerateColumns="false" DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="tresmenu" class="tab-pane">
                            <br />
                            <div class="body">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel8">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvBeneficiadosVeracruz" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="cuatromenu" class="tab-pane">
                            <br />
                            <div class="body">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel9">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvBeneficiadosCoatza" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="cincomenu" class="tab-pane">
                            <br />
                            <div class="body">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel10">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvBeneficiadosCordoba" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div id="seismenu" class="tab-pane">
                            <br />
                            <div class="body">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel11">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvBeneficiadosEnlace" CssClass="table table-bordered table-sm table-responsive" AutoGenerateColumns="false"
                                            DataKeyNames="CargaTrabjaoId">
                                            <Columns>
                                                <asp:BoundField DataField="progra" HeaderText="PROGRAMA" SortExpression="progra" />
                                                <asp:BoundField DataField="dela" HeaderText="DELEGACIÓN" SortExpression="dela" />
                                                <asp:BoundField DataField="Enero" HeaderText="ENERO" SortExpression="Enero" />
                                                <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" SortExpression="FEBRERO" />
                                                <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                                                <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                                                <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                                                <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                                                <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                                                <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" SortExpression="AGOSTO" />
                                                <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" SortExpression="SEPTIEMBRE" />
                                                <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" SortExpression="OCTUBRE" />
                                                <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" SortExpression="NOVIEMBRE" />
                                                <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" SortExpression="DICIEMBRE" />

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <span class="fas fa-exclamation-circle" style="color: red; font-size: 1.3em"><span>NO SE HA HECHO LA CARA DE TRABAJO DE LOS BENEFICIADOS</span></span>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>



    <%-- APARTADO DE MODALES ACCIONES --%>
    <!-- Modal ACCIONES-->
    <div class="modal fade" id="ModalAcciones" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Carga de trabajo de las acciones por delegación del año <strong id="ano" runat="server"></strong></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="cotainer">
                        <div class="row justify-content-center">
                            <div class="col-md-12">

                                <div class="card-body">
                                    <div>
                                        <div class="form-group row">
                                            <label for="full_name" class="col-md-4 col-form-label text-md-right">Programa</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList runat="server" ID="ddlprograma" CssClass="form-control" DataSourceID="edsPrograma" OnDataBound="ddlprograma_DataBound"
                                                    DataTextField="NombrePrograma" DataValueField="programasID">
                                                </asp:DropDownList>
                                                <asp:EntityDataSource runat="server" ID="edsPrograma" DefaultContainerName="SIICOPEntities"
                                                    Where="it.programasID IN {7,8,9,10,11,12,13,14}"
                                                    ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="tb_programa">
                                                </asp:EntityDataSource>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="email_address" class="col-md-4 col-form-label text-md-right">Delegación</label>
                                            <div class="col-md-6">
                                                <asp:DropDownList runat="server" ID="ddlDelegación" CssClass="form-control" OnDataBound="ddlDelegación_DataBound">
                                                    <asp:ListItem Value="0">-Seleccione-</asp:ListItem>
                                                    <asp:ListItem Value="CONURBACION XALAPA XX">CONURBACION XALAPA XX</asp:ListItem>
                                                    <asp:ListItem Value="CONURBACION POZA RICA">CONURBACION POZA RICA</asp:ListItem>
                                                    <asp:ListItem Value="CONURBACION VERACRUZ XXIII">CONURBACION VERACRUZ XXIII</asp:ListItem>
                                                    <asp:ListItem Value="COORDINACION COATZACOALCOS">COORDINACION COATZACOALCOS</asp:ListItem>
                                                    <asp:ListItem Value="COORDINACION CORDOBA">COORDINACION CORDOBA</asp:ListItem>
                                                    <asp:ListItem Value="Enlace">ENLACE</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="user_name" class="col-md-4 col-form-label text-md-right">ENERO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtenero"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="phone_number" class="col-md-4 col-form-label text-md-right">FEBRERO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtFebrero"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="present_address" class="col-md-4 col-form-label text-md-right">MARZO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtMarzo"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">ABRIL</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtAbril"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">MAYO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtMayo"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">JUNIO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtJunio"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">JULIO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtJulio"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">AGOSTO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtAgosto"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">SEPTIEMBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtSeptiembre"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">OCTUBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtOctubre"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">NOVIEMBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtNoviembre"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">DICIEMBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDiciembre"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <asp:LinkButton runat="server" ID="btnGuardarCargaAcciones" CssClass="btn btn-success" OnClick="btnGuardarCargaAcciones_Click"> Guardar
                        <i class="fas fa-save"></i>
                    </asp:LinkButton>
                </div>
            </div>

        </div>
    </div>




    <!-- Modal BENEFICIADOS-->
    <div class="modal fade" id="ModalBENEFICIADOS" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabe">Carga de trabajo de beneficiados por delegación del año <strong id="stronAnoBeni" runat="server"></strong></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="cotainer">
                        <div class="row justify-content-center">
                            <div class="col-md-12">

                                <div class="card-body">
                                    <div>
                                        <div class="form-group row">
                                            <label for="full_name" class="col-md-4 col-form-label text-md-right">Programa</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList runat="server" ID="ddlProgramaBeni" CssClass="form-control" DataSourceID="edsProgramaBeni" OnDataBound="ddlProgramaBeni_DataBound"
                                                    DataTextField="NombrePrograma" DataValueField="programasID">
                                                </asp:DropDownList>
                                                <asp:EntityDataSource runat="server" ID="edsProgramaBeni" DefaultContainerName="SIICOPEntities"
                                                    Where="it.programasID IN {7,8,9,10,11,12,13,14}"
                                                    ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="tb_programa">
                                                </asp:EntityDataSource>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="email_address" class="col-md-4 col-form-label text-md-right">Delegación</label>
                                            <div class="col-md-6">
                                                <asp:DropDownList runat="server" ID="ddlDelegbeni" CssClass="form-control" OnDataBound="ddlDelegbeni_DataBound">
                                                    <asp:ListItem Value="0">-Seleccione-</asp:ListItem>
                                                    <asp:ListItem Value="CONURBACION XALAPA XX">CONURBACION XALAPA XX</asp:ListItem>
                                                    <asp:ListItem Value="CONURBACION POZA RICA">CONURBACION POZA RICA</asp:ListItem>
                                                    <asp:ListItem Value="CONURBACION VERACRUZ XXIII">CONURBACION VERACRUZ XXIII</asp:ListItem>
                                                    <asp:ListItem Value="COORDINACION COATZACOALCOS">COORDINACION COATZACOALCOS</asp:ListItem>
                                                    <asp:ListItem Value="COORDINACION CORDOBA">COORDINACION CORDOBA</asp:ListItem>
                                                    <asp:ListItem Value="Enlace">ENLACE</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="user_name" class="col-md-4 col-form-label text-md-right">ENERO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtEneroB"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="phone_number" class="col-md-4 col-form-label text-md-right">FEBRERO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtFebreroB"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="present_address" class="col-md-4 col-form-label text-md-right">MARZO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtMarzoB"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">ABRIL</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtAbrilB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">MAYO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtMayoB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">JUNIO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtJunioB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">JULIO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtJulioB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">AGOSTO</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtAgostoB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">SEPTIEMBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtSeptiembreB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">OCTUBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtOctubreB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">NOVIEMBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtNoviembreB"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="permanent_address" class="col-md-4 col-form-label text-md-right">DICIEMBRE</label>
                                            <div class="col-md-2">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtDiciembreB"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                    <asp:LinkButton runat="server" ID="lnkBtnGuardarBeni" CssClass="btn btn-success" OnClick="lnkBtnGuardarBeni_Click"> Guardar
                        <i class="fas fa-save"></i>
                    </asp:LinkButton>
                </div>
            </div>

        </div>
    </div>










</asp:Content>
