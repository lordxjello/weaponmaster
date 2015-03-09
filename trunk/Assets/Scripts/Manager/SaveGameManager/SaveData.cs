using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SaveData : Singleton<SaveData>
{
	public enum WebType
	{
		Int = 0,
		Float,
		String
	}

	public enum SaveKey
	{
		HP = 0,
		MP,
		Attack,
		Defense,
		AttackSpeed,
		MoveSpeed,

		Count
	}

	public class WebData
	{
		public WebType	m_Type;
		public int 		m_IntValue;
		public float 	m_FloatValue;
		public string 	m_StringValue;

		public WebData(WebType i_Type, int i_Value)
		{
			m_Type = i_Type;
			m_IntValue = i_Value;
		}

		public WebData(WebType i_Type, float i_Value)
		{
			m_Type = i_Type;
			m_FloatValue = i_Value;
		}

		public WebData(WebType i_Type, string i_Value)
		{
			m_Type = i_Type;
			m_StringValue = i_Value;
		}
	}

	public static int SaveSlots = 3;
	public int m_SaveIndex = 0;
	public Dictionary<string, WebData> m_WebDatas = new Dictionary<string, WebData>();

	private void Start()
	{
		SaveGameManager.LoadWeb();
	}
}
