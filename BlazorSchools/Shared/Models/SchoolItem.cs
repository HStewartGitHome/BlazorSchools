namespace BlazorSchools.Shared.Models
{
    public class SchoolItem
    {
        public int Id { get; set; }

#pragma warning disable IDE1006 // Naming Styles  because of jsom depenedencies
        public string name { get; set; }


        public string street { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
