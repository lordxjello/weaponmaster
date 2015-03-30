using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EventEnemiesPopup : Window 
{
	private static EventEnemiesPopup m_Instance;
	public static EventEnemiesPopup Instance
	{
		get { return m_Instance; }
	}

	public Text m_EventTitle;

	public Enemy[] m_Enemies;

	private List<int> m_EnemiesToAppear = new List<int>();

	protected override void Awake ()
	{
		base.Awake ();
		m_Instance = this;
	}

	private void OnEnable () 
	{
		Reset ();
	}

	private void Update () 
	{
	
	}

	private void Reset()
	{
		m_EnemiesToAppear.Clear();
		for(int i = 0; i < m_Enemies.Length; i++)
		{
			m_Enemies[i].aGameObject.SetActive(false);
			m_EnemiesToAppear.Add (i);
		}
	}

	public void OnClick_Accept()
	{
		Close ();
	}

	public void Setup()
	{
		int randomAppear = Random.Range(1, m_Enemies.Length+1);
		int randomIndex;

		for(int i = 0; i < randomAppear; i++)
		{
			randomIndex = Random.Range (0, m_EnemiesToAppear.Count);
			m_Enemies[m_EnemiesToAppear[randomIndex]].Setup();
			m_EnemiesToAppear.RemoveAt(randomIndex);
		}
	}
}
