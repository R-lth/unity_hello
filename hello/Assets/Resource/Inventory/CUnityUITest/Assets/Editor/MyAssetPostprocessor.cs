//AssetImporter ≒ meta 파일

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEditor;
using UnityEngine;

public class MyAssetPostprocessor : AssetPostprocessor
{
    class MyAllPostprocessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (string str in importedAssets)
                Debug.Log("Reimported Asset: " + str);

            //foreach (string str in deletedAssets)
            //    Debug.Log("Deleted Asset: " + str);

            //for (int i = 0; i < movedAssets.Length; i++)
            //    Debug.Log("Moved Asset: " + movedAssets[i] + " from: " + movedFromAssetPaths[i]);
        }
    }

    /*
        void OnPostprocessTexture(Texture2D texture)
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            if (textureImporter == null) return;

            // texture에 경로가 "Assets/Texture"라면 mipmap 옵션을 켜줌
            if (assetPath.StartsWith("Assets/Texture"))
            {
                if (textureImporter.mipmapEnabled == false)
                {
                    textureImporter.mipmapEnabled = true;
                    Debug.LogWarning(" textureImporter.mipmapEnabled ");
                }
            }
        }

        //ReadOnlyModelPostprocessor
        public void OnPreprocessModel()
        {
            ModelImporter modelImporter = (ModelImporter)assetImporter;
            if (modelImporter.isReadable)
            {
                modelImporter.isReadable = false;
                modelImporter.SaveAndReimport();
            }
        }
    */
}

