using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTim = 5f;
    private float timeSinceLast = 0f;


    private void Update()
    {
        if (timeSinceLast > lifeTim)
        {
            Destroy(gameObject);
        }
        timeSinceLast += Time.deltaTime;
    }
}
