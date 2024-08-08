using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataAsset : ScriptableObject
{

	[SerializeField]
	public EnemyDataEntry[] enemyDataEntries;

	[Serializable]
	public class EnemyDataEntry
	{
		public string enemyName;
	}

}
