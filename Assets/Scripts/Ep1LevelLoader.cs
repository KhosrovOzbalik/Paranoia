using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ep1LevelLoader : MonoBehaviour
{
    private Scene scene;
    public int waitSecondTime;
    public Animator fade;
    
    void Start(){
        LoadNextLevel();
    }
    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        yield return new WaitForSeconds(waitSecondTime);
        yield return new WaitForSeconds(1);
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
