using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // On left-click, cast ray
            RaycastHit hit = CastRay();

            // If object has a collider, execute
            if(hit.collider != null)
            {
                // If object is not moveable, cancel
                if(!hit.collider.CompareTag("Moveable"))
                {
                    return;
                }

                // New selected object
                selectedObject = hit.collider.gameObject;
                Debug.Log("selected");
            }
            
            // If ray does not hit collider, remove selection
            else
            {
                selectedObject = null;
                Debug.Log("deselected");
            }
        }

        if (selectedObject != null)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                Vector3 temp = selectedObject.transform.position;
                temp.x = selectedObject.transform.position.x + 1;
                selectedObject.transform.position = temp;
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                Vector3 temp = selectedObject.transform.position;
                temp.z = selectedObject.transform.position.z + 1;
                selectedObject.transform.position = temp;
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                Vector3 temp = selectedObject.transform.position;
                temp.x = selectedObject.transform.position.x - 1;
                selectedObject.transform.position = temp;
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                Vector3 temp = selectedObject.transform.position;
                temp.z = selectedObject.transform.position.z - 1;
                selectedObject.transform.position = temp;
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        return hit;
    }
}
