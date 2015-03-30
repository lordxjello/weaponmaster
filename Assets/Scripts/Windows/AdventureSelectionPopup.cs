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

	[Header("EASY")]
	public AdventureSelectionButton m_EasyButton;
	public string 					m_EasyDescription;

	[Header("MEDIUM")]
	public AdventureSelectionButton m_MediumButton;
	public string 					m_MediumDescription;

	[Header("HARD")]
	public AdventureSelectionButton m_HardButton;
	public string 					m_HardDescription;

	[Header("EXPERT")]
	public AdventureSelectionButton m_ExpertButton;
	public string 					m_ExpertDescription;

	[Header("BOSS")]
	public AdventureSelectionButton m_FightButton;
	public string 					m_FightDescription;

	public int m_NbOfAdventures = 4;
	public Transform m_ButtonsContainer;
	public GameObject m_AdventureSelectionButton;

	public Text m_DebugText;

	private bool m_AdventureSelected = false;
	private AdventureSelectionButton m_CurrentButton;

	protected override void Awake () 
	{
		m_Instance = this;

		base.Awake();
		Setup ();
		SetupButtons();
	}

	private void OnEnable()
	{
		m_AdventureSelected = false;
		m_DebugText.text = CharacterManager.Instance.HP.ToString();
	}

	public override void Close ()
	{
		Show (false);
	}

	private void Update () 
	{
	}

	private void Show(bool i_Show)
	{
		aGameObject.SetActive(i_Show);
	}

	private void SetupButtons()
	{
		// Save Current Button???
		m_CurrentButton = m_EasyButton;
		m_EasyButton.ToggleSelected();

		m_EasyButton.SetClickAction( () => {OnClick_Accept(m_EasyButton);} );
		m_EasyButton.m_Message = m_EasyDescription;

		m_MediumButton.SetClickAction( () => {OnClick_Accept(m_MediumButton);} );
		m_MediumButton.m_Message = m_MediumDescription;

		m_HardButton.SetClickAction( () => {OnClick_Accept(m_HardButton);} );
		m_HardButton.m_Message = m_HardDescription;

		m_ExpertButton.SetClickAction( () => {OnClick_Accept(m_ExpertButton);} );
		m_ExpertButton.m_Message = m_ExpertDescription;

		m_FightButton.SetClickAction( () => {OnClick_Accept(m_FightButton);} );
		m_FightButton.m_Message = m_ExpertDescription;
	}

	public void Setup()
	{
		Show(true);
	}

	public void OnClick_Accept(AdventureSelectionButton i_Button)
	{
		if(m_CurrentButton != i_Button)
		{
			m_CurrentButton.ToggleSelected();
			m_CurrentButton = i_Button;
			m_CurrentButton.ToggleSelected();
		}
	}

}
