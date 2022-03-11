# Código PostgreSQL

El documento hoja_de_vida_seiton contiene el código para la construcción de la hoja de vida de dispositos biomédicos en PostgreSQL divididos en las siguientes tablas:

## Hoja de vida

1. Descripción del bien  
2. Datos técnicos
3. Datos económicos
4. Datos de ubicación del equipo
5. Datos de proveedor
6. Requerimentos de funcionamiento
7. Tabla de parámetros medidos
8. Tabla existencia de información técnica
9. Estado de bien
10. Accesorios del equipo
11. Otros datos
12. Registro de elaboración y actualización

## Busqueda

Queries para la busqueda de cada tabla descritos en el documento con código.

**RECORDATORIO**

 /* AQUI ES LA SECCIÓN DE IMPLEMENTACIONES SIN TERMINAR */
 /* En contexto para la actualizacion de los dispositivos se planteo la anternativa de tomar las series de cada
 dispositivo donde en el caso en el sistema se ingrese la serie de nuevo, el sistema lo indentifique y lo cambie
 de la siguiente manera*/
 /* Serie guardada: 1234; Ingresa de nuevo la serie: 1234; El trigger de cambiar la serie a 1234-1*/
 /* Para una segunda actualizacion un contador aumentara el valor tal que la serie*/
 /* 1234, 1234-1, 1234-2, 1234-... */
