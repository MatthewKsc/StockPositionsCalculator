using StockPositionsCalculator.Models;
using System;
using System.Linq;
using System.Windows;

namespace StockPositionsCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeLeverageComboBox();
            StopLossPrice.Text = "10";
            TakeProfitPrice.Text = "10";
        }

        private void InitializeLeverageComboBox()
        {
            LeverageTypeBox.SelectedItem = TargetLeverageType.None;
            LeverageTypeBox.ItemsSource = Enum.GetValues(typeof(TargetLeverageType)).Cast<TargetLeverageType>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PositionDeviation positionDeviation = new(
                Convert.ToDouble(ProvidedUserPrice.Text),
                Convert.ToDouble(TakeProfitProcentage.Text),
                Convert.ToDouble(StopLossProcentage.Text),
                (TargetLeverageType)LeverageTypeBox.SelectedValue);

            positionDeviation.CalculatePositionPrice();

            ProvidedUserPrice.Text = "0";
            TakeProfitPrice.Text = Convert.ToString(positionDeviation.TakeProfitPositionPrice);
            StopLossPrice.Text = Convert.ToString(positionDeviation.StopLossPositionPrice);
        }
    }
}
