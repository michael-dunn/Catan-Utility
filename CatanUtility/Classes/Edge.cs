namespace CatanUtility.Classes
{
    public class Edge
    {
        public bool Occupied { get; set; }
        public string Color { get; set; }
        public Edge()
        {
        }
        public override string ToString()
        {
            return (Color ?? "No") + " road";
        }
    }
}