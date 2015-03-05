using UnityEngine;
using System.Collections;

public class ToolTipDisplay : Actor
{
	public enum Tag
	{
		Adventure = 0,
		Weapon,
		Armor
	}

	public Tag m_DisplayTag;

	protected virtual void Start()
	{
		ToolTipManager.Instance.RegisterToolTipInfo(this);
	}
}
