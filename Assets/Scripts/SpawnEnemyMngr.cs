using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyMngr : MonoBehaviour
{
    public GameObject[] Enemys;

    public Transform MinY;
    public Transform MaxY;

    private float XDefault;

    float counter;
    public float Time = 3;

    public EnemyMngr EnemyMngr;

    // Start is called before the first frame update
    void Start()
    {
        XDefault = MinY.position.x;

        Services.SpawnEnemyMngr = this;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void SpawnEnemy()
	{
        GameObject enemy = Instantiate(Enemys[Random.Range(0, 2)], new Vector3(XDefault, Random.Range(MinY.position.y, MaxY.position.y), -1), Quaternion.identity);

        EnemyMngr.AddEnemy(enemy);
	}

    private void Timer()
	{
        counter += UnityEngine.Time.deltaTime;

        if (counter >= Time)
		{
            counter = 0f;
            SpawnEnemy();
		}
	}

    public void DecrementTimeSpawn(float decrement)
	{
        Time = Mathf.Clamp(Time - decrement, 1, 3);
	}
}
