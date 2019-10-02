using OpenLab.DAL.EF.Contexts;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Services.Factories;
using OpenLab.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Services
{
    public interface IBackofficeService
    {

    }

    public class BackofficeService : IBackofficeService
    {
        private readonly OpenLabDbContext _context;
        private readonly IBackofficeRepository _backofficeRepository;

        public BackofficeService(OpenLabDbContext context)
        {
            _context = context;
            _backofficeRepository = new BackofficeRepository(_context);
        }
    }
}
