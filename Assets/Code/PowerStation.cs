using UnityEngine;

public class PowerStation : PowerAcceptor 
{
    public float MaxPower = 100f;
    public float ConsumptionPerSecond = 1f;
    public float CurrentPower;

    private float DifficultyTimer = 10f;

    public int MaxHealth = 100;
    public int CurrentHealth = 100;

    public Transform AttackTarget;
    
    protected override void Start () 
	{
        CurrentPower = MaxPower;
        base.Start();
	}
	
	void Update () 
	{
        CurrentPower -= ConsumptionPerSecond * Time.deltaTime;
        DifficultyTimer -= Time.deltaTime;

        if (DifficultyTimer <= 0f)
        {
            DifficultyTimer = 10f;
            ConsumptionPerSecond += 0.25f;
        }
	}

    public override void AcceptBattery(Battery battery)
    {
        CurrentPower += battery.PowerValue;

        if (CurrentPower > MaxPower)
            CurrentPower = MaxPower;

        base.AcceptBattery(battery);
    }

    public float CurrentPowerLevel { get { return CurrentPower / MaxPower; } }

    public float CurrentHealthLevel { get { return CurrentHealth / (float)MaxHealth; } }
}