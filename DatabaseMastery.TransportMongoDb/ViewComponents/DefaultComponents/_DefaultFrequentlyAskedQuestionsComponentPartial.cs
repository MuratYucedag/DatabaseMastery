using DatabaseMastery.TransportMongoDb.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMastery.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultFrequentlyAskedQuestionsComponentPartial:ViewComponent
    {
        private readonly IQuestionService _QuestionService;
        public _DefaultFrequentlyAskedQuestionsComponentPartial(IQuestionService QuestionService)
        {
            _QuestionService = QuestionService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _QuestionService.GetAllQuestionAsync();
            return View(values);
        }
    }
}
