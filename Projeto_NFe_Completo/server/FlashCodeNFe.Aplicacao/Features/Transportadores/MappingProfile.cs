using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Transportadores.Commands;
using FlashCodeNFe.Aplicacao.Features.Transportadores.ViewModels;
using FlashCodeNFe.Dominio.Features.Transportadores;

namespace FlashCodeNFe.Aplicacao.Features.Transportadores
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transportador, TransportadorViewModel>();
            CreateMap<TransportadorRegistrarCommand, Transportador>();
            CreateMap<TransportadorEditarCommand, Transportador>();
        }
    }
}
