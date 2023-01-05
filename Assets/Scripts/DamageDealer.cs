using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] ParticleSystem hitEffect;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (gameObject.tag == "Player Projectile")
        {
            if (other.tag == "Enemy Projectile")    
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                PlayHitEffect();
            }
        }
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
