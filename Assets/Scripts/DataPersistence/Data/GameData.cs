using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	public int maxLevelReached;

	public int enemiesDefeated;

	public GameData()
	{
		this.maxLevelReached = 1;
		this.enemiesDefeated = 0;
	}
}
