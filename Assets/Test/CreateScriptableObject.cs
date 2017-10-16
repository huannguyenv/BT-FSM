using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BT;
using System;

public class CreateScriptableObject
{
    [MenuItem("BT/Create/Create Composite Node")]
    public static CompositeNode CreateNode()
    {
        CompositeNode asset = ScriptableObject.CreateInstance<CompositeNode>();
        AssetDatabase.CreateAsset(asset, "Assets/CompositeNode.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
