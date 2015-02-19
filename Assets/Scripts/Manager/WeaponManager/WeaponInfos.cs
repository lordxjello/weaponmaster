using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponInfos : ScriptableObject 
{
	[System.Serializable]
	public class Data
	{

	}

	public bool m_IsInitialized;

	public List<string> m_Prefixes;
	public List<string> m_Sufixes;

	public List<Data> m_Datas;

	public void Setup()
	{
		m_IsInitialized = true;

		m_Prefixes = 	new List<string>();
		m_Sufixes = 	new List<string>();
		m_Datas = 		new List<Data>();
	}
}
