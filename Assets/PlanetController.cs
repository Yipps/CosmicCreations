using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

    public PlanetInfo newPlanet;
    public Transform leftHand;
    public Transform rightHand;
    public Transform rotateTransform;

    public bool isScaleable;
    public bool isLeftHandTracking { get; set; }
    public bool isRightHandTracking { get; set; }



// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isLeftHandTracking && isRightHandTracking)
            isScaleable = true;
        else
            isScaleable = false;

        // if (isScaleable)
        //UpdateRadius();

        UpdateRotation();
	}

    private void UpdateRotation()
    {
        Vector3 angle = Vector3.Cross(leftHand.up, rightHand.up); 
        Debug.Log(angle);
        rotateTransform.localRotation = Quaternion.Euler(Vector3.Cross(leftHand.up, rightHand.up));
    }

    public void UpdateRadius()
    {
        //Get the distance between hands. Value is clamped so the max and min of hand distance is locked at some point
        float handDist = Vector3.Distance(leftHand.position, rightHand.position);
        handDist = Mathf.Clamp(handDist, 1.5f, 4f);

        //Normalize tha value of the handDist to a scale of 0 - 1)
        float normalizedRadius = (handDist - 1.5f) / 2.5f;
        newPlanet.radius = normalizedRadius;


        float scaleFactor = normalizedRadius * 3 + 1;
        newPlanet.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }

}
