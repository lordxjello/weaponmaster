using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuPopup : Window 
{
	private static MenuPopup m_Instance;
	public static MenuPopup Instance
	{
		get { return m_Instance; }
	}

	[System.Serializable]
	public class GenericDisplay
	{
		public GameObject m_DisplayGO;
	}

	[System.Serializable]
	public class InventoryDisplay : GenericDisplay
	{

	}
	
	[System.Serializable]
	public class StatsDisplay : GenericDisplay
	{
		
	}
	
	[System.Serializable]
	public class AchievementsDisplay : GenericDisplay
	{
		
	}
	
	[System.Serializable]
	public class OptionsDisplay : GenericDisplay
	{
		
	}
	
	[System.Serializable]
	public class ShopDisplay : GenericDisplay
	{
		
	}

	public Text m_EventTitle;

	public GenericDisplay m_InitialDisplay;
	
	[Header("INVENTORY DISPLAY")]
	public InventoryDisplay m_InventoryDisplay;
	[Header("STATS DISPLAY")]
	public InventoryDisplay m_StatsDisplay;
	[Header("ACHIEVEMENTS DISPLAY")]
	public InventoryDisplay m_AchievementsDisplay;
	[Header("OPTIONS DISPLAY")]
	public InventoryDisplay m_OptionsDisplay;
	[Header("SHOP DISPLAY")]
	public InventoryDisplay m_ShopDisplay;

	protected override void Awake ()
	{
		m_Instance = this;
		base.Awake ();
		//ToggleDisplay(m_InventoryDisplay);
	}

	public override void Close ()
	{
		base.Close ();
	}

	private void OnEnable () 
	{
		
	}

	private void Update () 
	{
	}

	public void Setup (SubMenu.SubMenuType i_Type)
	{
		m_EventTitle.text = i_Type.ToString();
		switch(i_Type)
		{
		case SubMenu.SubMenuType.Inventory:
			ToggleDisplay(m_InventoryDisplay);
			break;
		case SubMenu.SubMenuType.Stats:
			ToggleDisplay(m_StatsDisplay);
			break;
		case SubMenu.SubMenuType.Achievements:
			ToggleDisplay(m_AchievementsDisplay);
			break;
		case SubMenu.SubMenuType.Options:
			ToggleDisplay(m_OptionsDisplay);
			break;
		case SubMenu.SubMenuType.Shop:
			ToggleDisplay(m_ShopDisplay);
			break;
		}
	}

	#region DISPLAY INFO
	private void ToggleDisplay(GenericDisplay i_Display)
	{
		m_InventoryDisplay.m_DisplayGO.SetActive(i_Display == m_InventoryDisplay);
		m_StatsDisplay.m_DisplayGO.SetActive(i_Display == m_StatsDisplay);
		m_AchievementsDisplay.m_DisplayGO.SetActive(i_Display == m_AchievementsDisplay);
		m_OptionsDisplay.m_DisplayGO.SetActive(i_Display == m_OptionsDisplay);
		m_ShopDisplay.m_DisplayGO.SetActive(i_Display == m_ShopDisplay);
	}

	private void DisplayInventory()
	{

	}
	#endregion
}
