using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PowerUpMngr : MonoBehaviour
{
    public Transform MinY;
    public Transform MaxY;

    public GameObject Heart;

    private float counter;
    private float Time = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

	}

    public void Timer()
	{
        counter += UnityEngine.Time.deltaTime;

        if (counter >= Time)
        {
            counter = 0f;
            SpawnHeart();
        }
    }

    public void SpawnHeart()
	{
        Instantiate(Heart, new Vector3(12f, Random.Range(MinY.position.y, MaxY.position.y), -1), Quaternion.identity);
    }
}
