using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionMode { Scaling, ElementSelection, ElementAdding, CrossSection, Inactive, Pending }

[CreateAssetMenu]
public class SO_InteractionMode : ScriptableObject
{
    public InteractionMode currentMode;

    public InteractionMode previousMode;
}
