<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CapturaReporteActividades.aspx.cs" Inherits="SIICOP_V1._2.Captura.CapturaReporteActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--Prestada por Claudia--%>
    <asp:HiddenField ID="HiddenField1cn" runat="server" Value="0" />
    <div class="container-fluid" id="main" style="padding-top: 3%">
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                <div id="sidebar">
                    <div class="sosmed">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="row" style="display: flex; align-items: center;">
                                    <div class="col-sm-3 text-center">
                                        <img src="../Imagenes/data-entry.png"
                                            style="width: 48px; height: 48px;" />
                                    </div>
                                    <div class="user-head">
                                        <h3 style="margin-top: 0; margin-bottom: 5px; font-size: 16px; font-weight: bold;">REPORTE DE ACTIVIDADES
                                        </h3>
                                        <h5>
                                            <asp:Label ID="lblPrograma"
                                                runat="server"
                                                CssClass="label label text-warning">
                                            </asp:Label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 col-md-9 col-sm-8 col-xs-12">
                <div id="content">
                    <!-- start:main content -->
                    <div class="main-content">
                        <ul class="timeline">
                            <!-- start:profile -->
                            <li id="id-profile">
                                <div class="timeline-badge default"><i class="fa fa-user" data-original-title="" title=""></i></div>
                                <h3 class="timeline-head"><strong style="color: #34495e">Datos generales</strong></h3>
                            </li>
                            <li id="profile">
                                <div class="timeline-badge primary"></div>
                                <div class="timeline-panel">
                                    <h4 style="text-align: center">
                                        <asp:Label ID="lblfecha" runat="server" Text=""></asp:Label>
                                    </h4>
                                    <div class="hr-left"></div>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div id="DatosGenerales" class="form-horizontal">
                                                <div class="row gy-3 gx-4">
                                                    <!-- Responsable -->
                                                    <div class="col-md-5">
                                                        <label class="control-label">Responsable</label>
                                                        <asp:TextBox ID="txtResponsable" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <!-- Área/Departamento -->
                                                    <div class="col-md-5">
                                                        <label class="control-label">Área/Departamento</label>
                                                        <asp:TextBox ID="txtArea" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <!-- Fecha de la actividad -->
                                                    <div class="col-md-2">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <label class="control-label">Fecha de la actividad</label>
                                                                <div class="input-group date" id="datetimepicker1">
                                                                    <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control"
                                                                        placeholder="dd/mm/aaaa" autocomplete="off" AutoPostBack="true" />
                                                                    <ajaxToolkit:CalendarExtender ID="DateNacimiento_CalendarExtender" runat="server"
                                                                        BehaviorID="DateNacimiento_CalendarExtender" TargetControlID="txtFecha"
                                                                        Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                                    <span class="input-group-addon">
                                                                        <span class="glyphicon glyphicon-calendar" style="color: #820E2E"></span>
                                                                    </span>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                                <div id="PanelCoordinacion" runat="server">
                                                    <div class="row gy-3 gx-4">
                                                        <div class="col-md-4">
                                                            <label class="control-label">Coordinador</label>
                                                            <asp:DropDownList runat="server" ID="txtCoordinador" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlZona_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <%-- <asp:TextBox ID="txtCoordinador" MaxLength="200" CssClass="form-control" runat="server"></asp:TextBox>  --%>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="control-label">Región</label>
                                                            <asp:DropDownList runat="server" ID="ddlZona" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlZona_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <label class="control-label">Región estrategia</label>
                                                            <asp:DropDownList runat="server" ID="ddlCoordinacion" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </li>
                            <!-- start:resume -->
                            <li id="id-resume">
                                <!-- CAMBIO: Se cambió "default" por "primary" para que el círculo tome color, y se agregó "fas" a FontAwesome -->
                                <div class="timeline-badge primary"><i class="fas fa-globe" title="Ubicación"></i></div>
                                <h3 class="timeline-head"><strong style="color: #34495e">Ubicación</strong></h3>
                            </li>
                                <%--Del Depto--%>
                            <li id="resumen">
                                <div class="timeline-badge warning"></div>
                                <div class="timeline-panel">

                                    <div class="hr-left"></div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <script type="text/javascript">
                                                // This example displays an address form, using the autocomplete feature
                                                // of the Google Places API to help users fill in the information.
                                                var dir = "";
                                                var placeSearch, autocomplete;
                                                var componentForm = {
                                                    street_number: 'short_name',
                                                    colony: 'long_name',
                                                    route: 'long_name',
                                                    locality: 'long_name',
                                                    administrative_area_level_1: 'short_name',
                                                    country: 'long_name',
                                                    postal_code: 'short_name'

                                                };
                                                var marcadorClicMapa;

                                                function initMap() {
                                                    var map = new google.maps.Map(document.getElementById('map'), {
                                                        center: { lat: 17.9986108, lng: -98.2021055 },
                                                        zoom: 7,
                                                    });
                                                    var input = /** @type {!HTMLInputElement} */(
                                                        document.getElementById('autocomplete'));


                                                    var autocomplete = new google.maps.places.Autocomplete(input);
                                                    autocomplete.bindTo('bounds', map);

                                                    var infowindow = new google.maps.InfoWindow();
                                                    var marker = new google.maps.Marker({
                                                        map: map,

                                                        anchorPoint: new google.maps.Point(0, -29)
                                                    });

                                                    autocomplete.addListener('place_changed', function () {
                                                        infowindow.close();
                                                        marker.setVisible(false);
                                                        var place = autocomplete.getPlace();
                                                        if (!place.geometry) {
                                                            // User entered the name of a Place that was not suggested and
                                                            // pressed the Enter key, or the Place Details request failed.
                                                            window.alert("No details available for input: '" + place.name + "'");
                                                            return;
                                                        }

                                                        // If the place has a geometry, then present it on a map.
                                                        if (place.geometry.viewport) {
                                                            map.fitBounds(place.geometry.viewport);
                                                        } else {
                                                            map.setCenter(place.geometry.location);
                                                            map.setZoom(17);  // Why 17? Because it looks good.
                                                        }
                                                        marker.setIcon(/** @type {google.maps.Icon} */({
                                                            url: place.icon,
                                                            size: new google.maps.Size(71, 71),
                                                            origin: new google.maps.Point(0, 0),
                                                            anchor: new google.maps.Point(17, 34),
                                                            scaledSize: new google.maps.Size(35, 35)
                                                        }));
                                                        marker.setPosition(place.geometry.location);
                                                        marker.setVisible(true);
                                                        document.getElementById('latlng').value = place.geometry.location;
                                                        var dir = document.getElementById('autocomplete').value; coordenada = place.geometry.location;
                                                        coordenada = coordenada.toString();
                                                        arregloDeSubCadenas = separarCoord(coordenada);
                                                        //se cambio de esta manera por que asi es como le puedes poner un runat server
                                                        //document.getElementById(component).value = '';
                                                        $("[id*='" + 'lati' + "']").val(arregloDeSubCadenas[0]);
                                                        $("[id*='" + 'lati' + "']").removeAttr('disabled');
                                                        console.log("--cuarta ENCUENTRO = " + 'lati' + arregloDeSubCadenas[0]);



                                                        //se cambio de esta manera por que asi es como le puedes poner un runat server
                                                        //document.getElementById('longi').value = arregloDeSubCadenas[1];
                                                        $("[id*='" + 'longi' + "']").val(arregloDeSubCadenas[1]);
                                                        $("[id*='" + 'longi' + "']").removeAttr('disabled');
                                                        console.log("--quinto ENCUENTRO = " + 'longi' + arregloDeSubCadenas[1]);


                                                        var address = '';
                                                        if (place.address_components) {
                                                            address = [
                                                                (place.address_components[0] && place.address_components[0].short_name || ''),
                                                                (place.address_components[1] && place.address_components[1].short_name || ''),
                                                                (place.address_components[2] && place.address_components[2].short_name || '')
                                                            ].join(' ');
                                                        }

                                                        infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
                                                        infowindow.open(map, marker);

                                                        $("[id*='" + 'txtdireccomple' + "']").removeAttr('disabled');

                                                        var array = dir.split(',');
                                                        document.getElementById('route').value = array[0];
                                                        $("[id*='" + 'route' + "']").val(array[0]);
                                                        $("[id*='" + 'route' + "']").removeAttr('disabled');
                                                        console.log("--segundo ENCUENTRO = " + 'route' + array[0]);

                                                        document.getElementById('colony').value = array[1];
                                                        $("[id*='" + 'colony' + "']").val(array[1]);
                                                        $("[id*='" + 'colony' + "']").removeAttr('disabled');
                                                        console.log("--TERCER ENCUENTRO = " + 'colony' + array[1]);

                                                        document.getElementById('locality').value = array[2];
                                                        $("[id*='" + 'locality' + "']").val(array[2]);
                                                        $("[id*='" + 'locality' + "']").removeAttr('disabled');
                                                        console.log("--cuarto ENCUENTRO = " + 'locality' + array[2]);

                                                        document.getElementById('administrative_area_level_1').value = array[3];
                                                        $("[id*='" + 'administrative_area_level_1' + "']").val(array[3]);
                                                        $("[id*='" + 'administrative_area_level_1' + "']").removeAttr('disabled');
                                                        console.log("--se ENCUENTRO = " + 'administrative_area_level_1' + array[3]);
                                                    });

                                                    google.maps.event.addListener(map, "click", function (event) {
                                                        var geocoder = new google.maps.Geocoder;
                                                        geocoder.geocode({ 'location': event.latLng }, function (results, status) {
                                                            if (status === google.maps.GeocoderStatus.OK) {

                                                                if (results[1]) {
                                                                    if (marcadorClicMapa != null)
                                                                        marcadorClicMapa.setMap(null);
                                                                    marcadorClicMapa = new google.maps.Marker({
                                                                        position: event.latLng,
                                                                        map: map,
                                                                        title: 'Punto Seleccionado'

                                                                    });
                                                                    var infowindow = new google.maps.InfoWindow({
                                                                        content: results[0].formatted_address,
                                                                        maxWidth: 200
                                                                    });
                                                                    console.log("lating" + event.latLng);
                                                                    coordenadaXpunto = event.latLng;
                                                                    coordenadaXpunto = coordenadaXpunto.toString();
                                                                    arregloDeSubCadenasXpunto = separarCoord(coordenadaXpunto);

                                                                    $("[id*='" + 'lati' + "']").val(arregloDeSubCadenasXpunto[0]);
                                                                    $("[id*='" + 'lati' + "']").removeAttr('disabled');

                                                                    $("[id*='" + 'longi' + "']").val(arregloDeSubCadenasXpunto[1]);
                                                                    $("[id*='" + 'longi' + "']").removeAttr('disabled');


                                                                    console.log("geo" + results[0].formatted_address);
                                                                    var direcMarker = results[0].formatted_address;
                                                                    var arrayDireccion = direcMarker.split(',');
                                                                    document.getElementById('route').value = arrayDireccion[0];
                                                                    $("[id*='" + 'route' + "']").val(arrayDireccion[0]);
                                                                    $("[id*='" + 'route' + "']").removeAttr('disabled');


                                                                    document.getElementById('colony').value = arrayDireccion[1];
                                                                    $("[id*='" + 'colony' + "']").val(arrayDireccion[1]);
                                                                    $("[id*='" + 'colony' + "']").removeAttr('disabled');




                                                                    marcadorClicMapa.metadata = { "txt": results[0].formatted_address };
                                                                    infowindow.open(map, marcadorClicMapa);
                                                                    marcadorClicMapa.addListener('click', function () {
                                                                        infowindow.open(map, marcadorClicMapa);
                                                                    });
                                                                } else {
                                                                    //alert('No results found');
                                                                }
                                                            } else {
                                                                //alert('Geocoder failed due to: ' + status);
                                                            }
                                                        });
                                                    }); //end addListener
                                                }

                                                function separarCoord(str) {
                                                    str = str.replace("(", "");
                                                    str = str.replace(")", "");
                                                    str = str.replace(" ", "");
                                                    str = str.split(",");

                                                    return str;
                                                }



                                                function VerDireccionMapa() {

                                                    var ActividadId = document.getElementById('<%=HiddenField1cn.ClientID %>').value;
                                                console.log("Si entro");
                                                console.log("Actividad ID" + ActividadId);
                                                $.ajax({
                                                    type: "POST",
                                                    contentType: "application/json; charset=utf-8",
                                                    dataType: "json",
                                                    url: '<%= ResolveUrl("EsculaSegura.aspx/Cordenadas")%>',
                                                    data: JSON.stringify({ 'ActividadId': ActividadId }),
                                                    success: OnSuccess,
                                                    failure: function (response) {

                                                        //alert(response.d);
                                                    },
                                                    error: function (response) {

                                                    }
                                                });

                                                    function OnSuccess(response) {
                                                        latitude = response.latitud;
                                                        longitude = response.longitud;
                                                        var items = response.d;

                                                        $.each(items, function (index, val) {

                                                            marker = new google.maps.Marker({
                                                                position: { lat: val.Latitud, lng: val.Longitud },
                                                                map: map,

                                                            });

                                                            marker.addListener('click', toggleBounce);

                                                            function toggleBounce() {
                                                                if (marker.getAnimation() !== null) {
                                                                    marker.setAnimation(null);
                                                                } else {
                                                                    marker.setAnimation(google.maps.Animation.BOUNCE);

                                                                }
                                                            }
                                                            marker.setMap(map);
                                                            map.setCenter({ lat: val.Latitud, lng: val.Longitud });
                                                            map.setZoom(15);



                                                        });

                                                    }
                                                }
                                            </script>
                                            <%--<div id="PanelAccionImplentada" runat="server" visible="false">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="form-group form-group-sm">
                                                                    <label for="exampleInputEmail1">Acción implementada</label>
                                                                    <div>
                                                                        <asp:TextBox ID="txtAccionImplementada" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>                                            <%--<div class="col-md-3">
                                                            <label for="exampleInputEmail1">Nombre del contacto</label>
                                                            <asp:TextBox ID="txtnombrecontacto" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label for="exampleInputEmail1">Tel/Cel</label>
                                                            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>--%>                                            <%--<div id="PanelAccionImplentada" runat="server" visible="false">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="form-group form-group-sm">
                                                                    <label for="exampleInputEmail1">Acción implementada</label>
                                                                    <div>
                                                                        <asp:TextBox ID="txtAccionImplementada" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                            <%--<div class="col-md-3">
                                                            <label for="exampleInputEmail1">Nombre del contacto</label>
                                                            <asp:TextBox ID="txtnombrecontacto" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label for="exampleInputEmail1">Tel/Cel</label>
                                                            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>--%>
                                            <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAI08v0vd-dWhFIxanIu5O5wlnYfmYto-Y&libraries=places&callback=initMap" async defer></script>


                                            <div id="map" style="height: 300px;"></div>
                                        </div>
                                    </div>
                                    <div id="address">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-3 control-label">Buscar la dirección</label>
                                                    <div class="col-md-12">
                                                        <div class="label">
                                                            <input id="autocomplete" class="form-control" style="width: 70% !important" placeholder="Ingresa la dirección" type="text" value="" />
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-11 control-label">Coordenadas </label>
                                                    <div class="wideField" colspan="2">
                                                        <input class="field form-control" type="text" id="latlng" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-6">Latitud</label>
                                                    <div class="wideField" colspan="2">
                                                        <input class="field form-control" runat="server" type="text" id="lati" disabled="disabled" required autofocus />

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-3 control-label">Longitud</label>
                                                    <div class="wideField" colspan="2">
                                                        <input class="field form-control" type="text" id="longi" runat="server" disabled="disabled" />

                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>

                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-6">Calle</label>
                                                            <input class="form-control" id="route" type="text" disabled="disabled" runat="server" clientidmode="Static" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-3 control-label">Colonia</label>
                                                            <input class=" form-control" id="colony" type="text" disabled="disabled" runat="server" clientidmode="Static" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-3">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-3 control-label">Municipio</label>
                                                            <asp:DropDownList runat="server" ID="ddlMuNICIPIO" CssClass="form-control" DataTextField="MUNICIPIO" DataValueField="MunicipioID" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>


                                                    <div class="col-md-3">
                                                        <label class="col-md-4 control-label">Localidad</label>
                                                        <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-control" DataTextField="Localidad" DataValueField="LocalidadID">
                                                        </asp:DropDownList>
                                                    </div>


                                                </div>



                                                <div id="PanelMunicipiosPrioritarios" runat="server">


                                                    <div class="row">

                                                        <div class="col-md-4">
                                                            <label class="control-label">Municipio Prioritario</label>
                                                            <asp:DropDownList runat="server" ID="ddlMunicipioPrioritario" CssClass="form-control"
                                                                AppendDataBoundItems="true">
                                                                <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                                <asp:ListItem Value="True">Si</asp:ListItem>
                                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <label class="control-label">Municipio Homicidio</label>
                                                            <asp:DropDownList runat="server" ID="ddlMunicipioHomicidio" CssClass="form-control">
                                                                <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                                <asp:ListItem Value="True">Si</asp:ListItem>
                                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <label class="control-label">Colonia prioritaria</label>
                                                            <asp:DropDownList runat="server" ID="ddlColoniaPrioritaria" CssClass="form-control">
                                                                <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                                <asp:ListItem Value="True">Si</asp:ListItem>
                                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <label class="control-label">Municipio con población indígenta</label>
                                                            <asp:DropDownList runat="server" ID="ddlMunicipioIndigena" CssClass="form-control" AppendDataBoundItems="true">
                                                                <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                                <asp:ListItem Value="True">Si</asp:ListItem>
                                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>


                                                        <div class="col-md-4">
                                                            <label class="control-label">Programa ISTMO</label>
                                                            <asp:DropDownList runat="server" ID="ddlProgramaIstmo" CssClass="form-control" AppendDataBoundItems="true">
                                                                <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                                <asp:ListItem Value="True">Si</asp:ListItem>
                                                                <asp:ListItem Value="False">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                            </li>

                            <!-- end:resume -->


                            <!-- end:profile -->

                            <!-- start:work -->
                            <li id="id-work">
                                <div class="timeline-badge default"><i class="fa fa-briefcase" data-original-title="" title=""></i></div>
                                <h3 class="timeline-head"><strong style="color: #34495e">Datos de la actividad</strong></h3>
                            </li>
                            <li>
                                <div class="timeline-badge danger"></div>
                                <div class="timeline-panel">
                                    <div class="timeline-body">

                                        <asp:UpdatePanel runat="server" ID="udpCATALOGOS">
                                            <ContentTemplate>
                                                <fieldset class="group-border form-group-sm">
                                                    <div id="PanelListados" runat="server" visible="false">
                                                        <div class="row">
                                                            <div class="form-group form-group-sm col-md-4">
                                                                <label for="exampleInputEmail1">Subprograma</label>
                                                                <div class='input-group ' id='date2'>
                                                                    <span class="input-group-addon">
                                                                        <span class="glyphicon glyphicon-plus" data-placement="top"></span>
                                                                    </span>
                                                                    <asp:DropDownList runat="server" ID="ddlsubprograma" CssClass="form-control" AppendDataBoundItems="False" AutoPostBack="true" OnSelectedIndexChanged="ddlsubprograma_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group form-group-sm col-md-4">
                                                                <label for="exampleInputEmail1">Acción implementada</label>
                                                                <div class='input-group ' id='date4'>
                                                                    <asp:DropDownList ID="ddlAcciones" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="form-group form-group-sm col-md-4">
                                                                <label for="exampleInputEmail1">Sub acción implementada</label>
                                                                <div class='input-group ' id='date42'>
                                                                    <asp:DropDownList ID="ddlSubAcciones" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <%--<div id="PanelAccionImplentada" runat="server" visible="false">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="form-group form-group-sm">
                                                                    <label for="exampleInputEmail1">Acción implementada</label>
                                                                    <div>
                                                                        <asp:TextBox ID="txtAccionImplementada" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>


                                                    <br />

                                                    <div class="row">

                                                        <!-- ENTORNO -->
                                                        <div class="col-md-2">
                                                            <div class="form-group form-group-sm">
                                                                <label for="ddlAmbito">Entorno</label>
                                                                <div class="input-group" id="ambito">

                                                                    <asp:DropDownList
                                                                        runat="server"
                                                                        ID="ddlAmbito"
                                                                        CssClass="form-control"
                                                                        AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlAmbito_SelectedIndexChanged">

                                                                        <asp:ListItem Value="0">--Seleccione--</asp:ListItem>

                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- EJE -->
                                                        <div class="col-md-3">
                                                            <div class="form-group form-group-sm">
                                                                <label for="ddlEje">Eje</label>
                                                                <div class="input-group" id="eje">

                                                                    <asp:DropDownList
                                                                        runat="server"
                                                                        ID="ddlEje"
                                                                        CssClass="form-control"
                                                                        AutoPostBack="true"
                                                                        OnSelectedIndexChanged="ddlEje_SelectedIndexChanged">

                                                                        <asp:ListItem Value="0">--Seleccione--</asp:ListItem>

                                                                    </asp:DropDownList>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- RESPONSABILIDAD + INDICADOR -->
                                                        <asp:Panel
                                                            ID="pnlResponsabilidadIndicador"
                                                            runat="server"
                                                            CssClass="col-md-7">

                                                            <div class="row">

                                                                <!-- RESPONSABILIDAD -->
                                                                <div class="col-md-5">
                                                                    <div class="form-group form-group-sm">

                                                                        <label for="ddResponsabilidad">
                                                                            Responsabilidad principal
                                                                        </label>

                                                                        <div class="input-group" id="responsabilidad">

                                                                            <asp:DropDownList
                                                                                runat="server"
                                                                                ID="ddlResponsabilidad"
                                                                                CssClass="form-control"
                                                                                AutoPostBack="true"
                                                                                OnSelectedIndexChanged="ddResponsabilidad_SelectedIndexChanged"
                                                                                Enabled="false">

                                                                                <asp:ListItem Value="0">--Seleccione--</asp:ListItem>

                                                                            </asp:DropDownList>

                                                                        </div>

                                                                    </div>
                                                                </div>

                                                                <!-- INDICADOR -->
                                                                <div class="col-md-7">
                                                                    <div class="form-group form-group-sm">

                                                                        <label for="ddIndicador">
                                                                            Indicador de desempeño
                                                                        </label>

                                                                        <div class="input-group" id="indicador">

                                                                            <asp:DropDownList
                                                                                runat="server"
                                                                                ID="ddlIndicador"
                                                                                CssClass="form-control"
                                                                                AutoPostBack="true"
                                                                                Enabled="false">

                                                                                <asp:ListItem Value="0">--Seleccione--</asp:ListItem>

                                                                            </asp:DropDownList>

                                                                        </div>

                                                                    </div>
                                                                </div>

                                                            </div>

                                                        </asp:Panel>

                                                    </div>
                                                    <br />

                                                    <div class="row">

                                                        <div class="col-md-3">

                                                            <label for="exampleInputEmail1">Lugar donde se realizó la actividad</label>
                                                            <asp:DropDownList runat="server" ID="ddlnombreescuela" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAmbito_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
                                                                <asp:ListItem Value="Escuela">Escuela</asp:ListItem>
                                                                <asp:ListItem Value="Empresa">Empresa</asp:ListItem>
                                                                <asp:ListItem Value="Red Vecinal">Red Vecinal</asp:ListItem>
                                                                <asp:ListItem Value="Centro Comunitario">Centro Comunitario</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>

                                                        <div class="col-md-4">
                                                            <label class="control-label">Nombre/lugar/escuela/red</label>
                                                            <asp:TextBox ID="txtLugarActividad" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>

                                                        <%--<div class="col-md-3">
                                                            <label for="exampleInputEmail1">Nombre del contacto</label>
                                                            <asp:TextBox ID="txtnombrecontacto" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <label for="exampleInputEmail1">Tel/Cel</label>
                                                            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>--%>
                                                    </div>
                                                    <br />

                                                    <div class="row mt-3">

                                                        <div runat="server" id="PanelEscuela" visible="true">

                                                            <div class="row mt-3">

                                                                <div class="form-group form-group-sm col-md-4">
                                                                    <label for="exampleInputEmail1">Nivel educativo</label>
                                                                    <div class='input-group ' id='niveled'>
                                                                        <span class="input-group-addon">
                                                                            <span class="fa fa-university" style="color: #820E2E"></span>
                                                                        </span>
                                                                        <asp:DropDownList ID="ddlNivel" AppendDataBoundItems="True" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Text="-SELECCIONE POR FAVOR-" Value="0" />
                                                                            <asp:ListItem Value="Jardin">Jardin</asp:ListItem>
                                                                            <asp:ListItem Value="Primaria">Primaria</asp:ListItem>
                                                                            <asp:ListItem Value="Secundaria">Secundaria</asp:ListItem>
                                                                            <asp:ListItem Value="Bachillerato">Bachillerato</asp:ListItem>
                                                                            <asp:ListItem Value="Universidad">Universidad</asp:ListItem>
                                                                            <asp:ListItem Value="Centro de capacitación">Centro de capacitación</asp:ListItem>
                                                                            <asp:ListItem Value="No cuenta con el dato">No cuenta con el dato</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>

                                                                <div class="form-group form-group-sm col-md-4">
                                                                    <label for="exampleInputEmail1">Clave del plantel</label>
                                                                    <div class='input-group ' id='date53'>
                                                                        <span class="input-group-addon">
                                                                            <span class="fas fa-barcode" style="color: #820E2E"></span>

                                                                        </span>
                                                                        <asp:TextBox ID="txtclave" CssClass="form-control" runat="server"></asp:TextBox>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-4">
                                                                    <label for="ddlPlantelDiagnosticado">Plantel Diagnosticado</label>
                                                                    <asp:DropDownList runat="server" ID="ddlPlantelDiagnosticado" CssClass="form-control" AutoPostBack="true">
                                                                        <asp:ListItem Value="">--Seleccione--</asp:ListItem>
                                                                        <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>

                                                            </div>

                                                        </div>


                                                        <%--<div class="row mt-3">

                                                            <div class="col-md-6">
                                                                <label for="txtInstitucionesParticipantes">Instituciones Participantes</label>
                                                                <asp:TextBox ID="txtInstitucionesParticipantes" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </div>

                                                            <div class="col-md-6">
                                                                <label for="txtTemaImpartido">Tema impartido</label>
                                                                <asp:TextBox ID="txtTemaImpartido" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </div>


                                                        </div>--%>

                                                    </div>



                                                    <div runat="server" id="PanelRAVI">
                                                        <div class="row mt-3">
                                                            <div class="col-md-2">
                                                                <label for="ddlCasosRAVI">Casos RAVI</label>
                                                                <asp:DropDownList runat="server" ID="ddlCasosRavi" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCasosRavi_SelectedIndexChanged">
                                                                    <asp:ListItem Value="">--Seleccione--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label for="txtNoCasosRavi">No. casos RAVI</label>
                                                                <asp:DropDownList runat="server" ID="txtNoCasosRavi" CssClass="form-control" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <label for="txtDirigidoA">Dirigido a</label>
                                                                <asp:TextBox ID="txtDirigidoA" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <label for="txtGiroComercio">Giro</label>
                                                                <asp:TextBox ID="txtGiroComercio" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row mt-3">

                                                            <div class="col-md-2">

                                                                <label for="ddlNoaccionesDGPVI">No.acciones DGPVI</label>
                                                                <asp:DropDownList runat="server" ID="ddlNoaccionesDGPVI" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlNoaccionesDGPVI_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-md-3">
                                                                <label for="ddlNoAccionesInstitucionales">No. acciones Institucionales</label>
                                                                <asp:DropDownList runat="server" ID="ddlNoAccionesInstitucionales" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlNoaccionesDGPVI_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label for="txtTotalAccionesRAVI">Total acciones </label>
                                                                <asp:TextBox ID="txtTotalAccionesRAVI" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-2">
                                                                <label for="ddlOfrecioSegurichat">¿Se ofreció segurichat?</label>
                                                                <asp:DropDownList runat="server" ID="ddlOfrecioSegurichat" CssClass="form-control" AutoPostBack="true">
                                                                    <asp:ListItem Value="">--Seleccione--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <label for="txtSegurichat">Segurichat</label>
                                                                <asp:TextBox ID="txtSegurichat" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <h3>Descripción/Observación</h3>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtDescripcionActividad" CssClass="form-control" runat="server" Height="60px" TextMode="MultiLine" MaxLength="300" ></asp:TextBox>
                                                            <small class="text-muted">Caracteres restantes: <span id="charsLeft">300</span>
                                                            </small>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <%--<div class="col-md-12">
                                                        <div class="row">
                                                            <div id="Div1" runat="server">
                                                                <h3>Persona que atendió la actividad</h3>
                                                                <asp:TextBox ID="txtpersonal_atendio_actividad" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h3>Seguimiento</h3>
                                                            <asp:TextBox ID="txtSeguimiento" CssClass="form-control" runat="server" Height="60px" TextMode="MultiLine" MaxLength="300" ></asp:TextBox>
                                                            </small>
                                                        </div>
                                                    </div>
                                                </fieldset>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </li>
                            <!-- end:work -->

                            <!-- start:blog -->

                            <li id="id-blog">
                                <div class="timeline-badge default"><i class="fa fa-comments" data-original-title="" title=""></i></div>
                                <h3 class="timeline-head"><strong style="color: #34495e">Personas atendidas </strong></h3>
                            </li>
                            <li>
                                <div class="timeline-badge primary"></div>
                                <div class="timeline-panel">
                                    <asp:UpdatePanel ID="updBeneficiados" runat="server">
                                        <ContentTemplate>

                                            <div class="container-fluid">
                                                <div class="row">
                                                    <!-- Niños -->
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label for="txnino" class="col-md-5 col-form-label">Niños</label>
                                                            <div class="col-md-7">
                                                                <div class="input-group">
                                                                    <input type="text" id="txnino" class="form-control montoH" onkeyup="sumarH();" runat="server" />
                                                                    <span class="input-group-text"><i class="fa fa-male" style="color: #820E2E"></i></span>
                                                                    <span class="badge bg-white text-danger" data-toggle="tooltip" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- Niñas -->
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label for="txnina" class="col-md-5 col-form-label">Niñas</label>
                                                            <div class="col-md-7">
                                                                <div class="input-group">
                                                                    <input type="text" id="txnina" class="form-control montoM" onkeyup="sumarM();" runat="server" />
                                                                    <span class="input-group-text"><i class="fa fa-female" style="color: #820E2E"></i></span>
                                                                    <span class="badge bg-white text-danger" data-toggle="tooltip" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row mt-3">
                                                    <!-- Hombres -->
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label for="txhombres" class="col-md-5 col-form-label">Hombres</label>
                                                            <div class="col-md-7">
                                                                <div class="input-group">
                                                                    <input type="text" id="txhombres" class="form-control montoH" onkeyup="sumarH();" runat="server" />
                                                                    <span class="input-group-text"><i class="fa fa-male" style="color: #820E2E"></i></span>
                                                                    <span class="badge bg-white text-danger" data-toggle="tooltip" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- Mujeres -->
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label for="txmujeres" class="col-md-5 col-form-label">Mujeres</label>
                                                            <div class="col-md-7">
                                                                <div class="input-group">
                                                                    <input type="text" id="txmujeres" class="form-control montoM" onkeyup="sumarM();" runat="server" />
                                                                    <span class="input-group-text"><i class="fa fa-female" style="color: #820E2E"></i></span>
                                                                    <span class="badge bg-white text-danger" data-toggle="tooltip" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>


                                                <div class="row mt-3">
                                                    <!-- Total Hombres -->
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label for="txtatendiosH" class="col-md-5 col-form-label">Total Hombres</label>
                                                            <div class="col-md-7">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtatendiosH" runat="server" CssClass="form-control" Enabled="true" placeholder="0" Width="170px"></asp:TextBox>
                                                                    <span class="input-group-text"><i class="fa fa-male" style="color: #820E2E"></i></span>
                                                                    <span class="badge bg-white text-danger" data-toggle="tooltip" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- Total Mujeres -->
                                                    <div class="col-md-6">
                                                        <div class="form-group row">
                                                            <label for="txtatendiosM" class="col-md-5 col-form-label">Total Mujeres</label>
                                                            <div class="col-md-7">
                                                                <div class="input-group">
                                                                    <asp:TextBox ID="txtatendiosM" runat="server" CssClass="form-control" Enabled="true" placeholder="0" Width="170px"></asp:TextBox>
                                                                    <span class="input-group-text"><i class="fa fa-female" style="color: #820E2E"></i></span>
                                                                    <span class="badge bg-white text-danger" data-toggle="tooltip" title="Es obligatorio este campo">*</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </li>


                            <!-- end:blog -->


                            <!-- start:contact -->
                            <li id="id-contact">
                                <div class="timeline-badge default"><i class="fa fa-envelope" data-original-title="" title=""></i></div>
                                <h3 class="timeline-head"><strong style="color: #34495e">Evidencia fotográfica</strong></h3>
                            </li>
                            <li>
                                <div class="timeline-badge primary"></div>
                                <div class="timeline-panel">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <asp:FileUpload CssClass="file" runat="server" ID="file" AllowMultiple="true" type="file" accept=".jpg,.jpeg,.png,.pdf" data-min-file-count="1" data-max-file-count="2" />
                                        </div>
                                        <br />
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Button runat="server" ID="btnSalir" Text="Salir Modo edición" class="btn btn-danger" Visible="false" OnClick="btnSalir_Click" />
                                        </div>
                                        <div class="col-md-4"></div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <asp:LinkButton runat="server" CssClass="btn btn-success btn-block" Visible="false" ID="lnkbtnGuardar" OnClick="lnkbtnGuardar_Click">
                                                <span class="glyphicon glyphicon-floppy-saved" aria-hidden="true"></span>Guardar
                                                </asp:LinkButton>
                                            </div>

                                            <asp:Button runat="server" ID="btnGuardarEdicion" Text="Guardar" class="btn btn-success btn-block" Visible="false" OnClick="btnGuardarEdicion_Click" />

                                        </div>
                                    </div>
                                </div>
                            </li>

                            <!-- end:contact -->
                        </ul>
                    </div>
                    <!-- end:main content -->
                </div>
            </div>
        </div>
    </div>


    <%-- **************************** --%>


    <div class="modal" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 style="text-align: center">¿Estas seguro que deseas guardar?</h4>
                </div>

                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <h3 style="text-align: center">Favor de verificar los campos que faltan:</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-horizontal">
                                <asp:Label ID="lblValidacionesTxt" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        <span class="glyphicon glyphicon-floppy-remove" aria-hidden="true"></span>
                        Cancelar
                    </button>
                </div>

            </div>
        </div>
    </div>



    <div class="modal" id="ModalGuardarexito" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <div class=" modal-title" style="font-size: 2.3em; color: green">Proceso exitoso</div>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-3" style="text-align: center">
                            <i class="fas fa-check-circle" style="font-size: 5.3em; color: green"></i>
                        </div>
                        <div class="col-md-9">
                            <h5>Se guardo con exito la actividad</h5>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="lkbtSalirReporte_Click" ID="lkbtSalirReporte">Aceptar</asp:LinkButton>

                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" id="modalFOlio" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title">El folio de la actividad es:</h3>
                </div>
                <div class="modal-body">
                    <div style="text-align: center">
                        <span id="spnfolioo" runat="server" style="font-size: 2.2em; text-align: center; color: green; font-family: fantasy;"></span>

                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnaceptar_Click" ID="btnaceptar">Aceptar</asp:LinkButton>

                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">   
        function openModalvalidador() {
            $('.modal-backdrop').remove();

            if (typeof $.fn.modal !== 'function') {
                $.getScript("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js", function () {
                    $('#exampleModal').appendTo("form:first").modal('show');
                });
            } else {
                $('#exampleModal').appendTo("form:first").modal('show');
            }
            return false;
        }



        function openGuardadoExito() {
            if (typeof $.fn.modal !== 'function') {
                $.getScript("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js", function () {
                    $('#ModalGuardarexito').removeAttr('aria-hidden').modal('show');
                });
            } else {
                $('#ModalGuardarexito').removeAttr('aria-hidden').modal('show');
            }
            return false;
        }

        function openFolio() {
            if (typeof $.fn.modal !== 'function') {
                $.getScript("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js", function () {
                    $('#modalFOlio').removeAttr('aria-hidden').modal('show');
                });
            } else {
                $('#modalFOlio').removeAttr('aria-hidden').modal('show');
            }
            return false;
        }



        function sumarH(valor) {
            var total = 0;
            $(".montoH").each(function () {
                var val = parseFloat($(this).val());
                if (!isNaN(val)) {
                    total += val;
                }
            });
            document.getElementById('<%= txtatendiosH.ClientID %>').value = total;
        }

        function sumarM(valor) {
            var total = 0;
            $(".montoM").each(function () {
                var val = parseFloat($(this).val());
                if (!isNaN(val)) {
                    total += val;
                }
            });
            document.getElementById('<%= txtatendiosM.ClientID %>').value = total;
        }



        function pageLoad() {
            var limite = 300;
            var txtBox = $("#<%= txtDescripcionActividad.ClientID %>");
            var contador = $("#charsLeft");

            if (txtBox.length > 0) {

                actualizarContador();

                txtBox.off("input propertychange").on("input propertychange", function () {
                    actualizarContador();
                });
            }

            function actualizarContador() {

                var texto = txtBox.val() || "";
                var actual = texto.length;
                var restantes = limite - actual;

                if (restantes < 0) restantes = 0;

                contador.text(restantes);

                if (restantes === 0) {
                    contador.css("color", "red");
                } else {
                    contador.css("color", "inherit");
                }
            }
        }
    </script>
    <asp:Label
        ID="lblError"
        runat="server"
        ForeColor="Red"
        Visible="false">
    </asp:Label>

</asp:Content>
