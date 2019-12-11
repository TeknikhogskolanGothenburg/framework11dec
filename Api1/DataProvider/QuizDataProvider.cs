using Api1.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Api1.DataProvider
{
    class QuizDataProvider
    {
        public async Task<List<Category>> GetCategories()
        {
            string URL = "https://opentdb.com/api_category.php";
            List<Category> categoryList = new List<Category>();
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                if(response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CategoryRoot>(result.Result);
                    foreach(var cat in data.TriviaCategories)
                    {
                        categoryList.Add(cat);
                    }
                }
            }
            return categoryList;
        }

        public async Task<List<Question>> GetQuestions(int categoryId)
        {
            string URL = $"https://opentdb.com/api.php?amount=10000&category={categoryId}";
            List<Question> questionList = new List<Question>();
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<QuestionRoot>(result.Result);
                    foreach (var question in data.Questions)
                    {
                        question.TheQuestion = HttpUtility.HtmlDecode(question.TheQuestion);
                        question.CorrectAnswer = HttpUtility.HtmlDecode(question.CorrectAnswer);
                        for(int i = 0; i < question.IncorrectAnswers.Count; i++)
                        {
                            question.IncorrectAnswers[i] = HttpUtility.HtmlDecode(question.IncorrectAnswers[i]);
                        }
                        questionList.Add(question);
                    }
                }
            }
            return questionList;
        }
    }
}
