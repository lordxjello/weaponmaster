using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdventureSelectionButton : Actor
{
	public Button m_Button;

	public Text m_Location;
	public Text m_CVValue;
	public Text m_LootValue;

	private AdventureProgression.AdventureInfo m_AdventureInfo;
	public AdventureProgression.AdventureInfo AdventureInfo
	{
		get { return m_AdventureInfo; }
	}

	private void OnDisable()
	{
		ToolTipManager.Instance.ShowToolTip(false, m_AdventureInfo);
	}

	public void SetClickAction(UnityEngine.Events.UnityAction i_ClickEvent)
	{
		m_Button.onClick.AddListener(i_ClickEvent);
	}

	public void Setup()
	{
		m_AdventureInfo = new AdventureProgression.AdventureInfo();
		m_AdventureInfo.m_Name = "Test Location";
		m_AdventureInfo.m_Description = "That's actually a cool place!";
		m_AdventureInfo.m_CVValue = Random.Range(50f, 10000f);
		m_AdventureInfo.m_LootValue = Random.Range(50f, 10000f);

		m_Location.text = m_AdventureInfo.m_Name;
		m_CVValue.text = m_AdventureInfo.m_CVValue.ToString("F1");
		m_LootValue.text = m_AdventureInfo.m_LootValue.ToString("F1");
	}

	public void OnPointerEnter()
	{
		ToolTipManager.Instance.ShowToolTip(true, m_AdventureInfo);
	}

	public void OnPointerExit()
	{
		ToolTipManager.Instance.ShowToolTip(false);
	}
}
