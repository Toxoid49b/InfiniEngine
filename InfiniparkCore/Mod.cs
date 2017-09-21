using System;
using InfiniEngine;
using InfiniEngine.Managers;
using UnityEngine;
using InfiniparkCore.Commands;

namespace InfiniparkCore {

    public class Mod : InfiniMod {

        // Example mod for InfiniEngine

        public override bool Init() {

            RegisterCommands();
            RegisterPrefabs();
            Debug.Log("[CORE] Loaded!");
            return true;            

        }

        private void RegisterPrefabs() {

            PrefabManager.RegisterObjectPrefab("cube", new Primitives.Cube());
            PrefabManager.RegisterObjectPrefab("dynamiccube", new Primitives.DynamicCube());
            PrefabManager.RegisterObjectPrefab("sphere", new Primitives.Sphere());
            PrefabManager.RegisterObjectPrefab("dynamicsphere", new Primitives.DynamicSphere());
            PrefabManager.RegisterObjectPrefab("texturedcube", new Primitives.TexturedCube());

        }

        private void RegisterCommands() {

            ICClear cmdClear = new ICClear();
            CommandManager.RegisterCommand(cmdClear);

            ICSpawn cmdSpawn = new ICSpawn();
            CommandManager.RegisterCommand(cmdSpawn);

            ICSword cmdSword = new ICSword();
            CommandManager.RegisterCommand(cmdSword);

            ICDeclare cmdDeclare = new ICDeclare();
            CommandManager.RegisterCommand(cmdDeclare);

        }

    }

}
