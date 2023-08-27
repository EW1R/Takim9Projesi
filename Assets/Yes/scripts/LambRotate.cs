using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lambrotate : MonoBehaviour
{

    public float maxRotationAmount = 90.0f; // Maksimum d�n�� a��s�
    public float shakeSpeed = 0.8f; // Sallanma h�z�

    private Vector3 initialRotation;
    private float rotationTimer = 0.0f;

    private void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        // Zamanlay�c�y� art�rarak sallanma efektini yarat
        rotationTimer += Time.deltaTime * shakeSpeed;

        // Maksimum d�n�� a��s�n� hesaplayarak, sin�s fonksiyonunu kullanarak sallanma efektini olu�tur
        float currentRotationAmount = Mathf.Sin(rotationTimer) * maxRotationAmount;

        // Eski rotasyonu koruyarak yaln�zca nesnenin yatay d�n���n� de�i�tir
        Quaternion newRotation = Quaternion.Euler(initialRotation.x, initialRotation.y + currentRotationAmount, initialRotation.z);

        // Nesneyi yeni rotasyonla g�ncelle
        transform.rotation = newRotation;
    }
}
