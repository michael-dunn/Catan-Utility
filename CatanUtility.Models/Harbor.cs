using CatanUtility.Models.Enums;

namespace CatanUtility.Models
{
    public class Harbor
    {
        public int Id { get; set; }
        public Edge Position { get; set; }
        public HarborType Type { get; set; }

        public Harbor() { }
    }
}
