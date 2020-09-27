using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f, offset2 = 0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("instance already exists");
            Destroy(this);
        }
    }
    private void Update()
    {
        offset += Time.deltaTime * speed;
        offset2 += Time.fixedDeltaTime * speed;
    }
    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / length + offset);
    }
    public float GetWaveHeight2(float y)
    {
        return amplitude * Mathf.Cos(y / length - offset);
    }
}
