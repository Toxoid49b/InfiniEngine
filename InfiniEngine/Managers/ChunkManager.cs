using System;
using System.Collections.Generic;
using UnityEngine;
using InfiniEngine.Terrain;
using InfiniEngine.Generator;

namespace InfiniEngine.Managers {

    public static class ChunkManager {

        private static Vector2[] newChunkPositions = new Vector2[9];
        private static Vector2? lastPosition;
        private static bool isInitialized = false;
        private static InfiniTerrain defaultTerrain;
        private static float incrementX;
        private static float incrementZ;
        private static Dictionary<Vector2, Chunk> activeChunks = new Dictionary<Vector2, Chunk>();

        public static void Initialize(InfiniTerrain terrainObject) {

            defaultTerrain = terrainObject;
            isInitialized = true;

        }

        public static void RunChunkUpdate(Vector3 playerPosition, bool autoGenerateTerrain) {

            incrementX = defaultTerrain.GetUnityObject().gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.x;
            incrementZ = defaultTerrain.GetUnityObject().gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.z;            
            Vector2 playerPositionRounded = new Vector2((Mathf.Round(playerPosition.x / incrementX) * incrementX) / incrementX, (Mathf.Round(playerPosition.z / incrementZ) * incrementZ) / incrementZ);

            if (lastPosition != null) {
                if (playerPositionRounded == lastPosition) return;
            }

            if (!isInitialized) throw new Exception("Chunk update reqeusted without proper initialization!");

            for (float I = playerPositionRounded.x - 1.0f; I <= playerPositionRounded.x + 1.0f; I++) {

                for (float J = playerPositionRounded.y - 1.0f; J <= playerPositionRounded.y + 1.0f; J++) {

                    if(!activeChunks.ContainsKey(new Vector2(I, J))){

                        GameObject terObj = (GameObject)GameObject.Instantiate(defaultTerrain.GetUnityObject(), new Vector3(I * incrementX, 0, J * incrementZ), Quaternion.identity);
                        InfiniTerrain newTerrain = new InfiniTerrain(terObj);
                        Chunk newChunk = new Chunk(newTerrain, new Biome(128.0f, 16.0f, 32.0f), new Vector2(I, J));
                        if (autoGenerateTerrain) newChunk.GenerateTerrain();                        
                        activeChunks.Add(new Vector2(I, J), newChunk);

                    }

                }

            }

            Vector2 playMoveDir = playerPositionRounded - lastPosition.GetValueOrDefault();
            playMoveDir.Normalize();

            if (playMoveDir == Vector2.up) {

                for (int K = (int)playerPositionRounded.x - 1; K <= playerPositionRounded.x + 1; K++) {

                    Vector2 nextToTest = new Vector2(K, playerPositionRounded.y - 2);

                    if (activeChunks.ContainsKey(nextToTest)) {

                        GameObject.Destroy(activeChunks[nextToTest].GetTerrainObject().GetUnityObject());
                        activeChunks.Remove(nextToTest);

                    }
                
                }

            }

            if (playMoveDir == Vector2.down) {

                for (int K = (int)playerPositionRounded.x - 1; K <= playerPositionRounded.x + 1; K++) {

                    Vector2 nextToTest = new Vector2(K, playerPositionRounded.y + 2);

                    if (activeChunks.ContainsKey(nextToTest)) {

                        GameObject.Destroy(activeChunks[nextToTest].GetTerrainObject().GetUnityObject());
                        activeChunks.Remove(nextToTest);

                    }

                }

            }

            if (playMoveDir == Vector2.left) {

                for (int K = (int)playerPositionRounded.y - 1; K <= playerPositionRounded.y + 1; K++) {

                    Vector2 nextToTest = new Vector2(playerPositionRounded.x + 2, K);

                    if (activeChunks.ContainsKey(nextToTest)) {

                        GameObject.Destroy(activeChunks[nextToTest].GetTerrainObject().GetUnityObject());
                        activeChunks.Remove(nextToTest);

                    }

                }

            }

            if (playMoveDir == Vector2.right) {

                for (int K = (int)playerPositionRounded.y - 1; K <= playerPositionRounded.y + 1; K++) {

                    Vector2 nextToTest = new Vector2(playerPositionRounded.x - 2, K);

                    if (activeChunks.ContainsKey(nextToTest)) {

                        GameObject.Destroy(activeChunks[nextToTest].GetTerrainObject().GetUnityObject());
                        activeChunks.Remove(nextToTest);

                    }

                }

            }

            lastPosition = playerPositionRounded;

        }

    }

}
