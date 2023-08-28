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
    public bool isPlayer;



    public GameObject indicatorPrefab, tempObject; // Gösterge için kullanýlacak prefab
    private GameObject temp;
    public bool isSpawned= true;
    protected Transform castPos;
   
    public void ControlIndicator()
    {
        if (!isPlayer)
        {
            return;
        }

        if (isSpawned)
        {
            Vector3 worldPosition = MousePosWorld();
            Create(worldPosition);

        }
        
        if(!isSpawned)
        // Büyü yeteneði kullanýlacaðýnda (örneðin, fare sol týklamada)
        {
            Debug.DrawRay(temp.transform.position, Vector3.left * (raycastRadius / 2));
            Debug.DrawRay(temp.transform.position, Vector3.right * (raycastRadius / 2));
            Vector3 worldPos = MousePosWorld();
            worldPos.y = temp.GetComponent<FindGround>().GetHitPoint().y;
            temp.transform.position = worldPos;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up , temp.GetComponent<FindGround>().GetHitNormal());
            Debug.Log(rotation.x += 90);
            temp.transform.rotation =rotation;
           
            temp.transform.position += temp.GetComponent<FindGround>().GetHitNormal() * yOffset;
        }


       

    }

    private GameObject Create(Vector3 worldPos)
    {
        
        temp = Instantiate(indicatorPrefab, worldPos, Quaternion.Euler(90,90,0));
        Vector3 scale = temp.transform.localScale;
        scale.x*=raycastRadius;
        scale.z *= raycastRadius;
        temp.transform.localScale += scale;
        isSpawned = false;
        return temp;
    }

    public void EndIndicate()
    {
        
        castPos = temp.transform;
        Instantiate(tempObject, temp.transform.position, Quaternion.identity);
        isSpawned = true;
        Destroy(temp);
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
