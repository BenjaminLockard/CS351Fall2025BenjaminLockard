using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text textbox;

    public string[] sentences;
    private int index;
    public float typingSpeed;

    void OnEnable()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        textbox.text = "";
        foreach(char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        } else
        {
            textbox.text = "";
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
