using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class bloktasi : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject previewBlock;
    private bool isDragging = false;
    private Vector3 hitPoint;
    public Transform referenceObject;
    private RaycastHit hit;
    public float smoothSpeed = 5.0f; // Hareketin yumu�akl���n� kontrol eden de�er

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Sa� t�kland���nda
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == referenceObject.gameObject)
            {
                hitPoint = hit.point;
                isDragging = true;
                previewBlock = Instantiate(blockPrefab, hitPoint, Quaternion.identity);

            }
        }

        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == referenceObject.gameObject)
            {
                hitPoint = hit.point;
                // Yumu�ak�a hareket ettirme i�lemi (Lerp)
                Vector3 targetPosition = hitPoint;
                Vector3 smoothedPosition = Vector3.Lerp(previewBlock.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
                previewBlock.transform.position = smoothedPosition;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
            Destroy(previewBlock);

            Instantiate(blockPrefab, hitPoint, Quaternion.identity);
        }
    }
}
