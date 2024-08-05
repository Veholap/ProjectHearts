using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Character origin;
    public Character target;

    public float projectileSpeed;
    public bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (GameManager.Instance.gamePaused)
		{
			return;
		}
		if (target == null || origin == null || destroyed)
        {
            return;
        }
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) <= 0.2f)
            {
                ProjectileHit();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
            }
        }
    }

    public void InitProjectile(Character origin, Character target)
    {
		destroyed = false;
        this.origin = origin;
        this.target = target;
        transform.position = origin.transform.position;
        projectileSpeed = Random.Range(1f, 2f) + target.GetStat(Gval.StatType.MSPEED).value;
	}

	public void DestroyProjectile()
	{
        destroyed = true;
        Destroy(gameObject);
	}

	public void ProjectileHit()
    {
		if (target == null || origin == null || destroyed)
		{
			return;
		}
        if (target != null && target.isDefeated)
        {
            DestroyProjectile();
        }
        else
        {
            target.TakeDMG(origin);
			DestroyProjectile();
		}
	}

}
