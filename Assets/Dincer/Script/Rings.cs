using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    public Ring fireRing;   
    public Ring boltRing;
    public Ring iceRing;
    private Ring currentRing;

    int activateKey;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (fireRing.isActive)
            {
                currentRing = fireRing;

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (boltRing.isActive)
            {
                currentRing = boltRing;

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (iceRing.isActive)
            {
                currentRing = iceRing;

            }
        }

        if (currentRing!=null)
        {
            print(currentRing.name);

        }

    }

    public Ring GetCurrentRing()
    {
        return currentRing;
    }
}
