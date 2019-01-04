using System.Collections.Generic;
using AspNetMvc.Services.Content.Slides.Dtos;
using AspNetMvc.Services.System.Settings.Dtos;
using AspNetMvc.Data.Enums;
using AspNetMvc.Services.Content.Footers.Dtos;

namespace AspNetMvc.Services.System.Commons
{
    public interface ICommonService 
    {
        FooterViewModel GetFooter();

        //List<SlideViewModel> GetSlides(SlideGroup groupAlias);

        //SystemConfigViewModel GetSystemConfig(string code);
    }
}