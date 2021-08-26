using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
