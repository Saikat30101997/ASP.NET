using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForEntityFrameWork.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
