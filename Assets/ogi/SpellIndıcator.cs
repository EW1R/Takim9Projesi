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
        if (Input.GetMouseButtonUp(1))
        {
            // İndikatörü yok et
            if (obje != null)
            {
                isIndicating = false;
                Destroy(obje);
            }
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // Uzaklığı ayarlayın
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Instantiate(tempObject, worldPosition, Quaternion.identity);
        }
        if (!isSpawned)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // Uzaklığı ayarlayın
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Create(worldPosition);
            isSpawned = !isSpawned;
        }
        if (isIndicating && isSpawned)
        {
            Indıcator();
        }
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
        print("OBJE" + obje.transform.position);
        obje.transform.position = worldPosition;
    }

    private GameObject Create(Vector3 worldPos)
    {
        temp = Instantiate(indicatorPrefab, worldPos, Quaternion.identity);
        return temp;
    }
}


