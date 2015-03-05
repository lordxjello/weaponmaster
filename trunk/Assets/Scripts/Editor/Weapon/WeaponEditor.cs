using UnityEngine;
using System.Collections;
using UnityEditor;

public class WeaponEditor : EditorWindow 
{
	private WeaponInfos m_Infos;

	private bool m_NeedLoad = true;

	[MenuItem("WeaponMaster/Weapon Editor")]
	private static void Init()
	{
		EditorWindow.GetWindow (typeof (WeaponEditor));
	}

	private void OnGUI () 
	{
		if(m_NeedLoad /*|| m_Infos == null*/)
		{
			m_NeedLoad = false;
			LoadValues();
		}

		if(GUILayout.Button("ADD"))
		{
			m_Infos.m_Prefixes.Add (new ItemBaseData("New Prefix" + (m_Infos.m_Prefixes.Count+1).ToString()));
		}

		for(int i = 0; i < m_Infos.m_Prefixes.Count; i++)
		{
			EditorGUILayout.BeginHorizontal(GUI.skin.box);

			EditorGUILayout.LabelField(m_Infos.m_Prefixes[i].m_Name);
			if(GUILayout.Button("X", GUILayout.Width (18f)))
			{
				m_Infos.m_Prefixes.RemoveAt(i);
			}

			EditorGUILayout.EndHorizontal();
		}
	}

	private void LoadValues()
	{
		if(m_Infos == null)
		{
			m_Infos = ScriptableObjectUtils.CreateAsset<WeaponInfos> (WeaponManager.m_AssetPath);
			if(!m_Infos.m_IsInitialized) m_Infos.Setup();
		}
	}
}
