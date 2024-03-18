using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingCutscene : MonoBehaviour
{
    public GameObject panel;
    public int seconds;
    void Awake()
    {
        panel.SetActive(true);
    }

    IEnumerator Wait(int _seconds){
        yield return new WaitForSeconds(_seconds);
    }
    void OnTriggerEnter2D(Collider2D collider){
        StartCoroutine(Wait(seconds));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
