using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetMvc.Services.Content.Tags;

namespace AspNetMvc.Services.Content.Posts.Dtos
{
    public class PostTagViewModel
    {  
        public int PostId { set; get; }

        public string TagId { set; get; }

        public PostViewModel Post { set; get; }

        public TagViewModel Tag { set; get; }
    }
}