using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Emitentes.Commands;
using FlashCodeNFe.Aplicacao.Features.Emitentes.ViewModels;
using FlashCodeNFe.Dominio.Features.Emitentes;

namespace FlashCodeNFe.Aplicacao.Features.Emitentes
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Emitente, EmitenteResource>()
                .ForMember(d => d.Cpf, o => o.MapFrom(s => s.Cpf))
                .ForMember(d => d.Cnpj, o => o.MapFrom(s => s.Cnpj));

            CreateMap<Emitente, EmitenteViewModel>()
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Municipio));

            CreateMap<EmitenteRegistrarCommand, Emitente>();

            CreateMap<EmitenteEditarCommand, Emitente>();
        }
    }
}
