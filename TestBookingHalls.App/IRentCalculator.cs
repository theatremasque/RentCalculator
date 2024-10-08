namespace TestBookingHalls.App;

public interface IRentCalculator
{
    decimal Calculate(int baseCost, TimeSpan start, TimeSpan end);
}