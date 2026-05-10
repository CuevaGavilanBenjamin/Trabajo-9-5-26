# Refactorización del Proyecto

Se ha actualizado la estructura del proyecto para que coincida con la imagen proporcionada:

## Estructura de carpetas creada
- `Context`
- `Controllers` (ya existía)
- `Helpers`
- `Models`
- `Repositories`
- `Services`

## Cambios realizados en archivos
- Movido `WeatherForecast.cs` a la carpeta `Models` y actualizado su namespace a `Trabajo_9_5_26.Models`.
- Renombrado `WeatherForecastController.cs` a `EjecucionController.cs` en la carpeta `Controllers` y cambiando el nombre de la clase a `EjecucionController` e importando el nuevo namespace de models aportado al proyecto.