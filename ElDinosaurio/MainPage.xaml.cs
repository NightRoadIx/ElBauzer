using Microsoft.Maui.Controls;
using System;

namespace ElDinosaurio
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnAddClicked(object sender, EventArgs e)
		{
			ResultLabel.Text = "";
			if (TryParseInputs(out double FirstNum1, out double SecondNum1))
			{
				double resultado = FirstNum1 + SecondNum1;
				Console.WriteLine($"{FirstNum1} {SecondNum1} {resultado}");
				//UpdateResultLabel(resultado);
			}
		}

		private void OnSubstractClicked(object sender, EventArgs e)
		{}

		private void OnMultiplyClicked(object sender, EventArgs e)	
		{}

		private void OnDivideClicked(object sender, EventArgs e)	
		{}

		private bool TryParseInputs(out double FirstNum1, out double SecondNum1)
		{
			bool validPrimerNum = double.TryParse(FirstNum.Text, out FirstNum1);
			bool validSecondNum = double.TryParse(SecondNum.Text, out SecondNum1);

			Console.WriteLine($"{FirstNum1} {SecondNum1}");
			if (!validPrimerNum || !validSecondNum)
			{
				// TODO: Aquí funciona esta vaina
				ResultLabel.Text = "Error Mortal";
				Console.WriteLine("Error en conversión");
				DisplayAlert("Error", "Valores incorrectos", "OK");			
				return false;
			}
			Console.WriteLine("Conversión exitosa");
			return true;
		}
		void UpdateResultLabel(double result)
		{
			// Actualizar el ResultLabel en el hilo principal
			Device.BeginInvokeOnMainThread(() =>
			{
				ResultLabel.Text = $"Resultado: {result}";
			});
		}	
	}
}