using UnityEngine;
using System.Collections.Generic;
using InfiniEngine.Util;

namespace InfiniEngine.Terrain {

    public class ScatterHelper {

        private GameObject terrain;
        private List<Vector3> objectPositions = new List<Vector3>();
        private bool allowOverlap;
        private float maxPadding;

        public ScatterHelper(GameObject terrainObj) {

            terrain = terrainObj;
            allowOverlap = false;
            maxPadding = 1.0f;

        }

        public ScatterHelper(GameObject terrainObj, bool overlapSetting, float paddingSetting) {

            terrain = terrainObj;
            allowOverlap = overlapSetting;
            maxPadding = paddingSetting;

        }

        public void ScatterObject(GameObject objToScatter, int numObjects, Vector3 rndRotAxis, Vector3 baseRotation, int exclusionZone) {

            for (int I = 0; I < numObjects; I++) {

                ScatterObject(objToScatter, 1, Quaternion.Euler(new Vector3(rndRotAxis.x * InfiniUtil.GetNextInt32(360) + baseRotation.x, rndRotAxis.y * InfiniUtil.GetNextInt32(360) + baseRotation.y, rndRotAxis.z * InfiniUtil.GetNextInt32(360) + baseRotation.z)), exclusionZone);

            }

        }

        public void ScatterObject(GameObject objToScatter, int numObjects, Quaternion objRot, int exclusionZone) {

            Mesh terrainMesh = terrain.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = terrainMesh.vertices;
            Vector3 objPos = Vector3.zero;

            for (int I = 0; I < numObjects; I++) {

                while (true) {

                    int rndIndex = InfiniUtil.GetNextInt32(terrainMesh.vertices.Length);
                    objPos = vertices[rndIndex];

                    if (objPos.x > terrainMesh.bounds.min.x + exclusionZone && objPos.x < terrainMesh.bounds.max.x - exclusionZone) {

                        if (objPos.z > terrainMesh.bounds.min.z + exclusionZone && objPos.z < terrainMesh.bounds.max.z - exclusionZone) {

                        onReset:
                            foreach(Vector3 entPos in objectPositions){

                                if (Vector3.Distance(objPos, entPos) <= maxPadding) {

                                    Vector2 rndRange = Random.insideUnitCircle * 2;
                                    objPos = new Vector3(objPos.x + rndRange.x + maxPadding, objPos.y, objPos.z + rndRange.y + maxPadding);
                                    goto onReset;

                                }

                            }

                            break;

                        }

                    }

                }

                GameObject.Instantiate(objToScatter, objPos, objRot);
                if (!allowOverlap) objectPositions.Add(objPos);

            }

        }

        public void ClearObjectPosCache() {

            objectPositions.Clear();

        }

    }

}
