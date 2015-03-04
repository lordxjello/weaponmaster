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
		foreach(KeyValuePair<string, SaveData.WebData> kvp in SaveData.WebDatas)
		{
			switch(kvp.Value.m_Type)
			{
			case SaveData.WebType.Float:
				PlayerPrefs.SetFloat(kvp.Key, (float)kvp.Value.m_FloatValue);
				break;
			case SaveData.WebType.Int:
				PlayerPrefs.SetInt(kvp.Key, (int)kvp.Value.m_IntValue);
				break;
			case SaveData.WebType.String:
				PlayerPrefs.SetString(kvp.Key, (string)kvp.Value.m_StringValue);
				break;
			}
		}
	}   
	
	public static void LoadWeb() 
	{
		if(SaveData.Current == null)
		{
			SaveData.Current = new SaveData();
		}

		foreach(KeyValuePair<string, SaveData.WebData> kvp in SaveData.WebDatas)
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
				kvp.Value.m_StringValue = PlayerPrefs.GetString(kvp.Key);
				break;
			}
		}
	}
	#endregion
}