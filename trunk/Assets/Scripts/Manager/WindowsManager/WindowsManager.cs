using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WindowsManager : Singleton<WindowsManager> 
{
	protected override void Awake()
	{
		base.Awake();
	}

	public GameObject CreateWindow(string i_WindowName, Camera i_Camera)
	{
		Transform cameraCanvas = i_Camera.transform.GetChild(0);
		GameObject windowGO = (GameObject)Instantiate(Resources.Load<GameObject>(/*"Assets/Resources*/"Windows/" + i_WindowName/* + ".prefab"*/), 
		                                              i_Camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, -i_Camera.transform.position.z)), 
		                                              Quaternion.identity);
		windowGO.transform.SetParent(cameraCanvas, false);

		return windowGO;

	}
}
