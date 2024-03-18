using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Animation());
        
    }

    IEnumerator Animation(){
        GetComponent<PlayerController>().enabled = false;
        animator.SetTrigger("wakeUp");
        yield return new WaitForSeconds(1.2f);
        GetComponent<PlayerController>().enabled = true;
    }
}
