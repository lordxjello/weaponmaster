using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
	public static SaveData Current;

	public enum WebType
	{
		Int = 0,
		Float,
		String
	}

	public class WebData
	{
		public WebType	m_Type;
		public float 	m_FloatValue;
		public int 		m_IntValue;
		public string 	m_StringValue;

		public WebData(WebType i_Type)
		{
			m_Type = i_Type;
		}
	}

	[HideInInspector]
	public static Dictionary<string, WebData> WebDatas;

	public float CharacterCV
	{
		get { return WebDatas["CharacterCV"].m_FloatValue; }
		set { WebDatas["CharacterCV"].m_FloatValue = value; }
	}


	public SaveData()
	{
		WebDatas = new Dictionary<string, WebData>();
		WebDatas.Add ("CharacterCV", new WebData(WebType.Float));
	}
}
