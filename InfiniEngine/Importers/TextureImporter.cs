using System;
using System.IO;
using UnityEngine;

namespace InfiniEngine.Importers {

    public static class TextureImporter {

        public static Texture2D LoadFromBytes(byte[] imageData) {

            Texture2D newTex = new Texture2D(0, 0);
            newTex.LoadImage(imageData);
            return newTex;

        }

        public static Texture2D LoadFromFile(string filePath) {

            if (File.Exists(filePath)) {

                byte[] fileData;
                fileData = File.ReadAllBytes(filePath);
                Texture2D newTex = new Texture2D(0, 0);
                newTex.LoadImage(fileData);
                return newTex;

            } else {

                return null;

            }

        }

    }

}
