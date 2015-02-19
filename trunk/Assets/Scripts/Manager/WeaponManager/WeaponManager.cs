using UnityEngine;
using System.Collections;

public class WeaponManager : Singleton<WeaponManager> 
{
	public static string m_AssetPath = "Assets/Resources/WeaponInfos.asset";

	public static WeaponInfos m_WeaponInfo;

	protected override void Awake()
	{
		base.Awake();

		m_WeaponInfo = Resources.LoadAssetAtPath<WeaponInfos>(m_AssetPath);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
