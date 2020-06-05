namespace BlazorSchools.Shared
{
    public class Schools
    {
        public int id { get; set; }

        public School[] schools { get; set; }

        public int CurrentIndex { get; set; }

        public int MaxIndex { get; set; }

        public int MaxPage { get; set; }
    }
}
