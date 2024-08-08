using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

public class MakeScriptableObject
{
	[MenuItem("ProjectScripts/Make ScriptableObject")]
	public static void CreateMyAsset()
	{
		string assetName = "EnemyData";
		Type packageType = Type.GetType(assetName);

		EnemyDataAsset asset = ScriptableObject.CreateInstance<EnemyDataAsset>();

		AssetDatabase.CreateAsset(asset, "Assets/EnemyData.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}

}