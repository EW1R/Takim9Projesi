using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellIndicator : MonoBehaviour
{
    public GameObject indicatorPrefab, tempObject; // Gösterge için kullanılacak prefab
    private GameObject obje; // Oluşturulan gösterge
    private bool isIndicating = false;
    private GameObject temp;
    private bool isSpawned = false;
    public float yOffset = 0.2f;
    public GameObject particleCircle;
    
    private void Start()
    {

    }
    void Update()
    {
        // Büyü yeteneği kullanılacağında (örneğin, fare sol tıklamada)
        if (Input.GetMouseButtonDown(1))
        {
            isIndicating = true;
            isSpawned = false;
        }

        // Büyü yeteneği kullanımını bitirdiğinizde
        
        if (!isSpawned)
        {
            Vector3 mousePosition = Input.mousePosition;
            //mousePosition.z = 10; // Uzaklığı ayarlayın
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Create(worldPosition);
            isSpawned = !isSpawned;
        }
        if (isIndicating && isSpawned)
        {
            Indıcator();
        }
        if (Input.GetMouseButtonUp(1))
        {
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, temp.GetComponent<FindGround>().GetHitNormal());

            Instantiate(tempObject, obje.transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButtonUp(1))
        {
            // İndikatörü yok et
            if (obje != null)
            {
                isIndicating = false;
                Destroy(obje);
            }
        }
        //if (ınput.getmousebuttonup(1))
        //{
        //    vector3 mouseposition = ınput.mouseposition;
        //    mouseposition.z = 10; // uzaklığı ayarlayın
        //    vector3 worldposition = camera.main.screentoworldpoint(mouseposition);

        //    ınstantiate(tempobject, worldposition, quaternion.identity);
        //}
    }

    private void Indıcator()
    {
        // İndikatörü oluştur
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Uzaklığı ayarlayın
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        print("1" + mousePosition);
        print("2" + Input.mousePosition);
        print("3" + worldPosition);
        obje = temp;
        worldPosition.y = temp.GetComponent<FindGround>().GetHitPoint().y;
        print("OBJE" + obje.transform.position);
        obje.transform.position = worldPosition;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, temp.GetComponent<FindGround>().GetHitNormal());
        obje.transform.rotation=rotation;
        obje.transform.position+=temp.GetComponent<FindGround>().GetHitNormal()*yOffset;
    }

    private GameObject Create(Vector3 worldPos)
    {
        temp = Instantiate(indicatorPrefab, worldPos, Quaternion.identity);
        return temp;
    }
}


