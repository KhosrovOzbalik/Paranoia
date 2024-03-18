using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour
{   
    public GameObject bubble;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        bubble.SetActive(false);
    }
    
}
