using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using EasyJoystick;

public class Player : MonoBehaviour
{
    public Transform MinY;
    public Transform MaxY;

    public GameObject GameOver;

    public GameObject Bullet;

    public List<GameObject> ActivatedBullets;

    public Transform StartBullet;

    public PowerUpMngr PowerUpMngr;

    public bool MovementHorizontal;

    public float Speed;

    public Text counterKill;

    public int Kill = 0;

    public List<Sprite> ImageHeart;

    public List<Image> MyLife;
    public int Life = 5;

    //JOYSTICK
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;

    //SOUNDS
    [SerializeField] private AudioSource fireSoundEffect;
    [SerializeField] private AudioSource lifeSoundEffect;
    [SerializeField] private AudioSource enemyImpact;


    // Start is called before the first frame update

	void Start()
    {
        ActivatedBullets = new List<GameObject>();

        MovementHorizontal = true;
    }

    void Update()
    {
        Input();

        //joystick
        float Speed = this.Speed * Time.deltaTime;

        float x = 0;
        float y = joystick.Vertical();

        if (MovementHorizontal)
            x = joystick.Horizontal();

        transform.position += new Vector3(x * Speed, y * Speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), Mathf.Clamp(transform.position.y, MinY.position.y - 0.5f, MaxY.position.y + 0.5f), transform.position.z);

    }

    // FUNZIONE PER MOVIMENTO DEL PLAYER - FUNCTION MOVEMENT PLAYER
    public void Input()
	{
        float Speed = this.Speed * Time.deltaTime;

        float y = UnityEngine.Input.GetAxis("Vertical");
        float x = 0;

		if (MovementHorizontal)
			x = UnityEngine.Input.GetAxis("Horizontal");

		transform.position += new Vector3(x * Speed, y * Speed);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), Mathf.Clamp(transform.position.y, MinY.position.y - 0.5f, MaxY.position.y + 0.5f), transform.position.z);

        if (UnityEngine.Input.GetButtonDown("Fire"))
            Fire();
    }

    public void Fire()
	{
        GameObject bullet = Instantiate(Bullet, new Vector3(StartBullet.position.x, StartBullet.position.y, -1), Quaternion.identity);

        ActivatedBullets.Add(bullet);

        //sound
        fireSoundEffect.Play();
    }

    public void KillEnemy()
	{
        Kill++;

        counterKill.text = Kill.ToString();
	}

    public GameManagerScript gameManager;
    private bool isDead = false;

    public void Dead()
	{
        SceneManager.LoadScene("MainMenu");
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag ==  "Enemy")
		{
            GetDamage();
		}

        if (collision.gameObject.name.Contains("Heart"))
        {
            AddHeart();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            GetDamage();
        }

        if (collider.gameObject.tag == "Heart")
        {
            AddHeart();
            Destroy(collider.gameObject);
        }
    }

    public void GetDamage()
	{
        enemyImpact.Play();
		for (int i = MyLife.Count-1; i >= 0; i--)
		{
            if (MyLife[i].sprite.texture.name.Contains("Full"))
			{
                MyLife[i].sprite = ImageHeart[0];
                Life--;

                if (i <= 0 && !isDead) {
                    isDead = true;
                    gameObject.SetActive(false);
                    gameManager.gameOver();
                    Debug.Log("Morto");
                    //break;
                }
                return;
            }
		}

        //Dead();
    }

    public void AddHeart()
	{
         lifeSoundEffect.Play();
		for (int i = 0; i < MyLife.Count; i++)
		{
            if (MyLife[i].sprite.texture.name.Contains("Empty"))
			{
                MyLife[i].sprite = ImageHeart[1];
                Life++;
                return;
            }
		}
	}
    
}
