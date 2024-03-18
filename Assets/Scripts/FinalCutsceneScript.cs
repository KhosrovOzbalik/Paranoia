using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCutsceneScript : MonoBehaviour
{
    private Scene scene;
    public int waitSecondTime;
    public Animator fade;

    void Start(){
        LoadNextLevel();
    }
    public void LoadNextLevel(){
        StartCoroutine(LoadLevel("Menu"));
    }
    IEnumerator LoadLevel(string levelIndex){
        yield return new WaitForSeconds(waitSecondTime);
        yield return new WaitForSeconds(1);
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
