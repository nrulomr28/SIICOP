# Reorganización SIICOP

## Objetivo

Reducir acoplamiento, centralizar servicios comunes y mejorar la mantenibilidad sin afectar la operación actual.

## Reconstrucción de Site.Master

Fecha: 08/06/2026

Se detectó que la Master heredada presentaba comportamientos inconsistentes en el renderizado del menú.

Acciones:
- Se creó una Master mínima funcional.
- Se validó Login, Menú y Logout.
- Se inició reconstrucción incremental por componentes.
- Se agregó nuevamente el footer institucional.

Estado:
Master funcional y estable.

## Desecho o desuso de páginas de bienvenida.
Fecha: 09/06/2026

Las páginas Bienvenido_* dejan de ser utilizadas
como punto de entrada principal.

El acceso institucional se centraliza en Launcher.aspx.