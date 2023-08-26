using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class bloktasi : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject previewBlock;
    private bool isDragging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Sað týklandýðýnda
        {
            isDragging = true;
           Ray ray = 
            mousePosition.z = 0f;
            previewBlock = Instantiate(blockPrefab, mousePosition, Quaternion.identity);
        }

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            previewBlock.transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(1)) // Sað týklamayý býraktýðýnýzda
        {
            isDragging = false;

            Destroy(previewBlock);
            Vector3 finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            finalPosition.z = 0f;
            Instantiate(blockPrefab, finalPosition, Quaternion.identity);
        }
    }
}
