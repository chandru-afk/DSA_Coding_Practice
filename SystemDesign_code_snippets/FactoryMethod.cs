//In the Factory Method Pattern, the factory class is responsible for deciding which subclass instance to return. 

using System;

public interface IDatabaseConnection
{
    void Connect();
    
    void Disconnect();
}

public class MySql : IDatabaseConnection
{
    public void Connect()
    {
        Console.WriteLine("My Sql Connected");
    }
    public void Disconnect()
    {
        Console.WriteLine("My Sql Disconnected");
    }
}

public class SqlServer : IDatabaseConnection
{
     public void Connect()
    {
        Console.WriteLine("Sqlserver Connected");
    }
    public void Disconnect()
    {
        Console.WriteLine("Sqlserver Disconnected");
    }
}

public class DatabaseFactory
{
    public static IDatabaseConnection GetdatabaseConnection(string Dbtype)
    {
        if(Dbtype.Equals("Mysql"))
        {
            return new MySql();
        }
        else if(Dbtype.Equals("SqlServer"))
        {
            return new SqlServer();
        }
        else
        {
             throw new ArgumentException("Invalid database type.");
        }
    }
}

class Program
{
    static void Main()
    {
        IDatabaseConnection Dbconnection = DatabaseFactory.GetdatabaseConnection("Mysql");
        Dbconnection.Connect();
        Dbconnection.Disconnect();
        
    }
}

