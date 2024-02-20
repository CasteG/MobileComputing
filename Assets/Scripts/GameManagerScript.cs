using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    [SerializeField] private AudioSource gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
       // Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverUI.activeInHierarchy) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }   
        else{
           // Cursor.visible = false;
           // Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true); 
        gameOverSound.Play();
    } 
    public void restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void back() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
