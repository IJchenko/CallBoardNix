namespace CallBoardNix.Models.Advert
{
    public class ResumeViewModel
    {
        public Guid IdResume { get; set; }
        public string? Description { get; set; }
        public string? Login { get; set; }
        public Guid IdAdvert { get; set; }
        public AdvertView? Advert { get; set; }
    }
}
