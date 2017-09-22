using UnityEngine;

namespace InfiniEngine.Generator {

    public class MaterialGenerator {

        /// <summary>
        /// Creates a new Material from the specified paramaters
        /// </summary>
        public static Material CreateMaterial(string materialName, string shaderName, Texture2D materialTexture, Color materialColor, Vector2 textureOffest, Vector2 textureScale) {

            Shader matShader = Shader.Find(shaderName);
            if (matShader == null) return null;

            Material newMat = new Material(matShader);
            newMat.color = materialColor;
            newMat.name = materialName;
            newMat.mainTexture = materialTexture;
            newMat.mainTextureOffset = textureOffest;
            newMat.mainTextureScale = textureScale;

            return newMat;

        }

        /// <summary>
        /// Creates a new Material from the specified paramaters
        /// </summary>
        public static Material CreateMaterial(string materialName, string shaderName, Texture2D materialTexture, Color materialColor) {

            Shader matShader = Shader.Find(shaderName);
            if (matShader == null) return null;

            Material newMat = new Material(matShader);
            newMat.color = materialColor;
            newMat.name = materialName;
            newMat.mainTexture = materialTexture;
            newMat.mainTextureOffset = new Vector2(1, 1);
            newMat.mainTextureScale = new Vector2(1, 1);

            return newMat;

        }

        /// <summary>
        /// Creates a new Material from the specified paramaters
        /// </summary>
        public static Material CreateMaterial(string materialName, string shaderName, Texture2D materialTexture) {

            Shader matShader = Shader.Find(shaderName);
            if (matShader == null) return null;

            Material newMat = new Material(matShader);
            newMat.color = Color.white;
            newMat.name = materialName;
            newMat.mainTexture = materialTexture;
            newMat.mainTextureOffset = new Vector2(1, 1);
            newMat.mainTextureScale = new Vector2(1, 1);

            return newMat;

        }

        /// <summary>
        /// Creates a new Material from the specified paramaters
        /// </summary>
        public static Material CreateMaterial(string materialName, string shaderName, Color materialColor) {

            Shader matShader = Shader.Find(shaderName);
            if (matShader == null) return null;

            Material newMat = new Material(matShader);
            newMat.color = materialColor;
            newMat.name = materialName;

            return newMat;

        }

        public static Material DefaultMaterial() {

            Material newMat = new Material(Shader.Find("Standard"));
            newMat.color = Color.white;
            newMat.name = "Default";
            return newMat;

        }

    }

}
