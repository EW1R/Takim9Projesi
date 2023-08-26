using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpellIndicator : MonoBehaviour
{
    public GameObject indicatorPrefab; // Gösterge için kullanılacak prefab
    private GameObject obje; // Oluşturulan gösterge

    void Update()
    {
        // Büyü yeteneği kullanılacağında (örneğin, fare sol tıklamada)
        if (Input.GetMouseButtonDown(1))
        {
            // İndikatörü oluştur
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // Uzaklığı ayarlayın
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            obje = Instantiate(indicatorPrefab, worldPosition, Quaternion.identity);
        }

        // Büyü yeteneği kullanımını bitirdiğinizde
        if (Input.GetMouseButtonUp(0))
        {
            // İndikatörü yok et
            if (obje != null)
            {
                Destroy(obje);
            }
        }
    }
}


