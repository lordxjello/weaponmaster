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

	protected override void Awake ()
	{
		base.Awake ();
		ToolTipManager.Instance.RegisterToolTipInfo(this);
	}

	protected virtual void Start()
	{
	}
}
