using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubMenu : MonoBehaviour
{
	public enum SubMenuType
	{
		Inventory = 0,
		Stats,
		Achievements,
		Options,
		Shop
	}

	[System.Serializable]
	public class SubMenuInfo
	{
		public SubMenuType m_Type;
		public Button m_Button;
		public Image m_Image;
	}

	public SubMenuType m_InitialSelected;
	public SubMenuInfo[] m_Infos;

	private int m_CurrentSelected = -1;

	private void Start()
	{
		for(int i = 0; i < m_Infos.Length; i++)
		{
			int buttonIndex = i;
			if(m_Infos[i].m_Type == m_InitialSelected)
			{
				ToggleButton(i);
			}
			m_Infos[i].m_Button.onClick.AddListener( () =>  {ToggleButton(buttonIndex); } );
		}
	}

	private void ToggleButton(int i_ButtonIndex)
	{
		if(m_CurrentSelected != i_ButtonIndex)
		{
			if(m_CurrentSelected >= 0) m_Infos[m_CurrentSelected].m_Image.color = Color.white;
			m_CurrentSelected = i_ButtonIndex;
			m_Infos[m_CurrentSelected].m_Image.color = Color.blue;
			MenuPopup.Instance.Setup(m_Infos[m_CurrentSelected].m_Type);
		}
	}

}
