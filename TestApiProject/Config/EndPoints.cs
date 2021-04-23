namespace TestApiProject.Config
{
    public class EndPoints
    {
        public static EndPoints PostCode = new EndPoints
                                         {
                                             Scheme = "http",
                                             Host = "api.zippopotam.us/"
                                         };
        public string Host { get; set; }
        public string Scheme { get; set; }

        public string GetUrl()
        {
            return $"{Scheme}://{Host}/";
        }
    }
}
