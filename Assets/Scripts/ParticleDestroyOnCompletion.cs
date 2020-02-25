using UnityEngine;
using System.Collections;

public class ParticleDestroyOnCompletion : MonoBehaviour
{
    private ParticleSystem ps;
    private float destroyLightTimer = .1f;
    private bool destroyedLight = false;


    public void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
        if(destroyLightTimer > 0)
        {
            destroyLightTimer -= Time.deltaTime;
        } else if (!destroyedLight)
        {
            Destroy(GetComponentsInChildren<Transform>()[1].gameObject);
            destroyedLight = true;
        }
    }
}