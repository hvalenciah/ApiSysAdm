using System;
using System.Collections.Generic;
using System.Linq;
using ADP.API.Model.Data.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.Mappers.Balcan;

namespace ADP.API.Service.Services.Balcan
{
    public class VistaService : IVistaService
    {
        private readonly BalcanContext _context;

        public VistaService(BalcanContext context)
        {
            _context = context;
        }

        public IEnumerable<VistaDTO> GetByModuleId(int idModulo)
        {
            var vistas = _context.Vista
                .Where(v => v.IdModulo == idModulo)
                .ToList();

            return vistas.Select(VistaMapper.ToDTO);
        }

        public VistaDTO AddViewToModule(ModuloVistaDTO dto)
        {
            var vista = _context.Vista.FirstOrDefault(v => v.Id == dto.IdVista);
            if (vista == null)
            {
                throw new KeyNotFoundException($"No se encontró la vista con ID {dto.IdVista}");
            }

            var moduloExists = _context.Modulos.Any(m => m.Id == dto.IdModulo);
            if (!moduloExists)
            {
                throw new KeyNotFoundException($"No se encontró el módulo con ID {dto.IdModulo}");
            }

            vista.IdModulo = dto.IdModulo;
            _context.SaveChanges();

            return VistaMapper.ToDTO(vista);
        }

        public bool DeleteViewFromModule(ModuloVistaDTO dto)
        {
            var vista = _context.Vista.FirstOrDefault(v => v.Id == dto.IdVista && v.IdModulo == dto.IdModulo);
            if (vista == null)
            {
                return false;
            }

            vista.IdModulo = null;
            _context.SaveChanges();

            return true;
        }
    }
}