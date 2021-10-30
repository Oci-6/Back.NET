using AutoMapper;
using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Roles 
    {
        Task<IdentityResult> AddRol(UsuarioDto x, string rol);
        Task<IEnumerable<UsuarioDto>> GetUsuariosEnRol(string x);

    }
}
