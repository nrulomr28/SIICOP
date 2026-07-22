<%@ Page Title="CONSTRUCIÓN DE UNA CULTURA INCLUYENTE" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Informe_Construccion_Cultura_Incluyente.aspx.cs" Inherits="SIICOP_V1._2.VistasReportes.Informe_Construccion_Cultura_Incluyente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/styleFormularios.css" rel="stylesheet" />
    <script src="../Scripts/Chart.js"></script>
    <link href="../Content/BotonoesCargaTrabajo.css" rel="stylesheet" />
    <link href="../Content/StyleGraficasprogra.css" rel="stylesheet" /> 
    <div class="container" style="padding-top:3%">
        <div class="row">
            <div id="sidebar">
                <div class="sosmed">
                    <div class="user">
                        <div class="user-head">
                            <h1>VISTA DE DATOS DE LAS ACTIVIDADES CAPTURADAS</h1>
                            <div class="hr-center"></div>
                            <h5 style="color: #feff00">CONSTRUCIÓN DE UNA CULTURA INCLUYENTE</h5>
                        </div>
                        <div class="link-me">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- START MARKETING DIV-->

    <div class="container-fluid">

        <div class="well" style="background-color: white">
            <div class="row">
                <div class="col-lg-2">
                    <div class="form-group has-feedback">
                        <div class="input-group">
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                            <asp:TextBox ID="txtFInicialC" runat="server" CssClass="form-control" placeholder="Buscar por Fecha"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="ceFIC" runat="server" TargetControlID="txtFInicialC" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div class="col-lg-2">
                    <div class="form-group has-feedback">
                        <div class="input-group">
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                            <asp:TextBox ID="txtfechafin" runat="server" CssClass="form-control" placeholder="Fecha final"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechafin" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <asp:TextBox runat="server" ID="txtBusquedaFolio" CssClass="form-control" placeholder="Busqueda por asunto.."></asp:TextBox>
                    </div>
                </div>


                <div id="RESPONSA" runat="server">

                    <div class="col-lg-1">

                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
                    </div>

                    <div class="col-lg-1" runat="server" id="bottonExcel" visible="false">

                        <asp:LinkButton ID="lkbtnexcel" runat="server" CssClass="btn btn-success" Style="font-size: 1.8em" Text="excel" title="Exportar" OnClick="lkbtnexcel_Click"><span class="far fa-file-excel"></span>&nbsp;</asp:LinkButton>
                    </div>
                    <div class="col-lg-1" runat="server" id="dvCaegaTrabajo">

                        <asp:LinkButton ID="lnkbtnCarga" runat="server" CssClass="btn btn-primary" Style="font-size: 1.8em" Text="CargaTrabajo" title="Ver Carga de trabajo" OnClick="lnkbtnCarga_Click"><span class="fas fa-chart-line"></span>&nbsp;</asp:LinkButton>
                    </div>
                </div>

                <div class="col-lg-1" runat="server" id="Div1">

                    <asp:LinkButton ID="lkmapa" runat="server" CssClass="btn btn-warning" Style="font-size: 1.8em" Text="excel" title="Ver georeferencia" OnClick="lkmapa_Click"><span class="fas fa-map-marked-alt"></span>&nbsp;</asp:LinkButton>
                </div>

                <div class="col-lg-1" runat="server" id="Div2">

                    <asp:LinkButton ID="lkGraficas" runat="server" CssClass="btn btn-info" Style="font-size: 1.8em" Text="excel" title="Ver Graficas" OnClick="lkGraficas_Click"><span class="fas fa-chart-pie"></span>&nbsp;</asp:LinkButton>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-lg-2 pull-right">
                    <div class="form-group pull-right">
                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="label label-warning" Font-Size="18px" Font-Bold="true"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <asp:UpdatePanel runat="server" ID="upd">
                    <ContentTemplate>
                        <asp:GridView ID="GvIncluyenteCap" runat="server" CssClass="table table-condensed table-bordered" AutoGenerateColumns="False" Visible="false"
                            CellPadding="3" AllowPaging="True"
                            DataKeyNames="idResumenDiario" DataSourceID="EdsVistaEscolar"
                            OnDataBound="GvIncluyenteCap_DataBound"
                            OnRowCommand="GvIncluyenteCap_RowCommand"
                            OnRowDataBound="GvIncluyenteCap_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="FolioActividad" HeaderText="Folio" HeaderStyle-CssClass="col-md-1" SortExpression="FolioActividad"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" DataFormatString="{0:dddd-dd-MMMM-yyyy}"></asp:BoundField>
                               <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" SortExpression="MUNICIPIO"></asp:BoundField>
                                <asp:BoundField DataField="nombrecompleto" HeaderText="Capturista" SortExpression="nombrecompleto"></asp:BoundField>
                                <asp:BoundField DataField="personal_atendio_actividad" HeaderText="Encargado de actividad" SortExpression="personal_atendio_actividad"></asp:BoundField>
                                <asp:BoundField DataField="NombreSubPrograma" HeaderText="Nombre SubPrograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                                <asp:BoundField DataField="AccionesNombre" HeaderText="Acciones" SortExpression="AccionesNombre"></asp:BoundField>
                                <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                                <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                                <asp:BoundField DataField="total_atendidos" HeaderText="Total atendidos" SortExpression="total_atendidos"></asp:BoundField>
                                <asp:BoundField DataField="descripcion_actividad" HeaderText="Descripción" SortExpression="descripcion_actividad"></asp:BoundField>
                                <asp:TemplateField HeaderText="¿Fotos cargadas?">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" AlternateText='<%# Eval("fotos") %>' ID="imgCap" Width="25" Height="25" CommandArgument='<%# Eval("idResumenDiario") %>' CommandName="VERFOTO" ToolTip="Ver fotos" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="Editar" CommandName="Editar" CausesValidation="False" ID="lkbEditar" ToolTip="Editar" CommandArgument='<%# Eval("idResumenDiario") %>'>
                                    <i class="fas fa-edit" style="font-size:1.8em"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                        <asp:EntityDataSource runat="server" ID="EdsVistaEscolar" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                            EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico" OrderBy="it.[fecha] desc"
                            Where="((@fInicialC IS NULL OR it.fecha >= @fInicialC) AND (@fFinalC IS NULL OR it.fecha <= @fFinalC) AND (it.Personalid == @resp || it.nombrecompleto =='0' && it.programasID = 7) and (@Folio is null or it.descripcion_actividad like '%' + @Folio + '%'))">
                            <WhereParameters>
                                <asp:SessionParameter DefaultValue="xxxxxx" Name="resp" SessionField="responsable" Type="Int32" />
                                <asp:SessionParameter SessionField="fInicialC" Name="fInicialC" Type="DateTime" />
                                <asp:SessionParameter SessionField="fFinalC" Name="fFinalC" Type="DateTime" />
                                <asp:ControlParameter ControlID="txtBusquedaFolio" Name="Folio" PropertyName="Text" Type="String" DefaultValue="" />

                            </WhereParameters>
                        </asp:EntityDataSource>

                        <%--administrador--%>

                        <asp:GridView runat="server" ID="GvIncluyentedmin" AutoGenerateColumns="False" DataKeyNames="idResumenDiario" DataSourceID="EdsVistaEmpresarialAdmi"
                            CssClass="table table-condensed table-bordered" Visible="false" CellPadding="3" AllowPaging="True"
                            OnDataBound="GvIncluyentedmin_DataBound"
                            OnRowCommand="GvIncluyentedmin_RowCommand"
                            OnRowDataBound="GvIncluyentedmin_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="FolioActividad" HeaderText="Folio" HeaderStyle-CssClass="col-md-1" SortExpression="FolioActividad"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" DataFormatString="{0:dddd-dd-MMMM-yyyy}"></asp:BoundField>
                               <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" SortExpression="MUNICIPIO"></asp:BoundField>
                                <asp:BoundField DataField="nombrecompleto" HeaderText="Capturista" SortExpression="nombrecompleto"></asp:BoundField>
                                <asp:BoundField DataField="personal_atendio_actividad" HeaderText="Encargado de actividad" SortExpression="personal_atendio_actividad"></asp:BoundField>
                                <asp:BoundField DataField="AreaTrabajo" HeaderText="Área" SortExpression="AreaTrabajo"></asp:BoundField>
                                <asp:BoundField DataField="NombreSubPrograma" HeaderText="SubPrograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                                <asp:BoundField DataField="AccionesNombre" HeaderText="Acciones" SortExpression="AccionesNombre"></asp:BoundField>
                                <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                                <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                                <asp:BoundField DataField="total_atendidos" HeaderText="Total atendidos" SortExpression="total_atendidos"></asp:BoundField>
                                <asp:BoundField DataField="descripcion_actividad" HeaderText="Descripción" SortExpression="descripcion_actividad"></asp:BoundField>
                                <asp:TemplateField HeaderText="¿Fotos cargadas?">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" AlternateText='<%# Eval("fotos") %>' ID="imgAdmin" Width="25" Height="25" CommandArgument='<%# Eval("idResumenDiario") %>' CommandName="VERFOTO" ToolTip="Ver fotos" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="Editar" CommandName="Editar" CausesValidation="False" ID="lkbEditar" ToolTip="Editar" CommandArgument='<%# Eval("idResumenDiario") %>'>
                                    <i class="fas fa-edit" style="font-size:1.8em"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerTemplate>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-lg-1" style="text-align: right;">
                                        <h5>
                                            <asp:Label ID="MessageLabel" Text="Pág." runat="server" /></h5>
                                    </div>
                                    <div class="col-lg-2 col-md-3" style="text-align: left;">
                                        <asp:DropDownList ID="PageDropDownListAdmin" Width="60%" AutoPostBack="true" OnSelectedIndexChanged="PageDropDownListAdmin_SelectedIndexChanged" runat="server" CssClass="form-control" /></h3>
                                    </div>
                                    <div class="col-lg-10" style="text-align: right;">
                                        <h3>
                                            <asp:Label ID="CurrentPageLabelAdmin" runat="server" CssClass="label label-success" /></h3>
                                    </div>
                                </div>
                            </PagerTemplate>
                        </asp:GridView>
                        <asp:EntityDataSource runat="server" ID="EdsVistaEmpresarialAdmi" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                            EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico" OrderBy="it.[fecha] desc"
                            Where="((@fInicialC IS NULL OR it.fecha >= @fInicialC) AND (@fFinalC IS NULL OR it.fecha <= @fFinalC) AND (it.programasID = 7) and (@Folio is null or it.descripcion_actividad like '%' + @Folio + '%'))">
                            <WhereParameters>
                                <asp:SessionParameter DefaultValue="0" Name="resp" SessionField="responsable" DbType="Int32" />
                                <asp:SessionParameter SessionField="fInicialC" Name="fInicialC" Type="DateTime" />
                                <asp:SessionParameter SessionField="fFinalC" Name="fFinalC" Type="DateTime" />
                                <asp:ControlParameter ControlID="txtBusquedaFolio" Name="Folio" PropertyName="Text" Type="String" DefaultValue="" />
                            </WhereParameters>
                        </asp:EntityDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>




    <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ubicación geografica</h5>
                </div>
                <div class="modal-body">
                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBzKpx_jKJbeh1oiuY7p4pdfspnIcbmxco&callback=initMap" async="" defer=""></script>
                    <div id="map" style="width: 100%; height: 600px;"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var opcion = 0;
        var map;
        var markersArray = [];

        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 6,
                center: { lat: 19.5420462, lng: -96.9199274 },
                mapTypeControl: false,
                mapTypeControlOptions: {
                    style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
                    position: google.maps.ControlPosition.TOP_LEFT
                },
                zoomControl: true,
                zoomControlOptions: {
                    position: google.maps.ControlPosition.LEFT_BOTTOM
                },
                scaleControl: true,
                streetViewControl: true,
                streetViewControlOptions: {
                    position: google.maps.ControlPosition.LEFT_CENTER
                },
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
        }



        function MostrarPlanteles() {

            var fechaInicial = document.getElementById('<%=txtFInicialC.ClientID %>').value;
            var fechafinal = document.getElementById('<%=txtfechafin.ClientID %>').value;
            var ProgramaID = 1;

            var url = '/json/ActividadesGeo.ashx?ProgramaID=' + ProgramaID + '&fechaInicial=' + fechaInicial + '&fechafinal=' + fechafinal;
            $.getJSON(url, function (data) {
                var f = 0;
                var content = [];
                var iconoIncidencia = "";
                var direccion = [];
                var geocoder = null;
                var myHtml = "";
                for (f; f < data.Puntos.length; f++) {

                    switch (data.Puntos[f].id) {
                        case 7:
                            imgTipoAlerta = "/Imagenes/PinesReporte/ConstrucionCultura.png";
                            break;
                        case 8:
                            imgTipoAlerta = "/Imagenes/PinesReporte/RedesVecinales.png";
                            break;
                        case 9:
                            imgTipoAlerta = "/Imagenes/PinesReporte/Escolar.png";
                            break;
                        case 10:
                            imgTipoAlerta = "/Imagenes/PinesReporte/ViolenciaGenero.png";
                            break;
                        case 11:
                            imgTipoAlerta = "/Imagenes/PinesReporte/EncuentroCiudadano.png";
                            break;
                        case 12:
                            imgTipoAlerta = "/Imagenes/PinesReporte/DeporteYcultura.png";
                            break;
                        case 13:
                            imgTipoAlerta = "/Imagenes/PinesReporte/Empresarial.png";
                            break;
                        case 14:
                            imgTipoAlerta = "/Imagenes/PinesReporte/RedesVerPorLaPaz.png";
                            break;
                    }
                    marker = new google.maps.Marker({
                        position: { lat: data.Puntos[f].latitud, lng: data.Puntos[f].longitud },
                        map: map,
                        animation: google.maps.Animation.DROP,
                        icon: imgTipoAlerta
                    });

                    content[f] = '<div class="infoSeccion">' +

                        '<div id="streetview" style="width:100%px; height:200px;">' +
                        '</div>' +
                        '</div>';

                    markersArray.push(marker);
                    google.maps.event.addListener(marker, 'click', (function (marker, f) {
                        (marker, f)
                    })
                        (marker, f)
                    );



                    function stopDance(marker, f) {

                        for (var i = 0, length = markersArray.length; i < length; i++) {
                            if (markersArray[i].getAnimation() != null) {
                                //alert("Si entra" + markersArray);
                                markersArray[i].setAnimation(null);
                            }
                        }
                    }

                    function Animar(marker, f) {

                        markersArray[i].setAnimation(google.maps.Animation.BOUNCE);
                        setTimeout(function () {
                            marker.setAnimation(null)
                        }, 5000);
                    }

                }


            });

        };

        function openModal() {
            $('#exampleModal').modal();
            return false;
        }

        function openModalGrafi() {
            $('#exampleModalGrafica').modal();
            return false;
        }
    </script>



    <div class="modal fade bd-example-modal-lg" id="exampleModalGrafica" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialogGraf modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabelGrafica">Graficas</h5>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <section runat="server" id="atendidos">
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="card table-card widget-Blue-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-xs-3 col-sm-3  col-md-12  col-lg-3 card-block-big">
                                                            <i class="fas fa-users"></i>
                                                        </div>
                                                        <div class="col-xs-9 col-sm-9  col-md-12 col-lg-9">
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
                                        <div class="col-md-6">
                                            <div class="card table-card widget-verdeAgua-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-file-contract"></i>
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
                                        <div class="col-md-6">
                                            <div class="card table-card widget-success-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-globe-americas"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="MuniTtoatl"></h2>
                                                            <h4>Municipios atendidos</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="card table-card widget-primary-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-child"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="H2NinosBeneficiados"></h2>
                                                            <h4>Niños beneficiados</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="card table-card widget-primary-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-female"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="H2NinasBeneficiadas"></h2>
                                                            <h4>Niñas beneficiadas</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="card table-card widget-primary-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-user-tie"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="H3PadresFamilia"></h2>
                                                            <h4>Padres de familia beneficiados</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="card table-card widget-primary-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-female"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="H4MadresFamilia"></h2>
                                                            <h4>Madres de familia beneficiadas</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="card table-card widget-primary-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-user-graduate"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="H5DocentesH"></h2>
                                                            <h4>Docentes hombres beneficiados</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="card table-card widget-primary-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-user-nurse"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="H6DocentesM"></h2>
                                                            <h4>Docentes mujeres beneficiadas</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <br />
                            <section runat="server" id="Graficas">
                                <h1 style="text-align: center; background-color: brown; color: white"><span>DATOS POR ZONA NORTE </span></h1>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <div class="row">
                                            <div class="card table-card widget-Blue-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-xs-3 card-block-big">
                                                            <i class="fas fa-users"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="PersonasZonaNorte"></h2>
                                                            <h4>Beneficiados </h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="card table-card  widget-verdeAgua-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-file-contract"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="AccionesZonaNorte"></h2>
                                                            <h4>Acciones realizadas</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="card table-card  widget-success-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-xs-3 card-block-big">
                                                            <i class="fas fa-globe-americas"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="ZonaNorte"></h2>
                                                            <h4>Municipios antendidos</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="col-md-10">
                                        <div class="row">
                                            <div class="col-md-6" style="position: relative; width: 28vw">
                                                <div class="card table-1-card">
                                                    <div class="card-block">

                                                        <div class="chart-container">
                                                            <div class="panel-body">
                                                                <div>
                                                                    <canvas id="myChartPastelNorteAccionesES"></canvas>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-6" style="position: relative; width: 46vw">
                                                <div class="card table-1-card">
                                                    <div class="card-block">
                                                        <div class="chart-container">
                                                            <canvas id="myChartBarZonaNorteES"></canvas>
                                                        </div>
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
                                            <div class="card table-card  widget-Blue-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-xs-3 card-block-big">
                                                            <i class="fas fa-users"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="PersonasAtendidasZonaCentro"></h2>
                                                            <h4>Beneficiados</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="card table-card  widget-verdeAgua-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-file-contract"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="accionesRealizadasZonaCentro"></h2>
                                                            <h4>Acciones realizadas</h4>
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
                                                        <div class="col-xs-3 card-block-big">
                                                            <i class="fas fa-globe-americas"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="ZonaCentro"></h2>
                                                            <h4>Municipios atendidos</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-10">
                                        <div class="row">
                                            <div class="col-md-6" style="position: relative; width: 28vw">
                                                <div class="card table-1-card">
                                                    <div class="card-block">

                                                        <div class="chart-container" s>
                                                            <div class="panel-body">
                                                                <div>
                                                                    <canvas id="myChartAccionesCnetro"></canvas>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6" style="position: relative; width: 46vw">
                                                <div class="card table-1-card">
                                                    <div class="card-block">
                                                        <div class="chart-container">
                                                            <canvas id="myChartBarCentro"></canvas>
                                                        </div>
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
                                            <div class="card table-card  widget-Blue-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-xs-3 card-block-big">
                                                            <i class="fas fa-users"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="personasAtendidasZonaSur"></h2>
                                                            <h4>Beneficiados</h4>
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
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-file-contract"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="AccionesRealizadasSur"></h2>
                                                            <h4>Acciones realizadas</h4>
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
                                                        <div class="col-xs-3 card-block-big">
                                                            <i class="fas fa-globe-americas"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="ZonaSurRR"></h2>
                                                            <h4>Municipios antendidos</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-10">
                                        <div class="row">
                                            <div class="col-md-6" style="position: relative; width: 28vw">
                                                <div class="card table-1-card">
                                                    <div class="card-block">

                                                        <div class="chart-container">
                                                            <div class="panel-body">
                                                                <div>
                                                                    <canvas id="myChartAccioneSur"></canvas>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6" style="position: relative; width: 46vw">
                                                <div class="card table-1-card">
                                                    <div class="card-block">
                                                        <div class="chart-container">
                                                            <canvas id="myChartBarSur"></canvas>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <br />

                            </section>
                        </section>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- MODAL PARA VER IMAGENES -->
    <div class="modal fade" id="myModalConsultariMG" tabindex="-1" role="dialog" aria-labelledby="myModalLabelConsultaIMG">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabelConsultaiMG" style="text-align: center">EVIDENCIA FOTOGRAFICA.</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <asp:UpdatePanel ID="updPanel" runat="server">
                            <ContentTemplate>
                                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                    <!-- Indicators -->
                                    <ol class="carousel-indicators">
                                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                                        <li data-target="#myCarousel" data-slide-to="1" runat="server" id="foto1" visible="false"></li>
                                        <li data-target="#myCarousel" data-slide-to="2" runat="server" id="foto2" visible="false"></li>
                                        <li data-target="#myCarousel" data-slide-to="3" runat="server" id="foto3" visible="false"></li>
                                    </ol>

                                    <!-- Wrapper for slides -->
                                    <div class="carousel-inner">
                                        <div class="item active" runat="server" id="foto11" visible="false">
                                            <asp:Image ID="ImagenEvidencia1" runat="server" CssClass="tamañoImgCarru" />
                                        </div>
                                        <div class="item" runat="server" id="foto22" visible="false">
                                            <asp:Image ID="ImagenEvidencia2" CssClass="tamañoImgCarru" runat="server" />
                                        </div>

                                        <div class="item" runat="server" id="foto33" visible="false">
                                            <asp:Image ID="ImagenEvidencia3" runat="server" CssClass="tamañoImgCarru" />
                                        </div>
                                        <div class="item" runat="server" id="foto34" visible="false">
                                            <asp:Image ID="ImagenEvidencia4" runat="server" CssClass="tamañoImgCarru" />

                                        </div>
                                    </div>

                                    <!-- Left and right controls -->
                                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                                        <span class="glyphicon glyphicon-chevron-left"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="right carousel-control" href="#myCarousel" data-slide="next">
                                        <span class="glyphicon glyphicon-chevron-right"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>


                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <%-- MODAL PARA LAS CARGAS DE TRABAJO --%>
    <div class="modal fade" id="ModalConsultarCargasTtrabajo" tabindex="-1" role="dialog" aria-labelledby="myModalLabelConsultaIMG">
        <div class="modal-dialog modal-lgr" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabelConsultaCarga" style="text-align: center; font-size: 1.3em; color: #949ca0; text-transform: uppercase;">Cargas de trabajo &nbsp;<span class="fas fa-chart-line"></span></h4>
                </div>
                <div class="modal-body">
                    <h4 style="text-align: center; color: #949ca0; text-transform: uppercase;">ACCIONES Y BENEFICIADOS DEL MES DE: <strong runat="server" id="MesActividdesGral" style="color: forestgreen"></strong></h4>
                    <div class="row">

                        <div class="col-md-4">
                            <h5 style="text-align: center; color: #949ca0;  font-size: 20px; text-transform: uppercase;">XALAPA</h5>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-file-invoice"></i>&nbsp;
                          <i class="fas fa-arrow-up" runat="server" id="ArribagralAccionXAL" style="color: green" visible="false"></i>
                                                <i class="fas fa-arrow-down" runat="server" id="AbajoagralAccionXAL" style="color: red" visible="false"></i>
                                                <i class="fas fa-window-minimize" runat="server" id="mediogralAccionXAL" style="color: yellow" visible="false"></i>
                                                <br />
                                                <strong>TOTAL DE ACCIONES<strong runat="server" id="Strong2" style="color: forestgreen"></strong></strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjeXAL" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjtXAL" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-users"></i>&nbsp;
                                                  <br />
                                                <strong>TOTAL DE BENEFICIADOS</strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjeXAL" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjtXAL" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <h5 style="text-align: center; color: #949ca0;  font-size: 20px; text-transform: uppercase;">VERACRUZ</h5>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-file-invoice"></i>&nbsp;
                                                <i class="fas fa-arrow-up" runat="server" id="ArribagralAccionver" style="color: green" visible="false"></i>
                                                <i class="fas fa-arrow-down" runat="server" id="AbajogralAccionver" style="color: red" visible="false"></i>
                                                <i class="fas fa-window-minimize" runat="server" id="MediogralAccionver" style="color: yellow" visible="false"></i>
                                                <br />
                                                <strong>TOTAL DE ACCIONES<strong runat="server" id="Strong1" style="color: forestgreen"></strong></strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjeVER" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjtVER" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-users"></i>&nbsp;
                                                  <br />
                                                <strong>TOTAL DE BENEFICIADOS</strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjeVER" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObtVER" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <h5 style="text-align: center; color: #949ca0;  font-size: 20px; text-transform: uppercase;">POZA RICA</h5>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-file-invoice"></i>&nbsp;
                                                <i class="fas fa-arrow-up" runat="server" id="ArribagralAccionPOZA" style="color: green" visible="false"></i>
                                                <i class="fas fa-arrow-down" runat="server" id="AbajogralAccionPOZA" style="color: red" visible="false"></i>
                                                <i class="fas fa-window-minimize" runat="server" id="MediogralAccionPOZA" style="color: yellow" visible="false"></i>
                                                <br />
                                                <strong>TOTAL DE ACCIONES<strong runat="server" id="Strong3" style="color: forestgreen"></strong></strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjePOZA" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjtPOZA" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-users"></i>&nbsp;
                                                  <br />
                                                <strong>TOTAL DE BENEFICIADOS</strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjePOZA" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjtPOZA" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <br />
                    <div class="row">

                        <div class="col-md-4">
                            <h5 style="text-align: center; color: #949ca0;  font-size: 20px; text-transform: uppercase;">CORDOBA</h5>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-file-invoice"></i>&nbsp;
                          <i class="fas fa-arrow-up" runat="server" id="ArribagralAccionCOR" style="color: green" visible="false"></i>
                                                <i class="fas fa-arrow-down" runat="server" id="AbajogralAccionCOR" style="color: red" visible="false"></i>
                                                <i class="fas fa-window-minimize" runat="server" id="MediogralAccionCOR" style="color: yellow" visible="false"></i>
                                                <br />
                                                <strong>TOTAL DE ACCIONES<strong runat="server" id="Strong4" style="color: forestgreen"></strong></strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjeCOR" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjTCOR" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-users"></i>&nbsp;
                                                  <br />
                                                <strong>TOTAL DE BENEFICIADOS</strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjeCOR" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjtCOR" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <h5 style="text-align: center; color: #949ca0;  font-size: 20px; text-transform: uppercase;">COATZACOALCOS</h5>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-file-invoice"></i>&nbsp;
                                                <i class="fas fa-arrow-up" runat="server" id="ArribagralAccionCOATZA" style="color: green" visible="false"></i>
                                                <i class="fas fa-arrow-down" runat="server" id="AbajogralAccionCOATZA" style="color: red" visible="false"></i>
                                                <i class="fas fa-window-minimize" runat="server" id="MediogralAccionCOATZA" style="color: yellow" visible="false"></i>
                                                <br />
                                                <strong>TOTAL DE ACCIONES<strong runat="server" id="Strong5" style="color: forestgreen"></strong></strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjeCOATZA" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjtCOATZA" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-users"></i>&nbsp;
                                                  <br />
                                                <strong>TOTAL DE BENEFICIADOS</strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjeCOATZA" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjtCOATZA" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <h5 style="text-align: center; color: #949ca0;  font-size: 20px; text-transform: uppercase;">ENLACE</h5>
                            <div class="row">

                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-file-invoice"></i>&nbsp;
                                                <i class="fas fa-arrow-up" runat="server" id="ArribagralAccionENLACE" style="color: green" visible="false"></i>
                                                <i class="fas fa-arrow-down" runat="server" id="AbajogralAccionENLACE" style="color: red" visible="false"></i>
                                                <i class="fas fa-window-minimize" runat="server" id="MediogralAccionENLACE" style="color: yellow" visible="false"></i>
                                                <br />
                                                <strong>TOTAL DE ACCIONES<strong runat="server" id="Strong6" style="color: forestgreen"></strong></strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjeENLACE" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanAccionXareaObjtENLACE" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="col-lg-6 col-md-6">
                                            <div class="social-box ">
                                                <i class="fas fa-users"></i>&nbsp;
                                                  <br />
                                                <strong>TOTAL DE BENEFICIADOS</strong>
                                                <ul>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjeENLACE" style="color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>META</span>
                                                        </strong>

                                                    </li>
                                                    <li>
                                                        <strong><span class="count" runat="server" id="spanBeniTotalXareaObjtENLACE" style="text-align: center; color: forestgreen; font-size: 1.4em"></span>
                                                            <br />
                                                            <span>OBTENIDOS</span>
                                                        </strong>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>


                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->

    <script type="text/javascript">

        var colores;
        var x = "VARIABLE X";
        var fechaInicial = document.getElementById('<%=txtFInicialC.ClientID %>').value;
        var fechafinal = document.getElementById('<%=txtfechafin.ClientID %>').value;


        //METODOS PARA SACAR LAS GRAFICAS DE LA ZONA NORTE
        function ConsultaHombresXacciones() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Informe_Construccion_Cultura_Incluyente.aspx/ChartDataNorteAccionesta")%>',
                data: "{'x': '" + x + "'}",
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: LlenarGraficaAccionesNorte,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Alerta:" + textStatus + " : " + errorThrown);
                }
            });
            function LlenarGraficaAccionesNorte(response) {
                var dato = response.d;
                if (dato == null) {
                    console.log("NO TRAJO DATOS");
                }
                else {
                    console.log("SI ENTRÓ" + response);
                    var acciones = [];
                    var cantidadesTotal = [];
                    $.each(dato, function (inx, val) {
                        acciones.push(val.etiquetaR);
                        cantidadesTotal.push(val.Cantidad);

                    });

                    var ct = document.getElementById("myChartPastelNorteAccionesES");
                    var MyCahrtAccionesPatelNorte = new Chart(ct, {
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


        function ConsultaMuniNorte() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Informe_Construccion_Cultura_Incluyente.aspx/datoGraficabarteNorteMuni")%>',
                data: "{'x':'" + x + "'}",
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
                    console.log("SI ENTRÓ");
                    var Muni = [];
                    var cantidadesTotalMun = [];
                    $.each(dato, function (inx, val) {
                        Muni.push(val.Municipios);
                        cantidadesTotalMun.push(val.CantidadMuni);

                    });
                    var ctx = document.getElementById("myChartBarZonaNorteES");
                    var MyBarChartMuniNorte = new Chart(ctx, {
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
        //TERMINA EL METODO PARA ZONA NORTE


        //INICIO DE METODO DE LA ZONA CENTRO 
        function AccionescentroTtotal() {

            console.log("si entro paso 2" + fechaInicial + "fecha 2" + fechafinal);
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Informe_Construccion_Cultura_Incluyente.aspx/ChartDataCentroAccionesta")%>',
                data: "{'x': '" + x + "'}",
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: LlenarGraficaAccionesCentro,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Alerta:" + textStatus + " : " + errorThrown);
                }
            });
            function LlenarGraficaAccionesCentro(response) {
                var dato = response.d;
                if (dato == null) {
                    console.log("NO TRAJO DATOS");
                }
                else {
                    console.log("SI ENTRÓ" + response);
                    var accionesCentro = [];
                    var cantidadesTotalCentro = [];
                    $.each(dato, function (inx, val) {
                        accionesCentro.push(val.etiquetaRcentro);
                        cantidadesTotalCentro.push(val.Cantidadcentro);

                    });

                    var xt = document.getElementById("myChartAccionesCnetro");
                    var MyPieChartAccionesCentro = new Chart(xt, {
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


        function ConsultaMunicentro() {

            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Informe_Construccion_Cultura_Incluyente.aspx/datoGraficabarteCentroMuni")%>',
                data: "{'x':'" + x + "'}",
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
                    console.log("SI ENTRÓ");
                    var Municentro = [];
                    var cantidadesTotalMuncentro = [];
                    var coloress = [];
                    $.each(dato, function (inx, val) {
                        Municentro.push(val.Municipioscentro);
                        cantidadesTotalMuncentro.push(val.CantidadMunicentro);

                    });
                    var ctx = document.getElementById("myChartBarCentro");
                    var MyBarChartCentro = new Chart(ctx, {
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

        //TERMINO DEL METODO PARA SACR GARFICAS ZONA CENTRO 


        //INICIO DE METODO PARA LAS ZONA SUR 

        function AccionesSurTtotal() {


            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Informe_Construccion_Cultura_Incluyente.aspx/ChartDataSurAccionesta")%>',
                data: "{'x': '" + x + "'}",
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: LlenarGraficaAccionesZonaSur,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Alerta:" + textStatus + " : " + errorThrown);
                }
            });
            function LlenarGraficaAccionesZonaSur(response) {
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
                    var myPieChartZonaSurAcciones = new Chart(ctx, {
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




        function ConsultaMunisur() {

            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Informe_Construccion_Cultura_Incluyente.aspx/datoGraficabartesurMuni")%>',
                data: "{'x':'" + x + "'}",
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'x': x }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                dataFilter: function (data) { return data; },
                success: LlenarGraficaMuniZonaSur,
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Alerta:" + textStatus + " : " + errorThrown);
                }
            });
            function LlenarGraficaMuniZonaSur(response) {
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
                    var MyBarChartMuniZonSur = new Chart(ctx, {
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
        //TERMINO DEL METODO DE LA ZONA SUR 
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

        function AbrirModalFotos() {
            $('#myModalConsultariMG').modal();
            return false;
        }

        function AbrirModalCargasTrabajo() {
            $('#ModalConsultarCargasTtrabajo').modal();
            return false;
        }
    </script>

</asp:Content>


