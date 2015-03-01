using UnityEngine;
using System.Collections;

public class Window : Actor
{
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected virtual void Close()
	{
		Destroy(gameObject);
	}
}
