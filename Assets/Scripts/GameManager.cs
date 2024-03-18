using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public Animator fade;
    
    public void PlayGame(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    public void QuitGame(){

        Application.Quit();
    }
    public void SetVolume(float volume){
        AudioListener.volume = volumeSlider.value;
    }
    public void SetFullscreen(bool fullscreen){
        Screen.fullScreen = fullscreen;
    }
    IEnumerator LoadLevel(int levelIndex){
        yield return new WaitForSeconds(1);
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
