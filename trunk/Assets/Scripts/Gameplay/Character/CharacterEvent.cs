using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterEvent : Actor 
{
	private static CharacterEvent m_Instance;
	public static CharacterEvent Instance
	{
		get { return m_Instance; }
	}

	public Image m_HPMeter;
	public float m_HPDecrementSpeed;

	private float m_HPPercentage;

	private int m_TargetedEnemyIndex;
	private float m_AttackTimer = 0f;

	protected override void Awake ()
	{
		base.Awake ();
		m_Instance = this;
	}

	private void Kill()
	{
		aGameObject.SetActive(false);
	}

	private void Update () 
	{
		if(AdventureProgression.Instance.EventEnemyStart)
		{
			m_HPMeter.fillAmount = Mathf.Lerp(m_HPMeter.fillAmount, m_HPPercentage, m_HPDecrementSpeed * Time.deltaTime);
			// TODO Get Real attack speed value
			m_AttackTimer += Time.deltaTime;
			if(m_AttackTimer >= 1f)
			{
				m_AttackTimer = 0f;
				AdventureProgression.Instance.Enemies[m_TargetedEnemyIndex].ReceiveDamage();
			}
		}
	}

	private void CheckHP()
	{
		/*
		m_HPPercentage = (float)m_Data.m_HP/(float)m_Data.m_InitialHP;
		if(m_Data.m_HP <= 0)
		{
			Kill ();
		}
		*/
	}
	
	private void GetAliveEnemy()
	{
		for(int i = 0; i < AdventureProgression.Instance.Enemies.Count; i++)
		{
			if(AdventureProgression.Instance.Enemies[i].IsAlive)
			{
				m_TargetedEnemyIndex = i;
			}
		}
	}

	public void Setup()
	{
		aGameObject.SetActive(true);
		m_HPPercentage = 1f;
		m_HPMeter.fillAmount = 1f;
		m_AttackTimer = 0f;
		GetAliveEnemy();

		// TODO Adjust real value

		//CharacterManager.Instance.
		//m_Data.m_HP = Random.Range (1, 7);
		//m_Data.m_InitialHP = m_Data.m_HP;
	}

	public void OnEnemyDeath()
	{
		GetAliveEnemy();
	}
}
