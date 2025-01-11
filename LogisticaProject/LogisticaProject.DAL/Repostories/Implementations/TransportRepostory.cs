using LogisticaProject.Core.Entities;
using LogisticaProject.DAL.Contexts;
using LogisticaProject.DAL.Repostories.Abstractions;

namespace LogisticaProject.DAL.Repostories.Implementations
{
    public class TransportRepostory: GenericRepostory<Transport>, ITransportRepostory
    {
        public TransportRepostory(AppDbContext context) : base(context)
        {

        }
    }
}
