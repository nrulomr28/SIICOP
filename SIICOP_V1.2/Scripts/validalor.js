
function openModal() {

    var fecha = document.getElementById('<%=txtFecha.ClientID %>').value;
    document.getElementById('<%=txtfechacap.ClientID %>').value = fecha;
    var divfechaerror = document.getElementById('errofeca');
    var divfecha = document.getElementById('exitfeca');
    if (fecha != "") {
        divfechaerror.style.display = 'none';
        divfecha.style.display = 'block';
    } else {
        divfecha.style.display = 'none';
        divfechaerror.style.display = 'block';
    }


    var lat = document.getElementById('<%=lati.ClientID %>').value;
    document.getElementById('<%=txtCalleveredit.ClientID %>').value = lat;
    if (lat == "") {
        console.log("ENTRO LATITUD");

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (objPosition) {
                var lon = objPosition.coords.longitude;
                var lat = objPosition.coords.latitude;


            });
        }
        else {
            content.innerHTML = "Su navegador no soporta la API de geolocalización.";
        }
        alert("Ingresar la dirección correctamente falta la georeferencia");
    }


    var longi = document.getElementById('<%=lati.ClientID %>').value;
    document.getElementById('<%=txtCalleveredit.ClientID %>').value = longi;
    if (longi == "") {
        console.log("ENTRO LONGITUD");

        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (objPosition) {
                var lon = objPosition.coords.longitude;
                var lat = objPosition.coords.latitude;


            });
        }
        else {
            content.innerHTML = "Su navegador no soporta la API de geolocalización.";
        }
        alert("Ingresar la dirección correctamente falta la georeferencia");
    }

    var calle = document.getElementById('<%=route.ClientID %>').value;
    document.getElementById('<%=txtCalleveredit.ClientID %>').value = calle;
    var divcallerro = document.getElementById('errocalle');
    var divcalleexit = document.getElementById('calleexit');
    if (calle != "") {
        divcallerro.style.display = 'none';
        divcalleexit.style.display = 'block';
    }
    else {
        divcalleexit.style.display = 'none';
        divcallerro.style.display = 'block';
    }

    var calle1 = document.getElementById('<%=entrecalle1.ClientID %>').value;
    document.getElementById('<%=txtvercalle1veri.ClientID %>').value = calle1;
    var divcalle1exit = document.getElementById('exitcalle1');
    var divcalle1error = document.getElementById('errocalle1');
    if (calle1 != "") {
        divcalle1error.style.display = 'none';
        divcalle1exit.style.display = 'block';
    }
    else {
        divcalle1exit.style.display = 'none';
        divcalle1error.style.display = 'block';
    }

    var calle2 = document.getElementById('<%=entrecalle2.ClientID %>').value;
    document.getElementById('<%=txtcalle2ververi.ClientID %>').value = calle2;
    var calle2exit = document.getElementById('exitcalle2');
    var divcalle2 = document.getElementById('errocalle2');
    if (calle2 != "") {
        divcalle2.style.display = 'none';
        calle2exit.style.display = 'block';
    } else {
        calle2exit.style.display = 'none';
        divcalle2.style.display = 'block';
    }

    var colonia = document.getElementById('<%=colony.ClientID %>').value;
    document.getElementById('<%=txtcoloniaververi.ClientID %>').value = colonia;
    var divcoloniaexit = document.getElementById('exitcolonia');
    var divcoloniaerror = document.getElementById('errocolonia');
    if (colonia != "") {
        divcoloniaerror.style.display = 'none';
        divcoloniaexit.style.display = 'block';
    }
    else {
        divcoloniaexit.style.display = 'none';
        divcoloniaerror.style.display = 'block';
    }
    //VALIDACION DE REGION
    var textoregion = document.getElementById('<%=ddlRegion.ClientID %>');
    var Textregion = textoregion.options[textoregion.selectedIndex].text;
    var region = textoregion.options[textoregion.selectedIndex].value;
    var divregionexit = document.getElementById('regionexit');
    var divregion = document.getElementById('erroregion');

    document.getElementById('<%=txtregionververi.ClientID %>').value = Textregion;
    if (region != 0) {
        divregion.style.display = 'none';
        divregionexit.style.display = 'block';
    } else {
        divregionexit.style.display = 'none';
        divregion.style.display = 'block';


    }

    var dele = document.getElementById('<%=ddlDelegacion.ClientID %>');
    var deletext = dele.options[dele.selectedIndex].text;
    var deleval = dele.options[dele.selectedIndex].value;
    var divdele = document.getElementById('errorDelegación');
    var divdeleexit = document.getElementById('Delegaciónxit');
    document.getElementById('<%=txtredeleververi.ClientID %>').value = deletext;
    if (deleval != 0) {
        divdele.style.display = 'none';
        divdeleexit.style.display = 'block';
    } else {
        divdeleexit.style.display = 'none';
        divdele.style.display = 'block';
    }

    var muni = document.getElementById('<%=ddlMuNICIPIO.ClientID %>');
    var munitext = muni.options[muni.selectedIndex].text;
    var munival = muni.options[muni.selectedIndex].value;
    document.getElementById('<%=txtmuniververi.ClientID %>').value = munitext;
    var divmuniexit = document.getElementById('Municipioexit');
    var divrmuni = document.getElementById('errorMunicipio');
    if (munival != 0) {
        divrmuni.style.display = 'none';
        divmuniexit.style.display = 'block';
    } else {
        divmuniexit.style.display = 'none';
        divrmuni.style.display = 'block';
    }
    var locali = document.getElementById('<%=ddlLocalidad.ClientID %>');
    var localitext = locali.options[locali.selectedIndex].text;
    var localival = locali.options[locali.selectedIndex].value;
    document.getElementById('<%=txtlocaliververi.ClientID %>').value = localitext;
    var divlocaleliexit = document.getElementById('Localidadexit');
    var divlocalierro = document.getElementById('errorLocalidad');
    if (localival != 0) {
        divlocalierro.style.display = 'none';
        divlocaleliexit.style.display = 'block';
    } else {
        divlocaleliexit.style.display = 'none';
        divlocalierro.style.display = 'block';
    }

    var subrpograma = document.getElementById('<%=ddlsubprograma.ClientID %>');
    var subprotext = subrpograma.options[subrpograma.selectedIndex].text;
    var subproval = subrpograma.options[subrpograma.selectedIndex].value;
    document.getElementById('<%=txtsunproververi.ClientID %>').value = subprotext;
    var divsubpograma = document.getElementById('errorSubprograma');
    var divsubproexit = document.getElementById('exitsubprogra');
    if (subproval != 0) {
        divsubpograma.style.display = 'none';
        divsubproexit.style.display = 'block';
    } else {
        divsubproexit.style.display = 'none';
        divsubpograma.style.display = 'block';
    }


    var accion = document.getElementById('<%=ddlAcciones.ClientID %>');
    var acciontext = accion.options[accion.selectedIndex].text;
    var accionval = accion.options[accion.selectedIndex].value;
    document.getElementById('<%=txtaccionververi.ClientID %>').value = acciontext;
    var divaccion = document.getElementById('erroraccion');
    var divaccionexit = document.getElementById('accionexit');
    if (accionval != 0) {
        divaccion.style.display = 'none';
        divaccionexit.style.display = 'block';
    } else {
        divaccionexit.style.display = 'none';
        divaccion.style.display = 'block';
    }

    var nombrelugar = document.getElementById('<%=txtNombrelugar.ClientID %>').value;
    document.getElementById('<%=txtNombrelugarveredit.ClientID %>').value = nombrelugar;
    var calleexit = document.getElementById('extinombrelugar');
    var error = document.getElementById('errorlugar');
    if (nombrelugar != "") {
        error.style.display = 'none';
        calleexit.style.display = 'block';
    } else {
        calleexit.style.display = 'none';
        error.style.display = 'block';
    }

    var nombreContac = document.getElementById('<%=txtnombrecontacto.ClientID %>').value;
    document.getElementById('<%=txtnombrecontactoveriedit.ClientID %>').value = nombreContac;
    var contactexit = document.getElementById('exitnombrecontac');
    var errorcontac = document.getElementById('errornombrecontac');
    if (nombreContac != "") {
        errorcontac.style.display = 'none';
        contactexit.style.display = 'block';
    }
    else {
        contactexit.style.display = 'none';
        errorcontac.style.display = 'block';

    }

    var telefonocontac = document.getElementById('<%=txttel.ClientID %>').value;
    document.getElementById('<%=txttelefonoveredit.ClientID %>').value = telefonocontac;
    var exittelefono = document.getElementById('exitTelefono');
    var errortelefono = document.getElementById('errortelefono');

    if (telefonocontac != "") {
        errortelefono.style.display = 'none';
        exittelefono.style.display = 'block';
    }
    else {
        exittelefono.style.display = 'none';
        errortelefono.style.display = 'block';
    }

    var descripcionn = document.getElementById('<%=txtDescripcionActividad.ClientID %>').value;
    document.getElementById('<%=txtdescripveredit.ClientID %>').value = descripcionn;
    var exitdescrip = document.getElementById('exitdescrip');
    var errordescrip = document.getElementById('errordescrip');
    if (descripcionn != "") {
        errordescrip.style.display = 'none';
        exitdescrip.style.display = 'block';
    }
    else {
        exitdescrip.style.display = 'none';
        errordescrip.style.display = 'block';
    }

    var personaatemdio = document.getElementById('<%=txtpersonal_atendio_actividad.ClientID %>').value;
    document.getElementById('<%=txtpersonaatendioveredit.ClientID %>').value = personaatemdio;
    var exitpersonaatendio = document.getElementById('exitpersonaatemdio');
    var erropersonaatendio = document.getElementById('errorpersonaatendio');
    if (personaatemdio != "") {
        erropersonaatendio.style.display = 'none';
        exitpersonaatendio.style.display = 'block';
    }
    else {
        exitpersonaatendio.style.display = 'none';
        erropersonaatendio.style.display = 'block';

    }
    var niño = document.getElementById('<%=txtnino.ClientID %>').value;
    var exitnino = document.getElementById('exitnino');
    var errornino = document.getElementById('errornino');
    if (niño != "") {
        errornino.style.display = 'none';
        exitnino.style.display = 'block';
    } else {
        exitnino.style.display = 'none';
        errornino.style.display = 'block';

    }
    var nina = document.getElementById('<%=txtnina.ClientID %>').value;
    document.getElementById('<%=txtMeditver.ClientID %>').value = nina;
    var extinina = document.getElementById('exitnina');
    var erronina = document.getElementById('errornina');
    if (nina != "") {
        erronina.style.display = 'none';
        extinina.style.display = 'block';

    } else {
        extinina.style.display = 'none';
        erronina.style.display = 'block';
    }

    var Hombres = document.getElementById('<%=txthombres.ClientID %>').value;
    document.getElementById('<%=txtHombresveredit.ClientID %>').value = Hombres;
    var exith = document.getElementById('exithombre');
    var errorm = document.getElementById('errorhombre');
    if (Hombres != "") {
        errorm.style.display = 'none';
        exith.style.display = 'block';
    } else {
        exith.style.display = 'none';
        errorm.style.display = 'block';
    }

    var Mujeres = document.getElementById('<%=txtmujeres.ClientID %>').value;
    document.getElementById('<%=txtmujeresVeredit.ClientID %>').value = Mujeres;
    var exitm = document.getElementById('extimujer');
    var errorm = document.getElementById('errormujer');
    if (Mujeres != "") {
        errorm.style.display = 'none';
        exitm.style.display = 'block';
    }
    else {
        exitm.style.display = 'none';
        errorm.style.display = 'block';
    }

    var doceh = document.getElementById('<%=txtdocenteh.ClientID %>').value;
    document.getElementById('<%=txtdocehombresverdeit.ClientID %>').value = doceh;
    var exitdoceh = document.getElementById('exitdocentesh');
    var errortdoceh = document.getElementById('errordoceh');
    if (doceh != "") {
        errortdoceh.style.display = 'none';
        exitdoceh.style.display = 'block';
    } else {
        exitdoceh.style.display = 'none';
        errortdoceh.style.display = 'block';
    }


    var docem = document.getElementById('<%=txtdocentem.ClientID %>').value;
    document.getElementById('<%=txtdoceMujerverdeit.ClientID %>').value = docem;
    var exitdocem = document.getElementById('exitdocentesm');
    var errordocem = document.getElementById('errordocem');
    if (docem != "") {
        errordocem.style.display = 'none';
        exitdocem.style.display = 'block';
    } else {
        exitdocem.style.display = 'none';
        errordocem.style.display = 'block';
    }

    var totales = document.getElementById('<%=txtatendios.ClientID %>').value;
    document.getElementById('<%=txttotalveredit.ClientID %>').value = totales;
    var exitotal = document.getElementById('extitotal');
    var errortotal = document.getElementById('errortotal');

    if (totales != "") {
        errortotal.style.display = 'none';
        exitotal.style.display = 'block';
    }
    else {
        exitotal.style.display = 'none';
        errortotal.style.display = 'block';
    }

    $('#exampleModal').modal();
    return false;

}

function confirmar() {
    if (!Page_ClientValidate())
        // Fuerza la validación en cliente
        return false;
    return confirm('¿Seguro que desea realizar el envío?');
}
