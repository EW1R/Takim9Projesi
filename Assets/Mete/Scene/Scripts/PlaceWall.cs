using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWall : MonoBehaviour
{
    public Vector3 place;

    private RaycastHit _hit;

    public GameObject objectPlace, tempObject;

    public GameObject iceWall, tempIceWall;

    public bool placeNow;
    public bool placeActive;
    public bool placeDeactive;

    void Update()
    {
        if (placeNow == true)
            SendRay();

        if (placeActive == true)
            objectPlace = iceWall;

        if(Input.GetKeyDown(KeyCode.E))
        {
        
        }

    }

    void SendRay()
    {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out _hit))
        {
            place = new Vector3(_hit.point.x,_hit.point.y,_hit.point.z);

            if(placeDeactive == false)
            {
                Instantiate(tempIceWall,place,Quaternion.identity);
                tempObject = GameObject.Find("IceWall");
                placeDeactive= true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(objectPlace,place,Quaternion.identity);
                placeNow = false;
                placeActive = false;
                


            }
        }
    }


}
