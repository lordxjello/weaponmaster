using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryManager : Singleton<InventoryManager> 
{
	public GameObject m_ItemButton;

	protected override void Awake()
	{
		base.Awake();
	}
	
	void Start () 
	{
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(1))
		{
			AddItem();
		}
	}

	public void AddItem()
	{
		GameObject itemGO = (GameObject)Instantiate(m_ItemButton);
		itemGO.transform.SetParent(RefManager.Instance.m_InventoryContainer, false);
	}
}
