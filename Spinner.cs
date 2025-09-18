using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Timer { Unscaled = 0, Scaled }

public class Spinner : MonoBehaviour
{
    // Como se fosse uma 'tag'
    public Timer timer;

    // Velocidade da escala de tempo
    [Range(0.0f, 10.0f)] public float speed;

    void Start()
    {
        Time.timeScale = speed;

        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while(true)
        {
            if(timer == Timer.Unscaled)
            {
                transform.Rotate(Vector3.up * 10 * Time.unscaledDeltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up * 10 * Time.deltaTime);
            }

            Time.timeScale = speed;

            yield return null;
        }
    }
}
