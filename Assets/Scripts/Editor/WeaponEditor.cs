using UnityEngine;
using System.Collections;
using UnityEditor;

public class WeaponEditor : EditorWindow 
{
	private static WeaponInfos m_Infos;

	[MenuItem("WeaponMaster/Weapon Editor")]
	private static void Init()
	{
		EditorWindow.GetWindow (typeof (WeaponEditor));
		m_Infos = ScriptableObjectUtils.CreateAsset<WeaponInfos> (WeaponManager.m_AssetPath);
		if(!m_Infos.m_IsInitialized) m_Infos.Setup();
	}

	private void OnGUI () 
	{
		if(GUILayout.Button("ADD"))
		{
			m_Infos.m_Prefixes.Add ("New Prefix" + (m_Infos.m_Prefixes.Count+1).ToString());
		}

		for(int i = 0; i < m_Infos.m_Prefixes.Count; i++)
		{
			EditorGUILayout.BeginHorizontal(GUI.skin.box);

			EditorGUILayout.LabelField(m_Infos.m_Prefixes[i]);
			if(GUILayout.Button("X", GUILayout.Width (18f)))
			{
				m_Infos.m_Prefixes.RemoveAt(i);
			}

			EditorGUILayout.EndHorizontal();
		}
	}
}
