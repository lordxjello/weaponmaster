using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventPopup : Window 
{
	public Text m_EventTitle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick_Accept()
	{
		Close ();
		AdventureProgression.Instance.OnEventCompleted();
	}

	public void Setup(AdventureProgression.AdventureEvent i_Event, bool i_AdventureCompleted)
	{
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
