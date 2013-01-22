using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigurationFileTransformationExample.Model;

namespace ConfigurationFileTransformationExample.Services
{
    interface ISettingService
    {
        bool TryLocateByKey(string key, out Setting value);

        IEnumerable<Setting> FindAll();
    }
}
