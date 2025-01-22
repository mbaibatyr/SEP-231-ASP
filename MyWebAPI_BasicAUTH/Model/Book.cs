namespace MyWebAPI_BasicAUTH.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }


    public class AuthorMain
    {
        public string Author { get; set; }
        public Book2[] Books { get; set; }
    }

    public class Book2
    {
        public string Name { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}
