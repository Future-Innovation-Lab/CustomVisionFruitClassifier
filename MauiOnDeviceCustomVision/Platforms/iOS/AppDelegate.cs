using Foundation;
using Xam.Plugins.OnDeviceCustomVision;

namespace MauiOnDeviceCustomVision
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        iOSImageClassifier.Init("model");
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
