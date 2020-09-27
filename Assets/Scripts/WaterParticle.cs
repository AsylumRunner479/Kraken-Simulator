using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticle : MonoBehaviour
{
    public Transform originalPos;
    public float normSpeed;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 end = originalPos.position;
        self.transform.position = Vector3.Lerp(self.transform.position, end, normSpeed);
    }
}
