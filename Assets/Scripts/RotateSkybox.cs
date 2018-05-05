using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    void Rotate()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
