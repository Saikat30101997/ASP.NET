using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
