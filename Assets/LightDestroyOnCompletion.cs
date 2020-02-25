using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;

public class LightDestroyOnCompletion : MonoBehaviour
{
    private ParticleSystem ps;
    private float destroyLightTimer = .3f;
    private bool destroyedLight = false;
    private Light2D light2D;
    public void Start()
    {
        light2D = GetComponent<Light2D>();
    }

    public void Update()
    {
        if (destroyLightTimer > 0)
        {
            destroyLightTimer -= Time.deltaTime;
            light2D.pointLightOuterRadius = destroyLightTimer * 100;
        }
        else if (!destroyedLight)
        {
            Destroy(gameObject);
        }
    }
}