using System;
using System.Collections.Generic;
using AspNetMvc.Services.Content.Feedbacks.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.Feedbacks
{
    public interface IFeedbackService : IWebServiceBase<Feedback, int, FeedbackViewModel>
    {
        //void Add(FeedbackViewModel feedbackVm);
        //void Update(FeedbackViewModel feedbackVm);    
        //void Delete(int id);
        //FeedbackViewModel GetById(int id);
        //List<FeedbackViewModel> GetAll();  
        PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize);
     }
}