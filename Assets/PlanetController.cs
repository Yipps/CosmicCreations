using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    enum InteractionMode {Scaling, ElementSelection, ElementAdding, CrossSection, Inactive}


    public PlanetInfo newPlanet;
    public Transform leftHand;
    public Transform rightHand;
    public Transform rotateTransform;
    public Transform mask;

    public bool isLeftHandTracking { get; set; }
    public bool isRightHandTracking { get; set; }

    private InteractionMode currentMode;
    private bool isInUpdateModeCoroutine;
    private IEnumerator UpdateModeCoroutine;

    Vector3 avgForward;
    Vector3 avgCross;
    public float scaleSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentMode == InteractionMode.Scaling)
            UpdateRadius();

        //if (isLeftHandTracking && isRightHandTracking)
        //{
        //    UpdateRadius();
        //    UpdateRotation();
        //}else if (isRightHandTracking)
        //{
        //    UpdateMask();
        //}
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

        Vector3 targetScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        newPlanet.transform.localScale = Vector3.Lerp(newPlanet.transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
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
        GUI.Label(new Rect(10, 10, 200, 20), currentMode.ToString());
    }

    public IEnumerator UpdateInteractionMode()
    {
        yield return new WaitForSeconds(1.5f);

        if (isLeftHandTracking && isRightHandTracking)
        {
            currentMode = InteractionMode.Scaling;
        }
        else if (isLeftHandTracking)
        {
            currentMode = InteractionMode.CrossSection;
        }
        else if(isRightHandTracking)
        {
            currentMode = InteractionMode.ElementSelection;
            currentMode = InteractionMode.ElementAdding;
        }
        else
        {
            currentMode = InteractionMode.Inactive;
        }
    }

    public void CheckHandTracking()
    {
        if (UpdateModeCoroutine != null)
            StopCoroutine(UpdateModeCoroutine);
        UpdateModeCoroutine = UpdateInteractionMode();
        StartCoroutine(UpdateModeCoroutine);
    }
}
