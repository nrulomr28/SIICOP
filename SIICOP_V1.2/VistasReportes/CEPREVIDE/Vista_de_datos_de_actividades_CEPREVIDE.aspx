<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vista_de_datos_de_actividades_CEPREVIDE.aspx.cs" Inherits="SIICOP_V1._2.VistasReportes.CEPREVIDE.Vista_de_datos_de_actividades_CEPREVIDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <link href="../../Content/styleFormularios.css" rel="stylesheet" />


    <div class="container">
        <div class="row">
            <div id="sidebar">
                <div class="sosmed">
                    <div class="user">
                        <div class="user-head">
                            <h1>VISTA DE RESÚMENES DEL CEPREVIDE</h1>
                            <div class="hr-center"></div>

                        </div>
                        <div class="link-me">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="container-fluid">
        <div class="well" style="background-color: white">
            <div class="row">
                <div class="col-lg-2">
                    <div class="form-group has-feedback">
                        <div class="input-group">
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                            <asp:TextBox ID="txtFInicialC" runat="server" CssClass="form-control" placeholder="Fecha inicial" autocomplete="off"></asp:TextBox>
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
                            <asp:TextBox ID="txtfechafin" runat="server" CssClass="form-control" placeholder="Fecha final" autocomplete="off"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechafin" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div class="col-lg-1">
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="ddlZona" CssClass="form-control">
                            <asp:ListItem Value="0">-Seleccione-</asp:ListItem>
                            <asp:ListItem Value="1">Norte</asp:ListItem>
                            <asp:ListItem Value="2">Centro</asp:ListItem>
                            <asp:ListItem Value="3">Sur</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>

                <div class="col-lg-2">
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="ddlProgramas" CssClass="form-control" DataSourceID="edsProgramasBUsca" DataTextField="NombrePrograma" DataValueField="programasID" OnDataBound="ddlProgramas_DataBound"></asp:DropDownList>
                        <asp:EntityDataSource runat="server" ID="edsProgramasBUsca" DefaultContainerName="SIICOPEntities"
                            Where="it.programasID IN {22,23,24,25,26}"
                            ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="tb_programa">
                        </asp:EntityDataSource>
                    </div>
                </div>


                <div id="RESPONSA" runat="server">

                    <div class="col-lg-1">

                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search"></span>&nbsp;Buscar</asp:LinkButton>
                    </div>

                    <div class="col-lg-1">

                        <div class="dropdown">
                            <a href="#" class="btn btn-success dropdown-toggle" data-toggle="dropdown" aria-expanded="true"><b>Descargar</b> <b class="caret"></b>&nbsp;<span class="fa fa-download" aria-hidden="true"></span></a>
                            <ul class="dropdown-menu" style="font-size: 11px;">
                                <li runat="server">
                                    <asp:LinkButton ID="lkbtnexcel" runat="server" Style="font-size: 1.5em" Text="excel" title="Exportar" OnClick="lkbtnexcel_Click">Actividades&nbsp;<span class="far fa-file-excel" style="color:green"></span></asp:LinkButton>
                                </li>
                                <%-- <li runat="server">
                                    <asp:LinkButton ID="lnBtnExpCedula" runat="server" Style="font-size: 1.5em" Text="excel" title="Exportar" OnClick="lnBtnExpCedula_Click">Cedulas &nbsp;<span style="color:blue" class="fas fa-chart-line"></span></asp:LinkButton>
                                </li>--%>

                                <li runat="server">
                                    <asp:LinkButton ID="lnkbtnZip" runat="server" Style="font-size: 1.5em" Text="Foto" title="Exportar" OnClick="lnkbtnZip_Click">Imagenes &nbsp;<span style="color:RED" class="fa fa-file-archive"></span></asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </div>

                </div>
                <div class="col-lg-1" runat="server" id="Div1">

                    <asp:LinkButton ID="lkmapa" runat="server" CssClass="btn btn-warning" Style="font-size: 1.8em" Text="excel" title="Ver georeferencia" OnClick="lkmapa_Click"><span class="fas fa-map-marked-alt"></span>&nbsp;</asp:LinkButton>
                </div>

            </div>
            <br />
            <div class="col-lg-2 pull-right">
                <div class="form-group pull-right">
                    <asp:Label ID="lblTotalRegistros" runat="server" CssClass="label label-warning" Font-Size="18px" Font-Bold="true"></asp:Label>
                </div>
            </div>
            <div class="row">
                <asp:UpdatePanel runat="server" ID="upd">
                    <ContentTemplate>
                        <asp:GridView ID="GvPCAdmin" runat="server"
                            EmptyDataText="No se encontraron datos."
                            CssClass="table table-striped  table-bordered table-hover  table-sm table-responsive"
                            CellPadding="5" AllowPaging="True"
                            AutoGenerateColumns="False" DataKeyNames="idResumenDiario,programasID"
                            DataSourceID="EdsVistaPCaAdmin" AllowSorting="True"
                            OnRowDataBound="GvPCAdmin_RowDataBound"
                            OnRowCommand="GvPCAdmin_RowCommand">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:BoundField DataField="FolioActividad" HeaderText="Folio" SortExpression="FolioActividad"></asp:BoundField>

                                <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Bind("fecha", "{0:dddd-dd-MMMM-yyyy}") %>' ID="Label1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" SortExpression="MUNICIPIO"></asp:BoundField>
                                <asp:BoundField DataField="nombrecompleto" HeaderText="Capturista" SortExpression="nombrecompleto"></asp:BoundField>
                                <asp:BoundField DataField="personal_atendio_actividad" HeaderText="Encargado de actividad" SortExpression="personal_atendio_actividad"></asp:BoundField>
                                <asp:BoundField DataField="AreaTrabajo" HeaderText="Delegación o Conurbación" SortExpression="AreaTrabajo"></asp:BoundField>
                                <asp:BoundField DataField="NombrePrograma" HeaderText="Programa" SortExpression="NombrePrograma"></asp:BoundField>
                                <asp:BoundField DataField="NombreSubPrograma" HeaderText="Subprograma" SortExpression="NombreSubPrograma"></asp:BoundField>
                                <asp:BoundField DataField="AccionesNombre" HeaderText="Acciones" SortExpression="AccionesNombre"></asp:BoundField>
                                <asp:BoundField DataField="TotalHombresAtendidos" HeaderText="Hombres" SortExpression="TotalHombresAtendidos"></asp:BoundField>
                                <asp:BoundField DataField="TotalMujeresAtendidas" HeaderText="Mujeres" SortExpression="TotalMujeresAtendidas"></asp:BoundField>
                                <asp:BoundField DataField="total_atendidos" HeaderText="Total beneficiados" SortExpression="total_atendidos"></asp:BoundField>
                                <asp:BoundField DataField="descripcion_actividad" HeaderText="Descripción" SortExpression="descripcion_actividad"></asp:BoundField>

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
                                        <asp:DropDownList ID="PageDropDownListAdmin" Width="60%" AutoPostBack="true" runat="server" CssClass="form-control" /></h3>
                                    </div>
                                    <div class="col-lg-10" style="text-align: right;">
                                        <h3>
                                            <asp:Label ID="CurrentPageLabelAdmin" runat="server" CssClass="label label-success" /></h3>
                                    </div>
                                </div>
                            </PagerTemplate>
                        </asp:GridView>
                        <asp:EntityDataSource runat="server" ID="EdsVistaPCaAdmin" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities"
                            EnableFlattening="False" EntitySetName="Wv_DatosReportesHistorico"
                            OrderBy="it.[fecha] desc"
                            Where="((@fInicialC IS NULL OR it.fecha >= @fInicialC) AND (@fFinalC IS NULL OR it.fecha <= @fFinalC) and (it.Dependencia == 'CEPREVIDE' )  AND
                            ((it.RegionID == @zona || @zona==0) and (it.programasID == @progra || @progra == 0)))">
                            <WhereParameters>
                                <asp:SessionParameter SessionField="fInicialC" Name="fInicialC" Type="DateTime" />
                                <asp:SessionParameter SessionField="fFinalC" Name="fFinalC" Type="DateTime" />
                                <asp:ControlParameter ControlID="ddlProgramas" Name="progra" DbType="Int32" DefaultValue="0" />
                                <asp:ControlParameter ControlID="ddlZona" Name="zona" DbType="Int32" DefaultValue="0" />

                            </WhereParameters>
                        </asp:EntityDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>


    <!-- Modal para validar que pongan fechas  -->

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


    <%-- MODAL PARA LA GNERACION DE LOS PUNTOS EN EL MAPA --%>
    <div class="modal fade bd-example-modal-lg" id="exampleModal" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="width: 100% !important" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ubicación geografica</h5>
                </div>
                <div class="modal-body">
                    <asp:HiddenField runat="server" ID="hfDependencia" Value="" />
                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBKNdB_BzlNlxf84AMZK6C_T7tzodsLpy4&callback=initMap" defer=""></script>
                    <div id="map" style="width: 100%; height: 600px;"></div>
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

                        function MostrarActDependencias() {

                            var fechaInicial = document.getElementById('<%=txtFInicialC.ClientID %>').value;
                            var fechafinal = document.getElementById('<%=txtfechafin.ClientID %>').value;
                            var Dependencia = document.getElementById('<%=hfDependencia.ClientID %>').value;;
                            var ProgramaID = document.getElementById('<%=ddlProgramas.ClientID %>').value;;

                            var url = '../../json/ActividadesGeoDependencias.ashx?ProgramaID=' + ProgramaID + '&fechaInicial=' + fechaInicial + '&fechafinal=' + fechafinal + '&Dependencia=' + Dependencia;
                            $.getJSON(url, function (data) {
                                var f = 0;
                                var content = [];

                                for (f; f < data.Puntos.length; f++) {
                                    switch (data.Puntos[f].id) {
                                        case 22:
                                            imgTipoAlerta = "../../Imagenes/Banner/CEPREVIDE/Pines/Pin_ParticipaCiudadana.png";
                                            break;
                                        case 23:
                                            imgTipoAlerta = "../../Imagenes/Banner/CEPREVIDE/Pines/Pin_Escolar.png";
                                            break;
                                        case 24:
                                            imgTipoAlerta = "../../Imagenes/Banner/CEPREVIDE/Pines/Pin_GruposVulnerables.png";
                                            break;
                                        case 25:
                                            imgTipoAlerta = "../../Imagenes/Banner/CEPREVIDE/Pines/Pin_CulturaLegalidadyDenuncia.png";
                                            break;
                                        case 26:
                                            imgTipoAlerta = "../../Imagenes/Banner/CEPREVIDE/Pines/Pin_Espacios.png";;
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
                                        //' <i class="fas fa-scroll" style="font-size: 2.3em;"></i>' +
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

                        };// termina boton
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
