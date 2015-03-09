using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WindowsManager : Singleton<WindowsManager> 
{
	public enum ReusableWindowName
	{
		EventEnemiesPopup = 0,
		EventLootPopup = 1
	}

	[System.Serializable]
	public class ReusableWindow
	{
		public ReusableWindowName m_ID;
		public Window m_Window;
		public bool m_EnableOnStart = false;
	}

	public ReusableWindow[] m_ReusableWindows;

	private Dictionary<ReusableWindowName, Window> m_ReusableWindowsList;

	protected override void Awake()
	{
		base.Awake();

		m_ReusableWindowsList = new Dictionary<ReusableWindowName, Window>();
		for(int i = 0; i < m_ReusableWindows.Length; i++)
		{
			m_ReusableWindows[i].m_Window.aGameObject.SetActive(m_ReusableWindows[i].m_EnableOnStart);
			m_ReusableWindowsList.Add (m_ReusableWindows[i].m_ID, m_ReusableWindows[i].m_Window);
		}
	}

	public Window CreateWindow(string i_WindowName, Transform i_Canvas)
	{
		GameObject windowGO = (GameObject)Instantiate(Resources.Load<GameObject>("Windows/" + i_WindowName));
		windowGO.transform.SetParent(i_Canvas, false);

		return windowGO.GetComponent<Window>();
	}
	
	public Window EnableWindow(ReusableWindowName i_WindowName)
	{
		m_ReusableWindowsList[i_WindowName].aGameObject.SetActive(true);
		return m_ReusableWindowsList[i_WindowName];
	}
}
