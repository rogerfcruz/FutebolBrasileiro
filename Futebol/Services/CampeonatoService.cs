using Futebol.Data;
using Futebol.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Futebol.Services
{
    public class CampeonatoService
    {
        private readonly FutebolContext _context;
        public CampeonatoService(FutebolContext futebolContext)
        {
            _context = futebolContext;
        }
        public List<CampeonatoModel> FindAll()
        {
            return _context.Campeonato.OrderByDescending(x => x.Valor).ToList();
        }
        public CampeonatoModel FindById(int id)
        {
            return _context.Campeonato.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(CampeonatoModel obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            try
            {
                var obj = _context.Campeonato.Find(id);
                _context.Campeonato.Remove(obj);
                _context.SaveChanges();
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException(e.Message);
            }
        }
        public void Update(CampeonatoModel obj)
        {
            if (!_context.Campeonato.Any(x => x.Id == obj.Id))
            {
                throw new ApplicationException("Id não encontrado!");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}
