using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Dictionary<Gval.StatType, Stat> stats;

	private void Awake()
	{
        int statCount = (int)Gval.StatType.Count;
		stats = new Dictionary<Gval.StatType, Stat>();
        for (int i = 0; i< statCount; i++)
        {
            Gval.StatType statType = (Gval.StatType)i;
			stats.Add(statType, new Stat(statType, 1f));
        }
	}

	// Start is called before the first frame update
	protected virtual void Start()
    {
        //Debug.Log("CHARACTER START");
    }

	// Update is called once per frame
	protected virtual void Update()
    {

    }
}
