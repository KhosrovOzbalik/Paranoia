using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHeat : MonoBehaviour
{
    public ParticleSystem fire;
    public UnityEngine.Rendering.Universal.Light2D heat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ice")
        {
            StartCoroutine(WaitIce(collision));
            fire.gameObject.SetActive(true);
            heat.pointLightOuterRadius = 4;

        }
    }
    IEnumerator WaitIce(Collider2D collision){
        GameObject Child = collision.gameObject.transform.GetChild(0).gameObject;
        Child.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(collision.gameObject);
        fire.gameObject.SetActive(false);
        heat.pointLightOuterRadius = 2;
    }
}
