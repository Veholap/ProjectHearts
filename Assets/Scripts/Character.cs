using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	//public GameManager gameManager;
	public Dictionary<Gval.StatType, Stat> stats;
    public Gval.CharacterType characterType;

    public Character target;
    public float attackTimer = 0f;
    public bool isDefeated = false;

	private void Awake()
	{
		isDefeated = false;
		if (stats == null)
        {
            //InitStats();
        }
	}

    public void InitStats()
    {
		int statCount = (int)Gval.StatType.Count;
		stats = new Dictionary<Gval.StatType, Stat>();
		for (int i = 0; i < statCount; i++)
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
        if (GameManager.Instance.gamePaused)
        {
            return;
        }
    }

    public Stat GetStat(Gval.StatType statType)
    {
        return stats[statType];
    }

    public void SetStatValue(Gval.StatType statType, float newValue)
    {
        stats[statType].value = newValue;
    }

    public void GetClosestTarget()
    {
        if (characterType == Gval.CharacterType.None)
        {
            Debug.LogError("CHARACTER TYPE NONE");
        }
        else if (characterType == Gval.CharacterType.HERO)
        {
            Enemy closest = null;
            List<Enemy> enemies = GameManager.Instance.enemies;
            if (enemies != null)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Enemy enemy = enemies[i];
                    if (enemy != null && !enemy.isDefeated)
                    {
                        if (closest == null)
                        {
                            closest = enemy;
                        }
                        else if (closest != null)
                        {
                            float enemyDist = Vector3.Distance(transform.position, enemy.transform.position);
                            float closestDist = Vector3.Distance(transform.position, closest.transform.position);
                            if (enemyDist < closestDist)
                            {
                                closest = enemy;
                            }
                        }
                    }
                }
            }
            target = closest;
        }
        else if (characterType == Gval.CharacterType.ENEMY)
        {
            target = GameManager.Instance.heroBase;
        }
    }

    public bool IsInRange()
    {
        if (target == null)
        {
            return false;
        }
        if (target != null && Vector3.Distance(target.transform.position, transform.position) <= GetStat(Gval.StatType.RANGE).value)
        {
            return true;
        }
        return false;
    }

    public void FireProjectileAtTarget()
    {
        if (target == null)
        {
            GetClosestTarget();
        }
        if (target != null && !target.isDefeated)
        {
            Projectile projectile = Instantiate(GameManager.Instance.projectilePrefab).GetComponent<Projectile>();
            projectile.InitProjectile(this, target);
        }
    }

    public void TakeDMG(Character dmgDealer)
    {
        float currentHP = GetStat(Gval.StatType.HP).value;
        float dmg = dmgDealer.GetStat(Gval.StatType.DMG).value;
        float newHP = currentHP - dmg;
        SetStatValue(Gval.StatType.HP, newHP);
        //Debug.Log(dmgDealer.gameObject.name + " deals " + dmg + " dmg to " + gameObject.name + " (" + newHP + ") hp left");
        if (newHP <= 0f)
        {
			isDefeated = true;
            if (characterType == Gval.CharacterType.BASE)
            {
                Debug.Log("BASE DESTROYED");
            }
		}
    }

}
