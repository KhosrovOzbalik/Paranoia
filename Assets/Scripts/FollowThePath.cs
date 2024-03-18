using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public float moveSpeed;

    public bool mustPatrol;
    private bool mustTurn;
    private float health;

    public Rigidbody2D rb;    
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public LayerMask enemyLayer;

    void Start() {
        mustPatrol = true;
        
    }
    void Update() {
        health = gameObject.GetComponent<Enemy>().health;
        if(mustPatrol && health > 0){
            Patrol();
        }
        else{
            rb.velocity = new Vector2(0f,0f);
        }
    }
    void FixedUpdate() {
        if(mustPatrol){
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f,groundLayer);
        }
    }
    void Patrol() {
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(enemyLayer)){
            Flip();
        }
        
        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime , rb.velocity.y);
    }
    void Flip() {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1 , transform.localScale.y);
        moveSpeed *= -1;
        mustPatrol = true;

    }
}