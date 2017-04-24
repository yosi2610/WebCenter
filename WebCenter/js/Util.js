function KeyPress(btnSubmit, btnCancel){
	if (event.keyCode == 27){
		event.cancelBubble = true;
		event.returnValue = false;
		var btn = document.getElementById("btnCancel");
		btn.click();
		//Form1[btnCancel].click();
	}
	if (event.keyCode == 13){
		event.cancelBubble = true;
		event.returnValue = false;
		var btn = document.getElementById("btnSubmit");
		btn.click();

		//Form1[btnSubmit].click();
	}
}

function ClearTextBoxESC(txtBox) {
	if (event.keyCode == 27){
		event.cancelBubble = true;
		event.returnValue = false;
		Form1[txtBox].value="";
	}

}


//Obtiene una instancia del objeto XmlHttpRequest

function ObtenerObjetoAjax() {

    var peticionHttp = null;

    try {

        //Comprobación para navegadores Firefox, Opera y Safari

        if (window.XMLHttpRequest) {

            peticionHttp = new XMLHttpRequest();

        }

        //Comprobación para navegadores IE

        else if (window.ActiveXObject) {

            //Comprobamos para JavaScript 5.0. Si da error,

            //creamos un objeto con la versión anterior

            try {

                peticionHttp = new ActiveXObject("Microsoft.XMLHTTP2");

            }

            catch (e1) {

                peticionHttp = new ActiveXObject("Microsoft.XMLHTTP");

            }

        }

        //Comprobación para IceBrowser

        else if (window.createRequest) {

            peticionHttp = window.createRequest();

        }

        //Si el navegador no soporta ajax retornamos null

        else {

            peticionHttp = null;

        }

    }

    catch (e2) {

        return null;

    }

    return peticionHttp;

}

 //A continuación crearemos la función que envíe la petición al servidor:

//Realiza una petición asíncronamente al servidor

//url: Url dónde realizar la petición

//tipoResultado: Puede set 'XML' o 'TEXT'

//metodo: Tipo de petición. Puede ser 'GET' o 'POST'

//parametrosPost: Parámetros para peticiones tipo POST

//cacheDatos: Indica si se cachearán las peticiones por GET en IE

//funcionPintarDatos: Función para manejar las acciones a realizar en

// cada estado de la petición

function ObtenerDatosASinc(url, tipoResultado, metodo, parametrosPost,

cacheDatos, funcionAjax) {

    try {

        //Obtenemos la instancia del objeto XmlHttpObject

        var objAjax = ObtenerObjetoAjax();

         

        //Nos suscribimos al evento onreadystatechange para manejar los

        //posibles estados de la petición para que se lance la

        //función recibida por parámetro

        objAjax.onreadystatechange = function() {

            switch (objAjax.readyState) {

                 

                //Petición no inicializada

                case 0:

                    break;

                 

                //Conexión con el servidor establecida

                //(llamada a send)

                case 1:

                    break;

                 

                //Enviando petición

                case 2:

                    //Aquí se podría mostrar un gif que indicase

                    //que se está realizando la petición al servidor

                    //Habría que ocultarlo en el caso 4,

                    //cuando ya se ha recibido la respuesta

                    break;

                 

                //Recibiendo petición

                case 3:

                    break;

                 

                //Respuesta del servidor recibida

                case 4:

                    //Si el status code de la respuesta es 200,

                    //todo ha ido bien

                    if (objAjax.status == 200) {

                        switch (tipoResultado) {

                        case 'XML':

                            funcionAjax(objAjax.responseXML);

                        break;

                        case 'TEXT':

                            funcionAjax(objAjax.responseText);

                        break;

                        default:

                            funcionAjax(objAjax.responseText);

                        break;

                        }

                    }

                    //Si no, no ha ido bien y retornamos el texto

                    //equivalente al status code

                    else {

                        switch (tipoResultado) {

                        case 'XML':

                            funcionAjax(

                            '<a>' + objAjax.statusText + '</a>');

                            break;

                        case 'TEXT':

                            funcionAjax(objAjax.statusText);

                            break;

                        default:

                            funcionAjax(objAjax.statusText);

                            break;

                        }

                    }

                    break;

                     

                //No hay más estados en la petición,

                //por lo que no hacemos nada

                default:

                    break;

            }

     

        };

         

        //Si realizamos la petición por POST

        if (metodo == 'POST') {

             

            //Si no recibimos parámetros ponemos la variable a null

            if (parametrosPost == 'undefined' || !parametrosPost) {

                parametrosPost = null;

            }

         

            objAjax.open('POST', url, true);

            objAjax.setRequestHeader('Content-type',

            'application/x-www-form-urlencoded');

            objAjax.send(parametrosPost);

        }

        //Si no la realizamos por GET.

        else {

             

            //Internet Explorer cachea las peticiones por GET,

            //por lo que agregamos un parametro random si se

            //quiere evitar

            if (!cacheDatos) {

                var separadorUrl =

                (url.indexOf('?') > -1) ? '&' : '?';

                url += separadorUrl + 'rndCache=' + Math.random();

            }

             

            objAjax.open('GET', url, true);

            objAjax.send(null);

        }

    }

    catch (e) {

        //Si hay un error mostramos su mensaje

        alert(e.message);

    }

}

//Realiza una petición asíncrona al servidor para obtener la hora

function ObtenerHora() {

        ObtenerDatosASinc('HoraServidor.aspx', 'TEXT', 'GET', null, false, PintarHora);
    
}
function SoloNumeros(e) {
    var key_press = document.all ? key_press = e.keyCode : key_press = e.which;
    return ((key_press > 47 && key_press < 58));
    //return((key_press > 47 && key_press < 58)|| key_press == 46); 
    // el  "|| key_press == 46" es para incluir el punto ".", si borramos solo ingresara enteros 
}