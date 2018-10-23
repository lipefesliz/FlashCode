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

            CreateMap<Produto, ProdutoDetailViewModel>()
                .ForMember(x => x.ValorUnitario, opt => opt.MapFrom(src => src.ValorProduto.Unitario))
                .ForMember(x => x.ValorTotal, opt => opt.MapFrom(src => src.ValorProduto.Total))
                .ForMember(x => x.ICMS, opt => opt.MapFrom(src => src.ValorProduto.ICMS))
                .ForMember(x => x.IPI, opt => opt.MapFrom(src => src.ValorProduto.Ipi));

            CreateMap<ProdutoRegistrarCommand, Produto>()
                .ForPath(x => x.ValorProduto.Unitario, opt => opt.MapFrom(src => src.Valor)); ;

            CreateMap<ProdutoEditarCommand, Produto>();
        }
    }
}
