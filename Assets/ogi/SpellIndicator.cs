using UnityEngine;

public class SpellIndicator : MonoBehaviour
{
    public GameObject indicatorPrefab; // Gösterge için kullanýlacak prefab
    private GameObject indicator; // Oluþturulan gösterge

    void Update()
    {
        // Büyü yeteneði kullanýlacaðýnda (örneðin, fare sol týklamada)
        if (Input.GetMouseButtonUp(1))
        {
            // Ýndikatörü oluþtur
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // Uzaklýðý ayarlayýn
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            indicator = Instantiate(indicatorPrefab, worldPosition, Quaternion.identity);
        }

        // Büyü yeteneði kullanýmýný bitirdiðinizde
        if (Input.GetMouseButtonUp(0))
        {
            // Ýndikatörü yok et
            if (indicator != null)
            {
                Destroy(indicator);
            }
        }
    }
}

