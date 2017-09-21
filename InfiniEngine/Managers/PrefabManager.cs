using System;
using System.Collections.Generic;

namespace InfiniEngine.Managers {

    public class PrefabManager {

        private static Dictionary<string, IObjectPrefab> registeredPrefabs = new Dictionary<string, IObjectPrefab>();

        public static IObjectPrefab LookupObjectPrefab(string prefabIdentifier) {

            if (registeredPrefabs.ContainsKey(prefabIdentifier)) {

                return registeredPrefabs[prefabIdentifier];

            }

            return null;

        }

        public static void RegisterObjectPrefab(string prefabIdentifier, IObjectPrefab prefabObject) {

            registeredPrefabs.Add(prefabIdentifier, prefabObject);

        }

    }

}
