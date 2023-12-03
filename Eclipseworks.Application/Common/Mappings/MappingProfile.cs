using AutoMapper;

using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Security;
using Eclipseworks.Domain.Entities;
using Eclipseworks.Application.DTOs.Projeto.Queries;
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


            #endregion


            #region TarefaHistorico


            #endregion

        }
    }
}
