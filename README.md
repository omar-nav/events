# events API

Ejercicio
BACKEND .NET
Caso del ejercicio
Se espera construir un administrador de eventos con buscador de texto 
inteligente que pueda filtrar la búsqueda en grandes cantidades de registros.
Backend (API Service): (.Net Framework)
1. Crear tabla de eventos en MySQL / Oracle / SQL Server y agregar 10 registros
con los siguientes valores:
o id
o name
o Category
o brand
o slug
o status
2. Hacer los servicios para la gestión de productos:
• Servicios para CRUD:
▪ Obtener un producto
▪ Obtener varios productos con posibilidad de paginado
▪ Actualizar un producto
▪ Eliminar un producto
• Servicio de búsqueda:
▪ Crear un servicio con método de búsqueda que 
devuelva los items de productos que contengan la 
fracción de palabra en base a:
• Nombre de producto (name)
• URL de producto (slug)
• Nombre de categoría de producto (category
{name})
• Nombre de marca de producto (brand {name})