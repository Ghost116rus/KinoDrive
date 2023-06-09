﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaCore.Aplication.Interfaces
{
    public interface IFilmImageService
    {
        Task<int> SavePoster(int filmId, IFormFile file, CancellationToken cancellationToken);
        Task<int> SaveImages(int filmId, List<IFormFile> files, CancellationToken cancellationToken);
    }
}
