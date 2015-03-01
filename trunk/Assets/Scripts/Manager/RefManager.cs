using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefManager : Singleton<RefManager> 
{
	public Camera m_CameraTop;
	public Camera m_CameraRight;
	public Camera m_CameraLeft;

	protected override void Awake()
	{
		base.Awake();
	}
	
	void Start () {
		
	}

	void Update () {
		
	}
}
