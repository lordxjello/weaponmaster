using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AdventureSelectionPopup : Window 
{
	private static AdventureSelectionPopup m_Instance;
	public static AdventureSelectionPopup Instance
	{
		get { return m_Instance; }
	}

	public int m_NbOfAdventures = 4;
	public Transform m_ButtonsContainer;
	public GameObject m_AdventureSelectionButton;

	public Text m_TimerText;
	public float m_TimeAutoSelect = 10f;
	public Text m_DebugText;

	private float m_Timer;
	private bool m_AdventureSelected = false;

	private List<AdventureSelectionButton> m_AdventureSelectionButtons;	
	protected override void Awake () 
	{
		m_Instance = this;

		base.Awake();
		AdventureProgression.Instance.m_AdventureSelected = false;
		CreateButtons ();
		Setup ();
	}

	private void OnEnable()
	{
		m_AdventureSelected = false;
		m_Timer = m_TimeAutoSelect;
		m_TimerText.text = Mathf.RoundToInt(m_Timer).ToString("F1");
		m_DebugText.text = CharacterManager.Instance.HP.ToString();
	}

	public override void Close ()
	{
		AdventureProgression.Instance.Reset();
		Show (false);
	}

	private void Update () 
	{
		if(m_Timer > 0f)
		{
			m_Timer -= Time.deltaTime;
			m_TimerText.text = Mathf.CeilToInt(m_Timer).ToString("00");
		}
		else if (!m_AdventureSelected)
		{
			m_Timer = 0f;
			m_TimerText.text = "";
			int randomAdventure = Random.Range(0, m_NbOfAdventures);
			OnClick_Accept(m_AdventureSelectionButtons[randomAdventure]);
		}
	}

	private void CreateButtons()
	{
		GameObject buttonGo;
		m_AdventureSelectionButtons = new List<AdventureSelectionButton>();
		for(int i = 0; i < m_NbOfAdventures; i++)
		{
			buttonGo = (GameObject)Instantiate(m_AdventureSelectionButton);
			buttonGo.transform.SetParent(m_ButtonsContainer, false);
			AdventureSelectionButton button = buttonGo.GetComponent<AdventureSelectionButton>();
			button.SetClickAction( () => {OnClick_Accept(button); } );
			m_AdventureSelectionButtons.Add(button);
		}
	}

	private void Show(bool i_Show)
	{
		aGameObject.SetActive(i_Show);
	}

	public void Setup()
	{
		Show(true);
		for(int i = 0; i < m_AdventureSelectionButtons.Count; i++)
		{
			m_AdventureSelectionButtons[i].Setup();
		}
	}

	
	public void OnClick_Accept(AdventureSelectionButton i_Button)
	{
		if(!m_AdventureSelected)
		{
			m_AdventureSelected = true;
			CharacterManager.Instance.HP = 100;

			Close ();
			AdventureProgression.Instance.OnAdventureSelected(i_Button.AdventureInfo);
		}
	}

}
