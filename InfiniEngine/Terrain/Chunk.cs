using UnityEngine;

namespace InfiniEngine.Terrain {

    public class Chunk {

        private InfiniTerrain thisTerrain;

        public Vector2 chunkPosition;
        public string chunkName;
        public Biome chunkBiome;

        public Chunk(InfiniTerrain it, Biome b, Vector2 posRounded) {

            thisTerrain = it;
            chunkBiome = b;
            chunkPosition = posRounded;

        }

        public InfiniTerrain GetTerrainObject() {

            return thisTerrain;

        }

        public void GenerateTerrain() {

            thisTerrain.GenerateTerrain(chunkBiome.terrainDetailScale, chunkBiome.terrainHeight);

        }

    }

}
