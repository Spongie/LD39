using UnityEngine;

public class PowerAcceptor : MonoBehaviour
{
    protected Player player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void AcceptBattery(Battery battery)
    {
        Destroy(battery.gameObject);
        player.IsCarrying = false;
    }
}