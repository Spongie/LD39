using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battery : MonoBehaviour 
{
    public float PowerValue = 20f;
    public bool IsGrabbed = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (!IsGrabbed && other.tag == "Player" && !other.GetComponent<Player>().IsCarrying)
        {
            IsGrabbed = true;
            other.GetComponent<Player>().IsCarrying = true;
            transform.SetParent(other.gameObject.GetComponent<Player>().BatteryHold);
            transform.localPosition = Vector3.zero;
            GetComponent<DestroyTimer>().LifeTime = float.MaxValue;
        }
        else
        {
            PowerAcceptor powerAcceptor = other.GetComponentInParent<PowerAcceptor>();

            if (powerAcceptor != null)
                powerAcceptor.AcceptBattery(this);
        }
    }
}