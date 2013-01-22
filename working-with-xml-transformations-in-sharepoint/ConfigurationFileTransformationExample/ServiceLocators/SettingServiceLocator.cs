using ConfigurationFileTransformationExample.Services;

namespace ConfigurationFileTransformationExample.ServiceLocators
{
    class SettingServiceLocator
    {
        public static ISettingService SettingService<T>() where T : ISettingService, new()
        {
            return new T();
        }
    }
}
