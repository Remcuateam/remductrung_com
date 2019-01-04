using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetMvc.Services.Content.Feedbacks.Dtos;
using AspNetMvc.Services.Content.Feedbacks;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.Feedbacks
{
    public class FeedbackService : WebServiceBase<Feedback, int, FeedbackViewModel>, IFeedbackService
    {
        private readonly IRepository<Feedback, int> _feedbackRepository;

        public FeedbackService(IRepository<Feedback, int> feedbackRepository,
            IUnitOfWork unitOfWork) : base(feedbackRepository, unitOfWork)
        {
            _feedbackRepository = feedbackRepository;
        }

        public override void Add(FeedbackViewModel feedbackVm)
        {
            var feedback = Mapper.Map<FeedbackViewModel, Feedback>(feedbackVm);
            _feedbackRepository.Add(feedback);
        }
        public override void Update(FeedbackViewModel feedbackVm)
        {
            var feedback = Mapper.Map<FeedbackViewModel, Feedback>(feedbackVm);
            _feedbackRepository.Update(feedback);
        }

        public override void Delete(int id)
        {
            _feedbackRepository.Remove(id);
        }

        public override FeedbackViewModel GetById(int id)
        {
            return Mapper.Map<Feedback, FeedbackViewModel>(_feedbackRepository.GetById(id));
        }

        public override List<FeedbackViewModel> GetAll()
        {
            return _feedbackRepository.GetAll().OrderBy(x => x.CreatedDate).ProjectTo<FeedbackViewModel>().ToList();
        }

        public PagedResult<FeedbackViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _feedbackRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<FeedbackViewModel>()
            {
                Results = data.ProjectTo<FeedbackViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

    }
}