using UnityEngine;
using System.Collections;

public class Window : Actor
{
	public bool m_IsReusable = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Close()
	{
		if(m_IsReusable)
		{
			aGameObject.SetActive(false);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
