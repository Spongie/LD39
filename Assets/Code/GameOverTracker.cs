using UnityEngine;
using UnityEngine.UI;

public class GameOverTracker : MonoBehaviour 
{
    StateManagaer stateManager;

	void Start () 
	{
        stateManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateManagaer>();
    }
	
	void Update () 
	{
		if (stateManager.IsDead)
        {
            GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 150);
            GetComponentInChildren<Text>().text = "You are dead! \n You scored: " + (int)stateManager.Score + "\n Press Space to try again \n Press Esc to exit game";
        }
	}
}