using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetMvc.Services.Content.Contacts.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Infrastructure.Interfaces;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.Contacts
{
    public class ContactService : WebServiceBase<Contact, string, ContactViewModel>, IContactService
    {
        private readonly IRepository<Contact, string> _contactRepository;
       
        public ContactService(IRepository<Contact, string> contactRepository,
            IUnitOfWork unitOfWork) : base(contactRepository, unitOfWork)
        {
            _contactRepository = contactRepository;          
        }

        public override void Add(ContactViewModel contactVm)
        {
            var contact = Mapper.Map<ContactViewModel, Contact>(contactVm);
            _contactRepository.Add(contact);
        }
        public override void Update(ContactViewModel contactVm)
        {
            var contact = Mapper.Map<ContactViewModel, Contact>(contactVm);
            _contactRepository.Update(contact);
        }

        public override void Delete(string id)
        {
            _contactRepository.Remove(id);
        }

        public override ContactViewModel GetById(string id)
        {
            return Mapper.Map<Contact, ContactViewModel>(_contactRepository.GetById(id));
        }

        public override List<ContactViewModel> GetAll()
        {
            return _contactRepository.GetAll().OrderBy(x=>x.Id).ProjectTo<ContactViewModel>().ToList();
        }

        public PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _contactRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<ContactViewModel>()
            {
                Results = data.ProjectTo<ContactViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }              
    }
}