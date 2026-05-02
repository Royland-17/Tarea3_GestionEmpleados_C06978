# Tarea 3: Sistema de Gestión de Empleados
**Estudiante:** [Royland Ruiz Arias]  
**Carnet:** [C06978]  
**Curso:** [Lenguajes de Aplicaciones Comerciales]

## Instrucciones de Ejecución
1. Abrir la solución `Tarea3_GestionEmpleados_C06978.sln` en Visual Studio 2022.
2. Abrir la **Consola del Administrador de Paquetes**.
3. Ejecutar el comando `Update-Database` para crear la base de datos localmente.
4. Presionar `F5` o el botón **Start** para ejecutar la aplicación en el navegador.

## Descripción de la Paginación
La funcionalidad de paginación se implementó en el controlador de Empleados utilizando los parámetros `pageNumber` y `pageSize`. 
- Se calcula el total de registros para determinar cuántas páginas existen.
- Se utiliza `.Skip()` y `.Take()` en LINQ para recuperar solo los registros correspondientes a la vista actual, optimizando el rendimiento del servidor.

## Ejemplo de URL con Búsqueda y Paginación
Para buscar empleados por nombre y navegar a una página específica, use el siguiente link:
https://localhost:7278/

## Script SQL
El script para la creación manual de la base de datos se encuentra en la carpeta `/ScriptsSQL`.