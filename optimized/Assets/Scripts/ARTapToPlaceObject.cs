using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject draft;
    public GameObject objectToPlace;
    public GameObject chair;
    public GameObject table;
    public GameObject lowbed;
    public GameObject shelf;
    public GameObject sofa;
    private Pose myPose; 
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    public recommendation recom;
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid) 
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(myPose.position, myPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    
    // does raycast to center of screen, looks for planes, and stores the results in hits.
    // then if there are hits, set myPose to that pose.
    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            myPose = hits[0].pose;
        }
    }

    public void PlaceObject()
    {
        //for simualtion
        //draft = chair;

        if (placementPoseIsValid)
        {
            draft.GetComponent<Recolour>().SetOriginalMaterial();
            draft.transform.parent = null;
            //draft=MyPooler.ObjectPooler.Instance.GetFromPool("obj", myPose.position, myPose.rotation);

            draft = Instantiate(objectToPlace, myPose.position, myPose.rotation);
            //Debug.Log("here");
            draft.GetComponent<Recolour>().SetValid();
            draft.transform.parent = placementIndicator.transform;
        }
    }
    
    private void UseObject(GameObject obj)
    {
        objectToPlace = obj;
        Destroy(draft);
        draft = Instantiate(obj, myPose.position, myPose.rotation);

        draft.GetComponent<Recolour>().SetValid();
        draft.transform.parent = placementIndicator.transform;
    }
    
    public void UseChair()
    {
        recom.changenum("chair", 1);
        UseObject(chair);
    }
    
    public void UseTable()
    {
        recom.changenum("table", 1);

        UseObject(table);
    }
    
    public void UsePouf()
    {
        recom.changenum("bed", 1);

        UseObject(lowbed);
    }
    
    public void UseShelf()
    {
        recom.changenum("shelf", 1);

        UseObject(shelf);
    }
    
    public void UseSofa()
    {
        recom.changenum("sofa", 1);

        UseObject(sofa);
    }
}
