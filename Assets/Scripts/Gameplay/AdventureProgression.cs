using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AdventureProgression : Singleton<AdventureProgression>
{
	public enum AdventureEvent
	{
		Enemies = 0,
		Loot,
		//Mystery,
		RandomEvent // -> Must be last (Like 'Count')
	}

	public class AdventureInfo : ToolTipManager.ToolTipInfo
	{
		public float m_CVValue = 0f;
		public float m_LootValue = 0f;

		public AdventureInfo() 
		{
			m_Tag = ToolTipDisplay.Tag.Adventure;
		}
	}

	public delegate void AdventureEventCallback(AdventureEvent i_Event, bool i_AdventureCompleted);
	public AdventureEventCallback m_OnEventReached;

	[Header("CONTAINERS")]
	public GameObject m_CharacterGO;
	public Transform m_CharacterTransform;
	public LineRenderer m_CharacterTrail;

	[Header("TWEAKABLE")]
	public float m_ProgressionSpeed = 5f;

	[HideInInspector]
	public bool m_StopProgression = false;

	[HideInInspector]
	public bool m_AdventureSelected = false;

	private bool m_EventEnemyStart = false;
	public bool EventEnemyStart
	{
		get { return m_EventEnemyStart; }
	}

	#region ADVENTURE EVENT Vars
	private Vector3 m_NextEventPosition;
	private AdventureEvent m_NextEventType;
	private bool m_AdventureCompleted;
	#endregion

	#region ENEMIES Vars
	private List<Enemy> m_Enemies = new List<Enemy>();
	public List<Enemy> Enemies
	{
		get { return m_Enemies; }
	}
	#endregion

	#region MONO Methods
	private void Start () 
	{
		Reset ();
		m_CharacterGO.SetActive(false);
		HUDManager.Instance.ShowPercentage(false);
	}

	private void Update () 
	{
		if(!m_StopProgression && m_AdventureSelected)
		{			
			m_CharacterTransform.position = Vector3.MoveTowards(m_CharacterTransform.position, m_NextEventPosition, Time.deltaTime * m_ProgressionSpeed);
			m_CharacterTrail.SetPosition(1, m_CharacterTransform.position);
			
			if(Mathf.Abs (m_CharacterTransform.position.x - m_NextEventPosition.x) <= 0.001f)
			{
				OnEventReached(m_NextEventType);
			}

			HUDManager.Instance.SetProgressionText(GetProgressionPercentage());
		}
	}
	#endregion

	#region PRIVATE Methods
	private void OnEventReached(AdventureEvent i_CurrentEvent)
	{
		m_StopProgression = true;

		if(m_OnEventReached != null) m_OnEventReached(i_CurrentEvent, m_AdventureCompleted);

		if(m_AdventureCompleted || i_CurrentEvent == AdventureEvent.Loot)
		{
			EventLootPopup lootPopup = (EventLootPopup)WindowsManager.Instance.EnableWindow(WindowsManager.ReusableWindowName.EventLootPopup);
			lootPopup.Setup(i_CurrentEvent, m_AdventureCompleted);
		}
		else
		{
			switch(i_CurrentEvent)
			{
			case AdventureEvent.Enemies:
				EventEnemiesPopup EnemiesPopup = (EventEnemiesPopup)WindowsManager.Instance.EnableWindow(WindowsManager.ReusableWindowName.EventEnemiesPopup);
				EnemiesPopup.Setup();
				m_EventEnemyStart = true;
				break;
			}
		}
	}

	private void OnEnemiesCleared()
	{
		m_EventEnemyStart = false;
		m_StopProgression = false;
		EventEnemiesPopup.Instance.Close();
		SetNextEvent(GetDistancePercentage(0.02f), GetDistancePercentage(0.15f));
	}

	private float GetDistancePercentage(float i_Percentage)
	{
		return GetProgressionLineWidth() * i_Percentage;
	}

	private float GetProgressionLineWidth()
	{
		return Mathf.Abs(GetProgressionStart().x) + Mathf.Abs(GetProgressionEnd().x);
	}

	private float GetProgressionPercentage()
	{
		return Mathf.Abs((m_CharacterTransform.position.x - GetProgressionStart().x)) / GetProgressionLineWidth();
	}

	private Vector3 GetProgressionStart()
	{
		return RefManager.Instance.m_CameraAll.ViewportToWorldPoint(new Vector3(0.05f, 0.9f, -RefManager.Instance.m_CameraAll.transform.position.z));
	}

	private Vector3 GetProgressionEnd()
	{
		return RefManager.Instance.m_CameraAll.ViewportToWorldPoint(new Vector3(0.95f, 0.9f, -RefManager.Instance.m_CameraAll.transform.position.z));
	}
	#endregion

	#region PUBLIC Methods
	// EVENTS
	public void OnAdventureSelected(AdventureInfo i_Info)
	{
		m_AdventureSelected = true;
	}

	public void OnEventCompleted()
	{
		if(m_AdventureCompleted)
		{
			AdventureSelectionPopup.Instance.Setup();
			m_CharacterGO.SetActive(false);
			HUDManager.Instance.ShowPercentage(false);
		}
		else
		{
			m_StopProgression = false;
			SetNextEvent(GetDistancePercentage(0.02f), GetDistancePercentage(0.15f));
		}
	}

	public void SetNextEvent(float i_MinDistance, float i_MaxDistance, AdventureEvent i_ForceEvent = AdventureEvent.RandomEvent)
	{
		m_NextEventPosition = m_CharacterTransform.position;
		m_NextEventPosition.x += Random.Range (i_MinDistance, i_MaxDistance);
		if(i_ForceEvent != AdventureEvent.RandomEvent)
		{
			m_NextEventType = i_ForceEvent;
		}
		else
		{
			m_NextEventType = (AdventureEvent)Random.Range (0, (int)AdventureEvent.RandomEvent);
		}

		if(m_NextEventPosition.x >= GetProgressionEnd().x)
		{
			m_AdventureCompleted = true;
			m_NextEventPosition.x = GetProgressionEnd().x;
		}
	}

	//ENEMIES
	public void RegisterEnemy(Enemy i_Enemy)
	{
		m_Enemies.Add (i_Enemy);
	}

	public void UnregisterEnemy(Enemy i_Enemy)
	{
		m_Enemies.Remove (i_Enemy);

		if(m_Enemies.Count == 0)
		{
			OnEnemiesCleared();
		}
	}
	// UTILS
	public void Reset()
	{
		m_StopProgression = false;
		m_AdventureSelected = false;
		m_AdventureCompleted = false;

		m_CharacterGO.SetActive(true);
		HUDManager.Instance.ShowPercentage(true);
		m_CharacterTransform.position = GetProgressionStart();
		
		m_CharacterTrail.SetVertexCount(2);
		m_CharacterTrail.SetPosition(0, m_CharacterTransform.position);
		m_CharacterTrail.SetPosition(1, m_CharacterTransform.position);
		
		SetNextEvent(GetDistancePercentage(0.02f), GetDistancePercentage(0.15f));
	}
	#endregion
}
