using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;

    private int score = 0;
    public bool game_over = false;
    public float scrollspeed = -4f;
    public GameObject GameOverText;

    void Awake()
    {
        //If there is no game control currently
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //destroy duplicate.
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game_over && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Reload the current scene.
        }
    }

    public void PlayerDied()
    {
        game_over = true;
        GameOverText.SetActive(true);
    }
}
