using System;
using System.Collections.Generic;

// Observer interface
public interface IObserver
{
    void Update();
}

// Subject interface
public interface StocksObservable
{
    void Add(IObserver observer);
    void Remove(IObserver observer);
    void Notify();
    void SetStockcount(int stockcount);
    int GetStockcount();
}

// Concrete Subject
public class IphoneStock : StocksObservable
{
    private List<IObserver> _observers = new List<IObserver>();
    private int stockcount=0;

    public void Add(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Remove(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
    public void SetStockcount(int newStockAdded)
    {
        if(stockcount==0)
            Notify();
        stockcount+=newStockAdded;
    }
    public int GetStockcount()
    {
        return stockcount;
    }
}
public class EmailAlert : IObserver
{
    string _email;
    public EmailAlert(string email)
    {
        _email=email;
    }
    public void Update()
    {
        Console.WriteLine($"Email Sent to {_email}");
        
    }
}
public class HelloWorld
{
    public static void Main()
    {
        StocksObservable iphoneStock = new IphoneStock();

        IObserver emailObserver = new EmailAlert("user@example.com");
        iphoneStock.Add(emailObserver);
         // Initial stock = 0 (so notify will be triggered on adding new stock)
        iphoneStock.SetStockcount(10); // Notify observers

        // Both get updated again
    }
}



// WEATHER STATION


public Interface IObserver
{
	void update(float temp);
}
public interface IObservable
{
	void Add(IObserver obj);
	void Remove(IObserver obj);
	void Notify();
}
public class WeatherData : IObservable
{
	private List<IObserver> lst = new List<IObserver>();
	private foat Temp;
	public setTemp(float temp)
	{
		Temp= temp;
		Notify();
	}
	public void Add(IObserver obj)
	{
		lst.Add(obj);
	}
	public void Remove(IObserver obj)
	{
		lst.Remove(obj);
	}
	public Notify()
	{
		foreach(var obj in lst)
		{
			obj.Update(Temp);
		}
	}
}