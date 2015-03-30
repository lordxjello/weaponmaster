using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdventureSelectionButton : ToolTipDisplay
{
	public Button m_Button;
	public GameObject m_SelectedGO;

	private bool m_IsSelected;

	public void ToggleSelected()
	{
		m_IsSelected = !m_IsSelected;
		m_SelectedGO.SetActive(m_IsSelected);
	}

	public void SetClickAction(UnityEngine.Events.UnityAction i_ClickEvent)
	{
		m_Button.onClick.AddListener(i_ClickEvent);
	}
}
