using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Canvas gameOverScreen;
    public CasparStats caspar;
    public AudioSource music;
    public Button tryAgain;
    public Button quit;


    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen = GetComponent<Canvas>();
        gameOverScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        tryAgain.onClick.AddListener(task1);
        quit.onClick.AddListener(task2);
        if(caspar.lives == 0){
            gameOverScreen.enabled = true;
            music.Stop();
        }

    }

    void task1(){
        Application.Quit();
    }

    void task2(){
        Application.Quit();
    }

    
}
