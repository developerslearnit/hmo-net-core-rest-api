using AvonHMO.Domain.Interfaces.Avon;
using AvonHMO.Domain.Interfaces.Toshfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvonHMO.Domain.Interfaces
{
    public interface IRepositoryManager
    {
        IToshfaRepository Toshfa { get; }

        IAuthenticationRepository AvonAuth { get; }

        IAvonRepository Avon { get; }

        ISettings Settings { get; }

        IPostRepository Posts { get; }

        IPlanRepository Plans { get; }

        IEnrolleeRepository Enrollee { get; }

    }
}
