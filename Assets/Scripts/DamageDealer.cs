using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int DamageAmount = 10;

    public int getDamage(){
        return DamageAmount;
    }
    public void Hit(){
        Destroy(gameObject);
    }
}
