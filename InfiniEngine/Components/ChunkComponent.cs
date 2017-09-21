using System;
using System.Collections.Generic;
using UnityEngine;
using InfiniEngine;
using InfiniEngine.Generator;
using InfiniEngine.Terrain;

public class ChunkComponent : MonoBehaviour {

    private Chunk thisChunk;
    private ChunkTerrainGenerator chunkGen;
    private bool isChunkGenDone;

    void Awake() {

        thisChunk = new Chunk(this);

    }

    void Update() {

        if (chunkGen != null && !isChunkGenDone) {

            if (chunkGen.Update()) {

                isChunkGenDone = true;

            }

        }

    }

    public void StartGenerator() {

        chunkGen = new ChunkTerrainGenerator(this.gameObject, EngineComponent.instance.terrainDetailScale, EngineComponent.instance.terrainDetailHeight, 0.0f, 0.0f);
        chunkGen.Start();

    }

    public void DestroyChunk() {

        Destroy(this.gameObject);

    }

}

