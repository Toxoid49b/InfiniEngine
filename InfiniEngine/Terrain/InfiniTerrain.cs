using InfiniEngine.Generator;
using System;
using UnityEngine;

namespace InfiniEngine.Terrain {

    public class InfiniTerrain {

        private GameObject terrainObject;
        private ScatterHelper scatterHelper;
        private ChunkTerrainGenerator activeGenerator;

        public InfiniTerrain(GameObject baseObject) {

            terrainObject = baseObject;
            scatterHelper = new ScatterHelper(baseObject);

        }

        public GameObject GetUnityObject() {

            return terrainObject;

        }

        public bool GenerateTerrain(float scale, float height) {

            if(activeGenerator != null) return false;
            ChunkTerrainGenerator ctg = new ChunkTerrainGenerator(terrainObject, scale, height, 0.0f, 0.0f);
            ctg.Start();
            activeGenerator = ctg;
            InfiniManager.activeManager.OnCycle += ActiveManager_OnCycle;
            return true;

        }

        public bool GenerateTerrain(float scale, float height, float xOffset, float yOffset) {

            if (activeGenerator != null) return false;
            ChunkTerrainGenerator ctg = new ChunkTerrainGenerator(terrainObject, scale, height, xOffset, yOffset);
            ctg.Start();
            activeGenerator = ctg;
            InfiniManager.activeManager.OnCycle += ActiveManager_OnCycle;
            return true;

        }

        private void ActiveManager_OnCycle(object sender, System.EventArgs e) {

            if (activeGenerator == null) throw new Exception("Tried to poll null terrain generator!");
            activeGenerator.Update();
            if (activeGenerator.IsDone) {
                InfiniManager.activeManager.OnCycle -= ActiveManager_OnCycle;
                activeGenerator = null;
            }

        }

        public void ScatterObject(InfiniObject objectToScatter, int timesToScatter, Quaternion objectRot) {

            scatterHelper.ScatterObject(objectToScatter.unityObject, timesToScatter, objectRot, 1);

        }

    }

}
