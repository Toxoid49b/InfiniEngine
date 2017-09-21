using System;
using System.Collections.Generic;
using UnityEngine;
using InfiniEngine.Managers;

namespace InfiniEngine.Terrain {

    public class Chunk {

        private ChunkComponent thisChunkComponent;

        public Vector2 chunkPosition;
        public List<Vector3> trailerSpawns = new List<Vector3>();
        public string chunkName;
        public Biome chunkBiome;
        public Zone chunkZone;

        public Chunk(ChunkComponent cc) {

            thisChunkComponent = cc;

            ChunkManager.RegisterChunk(this); // Register with the chunk manager to let it know this chunk has spawned

        }

        /// <summary>
        /// Called after the Chunk Manager registers the chunk, used to initialize chunk information
        /// </summary>
        public void SetChunkConfigurationInformation(Vector2 newChunkPosition, Biome newChunkBiome, Zone newChunkZone, string newChunkName) {

            chunkPosition = newChunkPosition;
            thisChunkComponent.gameObject.transform.position = new Vector3((newChunkPosition.x * 128) + 64, 0.0f, (newChunkPosition.y * 128) + 64);
            thisChunkComponent.StartGenerator();

        }

        public void RemoveChunk() {

            thisChunkComponent.DestroyChunk();

        }

    }

}
