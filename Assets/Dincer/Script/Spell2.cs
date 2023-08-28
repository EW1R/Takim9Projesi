using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spell2 : ScriptableObject
{
    
    public ParticleSystem vfx;
    public float damage;
    public float cooldown;
    public float projectileLifeTime;
    public float yOffset;
    public float raycastRadius;



    public GameObject indicatorPrefab, tempObject; // Gösterge için kullanýlacak prefab
    private GameObject temp;
    public bool isSpawned= true;
    protected Transform castPos;
   
    public void ControlIndicator()
    {
        

        if (isSpawned)
        {
            Debug.Log("ICERDE");
            Vector3 worldPosition = MousePosWorld();
            Create(worldPosition);

        }
        else
        // Büyü yeteneði kullanýlacaðýnda (örneðin, fare sol týklamada)
        {
            Debug.Log(isSpawned + "CIEDREDES");
            Debug.DrawRay(temp.transform.position, Vector3.left * (raycastRadius / 2));
            Debug.DrawRay(temp.transform.position, Vector3.right * (raycastRadius / 2));
            Vector3 worldPos = MousePosWorld();
            worldPos.y = temp.GetComponent<FindGround>().GetHitPoint().y;
            temp.transform.position = worldPos;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, temp.GetComponent<FindGround>().GetHitNormal());
            temp.transform.rotation = rotation;
            temp.transform.position += temp.GetComponent<FindGround>().GetHitNormal() * yOffset;
        }

        Debug.Log(isSpawned + "AFTER");

       

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
        isSpawned = false;
        return temp;
    }

    public void EndIndicate()
    {
        
        castPos = temp.transform;
        Instantiate(tempObject, temp.transform.position, Quaternion.identity);
        isSpawned = true;
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
