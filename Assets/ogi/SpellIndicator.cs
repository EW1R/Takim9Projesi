using UnityEngine;

public class SpellIndicator : MonoBehaviour
{
    public GameObject indicatorPrefab; // G�sterge i�in kullan�lacak prefab
    private GameObject indicator; // Olu�turulan g�sterge

    void Update()
    {
        // B�y� yetene�i kullan�laca��nda (�rne�in, fare sol t�klamada)
        if (Input.GetMouseButtonUp(1))
        {
            // �ndikat�r� olu�tur
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // Uzakl��� ayarlay�n
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            indicator = Instantiate(indicatorPrefab, worldPosition, Quaternion.identity);
        }

        // B�y� yetene�i kullan�m�n� bitirdi�inizde
        if (Input.GetMouseButtonUp(0))
        {
            // �ndikat�r� yok et
            if (indicator != null)
            {
                Destroy(indicator);
            }
        }
    }
}

