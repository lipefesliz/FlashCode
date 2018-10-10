using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Produtos.Commands;
using FlashCodeNFe.Aplicacao.Features.Produtos.ViewModels;
using FlashCodeNFe.Dominio.Features.Produtos;

namespace FlashCodeNFe.Aplicacao.Features.Produtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(x => x.Valor, opt => opt.MapFrom(src => src.ValorProduto.Unitario));
            
            CreateMap<ProdutoRegistrarCommand, Produto>();

            CreateMap<ProdutoEditarCommand, Produto>()
                .ForPath(x => x.ValorProduto.Unitario, opt => opt.MapFrom(src => src.Valor));
        }
    }
}
