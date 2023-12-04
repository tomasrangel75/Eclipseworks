using AutoMapper;
using Eclipseworks.Application.DTOs.Projeto.Queries;
using Eclipseworks.Application.DTOs.Tarefa.Queries;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Shared;

namespace Eclipseworks.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Projeto

            CreateMap<Projeto, ProjetoResponseDto>()
               .ForMember(
                   dest => dest.Id,
                   options => options
                   .MapFrom(src => src.Id))
               .ForMember(
                   dest => dest.Descricao,
                   options => options
                   .MapFrom(
                           src => src.Descricao))
               .ForMember(
                   dest => dest.Status,
                   options => options
                   .MapFrom(
                           src => EnumHelper.GetEnumDescription(src.Status)))
               .ForMember(
                   dest => dest.DataCriacao,
                   options => options
                   .MapFrom(
                           src => src.DataCriacao))
               .ForMember(
                   dest => dest.DataAtualizacao,
                   options => options
                   .MapFrom(
                           src => src.DataAtualizacao));

            #endregion

            #region Tarefa

            CreateMap<Tarefa, TarefaResponseDto>()
               .ForMember(
                   dest => dest.Id,
                   options => options
                   .MapFrom(src => src.Id))
                .ForMember(
                   dest => dest.Titulo,
                   options => options
                   .MapFrom(
                           src => src.Titulo))
               .ForMember(
                   dest => dest.Descricao,
                   options => options
                   .MapFrom(
                           src => src.Descricao))
               .ForMember(
                   dest => dest.Status,
                   options => options
                   .MapFrom(
                           src => EnumHelper.GetEnumDescription(src.Status)))
                .ForMember(
                   dest => dest.Prioridade,
                   options => options
                   .MapFrom(
                           src => EnumHelper.GetEnumDescription(src.Prioridade)))
               .ForMember(
                   dest => dest.DataCriacao,
                   options => options
                   .MapFrom(
                           src => src.DataCriacao))
                .ForMember(
                   dest => dest.DataVencimento,
                   options => options
                   .MapFrom(
                           src => src.DataVencimento))
               .ForMember(
                   dest => dest.DataAtualizacao,
                   options => options
                   .MapFrom(
                           src => src.DataAtualizacao));

            #endregion

        }
    }
}
