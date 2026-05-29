<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vista_Datos_Foraneo.aspx.cs" Inherits="SIICOP_V1._2.VistasReportes.Vista_Datos_Foraneo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/Chart.js"></script>
        <link href="../Content/StyleGraficasprogra.css" rel="stylesheet" />

   
    <br />
    <asp:HiddenField ID="HDFUSERID" runat="server" Value="0" />
    <asp:HiddenField ID="HDFRegion" runat="server" Value="0" />

    <link href="../Content/styleFormularios.css" rel="stylesheet" />
    <div class="container" style="padding-top:3%">
        <div class="row">
            <div id="sidebar">
                <div class="sosmed">
                    <div class="user">
                        <div class="user-head">
                            <h1>INFORME DE RESULTADOS DE</h1>
                            <div class="hr-center"></div>
                            <h5 style="color: #feff00">CAPTURA DE ACTIVIDADES</h5>
                        </div>
                        <div class="link-me">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="marketing">
                    <hr class="half">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="well">
                                <div class="container">
                                    <div class="row">
                                        <div class="col-lg-2">
                                            <div class="form-group has-feedback">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                    <asp:TextBox ID="txtFInicialC" runat="server" CssClass="form-control" placeholder="Fecha inicial"></asp:TextBox>
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

                                            <div class="col-lg-2">

                                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search" ></span>&nbsp;Buscar</asp:LinkButton>
                                            </div>

                                        </div>

                                        <div class="col-lg-1" runat="server" id="Div1">

                                            <asp:LinkButton ID="lkmapa" runat="server" CssClass="btn btn-warning" Style="font-size: 1.8em" Text="MAPA" title="Ver georeferencia" OnClick="lkmapa_Click"><span class="fas fa-map-marked-alt"></span>&nbsp;</asp:LinkButton>
                                        </div>

                                        <div class="col-lg-1" runat="server" id="Div2">

                                            <asp:LinkButton ID="lkGraficas" runat="server" CssClass="btn btn-info" Style="font-size: 1.8em" Text="GRAFICAS" title="Ver Graficas" OnClick="lkGraficas_Click"><span class="fas fa-chart-pie"></span>&nbsp;</asp:LinkButton>
                                        </div>
                                    </div>
                                    <br />

                                </div>
                            </div>
                        </div>
                        <hr class="half">
                    </div>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/Empresarial.png" />
                    <p>Enlace con el Sector Empresarial</p>
                </div>

                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/RedesVecinales.png" />
                    <p>Redes vecinales</p>
                </div>
                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/Escolar.png" />
                    <p>Seguridad Ciudadana y Paz Social en Entornos Educativos</p>
                </div>
                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/ViolenciaGenero.png" />
                    <p>Prevención de la Violencia por Razones de Género</p>
                </div>
                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/EncuentroCiudadano.png" />
                    <p>Encuentros Ciudadanos por la Seguridad</p>
                </div>
                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/ConstrucionCultura.png" />
                    <p>Inclusión de personas en situación de vunerabilidad</p>
                </div>

                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/DeporteYcultura.png" />
                    <p>Fomento a la Prevención a través del Deporte la Cultura</p>
                </div>
                <div class="col-md-1" style="text-align: center">
                    <img src="../Imagenes/PinesReporte/RedesVerPorLaPaz.png" />
                    <p>Redes Veracruzanas en la Construcción de la Paz</p>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="upd">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="container-fluid">
                    <div class="col-lg-2 pull-right">
                        <div class="form-group pull-right">
                            <asp:Label ID="lblTotalRegistros" runat="server" CssClass="label label-warning" Font-Size="18px" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div class="well" style="background-color: white">
                        <asp:GridView ID="GvInformeResultados" runat="server" CssClass="table table-condensed table-bordered" AutoGenerateColumns="False" Visible="true"
                            CellPadding="3" AllowPaging="True"
                            DataKeyNames="idResumenDiario" DataSourceID="EdsVistaInformeCapturas"
                            OnDataBound="GvInformeResultados_DataBound"
                            OnRowCommand="GvInformeResultados_RowCommand"
                            OnRowDataBound="GvInformeResultados_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="FolioActividad" HeaderText="Folio" HeaderStyle-CssClass="col-md-1" SortExpression="FolioActividad"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" DataFormatString="{0:dddd-dd-MMMM-yyyy}"></asp:BoundField>
                                <%--<asp:BoundField DataField="Personalid" HeaderText="Personalid" SortExpression="Personalid"></asp:BoundField>--%>
                                <asp:BoundField DataField="nombrecompleto" HeaderText="Nombre" SortExpression="nombrecompleto"></asp:BoundField>
                                <asp:BoundField DataField="NombreSubPrograma" HeaderText="SubPrograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                                <asp:BoundField DataField="AccionesNombre" HeaderText="Acciones" SortExpression="AccionesNombre"></asp:BoundField>
                                <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                                <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                                <asp:BoundField DataField="total_atendidos" HeaderText="Total atendidos" SortExpression="total_atendidos"></asp:BoundField>
                                <asp:BoundField DataField="descripcion_actividad" HeaderText="Descripción" SortExpression="descripcion_actividad"></asp:BoundField>
                                <asp:TemplateField HeaderText="programasID" SortExpression="programasID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("programasID") %>' ID="lblprogramasID"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pin">
                                    <ItemTemplate>
                                        <asp:Image runat="server" AlternateText='<%# Eval("programasID") %>' ID="imgpato" Width="25" Height="25"></asp:Image>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="¿Fotos cargadas?">
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" AlternateText='<%# Eval("fotos") %>' ID="imgFoto" Width="25" Height="25" CommandArgument='<%# Eval("idResumenDiario") %>' CommandName="VERFOTO" ToolTip="Ver fotos" />
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



                        <asp:EntityDataSource runat="server" ID="EdsVistaInformeCapturas" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                          EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico" OrderBy="it.[fecha] desc"
                          Where="((@fInicialC IS NULL OR it.fecha >= @fInicialC) AND (@fFinalC IS NULL OR it.fecha <= @fFinalC) AND (it.Personalid == @resp) and (@Folio is null or it.descripcion_actividad like '%' + @Folio + '%'))">
                          <WhereParameters>
                              <asp:SessionParameter DefaultValue="0" Name="resp" SessionField="responsable" DbType="Int32" />
                              <asp:SessionParameter SessionField="fInicialC" Name="fInicialC" Type="DateTime" />
                              <asp:SessionParameter SessionField="fFinalC" Name="fFinalC" Type="DateTime" />
                              <asp:ControlParameter ControlID="txtBusquedaFolio" Name="Folio" PropertyName="Text" Type="String" DefaultValue="" />
                          </WhereParameters>
                      </asp:EntityDataSource>


                        <asp:EntityDataSource runat="server" ID="EntityDataSource1" 
                            DefaultContainerName="SIICOPEntities" 
                            ConnectionString="name=SIICOPEntities"
                            EnableFlattening="False" 
                            EntitySetName="Wv_DatosReportesHistorico" 
                            OrderBy="it.[fecha] desc"
                            Where="((@fInicialC IS NULL OR it.fecha >= @fInicialC) AND (@fFinalC IS NULL OR it.fecha <= @fFinalC) AND (it.Personalid == @resp) AND (@Folio IS NULL OR it.descripcion_actividad LIKE '%' + @Folio + '%'))">
                            <WhereParameters>
                                <asp:SessionParameter Name="resp" SessionField="responsable" Type="Int32" DefaultValue="0" />
                                <asp:SessionParameter Name="fInicialC" SessionField="fInicialC" Type="DateTime" />
                                <asp:SessionParameter Name="fFinalC" SessionField="fFinalC" Type="DateTime" />        
                                <asp:ControlParameter ControlID="txtBusquedaFolio" Name="Folio" PropertyName="Text" 
                                    Type="String" ConvertEmptyStringToNull="true" />
                            </WhereParameters>
                       </asp:EntityDataSource>






                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <div class="modal fade bd-example-modal-lg" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ubicación geografica</h5>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-1" style="text-align: center">
                                    <img src="../Imagenes/PinesReporte/Empresarial.png" />
                                    <p>Empresarial</p>
                                </div>

                                <div class="col-md-2" style="text-align: center">
                                    <img src="../Imagenes/PinesReporte/RedesVecinales.png" />
                                    <p>Participación Ciudadana</p>
                                </div>
                                <div class="col-md-1" style="text-align: center">
                                    <img src="../Imagenes/PinesReporte/Escolar.png" />
                                    <p>Escuela Segura</p>
                                </div>
                                <div class="col-md-2" style="text-align: center">
                                    <img src="../Imagenes/PinesReporte/ViolenciaGenero.png" />
                                    <p>Violencia Contra la Mujer </p>
                                </div>
                                <div class="col-md-1" style="text-align: center">
                                    <img src="../Imagenes/PinesReporte/EncuentroCiudadano.png" />
                                    <p>Foros y Ferias </p>
                                </div>

                            </div>
                        </div>
                    </div>
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
            var IdUser = document.getElementById('<%=HDFUSERID.ClientID %>').value;
            var Tipoconsulta = 20;


            var url = '/json/ActividadesGeo.ashx?Tipoconsulta=' + Tipoconsulta + '&fechaInicial=' + fechaInicial + '&fechafinal=' + fechafinal + '&IdUser=' + IdUser;
            $.getJSON(url, function (data) {
                var f = 0;
                var content = [];
                var iconoIncidencia = "";
                var direccion = [];
                var geocoder = null;
                var myHtml = "";
                for (f; f < data.Puntos.length; f++) {

                    switch (data.Puntos[f].id) {
                       case 1:
                            imgTipoAlerta = "/Imagenes/PinesReporte/Empresarial.png";
                            break;
                        case 2:
                            imgTipoAlerta = "/Imagenes/PinesReporte/RedesVecinales.png";
                            break;
                        case 3:
                            imgTipoAlerta = "/Imagenes/PinesReporte/Escolar.png";
                            break;
                        case 4:
                            imgTipoAlerta = "/Imagenes/PinesReporte/ViolenciaGenero.png";
                            break;
                        case 5:
                            imgTipoAlerta = "/Imagenes/PinesReporte/ConstrucionCultura.png";
                            break;
                      
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

        };// termina boton

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
                                </div>
                                <div class="col-md-7">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="card table-card widget-primary-card">
                                                <div class="">
                                                    <div class="row-table">
                                                        <div class="col-sm-3 card-block-big">
                                                            <i class="fas fa-user-tie"></i>
                                                        </div>
                                                        <div class="col-sm-9">
                                                            <h2 runat="server" id="H2MombresBeneficiados"></h2>
                                                            <h4>Hombres beneficiados</h4>
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
                                                            <h2 runat="server" id="H2MujeresBeneficiadas"></h2>
                                                            <h4>Mujeres beneficiadas</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <br />
                            <section id="Grafica">
                                <div runat="server" id="zoonaNorte" visible="false">
                                    <h1 style="text-align: center; color: white; background-color: brown"><span>DATOS POR ZONA NORTE </span></h1>
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
                                </div>

                                <div runat="server" id="zoonaCentro" visible="false">
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
                                </div>

                                <div runat="server" id="zoonaSur" visible="false">
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
                                </div>
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

    <!-- Modal -->

    <script type="text/javascript">

        var colores;
        var x = "VARIABLE X";
        var fechaInicial = document.getElementById('<%=txtFInicialC.ClientID %>').value;
        var fechafinal = document.getElementById('<%=txtfechafin.ClientID %>').value;
        var IdUser = document.getElementById('<%=HDFUSERID.ClientID %>').value;


        //INICIO DE METODO DE LA ZONA CENTRO 
        function AccionescentroTtotal() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Vista_Datos_Foraneo.aspx/ChartDataCentroAccionesta")%>',
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'IdUser': IdUser, 'x': x }),
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
                url: '<%= ResolveUrl("Vista_Datos_Foraneo.aspx/datoGraficabarteCentroMuni")%>',
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'IdUser': IdUser, 'x': x }),
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

        function AccionTotalSur() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("Vista_Datos_Foraneo.aspx/DtAccionesSUR")%>',
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'IdUser': IdUser, 'x': x }),
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
                url: '<%= ResolveUrl("Vista_Datos_Foraneo.aspx/datoGraficabartesurMuni")%>',
                data: JSON.stringify({ 'fechaInicial': fechaInicial, 'fechafinal': fechafinal, 'IdUser': IdUser, 'x': x }),
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
    </script>
</asp:Content>
