namespace Catmash.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public Cat FirstCat { get; set; }
        
        public Cat SecondCat { get; set; }

        public Cat Winner { get; set; }

        public User User { get; set; }
    }
}
