using System.Collections.Generic;
using System.Linq;
using Forum.Domain.Models.Answers;
using Forum.Presentation.Contracts.Query;
using Framework.Core;

namespace Forum.Presentation.Query.Mppers
{
    public static class AnswerMapper
    {
        public static List<AnswerDto> MapAnswers(IList<Answer> answers)
        {
            return answers.Select(MapAnswer).ToList();
        }

        public static AnswerDto MapAnswer(Answer answer)
        {
            return new AnswerDto
            {
                Id = answer.Id.DbId,
                Body = answer.Body,
                IsChosen = answer.IsChosen,
                Responder = "روح الله خوشدل",
                CreationDateTime = DatetimeConvertor.ConvertToPersianDate(answer.CreationDateTime)
            };
        }
    }
}