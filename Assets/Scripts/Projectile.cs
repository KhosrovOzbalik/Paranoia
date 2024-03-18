using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    public AudioSource impact_sound;
    private float direction;
    private float directionUpDown;
    private bool hit;
    private float lifetime;
    private float damage;
    public GameObject player;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        damage = player.GetComponent<PlayerShoot>().damage;
    }
    private void Update()
    {
        if (hit) return;
        if(direction != 0){
            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
        }
        else if(directionUpDown != 0){
            float movementSpeed = speed * Time.deltaTime * directionUpDown;
            transform.Translate(0, movementSpeed, 0);
        }
        

        lifetime += Time.deltaTime;
        if (lifetime > 3) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "HeatArea"){
            hit = true;
            if(collision.gameObject.tag == "Enemy"){
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.health -= damage;
                
            }
            else if (collision.gameObject.tag == "Ice")
            {
                collision.gameObject.SetActive(false);
            }
            boxCollider.enabled = false;
            anim.SetTrigger("explode");
            impact_sound.Play();
        }
    }
    
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false; 
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    public void SetDirectionUpDown(float _direction){
        lifetime = 0;
        directionUpDown = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleY = transform.localScale.y;
        if(Mathf.Sign(localScaleY) != _direction){
            localScaleY = -localScaleY;
        }
        transform.localScale = new Vector3(transform.localScale.x, localScaleY, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
