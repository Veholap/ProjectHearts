using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
	public Vector3 originPos;
	public Vector3 targetPos;

	private void Awake()
	{
		characterType = Gval.CharacterType.ENEMY;
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
		if (GameManager.Instance.gamePaused)
		{
			return;
		}

		base.Update();

		if (isDefeated)
		{
			transform.position = Vector3.MoveTowards(transform.position, originPos, GetStat(Gval.StatType.MSPEED).value * 0.5f * Time.deltaTime);
			return;
		}

		if (target == null)
		{
			GetClosestTarget();
		}

		//if (Vector3.Distance(targetPos, transform.position) > GetStat(Gval.StatType.RANGE).value)
		if (!IsInRange())
		{
			transform.position = Vector3.MoveTowards(transform.position, targetPos, GetStat(Gval.StatType.MSPEED).value * Time.deltaTime);
		}

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
