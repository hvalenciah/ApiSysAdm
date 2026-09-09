using ADP.API.Model.DTOs.Balcan;
using APD.API.Model.Entitites.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class PermisosMapper
    {
        public static PermisoNodoDTO ToNodoDto(
            Vistum vista, 
            List<Vistum> todasLasVistas, 
            HashSet<int> vistasConPermisoIds, 
            List<VistaUsuario> permisosUsuario,
            ref int idVirtual)
        {
            var permisoEspecifico = permisosUsuario.FirstOrDefault(pu => pu.IdVista == vista.Id);

            var nodo = new PermisoNodoDTO
            {
                Id = vista.Id,
                IdVistaPadre = vista.IdVistaPadre,
                Nombre = vista.Nombre,
                IsChecked = vistasConPermisoIds.Contains(vista.Id)
            };

            // 1. Obtener vistas hijas asignadas en la BD
            var vistasHijas = todasLasVistas
                .Where(v => v.IdVistaPadre == vista.Id)
                .ToList();

            if (vistasHijas.Any())
            {
                // Mapeo recursivo
                foreach (var hija in vistasHijas)
                {
                    nodo.Hijos.Add(ToNodoDto(hija, todasLasVistas, vistasConPermisoIds, permisosUsuario, ref idVirtual));
                }
            }
            else
            {
                // 2. Si es nodo hoja, generar las casillas virtuales para cada acción (CRUD + Autorizar)
                nodo.Hijos = GenerarNodosAcciones(vista.Id, permisoEspecifico, ref idVirtual);
            }

            return nodo;
        }

        private static List<PermisoNodoDTO> GenerarNodosAcciones(int idVistaPadre, VistaUsuario? permiso, ref int idVirtual)
        {
            return new List<PermisoNodoDTO>
            {
                new PermisoNodoDTO
                {
                    Id = ++idVirtual,
                    IdVistaPadre = idVistaPadre,
                    Nombre = "Consultar",
                    IsChecked = permiso?.Consultar ?? false,
                    Hijos = new List<PermisoNodoDTO>()
                },
                new PermisoNodoDTO
                {
                    Id = ++idVirtual,
                    IdVistaPadre = idVistaPadre,
                    Nombre = "Agregar",
                    IsChecked = permiso?.Agregar ?? false,
                    Hijos = new List<PermisoNodoDTO>()
                },
                new PermisoNodoDTO
                {
                    Id = ++idVirtual,
                    IdVistaPadre = idVistaPadre,
                    Nombre = "Actualizar",
                    IsChecked = permiso?.Actualizar ?? false,
                    Hijos = new List<PermisoNodoDTO>()
                },
                new PermisoNodoDTO
                {
                    Id = ++idVirtual,
                    IdVistaPadre = idVistaPadre,
                    Nombre = "Borrar",
                    IsChecked = permiso?.Borrar ?? false,
                    Hijos = new List<PermisoNodoDTO>()
                },
                new PermisoNodoDTO
                {
                    Id = ++idVirtual,
                    IdVistaPadre = idVistaPadre,
                    Nombre = "Autorizar",
                    IsChecked = permiso?.Autorizar ?? false,
                    Hijos = new List<PermisoNodoDTO>()
                }
            };
        }
    }
}