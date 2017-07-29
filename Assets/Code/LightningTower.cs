using System.Linq;
using UnityEngine;

public class LightningTower : PowerAcceptor 
{
    public float AggroRange = 5f;
    public float AttackCooldown = 2f;
    public float AttackDamage = 20f;
    public float CooldownRemaining = 0f;
    public Transform Target;
    public Transform ShootPosition;
    public GameObject ShootEffect;
    StateManagaer stateManager;

    protected override void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateManagaer>();
        base.Start();
    }

    void Update () 
	{
        CooldownRemaining -= Time.deltaTime;

		if (Target != null && Vector3.Distance(Target.position, transform.position) <= AggroRange)
        {
            ShootTarget();
        }
        else
        {
            FindTarget();
        }
	}

    private void FindTarget()
    {
        foreach (var hit in Physics.SphereCastAll(transform.position, AggroRange, transform.forward).Where(hit => hit.transform.tag == "Enemy"))
        {
            Target = hit.transform;
            break;
        }
    }

    private void ShootTarget()
    {
        if (CooldownRemaining <= 0f)
        {
            Target.GetComponentInParent<Health>().DealDamage(AttackDamage);
            CooldownRemaining = AttackCooldown;
            Instantiate(ShootEffect, ShootPosition.position, Quaternion.identity);
            Instantiate(ShootEffect, Target.position, Quaternion.identity);
        }
    }

    public override void AcceptBattery(Battery battery)
    {
        AttackDamage *= 1.1f;
        AttackCooldown *= 0.9f;

        if (AttackCooldown < 0.5f)
            AttackCooldown = 0.5f;

        base.AcceptBattery(battery);
    }

    private void OnDrawGizmos()
    {
        if (stateManager != null && stateManager.DrawAggroRanges)
            Gizmos.DrawWireSphere(transform.position, AggroRange);
    }
}