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

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Sað týklandýðýnda
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

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
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == referenceObject.gameObject)
            {
                hitPoint = hit.point;
                previewBlock.transform.position = hitPoint;
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
