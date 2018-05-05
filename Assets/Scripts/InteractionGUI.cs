using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InteractionGUI : MonoBehaviour {

    public Image leftHand;
    public Image rightHand;
    public Text interaction;

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
        interaction.text = interactionModeInfo.currentMode.ToString();
    }
}
