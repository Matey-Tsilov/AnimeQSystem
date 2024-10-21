namespace AniQu.Models.AnimeSystem
{
    public class Studio
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public DateTime DateFounded { get; set; }


    }
}
