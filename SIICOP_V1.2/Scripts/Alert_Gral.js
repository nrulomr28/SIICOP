

function error() {
    Swal.fire(
        'Error!',
        'Hubo un error',
        'error'
    )
};


function Correcto() {
    Swal.fire(
        'Correcto!',
        'Se guardo con exito',
        'success'
    )
};



function ModoEdicion() {
    Swal.fire(
        'Edición',
        'Esta en modo edición del reporte.',
        'question'
    )
};


function CamposObligatorios(textoValidacion) {
    Swal.fire({
        title: '<strong>Campos obligatorios</strong>',
        icon: 'warning',
        html: textoValidacion,
        timer: 6000,
        timerProgressBar: true,
    })
}