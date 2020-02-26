using System;
using System.Collections.Generic;
using System.Linq;

namespace CrowdCat.TechnicalTest.Domain
{
    public class Question
    {
        public Question(CreateQuestionDto createQuestionDto)
        {
            if (createQuestionDto == null)
            {
                throw new ArgumentNullException(nameof(createQuestionDto));
            }

            Tags = createQuestionDto.Tags?.ToList() ?? new List<string>();
            ViewTotal = createQuestionDto.ViewTotal;
        }

        public IEnumerable<string> Tags { get; protected set; }
        public int ViewTotal { get; protected set; }
    }
}