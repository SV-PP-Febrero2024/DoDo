DoDo App.
    Aplicación de gestión de tareas.

INSTRUCCIONES:

 1. Abrir la aplicación:
     - USANDO DOCKER 
         a. Instala Docker, ábrelo e inicia sesión.

         b. Descarga la imagen de Docker del repositorio con el siguiente comando en la terminal:
            docker pull icbmasterchief/dodo-app:latest
        
         c. Crear y ejecutar el contenedor de la imagen que acabamos de descargar con el siguiente comando en la terminal:
            docker run -it -p 7790:7790 -e MACHINE_NAME=Docker icbmasterchief/dodo-app
              
     - DEBUGEANDO LOCALMENTE DESDE EL PROPIO PROYECTO DESCARGADO
         a. Abre la terminal y ve a la carpeta "DoDo.Presentation" del proyecto.
            ejemplo: cd "C:\Descargas\DoDo\DoDo.Presentation" 

         b. Ejecuta la aplicación con este comando:
            dotnet run

 2. Moverse por la aplicación:
     - Usa las flechas del teclado para navegar por los menús

     - Pulsa Enter para aceptar.

 3. Explicación de los menús:
     - "Log In": Iniciar sesión con un usuario existente.

     - "Sign Up": Crea un nuevo usuario.

     - "Search for task": Busca tareas del usuario por título.

     - "Show current tasks": Muestra todas las tareas del usuario sin completar.

     - "Show completed tasks": Muestra todas las tareas del usuario completadas.

     - "Create new task": Crea una nueva tarea para el usuario.

     - "Complete a task": Completa una tarea del usuario.

     - "Delete a task": Elimina una tarea del usuario.

     - "My user info": Aquí puedes ver los datos de tu cuenta de usuario, como por ejemplo las multas 
       por no haber devuelto un lirbo a tiempo. Además aparecerá un nuevo menú con estas opciones:

     - "Log Out": Finalizar la sesión del usuario actual.

     - "<- Back to menu": Esta opción aparecerá en varios apartados de la aplicación y sirve para
       regresar al menú principal. 
    
     - "Exit": Salir de la aplicación.

 4. Puntos del ejercicio realizados:
         Obligatorios:
             - Menú principal y secundario.
             - Gestión de alta y selección de usuarios.
             - Zona pública y privada.
             - El modelo de datos está compuesto de 2 clases relacionadas entre ellas (Usuario y Tarea). Las clases tienen 5 atributos (String, int, boolean, DateTime, Usuario).
             - funcionalidad de búsqueda.
             - Aplicación contenerizada y alojada en un registro de contenedores.
         Extra:
             - Se ha usado Git y la metodología Gitflow.
             - Datos almacenados y cargados en ficheros Json.
             - Volumen del contenedor configurado para poder acceder a los ficheros json.
             - Variable de entorno utilizada en el contenedor y en la aplicación.
             - Implementada una interfaz de usuario más visual usando "Spectre.Console".