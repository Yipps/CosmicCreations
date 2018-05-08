using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    //public enum InteractionMode {Scaling, ElementSelection, ElementAdding, CrossSection, Inactive, Pending}

    [Header("Script Reference Dependencies")]
    public PlanetInfo newPlanet;
    public Transform leftHand;
    public Transform rightHand;
    public Transform rotateTransform;
    public Transform mask;
    public SO_InteractionMode InteractionModeInfo;
    public ElementGUI elementGUI;
    public GameEvent InteractionModeChange;
    public GameEvent ScrollElementEvent;
    public GameEvent AddElementEvent;

    public bool isLeftHandTracking { get; set; }
    public bool isRightHandTracking { get; set; }
    public bool isEditingElements { get; set; }
    public bool isAddingElements { get; set; }

    private InteractionMode previousMode;
    private IEnumerator _updateModeCoroutine;

    [Header("Scaling Settings")]
    public float scaleSpeed;
    [Header("Cross Section Speed")]
    public float crossSectionSpeed;
    [Header("Element Editing Settings")]

    [Header("Interaction Mode Update")]
    public float updateModeDelay;

    Vector3 avgForward;
    Vector3 avgCross;
    private bool isInElementCoroutine;

    // Use this for initialization
    void Start () {
        InteractionModeInfo.currentMode = InteractionMode.Inactive;
        isEditingElements = true;
        isAddingElements = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (InteractionModeInfo.currentMode == InteractionMode.Scaling)
            UpdateRadius();
        else if (InteractionModeInfo.currentMode == InteractionMode.CrossSection)
            UpdateMask();
        else if (InteractionModeInfo.currentMode == InteractionMode.ElementAdding)
        {
            if (isEditingElements)
            {
                if(isAddingElements)
                    AddElement();
                else
                {
                    RemoveElement();
                }
            }
                
            else
            {
                ScrollElement();
            }
                
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

        Vector3 targetScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        newPlanet.transform.localScale = Vector3.Lerp(newPlanet.transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
    }

    private void UpdateMask()
    {
        float xPos = Mathf.Lerp(mask.transform.position.x, leftHand.transform.position.x, crossSectionSpeed * Time.deltaTime);
        mask.transform.position = new Vector3(xPos, mask.transform.position.y, mask.transform.position.z);
    }

    public void ScrollElement()
    {
        if (!isInElementCoroutine)
            StartCoroutine(ScrollElementCoroutine());
    }

    public void AddElement()
    {
        if (!isInElementCoroutine)
            StartCoroutine(AddElementCoroutine());
    }

    public void RemoveElement()
    {
        if (!isInElementCoroutine)
            StartCoroutine(RemoveElementCoroutine());
    }

    public IEnumerator ScrollElementCoroutine()
    {
        isInElementCoroutine = true;
        ScrollElementEvent.Raise();
        Debug.Log("Raised scroll element event");
        yield return new WaitForSeconds(2f);
        isInElementCoroutine = false;
    }

    public IEnumerator AddElementCoroutine()
    {
        isInElementCoroutine = true;
        AddElementEvent.Raise();
        newPlanet.AddElement(elementGUI.selectedElementIndex);
        Debug.Log("Raised Add element event");
        yield return new WaitForSeconds(0.5f);
        isInElementCoroutine = false;
    }

    public IEnumerator RemoveElementCoroutine()
    {
        isInElementCoroutine = true;
        AddElementEvent.Raise();
        newPlanet.SubtractElement(elementGUI.selectedElementIndex);
        Debug.Log("Raised remove element event");
        yield return new WaitForSeconds(0.5f);
        isInElementCoroutine = false;
    }

    public InteractionMode GetInteractionMode()
    {
        //Determine what interaction mode is active based on hand tracking
        if (isLeftHandTracking && isRightHandTracking)
        {
            return InteractionMode.Scaling;
        }
        else if (isLeftHandTracking)
        {
            return InteractionMode.CrossSection;
        }
        else if(isRightHandTracking)
        {
            //currentMode = InteractionMode.ElementSelection;
            return InteractionMode.ElementAdding;
        }
        else
        {
            return InteractionMode.Inactive;
        }
    }


    private IEnumerator UpdateInteractionModeCoroutine(InteractionMode newMode)
    {
        //Call whenever hand tracking state changes 
        //Coroutine should restart whenever called

        //Immediately set mode to pending to stop interactions
        //Save previous mode for reference
        if (InteractionModeInfo.currentMode != InteractionMode.Pending)
            previousMode = InteractionModeInfo.currentMode;
        InteractionModeInfo.currentMode = InteractionMode.Pending;

        //Check if newMode is different from previous
        //If equal, user accidently lost tracking immediately set new mode
        //If different, countdown to set new mode
        if (previousMode == newMode)
        {
            InteractionModeInfo.currentMode = newMode;
        }
        else
        {
            yield return new WaitForSeconds(updateModeDelay);
            InteractionModeInfo.currentMode = newMode;
        }
        InteractionModeChange.Raise();
    }

    public void UpdateInteractionMode()
    {
        if (_updateModeCoroutine != null)
            StopCoroutine(_updateModeCoroutine);
        _updateModeCoroutine = UpdateInteractionModeCoroutine(GetInteractionMode());
        StartCoroutine(_updateModeCoroutine);
    }
}
