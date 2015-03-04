using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolTipManager : Singleton<ToolTipManager> 
{
	public GameObject m_ToolTipGO;

	private bool m_ShowToolTip = false;
	private RectTransform m_ToolTipTransform;
	private Vector2 m_ToolTipPosition;

	protected override void Awake()
	{
		base.Awake();

		m_ToolTipTransform = m_ToolTipGO.GetComponent<RectTransform>();
		ShowToolTip(false);
	}
	
	void Start () 
	{
		
	}

	void Update () 
	{
		if(m_ShowToolTip)
		{
			m_ToolTipPosition = (Vector2)Input.mousePosition;
			if(Input.mousePosition.y >= Screen.height/2f)
			{
				m_ToolTipPosition.y -= m_ToolTipTransform.rect.height;
			}
			m_ToolTipTransform.anchoredPosition = m_ToolTipPosition;
		}
	}

	public void ShowToolTip(bool i_Enable)
	{
		m_ShowToolTip = i_Enable;
		m_ToolTipGO.SetActive(i_Enable);

		if(i_Enable)
		{
			m_ToolTipPosition = (Vector2)Input.mousePosition;
			m_ToolTipPosition.y -= m_ToolTipTransform.rect.height;
			m_ToolTipTransform.anchoredPosition = m_ToolTipPosition;
		}
	}
}
