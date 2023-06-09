﻿using MediaCore.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaServer.WebAPI.Controllers
{
    [ApiController]
    [Route("api/MediaServer/filmImages/[action]")]
    public class FilmImageController : ControllerBase
    {
        IFilmImageService _filmImageService;

        public FilmImageController(IFilmImageService filmImageService)
        {
            _filmImageService = filmImageService;
        }

        [HttpPost]
        public async Task<IActionResult> SavePoster(int filmId, IFormFile file)
        {
            int count = await _filmImageService.SavePoster(filmId, file, new CancellationToken());

            return Created("Files", count);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMedia(int filmId, List<IFormFile> files)
        {
            int count = await _filmImageService.SaveImages(filmId, files, new CancellationToken());

            return Created("Files", count);
        }
    }
}
