using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    private float targetGetTimer = 0f;

	private void Awake()
	{
        characterType = Gval.CharacterType.HERO;
	}

	// Start is called before the first frame update
	protected override void Start()
    {
        //Debug.Log("HERO START");
        base.Start();
    }

	// Update is called once per frame
	protected override void Update()
    {
        if (Gval.GetGameState() != Gval.GameState.GameOngoing)
        {
            return;
        }

        base.Update();

        targetGetTimer -= Time.deltaTime;
        if (targetGetTimer <= 0f)
        {
            targetGetTimer = Random.Range(0.5f, 1f);
            GetClosestTarget();
        }
        if (target != null && IsInRange())
        {
			if (IsInRange() && !isDefeated)
			{
				attackTimer -= Time.deltaTime;
				if (attackTimer <= 0f)
				{
					attackTimer = GetStat(Gval.StatType.ASPEED).value;
					FireProjectileAtTarget();
				}
			}
		}
    }
}
