public sealed class Car
{
    private static Car _car;
    private static readonly Object _lock = new Object();
    
    private Car()
    {}
    
    public static Car Instance
    {
        get
        {
            if(_car == null)
            {
                lock(_lock)
                {
                    if(_car == null)
                    {
                        _car= new Car();
                    }
                }
            }
            return _car;
        }
    }
}

public sealed class Car
{
    private static readonly Car _car = new Car();
    
    private Car()
    {}
    
    public static Car Instance
    {
        get
        {
            return _car;
        }
    }
    
}



public class ConfigurationManager
{
	private static ConfigurationManager _config;
	private static readonly Object _lock = new Object();
	private readonly Dictionary<string,string> _setting = new Dictionary<string,string>();
	
	private ConfigurationManager(){}
	
	public static ConfigurationManager Instance
	{
		get
		{
			if(_config == null)
			{
				lock(_lock)
				{
					if(_config == null)
					{
						_config = new ConfigurationManager();
					}
				}
			}
			return _config;
		}
	}
	
	public void SetSetting(string key,string value)
	{	
		lock(_lock)
		{	
			_setting[key]= value;
		}
	}
	public string GetSetting(string key)
    {
        return _settings.TryGetValue(key, out string value) ? value : null;
    }
}
public class program
{
	static void Main()
	{	
		ConfigurationManager.Instance.SetSetting("Key","wkfjbwekfbweyjk");
		string apikey = ConfigurationManager.Instance.GetSetting("key");
		Console.WriteLine($"Key: {apikey}");
	}
}

DatabaseConnection
FileHandling in Logging
					
				





























