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
            SetColor(new Color(Mathf.Sin(t * 30f)*0.5f + 0.5f ,0,0, 0));
            
            yield return null;
        }
        
        SetColor(Color.clear);
    }

    private void SetColor(Color newColor)
    {
        foreach (var r in _renderers)
        {
            foreach (var m in r.materials)
            {
                m.SetColor("_EmissionColor", newColor);
            }
        }
    }
}
