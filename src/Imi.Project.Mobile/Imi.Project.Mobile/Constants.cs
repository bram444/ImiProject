using Xamarin.Essentials;

namespace Imi.Project.Mobile
{
    public class Constants
    {
        public static string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
    }
}