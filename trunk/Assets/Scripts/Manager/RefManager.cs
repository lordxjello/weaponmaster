using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefManager : Singleton<RefManager> 
{
	[Header("CAMERAS")]
	public Camera m_CameraAll;

	[Header("CANVAS")]
	public Transform m_CanvasAll;
	public Transform m_CanvasTop;
	public Transform m_CanvasLeft;
	public Transform m_CanvasRight;

	protected override void Awake()
	{
		base.Awake();
	}
	
	void Start () 
	{
	}

	void Update () 
	{
	}
}
