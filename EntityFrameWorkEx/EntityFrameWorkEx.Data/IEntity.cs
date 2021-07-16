using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkEx.Data
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
