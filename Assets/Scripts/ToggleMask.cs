using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMask : MonoBehaviour {

	public SO_InteractionMode InteractionModeInfo;
    public float maskExitSpeed;
    public float lerpTime = 2;

    public void CheckMask()
    {
        if (InteractionModeInfo.currentMode == InteractionMode.CrossSection)
        {
            
        }
        else
        {
            StartCoroutine(MaskExit());
            //float xPos = Mathf.Lerp(mask.transform.position.x, leftHand.transform.position.x, crossSectionSpeed * Time.deltaTime);
            //mask.transform.position = new Vector3(xPos, mask.transform.position.y, mask.transform.position.z);
        }
    }

    public IEnumerator MaskExit()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpTime)
        {
            float xPos = Mathf.Lerp(transform.parent.position.x, -4, timeElapsed / lerpTime);
            transform.parent.position = new Vector3(xPos, transform.parent.position.y, transform.parent.position.z);
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
