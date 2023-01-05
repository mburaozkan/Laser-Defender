using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheild : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int SheildTime = 10;
    
    void OnEnable() {
        StartCoroutine(SheildTimer()); 
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Enemy Projectile")
        {
            Destroy(other.gameObject);
            PlayHitEffect();
        }   
    }

    IEnumerator SheildTimer()
    {
        yield return new WaitForSeconds(SheildTime);
        gameObject.SetActive(false);
    }
    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
