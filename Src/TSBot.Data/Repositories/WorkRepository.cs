using System.Threading.Tasks;
using TSBot.Data.Repositories.Abstract;
using TSBot.Data.Entity;

namespace TSBot.Data.Repositories
{
    class WorkRepository : Repository<WorkEntity>, IWorkRepository
    {
        public WorkRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
        public override Task<long> GetId(WorkEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
