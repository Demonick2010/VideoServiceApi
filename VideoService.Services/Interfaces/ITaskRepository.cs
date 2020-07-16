using System;
using System.Collections.Generic;
using System.Text;
using VideoService.Models.Models;

namespace VideoService.Services.Interfaces
{
    public interface ITaskRepository : IGenericRepository<VideoModel>
    {
    }
}
