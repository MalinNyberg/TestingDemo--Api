namespace TestingRepApiDemo.Models
{
    public class DogPicture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

        public virtual Tag Tags { get; set; }
    }
}
