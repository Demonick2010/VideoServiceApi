using System;
using System.Collections.Generic;
using System.Text;

namespace VideoService.Services.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
    }
}
