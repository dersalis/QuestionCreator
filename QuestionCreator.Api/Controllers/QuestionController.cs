using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionCreator.Api.ViewModels;
using System.Linq;

namespace QuestionCreator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController: Controller
    {
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var questions = new List<QuestionViewModel>();

            questions.Add(
                new QuestionViewModel()
                {
                    Id = 1,
                    QuizId = quizId,
                    Text = "Co cenisz w swoim życiu najbardziej?",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            );

            for(int i = 2; i <= 5; i++)
            {
                questions.Add(
                    new QuestionViewModel()
                    {
                        Id = i,
                        QuizId = quizId,
                        Text = $"Przykładowe pytanie {i}",
                        CreatedDate = DateTime.Now.AddDays(-i),
                        LastModifiedDate = DateTime.Now
                    }
                );
            }

            return new JsonResult(questions, new JsonSerializerSettings(){Formatting = Formatting.Indented});
        }
    }
}

