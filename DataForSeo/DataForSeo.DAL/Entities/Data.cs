namespace DataForSeo.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Data
    {
        public int Id { get; set; }
        [Required]
        public string TaskId { get; set; }
        [Required]
        public string KeyWord { get; set; }
        [Required]
        public string SearchEngine { get; set; }
        [Required]
        public string WebSite { get; set; }
        [Required]
        public int Position { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
