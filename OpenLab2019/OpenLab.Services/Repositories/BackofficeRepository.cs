using OpenLab.DAL.EF.Contexts;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Services.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Repositories
{
    public class BackofficeRepository : IBackofficeRepository
    {
        private readonly OpenLabDbContext _context;
        private readonly IBackofficeFactory _backofficeFactory;

        public BackofficeRepository(OpenLabDbContext context)
        {
            _context = context;
            _backofficeFactory = new BackofficeFactory();
        }
    }
}
