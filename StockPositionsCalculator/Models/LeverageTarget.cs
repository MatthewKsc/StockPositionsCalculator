namespace StockPositionsCalculator.Models
{
    public class LeverageTarget
    {
        public double Price { get; set; }
        public double ResultPrice { get; set; }
        public int PositionLeverage { get; set; }
        public double PositionProcentageWanted { get; set; }
        public TargetLeverageType TargetLeverageType { get; set; }

        public LeverageTarget(double price, int positionLeverage, double positionProcentageWanted, TargetLeverageType targetLeverageType)
        {
            Price = price;
            PositionLeverage = positionLeverage;
            PositionProcentageWanted = positionProcentageWanted;
            TargetLeverageType = targetLeverageType;
        }

        public void CalculateTarget()
        {

        }
    }
}
