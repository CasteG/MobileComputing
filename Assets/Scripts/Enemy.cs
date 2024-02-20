using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float Speed => Services.EnemyMngr.Speed;

    private float counter = 0f;
    private float Time => Services.EnemyMngr.TimeFireEnemy;

    public GameObject Bullet;
    public Transform StartBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        transform.position -= new Vector3(Speed * UnityEngine.Time.deltaTime, 0, 0);

        if (transform.position.x < -12f)
		{
            Services.Player.GetDamage();
            Dead();
		}
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag == "Player")
            Dead();

        if (collision.gameObject.tag == "BulletPlayer")
            Dead();
    }

    public void Dead()
	{
        Services.EnemyMngr.DeadEnemy(gameObject);
    }

    public void Fire()
	{
        Instantiate(Bullet, new Vector3(StartBullet.position.x, StartBullet.position.y, -1), Quaternion.identity);
    }

    private void Timer()
    {
        counter += UnityEngine.Time.deltaTime;

        if (counter >= Time)
        {
            counter = 0f;
            Fire();
        }
    }
}
