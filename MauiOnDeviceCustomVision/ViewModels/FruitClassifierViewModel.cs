using Xam.Plugins.OnDeviceCustomVision;
using MauiOnDeviceCustomVision.Models;
using CommunityToolkit.Mvvm.Input;

namespace MauiOnDeviceCustomVision.ViewModels
{
    public partial class FruitClassifierViewModel : BaseViewModel
    {

        public string HighestProbabilityTag { get; set; }

        private ImageSource _photoImage;

        public ImageSource PhotoImage
        {
            get { return _photoImage; }

            set
            {
                _photoImage = value;

                OnPropertyChanged();
            }

        }

        private string _imageCaption;

        public string ImageCaption
        {
            get { return _imageCaption; }
            set
            {
                _imageCaption = value;

                OnPropertyChanged();
            }
        }

        public FruitClassifierViewModel()
        {
            ImageCaption = "When you only know apples and bananas, everything looks like apples and bananas...";
        }

        [RelayCommand]
        public async void Identify()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                  
                    using Stream sourceStream = await photo.OpenReadAsync();


                    MemoryStream ms = new MemoryStream();
                        await sourceStream.CopyToAsync(ms);
                    ms.Position = 0;

                    var classifications = await CrossImageClassifier.Current.ClassifyImage(ms);
                    var highestProbabilityTag = classifications.OrderByDescending(c => c.Probability).First();
                    HighestProbabilityTag = highestProbabilityTag.Tag;

                    ImageCaption = $"I think that is a {HighestProbabilityTag}   ({highestProbabilityTag.Probability:F2})";

                    ms.Position = 0;
                    PhotoImage = ImageSource.FromStream(() => ms);

                    await SpeakAboutTag(HighestProbabilityTag);
                }
            }
        }

        public async Task SpeakAboutTag(string tag)
        {
            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f
            };

            await TextToSpeech.SpeakAsync(SpeechStore.StandardResponse + tag, settings);
        }
    }
}
