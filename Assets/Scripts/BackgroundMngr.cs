using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundMngr : MonoBehaviour
{
    public Transform Bg1;
    public Transform Bg2;

    private Transform[] Backgrounds;

    public float speed;

    public Transform StartScreen;
    public Transform EndScreen;

    private Transform CurrentBg => Backgrounds[IndexBg1];
    private Transform NextBg => Backgrounds[IndexBg2];

    private int IndexBg1 = 0;
    private int IndexBg2 = 1;

	// Start is called before the first frame update
	void Start()
    {
        Services.Init();
        Services.BackgroundMngr = this;
        Backgrounds = new Transform[] { Bg1, Bg2 };
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FPS: " + 1 / Time.deltaTime);

        float speed = this.speed * Time.deltaTime;

        Bg1.position -= new Vector3(speed, 0, 0);
        Bg2.position -= new Vector3(speed, 0, 0);

        if (NextBg.position.x <= StartScreen.position.x)
		{
            CurrentBg.position = new Vector3(EndScreen.position.x, CurrentBg.position.y, CurrentBg.position.z);

            if (IndexBg1 == 0)
			{
                IndexBg1 = 1;
                IndexBg2 = 0;
			}
            else
			{
                IndexBg1 = 0;
                IndexBg2 = 1;
            }
        }
    }
}
