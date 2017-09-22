using System;
using System.Reflection;

namespace InfiniEngine.Managers {

    public static class ModManager {

        public static bool LoadMod(string modPath) {

            Assembly modAssembly = Assembly.LoadFrom(modPath);
            Type modClass = modAssembly.GetType(modAssembly.GetName().Name + ".Mod", true);

            if (modClass.IsSubclassOf(typeof(InfiniMod))) {

                MethodInfo initMethod = modClass.GetMethod("Init");

                object modInstance = Activator.CreateInstance(modClass);
                object retVal = initMethod.Invoke(modInstance, null);

                if ((bool)retVal) {

                    return true;

                } else {

                    return false;

                }

            } else {

                return false;

            }

        }

    }

}
