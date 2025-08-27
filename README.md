# API Gestion de Incidencias

Version .NET: 9 / C# 13

Base URL (desarrollo): http://localhost:5170/api

## Autenticacion / Login
POST /Login/login
Descripcion: Valida credenciales de un usuario (Alumno, Docente o Soporte) y retorna datos basicos + rol.
Body (JSON): { "username": "user@example.com", "password": "secreto" }
Respuesta (200): { "user": { ...datosUsuario... }, "rol": "Docente" }
Errores: 400 (datos faltantes), 401 (credenciales invalidas)

## Incidencias
GET /Incidencia/listaIncidencias
Descripcion: Lista todas las incidencias ordenadas por fecha de creacion descendente.

GET /Incidencia/listaIncidenciasNoResueltas
Descripcion: Lista incidencias cuyo Estado != "Resuelto".

GET /Incidencia/listaIncidenciasResueltas
Descripcion: Lista incidencias con Estado == "Resuelto".

GET /Incidencia/listaPorFecha?fechaInicio=AAAA-MM-DD&fechaFin=AAAA-MM-DD (fechaFin opcional)
Descripcion: Lista incidencias dentro del rango (si no se envia fechaFin usa solo el dia inicio).

GET /Incidencia/findById?id={id}
Descripcion: Obtiene una incidencia por su Id. Incluye datos del alumno asociado si AlumnoId != null.
Respuesta (200 ejemplo):
{
  "idIncidencia": 15,
  "descripcion": "Problema acceso plataforma",
  "estado": "Pendiente",
  "tipo": "Acceso",
  "fechaCreacion": "2025-08-27T10:15:00Z",
  "usuarioId": 3,
  "alumnoId": 12,
  "alumno": {
    "idAlumno": 12,
    "nombre": "Juan",
    "apellidos": "Perez",
    "dni": "12345678",
    "email": "juan.perez@correo.com",
    "grado": "5to Secundaria"
  }
}

POST /Incidencia/Crear
Descripcion: Crea una nueva incidencia.
Body (JSON):
{
  "descripcion": "Texto del problema",
  "estado": "Pendiente",    // opcional, default Pendiente
  "tipo": "Correo",          // opcional, default General
  "usuarioId": 3,             // Id del Docente (creador)
  "alumnoId": 12              // opcional
}
Respuesta 201: IncidenciaResponse (mismo formato que findById)
Errores: 400 validaciones

POST /Incidencia/resolver/{id}
Descripcion: Marca una incidencia como Resuelto (si aun no lo esta) y devuelve su estado actualizado.

## Incidencias (rol Soporte)
POST /Soporte/resolver/{id}
Descripcion: Alternativa para personal de soporte para resolver una incidencia. Valida existencia y evita doble resolucion.

GET /Soporte/top-alumnos
Descripcion: Retorna el TOP 3 de alumnos con mas incidencias asociadas.
Respuesta ejemplo:
[
  { "alumnoId": 12, "nombreCompleto": "Juan Perez", "totalIncidencias": 5 },
  { "alumnoId": 7,  "nombreCompleto": "Ana Lopez", "totalIncidencias": 4 },
  { "alumnoId": 3,  "nombreCompleto": "Luis Diaz", "totalIncidencias": 3 }
]
Notas: Si en el futuro se desea parametrizar el TOP, agregar query param ?top=N.

## Alumnos
GET /Alumno/{idAlumno}
Descripcion: Obtiene un alumno por su IdAlumno.

GET /Alumno/listar
Descripcion: Lista todos los alumnos ordenados por Apellidos y Nombre.

GET /Alumno/por-grado?grado=GRADO
Descripcion: Lista alumnos filtrando por valor exacto de Grado.

## Modelos principales
IncidenciaResponse:
{
  "idIncidencia": int,
  "descripcion": string,
  "estado": string,
  "tipo": string,
  "fechaCreacion": string (ISO 8601),
  "usuarioId": int,
  "alumnoId": int?,
  "alumno": AlumnoResponse | null
}

AlumnoResponse:
{
  "idAlumno": int,
  "nombre": string,
  "apellidos": string,
  "dni": string,
  "email": string,
  "grado": string
}

AlumnoIncidenciaCountResponse:
{
  "alumnoId": int,
  "nombreCompleto": string,
  "totalIncidencias": int
}

## Codigos de error comunes
400 BadRequest: Datos invalidos o faltantes.
401 Unauthorized: Credenciales invalidas (login).
404 NotFound: Recurso no encontrado.
409 Conflict: Intencion futura (no se usa aun) para estados inconsistentes.

## Notas
- Los endpoints de resolucion solo cambian Estado a "Resuelto" (no guardan fecha de resolucion; podria agregarse un campo FechaResolucion futuro).
- Se recomienda agregar autenticacion JWT y autorizacion por rol antes de exponer a produccion.
- Todas las fechas se manejan en la hora del servidor (recomendado UTC en produccion).

## Futuras Mejores Practicas (sugerencias)
- Paginacion en listados grandes (query params page, pageSize).
- Filtro por UsuarioId y AlumnoId en lista de incidencias.
- Historial de cambios de estado.
- Soft delete o archivado de incidencias.

Fin.
