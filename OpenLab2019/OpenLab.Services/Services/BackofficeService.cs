using OpenLab.DAL.EF.Contexts;
using OpenLab.Infrastructure.Interfaces.Repositories;
using OpenLab.Services.Factories;
using OpenLab.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Services.Services
{
#pragma warning disable CA1040 // Avoid empty interfaces
    public interface IBackofficeService
#pragma warning restore CA1040 // Avoid empty interfaces
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
