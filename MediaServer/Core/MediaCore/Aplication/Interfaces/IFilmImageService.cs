using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCore.Aplication.Interfaces
{
    public interface IFilmImageService
    {
        Task<int> SaveImages(int filmId, List<IFormFile> files);
    }
}
