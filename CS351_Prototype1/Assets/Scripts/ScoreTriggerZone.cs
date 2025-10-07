using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{


    private AudioSource scoreAudio;

    public AudioClip scoreSound;

    bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreAudio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            ScoreManager.score++;

            scoreAudio.PlayOneShot(scoreSound, 1.0f);

            active = false;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;

            //Unsure why, destroying object prevents sound from playing
            //Destroy(gameObject);
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
