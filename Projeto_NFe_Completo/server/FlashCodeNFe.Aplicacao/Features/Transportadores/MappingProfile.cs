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
            CreateMap<Transportador, TransportadorResource>();

            CreateMap<Transportador, TransportadorViewModel>()
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Municipio));

            CreateMap<TransportadorRegistrarCommand, Transportador>();
            CreateMap<TransportadorEditarCommand, Transportador>();
        }
    }
}
