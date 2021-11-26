using AutoMapper;
using DataAccessLayer.Entidades;
using Microsoft.AspNetCore.Identity;
using Shared.Dominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Roles 
    {
        Task<IdentityResult> AddRol(UsuarioCreateDto x, string rol);
        Task<IEnumerable<UsuarioDto>> GetUsuariosEnRol(string x);

    }
}
