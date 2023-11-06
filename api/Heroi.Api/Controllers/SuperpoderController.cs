﻿using Domain.Interfaces;
using Domain.Models;
using Heroi.Api.DTOs;
using Infrastructure.Configuracao;
using Microsoft.AspNetCore.Mvc;

namespace Heroi.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperpoderController : ControllerBase
    {
        private readonly ISuperpoder _interfaceSuperpoder;

        public SuperpoderController(ISuperpoder InterfaceSuperpoder, ContextDb ContextDb)
        {
            _interfaceSuperpoder = InterfaceSuperpoder;
        }

        [HttpGet]
        public async Task<object> ListaSuperpoderes()
        {
            return await _interfaceSuperpoder.ListarSuperpoderes();

        }

    }
}
