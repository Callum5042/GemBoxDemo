namespace GemBoxDemo.Models
{
    public class RangesModel
    {
        public IList<MovieListModel> Movies { get; set; } = new List<MovieListModel>();
    }

    public class MovieListModel
    {
        public string? Title { get; set; }

        public DateTime? ReleaseYear { get; set; }
    }
}
