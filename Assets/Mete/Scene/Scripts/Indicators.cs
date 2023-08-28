using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicators : MonoBehaviour
{
    public ParticleSystem vfx;
    public float damage;
    public float cooldown;
    public float projectileLifeTime;
    public float yOffset;

    private Vector3 position;
    private RaycastHit hit;
    private Ray ray;


    public GameObject indicatorPrefab, tempObject; // G�sterge i�in kullan�lacak prefab
    private GameObject temp;
    public bool isSpawned = true;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        AbilityCanvas();
    }

    private void AbilityCanvas()
    {
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

        }
    }

    public void ControlIndicator()
    {

        if (isSpawned)
        {
            Debug.Log("ICERDE");
            Vector3 worldPosition = MousePosWorld();
            Create(worldPosition);

        }
        else
        {
            Vector3 worldPos = MousePosWorld();
            worldPos.y = temp.GetComponent<FindGround>().GetHitPoint().y;
            temp.transform.position = worldPos;

            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, temp.GetComponent<FindGround>().GetHitNormal());
            
            temp.transform.rotation = rotation;
            temp.transform.position += temp.GetComponent<FindGround>().GetHitNormal() * yOffset;
        }

   


    }

    private GameObject Create(Vector3 worldPos)
    {
        temp = Instantiate(indicatorPrefab, worldPos, Quaternion.identity);
        isSpawned = false;
        return temp;
    }

    public void EndIndicate()
    {

        Instantiate(tempObject, temp.transform.position, Quaternion.identity);
        isSpawned = true;
    }

    private static Vector3 MousePosWorld()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Uzakl��� ayarlay�n
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }
    public virtual void Activate()
    {
        Debug.Log("UsingActivate From:" + this);
    }
}

