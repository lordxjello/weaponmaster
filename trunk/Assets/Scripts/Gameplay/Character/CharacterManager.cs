using UnityEngine;
using System.Collections;

public class CharacterManager : Singleton<CharacterManager> 
{
	public GeneralStats m_Stats = new GeneralStats();

	protected override void Awake ()
	{
		base.Awake ();
		SetupSaveData();
	}

	private void Start () 
	{
	
	}
	
	// Update is called once per frame
	private void Update () 
	{
	
	}

	private void SetupSaveData()
	{
		SaveGameManager.SetStringSaveKey(SaveData.SaveKey.HP.ToString() + SaveData.Instance.m_SaveIndex.ToString(), m_Stats.m_HP.ToString());
	}

	#region GETTERS
	public System.UInt64 HP
	{
		get { return System.UInt64.Parse(SaveData.Instance.m_WebDatas[SaveData.SaveKey.HP.ToString() + SaveData.Instance.m_SaveIndex.ToString()].m_StringValue); }
		set 
		{ 
			string key = SaveData.SaveKey.HP.ToString() + SaveData.Instance.m_SaveIndex.ToString();
			SaveData.Instance.m_WebDatas[key].m_StringValue = value.ToString(); 
			SaveGameManager.SaveWebByData(key, SaveData.Instance.m_WebDatas[key]);
		}
	}
	#endregion
}
