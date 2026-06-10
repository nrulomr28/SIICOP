<%@ Page Title="Actividades DGRS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actividades_DGRS.aspx.cs" Inherits="SIICOP_V1._2.Captura.DGRS.Actividades_DGRS" %>
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

        function edicion() {
            swal({
                title: "Edición",
                text: "Va a editar la actividad",
                icon: "warning",
                timer: 3000,
                timerProgressBar: true,
            });
            return false
        }
    </script>
      <asp:HiddenField ID="HDFactividad" runat="server" Value="0" />
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
                                <h1>FORMATO DE REGISTRO</h1>
                                <div class="hr-center"></div>
                                <h5 style="color: #feff00">DE POBLACIÓN
                                <br>
                                    ASISTIDA</h5>
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
                                    <div id="DatosGenerales" class="form-horizontal" >

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

                                                    var ActividadId = document.getElementById('<%=HDFactividad.ClientID %>').value;
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
                                                    <div class="wideField" >
                                                        <input class="field form-control" type="text" id="latlng" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-6">Latitud</label>
                                                    <div class="wideField" >
                                                        <input class="field form-control" runat="server" type="text" id="lati" disabled="disabled" required autofocus />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-3 control-label">Longitud</label>
                                                    <div class="wideField">
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
                                    <%--        <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-11 control-label">Entre calle 1</label>
                                                    <div class="wideField" >
                                                        <input class="form-control" id="entrecalle1" type="text" runat="server" value="" clientidmode="Static" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="form-group form-group-sm">
                                                    <label class="col-md-11 control-label">Entre calle 2</label>
                                                    <div class="wideField" >
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
                                                                <asp:DropDownList runat="server" ID="ddlsubprograma" CssClass="form-control" DataSourceID="edsEscuelaSegura" DataTextField="NombreSubPrograma"
                                                                    DataValueField="subprogramaId" AppendDataBoundItems="True" AutoPostBack="true" OnSelectedIndexChanged="ddlsubprograma_SelectedIndexChanged">
                                                                    <asp:ListItem Text="-Seleccione un programa-" Value="0" />
                                                                </asp:DropDownList>
                                                                <asp:EntityDataSource runat="server" ID="edsEscuelaSegura" DefaultContainerName="SIICOPEntities"
                                                                    ConnectionString="name=SIICOPEntities" EnableFlattening="False" EntitySetName="TB_subprograma"
                                                                    Where="it.programasID == @ProgramaId or it.ProgramaCompartidoID == @IdProCompartido or it.subprogramaId == @subpro">
                                                                    <WhereParameters>
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="ProgramaId" Name="ProgramaId" />
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="subpro" Name="subpro" />
                                                                        <asp:SessionParameter DbType="Int32" DefaultValue="" SessionField="IdProCompartido" Name="IdProCompartido" />
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
                                                        <div class="form-group form-group-sm col-md-3">
                                                            <label for="exampleInputEmail1">Clave del plantel</label>
                                                            <div class='input-group ' >
                                                                <span class="input-group-addon">
                                                                    <span class="fas fa-barcode" style="color: #820E2E"></span>

                                                                </span>
                                                                <asp:TextBox ID="txtclave" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <div class="form-group form-group-sm">
                                                                <label class="col-md-10">Nombre del la institución</label>
                                                                <asp:TextBox ID="txtnombreescuela" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group form-group-sm col-md-4">
                                                            <label for="exampleInputEmail1">Director o responsable</label>
                                                            <div class='input-group ' >
                                                                <asp:TextBox ID="txtnombrecontacto" CssClass="form-control" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="row">
                                                        <div class="form-group form-group-sm col-md-3">
                                                            <label for="exampleInputEmail1">Tel/Cel</label>
                                                            <div class='input-group '>
                                                                <span class="input-group-addon">
                                                                    <span class="fas fa-barcode" style="color: #820E2E"></span>

                                                                </span>
                                                                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>

                                                            </div>
                                                        </div>
                                                        <div class="form-group form-group-sm col-md-4">
                                                            <label for="exampleInputEmail1">Nivel educativo</label>
                                                            <div class='input-group ' >
                                                                <span class="input-group-addon">
                                                                    <span class="fa fa-university" style="color: #820E2E"></span>
                                                                </span>
                                                                <asp:DropDownList ID="ddlNivel" AppendDataBoundItems="True" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Text="-Seleccione nivel-" Value="0" />
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
                                                            <label for="exampleInputEmail1">Turno</label>
                                                            <div class='input-group '>
                                                                <asp:DropDownList ID="ddlTurno" AppendDataBoundItems="True" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Text="-Seleccione turno-" Value="0" />
                                                                    <asp:ListItem Value="Matutino">Matutino</asp:ListItem>
                                                                    <asp:ListItem Value="Vespertino">Vespertino</asp:ListItem>
                                                                    <asp:ListItem Value="Mixto">Mixto</asp:ListItem>
                                                                    <asp:ListItem Value="Matutino y Vespertino">Matutino y Vespertino</asp:ListItem>
                                                                    <asp:ListItem Value="No cuenta con el dato">No cuenta con el dato</asp:ListItem>

                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />


                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <label for="exampleInputEmail1">Observaciones</label>
                                                            <asp:TextBox ID="txtDescripcionActividad" CssClass="form-control" runat="server" Height="60px" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <br />
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div  runat="server">
                                                                <label for="exampleInputEmail1">Ponente o Supervisor</label>
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
                                <h3 class="timeline-head"><strong style="color: #34495e">Registro de Población beneficiada </strong></h3>
                            </li>
                            <li>
                                <div class="timeline-badge primary"></div>
                                <div class="timeline-panel">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>

                                            <br />

                                            <article class="tabs">
                                                <ul class="nav nav-tabs nav-tabs-redBorders">
                                                    <li class="active">
                                                        <a data-toggle="tab" href="#home">Educativo
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a data-toggle="tab" href="#menu1">Social
                                                        </a>
                                                    </li>
                                                </ul>
                                                <div class="tab-content">
                                                    <!--tab1 - home-->
                                                    <div id="home" class="tab-pane fade in active">
                                                        <div class="panel-group" id="accordion1" role="tablist" aria-multiselectable="true">
                                                            <!--panel-default-->
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" role="tab" id="headingOne">
                                                                    <h3 class="panel-title">
                                                                        <a role="button" data-toggle="collapse" data-parent="#accordion1" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                                            <i class="fa fa-minus more-less" aria-hidden="true"></i>
                                                                            Alumnos
                                                                        </a>
                                                                    </h3>
                                                                </div>
                                                                <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="span6">
                                                                                    <div class="form-horizontal">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años M</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="txtAlu_H_0_4" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años F</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="txtAlu_M_0_4" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_H_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_M_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_H_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_M_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_H_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_M_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_H_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="txtAlu_M_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_H_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_M_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_H_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_M_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group' >
                                                                                                            <input type="text" id="txtAlu_H_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtAlu_M_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!--panel-2-->
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" role="tab" id="headingTwo">
                                                                    <h3 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion1" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                                                            <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                                            Padres de familia y/o docentes
                                                                        </a>
                                                                    </h3>
                                                                </div>
                                                                <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="span6">
                                                                                    <div class="form-horizontal">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años M</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' '>
                                                                                                            <input type="text" id="txtPadreDoc_H_0_4" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años F</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPadreDoc_M_0_4" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPadreDoc_H_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPadreDoc_M_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPadreDoc_H_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPadreDoc_M_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPadreDoc_H_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPadreDoc_M_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_H_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_M_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_H_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_M_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_H_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_M_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_H_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="txtPadreDoc_M_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </div>
                                                        <!-- end-->
                                                    </div>
                                                    <!--tab2-->
                                                    <div id="menu1" class="tab-pane fade">
                                                        <div class="panel-group" id="accordion2" role="tablist" aria-multiselectable="true">
                                                            <!--panel-default-->
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" role="tab" id="headingOne_2">
                                                                    <h3 class="panel-title">
                                                                        <a role="button" data-toggle="collapse" data-parent="#accordion2" href="#collapseOne2" aria-expanded="true" aria-controls="collapseOne2">
                                                                            <i class="fa fa-minus more-less" aria-hidden="true"></i>
                                                                            Personal de Institución Pública / Privada
                                                                        </a>
                                                                    </h3>
                                                                </div>
                                                                <div id="collapseOne2" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="span6">
                                                                                    <div class="form-horizontal">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años M</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:textbox id="txtnino" runat="server" cssclass="form-control" placeholder="0"  OnTextChanged="txtnino_TextChanged" autopostback="true" textmode="number"></asp:textbox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_0_4" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años F</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtnina" runat="server" CssClass="form-control" placeholder="0" AutoPostBack="true" OnTextChanged="txtnina_TextChanged" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_0_4" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txthombres" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txthombres_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtmujeres" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtmujeres_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' '>
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtdocenteh" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocenteh_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_H_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date'>
                                                                                                            <%--<asp:TextBox ID="txtdocentem" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtdocentem_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="InstPubli_Pri_M_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!--panel-2-->
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" role="tab" id="headingTwo_2">
                                                                    <h3 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion2" href="#collapseTwo2" aria-expanded="false" aria-controls="collapseTwo2">
                                                                            <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                                            Internos
                                                                        </a>
                                                                    </h3>
                                                                </div>
                                                                <div id="collapseTwo2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="span6">
                                                                                    <div class="form-horizontal">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años M</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:textbox id="txtnino" runat="server" cssclass="form-control" placeholder="0"  OnTextChanged="txtnino_TextChanged" autopostback="true" textmode="number"></asp:textbox>--%>
                                                                                                            <input type="text" id="Internos_H_0_4" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años F</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtnina" runat="server" CssClass="form-control" placeholder="0" AutoPostBack="true" OnTextChanged="txtnina_TextChanged" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="Internos_M_0_4" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txthombres" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txthombres_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="Internos_H_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <%--<asp:TextBox ID="txtmujeres" runat="server" CssClass="form-control" placeholder="0" OnTextChanged="txtmujeres_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>--%>
                                                                                                            <input type="text" id="Internos_M_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_H_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="Internos_M_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_H_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_M_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_H_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_M_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_H_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_M_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_H_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_M_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="Internos_H_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="Internos_M_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!--panel-3-->
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" role="tab" id="headingThree_2">
                                                                    <h3 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion2" href="#collapseThree2" aria-expanded="false" aria-controls="collapseThree2">
                                                                            <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                                            Familiares de internos
                                                                        </a>
                                                                    </h3>
                                                                </div>
                                                                <div id="collapseThree2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="span6">
                                                                                    <div class="form-horizontal">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años M</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_0_4" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años F</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="FamInt_M_0_4" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_M_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_M_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_M_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_M_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_M_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_M_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_H_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="FamInt_M_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />

                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!--panel-4-->
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" role="tab" id="headingFour_2">
                                                                    <h3 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion2" href="#collapseFour2" aria-expanded="false" aria-controls="collapseFour2">
                                                                            <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                                            Hijos de internos
                                                                        </a>
                                                                    </h3>
                                                                </div>
                                                                <div id="collapseFour2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="span6">
                                                                                    <div class="form-horizontal">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años M</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_0_4" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años F</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_0_4" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_H_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtHijos_M_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!--panel-5-->
                                                            <div class="panel panel-default">
                                                                <div class="panel-heading" role="tab" id="headingFoor_2">
                                                                    <h3 class="panel-title">
                                                                        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion2" href="#collapseFoor2" aria-expanded="false" aria-controls="collapseFoor2">
                                                                            <i class="fa fa-plus more-less" aria-hidden="true"></i>
                                                                            Preliberados
                                                                        </a>
                                                                    </h3>
                                                                </div>
                                                                <div id="collapseFoor2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                                                    <div class="panel-body">
                                                                        <div class="row">
                                                                            <div class="col-md-12">
                                                                                <div class="span6">
                                                                                    <div class="form-horizontal">
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años M</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="txtPreli_H_0_4" runat="server" cssclass="form-control" class="monto" onkeyup="sumar();" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">0 - 4 años F</label>
                                                                                                    <div class="col-md-1">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_M_0_4" onkeyup="sumar();" runat="server" cssclass="form-control" class="monto" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>

                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="txtPreli_H_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">5 - 8 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_M_5_8" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_H_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">9 - 12 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_M_9_12" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_H_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">13 - 15 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date'>
                                                                                                            <input type="text" id="txtPreli_M_13_15" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_H_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">16 - 18 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_M_16_18" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_H_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">19 - 22 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' id='docentem'>
                                                                                                            <input type="text" id="txtPreli_M_19_22" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_H_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">23 - 60 años F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_M_23_60" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="row">
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más M</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_H_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-male" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="col-md-6">
                                                                                                <div class="form-group form-group-sm">
                                                                                                    <label class="col-md-4 control-label">61 años o más F</label>
                                                                                                    <div class="col-md-2">
                                                                                                        <div class='input-group date' >
                                                                                                            <input type="text" id="txtPreli_M_61_mas" class="monto" onkeyup="sumar();" runat="server" cssclass="form-control" style="width: 60px !important" />
                                                                                                            <span class="input-group-addon"><i class="fa fa-female" aria-hidden="true" style="color: #820E2E"></i></span>
                                                                                                            <span class="badge" style="background-color: white; color: red" data-toggle="tooltip" data-placement="right" title="Es obligatorio este campo">*</span>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- end -->
                                                    </div>
                                                </div>
                                            </article>



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
                                                                        <asp:TextBox ID="txtBeneficiado" runat="server" CssClass="form-control" Enabled="false" placeholder="0"></asp:TextBox>
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

                                            <asp:Button runat="server" ID="btnGuardarEdicion" Text="Guardar" class="btn btn-success btn-block" Visible="false" OnClick="btnGuardarEdicion_Click"/>

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
            document.getElementById('<%= txtBeneficiado.ClientID %>').value = total;
        }
    </script>
</asp:Content>
