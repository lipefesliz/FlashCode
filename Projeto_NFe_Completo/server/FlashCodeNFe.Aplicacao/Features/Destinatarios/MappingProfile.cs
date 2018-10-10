using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Destinatarios.Commands;
using FlashCodeNFe.Aplicacao.Features.Destinatarios.ViewModels;
using FlashCodeNFe.Dominio.Features.Destinatarios;

namespace FlashCodeNFe.Aplicacao.Features.Destinatarios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Destinatario, DestinatarioResource>()
               .ForMember(d => d.Cpf, o => o.MapFrom(s => s.Cpf))
               .ForMember(d => d.Cnpj, o => o.MapFrom(s => s.Cnpj));

            CreateMap<Destinatario, DestinatarioViewModel>()
                 .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Municipio));

            CreateMap<DestinatarioRegistrarCommand, Destinatario>();

            CreateMap<DestinatarioEditarCommand, Destinatario>();
        }
    }
}
