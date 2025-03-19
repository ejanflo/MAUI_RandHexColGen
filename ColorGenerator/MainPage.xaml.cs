namespace ColorGenerator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sliderRed.Value;
            var green = sliderGreen.Value;
            var blue = sliderBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }

        private void SetColor(Color color)
        {
            Container.BackgroundColor = color;
            buttonRandom.BackgroundColor = color;

            labelHex.Text = color.ToHex();
        }

        private void buttonRandom_Clicked(object sender, EventArgs e)
        {
            var rand = new Random();

            var color = Color.FromRgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
            SetColor(color);
            sliderRed.Value = color.Red;
            sliderGreen.Value = color.Green;
            sliderBlue.Value = color.Blue;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(labelHex.Text);
            await DisplayAlert("Color Maker", "Color copied", "OK");
        }
    }

}
