using UnityEngine;
using UnityEditor;

public static class ScriptableObjectUtils
{
	public static T CreateAsset<T> (string i_Path) where T : ScriptableObject
	{
		T asset = (T)AssetDatabase.LoadAssetAtPath(i_Path, typeof(T));

		if(asset == null)
		{
			asset = ScriptableObject.CreateInstance<T> ();
			AssetDatabase.CreateAsset (asset, i_Path);

			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh();
		}

		//EditorUtility.FocusProjectWindow ();
		Selection.activeObject = asset;

		return asset;
	}
}