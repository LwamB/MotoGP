namespace MotoGP.Models.ViewModels
{
    public class ListTeamsRidersViewModel
    {
        public int teamID { get; set; }
        public List<Rider>? Riders { get; set; }
        public List<Team> Teams { get; set; }
    }
}
