using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractionGUI : MonoBehaviour {

    public Image leftHand;
    public Image rightHand;
    public Text interaction;

    public Image[] interactions;

    public PlanetController controls;
    public SO_InteractionMode interactionModeInfo;

    public void ToggleLeftHand()
    {
        if (controls.isLeftHandTracking)
            leftHand.color = Color.green;
        else
            leftHand.color = Color.red;
    }

    public void ToggleRightHand()
    {
        if (controls.isRightHandTracking)
            rightHand.color = Color.green;
        else
            rightHand.color = Color.red;
    }

    public void UpdateInteraction()
    {
        if (interactionModeInfo.currentMode == InteractionMode.Inactive)
        {
            DeactiveAllImages();
            interactions[0].gameObject.SetActive(true);
        }else if (interactionModeInfo.currentMode == InteractionMode.CrossSection)
        {
            DeactiveAllImages();
            interactions[1].gameObject.SetActive(true);
        }
        else if (interactionModeInfo.currentMode == InteractionMode.Scaling)
        {
            DeactiveAllImages();
            interactions[2].gameObject.SetActive(true);
        }
        else if (interactionModeInfo.currentMode == InteractionMode.ElementAdding)
        {
            DeactiveAllImages();
            interactions[3].gameObject.SetActive(true);
        }
    }

    private void DeactiveAllImages()
    {
        foreach (Image i in interactions)
        {
            i.gameObject.SetActive(false);
        }
    }
}
