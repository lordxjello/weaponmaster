using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdventureDisplay : ToolTipDisplay 
{
	public Text m_Location;
	public Text m_Description;

	public AdventureDisplay()
	{
		m_DisplayTag = Tag.Adventure;
	}

	public void Setup(AdventureProgression.AdventureInfo i_AdventureInfo)
	{
		m_Location.text = i_AdventureInfo.m_Name;
		m_Description.text = i_AdventureInfo.m_Description;
	}
}
