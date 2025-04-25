# Proyecto: Sistema de Gestión de Reclamos

Este repositorio contiene la solución al ejercicio técnico solicitado para la plaza de **Coordinador de Desarrollo de Sistemas Informáticos 2025**, desarrollado con ASP.NET Core 8.0, SQL Server y siguiendo principios de arquitectura limpia (Clean Architecture) y SOLID.

---

## ✅ Tecnologías utilizadas

- **ASP.NET Core 8.0 MVC**
- **Entity Framework Core 8.0**
- **SQL Server 2014+** (compatible hasta 2022)
- **Bootstrap 5** + Razor Views
- **jQuery + Input Mask** para máscaras de entrada
- **Autenticación con cookies**
- **Patrón Repository y Unit of Work**
- **Migraciones y SeedData** para datos iniciales

---

## 📦 Estructura del proyecto (Clean Architecture)

```
├── PCoor_Ramos.Web           # Capa de presentación (MVC)
├── PCoor_Ramos.Application   # Interfaces de servicios
├── PCoor_Ramos.Domain        # Entidades y modelos
├── PCoor_Ramos.Infrastructure # Repositorios y DbContext
├── Scripts                   # SQL y .bak
```

---

## 🧾 Requisitos funcionales implementados

- ✔️ Login de empleados técnicos
- ✔️ Registro de reclamos por consumidor
- ✔️ Clasificación de reclamos como asesoría, aviso o propuesta
- ✔️ Inserción automática en t_Asesoria o t_Aviso según clasificación
- ✔️ Propuestas de solución por proveedor
- ✔️ Aceptación o rechazo de propuestas por parte del consumidor
- ✔️ Validaciones de datos (campos obligatorios, únicos, fechas, formatos)
- ✔️ Transacciones de base de datos en operaciones sensibles
- ✔️ SeedData con empleados y estados de reclamo
- ✔️ Navegación protegida por login

---

## 🔐 Usuario de prueba

Puedes iniciar sesión en el sistema con el siguiente usuario precargado desde `SeedData.cs`:

```
Usuario: cmorales
Clave: 1234
```

---

## ▶️ Pasos para correr el proyecto

### 1. Restaurar la base de datos

- Opción 1: Ejecuta el script SQL ubicado en `Scripts/PCoor_Ramos.sql`
- Opción 2: Restaura desde el archivo `.bak` si tienes SQL Server Management Studio

### 2. Configurar la cadena de conexión

En el archivo `appsettings.json` dentro de `PCoor_Ramos.Web`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=DBCoor_Martinez;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### 3. Ejecutar migraciones y SeedData (si aplica)

Desde la consola de administrador de paquetes:

```
dotnet ef database update
```

> O simplemente ejecuta la app y SeedData se aplicará automáticamente.

### 4. Iniciar el proyecto

- Establece `PCoor_Ramos.Web` como proyecto de inicio
- Ejecuta con `Ctrl + F5` o desde Visual Studio

---

## 📋 Notas adicionales

- El diseño está basado en Bootstrap y es responsive
- Las máscaras para teléfono y montos están aplicadas vía jQuery
- El empleado autenticado se autoasigna al registrar reclamos
- El sistema aplica principios SOLID y buenas prácticas de desarrollo profesional

---

## 🧑 Autor

**José Antonio Martínez**  
Correo: [jaramosmartinez92@gmail.com  
Fecha de entrega: 24/04/2025
