using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epic_Restaurant_Food_Orders.Infastructure
{
    public interface IServiceGateway<T>
    {
        T Get(int id);
    }
}
