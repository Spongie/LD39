using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{
    public Image Image;
    public Health Health;

	void Start () 
	{
        Image = GetComponent<Image>();
        Health = GetComponentInParent<Health>();
	}
	
	void Update () 
	{
        Image.fillAmount = Health.CurrentHealthLevel;
	}
}