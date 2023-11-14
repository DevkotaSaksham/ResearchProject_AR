using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MoveObject : MonoBehaviour
{
    // private ARRaycastManager aRRaycastManager;
    public Camera aRCamera;
    private GameObject objtomove;

    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.current.ScreenPointToRay(touch.position);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                objtomove = hitObject.transform.parent.transform.parent.gameObject;
                objtomove.GetComponent<Recolour>().SetSelected();
                objtomove.transform.parent = aRCamera.transform;
            }
        }       
    }

    public void Deselect()
    {
        objtomove.GetComponent<Recolour>().SetOriginalMaterial();
        objtomove.transform.parent = null;
        objtomove = null;
    }
}
