using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : Singleton<HUDManager> 
{
	[Header("TOP CAMERA HUD")]
	public Text m_ProgressionPercentage;

	protected override void Awake()
	{
		base.Awake();
	}

	private void Update ()
	{
		
	}
	
	#region TOP CAMERA HUD
	public void SetProgressionText(float i_Value)
	{
		int value = Mathf.FloorToInt(i_Value * 100);
		m_ProgressionPercentage.text = value.ToString() + "%";
	}

	public void ShowPercentage(bool i_Enable)
	{
		m_ProgressionPercentage.gameObject.SetActive(i_Enable);
	}
	#endregion

	#region RIGHT CAMERA HUD
	
	#endregion

	#region LEFT CAMERA HUD
	
	#endregion
}
