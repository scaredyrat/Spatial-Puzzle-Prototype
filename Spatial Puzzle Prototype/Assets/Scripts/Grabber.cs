using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)
                {
                    if(!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                }
            }

            else
            {

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
        Debug.Log(Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit));
        return hit;
    }
}
