using System;
using System.Collections;

using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;

     [Header("EnemyAI")]

      [SerializeField] private bool EnemyShooter;
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float baseFiringRate = 0.2f;
    [SerializeField] private float minimumFiringRate = 0.2f;
    
    [HideInInspector]public bool isFiring;
    private Coroutine _fireCoroutine;
    private Rigidbody2D _rb;

    void Start(){
        if(EnemyShooter){
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && _fireCoroutine ==null)
        {
            _fireCoroutine = StartCoroutine(StartFiring());
            Debug.Log("Start");
        }
        else if(!isFiring && _fireCoroutine!=null)
        {
            StopCoroutine(_fireCoroutine);
            _fireCoroutine = null;
            Debug.Log("Stop");
        }  // This approach ensures that only one coroutine is active at any given time, 
    }

    IEnumerator StartFiring()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectile, transform.position, quaternion.identity);
            _rb = instance.GetComponent<Rigidbody2D>();
            if (_rb != null)
            {
                _rb.velocity = transform.up * projectileSpeed;
            }
          float firingtime = UnityEngine.Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
           firingtime = Mathf.Clamp(firingtime, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(firingtime);
            Destroy(instance,projectileLifeTime);
        }
    }
}
