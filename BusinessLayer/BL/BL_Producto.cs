using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Producto : IBL_Producto
    {
        private readonly IRepositorioProducto repositorio;
        private readonly IMapper mapper;

        public BL_Producto(IRepositorioProducto _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }
        
        public ProductoDto AddProducto(AgregarProductoDto x)
        {

            var producto = new Producto() { Id = Guid.NewGuid(), Precios = new List<Precio>() };

            mapper.Map(x, producto);

            repositorio.Insert(producto);

            return mapper.Map<ProductoDto>(producto);
        }

        public void DeleteProducto(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public ProductoDto GetProducto(Guid id)
        {
            var producto = repositorio.Get(id);
            if (producto != null)
            {
                return mapper.Map<ProductoDto>(producto);
            }
            return null;
        }

        public IEnumerable<ProductoDto> GetProductos()
        {
            return mapper.Map<IEnumerable<ProductoDto>>(repositorio.GetAll().Select(producto=> {
                producto.Precios = producto.Precios.OrderByDescending(precio => precio.Fecha_Validez);
                return producto;
            }));
        }

        public void PutProducto(ProductoDto x, Guid id)
        {
            var producto = repositorio.Get(id);
            producto.Nombre = x.Nombre;
            producto.CantMaxEdificios = x.CantMaxEdificios;
            producto.CantMaxSalones = x.CantMaxSalones;

            repositorio.Update(producto);
        }
    }
}
