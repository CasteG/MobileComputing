using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMngr : MonoBehaviour
{
    public List<GameObject> Enemys;

    public float Speed = 2f;

    public float TimeFireEnemy = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Services.EnemyMngr = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddEnemy(GameObject enemy)
	{
        if (enemy != null)
		{
            Enemys.Add(enemy);
		}
	}

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemy != null)
            Enemys.Remove(enemy);
    }

    public void RemoveEnemysNull()
	{
		foreach (var enemy in Enemys)
		{
            if (enemy == null)
                Enemys.Remove(enemy);
		}
    }

    public void DeadEnemy(GameObject Enemy)
	{
		foreach (var enemy in Enemys)
		{
            if (enemy == Enemy)
			{
                Enemys.Remove(enemy);
                Destroy(Enemy);
                break;
			}
		}
	}
}
