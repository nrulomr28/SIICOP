<%@ Page Title="Consulta de actividades registradas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaActividadesRegistradas.aspx.cs" Inherits="SIICOP_V1._2.VistasReportes.ConsultaActividadesRegistradas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <link href="../Content/styleFormularios.css" rel="stylesheet" />
    <link href="../Content/vista-reportes.css" rel="stylesheet" />

    <div class="page-header-report">

    <h2>Consulta de Actividades</h2>

    <p>
        Consulta, filtrado y exportación de actividades registradas.
    </p>

</div>

    <div class="container-fluid">
        <div class="col-md-12">
            <div class="row">
                <div  class="col-lg-2 col-md-4 col-sm-6">
                     <div class="program-card">
                    <img src="../Imagenes/PinesReporte/Empresarial.png" />
                    <p>Enlace con el Sector Empresarial</p>
                         </div>
                </div>

                <div class="col-lg-2 col-md-4 col-sm-6">

                <div class="program-card">
                    <img src="../Imagenes/PinesReporte/RedesVecinales.png" />
                    <p>Redes vecinales</p>
                </div>
                    </div>
                <div class="col-lg-2 col-md-4 col-sm-6">

                    <div class="program-card">
                    <img src="../Imagenes/PinesReporte/Escolar.png" />
                    <p>Seguridad Ciudadana y Paz Social en Entornos Educativos</p>
                </div>
                    </div>
                <div class="col-lg-2 col-md-4 col-sm-6">

                    <div class="program-card">
                    <img src="../Imagenes/PinesReporte/ViolenciaGenero.png" />
                    <p>Prevención de la Violencia por Razones de Género</p>
                        </div>
                </div>
                <div class="col-lg-2 col-md-4 col-sm-6">

                    <div class="program-card">
                    <img src="../Imagenes/PinesReporte/EncuentroCiudadano.png" />
                    <p>Encuentros Ciudadanos por la Seguridad</p>
                        </div>
                </div>
                <div class="col-lg-2 col-md-4 col-sm-6">

                <div class="program-card">
                    <img src="../Imagenes/PinesReporte/ConstrucionCultura.png" />
                    <p>Inclusión de personas en situación de vunerabilidad</p>
                </div>
                    </div>

                <div class="col-lg-2 col-md-4 col-sm-6">

                    <div class="program-card">
                    <img src="../Imagenes/PinesReporte/DeporteYcultura.png" />
                    <p>Fomento a la Prevención a través del Deporte la Cultura</p>
                </div>
                    </div>
            </div>
        </div>
    </div>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="report-filters">

            <div class="container-fluid">                

                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group has-feedback">

                                <asp:Label ID="lblFInicialC" runat="server" Text="Fecha Inicial:" CssClass="control-label"></asp:Label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                    <asp:TextBox ID="txtFInicialC" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="ceFIC" runat="server" TargetControlID="txtFInicialC" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group has-feedback">
                                <asp:Label ID="Label2" runat="server" Text="Fecha final:" CssClass="control-label"></asp:Label>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                    <asp:TextBox ID="txtfechafin" runat="server" CssClass="form-control" autocomplete="off"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechafin" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="Label3" runat="server" Text="Zona:" CssClass="control-label"></asp:Label>
                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddlZona" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlZona_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label5" runat="server" Text="Municipio:" CssClass="control-label"></asp:Label>
                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddlMunicipio" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label6" runat="server" Text="Localidad:" CssClass="control-label"></asp:Label>
                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="col-md-2">
                            <asp:Label ID="Label4" runat="server" Text="Programa:" CssClass="control-label"></asp:Label>
                            <div class="form-group">
                                <asp:DropDownList runat="server" ID="ddlProgramas" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-4">
                            <asp:Label ID="Label7" runat="server" Text="Instituciones participantes:" CssClass="control-label"></asp:Label>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtInstitucionesParticipantes" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div id="RESPONSA" runat="server">

                            <div class="col-md-1">

                                <asp:LinkButton ID="btnBuscar" runat="server" 
                                    CssClass="btn btn-info" Text="Buscar" 
                                    OnClick="btnBuscar_Click">
                                    <span class="glyphicon glyphicon-search">

                                    </span>&nbsp;Buscar</asp:LinkButton>

                            </div>

                            <div class="col-md-2">

                                <div class="dropdown">
                                    <a href="#" class="btn btn-success dropdown-toggle" data-toggle="dropdown" aria-expanded="true"><b>Descargar</b> <b class="caret"></b>&nbsp;<span class="fa fa-download" aria-hidden="true"></span></a>
                                    <ul class="dropdown-menu">
                                        <li runat="server">
                                            <asp:LinkButton ID="lkbtnexcel" runat="server"  Text="excel" title="Exportar" OnClick="lkbtnexcel_Click">Actividades&nbsp;<span class="far fa-file-excel" ></span></asp:LinkButton>
                                        </li>
                                        <li runat="server">
                                            <asp:LinkButton ID="lnBtnExpCedula" runat="server"  Text="excel" title="Exportar" OnClick="lnBtnExpCedula_Click1">Cedulas &nbsp;<span ></span></asp:LinkButton>
                                        </li>

                                        <li runat="server">
                                            <asp:LinkButton ID="lnkbtnZip" runat="server"  Text="Foto" title="Exportar" OnClick="lnkbtnZip_Click">Imagenes &nbsp;<span  class="fa fa-file-archive"></span></asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-1" runat="server" id="Div1">
                            <asp:LinkButton ID="lkmapa" runat="server" CssClass="btn btn-warning" Text="excel" title="Ver georeferencia" OnClick="lkmapa_Click"><span class="fas fa-map-marked-alt"></span>&nbsp;</asp:LinkButton>
                        </div>
                    </div>


                    <div class="report-grid">

    <div class="report-grid-header">

        <h4 class="report-section-title">
            Resultados
        </h4>

        <asp:Label
            ID="lblTotalRegistros"
            runat="server"
            CssClass="report-total">
        </asp:Label>

    </div>

    <div class="table-responsive">

        <asp:GridView
            ID="GvPCAdmin"
            runat="server"
            EmptyDataText="Sin registros."

            CssClass="table table-striped table-bordered table-hover table-sm"

            CellPadding="3"

            AllowPaging="True"

            PageSize="10"

            AutoGenerateColumns="False"

            DataKeyNames="idResumenDiario,programasID"

            AllowSorting="True"

            OnRowCommand="GvPCAdmin_RowCommand"

            OnRowDataBound="GvPCAdmin_RowDataBound"

            OnRowCreated="GvPCAdmin_RowCreated">

            <Columns>

                <asp:BoundField
                    DataField="FolioActividad"
                    HeaderText="Folio"
                    SortExpression="FolioActividad" />

                <asp:TemplateField
                    HeaderText="Fecha"
                    SortExpression="fecha">

                    <ItemTemplate>

                        <asp:Label
                            ID="Label1"
                            runat="server"
                            Text='<%# Bind("fecha","{0:dddd-dd-MMMM-yyyy}") %>' />

                    </ItemTemplate>

                </asp:TemplateField>

                <asp:BoundField
                    DataField="MUNICIPIO"
                    HeaderText="Municipio"
                    SortExpression="MUNICIPIO" />

                <asp:BoundField
                    DataField="nombrecompleto"
                    HeaderText="Capturista"
                    SortExpression="nombrecompleto" />

                <asp:BoundField
                    DataField="personal_atendio_actividad"
                    HeaderText="Encargado de actividad"
                    SortExpression="personal_atendio_actividad" />

                <asp:BoundField
                    DataField="AreaTrabajo"
                    HeaderText="Delegación o Conurbación"
                    SortExpression="AreaTrabajo" />

                <asp:BoundField
                    DataField="NombrePrograma"
                    HeaderText="Programa"
                    SortExpression="NombrePrograma" />

                <asp:BoundField
                    DataField="NombreSubPrograma"
                    HeaderText="Subprograma"
                    SortExpression="NombreSubPrograma" />

                <asp:BoundField
                    DataField="AccionesNombre"
                    HeaderText="Acciones"
                    SortExpression="AccionesNombre" />

                <asp:BoundField
                    DataField="TotalHombresAtendidos"
                    HeaderText="Hombres"
                    SortExpression="TotalHombresAtendidos" />

                <asp:BoundField
                    DataField="TotalMujeresAtendidas"
                    HeaderText="Mujeres"
                    SortExpression="TotalMujeresAtendidas" />

                <asp:BoundField
                    DataField="total_atendidos"
                    HeaderText="Total beneficiados"
                    SortExpression="total_atendidos" />

                <asp:BoundField
                    DataField="descripcion_actividad"
                    HeaderText="Descripción"
                    SortExpression="descripcion_actividad" />

                <asp:TemplateField HeaderText="Pin">

                    <ItemTemplate>

                        <asp:Image
                            ID="imgpato"
                            runat="server"
                            Width="25"
                            Height="25"
                            AlternateText='<%# Eval("programasID") %>' />

                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" />

                </asp:TemplateField>

                <asp:TemplateField HeaderText="¿Fotos cargadas?">

                    <ItemTemplate>

                        <asp:ImageButton
                            ID="imgFoto"
                            runat="server"
                            Width="25"
                            Height="25"
                            AlternateText='<%# Eval("fotos") %>'
                            CommandArgument='<%# Eval("idResumenDiario") %>'
                            CommandName="VERFOTO"
                            ToolTip="Ver fotografías" />

                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" />

                </asp:TemplateField>

                <asp:TemplateField ShowHeader="False">

                    <ItemTemplate>

                        <asp:LinkButton

                            ID="lkbEditar"

                            runat="server"

                            CssClass="btn btn-primary btn-sm"

                            CommandName="Editar"

                            CommandArgument='<%# Eval("idResumenDiario") %>'

                            CausesValidation="False"

                            ToolTip="Editar">

                            <i class="fas fa-edit"></i>

                        </asp:LinkButton>

                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" />

                </asp:TemplateField>

                <asp:TemplateField ShowHeader="False">

                    <ItemTemplate>

                        <asp:LinkButton

                            ID="lkbEliminar"

                            runat="server"

                            CssClass="btn btn-danger btn-sm"

                            CommandName="Eliminar"

                            CommandArgument='<%# Eval("idResumenDiario") %>'

                            CausesValidation="False"

                            ToolTip="Eliminar">

                            <i class="fa fa-trash"></i>

                        </asp:LinkButton>

                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" />

                </asp:TemplateField>

            </Columns>

            <PagerTemplate>

                <div class="row align-items-center">

                    <div class="col-auto">

                        <strong>Página</strong>

                    </div>

                    <div class="col-auto">

                        <asp:DropDownList

                            ID="PageDropDownListAdmin"

                            runat="server"

                            CssClass="form-control"

                            AutoPostBack="true"

                            Width="90"

                            OnSelectedIndexChanged="PageDropDownListAdmin_SelectedIndexChanged" />

                    </div>

                    <div class="col">

                        <asp:Label

                            ID="CurrentPageLabelAdmin"

                            runat="server"

                            CssClass="text-muted" />

                    </div>

                </div>

            </PagerTemplate>

        </asp:GridView>

    </div>

