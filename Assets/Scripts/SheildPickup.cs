using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player")
        {
            ActiviteShield(other.gameObject);
            Destroy(gameObject);
        }
    }

    void ActiviteShield(GameObject other)
    {
        GameObject Shield = other.transform.GetChild(0).gameObject;
        if (Shield != null)
        {
            Shield.SetActive(true);
        }
    }
}
