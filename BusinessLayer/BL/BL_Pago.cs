using AutoMapper;
using DataAccessLayer.Entidades;
using DataAccessLayer.Repositorios;
using Shared.Dominio.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BL
{
    public class BL_Pago : IBL_Pago
    {
        private readonly IRepositorio<Pago> repositorio;
        private readonly IMapper mapper;

        public BL_Pago(IRepositorio<Pago> _repositorio, IMapper _mapper)
        {
            repositorio = _repositorio;
            mapper = _mapper;
        }
        public PagoDto AddPago(AgregarPagoDto x)
        {
            var pago = mapper.Map<Pago>(x);
            pago.Id = Guid.NewGuid();

            repositorio.Insert(pago);

            return mapper.Map<PagoDto>(pago);
        }

        public void DeletePago(Guid id)
        {
            repositorio.Delete(repositorio.Get(id));
        }

        public PagoDto GetPago(Guid id)
        {
            var pago = repositorio.Get(id);
            if (pago != null)
            {
                return mapper.Map<PagoDto>(pago);
            }
            return null;
        }

        public IEnumerable<PagoDto> GetPagoFactura(Guid idFactura)
        {
            return mapper.Map<IEnumerable<PagoDto>>(repositorio.GetAll().Where(element => element.FacturaId == idFactura));
        }

        public void PutPago(PagoDto x, Guid id)
        {
            var pago = repositorio.Get(id);
            pago.Monto = x.Monto;
    
            repositorio.Update(pago);
        }
    }
}
