using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderQueue : MonoBehaviour {
    public int renderQueue = 3002;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.renderQueue = renderQueue;
	}
	
}
