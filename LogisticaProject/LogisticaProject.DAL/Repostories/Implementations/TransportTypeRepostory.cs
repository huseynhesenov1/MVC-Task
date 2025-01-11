using LogisticaProject.Core.Entities;
using LogisticaProject.DAL.Contexts;
using LogisticaProject.DAL.Repostories.Abstractions;

namespace LogisticaProject.DAL.Repostories.Implementations
{
    public class TransportTypeRepostory: GenericRepostory<TransportType>,ITransportTypeRepostory
    {
        public TransportTypeRepostory(AppDbContext context) : base(context)
        {

        }
    }
}
