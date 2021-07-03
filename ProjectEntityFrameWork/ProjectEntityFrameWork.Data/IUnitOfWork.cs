using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEntityFrameWork.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
