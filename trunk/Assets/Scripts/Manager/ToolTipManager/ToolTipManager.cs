using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToolTipManager : Singleton<ToolTipManager> 
{
	public class ToolTipInfo 
	{
		public string m_Name;
		public string m_Description;

		public ToolTipDisplay.Tag m_Tag;
	}

	public GameObject m_ToolTipGO;

	private bool m_ShowToolTip = false;
	private RectTransform m_ToolTipTransform;
	//private Vector2 m_ToolTipPosition;
	private Vector3 m_ToolTipPosition;
	private ToolTipInfo m_CurrentToolTipInfo = new ToolTipInfo();

	private Dictionary<ToolTipDisplay.Tag, ToolTipDisplay> m_ToolTipsDisplay;

	protected override void Awake()
	{
		base.Awake();

		m_ToolTipTransform = m_ToolTipGO.GetComponent<RectTransform>();
		m_ToolTipsDisplay = new Dictionary<ToolTipDisplay.Tag, ToolTipDisplay>();
	}
	
	void Start () 
	{
		ShowToolTip(false);
	}

	void Update () 
	{
	}

	private void LateUpdate()
	{
		if(m_ShowToolTip)
		{
			m_ToolTipPosition = RefManager.Instance.m_CameraAll.ScreenToWorldPoint(Input.mousePosition);
			m_ToolTipPosition.z = m_ToolTipTransform.position.z;
			m_ToolTipTransform.position = m_ToolTipPosition;
			
			if(Input.mousePosition.y >= Screen.height/2f)
			{
				m_ToolTipPosition = m_ToolTipTransform.anchoredPosition;
				m_ToolTipPosition.y -= m_ToolTipTransform.rect.height;
				m_ToolTipTransform.anchoredPosition = m_ToolTipPosition;
			}
		}
	}

	public void RegisterToolTipInfo(ToolTipDisplay i_Display)
	{
		if(!m_ToolTipsDisplay.ContainsKey(i_Display.m_DisplayTag))
		{
			m_ToolTipsDisplay.Add (i_Display.m_DisplayTag, i_Display);
		}
	}

	public void ShowToolTip(bool i_Enable, ToolTipInfo i_Info = null)
	{
		if(!i_Enable && i_Info != null && i_Info != m_CurrentToolTipInfo)
		{
			return;
		}

		m_ShowToolTip = i_Enable;
		m_ToolTipGO.SetActive(i_Enable);

		m_CurrentToolTipInfo = i_Info;

		if(i_Enable && i_Info != null)
		{
			m_ToolTipPosition = (Vector2)Input.mousePosition;
			m_ToolTipPosition.y -= m_ToolTipTransform.rect.height;
			m_ToolTipTransform.anchoredPosition = m_ToolTipPosition;

			DisplayByTag(i_Info);
		}
	}

	private void DisplayByTag(ToolTipInfo i_Info)
	{
		foreach(KeyValuePair<ToolTipDisplay.Tag, ToolTipDisplay> kvp in m_ToolTipsDisplay)
		{
			if(kvp.Key == i_Info.m_Tag)
			{
				kvp.Value.aGameObject.SetActive(true);
				switch(i_Info.m_Tag)
				{
				case ToolTipDisplay.Tag.Adventure:
					(kvp.Value as AdventureDisplay).Setup((AdventureProgression.AdventureInfo) i_Info);
					break;
				}
			}
			else
			{
				kvp.Value.aGameObject.SetActive(false);
			}
		}
	}
}
