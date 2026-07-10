<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productividad.aspx.cs" Inherits="SIICOP_V1._2.Graficas.Productividad" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--<script src="<%= ResolveUrl("~/Scripts/jquery.js") %>" type="text/javascript"></script>--%>
    <script src="../Scripts/Chart.js"></script>
    <style>
        .modal-dialog_pdf {
             width:  90%; 
        margin: auto;
        }
        
    </style>
    <script type="text/javascript">
        function AbrirModalValidador() {
            $('#exampleModalValidador').modal();
            return false;
        }

        function AbrirModalReporte() {
            $('#ModalReporte').modal();
            return false;
        }
    </script>

    <style>
        body {
            background-color: #f3f3f3;
            /*font-size: .875em;*/
            /*font-size: .8em;*/
            overflow-x: hidden;
            font-family: "Open Sans",sans-serif;
        }

        card {
            border-radius: 2px;
            border-top: 4px solid #8CDDCD;
            box-shadow: 0 2px 1px rgba(0,0,0,0.05);
            border-left: none;
            border-right: none;
            border-bottom: none;
            margin-bottom: 30px;
        }

        .card {
            border-top: 4px solid #8CDDCD !important;
            position: relative;
            display: -webkit-box;
            display: -webkit-flex;
            display: -ms-flexbox;
            display: flex;
            -webkit-box-orient: vertical;
            -webkit-box-direction: normal;
            -webkit-flex-direction: column;
            -ms-flex-direction: column;
            flex-direction: column;
            background-color: #fff;
            border: 1px solid rgba(0,0,0,.125);
            border-radius: .25rem;
        }

        .table-1-card .card-block {
            padding-top: 10px;
            padding-bottom: 0;
        }

        .card-block {
            -webkit-box-flex: 1;
            -webkit-flex: 1 1 auto;
            -ms-flex: 1 1 auto;
            flex: 1 1 auto;
            padding: 1.25rem;
        }

        .widget-primary-card,
        .widget-success-card,
        .widget-Blue-card,
        .widget-verdeAgua-card {
            border-top: none;
            background-color: #1abc9c;
            color: #fff;
        }

            widget-primary-card .row-table > [class*=col-]:first-child,
            .widget-success-card .row-table > [class*=col-]:first-child,
            .widget-Blue-card .row-table > [class*=col-]:first-child,
            .widget-verdeAgua-card .row-table > [class*=col-]:first-child {
                background-color: #148f77;
                text-align: center;
            }

        .widget-success-card {
            background-color: #2ecc71;
        }

        .widget-Blue-card {
            background-color: #44B8CE;
        }

        .widget-verdeAgua-card {
            background-color: #328899;
        }

        .table-card .row-table i {
            font-size: 28px;
        }

        .card-block-big {
            padding: 2em;
        }

        .widget-primary-card .row-table > [class*=col-]:first-child, .widget-success-card .row-table > [class*=col-]:first-child {
            background-color: #148f77;
            text-align: center;
        }
    </style>
    <div class="container" style="padding-top:3%">

        <div class="woww">
            <h2 class="center standart-h2title " style="text-align: center"><span class="large-text"><span class="main-color2">Gráficas</span><span></span> de Productividad</span></h2>

        </div>
        <hr />
    </div>
    <%-- termina el div del titulo --%>
    <br />



    <div class="container-fluid">

        <div class="row">
            <div class=" col-sm-4 col-md-4">
                <div class="activity_box activity_box1">

                    <div class="row">
                        <div class="col-lg-1"></div>
                        <div class="col-sm-6 col-md-6 col-lg-4">
                            <div class="input-group input-group-sm" id="Fecha1">
                                <asp:TextBox ID="txtFechaini" runat="server" CssClass=" form-control" placeholder="dd/MM/yyyy" autocomplete="off"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaini" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-calendar"></i>
                                </span>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-6 col-lg-4">
                            <div class="input-group input-group-sm" id="Fecha2">
                                <asp:TextBox ID="txtDateFin" runat="server" CssClass=" form-control" ReadOnly="false" placeholder="dd/MM/yyyy" autocomplete="off"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateFin" Format="yyyy/MM/dd"></ajaxToolkit:CalendarExtender>
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                    <hr>
                    <div class="row">
                        <div id="collapseOne" class="panel-collapse collapse in">
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-5">
                                        <h2 style="font-size: 1.0em; text-align: center">Marca &nbsp;<code><span class="cr"><i class="cr-icon glyphicon glyphicon-ok"></i></span></code>&nbsp;el programa que deseas filtrar</h2>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6 col-lg-3">
                                        <div class="col-xs-12 col-sm-9 col-lg-12">
                                            <div class="checkbox">
                                                <label>
                                                    <input id="ChkEmpresarial" type="checkbox" name="ChkEmpresarial" value="13" runat="server" groupname="chkprogramas">
                                                    Enlace con el Sector Empresarial
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input id="ChkCiudadano" type="checkbox" name="ChkCiudadano" value="8" runat="server" groupname="chkprogramas">
                                                    Redes vecinales
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input id="ChkEscuela" type="checkbox" name="ChkEscuela" value="9" runat="server" groupname="chkprogramas">
                                                    Seguridad Ciudadana y Paz Social en Entornos Educativos

         
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input id="Chkredspaz" type="checkbox" name="ChkEscuela" value="14" runat="server" groupname="chkprogramas">
                                                    Redes Veracruzanas en la Construcción de la Paz


         
                                                </label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-6  col-lg-3">
                                        <div class="col-xs-12 col-sm-9 col-lg-12">
                                            <div class="checkbox">
                                                <label>
                                                    <input id="ChkMujer" type="checkbox" name="ChkMujer" value="10" runat="server">
                                                    Prevención de la Violencia por Razones de Género         
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input id="ChkForesFerias" type="checkbox" name="ChkForesFerias" value="11" runat="server">
                                                    Encuentros Ciudadanos por la Seguridad
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input id="ChkInCiudadano" type="checkbox" name="ChkInCiudadano" value="12" runat="server">
                                                    Fomento a la Prevención a través del Deporte la Cultura
         
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input id="Chkinclusion" type="checkbox" name="ChkInCiudadano" value="7" runat="server">
                                                    Inclusión de personas en situación de vunerabilidad         
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br>

                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-4">
                            <asp:LinkButton runat="server" ID="lnkbtnImprimirReporte" CssClass="btn btn-success btn-block" OnClick="lnkbtnImprimirReporte_Click">Generar Reporte
                                <i class="fa fa-print" aria-hidden="true"></i>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-4">
                            <%--<asp:Button runat="server" ID="btnbuscar" Text="buscar" OnClick="btnbuscar_Click1" class=" btn btn-info" />--%>
                            <asp:Button runat="server" ID="btnbuscar2" Text="buscar" OnClick="btnbuscar2_Click" class=" btn btn-info" />
                        </div>
                    </div>
                </div>
                <br />
                <section runat="server" id="atendidos" visible="false">
                    <div class="row">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card table-card widget-primary-card">
                                    <div class="">
                                        <div class="row-table">
                                            <div class="col-sm-3 card-block-big">
                                                <i class="fas fa-users"></i>
                                            </div>
                                            <div class="col-sm-9">
                                                <h2 runat="server" id="TotalGeneralAten"></h2>
                                                <h4>Beneficiados</h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card table-card widget-success-card">
                                    <div class="">
                                        <div class="row-table">
                                            <div class="col-sm-3 card-block-big">
                                                <i class="fas fa-user-nurse"></i>
                                            </div>
                                            <div class="col-sm-9">
                                                <h2 runat="server" id="TotalAcx"></h2>
                                                <h4>Acciones realizadas</h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="card table-card widget-success-card">
                                    <div class="">
                                        <div class="row-table">
                                            <div class="col-sm-3 card-block-big">
                                                <i class="fas fa-user-nurse"></i>
                                            </div>
                                            <div class="col-sm-9">
                                                <h2 runat="server" id="MuniTtoatl"></h2>
                                                <h4>Municipios Atendidos</h4>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
            <section runat="server" id="Griddatos" visible="false">
                <div class="col-md-8">
                    <div class="card table-1-card">
                        <div class="card-block">
                            <div class="table-responsive">


                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvDATOS" CssClass="table table-condensed table-bordered" runat="server" AutoGenerateColumns="False"
                                            CellPadding="3" AllowPaging="True" DataKeyNames="idResumenDiario" OnDataBound="gvDATOS_DataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" Text='<%# Bind("fecha") %>' ID="TextBox1"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Convert.ToDateTime(Eval("fecha")).ToString("dd/MM/yyyy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="NombrePrograma" HeaderText="Programa" SortExpression="NombrePrograma"></asp:BoundField>
                                                <asp:BoundField DataField="NombreSubPrograma" HeaderText="Subprograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                                                <asp:BoundField DataField="AccionesNombre" HeaderText="Acciones" SortExpression="AccionesNombre"></asp:BoundField>
                                                <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres atendidos" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                                                <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres atendidas" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                                                <asp:BoundField DataField="total_atendidos" HeaderText="Total atendidos" SortExpression="total_atendidos"></asp:BoundField>
                                            </Columns>
                                            <PagerTemplate>
                                                <div class="row" style="margin-top: 20px;">
                                                    <div class="col-lg-1" style="text-align: right;">
                                                        <h5>
                                                            <asp:Label ID="MessageLabel" Text="Pág." runat="server" /></h5>
                                                    </div>
                                                    <div class="col-lg-2 col-md-3" style="text-align: left;">
                                                        <asp:DropDownList ID="PageDropDownList" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                                    </div>
                                                    <div class="col-lg-10" style="text-align: right;">
                                                        <h3>
                                                            <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-success" /></h3>
                                                    </div>
                                                </div>
                                            </PagerTemplate>
                                        </asp:GridView>
                                        <%--  <asp:EntityDataSource runat="server" ID="edsDatos" DefaultContainerName="SIICOPEntities"
                                            ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico"
                                            Where=" ((@fInicialC IS NULL OR it.fecha >= @fInicialC) AND (@fFinalC IS NULL OR it.fecha <= @fFinalC) and it.programasID =@pro)">
                                            <WhereParameters>
                                                <asp:SessionParameter SessionField="fInicialC" Name="fInicialC" Type="DateTime" />
                                                <asp:SessionParameter SessionField="fFinalC" Name="fFinalC" Type="DateTime" />
                                           <asp:SessionParameter SessionField="pro" Name="pro" Type="Object" />
                                            </WhereParameters>
                                        </asp:EntityDataSource>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <section runat="server" id="Graficas" visible="false">
            <h1 style="text-align: center; background-color: brown; color: white"><span>DATOS POR ZONA NORTE </span></h1>
            <br />
            <div class="row">

                <div class="col-md-2">
                    <div class="row">
                        <div class="card table-card widget-Blue-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="ZonaNorte"></h2>
                                        <h4>Municipios antendidos</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card table-card widget-verdeAgua-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="PersonasZonaNorte"></h2>
                                        <h4>Beneficiados</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card table-card widget-success-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="AccionesZonaNorte"></h2>
                                        <h4>Acciones realizadas</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-md-10">
                    <div class="row">
                        <div class="col-xs-6 col-md-6" style="position: relative; width: 36%">
                            <div class="card table-1-card">
                                <div class="card-block">
                                    <%--  
                                    <asp:HiddenField runat="server" ID="HDfProgramaIdd" Value="" />
                                    --%>
                                    <asp:HiddenField runat="server" ID="HDfinclusion" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfredesOld" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfredesOldNew" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfescolarOld" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfescolarNew" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfmujerOld" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfmujerNew" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfempreOld" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfempreNew" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfdeporteNew" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfforosferiaOld" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfforosferiaNew" Value="" />
                                    <asp:HiddenField runat="server" ID="HDfredspaz" Value="" />

                                    <div class="chart-container">
                                        <div class="panel-body">
                                            <div>

                                                <canvas id="myChartPastelNorteAcciones"></canvas>
                                            </div>
                                            <script type="text/javascript">

                                                var colores;


                                                function ConsultaHombresXacciones() {

                                                    console.log("si entro paso 1");
                                                    var x = "VARIABLE X";
                                                    var fechaInicial = document.getElementById('<%=txtFechaini.ClientID %>').value;
                                                    var fechafinal = document.getElementById('<%=txtDateFin.ClientID %>').value;

                                                    var inclusion = document.getElementById('<%=HDfinclusion.ClientID %>').value;
                                                    var redesOld = document.getElementById('<%=HDfredesOld.ClientID %>').value;
                                                    var redesOldNew = document.getElementById('<%=HDfredesOldNew.ClientID %>').value;
                                                    var escolarOld = document.getElementById('<%=HDfescolarOld.ClientID %>').value;
                                                    var escolarNew = document.getElementById('<%=HDfescolarNew.ClientID %>').value;
                                                    var mujerOld = document.getElementById('<%=HDfmujerOld.ClientID %>').value;
                                                    var mujerNew = document.getElementById('<%=HDfmujerNew.ClientID %>').value;
                                                    var empreOld = document.getElementById('<%=HDfempreOld.ClientID %>').value;
                                                    var empreNew = document.getElementById('<%=HDfempreNew.ClientID %>').value;
                                                    var deporteNew = document.getElementById('<%=HDfdeporteNew.ClientID %>').value;
                                                    var forosferiaOld = document.getElementById('<%=HDfforosferiaOld.ClientID %>').value;
                                                    var forosferiaNew = document.getElementById('<%=HDfforosferiaNew.ClientID %>').value;
                                                    var redspaz = document.getElementById('<%=HDfredspaz.ClientID %>').value;

                                                    console.log("si entro paso 2" + fechaInicial + "fecha 2" + fechafinal);
                                                    $.ajax({
                                                        type: "POST",
                                                        url: '<%= ResolveUrl("Productividad.aspx/ChartDataNorteAccionesta")%>',
                                                        data: "{'x': '" + x + "'}",
                                                        data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x, 'inclusion': inclusion, 'escolarOld': escolarOld, 'escolarNew': escolarNew, 'redesOld': redesOld, 'redesOldNew': redesOldNew, 'empreOld': empreOld, 'empreNew': empreNew, 'mujerOld': mujerOld, 'mujerNew': mujerNew, 'deporteNew': deporteNew, 'forosferiaOld': forosferiaOld, 'forosferiaNew': forosferiaNew, 'redspaz': redspaz }),
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

                                                            var ctx = document.getElementById("myChartPastelNorteAcciones");
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
                                                                            //borderColor: getRandomColor(cantidadesTotal.length)

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
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-6 col-md-6" style="position: relative; width: 63%">
                            <div class="card table-1-card">
                                <div class="card-block">

                                    <div class="chart-container">
                                        <canvas id="myChartBarZonaNorte"></canvas>
                                    </div>
                                    <script type="text/javascript">

                                        function ConsultaMuniNorte() {

                                            console.log("si entro paso 1");
                                            var x = "VARIABLE X";
                                            var fechaInicial = document.getElementById('<%=txtFechaini.ClientID %>').value;
                                            var fechafinal = document.getElementById('<%=txtDateFin.ClientID %>').value;
                                            var inclusion = document.getElementById('<%=HDfinclusion.ClientID %>').value;
                                            var redesOld = document.getElementById('<%=HDfredesOld.ClientID %>').value;
                                            var redesOldNew = document.getElementById('<%=HDfredesOldNew.ClientID %>').value;
                                            var escolarOld = document.getElementById('<%=HDfescolarOld.ClientID %>').value;
                                            var escolarNew = document.getElementById('<%=HDfescolarNew.ClientID %>').value;
                                            var mujerOld = document.getElementById('<%=HDfmujerOld.ClientID %>').value;
                                            var mujerNew = document.getElementById('<%=HDfmujerNew.ClientID %>').value;
                                            var empreOld = document.getElementById('<%=HDfempreOld.ClientID %>').value;
                                            var empreNew = document.getElementById('<%=HDfempreNew.ClientID %>').value;
                                            var deporteNew = document.getElementById('<%=HDfdeporteNew.ClientID %>').value;
                                            var forosferiaOld = document.getElementById('<%=HDfforosferiaOld.ClientID %>').value;
                                            var forosferiaNew = document.getElementById('<%=HDfforosferiaNew.ClientID %>').value;
                                            var redspaz = document.getElementById('<%=HDfredspaz.ClientID %>').value;

                                            $.ajax({
                                                type: "POST",
                                                url: '<%= ResolveUrl("Productividad.aspx/datoGraficabarteNorteMuni")%>',
                                                data: "{'x':'" + x + "'}",
                                                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x, 'inclusion': inclusion, 'escolarOld': escolarOld, 'escolarNew': escolarNew, 'redesOld': redesOld, 'redesOldNew': redesOldNew, 'empreOld': empreOld, 'empreNew': empreNew, 'mujerOld': mujerOld, 'mujerNew': mujerNew, 'deporteNew': deporteNew, 'forosferiaOld': forosferiaOld, 'forosferiaNew': forosferiaNew, 'redspaz': redspaz }),
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
                                                    console.log("SI ENTRÓ");
                                                    var Muni = [];
                                                    var cantidadesTotalMun = [];
                                                    var coloress = [];
                                                    $.each(dato, function (inx, val) {
                                                        Muni.push(val.Municipios);
                                                        cantidadesTotalMun.push(val.CantidadMuni);

                                                    });
                                                    var ctx = document.getElementById("myChartBarZonaNorte");
                                                    var myPieChart = new Chart(ctx, {
                                                        type: 'bar',
                                                        data: {
                                                            labels: Muni,
                                                            datasets: [
                                                                {
                                                                    label: 'Acciones atendidos',
                                                                    data: cantidadesTotalMun,
                                                                    fill: false,
                                                                    backgroundColor: getRandomColor(cantidadesTotalMun.length),
                                                                    stack: 1
                                                                },
                                                            ]
                                                        },
                                                        options: {
                                                            title: {
                                                                display: true,
                                                                text: 'Total de Municipios'
                                                            }
                                                        },
                                                        tooltips: {
                                                            mode: 'index',
                                                            intersect: false
                                                        },
                                                        //responsive: true,
                                                        scales: {
                                                            xAxes: [{
                                                                stacked: true,
                                                                maxRotation: 90,
                                                                minRotation: 90,
                                                                padding: -110,

                                                            }],
                                                            yAxes: [{
                                                                stacked: true,
                                                                ticks: {
                                                                    beginAtZero: true,
                                                                    min: 0,
                                                                    max: 100
                                                                }
                                                            }]
                                                        }
                                                    });
                                                }
                                            }

                                            function OnErrorCall_(response) { }
                                            console.log('EEROR:');
                                        }
                                    </script>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <br />

            <h1 style="text-align: center; background-color: brown; color: white"><span>DATOS POR ZONA CENTRO </span></h1>
            <div class="row">
                <div class="col-md-2">
                    <div class="row">
                        <div class="card table-card widget-Blue-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="ZonaCentro"></h2>
                                        <h4>Municipios atendidos</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card table-card widget-verdeAgua-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="PersonasAtendidasZonaCentro"></h2>
                                        <h4>Personas atendidas</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card table-card widget-success-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="accionesRealizadasZonaCentro"></h2>
                                        <h4>Acciones realizadas</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="row">
                        <div class="col-md-6" style="position: relative; width: 30vw">
                            <div class="card table-1-card">
                                <div class="card-block">

                                    <div class="chart-container" s>
                                        <div class="panel-body">
                                            <div>

                                                <canvas id="myChartAccionesCnetro"></canvas>
                                            </div>
                                            <script type="text/javascript">
                                                function AccionescentroTtotal() {

                                                    console.log("si entro paso 1");
                                                    var x = "VARIABLE X";
                                                    var fechaInicial = document.getElementById('<%=txtFechaini.ClientID %>').value;
                                                    var fechafinal = document.getElementById('<%=txtDateFin.ClientID %>').value;
                                                    var inclusion = document.getElementById('<%=HDfinclusion.ClientID %>').value;
                                                    var redesOld = document.getElementById('<%=HDfredesOld.ClientID %>').value;
                                                    var redesOldNew = document.getElementById('<%=HDfredesOldNew.ClientID %>').value;
                                                    var escolarOld = document.getElementById('<%=HDfescolarOld.ClientID %>').value;
                                                    var escolarNew = document.getElementById('<%=HDfescolarNew.ClientID %>').value;
                                                    var mujerOld = document.getElementById('<%=HDfmujerOld.ClientID %>').value;
                                                    var mujerNew = document.getElementById('<%=HDfmujerNew.ClientID %>').value;
                                                    var empreOld = document.getElementById('<%=HDfempreOld.ClientID %>').value;
                                                    var empreNew = document.getElementById('<%=HDfempreNew.ClientID %>').value;
                                                    var deporteNew = document.getElementById('<%=HDfdeporteNew.ClientID %>').value;
                                                    var forosferiaOld = document.getElementById('<%=HDfforosferiaOld.ClientID %>').value;
                                                    var forosferiaNew = document.getElementById('<%=HDfforosferiaNew.ClientID %>').value;
                                                    var redspaz = document.getElementById('<%=HDfredspaz.ClientID %>').value;

                                                    console.log("si entro paso 2" + fechaInicial + "fecha 2" + fechafinal);
                                                    $.ajax({
                                                        type: "POST",
                                                        url: '<%= ResolveUrl("Productividad.aspx/ChartDataCentroAccionesta")%>',
                                                        data: "{'x': '" + x + "'}",
                                                        data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x, 'inclusion': inclusion, 'escolarOld': escolarOld, 'escolarNew': escolarNew, 'redesOld': redesOld, 'redesOldNew': redesOldNew, 'empreOld': empreOld, 'empreNew': empreNew, 'mujerOld': mujerOld, 'mujerNew': mujerNew, 'deporteNew': deporteNew, 'forosferiaOld': forosferiaOld, 'forosferiaNew': forosferiaNew, 'redspaz': redspaz }),
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
                                                            var accionesCentro = [];
                                                            var cantidadesTotalCentro = [];
                                                            var coloress = [];
                                                            $.each(dato, function (inx, val) {
                                                                accionesCentro.push(val.etiquetaRcentro);
                                                                cantidadesTotalCentro.push(val.Cantidadcentro);

                                                            });

                                                            var ctx = document.getElementById("myChartAccionesCnetro");
                                                            var myPieChart = new Chart(ctx, {
                                                                type: 'doughnut',
                                                                data: {
                                                                    labels: accionesCentro,
                                                                    datasets: [
                                                                        {
                                                                            label: 'Acciones',
                                                                            data: cantidadesTotalCentro,
                                                                            //borderColor: "#3e95cd",
                                                                            fill: false,
                                                                            backgroundColor: getRandomColor(cantidadesTotalCentro.length),
                                                                            //borderColor: getRandomColor(cantidadesTotal.length)

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
                                                }

                                            </script>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6" style="position: relative; width: 50vw">
                            <div class="card table-1-card">
                                <div class="card-block">

                                    <div class="chart-container">
                                        <canvas id="myChartBarCentro"></canvas>
                                    </div>
                                    <script type="text/javascript">

                                        function ConsultaMunicentro() {

                                            console.log("si entro paso 1");
                                            var x = "VARIABLE X";
                                            var fechaInicial = document.getElementById('<%=txtFechaini.ClientID %>').value;
                                            var fechafinal = document.getElementById('<%=txtDateFin.ClientID %>').value;
                                            var inclusion = document.getElementById('<%=HDfinclusion.ClientID %>').value;
                                            var redesOld = document.getElementById('<%=HDfredesOld.ClientID %>').value;
                                            var redesOldNew = document.getElementById('<%=HDfredesOldNew.ClientID %>').value;
                                            var escolarOld = document.getElementById('<%=HDfescolarOld.ClientID %>').value;
                                            var escolarNew = document.getElementById('<%=HDfescolarNew.ClientID %>').value;
                                            var mujerOld = document.getElementById('<%=HDfmujerOld.ClientID %>').value;
                                            var mujerNew = document.getElementById('<%=HDfmujerNew.ClientID %>').value;
                                            var empreOld = document.getElementById('<%=HDfempreOld.ClientID %>').value;
                                            var empreNew = document.getElementById('<%=HDfempreNew.ClientID %>').value;
                                            var deporteNew = document.getElementById('<%=HDfdeporteNew.ClientID %>').value;
                                            var forosferiaOld = document.getElementById('<%=HDfforosferiaOld.ClientID %>').value;
                                            var forosferiaNew = document.getElementById('<%=HDfforosferiaNew.ClientID %>').value;
                                            var redspaz = document.getElementById('<%=HDfredspaz.ClientID %>').value;

                                            $.ajax({
                                                type: "POST",
                                                url: '<%= ResolveUrl("Productividad.aspx/datoGraficabarteCentroMuni")%>',
                                                data: "{'x':'" + x + "'}",
                                                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x, 'inclusion': inclusion, 'escolarOld': escolarOld, 'escolarNew': escolarNew, 'redesOld': redesOld, 'redesOldNew': redesOldNew, 'empreOld': empreOld, 'empreNew': empreNew, 'mujerOld': mujerOld, 'mujerNew': mujerNew, 'deporteNew': deporteNew, 'forosferiaOld': forosferiaOld, 'forosferiaNew': forosferiaNew, 'redspaz': redspaz }),
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
                                                    console.log("SI ENTRÓ");
                                                    var Municentro = [];
                                                    var cantidadesTotalMuncentro = [];
                                                    var coloress = [];
                                                    $.each(dato, function (inx, val) {
                                                        Municentro.push(val.Municipioscentro);
                                                        cantidadesTotalMuncentro.push(val.CantidadMunicentro);

                                                    });
                                                    var ctx = document.getElementById("myChartBarCentro");
                                                    var myPieChart = new Chart(ctx, {
                                                        type: 'bar',
                                                        data: {
                                                            labels: Municentro,
                                                            datasets: [
                                                                {
                                                                    label: 'Acciones atendidos',
                                                                    data: cantidadesTotalMuncentro,
                                                                    fill: false,
                                                                    backgroundColor: getRandomColor(cantidadesTotalMuncentro.length),
                                                                    stack: 1
                                                                },
                                                            ]
                                                        },
                                                        options: {
                                                            title: {
                                                                display: true,
                                                                text: 'Total de Municipios'
                                                            }
                                                        },
                                                        tooltips: {
                                                            mode: 'index',
                                                            intersect: false
                                                        },
                                                        responsive: true,
                                                        scales: {
                                                            xAxes: [{
                                                                stacked: true,
                                                                maxRotation: 90,
                                                                minRotation: 90,
                                                                padding: -110


                                                            }],
                                                            yAxes: [{
                                                                stacked: true
                                                            }]
                                                        }
                                                    });
                                                }
                                            }

                                            function OnErrorCall_(response) { }
                                            console.log('EEROR:');
                                        }
                                    </script>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <br />

            <h1 style="text-align: center; background-color: brown; color: white"><span>DATOS POR ZONA SUR </span></h1>
            <div class="row">

                <div class="col-md-2">
                    <div class="row">
                        <div class="card table-card widget-Blue-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="ZonaSurRR"></h2>
                                        <h4>Municipios antendidos</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card table-card widget-verdeAgua-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="personasAtendidasZonaSur"></h2>
                                        <h4>Personas atendidas</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="card table-card widget-success-card">
                            <div class="">
                                <div class="row-table">
                                    <div class="col-xs-6 col-sm-5 col-md-5 col-lg-3 card-block-big">
                                        <i class="far fa-compass"></i>
                                    </div>
                                    <div class="col-xs-6 col-sm-7 col-md-7  col-lg-9">
                                        <h2 runat="server" id="AccionesRealizadasSur"></h2>
                                        <h4>Acciones realizadas</h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="row">
                        <div class="col-md-6" style="position: relative; width: 30vw">
                            <div class="card table-1-card">
                                <div class="card-block">

                                    <div class="chart-container" s>
                                        <div class="panel-body">
                                            <div>

                                                <canvas id="myChartAccioneSur"></canvas>
                                            </div>
                                            <script type="text/javascript">
                                                function AccionesSurTtotal() {

                                                    console.log("si entro paso 1");
                                                    var x = "VARIABLE X";
                                                    var fechaInicial = document.getElementById('<%=txtFechaini.ClientID %>').value;
                                                    var fechafinal = document.getElementById('<%=txtDateFin.ClientID %>').value;
                                                    var inclusion = document.getElementById('<%=HDfinclusion.ClientID %>').value;
                                                    var redesOld = document.getElementById('<%=HDfredesOld.ClientID %>').value;
                                                    var redesOldNew = document.getElementById('<%=HDfredesOldNew.ClientID %>').value;
                                                    var escolarOld = document.getElementById('<%=HDfescolarOld.ClientID %>').value;
                                                    var escolarNew = document.getElementById('<%=HDfescolarNew.ClientID %>').value;
                                                    var mujerOld = document.getElementById('<%=HDfmujerOld.ClientID %>').value;
                                                    var mujerNew = document.getElementById('<%=HDfmujerNew.ClientID %>').value;
                                                    var empreOld = document.getElementById('<%=HDfempreOld.ClientID %>').value;
                                                    var empreNew = document.getElementById('<%=HDfempreNew.ClientID %>').value;
                                                    var deporteNew = document.getElementById('<%=HDfdeporteNew.ClientID %>').value;
                                                    var forosferiaOld = document.getElementById('<%=HDfforosferiaOld.ClientID %>').value;
                                                    var forosferiaNew = document.getElementById('<%=HDfforosferiaNew.ClientID %>').value;
                                                    var redspaz = document.getElementById('<%=HDfredspaz.ClientID %>').value;

                                                    console.log("si entro paso 2" + fechaInicial + "fecha 2" + fechafinal);
                                                    $.ajax({
                                                        type: "POST",
                                                        url: '<%= ResolveUrl("Productividad.aspx/ChartDataSurAccionesta")%>',
                                                        data: "{'x': '" + x + "'}",
                                                        data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x, 'inclusion': inclusion, 'escolarOld': escolarOld, 'escolarNew': escolarNew, 'redesOld': redesOld, 'redesOldNew': redesOldNew, 'empreOld': empreOld, 'empreNew': empreNew, 'mujerOld': mujerOld, 'mujerNew': mujerNew, 'deporteNew': deporteNew, 'forosferiaOld': forosferiaOld, 'forosferiaNew': forosferiaNew, 'redspaz': redspaz }),
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
                                                            var accionesSur = [];
                                                            var cantidadesTotalSur = [];
                                                            var coloress = [];
                                                            $.each(dato, function (inx, val) {
                                                                accionesSur.push(val.etiquetaRSur);
                                                                cantidadesTotalSur.push(val.CantidadSur);

                                                            });

                                                            var ctx = document.getElementById("myChartAccioneSur");
                                                            var myPieChart = new Chart(ctx, {
                                                                type: 'doughnut',
                                                                data: {
                                                                    labels: accionesSur,
                                                                    datasets: [
                                                                        {
                                                                            label: 'Acciones',
                                                                            data: cantidadesTotalSur,
                                                                            //borderColor: "#3e95cd",
                                                                            fill: false,
                                                                            backgroundColor: getRandomColor(cantidadesTotalSur.length),
                                                                            //borderColor: getRandomColor(cantidadesTotal.length)

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
                                                }

                                            </script>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6" style="position: relative; width: 50vw">
                            <div class="card table-1-card">
                                <div class="card-block">

                                    <div class="chart-container">
                                        <canvas id="myChartBarSur"></canvas>
                                    </div>
                                    <script type="text/javascript">

                                        function ConsultaMunisur() {

                                            console.log("si entro paso 1");
                                            var x = "VARIABLE X";
                                            var fechaInicial = document.getElementById('<%=txtFechaini.ClientID %>').value;
                                            var fechafinal = document.getElementById('<%=txtDateFin.ClientID %>').value;
                                            var inclusion = document.getElementById('<%=HDfinclusion.ClientID %>').value;
                                            var redesOld = document.getElementById('<%=HDfredesOld.ClientID %>').value;
                                            var redesOldNew = document.getElementById('<%=HDfredesOldNew.ClientID %>').value;
                                            var escolarOld = document.getElementById('<%=HDfescolarOld.ClientID %>').value;
                                            var escolarNew = document.getElementById('<%=HDfescolarNew.ClientID %>').value;
                                            var mujerOld = document.getElementById('<%=HDfmujerOld.ClientID %>').value;
                                            var mujerNew = document.getElementById('<%=HDfmujerNew.ClientID %>').value;
                                            var empreOld = document.getElementById('<%=HDfempreOld.ClientID %>').value;
                                            var empreNew = document.getElementById('<%=HDfempreNew.ClientID %>').value;
                                            var deporteNew = document.getElementById('<%=HDfdeporteNew.ClientID %>').value;
                                            var forosferiaOld = document.getElementById('<%=HDfforosferiaOld.ClientID %>').value;
                                            var forosferiaNew = document.getElementById('<%=HDfforosferiaNew.ClientID %>').value;
                                            var redspaz = document.getElementById('<%=HDfredspaz.ClientID %>').value;

                                            $.ajax({
                                                type: "POST",
                                                url: '<%= ResolveUrl("Productividad.aspx/datoGraficabartesurMuni")%>',
                                                data: "{'x':'" + x + "'}",
                                                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x, 'inclusion': inclusion, 'escolarOld': escolarOld, 'escolarNew': escolarNew, 'redesOld': redesOld, 'redesOldNew': redesOldNew, 'empreOld': empreOld, 'empreNew': empreNew, 'mujerOld': mujerOld, 'mujerNew': mujerNew, 'deporteNew': deporteNew, 'forosferiaOld': forosferiaOld, 'forosferiaNew': forosferiaNew, 'redspaz': redspaz }),
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
                                                    console.log("SI ENTRÓ");
                                                    var Munisur = [];
                                                    var cantidadesTotalMunsur = [];
                                                    var coloress = [];
                                                    $.each(dato, function (inx, val) {
                                                        Munisur.push(val.Municipiossuro);
                                                        cantidadesTotalMunsur.push(val.CantidadMunisur);

                                                    });
                                                    var ctx = document.getElementById("myChartBarSur");
                                                    var myPieChart = new Chart(ctx, {
                                                        type: 'bar',
                                                        data: {
                                                            labels: Munisur,
                                                            datasets: [
                                                                {
                                                                    label: 'Acciones atendidas',
                                                                    data: cantidadesTotalMunsur,
                                                                    fill: false,
                                                                    backgroundColor: getRandomColor(cantidadesTotalMunsur.length),
                                                                    stack: 1
                                                                },
                                                            ]
                                                        },
                                                        options: {
                                                            title: {
                                                                display: true,
                                                                text: 'Total de Municipios'
                                                            }
                                                        },
                                                        tooltips: {
                                                            mode: 'index',
                                                            intersect: false
                                                        },
                                                        responsive: true,
                                                        scales: {
                                                            xAxes: [{
                                                                stacked: true,
                                                                maxRotation: 90,
                                                                minRotation: 90,
                                                                padding: -110
                                                            }],
                                                            yAxes: [{
                                                                stacked: true
                                                            }]
                                                        }
                                                    });
                                                }
                                            }

                                            function OnErrorCall_(response) { }
                                            console.log('EEROR:');
                                        }
                                    </script>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
            <br />

        </section>
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

    <div class="modal fade" id="ModalReporte" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="<%--modal-dialog--%> modal-dialog_pdf" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="modal-body">
                            <div class="row">
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Height="900px" Width="100%"></rsweb:ReportViewer>
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

</asp:Content>

