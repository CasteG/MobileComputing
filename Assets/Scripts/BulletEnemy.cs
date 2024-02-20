using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    float Speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -12f)
            Destroy(gameObject);
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            Services.Player.GetDamage();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "BulletPlayer")
        {
            Destroy(gameObject);
        }
    }
}
