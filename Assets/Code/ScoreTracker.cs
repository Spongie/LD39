using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour 
{
    StateManagaer manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateManagaer>();
    }

    void Update () 
	{
        GetComponent<Text>().text = "Score: " + manager.Score.ToString("f0");
    }
}