using UnityEngine;
using System.Collections;
using InfiniEngine;
using InfiniEngine.UI;
using InfiniEngine.Managers;
using System.IO;

public class EngineComponent : MonoBehaviour {
    
    public static EngineComponent instance;

    public string modFolder;
    public byte tickRate;
    public string chunkSceneName;
    public float terrainDetailScale;
    public float terrainDetailHeight;
    public int flameDamageRate;

    public GameObject flamePrefab;

    public GUISkin defaultSkin;

    public EngineComponent() {

        instance = this;

    }

    void Awake() {

        string[] modPaths = Directory.GetFiles(modFolder);

        foreach (string mod in modPaths) {

            ModManager.LoadMod(mod);

        }

        if (chunkSceneName != "null" && chunkSceneName != "") {

            ChunkManager.Initialize(chunkSceneName);

        }

        InterfaceManager.Initialize(defaultSkin);
        StartCoroutine(GenerateEngineTick());

    }

    IEnumerator GenerateEngineTick() {

        InfiniManager.activeManager.Cycle();        
        yield return new WaitForSeconds((float)(1 / tickRate));
        StartCoroutine(GenerateEngineTick());

    }

    void OnGUI() {

        InterfaceManager.GUILoop();

    }

}

