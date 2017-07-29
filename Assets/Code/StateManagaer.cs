using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManagaer : MonoBehaviour 
{
    public bool DrawAggroRanges = false;
    public EnemyStats EnemyBaseStats;

    public int CurrentWave = 0;
    public int WaveSize = 3;
    public float WaveCooldown = 20f;
    public float CurrentCooldown = 5f;

    public List<Transform> EnemySpawns;
    public GameObject Enemy;

    public List<Transform> BatterySpawns;
    public GameObject Battery;

    public float MinBatteryCooldown = 0.5f;
    public float MaxBatteryCooldown = 1.5f;
    public float CurrentBatteryCooldown = 0f;

    public float Score = 0;
    public bool IsDead;
    PowerStation station;

    private void Start()
    {
        Score = 0;
        station = GameObject.FindGameObjectWithTag("PowerStation").GetComponent<PowerStation>();
    }

    void Update ()
    {
        if (IsDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("Main");
            else if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();

            return;
        }

        SpawnEnemies();
        SpawnBatteries();

        Score += Time.deltaTime * 10f;

        if (station.CurrentPower <= 0 || station.CurrentHealth <= 0)
        {
            IsDead = true;
        }
    }

    private void SpawnBatteries()
    {
        CurrentBatteryCooldown -= Time.deltaTime;

        if (CurrentBatteryCooldown <= 0)
        {
            CurrentBatteryCooldown = Random.Range(MinBatteryCooldown, MaxBatteryCooldown);
            GameObject battery = Instantiate(Battery, BatterySpawns[Random.Range(0, BatterySpawns.Count)].position, Quaternion.identity);
            battery.AddComponent<DestroyTimer>().LifeTime = Random.Range(4f, 8f);
        }
    }

    private void SpawnEnemies()
    {
        if (IsDead)
            return;

        CurrentCooldown -= Time.deltaTime;

        if (CurrentCooldown <= 0)
        {
            for (int i = 0; i < WaveSize; i++)
            {
                GameObject enemyObject = Instantiate(Enemy, EnemySpawns[Random.Range(0, EnemySpawns.Count)].position, Quaternion.identity);
            }

            CurrentCooldown = WaveCooldown;
            CurrentWave++;
            WaveCooldown = Mathf.Max(10, WaveCooldown - 0.5f);
            WaveSize++;
            EnemyBaseStats.Health *= 1.15f;
            EnemyBaseStats.Speed *= 1.15f;

            Score += CurrentWave + WaveSize + 100;
        }
    }
}