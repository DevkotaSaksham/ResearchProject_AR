using UnityEngine;

public class RemoveObject : MonoBehaviour
{

    public recommendation recom;

    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.current.ScreenPointToRay(touch.position);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                //MyPooler.ObjectPooler.Instance.ReturnToPool("obj", hitObject.transform.parent.transform.parent.gameObject);
                GameObject o = hitObject.transform.parent.transform.parent.gameObject;
                Destroy(o);
                recom.changenum(o.name.ToString(), -1);
            }
        }       
    }
}
