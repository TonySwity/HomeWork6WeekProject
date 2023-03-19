using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private List<Renderer> _renderers;


    public void StartBlink()
    { 
        StartCoroutine(BlinkEffect());
    }

    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t+=Time.deltaTime)
        {
            foreach (var r in _renderers)
            {
                r.material.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30f)*0.5f + 0.5f ,0,0, 0));
            }

            yield return null;
        }
        
        StopCoroutine(BlinkEffect());
    }
}
