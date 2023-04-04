namespace PostIT_App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public string MyStringTest { get; set; } = "Hello there";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            
            if (status != PermissionStatus.Granted)
            {
                //if (Permissions.ShouldShowRationale<Permissions.Camera>() )
                //{
                //    await DisplayAlert("Need camera permissions", "suck it", "Ok");
                //    status = await Permissions.RequestAsync<Permissions.Camera>();
                //}
            }
            

            var photoResult = await MediaPicker.PickPhotoAsync();

            if (photoResult != null)
            {
                var photoStream = await photoResult.OpenReadAsync();

                ImgBox.Source = ImageSource.FromStream(() => photoStream);
            }
        }

        private async void CounterBtn2_Clicked(object sender, EventArgs e)
        {
            //PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();

            //if (status != PermissionStatus.Granted)
            //{
            //    if (Permissions.ShouldShowRationale<Permissions.Camera>())
            //    {
            //        await DisplayAlert("Need camera permissions", "suck it", "Ok");
            //        status = await Permissions.RequestAsync<Permissions.Camera>();
            //    }
            //}
            var photoResult = await MediaPicker.CapturePhotoAsync();
            

            if (photoResult != null)
            {
                var photoStream = await photoResult.OpenReadAsync();

                ImgBox.Source = ImageSource.FromStream(() => photoStream);
            }

        }
    }
}