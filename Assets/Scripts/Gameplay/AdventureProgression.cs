using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdventureProgression : Singleton<AdventureProgression>
{
	public enum AdventureEvent
	{
		Enemies = 0,
		Treasure,
		Mystery,
		RandomEvent // -> Must be last (Like 'Count')
	}

	public delegate void AdventureEventCallback(AdventureEvent i_Event, bool i_AdventureCompleted);
	public AdventureEventCallback m_OnEventReached;

	[Header("CONTAINERS")]
	public Transform m_CharacterTransform;
	public LineRenderer m_CharacterTrail;

	[Header("TWEAKABLE")]
	public float m_ProgressionSpeed = 5f;

	[HideInInspector]
	public bool m_StopProgression = false;

	[HideInInspector]
	public bool m_AdventureSelected = false;

	#region ADVENTURE EVENT Vars
	private Vector3 m_NextEventPosition;
	private AdventureEvent m_NextEventType;
	private bool m_AdventureCompleted;
	#endregion

	#region MONO Methods
	private void Start () 
	{
		Reset ();
	}

	private void Update () 
	{
		if(!m_StopProgression && m_AdventureSelected)
		{			
			m_CharacterTransform.position = Vector3.MoveTowards(m_CharacterTransform.position, m_NextEventPosition, Time.deltaTime * m_ProgressionSpeed);
			m_CharacterTrail.SetPosition(1, new Vector3(m_CharacterTransform.position.x, m_CharacterTransform.position.y, m_CharacterTransform.position.z +0.01f));
			
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
		EventPopup popup = (EventPopup)WindowsManager.Instance.CreateWindow("EventPopup", RefManager.Instance.m_CanvasLeft);
		popup.Setup(i_CurrentEvent, m_AdventureCompleted);
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
		return RefManager.Instance.m_CameraTop.ViewportToWorldPoint(new Vector3(0.05f, 0.5f, -RefManager.Instance.m_CameraTop.transform.position.z));
	}

	private Vector3 GetProgressionEnd()
	{
		return RefManager.Instance.m_CameraTop.ViewportToWorldPoint(new Vector3(0.95f, 0.5f, -RefManager.Instance.m_CameraTop.transform.position.z));
	}
	#endregion

	#region PUBLIC Methods
	public void OnEventCompleted()
	{
		if(m_AdventureCompleted)
		{
			AdventureSelectionPopup.Instance.Setup();
		}
		else
		{
			m_StopProgression = false;
			SetNextEvent(1f, 5f);
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

	public void Reset()
	{
		m_StopProgression = false;
		m_AdventureSelected = false;
		m_AdventureCompleted = false;

		m_CharacterTransform.position = GetProgressionStart();
		
		m_CharacterTrail.SetVertexCount(2);
		m_CharacterTrail.SetPosition(0, m_CharacterTransform.position);

		SetNextEvent(GetDistancePercentage(0.5f), GetDistancePercentage(0.5f));
	}
	#endregion
}
