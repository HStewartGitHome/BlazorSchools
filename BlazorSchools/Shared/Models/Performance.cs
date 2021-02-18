namespace BlazorSchools.Shared.Models
{
    public class Performance
    {
        public int Id { get; set; }
        public int InitPerformance { get; set; }
        public int JsonPerformance { get; set; }
        public int DapperPerformance { get; set; }
        public int EFPerformance { get; set; }
        public int SimPerformance { get; set; }
        public int JsonPerformance2 { get; set; }
        public int DapperPerformance2 { get; set; }
        public int EFPerformance2 { get; set; }
        public int SimPerformance2 { get; set; }
        public int DapperUpdatePerformance { get; set; }
        public int EFUpdatePerformance { get; set; }
        public int SimUpdatePerformance { get; set; }
        public int UseSIM { get; set; }
        public int UseDapper { get; set; }
        public int UseEF { get; set; }
        public int Records { get; set; }
        public int MaxPage { get; set; }
        public int AllowDapper { get; set; }
        public int AllowEF { get; set; }
    }


    public record PerformanceRecord(int Id, int InitPerformance, int JsonPerformance, int DapperPerformance, int EFPerformance,  int SimPerformance, int JsonPerformance2, int DapperPerformance2,
                                    int EFPerformance2, int SimPerformance2, int DapperUpdatePerformance, int EFUpdatePerformance, int SimUpdatePerformance,
                                    int UseSIM, int UseDapper, int UseEF, int Records, int MaxPage, int AllowDapper, int AllowEF );

}