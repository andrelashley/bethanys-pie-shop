using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Data;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PieRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Pie> Pies {
            get { return _applicationDbContext.Pies.Include(c => c.Category); }
        }
        public IEnumerable<Pie> PiesOfTheWeek {
            get { return _applicationDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek); }
        }
        public Pie GetPieById(int pieId)
        {
            return _applicationDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
