using System.Collections.Generic;
using AspNetMvc.Services.Content.Contacts.Dtos;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Utilities.Dtos;

namespace AspNetMvc.Services.Content.Contacts
{
    public interface IContactService : IWebServiceBase<Contact, string, ContactViewModel>
    {
        //void Add(ContactViewModel contactVm);
        //void Update(ContactViewModel contactVm);    
        //void Delete(int id);
        //ContactViewModel GetById(int id);
        //List<ContactViewModel> GetAll();  
        PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);
    }
}