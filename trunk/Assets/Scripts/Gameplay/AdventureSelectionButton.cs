using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdventureSelectionButton : Actor
{
	public Button m_Button;

	public Text m_Location;
	public Text m_CVValue;
	public Text m_LootValue;

	public void SetClickAction(UnityEngine.Events.UnityAction i_ClickEvent)
	{
		m_Button.onClick.AddListener(i_ClickEvent);
	}

	public void Setup()
	{
		m_Location.text = "Test Location";
		m_CVValue.text = Random.Range(50f, 10000f).ToString("F1");
		m_LootValue.text = Random.Range(50f, 10000f).ToString("F1");
	}

	public void OnPointerEnter()
	{
		Debug.Log ("ON POINTER ENTER");
		ToolTipManager.Instance.ShowToolTip(true);
	}

	public void OnPointerExit()
	{
		Debug.Log ("ON POINTER EXIT");
		ToolTipManager.Instance.ShowToolTip(false);
	}
}
