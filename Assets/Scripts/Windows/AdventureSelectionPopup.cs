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

	private List<AdventureSelectionButton> m_AdventureSelectionButtons;	
	protected override void Awake () 
	{
		m_Instance = this;

		base.Awake();
		AdventureProgression.Instance.m_AdventureSelected = false;
		CreateButtons ();
		Setup ();

		SaveGameManager.LoadWeb();
	}

	protected override void Close ()
	{
		Show (false);
		AdventureProgression.Instance.Reset();
		AdventureProgression.Instance.m_AdventureSelected = true;
	}

	private void Update () 
	{
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
		SaveData.Current.CharacterCV = 50f;
		SaveGameManager.SaveWeb();

		Close ();
	}

}
