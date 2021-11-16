using Shared.Dominio.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBL_Producto
    {
        ProductoDto AddProducto(AgregarProductoDto x);
        IEnumerable<ProductoDto> GetProductos();
        ProductoDto GetProducto(Guid id);
        void PutProducto(ProductoDto x, Guid id);
        void DeleteProducto(Guid id);
    }
}
