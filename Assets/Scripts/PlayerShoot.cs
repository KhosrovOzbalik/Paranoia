using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform firePointUp;
    [SerializeField] private Transform firePointDown;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private GameObject[] fireballsUpDown;
    public AudioSource fire_sound;
    

    private bool isGrounded;
    public GameObject player;
    public float damage = 50f;
    private Animator anim;
    private PlayerController playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake(){
    
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerController>();

    }
    private void Update(){
        isGrounded = player.GetComponent<PlayerController>().isGrounded();
        if(Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown){
            fire_sound.Play();
            if(Input.GetKey(KeyCode.W)){
                AttackUp();
            }
            else{
                Attack();
            }
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack(){
        anim.SetTrigger("fire");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private void AttackUp(){
        anim.SetTrigger("fire");
        cooldownTimer = 0;
        fireballsUpDown[FindFireballUpDown()].transform.position = firePointUp.position;
        fireballsUpDown[FindFireballUpDown()].GetComponent<Projectile>().SetDirectionUpDown(Mathf.Sign(transform.localScale.y));
    }
    
    
    private int FindFireball(){
        for(int i = 0; i < fireballs.Length; i++){
            if(!fireballs[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }
    private int FindFireballUpDown(){
        for(int i = 0; i < fireballs.Length; i++){
            if(!fireballsUpDown[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }

}
