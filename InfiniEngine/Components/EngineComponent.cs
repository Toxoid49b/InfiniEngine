using UnityEngine;
using System.Collections;
using InfiniEngine;
using InfiniEngine.UI;
using InfiniEngine.Managers;
using InfiniEngine.Terrain;
using System.IO;

public class EngineComponent : MonoBehaviour {
    
    // Optional component for engine interaction with an infinte world

    public static EngineComponent instance;

    public string modFolder;
    public byte tickRate;
    public GameObject terrainObject;
    public float terrainDetailScale;
    public float terrainDetailHeight;
    public GUISkin defaultSkin;

    public EngineComponent() {

        instance = this;

    }

    void Awake() {

        // Get all files from the specified mods directory
        string[] modPaths = Directory.GetFiles(modFolder);

        // Try to load all valid mods
        foreach (string mod in modPaths) {

            ModManager.LoadMod(mod);

        }

        // Set the scene containing the default chunk
        if (terrainObject != null) {

            ChunkManager.Initialize(new InfiniTerrain(terrainObject));

        }

        // Initialize the interface manager with the specified skin
        InterfaceManager.Initialize(defaultSkin);

        // Start generating engine ticks
        StartCoroutine(GenerateEngineTick());

    }

    // Generates an engine cycle with the interval specified by tickRate
    IEnumerator GenerateEngineTick() {

        InfiniManager.activeManager.Cycle();        
        yield return new WaitForSeconds(1 / tickRate);
        StartCoroutine(GenerateEngineTick());

    }

    // Update the GUI system every time Unity performs a GUI update
    void OnGUI() {

        InterfaceManager.GUILoop();

    }

}

