using Application.Features.Questions.Commands.CreateQuestionCommand;
using Application.Features.Questions.Commands.UpdateQuestionCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.DTOs;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {

        #region Dtos
        //CreateMap<Question, QuestionDto>();
        #endregion

        #region Commands
        CreateMap<CreateQuestionCommand, Question>();
        CreateMap<UpdateQuestionCommand, Question>();
        #endregion
    }
}
