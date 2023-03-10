using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Business.Intefaces;
using ToDo.Business.Models;
using ToDo.Data.Context;

namespace ToDo.Data.Repository
{
    public class DificuldadeRepository : Repository<Dificuldade>, IDificuldadeRepository
    {
        public DificuldadeRepository(MeuDbContext context) : base(context) { }
    }
}