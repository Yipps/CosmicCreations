using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementGUI : MonoBehaviour {
    public int selectedElementIndex;
    public Image[] elementIcons;

    public void ScrollIcons()
    {
        selectedElementIndex = (selectedElementIndex + 1) % elementIcons.Length;
        UpdateIcon(selectedElementIndex);
    }

    public void UpdateIcon(int index)
    {
        foreach (Image i in elementIcons)
        {
            i.enabled = false;
        }
        elementIcons[index].enabled = true;
    }
}
