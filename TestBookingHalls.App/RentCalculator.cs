namespace TestBookingHalls.App;

public class RentCalculator : IRentCalculator
{
    private static readonly TimeSpan Strd9 = new(9, 0, 0);
    private static readonly TimeSpan Strd18 = new(18, 0, 0);
    private static readonly TimeSpan Mr6 = new(6, 0, 0);
    private static readonly TimeSpan Pk12 = new(12, 0, 0);
    private static readonly TimeSpan Pk14 = new(14, 0, 0);
    private static readonly TimeSpan Ev23 = new(14, 0, 0);
    
    public decimal Calculate(int baseCost,TimeSpan start, TimeSpan end)
    {
        decimal totalCost = 0;

        for (var t = start; t < end; t = t.Add(TimeSpan.FromHours(1)))
        {
            totalCost += t switch
            {
                _ when t >= Strd9 && t < Strd18 => baseCost, // Standard Hours
                _ when t >= Strd18 && t < Ev23 => baseCost * 0.8m, // Evening Hours
                _ when t >= Mr6 && t < Strd9 => baseCost * 0.9m, // Morning Hours
                _ when t >= Pk12 && t < Pk14 => baseCost * 1.15m, // Peak Hours
                _ => default
            };
        }

        return totalCost;
    }
}