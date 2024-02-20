using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player owner;

    float Speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        owner = Services.Player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);

        if (transform.position.x > 15)
            Destroy(gameObject);

    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "Enemy")
		{
            Services.SpawnEnemyMngr.DecrementTimeSpawn(0.05f);
            Services.EnemyMngr.Speed += 0.25f;
            Services.EnemyMngr.TimeFireEnemy -= 0.1f;
            Services.BackgroundMngr.speed += 0.25f;

            owner.ActivatedBullets.Remove(gameObject);
            owner.KillEnemy();
            Destroy(gameObject);
		}
        else if (collision.gameObject.tag == "BulletEnemy")
        {
            owner.ActivatedBullets.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
