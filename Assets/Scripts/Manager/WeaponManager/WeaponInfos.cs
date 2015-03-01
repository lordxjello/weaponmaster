using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponInfos : ScriptableObject 
{
	public bool m_IsInitialized;
	
	public List<string> m_Prefixes;
	public List<string> m_Sufixes;

	public void Setup()
	{
		m_IsInitialized = true;

		m_Prefixes = 	new List<string>();
		m_Sufixes = 	new List<string>();
	}

	#region Classes		
	[System.Serializable]
	public class Property
	{
		int m_Minimum;
		int m_Maximum;
	}

	[System.Serializable]
	public class BaseData
	{
		public WeaponManager.WeaponCategory m_Category;
		public string m_Name;
		public string m_Description;
		public List<Property> m_Properties;

		public bool m_DisplayInfo;

		public BaseData(string i_Name = "")
		{
			m_Name = i_Name;
			m_Properties = new List<Property>();
		}
	}

	[System.Serializable]
	public class WeaponData : BaseData
	{
	}
	#endregion
}