</div>
                
            </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="lkbtnexcel" />
        </Triggers>

    </asp:UpdatePanel>



    <div class="modal fade bd-example-modal-lg" id="exampleModal" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg"  role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ubicación geografica</h5>
                </div>
                <div class="modal-body">
                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBzKpx_jKJbeh1oiuY7p4pdfspnIcbmxco&callback=initMap" defer=""></script>
                    <div id="map"></div>
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
                            var Tipoconsulta = 0;
                            var ProgramaID = document.getElementById('<%=ddlProgramas.ClientID %>').value;
                            var Region = document.getElementById('<%=ddlZona.ClientID %>').value;

                            var url = '../json/ActividadesGeo.ashx?ProgramaID=' + ProgramaID + '&fechaInicial=' + fechaInicial + '&fechafinal=' + fechafinal + '&Tipoconsulta=' + Tipoconsulta + '&Region=' + Region;
                            $.getJSON(url, function (data) {
                                var f = 0;
                                var content = [];

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


                                    var contentString =
                                        ' <div class="container-fluid">' +
                                    <%--CONTENEDOR PARA VISUALIZAR LA IMAGEN DE LA PERSONA Y TEXTO DESCRIPTIVO (?)--%>
                                        ' <div id="contenedorTwo">' +
                                        ' <div class="row">' +
                                        ' <div class="col-lg-4"></div>' +
                                        ' <div class="col-lg-4">' +
                                        '<div class="card-avatar">' +
                                        
                                        ' </div>' +
                                        '</div>' +
                                        ' <div class="col-lg-4"></div>' +
                                        ' </div>' +
                                        ' <h4  style="font-size: 2.3em;">Información de la actividad</h4>' +

                                        '</div>' +
                                        ' <br />' +
                                    <%-- TERMINA EL CONTENEDOR DE LA IMAGEN DE LA USUARIA --%>
                                        ' <div class="row">' +

                                        ' <div class="col-md-12">' +
                                        '<div class="infoSeccion">' +

                                                <%--<asp:UpdatePanel ID="upDatosUsuaria" runat="server">
                                                    <ContentTemplate>--%>
                                                    <%--//termina el card avatar--%>
                                        ' <div class="table">' +
                                        '<h5 class="category text-muted">' +
                                        ' <br>' +

                                        '<div class="card-description">' +
                                        '<ul class="list-group">' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Folio: </strong>&nbsp;' + data.Puntos[f].folio + '<strong id="folio" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Programa: </strong>&nbsp;' + data.Puntos[f].programa + '<strong id="nombrescuela" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">SubPrograma: </strong>&nbsp;' + data.Puntos[f].subprograma + '<strong id="direccion" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Acción: </strong>&nbsp;' + data.Puntos[f].accion + '<strong id="clave" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Delegación o Coordinación: </strong>&nbsp;' + data.Puntos[f].DleConur + '<strong id="niveledu" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Región:</strong> <strong id="zona" runat="server">&nbsp;' + data.Puntos[f].region + '</strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Zona:</strong>&nbsp;' + data.Puntos[f].Zona + '<strong id="muniz" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Municipio:</strong>&nbsp;' + data.Puntos[f].Municipios + '<strong id="muni" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Hombres atendidos:</strong>&nbsp;' + data.Puntos[f].hombres + '<strong id="h" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Mujeres atendidas:</strong>&nbsp;' + data.Puntos[f].mujeres + '<strong id="m" runat="server"></strong></li>' +
                                        ' <li class="list-group-item"><strong style="color: #5E2129">Total de beneficiados:</strong>&nbsp;' + data.Puntos[f].total + '<strong id="total" runat="server"></strong></li>' +
                                        ' <li class="list-group-item" Style="min-height: 60px;" Width="100%"><strong style="color: #5E2129">Persona que atendio la actividad:</strong>&nbsp;' + data.Puntos[f].personaAtendio + '<strong id="peros" runat="server"></strong></li>' +
                                        ' <li class="list-group-item" Style="min-height: 60px;" Width="100%"><strong style="color: #5E2129">Descripción:</strong>&nbsp;' + data.Puntos[f].descripcion + '<strong id="descri" runat="server"></strong></li>' +
                                        ' </ul>' +
                                        ' &nbsp;<br />' +



                                        '</div>' +
                                                        <%--//termina el card descripcion--%>
                                        '</div>' +
                                                    <%--//termina tABLE--%>
                                        ' </div>' +
                                                <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>

                                                <%--//termina el card perfil--%>

                                        '</div>' +
                                            <%--//termina el div de infoseccion--%>
                                        ' </div>' +
                                        <%--//termina el div  del col-md-10--%>
                                        ' </div>' +

                                    <%--// termina el div container;--%>
                                        '</div>';


                                    marker = new google.maps.Marker({
                                        position: { lat: data.Puntos[f].latitud, lng: data.Puntos[f].longitud },
                                        map: map,
                                        animation: google.maps.Animation.DROP,
                                        icon: imgTipoAlerta
                                    });

                                    var infowindow = new google.maps.InfoWindow();


                                    google.maps.event.addListener(marker, 'click', (function (marker, contentString) {
                                        return function () {
                                            infowindow.close();
                                            infowindow.setContent(contentString);
                                            infowindow.open(map, marker);
                                            infowindow.push()
                                            //google.maps.event.addListener(map, 'click', function () {
                                            //    infowindow.close();
                                            //});
                                        };
                                    })(marker, contentString));


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
                        // termina boton
                    </script>
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
                    <h4 class="modal-title" id="myModalLabelConsultaiMG" >Evidencia fotográfica</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <asp:UpdatePanel ID="updPanel" runat="server">
                            <ContentTemplate>
                                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                    <!-- Indicators -->
                                    <ol class="carousel-indicators">
                                        <%--<li data-target="#myCarousel" data-slide-to="0" class="active" id="foto11" visible="false"></li>--%>
                                        <li data-target="#myCarousel" data-slide-to="1" runat="server" id="foto1" visible="false"></li>
                                        <li data-target="#myCarousel" data-slide-to="2" runat="server" id="foto2" visible="false"></li>
                                        <li data-target="#myCarousel" data-slide-to="3" runat="server" id="foto3" visible="false"></li>
                                    </ol>

                                    <!-- Wrapper for slides -->
                                    <div class="carousel-inner">
                                        <div class="item active" runat="server" id="fotouno" visible="false">
                                            <asp:Image ID="ImagenEvidencia1" runat="server" CssClass="tamañoImgCarru" />
                                        </div>
                                        <div class="item" runat="server" id="fotodos" visible="false">
                                            <asp:Image ID="ImagenEvidencia2" CssClass="tamañoImgCarru" runat="server" />
                                        </div>

                                        <div class="item" runat="server" id="fototres" visible="false">
                                            <asp:Image ID="ImagenEvidencia3" runat="server" CssClass="tamañoImgCarru" />
                                        </div>
                                        <%--  <div class="item" runat="server" id="fotocuatro" visible="false">
                                            <asp:Image ID="ImagenEvidencia4" runat="server" CssClass="tamañoImgCarru" />

                                        </div>--%>
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

    <div class="modal fade" id="exampleModalValidador" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <h3 ><span class="fa fa-exclamation-triangle" aria-hidden="true" ></span></h3>
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


    <script type="text/javascript">
        function AbrirModalValidador() {
            $('#exampleModalValidador').modal();
            return false;
        }
        function openModal() {
            $('#exampleModal').modal();
            return false;
        }

        function AbrirModalFotos() {
            $('#myModalConsultariMG').modal();
            return false;
        }

    </script>
</asp:Content>
