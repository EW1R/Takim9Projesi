using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lambrotate : MonoBehaviour
{

    public float maxRotationAmount = 90.0f; // Maksimum dönüþ açýsý
    public float shakeSpeed = 0.8f; // Sallanma hýzý

    private Vector3 initialRotation;
    private float rotationTimer = 0.0f;

    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        // Zamanlayýcýyý artýrarak sallanma efektini yarat
        rotationTimer += Time.deltaTime * shakeSpeed;

        // Maksimum dönüþ açýsýný hesaplayarak, sinüs fonksiyonunu kullanarak sallanma efektini oluþtur
        float currentRotationAmount = Mathf.Sin(rotationTimer) * maxRotationAmount;

        // Eski rotasyonu koruyarak yalnýzca nesnenin yatay dönüþünü deðiþtir
        Quaternion newRotation = Quaternion.Euler(initialRotation.x, initialRotation.y + currentRotationAmount, initialRotation.z);

        // Nesneyi yeni rotasyonla güncelle
        transform.rotation = newRotation;
    }
}
