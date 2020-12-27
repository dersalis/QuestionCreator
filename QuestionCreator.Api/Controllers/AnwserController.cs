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
    public class AnswerController: Controller
    {
        [HttpGet("All/{questionId}")]
        public IActionResult All(int questionId)
        {
            var answers = new List<AnswerViewModel>();

            answers.Add(
                new AnswerViewModel()
                {
                    Id = 1,
                    QuestionId = questionId,
                    Text = "Przyjaciół i rodzinę",
                    CreatedDate = DateTime.Now.AddDays(-2),
                    LastModifiedDate = DateTime.Now,
                }
            );

            for(int i = 2; i <= 5; i++)
            {
                answers.Add(
                    new AnswerViewModel()
                    {
                        Id = i,
                        QuestionId = questionId,
                        Text = $"Przykładowa odpowiedź {i}.",
                        CreatedDate = DateTime.Now.AddDays(-2),
                        LastModifiedDate = DateTime.Now,
                    }
                );
            }

            return new JsonResult(answers, new JsonSerializerSettings(){Formatting = Formatting.Indented});
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Content("Jeszcze nie zaimplementowane!");
        }


        [HttpPut]
        public IActionResult Put(QuizViewModel model)
        {
            return Content("Jeszcze nie zaimplementowane!");
        }


        [HttpPost]
        public IActionResult Post(QuizViewModel model)
        {
            return Content("Jeszcze nie zaimplementowane!");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Content("Jeszcze nie zaimplementowane!");
        }
    }
}