using System;
using UnityEngine;
using InfiniEngine.Util;

namespace InfiniEngine.Generator {

    public delegate void ChunkGeneratorFinishedHandler(object sender, EventArgs e);

    public class ChunkTerrainGenerator : ThreadJob {

        private GameObject terrainObject;
        private Mesh terrainMesh;
        private Vector3 terrainPosition;
        private Vector3[] oldTerrainVerts;
        private Vector3[] newTerrainVerts;
        private float terrainDetailScale;
        private float terrainDetailHeight;
        private float xOffset;
        private float zOffset;

        public ChunkTerrainGenerator(GameObject terrain, float detailScale, float detailHeight, float xoff, float zoff) {

            terrainObject = terrain;
            terrainMesh = terrainObject.GetComponent<MeshFilter>().mesh;
            terrainPosition = terrainObject.transform.position;
            oldTerrainVerts = terrainMesh.vertices;
            terrainDetailScale = detailScale;
            terrainDetailHeight = detailHeight;
            xOffset = xoff;
            zOffset = zoff;

        }

        protected override void ThreadFunction() {

            Vector3[] vertices = oldTerrainVerts;

            for (int i = 0; i < vertices.Length; i++) {

                float xCoord = (vertices[i].x + terrainPosition.x) / terrainDetailScale;
                float zCoord = (vertices[i].z + terrainPosition.z) / terrainDetailScale;
                vertices[i].y = Mathf.PerlinNoise(xCoord + xOffset, zCoord + zOffset) * terrainDetailHeight;

            }

            newTerrainVerts = vertices;

        }

        protected override void OnFinished() {

            terrainMesh.vertices = newTerrainVerts;
            terrainMesh.RecalculateBounds();
            terrainMesh.RecalculateNormals();
            terrainMesh.Optimize();

            terrainObject.GetComponent<MeshCollider>().sharedMesh = null;
            terrainObject.GetComponent<MeshCollider>().sharedMesh = terrainMesh;

        }

    }

}
