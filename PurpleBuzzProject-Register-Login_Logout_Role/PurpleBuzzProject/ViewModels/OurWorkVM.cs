using PurpleBuzzProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PurpleBuzzProject.ViewModels
{
    public class OurWorkVM
    {
        [DisallowNull]
        [MinLength(3)]
        public string Title { get; set; }
        public string Description { get; set; }
        [AllowNull]
        public string ImgUrl { get; set; }
        public int OurServiceId { get; set; }
    }
}
