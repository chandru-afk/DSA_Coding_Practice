using System;
public class Vehicle
{
    public void Drive()
    {
        
    }
}
public class OffroadVehicle : Vehicle
{
    public void Drive()
    {
        //same logic 
    }
}
public class OffroadsportVehicle : Vehicle
{
    public void Drive()
    {
        //same logic
    }
}


//To Avoid this repeated code we use Strategy Design Pattern

using System;

// Strategy interface
public interface IDriveStrategy
{
    void Drive();
}

// Concrete strategy
public class OffroadDriveStrategy : IDriveStrategy
{
    public void Drive()
    {
        Console.WriteLine("Driving off-road!");
    }
}

// Another concrete strategy
public class SportDriveStrategy : IDriveStrategy
{
    public void Drive()
    {
        Console.WriteLine("Driving sport style!");
    }
}

// Context base class
public class Vehicle
{
    protected IDriveStrategy _driveStrategy;

    public Vehicle(IDriveStrategy driveStrategy)
    {
        _driveStrategy = driveStrategy;
    }

    public void Drive()
    {
        _driveStrategy.Drive();
    }
}

public class Program
{
    public static void Main()
    {
        Vehicle v1 = new Vehicle(new OffroadDriveStrategy());
        Vehicle v2 = new Vehicle(new SportDriveStrategy());

        v1.Drive();  // Output: Driving off-road!
        v2.Drive();  // Output: Driving sport style!
    }
}
