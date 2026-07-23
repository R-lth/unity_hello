using UnityEngine;
using UnityEditor;
using System.Collections;

public class CheckAnimationFrames : AssetPostprocessor
{

    void OnPostprocessModel(GameObject g)
    {
        // Only operate on FBX files
        if (assetPath.IndexOf(".fbx") == -1)
        {
            return;
        }

        if (EditorUtility.DisplayDialog("FrameCount", "Show number of frames?", "Yes", "No"))
        {
            ShowFrames(g);
        }
    }

    void ShowFrames(GameObject g)
    {

        Animation anim = (Animation)g.GetComponent(typeof(Animation));
        foreach (AnimationState state in anim)
        {
            AnimationClip clip = state.clip;
            Debug.Log(g.name + " animation data is " + (clip.length * clip.frameRate) + " frames long");
        }
    }
}
