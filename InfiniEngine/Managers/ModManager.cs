using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace InfiniEngine.Managers {

    public static class ModManager {

        public static void LoadMod(string modPath) {

            Assembly modAssembly = Assembly.LoadFrom(modPath);
            Type modClass = modAssembly.GetType(modAssembly.GetName().Name + ".Mod", true);

            if (modClass.IsSubclassOf(typeof(InfiniMod))) {

                MethodInfo initMethod = modClass.GetMethod("Init");

                object modInstance = Activator.CreateInstance(modClass);
                object retVal = initMethod.Invoke(modInstance, null);

                if ((bool)retVal) {

                    Debug.Log("Loaded a mod!");

                } else {

                    Debug.LogWarning("Could not load the mod \"" + modPath + "\"! [Mod Init() Returned False]");

                }

            } else {

                Debug.LogWarning("Could not load the mod \"" + modPath + "\"! [Mod class is not a subclass of InfiniMod!]");

            }

        }

    }

}
