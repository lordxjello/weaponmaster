using UnityEngine;
using System.Collections;

public class SortingLayerModifier : Actor
{
	[SortingLayer]
	public string m_SortingLayer;
	public int m_SortingOrder = 0;

	private void OnEnable()
	{
		aRenderer.sortingLayerName = m_SortingLayer;
		aRenderer.sortingOrder = m_SortingOrder;
	}
}
