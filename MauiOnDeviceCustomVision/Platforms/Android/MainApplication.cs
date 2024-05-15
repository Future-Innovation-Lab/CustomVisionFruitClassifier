using Android.App;
using Android.Runtime;
using Xam.Plugins.OnDeviceCustomVision;

namespace MauiOnDeviceCustomVision
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            AndroidImageClassifier.Init("model.pb", "labels.txt", ModelType.General);
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
