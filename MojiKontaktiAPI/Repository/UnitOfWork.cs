using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MojiKontaktiAPI.IRepository;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MojiKontaktiDbContext _context;
        private IGenericRepository<Kontakt> _kontakti;
        private IGenericRepository<EmailAdresa> _emailAdrese;
        private IGenericRepository<BrojTelefona> _brojeviTelefona;
        private IGenericRepository<Tag> _tagovi;
        public UnitOfWork(MojiKontaktiDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Kontakt> Kontakti => _kontakti ??= new GenericRepository<Kontakt>(_context);
        public IGenericRepository<EmailAdresa> EmailAdrese => _emailAdrese ??= new GenericRepository<EmailAdresa>(_context);
        public IGenericRepository<BrojTelefona> BrojeviTelefona => _brojeviTelefona ??= new GenericRepository<BrojTelefona>(_context);
        public IGenericRepository<Tag> Tagovi => _tagovi ??= new GenericRepository<Tag>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
