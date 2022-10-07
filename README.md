# PRUEBA.APITIKET
este repositorio es de un proyecto de prueba para postulacion para programador de .net core backed
en la cual se detalla lo siguiente del codigo


apiPrueba esta constituido del framework .net 6 entityFramework Core
se maneja con esta orm para ser mas sencilla la manipulacion de dll de dato se maneja bajo un arquitectura hexagonal
de la cual esta compuesta por dominio servicios repositorios y sus respectivas api se maneja atravez de formato json no se maneja xml no fue configurado para ese alcance
presenta patrones de diseño factory y singleton
y una pequeña libreria de metodos reactivos 

en la parte del front se manejo con el framework de angular aplicacion servicios modelos la aplicacion debe realizar los siguientes pasos para ejecutar el programa

1. instalar npm i --legacy-peer-deps en la carpeta AppClient de la api pruebaTicket
2.  ejecutar en el pm de visual o consola update database para que se migre el modelo
3.  el proyecto es realizado first code
4.  la configuracion de acceso a la base de datos se encuentran en el appsettings
5.  de ser el caso si desea puede ejecutar el script sql para generar la base de datos con sus datos
6.  luego de ellp puede ejecutar la api y dirigirse al puertto 
7.  https://localhost:44450 para el front
8.  https://localhost:44350/swagger/index.html para la api del backend
9.  
