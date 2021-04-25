namespace TestApiProject.Tests.Config
{
    public class EndPoints
    {
        public static EndPoints PostCode = new()
                                           {
                                               Scheme = "http",
                                               Host = "api.zippopotam.us"
                                           };

        public string Host { get; set; }
        public string Scheme { get; set; }

        public string GetUrl()
        {
            return $"{Scheme}://{Host}/";
        }
    }
}