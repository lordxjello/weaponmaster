using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuPopup : Window 
{
	private static MenuPopup m_Instance;
	public static MenuPopup Instance
	{
		get { return m_Instance; }
	}

	public Text m_EventTitle;
	public Text m_TimerText;

	protected override void Awake ()
	{
		base.Awake ();
		m_Instance = this;
	}

	public override void Close ()
	{
		base.Close ();
	}

	private void OnEnable () 
	{
	
	}

	private void Update () 
	{
	}

	public void OnClick_Chest()
	{
	}
}
