using UnityEngine;
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

	public delegate void AdventureEventCallback(AdventureEvent i_Event);
	public AdventureEventCallback m_OnEventReached;

	public Transform m_CharacterTransform;
	public LineRenderer m_CharacterTrail;
	public float m_ProgressionSpeed = 5f;
	
	[HideInInspector]
	public bool m_StopProgression = false;

	#region ADVENTURE EVENT Vars
	private Vector3 m_NextEventPosition;
	private AdventureEvent m_NextEventType;
	#endregion

	#region MONO Methods
	private void Start () 
	{
		Vector3 newPos = RefManager.Instance.m_CameraTop.ViewportToWorldPoint(new Vector3(0.05f, 0.5f, -RefManager.Instance.m_CameraTop.transform.position.z));
		m_CharacterTransform.position = newPos;

		m_CharacterTrail.SetVertexCount(2);
		m_CharacterTrail.SetPosition(0, m_CharacterTransform.position);

		newPos.x = Mathf.Abs(RefManager.Instance.m_CameraTop.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -RefManager.Instance.m_CameraTop.transform.position.z)).x - m_CharacterTransform.position.x);
		SetNextEvent(newPos.x, newPos.x);
	}

	private void Update () 
	{
		if(!m_StopProgression)
		{			
			m_CharacterTransform.position = Vector3.MoveTowards(m_CharacterTransform.position, m_NextEventPosition, Time.deltaTime * m_ProgressionSpeed);
			m_CharacterTrail.SetPosition(1, new Vector3(m_CharacterTransform.position.x, m_CharacterTransform.position.y, m_CharacterTransform.position.z +0.01f));
			
			if(Mathf.Abs (m_CharacterTransform.position.x - m_NextEventPosition.x) <= 0.001f)
			{
				OnEventReached();
			}
		}
	}
	#endregion

	#region PRIVATE Methods
	private void OnEventReached()
	{
		if(m_OnEventReached != null) m_OnEventReached(m_NextEventType);

		WindowsManager.Instance.CreateWindow("EventPopup", RefManager.Instance.m_CameraLeft);
		Debug.Log("Distance: " + m_NextEventPosition.x.ToString() + " | " + m_NextEventType.ToString());
		m_StopProgression = true;
	}
	#endregion

	#region PUBLIC Methods
	public void OnEventCompleted()
	{
		m_StopProgression = false;
		SetNextEvent(1f, 5f);
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
	}
	#endregion
}
