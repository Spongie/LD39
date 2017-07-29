using UnityEngine;
using UnityEngine.UI;

public class PowerTracker : MonoBehaviour 
{
    public PowerStation PowerStation;
    public bool Power;

	void Update () 
	{
        if (Power)
            GetComponent<Image>().fillAmount = PowerStation.CurrentPowerLevel;
        else
            GetComponent<Image>().fillAmount = PowerStation.CurrentHealthLevel;
    }
}