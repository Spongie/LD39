using UnityEngine;

public class MovementController : MonoBehaviour 
{
    private float speed = 15f;
    public Transform Graphics;
    StateManagaer stateManager;

    private void Start()
    {
        stateManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateManagaer>();
    }

    void Update () 
	{
        if (stateManager.IsDead)
            return;

        var movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        GetComponent<CharacterController>().Move(movement * Time.deltaTime * speed);

        if (movement.z > 0)
        {
            if (movement.x > 0)
                Graphics.rotation = Quaternion.Euler(new Vector3(-90, 135, 0));
            else if (movement.x < 0)
                Graphics.rotation = Quaternion.Euler(new Vector3(-90, 45, 0));
            else
                Graphics.rotation = Quaternion.Euler(new Vector3(-90, 90, 0));
        }
        else if (movement.z < 0)
        {
            if (movement.x > 0)
                Graphics.rotation = Quaternion.Euler(new Vector3(-90, 225, 0));
            else if (movement.x < 0)
                Graphics.rotation = Quaternion.Euler(new Vector3(-90, 315, 0));
            else
            {
                Graphics.rotation = Quaternion.Euler(new Vector3(-90, 270, 0));
            }
        }
        else if (movement.x > 0)
            Graphics.rotation = Quaternion.Euler(new Vector3(-90, 180, 0));
        else if (movement.x < 0)
            Graphics.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
    }
}