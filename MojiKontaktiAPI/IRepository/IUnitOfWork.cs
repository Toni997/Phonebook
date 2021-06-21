using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Kontakt> Kontakti { get; }
        IGenericRepository<EmailAdresa> EmailAdrese { get; }
        IGenericRepository<BrojTelefona> BrojeviTelefona { get; }
        IGenericRepository<Tag> Tagovi { get; }

        Task Save();

    }
}
