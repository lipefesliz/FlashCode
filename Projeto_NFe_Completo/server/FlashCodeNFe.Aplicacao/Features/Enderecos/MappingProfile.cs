using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Enderecos.Commands;
using FlashCodeNFe.Aplicacao.Features.Enderecos.ViewModels;
using FlashCodeNFe.Dominio.Features.Enderecos;

namespace FlashCodeNFe.Aplicacao.Features.Enderecos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<EnderecoRegistrarCommand, Endereco>();
            CreateMap<EnderecoEditarCommand, Endereco>();
        }
    }
}
