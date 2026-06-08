# Decisiones Técnicas

## 2026-06-08

### Estructura de clases

Se mantiene la carpeta Clases como contenedor principal.

Subcarpetas:

* DTOs
* Helpers
* Models
* Repositories
* Services
* Constants
* Security
* Validators

Motivo:
Evitar cambios masivos de namespaces y mantener compatibilidad con módulos existentes.

### Entorno de desarrollo

Visual Studio 2022 se considera entorno principal de desarrollo.

Visual Studio 2026 se utilizará para pruebas de compatibilidad.
