using System;

namespace StockPositionsCalculator.Models
{
    public class PositionDeviation
    {
        public double StartingPositionPrice { get; set; }
        public double TakeProfitProcentage { get; set; }
        public double TakeProfitPositionPrice { get; set; }
        public double StopLossProcentage { get; set; }
        public double StopLossPositionPrice { get; set; }
        public TargetLeverageType LeverageType { get; set; }

        public PositionDeviation()
        {
        }

        public PositionDeviation(
            double startingPositionPrice,
            double takeProfitProcentage,
            double stopLossProcentage,
            TargetLeverageType leverageType)
        {
            StartingPositionPrice = startingPositionPrice;
            TakeProfitProcentage = takeProfitProcentage;
            StopLossProcentage = stopLossProcentage;
            LeverageType = leverageType;
        }

        public void CalculatePositionPrice()
        {
            TakeProfitProcentage = TakeProfitProcentage / 100;
            StopLossProcentage = StopLossProcentage / 100;

            (TakeProfitPositionPrice, StopLossPositionPrice) = GetPostionsPrices();
        }

        private (double takeProfit, double stopLoss) GetPostionsPrices() => LeverageType switch
        {
            TargetLeverageType.Long => GetPricesForLongPosition(),
            TargetLeverageType.Short => GetPricesForShortPosition(),
            _ => throw new Exception("Please provide leverageType"),
        };

        private (double takeProfit, double stopLoss) GetPricesForLongPosition()
        {
            double take = Math.Round(StartingPositionPrice + (TakeProfitProcentage * StartingPositionPrice), 2);
            double stop = Math.Round(StartingPositionPrice - (StopLossProcentage * StartingPositionPrice), 2);

            return (take, stop);
        }

        private (double takeProfit, double stopLoss) GetPricesForShortPosition()
        {
            double take = Math.Round(StartingPositionPrice - (TakeProfitProcentage * StartingPositionPrice), 2);
            double stop = Math.Round(StartingPositionPrice + (StopLossProcentage * StartingPositionPrice), 2);

            return (take, stop);
        }
    }
}
