<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformeResultados.aspx.cs" Inherits="SIICOP_V1._2.Graficas.InformeResultados" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link href="../Content/StyleResultados.css" rel="stylesheet" />
    <%--<script src="<%= ResolveUrl("~/Scripts/jquery.js") %>" type="text/javascript"></script>--%>
    <script src="../Scripts/Chart.js"></script>

    <div class="container" style="padding-top:3%">
        <h1 style="text-align: center; font-size: 2.2EM; color: #851717;">INFORME GENERAL DE RESULTADOS</h1>
        <div class="row">
            <div class="col-sm-6 col-md-6 col-lg-3">
                <div class="input-group input-group-sm" id="Fecha1">
                    <asp:TextBox ID="txtFechaini" runat="server" CssClass=" form-control" placeholder="YYYY/MM/DD" autocomplete="off"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaini" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                    <span class="input-group-addon">
                        <i class="glyphicon glyphicon-calendar"></i>
                    </span>
                </div>
            </div>
            <div class="col-sm-6 col-md-6 col-lg-3">
                <div class="input-group input-group-sm" id="Fecha2">
                    <asp:TextBox ID="txtDateFin" runat="server" CssClass=" form-control" ReadOnly="false" placeholder="YYYY/MM/DD" autocomplete="off"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFin" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
            <div class="col-sm-6 col-md-6 col-lg-3">
                <div class="btn btn-success">
                    <i class="fas fa-search"></i>
                    <asp:Button runat="server" ID="btnBuscar" CssClass="btn-success" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
            <div class="col-sm-6 col-md-6 col-lg-3" id="imprimir" runat="server" visible="false">
                <div class="btn btn-primary">
                    <i class="fas fa-print"></i>
                    <asp:Button runat="server" ID="btnInprimirReporte" CssClass="btn-primary" Text="Imprimir" OnClick="btnInprimirReporte_Click" />
                </div>
            </div>
            <div class="col-sm-6 col-md-6 col-lg-3" id="cancelar" runat="server" visible="false">
                <div class="btn btn-danger">
                    <i class="far fa-window-close"></i>
                    <asp:Button runat="server" ID="btnCancelar" CssClass="btn-danger" Text="Cancelar" OnClick="btnCancelar_Click1" />
                </div>
            </div>
        </div>
        <br />
        <div id="Resultados" runat="server" visible="false">
            <div class="row">
                <div class="col-md-6">
                    <h4>CONCENTRADO GENERAL DE RESULTADOS EN MATERIA DE PREVENCIÓN DEL DELITO Y PARTICIPACIÓN CIUDADANA 
                    </h4>

                    <div class="row">
                        <div class="col-md-4">
                            <img src="../Imagenes/mapa.png" />
                        </div>
                        <div class="col-md-8">
                            <div class="row">
                                <div class="col-md-11">
                                    <div class="card table-card widget-primary-card">
                                        <div class="">
                                            <div class="row-table">
                                                <div class="col-sm-3 card-block-big">
                                                    <h4 runat="server" id="TotalGeneralAten"></h4>
                                                </div>
                                                <div class="col-sm-9">

                                                    <h4>Personas atendidas</h4>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-10">
                                    <div class="card table-card widget-primary-card">
                                        <div class="">
                                            <div class="row-table">
                                                <div class="col-sm-3 card-block-big">
                                                    <h4 runat="server" id="TotalAcx"></h4>
                                                </div>
                                                <div class="col-sm-9">
                                                    <h4>Acciones en materia de prevención </h4>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-10">
                                    <div class="card table-card widget-primary-card">
                                        <div class="">
                                            <div class="row-table">
                                                <div class="col-sm-3 card-block-big">
                                                    <h4 runat="server" id="totalMunii"></h4>
                                                </div>
                                                <div class="col-sm-9">
                                                    <h4>Municipios atendidos
                                                    </h4>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div id="chart-container" style="height: 30vh; width: 33vw">
                        <h4>CONCENTRADO GENERAL DE RESULTADOS POR ACCIONES
                        </h4>
                        <canvas id="myChartPastel"></canvas>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <hr />
            <h4>CONCENTRADO DE RESULTADOS POR ZONA GEOGRÁFICA: Zona Norte
            </h4>
            <br />
            <div class="row">
                <div class="col-md-5">
                    <div class="row">
                        <div class="col-md-11">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="AtendidosZonaNorte"></h4>
                                        </div>
                                        <div class="col-sm-9">

                                            <h4>Personas atendidas</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="AccionesZonaNorte"></h4>
                                        </div>
                                        <div class="col-sm-9">
                                            <h4>Acciones en materia de prevención </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-10">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="MuniZonaNorte"></h4>
                                        </div>
                                        <div class="col-sm-9">
                                            <h4>Municipios atendidos
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">

                    <h4>CONCENTRADO GENERAL DE RESULTADOS POR PROGRAMAS
                    </h4>
                    <asp:UpdatePanel runat="server" ID="updZonaNorte">
                        <ContentTemplate>
                            <asp:GridView ID="gvzonanorte" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive"
                                CellPadding="3" AllowPaging="True" PageSize="5" OnDataBound="gvzonanorte_DataBound" EmptyDataText="NO HAY DATOS CON ESA FECHA.">
                                <Columns>
                                    <asp:BoundField DataField="ProgramaNomb" HeaderText="Programa" SortExpression="ProgramaNomb" />
                                    <asp:BoundField DataField="Municipios" HeaderText="Municipios" SortExpression="Municipios" />
                                    <asp:BoundField DataField="totalPprMun" HeaderText="Total Programas" SortExpression="totalPprMun" />
                                </Columns>
                                <PagerTemplate>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-lg-2" style="text-align: right;">
                                            <h5>
                                                <asp:Label ID="MessageLabel" Text="Pág." runat="server" /></h5>
                                        </div>
                                        <div class="col-lg-2 col-md-3" style="text-align: left;">
                                            <asp:DropDownList ID="PageDropDownList" Width="80%" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                        </div>
                                        <div class="col-lg-10" style="text-align: right;">
                                            <h3>
                                                <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-success" /></h3>
                                        </div>
                                    </div>
                                </PagerTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </div>

            <br />
            <hr />
            <h4>CONCENTRADO DE RESULTADOS POR ZONA GEOGRÁFICA: Zona Centro
            </h4>

            <br />
            <div class="row">
                <div class="col-md-5">
                    <div class="row">
                        <div class="col-md-11">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="personasCentro"></h4>
                                        </div>
                                        <div class="col-sm-9">

                                            <h4>Personas atendidas</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="AccionesCentro"></h4>
                                        </div>
                                        <div class="col-sm-9">
                                            <h4>Acciones en materia de prevención </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-10">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="MunicipiosCentro"></h4>
                                        </div>
                                        <div class="col-sm-9">
                                            <h4>Municipios atendidos
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">

                    <h4>CONCENTRADO GENERAL DE RESULTADOS POR PROGRAMAS
                    </h4>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <asp:GridView ID="gvZonaCentro" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive"
                                CellPadding="3" AllowPaging="True" PageSize="5" OnDataBound="gvZonaCentro_DataBound" EmptyDataText="NO HAY DATOS CON ESA FECHA.">
                                <Columns>
                                    <asp:BoundField DataField="ProgramaNomb" HeaderText="Programa" SortExpression="ProgramaNomb" />
                                    <asp:BoundField DataField="Municipios" HeaderText="Municipios" SortExpression="Municipios" />
                                    <asp:BoundField DataField="totalPprMun" HeaderText="Total Programas" SortExpression="totalPprMun" />
                                </Columns>
                                <PagerTemplate>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-lg-2" style="text-align: right;">
                                            <h5>
                                                <asp:Label ID="MessageLabel" Text="Pág." runat="server" /></h5>
                                        </div>
                                        <div class="col-lg-2 col-md-3" style="text-align: left;">
                                            <asp:DropDownList ID="pddZonaCentro" Width="80%" AutoPostBack="true" OnSelectedIndexChanged="pddZonaCentro_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                        </div>
                                        <div class="col-lg-10" style="text-align: right;">
                                            <h3>
                                                <asp:Label ID="cplZonaCentro" runat="server" CssClass="label label-success" /></h3>
                                        </div>
                                    </div>
                                </PagerTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </div>

            <hr />
            <h4>CONCENTRADO DE RESULTADOS POR ZONA GEOGRÁFICA: Zona Sur
            </h4>
            <br />
            <div class="row">
                <div class="col-md-5">
                    <div class="row">
                        <div class="col-md-11">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="personasSur"></h4>
                                        </div>
                                        <div class="col-sm-9">

                                            <h4>Personas atendidas</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="accionesSur"></h4>
                                        </div>
                                        <div class="col-sm-9">
                                            <h4>Acciones en materia de prevención </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-10">
                            <div class="card table-card widget-primary-card">
                                <div class="">
                                    <div class="row-table">
                                        <div class="col-sm-3 card-block-big">
                                            <h4 runat="server" id="MunicipiosSur"></h4>
                                        </div>
                                        <div class="col-sm-9">
                                            <h4>Municipios atendidos
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">

                    <h4>CONCENTRADO GENERAL DE RESULTADOS POR PROGRAMAS
                    </h4>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            <asp:GridView ID="GvProgramaSur" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-responsive"
                                CellPadding="3" AllowPaging="True" PageSize="5" OnDataBound="GvProgramaSur_DataBound" EmptyDataText="NO HAY DATOS CON ESA FECHA.">
                                <Columns>
                                    <asp:BoundField DataField="ProgramaNomb" HeaderText="Programa" SortExpression="ProgramaNomb" />
                                    <asp:BoundField DataField="Municipios" HeaderText="Municipios" SortExpression="Municipios" />
                                    <asp:BoundField DataField="totalPprMun" HeaderText="Total Programas" SortExpression="totalPprMun" />
                                </Columns>
                                <PagerTemplate>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-lg-2" style="text-align: right;">
                                            <h5>
                                                <asp:Label ID="MessageLabel" Text="Pág." runat="server" /></h5>
                                        </div>
                                        <div class="col-lg-2 col-md-3" style="text-align: left;">
                                            <asp:DropDownList ID="pddZonasur" Width="80%" AutoPostBack="true" OnSelectedIndexChanged="pddZonasur_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                        </div>
                                        <div class="col-lg-10" style="text-align: right;">
                                            <h3>
                                                <asp:Label ID="cplZonasur" runat="server" CssClass="label label-success" /></h3>
                                        </div>
                                    </div>
                                </PagerTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>


                </div>
            </div>
        </div>

        <div id="ReportePdf" runat="server" visible="false">

            <%--       <rsweb:reportviewer id="ReportViewer1" runat="server" processingmode="Remote" height="900px" width="100%">
            </rsweb:reportviewer>--%>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Height="800px" Width="100%">
            </rsweb:ReportViewer>
        </div>
    </div>




    <div class="modal fade" id="exampleModalValidador" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <h3 style="text-align: center"><span class="fa fa-exclamation-triangle" aria-hidden="true" style="font-size: 2.4em; color: orange"></span></h3>
                            </div>
                        </div>
                        <div class="row">
                            <div method="post" class="form-horizontal" action="none">
                                <asp:Label runat="server" ID="validadottxt"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <span class="glyphicon glyphicon-floppy-remove" aria-hidden="true"></span>
                        Cancelar</button>

                </div>
            </div>
        </div>
    </div>

    <%-- va el cofdigo de lo jquery para las graficas --%>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

    <script type="text/javascript">

        function ConsulTotalAcciones() {

            console.log("si entro paso 1");
            var x = "VARIABLE X";
            var fechaInicial = document.getElementById('<%=txtFechaini.ClientID %>').value;
            var fechafinal = document.getElementById('<%=txtDateFin.ClientID %>').value;
            console.log("si entro paso 2" + fechaInicial + "fecha 2" + fechafinal);
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("InformeResultados.aspx/GetChartData")%>',
                data: "{'x': '" + x + "'}",
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: LlenarGraficaAcciones,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Alerta:" + textStatus + " : " + errorThrown);
                }
            });
            function LlenarGraficaAcciones(response) {
                var dato = response.d;
                if (dato == null) {
                    console.log("NO TRAJO DATOS");
                }
                else {
                    console.log("SI ENTRÓ" + response);
                    var acciones = [];
                    var cantidadesTotal = [];
                    var coloress = [];
                    $.each(dato, function (inx, val) {
                        acciones.push(val.etiquetaR);
                        cantidadesTotal.push(val.Cantidad);

                    });

                    var ctx = document.getElementById("myChartPastel");
                    var myPieChart = new Chart(ctx, {
                        type: 'doughnut',
                        data: {
                            labels: acciones,
                            datasets: [
                                {
                                    label: 'Acciones',
                                    data: cantidadesTotal,
                                    //borderColor: "#3e95cd",
                                    fill: false,
                                    backgroundColor: getRandomColor(cantidadesTotal.length),
                                    borderColor: getRandomColor(cantidadesTotal.length)

                                },
                            ]
                        },
                        options: {
                            title: {
                                display: true,
                                text: 'Total de Acciones'
                            }
                        }
                    });
                }
            }

            function OnErrorCall_(response) { }
            console.log('EEROR:');
        }

        function getRandomColor(n) {
            var letters = '0123456789ABCDEF'.split('');
            var color = '#';
            var colors = [];
            for (var j = 0; j < n; j++) {
                for (var i = 0; i < 6; i++) {
                    color += letters[Math.floor(Math.random() * 16)];
                }
                colors.push(color);
                color = '#';
            }
            return colors;
        }



    </script>
    <script type="text/javascript">
        function AbrirModalValidador() {
            $('#exampleModalValidador').modal();
            return false;
        }

    </script>

</asp:Content>
