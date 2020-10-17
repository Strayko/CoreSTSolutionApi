namespace CoreSTSolutionApi.Data.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public Blog Blog { get; set; }
    }
}