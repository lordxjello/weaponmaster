using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindowsManager : Singleton<WindowsManager> 
{
	protected override void Awake()
	{
		base.Awake();
	}

	public Window CreateWindow(string i_WindowName, Transform i_Canvas)
	{
		GameObject windowGO = (GameObject)Instantiate(Resources.Load<GameObject>("Windows/" + i_WindowName));
		windowGO.transform.SetParent(i_Canvas, false);

		return windowGO.GetComponent<Window>();
	}
}
