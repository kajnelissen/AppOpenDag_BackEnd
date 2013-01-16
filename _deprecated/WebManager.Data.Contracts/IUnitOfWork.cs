using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebManager.Data.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        void Commit();
    }
}
