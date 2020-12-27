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
    public class QuizController: Controller
    {
        [HttpGet("Latest/{num:int?}")]
        public IActionResult Latest(int num = 10)
        {
            var samplesQuizzes = new List<QuizViewModel>();

            // Pierwszy przykładowy quiz
            samplesQuizzes.Add(
                new QuizViewModel()
                {
                    Id = 1,
                    Title = "Którą postacią z Shingeki No Kyojin (Atak tytanów) jesteś?",
                    Description = "Test osobowości bazujący na anime",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            );

            for(int i = 2; i <= num; i++)
            {
                samplesQuizzes.Add(
                    new QuizViewModel()
                    {
                        Id = i,
                        Title = $"Tytuł przykładowego quizu {i}.",
                        Description = $"Opis przykładowego opisu {i}.",
                        CreatedDate = DateTime.Now.AddDays(-2),
                        LastModifiedDate = DateTime.Now
                    }
                );
            }

            return new JsonResult(samplesQuizzes, new JsonSerializerSettings(){ Formatting = Formatting.Indented});
        }

        /// <summary>
        /// GET: api/quiz/ByTitle
        /// Pobiera {num} quizów posortowanych po tytule (od A do Z)
        /// </summary>
        /// <param name="num">Liczba quizów do pobrania</param>
        /// <returns>{num} quizów posortowanych po tytule</returns>
        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var samplesQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;
            var result = samplesQuizzes.OrderBy(q => q.Title);

            return new JsonResult(result, new JsonSerializerSettings(){ Formatting = Formatting.Indented});
        }


        /// <summary>
        /// GET: api/quiz/Random
        /// Pobiera {num} losowych quizów
        /// </summary>
        /// <param name="num">Liczba quizów do pobrania</param>
        /// <returns>{num} losowych quizów</returns>
        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            var samplesQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;
            var result = samplesQuizzes.OrderBy(q => q.Id);

            return new JsonResult(result, new JsonSerializerSettings{Formatting = Formatting.Indented});
        }
    }
}

