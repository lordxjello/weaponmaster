using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : Actor 
{
	public class EnemyData
	{
		public int m_CVValue;
		public int m_HP;
		public int m_InitialHP;
		//public int m_Strength;
		//public int m_Defense;
	}

	public Image m_HPMeter;
	public float m_HPDecrementSpeed;

	private float m_HPPercentage;

	private bool m_IsAlive = false;
	public bool IsAlive
	{
		get { return m_IsAlive; }
	}

	private EnemyData m_Data = new EnemyData();
	public EnemyData Data
	{
		get { return m_Data; }
	}

	protected override void Awake ()
	{
		base.Awake ();
	}

	private void Kill()
	{
		m_IsAlive = false;
		aGameObject.SetActive(false);
	}

	private void Update () 
	{
		m_HPMeter.fillAmount = Mathf.Lerp(m_HPMeter.fillAmount, m_HPPercentage, m_HPDecrementSpeed * Time.deltaTime);
	}

	private void CheckHP()
	{
		m_HPPercentage = (float)m_Data.m_HP/(float)m_Data.m_InitialHP;
		if(m_Data.m_HP <= 0)
		{
			Kill ();
		}
	}

	public void Setup()
	{
		//AdventureProgression.Instance.RegisterEnemy(this);
		aGameObject.SetActive(true);
		m_HPPercentage = 1f;
		m_HPMeter.fillAmount = 1f;
		m_IsAlive = true;

		// TODO Adjust real enemy value
		m_Data.m_HP = Random.Range (1, 7);
		m_Data.m_InitialHP = m_Data.m_HP;
	}

	public void OnClick()
	{
		ReceiveDamage();
	}

	public void ReceiveDamage()
	{
		m_Data.m_HP -= 1;
		
		CheckHP();
	}
}
