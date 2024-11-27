namespace PurpleBuzzProject.Models
{
    public class OurService:BaseAuditableEntity
    {
       
        public string Description { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<OurWork>? OurWorks { get; set; }
    }
}
