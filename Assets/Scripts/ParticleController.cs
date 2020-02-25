using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystem2;
    private float fireTimer = 1;

    private void Start()
    {
        particleSystem2.enableEmission = false;
    }
    [System.Obsolete]
    void Update()
    {
        if(fireTimer > 0)
        {
            particleSystem.startColor = new Color(1 - fireTimer, fireTimer, fireTimer);
            fireTimer -= Time.deltaTime * .5f;

            if(fireTimer <= 0)
            {
                particleSystem.enableEmission = false;
                particleSystem2.enableEmission = true;
            }
        }
    }
}
