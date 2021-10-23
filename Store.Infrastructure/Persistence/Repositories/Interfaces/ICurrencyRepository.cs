using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<T>> GetAvailableCurrencies<T>();
    }
}
