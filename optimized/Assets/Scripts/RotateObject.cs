using System;
using UnityEngine;
using UnityEngine.UI;
 
public class RotateObject : MonoBehaviour
{
    
    private GameObject objectToRotate;
    public Slider slider;
    private float prevvalue;
    private float startValue = 0.5f;
    void Awake ()
    {
        slider.onValueChanged.AddListener (OnSliderChanged);
        prevvalue = slider.value;
    }
 
    void OnSliderChanged (float value)
    {
        float delta = value - prevvalue;
        objectToRotate.transform.Rotate (Vector3.up * delta * 360);
        prevvalue = value;
    }
    
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.current.ScreenPointToRay(touch.position);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                objectToRotate = hitObject.transform.parent.transform.parent.gameObject;
                objectToRotate.GetComponent<Recolour>().SetSelected();
            }
        }       
    }

    public void Deselect()
    {
        objectToRotate.GetComponent<Recolour>().SetOriginalMaterial();
        objectToRotate = null;
        slider.value = startValue;
    }
}