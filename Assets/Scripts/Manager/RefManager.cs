using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefManager : Singleton<RefManager> 
{
	[Header("CAMERAS")]
	public Camera m_CameraTop;
	public Camera m_CameraRight;
	public Camera m_CameraLeft;
	public Camera m_CameraAll;

	[Header("CANVAS")]
	public Transform m_CanvasTop;
	public Transform m_CanvasRight;
	public Transform m_CanvasLeft;
	public Transform m_CanvasAll;

	protected override void Awake()
	{
		base.Awake();
	}
	
	void Start () {
		
	}

	void Update () {
		
	}
}
