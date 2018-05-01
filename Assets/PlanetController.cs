using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

    public PlanetInfo newPlanet;
    public Transform leftHand;
    public Transform rightHand;
    public Transform rotateTransform;
    public Transform mask;

    public bool isScaleable;
    public bool isLeftHandTracking { get; set; }
    public bool isRightHandTracking { get; set; }

    Vector3 avgForward;
    Vector3 avgCross;

// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isLeftHandTracking && isRightHandTracking)
        {
            UpdateRadius();
            UpdateRotation();
        }else if (isRightHandTracking)
        {
            UpdateMask();
        }
	}

    private void UpdateRotation()
    {
        avgForward = leftHand.forward + rightHand.forward;
        Vector3 avgUp = leftHand.up + rightHand.up;

        avgCross = Vector3.Cross(Vector3.up, avgForward);

        float crossMag = Vector3.Magnitude(Vector3.Cross(leftHand.up, rightHand.up));
        //Debug.Log(crossMag);

        //Vector3 clampedVector = avgForward.
        float clampedY = Mathf.Clamp(avgForward.y, -1f, 0.8f);
        avgForward.y = clampedY;

        if (crossMag < 0.65)
            rotateTransform.localRotation = Quaternion.LookRotation(avgForward);
        Debug.Log("Avg Vector: " + avgForward.ToString() + "Rotation: " + rotateTransform.rotation);
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

    private void UpdateMask()
    {
        if (isRightHandTracking && !isLeftHandTracking)
        {
            mask.gameObject.SetActive(true);
            mask.transform.position = new Vector3(rightHand.transform.position.x, mask.transform.position.y, mask.transform.position.z);
        }
        else
        {
            mask.gameObject.SetActive(false);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Left Hand: " + leftHand.forward.ToString());
        GUI.Label(new Rect(10, 30, 200, 20), "Right Hand: " + rightHand.forward.ToString());
        GUI.Label(new Rect(10, 50, 200, 20), "Average: " + avgForward.ToString());
        GUI.Label(new Rect(10, 70, 200, 20), "Cross: : " + avgCross.ToString());
    }
}
