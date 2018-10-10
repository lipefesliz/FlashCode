﻿using AutoMapper;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.Commands;
using FlashCodeNFe.Aplicacao.Features.Notas_Fiscais.ViewModels;
using FlashCodeNFe.Dominio.Features.Notas_Fiscais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCodeNFe.Aplicacao.Features.Notas_Fiscais
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotaFiscal, NotaFiscalViewModel>()
                .ForMember(dest => dest.TotalNota, opt => opt.MapFrom(src => src.Valor.TotalNota))
                .ForMember(dest => dest.NomeDestinatario, opt => opt.MapFrom(src => src.Destinatario.Nome))
                .ForMember(dest => dest.NomeEmitente, opt => opt.MapFrom(src => src.Emitente.Nome))
                .ForMember(dest => dest.NomeTransportador, opt => opt.MapFrom(src => src.Transportador.Nome));

            CreateMap<NotaFiscalRegistroCommand, NotaFiscal>();

            CreateMap<NotaFiscalEditarCommand, NotaFiscal>();
        }
    }
}
