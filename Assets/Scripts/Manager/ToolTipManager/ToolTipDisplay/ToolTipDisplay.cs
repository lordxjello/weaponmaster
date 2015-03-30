using UnityEngine;
using System.Collections;

public class ToolTipDisplay : Actor
{
	[HideInInspector]
	public string m_Message;

	public virtual void OnDisable()
	{
		ToolTipManager.Instance.ShowToolTip(false);
	}
	
	public virtual void OnPointerEnter()
	{
		ToolTipManager.Instance.ShowToolTip(true, m_Message);
	}
	
	public virtual void OnPointerExit()
	{
		ToolTipManager.Instance.ShowToolTip(false);
	}
}
