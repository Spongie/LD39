using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFacer : MonoBehaviour 
{
    public Transform Target;

	void Start () 
	{
		
	}
	
    [ExecuteInEditMode]
	void Update () 
	{
        transform.position = new Vector3(Target.position.x - 0.5f, Target.position.y, Target.position.z + 1f);
	}
}