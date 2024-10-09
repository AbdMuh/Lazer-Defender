using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer Damager = other.GetComponent<DamageDealer>();
        if(Damager !=null){
            takeDamage(Damager.getDamage());
            Damager.Hit();
        }
    }    

    private void takeDamage(int damageAmount){
        health -=damageAmount;
        if(health <=0){
            Destroy(gameObject);
        }
    }
}
