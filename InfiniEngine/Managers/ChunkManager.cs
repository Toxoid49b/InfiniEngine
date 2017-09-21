using System;
using System.Collections.Generic;
using UnityEngine;
using InfiniEngine.Terrain;

namespace InfiniEngine.Managers {

    public static class ChunkManager {

        private static bool isLoadingChunks;
        private static byte numberOfChunksToProcess;
        private static Vector2[] newChunkPositions = new Vector2[9];
        private static Vector2 lastPosition;
        private static string chunkSceneName;
        private static bool isInitialized = false;

        public static Dictionary<Vector2, Chunk> loadedChunks = new Dictionary<Vector2, Chunk>();

        public static void Initialize(string sceneName) {

            chunkSceneName = sceneName;
            isInitialized = true;

        }

        public static void RunChunkUpdate(Vector2 playerPositionRounded) {

            if (!isInitialized) { Logger.Put("Chunk update reqeusted without proper initialization!"); return; }

            isLoadingChunks = true;

            for (float I = playerPositionRounded.x - 1.0f; I <= playerPositionRounded.x + 1.0f; I++) {

                for (float J = playerPositionRounded.y - 1.0f; J <= playerPositionRounded.y + 1.0f; J++) {

                    if(!loadedChunks.ContainsKey(new Vector2(I,J))){

                        Application.LoadLevelAdditiveAsync(chunkSceneName);
                        newChunkPositions[numberOfChunksToProcess] = new Vector2(I, J);
                        numberOfChunksToProcess++;

                    }

                }

            }

            Vector2 playMoveDir = playerPositionRounded - lastPosition;
            playMoveDir.Normalize();

            if (playMoveDir == Vector2.up) {

                for (int K = (int)playerPositionRounded.x - 1; K <= playerPositionRounded.x + 1; K++) {

                    Vector2 nextToTest = new Vector2(K, playerPositionRounded.y - 2);

                    if (loadedChunks.ContainsKey(nextToTest)) {

                        loadedChunks[nextToTest].RemoveChunk();
                        loadedChunks.Remove(nextToTest);

                    }
                
                }

            }

            if (playMoveDir == Vector2.down) {

                for (int K = (int)playerPositionRounded.x - 1; K <= playerPositionRounded.x + 1; K++) {

                    Vector2 nextToTest = new Vector2(K, playerPositionRounded.y + 2);

                    if (loadedChunks.ContainsKey(nextToTest)) {

                        loadedChunks[nextToTest].RemoveChunk();
                        loadedChunks.Remove(nextToTest);

                    }

                }

            }

            if (playMoveDir == Vector2.left) {

                for (int K = (int)playerPositionRounded.y - 1; K <= playerPositionRounded.y + 1; K++) {

                    Vector2 nextToTest = new Vector2(playerPositionRounded.x + 2, K);

                    if (loadedChunks.ContainsKey(nextToTest)) {

                        loadedChunks[nextToTest].RemoveChunk();
                        loadedChunks.Remove(nextToTest);

                    }

                }

            }

            if (playMoveDir == Vector2.right) {

                for (int K = (int)playerPositionRounded.y - 1; K <= playerPositionRounded.y + 1; K++) {

                    Vector2 nextToTest = new Vector2(playerPositionRounded.x - 2, K);

                    if (loadedChunks.ContainsKey(nextToTest)) {

                        loadedChunks[nextToTest].RemoveChunk();
                        loadedChunks.Remove(nextToTest);

                    }

                }

            }

            lastPosition = playerPositionRounded;

        }

        public static void RegisterChunk(Chunk chunkToRegister) {

            if (!isInitialized) { Logger.Put("Chunk registration reqeusted without proper initialization!"); return; }

            if (isLoadingChunks) {

                chunkToRegister.SetChunkConfigurationInformation(newChunkPositions[numberOfChunksToProcess - 1], new Biome(), new Zone(), "A New Chunk"); //ToDo: Fix
                numberOfChunksToProcess--;
                loadedChunks.Add(newChunkPositions[numberOfChunksToProcess], chunkToRegister);

                if (numberOfChunksToProcess <= 0) isLoadingChunks = false;

            } else {

                Debug.LogError("[ERROR] Chunk attempted registration when no spawning opperation was in progress!"); 

            }
        
        }

    }

}
