using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spell2 : ScriptableObject
{
    
    public ParticleSystem vfx;
    public float damage;
    public float cooldown;
    public float projectileLifeTime;


  

    public GameObject indicatorPrefab, tempObject; // Gösterge için kullanýlacak prefab
    private GameObject temp;
    private bool isSpawned;
    
    public void SetIndicator()
    {
        isSpawned = false;
    }
    public void ControlIndicator()
    {
        Debug.Log(isSpawned);

        if (!isSpawned)
        {
            Vector3 worldPosition = MousePosWorld();
            Create(worldPosition);
            isSpawned = !isSpawned;
            Debug.Log("isSpawnedDDDDD");

        }
        // Büyü yeteneði kullanýlacaðýnda (örneðin, fare sol týklamada)
        if (isSpawned)
        {
            temp.transform.position = MousePosWorld();
            Debug.Log("isSpawned");
        }

       

    }

    //private void Indicator()
    //{
    //    // Ýndikatörü oluþtur
    //    Vector3 mousePosition = Input.mousePosition;
    //    mousePosition.z = 10; // Uzaklýðý ayarlayýn
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

    //    obje = temp;
    //    obje.transform.position = worldPosition;
    //}

    private GameObject Create(Vector3 worldPos)
    {
        temp = Instantiate(indicatorPrefab, worldPos, Quaternion.identity);
        return temp;
    }

    public void EndIndicate()
    {
  
        Instantiate(tempObject, temp.transform.position, Quaternion.identity);
    }

    private static Vector3 MousePosWorld()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Uzaklýðý ayarlayýn
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }
    public virtual void Activate()
    {
        Debug.Log("UsingActivate From:" + this);
    }
}
