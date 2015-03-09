using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class ProjectUtils : EditorWindow
{
	[MenuItem("SameLap/PlayerPrefs/Delete All")]
	private static void DeleteAllPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}
	
	[MenuItem("SameLap/PlayerPrefs/Delete Key")]
	private static void DeletePlayerPrefsbyKey()
	{
		EditorWindow.GetWindow (typeof (ProjectUtils));
	}
	
	private int m_KeyIndex;
	private List<string> m_KeysList;
	private string[] m_Keys;

	private void OnGUI () 
	{
		if(m_KeysList == null)
		{
			SetKeys();
		}

		EditorGUILayout.BeginHorizontal();

		EditorGUILayout.LabelField("Key: ", GUILayout.Width(30f));
		if(m_Keys.Length == 0)
			EditorGUILayout.LabelField("No Keys", GUILayout.Width(50f));
		else
		{
			m_KeyIndex = EditorGUILayout.Popup(m_KeyIndex, m_Keys);
			if(GUILayout.Button("Delete", GUILayout.Width(50f)))
			{
				PlayerPrefs.DeleteKey(m_Keys[m_KeyIndex]);
				SetKeys ();
			}
		}

		EditorGUILayout.EndHorizontal();
	}

	private void OnFocus()
	{
		SetKeys ();
	}

	private void SetKeys()
	{
		if(m_KeysList == null)
			m_KeysList = new List<string>();
		else
			m_KeysList.Clear();

		string[] saveKeys = System.Enum.GetNames(typeof(SaveData.SaveKey));
		int i;
		for(i = 0; i < SaveData.SaveSlots; i++)
		{
			for(int j = 0; j < saveKeys.Length; j++)
			{
				if(PlayerPrefs.HasKey(saveKeys[j]+i.ToString()))
				{
					m_KeysList.Add(saveKeys[j]+i.ToString());
				}
			}
		}

		m_Keys = new string[m_KeysList.Count];
		for(i = 0; i < m_KeysList.Count; i++)
		{
			m_Keys[i] = m_KeysList[i];
		}

		m_KeyIndex = 0;
	}
}
