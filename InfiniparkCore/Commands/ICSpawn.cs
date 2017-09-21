using System;
using UnityEngine;
using InfiniEngine;
using InfiniEngine.Managers;
using InfiniEngine.InfiniScript;

namespace InfiniparkCore.Commands {

    public class ICSpawn : IInfiniCommand {

        public string commandName {
            get {
                return "spawn";
            }
            set {

            }
        }

        public bool Execute(string[] cmdArgs) {

            if (cmdArgs.Length == 4) {

                IObjectPrefab newObj = PrefabManager.LookupObjectPrefab(cmdArgs[0]);

                if (newObj != null) {

                    Vector3 entPos = new Vector3(float.Parse(cmdArgs[1]), float.Parse(cmdArgs[2]), float.Parse(cmdArgs[3]));
                    newObj.Instantiate(entPos, Quaternion.identity);
                    Logger.Put("Spawned the " + cmdArgs[0] + " at " + entPos.ToString() + "\n");
                    return true;

                }

            }

            return false;

        }

    }

}
