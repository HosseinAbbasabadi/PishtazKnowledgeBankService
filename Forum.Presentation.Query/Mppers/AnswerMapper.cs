using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Domin.Contracts.Services;
using Forum.Presentation.Contracts.Query;
using Framework.Core;

namespace Forum.Presentation.Query.Mppers
{
    public class AnswerMapper
    {
        private readonly IUserService _userService;

        public AnswerMapper(IUserService userService)
        {
            _userService = userService;
        }

        public List<AnswerDto> MapAnswers(IList<Answer> answers)
        {
            return answers.Select(MapAnswer).ToList();
        }

        public AnswerDto MapAnswer(Answer answer)
        {
            return new AnswerDto
            {
                Id = answer.Id.DbId,
                Body = answer.Body,
                IsChosen = answer.IsChosen,
                Responder = _userService.GetUserFullName(answer.Responder.DbId),
                ResponderId = answer.Responder.DbId,
                CreationDateTime = DatetimeConvertor.ConvertToPersianDate(answer.CreationDateTime)
            };
        }
    }
}