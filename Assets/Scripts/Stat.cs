using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
	public Gval.StatType statType;
	public float value;

	public Stat(Gval.StatType statType, float value)
	{
		this.statType = statType;
		this.value = value;
	}
}
