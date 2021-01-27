namespace BlazorSchools.Shared.Models
{
    public class Schools
    {
        public int Id { get; set; }

#pragma warning disable IDE1006 // Naming Styles
        public SchoolItem[] schools { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        public int CurrentIndex { get; set; }

        public int MaxIndex { get; set; }

        public int MaxPage { get; set; }
    }
}