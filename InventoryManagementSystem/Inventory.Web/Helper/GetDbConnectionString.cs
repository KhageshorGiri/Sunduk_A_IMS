namespace Inventory.Web.Helper
{
    public static class GetDbConnectionString
    {
        public static IConfigurationRoot ReadDbConnectionString()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}
