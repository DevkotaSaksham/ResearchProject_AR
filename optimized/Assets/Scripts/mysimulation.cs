using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.UI;
using UnityEngine.UI;

public class mysimulation : MonoBehaviour
{


    public GameObject placeobj;
    float timePassed = 0f;
    Button btn;


    void Start()
    {
        btn = placeobj.GetComponent<Button>();

    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 2f)
        {
             btn.onClick.Invoke();
            btn.onClick.Invoke();
            btn.onClick.Invoke();







            timePassed = 0f;
        }
    }
}