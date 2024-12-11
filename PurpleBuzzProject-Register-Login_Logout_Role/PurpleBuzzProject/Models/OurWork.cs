using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PurpleBuzzProject.Models
{
    public class OurWork: BaseAuditableEntity
    {
      
        [DisallowNull]
        [MinLength(3)]
        public string Title { get; set; }
        public string Description { get; set; }
        [AllowNull]
        public string ImgUrl { get; set; }
        public int OurServiceId { get; set; }
        public OurService OurService { get; set; }
       
    }
}