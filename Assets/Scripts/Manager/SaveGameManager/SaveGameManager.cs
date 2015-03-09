using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveGameManager
{
	/*
	public static List<SaveData> savedGames = new List<SaveData>();

	public static void Save() 
	{
		SaveGameManager.savedGames.Add(SaveData.Current);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd");
		bf.Serialize(file, SaveGameManager.savedGames);
		file.Close();
	}   
	
	public static void Load() 
	{
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveGameManager.savedGames = (List<TestSave>)bf.Deserialize(file);
			file.Close();
		}
	}
	*/

	#region WEB
	public static void SaveWeb() 
	{
		foreach(KeyValuePair<string, SaveData.WebData> kvp in SaveData.Instance.m_WebDatas)
		{
			SaveWebByData(kvp.Key, kvp.Value);
		}
	}   
	
	public static void SaveWebByData(string i_ID, SaveData.WebData i_Data) 
	{
		switch(i_Data.m_Type)
		{
		case SaveData.WebType.Float:
			PlayerPrefs.SetFloat(i_ID, i_Data.m_FloatValue);
			break;
		case SaveData.WebType.Int:
			PlayerPrefs.SetInt(i_ID, i_Data.m_IntValue);
			break;
		case SaveData.WebType.String:
			PlayerPrefs.SetString(i_ID, i_Data.m_StringValue);
			break;
		}
	}
	
public static void LoadWeb() 
	{
		foreach(KeyValuePair<string, SaveData.WebData> kvp in SaveData.Instance.m_WebDatas)
		{
			switch(kvp.Value.m_Type)
			{
			case SaveData.WebType.Float:
				kvp.Value.m_FloatValue = PlayerPrefs.GetFloat(kvp.Key);
				break;
			case SaveData.WebType.Int:
				kvp.Value.m_IntValue = PlayerPrefs.GetInt(kvp.Key);
				break;
			case SaveData.WebType.String:
				string saveValue = PlayerPrefs.GetString(kvp.Key);
				if(!string.IsNullOrEmpty(saveValue))
				{
					kvp.Value.m_StringValue = saveValue;
				}
				break;
			}
		}
	}

	public static void SetIntSaveKey(string i_ID, int i_Value)
	{
		SaveData.Instance.m_WebDatas.Add(i_ID, new SaveData.WebData(SaveData.WebType.Int, i_Value));
	}

	public static void SetFloatSaveKey(string i_ID, float i_Value)
	{
		SaveData.Instance.m_WebDatas.Add(i_ID, new SaveData.WebData(SaveData.WebType.Float, i_Value));
	}

	public static void SetStringSaveKey(string i_ID, string i_Value)
	{
		SaveData.Instance.m_WebDatas.Add(i_ID, new SaveData.WebData(SaveData.WebType.String, i_Value));
	}
	#endregion
}