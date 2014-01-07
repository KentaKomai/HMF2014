using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Threading.Tasks;

namespace HMF_KOMAI_CSHARP.Services
{
    class UtilService
    {
 
		static public void ClearEvent(Component component)
        {
            if (component == null)
            {
                return;
            }

            BindingFlags flag = BindingFlags.NonPublic | BindingFlags.Instance;
            EventHandlerList evList = typeof(Component).GetField("events", flag).GetValue(component) as EventHandlerList;
            if (evList == null)
            {
                return;
            }

            object evEntryData = evList.GetType().GetField("head", flag).GetValue(evList);
            if (evEntryData == null)
            {
                return;
            }
            do
            {
                object key = evEntryData.GetType().GetField("key", flag).GetValue(evEntryData);
                if (key == null)
                {
                    break;
                }
                evList[key] = null;
                evEntryData = evEntryData.GetType().GetField("next", flag).GetValue(evEntryData);

            }
            while (evEntryData != null);
        }
    }

}
