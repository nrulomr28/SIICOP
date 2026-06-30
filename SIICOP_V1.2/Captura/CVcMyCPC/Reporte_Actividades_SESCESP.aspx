<%@ Page Title="Reporte de actividades de SESCESP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte_Actividades_SESCESP.aspx.cs" Inherits="SIICOP_V1._2.Captura.CVcMyCPC.Reporte_Actividades_SESCESP" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link runat="server" href="../../Content/styleFormularios.css" rel="stylesheet" type="text/css" />

    <br />
    <br />
    <script src="<%= ResolveUrl("~/Scripts/sweetalert2.all.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function error() {
            swal({
                title: "Error!",
                text: "Hubo un error",
                icon: "error",
                button: "Aceptar",

            });
            return false
        }

        function nuevoreporte() {
            swal({
                title: "Cargando nuevo reporte",
                text: "Se cerrará en 2 segundos.",
                icon: "info",
                timer: 3000,
                timerProgressBar: true,

            });
            return false
        }

    </script>
    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
    <div class="container" id="main">
        <div class="row">
            <div class="col-lg-3 col-md-3 col-sm-4 col-xs-12">
                <div id="sidebar">
                    <div class="sosmed">
                        <div class="user">
                            <div class="text-center">
                                <img src="../../Imagenes/data-entry.png" width="60%" class="img-circle">
                            </div>
                            <div class="user-head">
                                <h1>REPORTE DE ACTIVIDADES</h1>
                                <div class="hr-center"></div>
                                <h5 style="color: #feff00">SESCESP</h5>
                            </div>
                            <div class="link-me">
                                <div class="hr-center"></div>
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
                                    <br />
                                    <div class="hr-left"></div>
                                    <div id="DatosGenerales" method="post" class="form-horizontal" action="none">

                                        <div class="form-group form-group-sm">
                                            <label class="col-md-3 control-label">Responsable</label>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="txtResponsable" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="form-group form-group-sm">
                                            <label class="col-md-3 control-label">Área/Departamento</label>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="txtArea" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>

                                        <br />
                                        <div class="form-group form-group-sm">
                                            <label class="col-md-3 control-label">Fecha de la actividad</label>
                                            <div class="col-md-4">
                                                <div class='input-group date' id='datetimepicker1'>
                                                    <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" placeholder="dd/mm/aaaa" autocomplete="off" />
                                                    <ajaxToolkit:CalendarExtender ID="DateNacimiento_CalendarExtender" runat="server" BehaviorID="DateNacimiento_CalendarExtender" TargetControlID="txtFecha" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar" style="color: #820E2E"></span>
                                                    </span>
                                                </div>
                                            </div>

                                        </div>
                                        <br />

                                    </div>
                                </div>
                            </li>

                            <!-- start:resume -->
                            <li id="id-resume">
                                <div class="timeline-badge default"><i class="fa fa-globe" data-original-title="" title=""></i></div>
                                <h3 class="timeline-head"><strong style="color: #34495e">Ubicación</strong></h3>
                            </li>
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
                                                        var dir = document.getElementById('autocomplete').value;



                                                        coordenada = place.geometry.location;
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



                                                        //document.getElementById('txtdireccomple').value = dir;
                                                        //alert(document.getElementById('txtdireccomple').value);
                                                        //$("[id*='" + 'txtdireccomple' + "']").val(dir);
                                                        $("[id*='" + 'txtdireccomple' + "']").removeAttr('disabled');
                                                        //console.log("--primer ENCUENTRO = " + 'txtdireccomple' + dir);


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

                                                    var ActividadId = document.getElementById('<%=HiddenField1.ClientID %>').value;
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

                                            <%--termina--%>
                                             <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBzKpx_jKJbeh1oiuY7p4pdfspnIcbmxco&libraries=places&callback=initMap" async defer></script>
                                    
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
                                        <div class="row">

                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-6">Calle</label>
                                                    <input class="form-control" id="route" type="text" disabled="disabled" runat="server" clientidmode="Static" />
                                                </div>
                                            </div>
                               <%--             <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-11 control-label">Entre calle 1</label>
                                                    <div class="wideField" colspan="2">
                                                        <input class="form-control" id="entrecalle1" type="text" runat="server" value="" clientidmode="Static" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-11 control-label">Entre calle 2</label>
                                                    <div class="wideField" colspan="2">
                                                        <input class="form-control" id="entrecalle2" type="text" runat="server" value="" clientidmode="Static" />
                                                    </div>
                                                </div>
                                            </div>--%>

                                        </div>
                                        <asp:UpdatePanel ID="UpdRegionesMuni" runat="server">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-3 control-label">Colonia</label>
                                                            <input class=" form-control" id="colony" type="text" disabled="disabled" runat="server" clientidmode="Static" />

                                                        </div>
                                                    </div>

                                                    <div class="col-md-4">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-3 control-label">Municipio</label>
                                                            <asp:DropDownList runat="server" ID="ddlMuNICIPIO" CssClass="form-control" DataSourceID="edsMunicipios" DataTextField="MUNICIPIO" DataValueField="MunicipioID" AutoPostBack="true"
                                                                OnDataBound="ddlMuNICIPIO_DataBound">
                                                            </asp:DropDownList>
                                                            <asp:EntityDataSource runat="server" ID="edsMunicipios" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Municipios">
                                                            </asp:EntityDataSource>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group form-group-sm">
                                                            <label class="col-md-3 control-label">Localidad</label>
                                                            <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="form-control" DataSourceID="edsLocalidades" DataTextField="Localidad" DataValueField="LocalidadID" OnDataBound="ddlLocalidad_DataBound">
                                                            </asp:DropDownList>
                                                            <asp:EntityDataSource runat="server" ID="edsLocalidades" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Localidades"
                                                                AutoGenerateWhereClause="True">
                                                                <WhereParameters>
                                                                    <asp:ControlParameter ControlID="ddlMuNICIPIO" DbType="Int32" Name="MunicipioID" PropertyName="SelectedValue" DefaultValue="" />
                                                                </WhereParameters>
                                                            </asp:EntityDataSource>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="row">
                                            <div class="form-group form-group-sm col-md-5">
                                                <label for="exampleInputEmail1">Municipio en situación de Vulnerabilidad </label>
                                                <div class='input-group ' id='date5'>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDMSVSI" runat="server" name="MSV" value="true" GroupName="MSV1" />
                                                        Si
                                                    </label>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDMSVNO" runat="server" name="MSV" value="false" GroupName="MSV1" />
                                                        No
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="form-group form-group-sm col-md-5">
                                                <label for="exampleInputEmail1">El municipio tiene alerta de género  </label>
                                                <div class='input-group ' id='date5'>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDMAGSI" runat="server" name="MAG" GroupName="MAGG" />
                                                        Si
                                                    </label>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDMAGNO" runat="server" name="MAG" GroupName="MAGG" />
                                                        No
                                                    </label>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="form-group form-group-sm col-md-5">
                                                <label for="exampleInputEmail1">La población es preponderantemente indígena  </label>
                                                <div class='input-group ' id='date5'>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDPPISI" runat="server" name="PPI" value="true" GroupName="PPII" />
                                                        Si
                                                    </label>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDPPINO" runat="server" name="PPI" value="false" GroupName="PPII" />
                                                        No
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="form-group form-group-sm col-md-5">
                                                <label for="exampleInputEmail1">El municipio ha solicitado su informe de incidencia delictiva  </label>
                                                <div class='input-group ' id='date5'>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDMSIIDSI" runat="server" name="MSIID" value="true" GroupName="MSIIDD" />
                                                        Si
                                                    </label>
                                                    <label class="radio-inline">
                                                        <asp:RadioButton ID="RDMSIIDNO" runat="server" name="MSIID" value="false" GroupName="MSIIDD" />
                                                        No
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
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

                                                    <div class="row">
                                                        <div class="form-group form-group-sm col-md-5">
                                                            <label for="exampleInputEmail1">Subprograma</label>
                                                            <div class='input-group ' id='date2'>
                                                                <span class="input-group-addon">
                                                                    <span class="glyphicon glyphicon-plus" data-placement="top"></span>
                                                                </span>
                                                                <asp:DropDownList runat="server" ID="ddlsubprograma" CssClass="form-control" DataSourceID="edsEscuelaSegura" DataTextField="NombreSubPrograma" DataValueField="subprogramaId" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="ddlsubprograma_SelectedIndexChanged">
                                                                    <asp:ListItem Text="-Seleccione un programa-" Value="0" />
                                                                </asp:DropDownList>
                                                                <asp:EntityDataSource runat="server" ID="edsEscuelaSegura" DefaultContainerName="SIICOPEntities"
                                                                    ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="TB_subprograma"
                                                                    Where="it.programasID == @ProgramaId or it.subprogramaId == @subpro">
                                                                    <WhereParameters>
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="ProgramaId" Name="ProgramaId" />
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="subpro" Name="subpro" />

                                                                    </WhereParameters>
                                                                </asp:EntityDataSource>
                                                            </div>

                                                        </div>
                                                        <div class="form-group form-group-sm col-md-5">
                                                            <label for="exampleInputEmail1">Acción implementada</label>
                                                            <div class='input-group ' id='date4'>
                                                                <asp:DropDownList ID="ddlAcciones" runat="server" CssClass="form-control" DataSourceID="edsAcciones" DataTextField="AccionesNombre" DataValueField="AccionesID"
                                                                    OnDataBound="ddlAcciones_DataBound">
                                                                </asp:DropDownList>
                                                                <asp:EntityDataSource runat="server" ID="edsAcciones" DefaultContainerName="SIICOPEntities" ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="Cat_Acciones"
                                                                    Where="it.subprogramaId == @subprogra or it.IdPrograma ==@pro or it.AccionesID == @accion">
                                                                    <WhereParameters>
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="subprogra" Name="subprogra" />
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="pro" Name="pro" />
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="accion" Name="accion" />
                                                                    </WhereParameters>
                                                                </asp:EntityDataSource>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <br />
                                                    <div class="row">

                                                        <div class="col-md-6">
                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-10">Nombre del lugar</label>
                                                                <asp:TextBox ID="txtnombreescuela" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group form-group-sm col-md-6">
                                                            <label for="exampleInputEmail1">Nombre del contacto</label>
                                                            <div class='input-group ' id='date5'>
                                                                <asp:TextBox ID="txtnombrecontacto" CssClass="form-control" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="form-group form-group-sm col-md-3">
                                                            <label for="exampleInputEmail1">Tel/Cel</label>
                                                            <div class='input-group ' id='date5'>
                                                                <span class="input-group-addon">
                                                                    <span class="fas fa-barcode" style="color: #820E2E"></span>

                                                                </span>
                                                                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>

                                                    </div>
                                                    <br />


                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <label for="exampleInputEmail1">Descripción/Observación</label>
                                                            <asp:TextBox ID="txtDescripcionActividad" CssClass="form-control" runat="server" Height="60px" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <br />
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div id="Div1" runat="server">
                                                                <label for="exampleInputEmail1">Persona que atendió la actividad</label>
                                                                <asp:TextBox ID="txtpersonal_atendio_actividad" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
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
                                <h3 class="timeline-head"><strong style="color: #34495e">Personas beneficiadas </strong></h3>
                            </li>
                            <li>
                                <div class="timeline-badge primary"></div>
                                <div class="timeline-panel">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <div class="container">
                                                <div class="span9">
                                                    <div class="form-horizontal">
                                                        <div class="row">
                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Estudiantes hombres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='Nino'>
                                                                        <%--<asp:textbox id="txtnino" runat="server" cssclass="form-control" placeholder="0"  OnTextChanged="txtnino_TextChanged" autopostback="true" textmode="number"></asp:textbox>--%>
                                                                        <input type="text" id="txtnino" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" />
                                                                        <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Estudiantes mujeres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='niña'>
                                                                        <%--<asp:TextBox ID="txtnina" runat="server" CssClass="form-control" placeholder="0" AutoPostBack="true" OnTextChanged="txtnina_TextChanged" TextMode="Number"></asp:TextBox>--%>
                                                                        <input type="text" id="txtnina" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" />
                                                                        <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Hombres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='padres'>
                                                                        <%--<asp:TextBox ID="txthombres" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txthombres_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                        <input type="text" id="txthombres" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" />

                                                                        <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Mujeres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='Mujeres'>
                                                                        <%--<asp:TextBox ID="txtmujeres" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtmujeres_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                        <input type="text" id="txtmujeres" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" />
                                                                        <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>


                                                        <br />
                                                        <div class="row">
                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Servidores públicos hombres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='docenteh'>
                                                                        <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                        <input type="text" id="txtEmpleadasH" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" />
                                                                        <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Servidores públicos mujeres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='docentem'>
                                                                        <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                        <input type="text" id="txtEmpleadasM" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" />

                                                                        <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Ciudadanos hombres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='docenteh'>
                                                                        <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                        <input type="text" id="txtCiudadanosH" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" />
                                                                        <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-2 control-label">Ciudadanos mujeres</label>
                                                                <div class="col-md-2">
                                                                    <div class='input-group date' id='docentem'>
                                                                        <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                        <input type="text" id="txtCiudadanosM" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" />

                                                                        <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                        <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />

                                            <div class="container">
                                                <%--<div class="col-md-1">
                                        </div>--%>
                                                <div class="span9">
                                                    <div class="form-horizontal">

                                                        <div class="form-group">
                                                            <span class="col-md-4 control-label">Total de atendidos</span>
                                                            <div class="col-md-6">

                                                                <div class=" row">

                                                                    <div class=" col-xs-6 col-md-4">
                                                                        <asp:TextBox ID="txtatendios" runat="server" CssClass="form-control" Enabled="false" placeholder="0"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
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
                                            <%--  <asp:TextBox runat="server" ID="txtDomicilioTESTI" CssClass="form-control" TextMode="MultiLine" placeholder="Domicilio"></asp:TextBox>--%>
                                            <asp:FileUpload CssClass="file" runat="server" ID="file" AllowMultiple="true" type="file" date-min-file-count="1" />

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
                                                      <span class="glyphicon glyphicon-floppy-saved" aria-hidden="true"></span> Guardar
                                                </asp:LinkButton>
                                            </div>

                                            <asp:Button runat="server" ID="btnGuardarEdicion" Text="Guardar" class="btn btn-success btn-block" Visible="false" />

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

    <!-- Button trigger modal -->



    <%-- modal de confirmacion de guardado --%>
    <!-- Modal -->
    <%-- **************************** --%>


    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                            <div method="post" class="form-horizontal" action="none">
                                <asp:Label ID="lblValidacionesTxt" runat="server"></asp:Label>

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
    </div>

    <div class="modal fade" id="ModalGuardarexito" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                    <asp:LinkButton runat="server" CssClass="btn btn-success" ID="lkbtSalirReporte" OnClick="lkbtSalirReporte_Click">Aceptar</asp:LinkButton>

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
                    <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnaceptar" OnClick="btnaceptar_Click">Aceptar</asp:LinkButton>

                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        function openModalvalidador() {
            $('#exampleModal').modal();
            return false;

        }

        function openGuardadoExito() {
            $('#ModalGuardarexito').modal();
            return false;

        }

        function openFolio() {
            $('#modalFOlio').modal();
            return false;

        }


        function sumar(valor) {
            var total = 0;
            $(".monto").each(function () {

                if (isNaN(parseFloat($(this).val()))) {

                    total += 0;

                } else {

                    total += parseFloat($(this).val());

                }

            });
            document.getElementById('<%= txtatendios.ClientID %>').value = total;
        }
    </script>
</asp:Content>

