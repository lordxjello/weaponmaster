using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventLootPopup : Window 
{
	private static EventLootPopup m_Instance;
	public static EventLootPopup Instance
	{
		get { return m_Instance; }
	}

	public Text m_EventTitle;
	public Text m_TimerText;
	public float m_TimeAutoSelect = 5f;

	private bool m_Clicked = false;
	private float m_Timer = 0f;

	protected override void Awake ()
	{
		base.Awake ();
		m_Instance = this;
	}

	public override void Close ()
	{
		m_Clicked = false;
		base.Close ();
	}

	private void OnEnable () 
	{
	
	}

	void Update () 
	{
		if(m_Timer > 0f)
		{
			m_Timer -= Time.deltaTime;
			m_TimerText.text = Mathf.CeilToInt(m_Timer).ToString("00");
		}
		else if (!m_Clicked)
		{
			m_Timer = 0f;
			OnClick_Chest();
		}
	}

	public void OnClick_Chest()
	{
		if(!m_Clicked)
		{
			m_TimerText.text = "";
			m_Clicked = true;
			Close ();
			AdventureProgression.Instance.OnEventCompleted();
		}
	}

	public void Setup(AdventureProgression.AdventureEvent i_Event, bool i_AdventureCompleted)
	{
		m_Timer = m_TimeAutoSelect;

		if(i_AdventureCompleted)
		{
			m_EventTitle.text = "ADVENTURE COMPLETED!";
		}
		else
		{
			m_EventTitle.text = i_Event.ToString();
		}
	}
}
