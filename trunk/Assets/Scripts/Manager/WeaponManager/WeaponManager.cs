using UnityEngine;
using System.Collections;

public class WeaponManager : Singleton<WeaponManager> 
{
	public enum WeaponCategory
	{
		Sword = 0,
		TwoHandedSword,
		Axe,
		TwoHandedAxe,
		ShortBow,
		LongBow,
		Shield
	}
	
	public enum AccessoryCategory
	{
		Helmet = 0, 
		BreastPlate,
		Shoulders,
		Pants,
		Gloves,
		Bracers,
		Ring,
		Amulet
	}

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
