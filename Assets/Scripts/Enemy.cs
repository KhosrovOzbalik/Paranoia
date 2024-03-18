using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float health = 200f;
    public Animator anim;
    [SerializeField] 
    public Collider2D collider;
    public Collider2D collider2;
    public Collider2D collider3;
    private Scene scene;

    void Start(){
        scene = SceneManager.GetActiveScene();
        
    }
    void Update(){
        if(health <= 0f){
            StartCoroutine(WaitDeath());
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){

            SceneManager.LoadScene(scene.name);

        }
    }
    public void DeathAnimation(){
        collider.enabled = false;
        collider2.enabled = false;
        collider3.enabled = false;
        anim.SetTrigger("enemyDeath");
    }
    IEnumerator WaitDeath(){
        DeathAnimation();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
