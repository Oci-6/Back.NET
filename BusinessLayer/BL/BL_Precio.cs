using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Precio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Precio : IBL_Precio
    {
        private readonly IRepositorio<Precio> repositorio;
        private readonly IRepositorio<Producto> repositorio2;
        private readonly IMapper mapper;

        public BL_Precio(IRepositorio<Precio> _repositorio, IRepositorio<Producto> _repositorio2, IMapper _mapper)
        {
            repositorio = _repositorio;
            repositorio2 = _repositorio2;
            mapper = _mapper;
        }


        public PrecioDto AddPrecio(AgregarPrecioDto x)
        {
            
            var precio = mapper.Map<Precio>(x);
            precio.Id = Guid.NewGuid();
            precio.Fecha_Validez =  DateTime.Parse(x.Fecha_Validez);

            repositorio.Insert(precio);

            return mapper.Map<PrecioDto>(precio);
        }

        public void DeletePrecio(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public PrecioDto GetPrecio(Guid id)
        {
            var precio = repositorio.Get(id);
            if (precio != null)
            {
                return mapper.Map<PrecioDto>(precio);
            }
            return null;
        }

        public IEnumerable<PrecioDto> GetPrecios(Guid IdProducto)
        {
            return mapper.Map<IEnumerable<PrecioDto>>(repositorio.GetAll().Where(element => element.ProductoId == IdProducto));
        }

        public void PutPrecio(PrecioDto x, Guid id)
        {
            var precio = repositorio.Get(id);
            precio.Monto = x.Monto;
            precio.Fecha_Validez = x.Fecha_Validez;

            repositorio.Update(precio);
        }
    }
}
