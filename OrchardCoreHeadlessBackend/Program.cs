namespace OrchardCoreHeadlessBackend
{
    public static class Program
    {
        private static IHost? _webHost;
        
        public static void Main(string[] args)
        {
            _webHost = CreateHostBuilder(args).Build();
            _webHost.Run();
        }
        
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}