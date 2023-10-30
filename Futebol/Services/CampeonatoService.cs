using Futebol.Data;
using Futebol.Models;
using Microsoft.EntityFrameworkCore;
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
            var obj = _context.Campeonato.Find(id);
            _context.Campeonato.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(CampeonatoModel obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
    }
}
