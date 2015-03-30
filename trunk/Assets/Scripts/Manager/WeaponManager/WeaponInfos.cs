using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponInfos : ScriptableObject 
{
	public bool m_IsInitialized;
	
	public List<ItemBaseData> m_Prefixes;
	public List<string> m_Sufixes;

	public void Setup()
	{
		m_IsInitialized = true;

		m_Prefixes = 	new List<ItemBaseData>();
		m_Sufixes = 	new List<string>();
	}

	#region Classes		

	[System.Serializable]
	public class WeaponData : ItemBaseData
	{
	}
	#endregion
}

[System.Serializable]
public class Property
{
	int m_Minimum;
	int m_Maximum;
}

[System.Serializable]
public class ItemBaseData
{
	public string m_Name;
	public WeaponManager.WeaponCategory m_Category;
	public List<Property> m_Properties;
	
	public bool m_DisplayInfo;
	
	public ItemBaseData(string i_Name = "")
	{
		m_Name = i_Name;
		m_Properties = new List<Property>();
	}
}
