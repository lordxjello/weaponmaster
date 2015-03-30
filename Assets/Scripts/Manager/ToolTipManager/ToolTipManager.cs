using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToolTipManager : Singleton<ToolTipManager> 
{
	public GameObject m_ToolTipGO;
	public Text m_FitterDisplay;
	public Text m_MessageDisplay;
	public Canvas m_ToolTipCanvas;

	private bool m_ShowToolTip = false;
	private RectTransform m_ToolTipTransform;
	//private Vector2 m_ToolTipPosition;
	private Vector3 m_ToolTipPosition;

	protected override void Awake()
	{
		base.Awake();

		m_ToolTipTransform = m_ToolTipGO.GetComponent<RectTransform>();
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
			UpdateToolTipPosition();
		}
	}
	public void ShowToolTip(bool i_Enable, string i_Message = null)
	{
		m_ShowToolTip = i_Enable;
		m_ToolTipGO.SetActive(i_Enable);

		if(i_Enable)
		{
			m_FitterDisplay.text = i_Message + "\n";
			m_MessageDisplay.text = i_Message;

			Invoke ("StartDisplay", 0.02f);
		}
		else
		{
			m_ToolTipCanvas.enabled = false;
			CancelInvoke("StartDisplay");
		}
	}

	private void StartDisplay()
	{
		m_ToolTipCanvas.enabled = true;
	}

	private void UpdateToolTipPosition()
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
