namespace InfiniEngine.Terrain {

    public class Biome {

        public float terrainDetailScale;
        public float terrainHeight;
        public float averageTemp;

        public Biome(float detialScale, float biomeHeight, float biomeTemp) {

            terrainDetailScale = detialScale;
            terrainHeight = biomeHeight;
            averageTemp = biomeTemp;

        }

    }

}
