using Futebol.Data;
using Futebol.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Futebol.Services
{
    public class TimeService
    {
        private readonly FutebolContext _context;
        public TimeService(FutebolContext futebolContext)
        {
            _context = futebolContext;
        }
        public List<TimeModel> FindAll()
        {
            return _context.Time.OrderByDescending(x => x.Nome).ToList();
        }
        public TimeModel FindById(int id)
        {
            return _context.Time.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(TimeModel obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            try
            {
                var obj = _context.Time.Find(id);
                _context.Time.Remove(obj);
                _context.SaveChanges();
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException(e.Message);
            }
        }
        public void Update(TimeModel obj)
        {
            if (!_context.Time.Any(x => x.Id == obj.Id))
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
