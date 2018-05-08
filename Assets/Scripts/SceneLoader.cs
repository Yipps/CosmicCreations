using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour {

    public bool isLeftPositioned {get; set;}
    public bool isRightPositioned { get; set; }
    public int scene;
    private bool isInCoroutine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckIfLoadScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        if (!isInCoroutine)
        {
            isInCoroutine = true;
            yield return new WaitForSeconds(3f);
            if (isLeftPositioned && isRightPositioned)
                SceneManager.LoadScene(scene);
            isInCoroutine = false;
        }
    }
}
