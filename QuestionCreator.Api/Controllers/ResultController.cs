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
    public class ResultController: Controller
    {
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var sampleResults = new List<ResultViewModel>();
            
            sampleResults.Add(new ResultViewModel()
            {
                Id = 1,
                QuizId = quizId,
                Text = "Co cenisz w swoim życiu najbardziej?",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            for(int i = 2; i <= 5; i++)
            {
                sampleResults.Add(new ResultViewModel()
                {
                    Id = i,
                    QuizId = quizId,
                    Text = $"Co cenisz w swoim życiu najbardziej {i}?",
                    CreatedDate = DateTime.Now.AddDays(-3),
                    LastModifiedDate = DateTime.Now
                });
            }

            return new JsonResult(sampleResults, new JsonSerializerSettings(){Formatting = Formatting.Indented});
        }
    }
}