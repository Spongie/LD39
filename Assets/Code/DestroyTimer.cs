using UnityEngine;

public class DestroyTimer : MonoBehaviour 
{
    public float LifeTime;
	
	void Update () 
	{
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
            Destroy(gameObject);
	}
}