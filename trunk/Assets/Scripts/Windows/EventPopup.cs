using UnityEngine;
using System.Collections;

public class EventPopup : Window 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick_Accept()
	{
		Close ();
		AdventureProgression.Instance.OnEventCompleted();
	}
}
