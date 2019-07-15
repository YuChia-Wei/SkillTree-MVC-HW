using System;
using System.Data.Entity;

namespace SkillTree_MVC_HW.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// context
        /// </summary>
        DbContext Context { get; set; }

        /// <summary>
        /// save change
        /// </summary>
        void Commit();
    }
}