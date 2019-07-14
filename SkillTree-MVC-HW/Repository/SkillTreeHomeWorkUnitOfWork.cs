using System.Data.Entity;
using SkillTree_MVC_HW.Models.DataModel;

namespace SkillTree_MVC_HW.Repository
{
    public class SkillTreeHomeWorkUnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; set; }

        public SkillTreeHomeWorkUnitOfWork()
        {
            Context = new SkillTreeHomeworkEntities();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}