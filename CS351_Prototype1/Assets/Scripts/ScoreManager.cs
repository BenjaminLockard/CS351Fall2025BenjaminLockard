using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add for TextMeshPro
using TMPro;
//Add for scene manager, load & reload scenes
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    //public static universally accesible by scripts, invisible in inspector

    public static bool gameOver;
    public static bool won;
    public static int score;
    // Set in inspector
    public int scoreToWin;

    //Text Box ref
    public TMP_Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            textbox.text = "POINTS TO FIND: " + (16 - score);
        } else if (won) {
            textbox.text = "LOSER - R to Replay";
        } else {
            textbox.text = "WINNER - R to Replay";
        }

        if (score >= scoreToWin) {
            won = true;
            gameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
