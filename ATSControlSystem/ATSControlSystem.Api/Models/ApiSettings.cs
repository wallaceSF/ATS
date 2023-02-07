namespace ATSControlSystem.Api.Models;

public class ApiSettings
{
    public MongoSettings MongoSettings { get; set; }
    public SeqSettings SeqSettings { get; set; }
}

public class MongoSettings
{
    public string CollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}

public class SeqSettings
{
    public string Url { get; set; }
}