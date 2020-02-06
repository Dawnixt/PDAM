window.onload = inicializa;

function inicializa() {

    //document.getElementById("btnSaludar").addEventListener('click', pedirSaludo);
    document.getElementById("btnPedirApellido").addEventListener('click', pedirApellido);
    document.getElementById("btnBorrar").addEventListener('click', borrarPersona);
    document.getElementById("btnEditar").addEventListener('click', editarPersona);
}

function editarPersona() {

    var idPersona = document.getElementById("idPersonaBorrar").value;

    var heroe = new Object();
    heroe.idHeroe = idPersona;
    heroe.nombreHeroe = document.getElementById("idPersonaEditar").value;

    var millamada = new XMLHttpRequest();
    millamada.open("PUT", "https://localhost:44358/api/values/" + idPersona, false);
    millamada.setRequestHeader('Content-type', 'application/json');

    millamada.onreadystatechange = function () {

        if (millamada.readyState < 4) {

            document.getElementById("divEditar").innerHTML = "Cargando...";

        }
        else {

            if (millamada.readyState == 4 && millamada.status == 200) {
                alert("Persona editada")
            }
            else if (millamada.status == 404 || millamada.status == 400) {
                alert("Ha ocurrido un error");
            }

        }

    }

    millamada.send(JSON.stringify(heroe));

}

//function pedirSaludo() {


//    var miLlamada = new XMLHttpRequest();
//    miLlamada.open("GET", "../Pages/Hola.html");

//    //Definicion estados
//    miLlamada.onreadystatechange = function () {

//        if (miLlamada.readyState < 4) {

//            document.getElementById("divSaludo").innerHTML = "Cargando...";

//        }
//        else
//            if (miLlamada.readyState == 4 && miLlamada.status == 200) {


//                var mensaje = miLlamada.responseText;
//                document.getElementById("divSaludo").innerHTML = mensaje;

//            }

//    };

//    miLlamada.send();

//}
function pedirApellido() {

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://localhost:44358/api/values");
    //https://localhost:44358/api/values

    //Definicion estados
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            document.getElementById("divApellido").innerHTML = "Cargando...";

        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                //mensaje es igual al mensaje que se ha recibido entonces claro 
                //miLlamada es un texto que se recibe de la llamada y lo que nos da es un string 
                //con forma de JSON ese texto luego lo parseo y me da un array del cual cojo la primera 
                //persona y luego su apellido
                var mensaje = miLlamada.responseText;
                var arrayPersonas = JSON.parse(mensaje);
                var apellido = arrayPersonas[0].nombreSuperheroe;
                document.getElementById("divApellido").innerHTML = apellido;

            }

    };

    miLlamada.send();


}

function borrarPersona() {

    var miLlamada = new XMLHttpRequest();
    var idPersona = document.getElementById("idPersonaBorrar").value;
    miLlamada.open("DELETE", "https://localhost:44358/api/values" + idPersona);

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            document.getElementById("divBorrar").innerHTML = "Borrando...";

        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                alert("Persona Borrada");

            }
            else if (miLlamada.status == 404 || miLlamada.status == 204) {
                alert("Ha ocurrido un error");
            }


    };

    miLlamada.send();

}