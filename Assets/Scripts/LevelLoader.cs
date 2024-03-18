using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public AudioSource audio;
    public Animator fade;
    public Animator player;

    void Update(){
        if(Input.GetKeyDown(KeyCode.L)){
            LoadNextLevel();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            LoadNextLevel();
        }
    
    }
    public void LoadNextLevel(){
        audio.Play();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex){
        player.GetComponent<PlayerController>().enabled = false;
        player.SetTrigger("levelEnd");
        yield return new WaitForSeconds(1);
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
