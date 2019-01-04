using System;
using System.Collections.Generic;
using AspNetMvc.Services.Content.Posts.Dtos;
using AspNetMvc.Services.Content.Tags;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Utilities.Dtos;


namespace AspNetMvc.Services.Content.Posts
{
    public interface IPostService : IWebServiceBase<Post, int, PostViewModel>
    {    
        PagedResult<PostViewModel> GetAllPaging(int categoryId, string keyword, int page, int pageSize, string sortBy);
        List<PostViewModel> GetListPostByCategoryIdPaging(int categoryId, int page, int pageSize, string sort, out int totalRow);
        List<PostViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow);
        List<PostViewModel> GetListPostByTag(string tagId, int page, int pagesize, out int totalRow);
        //PagedResult<PostViewModel> GetMyWishlist(Guid userId, int page, int pageSize);
        List<PostViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);
        List<PostViewModel> GetListPost(string keyword);
        List<string> GetListPostByName(string name);
        List<PostViewModel> GetLastest(int top);
        List<PostViewModel> GetHotPost(int top);
        List<PostViewModel> GetRelatedPosts(int id, int top);
        void IncreaseView(int id);
        //List<TagViewModel> GetListTagByPostId(int id);
        List<TagViewModel> GetListPostTag(string searchText);
        TagViewModel GetTag(string tagId);
        //
        //void Add(PostViewModel postVm);
        //void Update(PostViewModel postVm);
        //void Delete(int id);
        //PostViewModel GetById(int id);
        //List<PostViewModel> GetAll();
        //PagedResult<PostViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
        //void ImportExcel(string filePath, int categoryId);
        //void AddImages(int postId, string[] images);
        //List<PostViewModel> GetImages(int postId);
        //PagedResult<PostViewModel> GetAllPaging(string keyword, int pageSize, int page = 1);
    }
}