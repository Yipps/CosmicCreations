using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScale : MonoBehaviour {
    public PlanetInfo planet;
    public Slider slider;
    public Image mercury;
    public Image jupiter;
    public Image mars;
    public Image[] scaleImages;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSlider();
	}

    void UpdateSlider(){
        slider.value = planet.radius;
        if(slider.value < .10)
        {
            ToggleImage(mercury);
        }
        else if (slider.value < .2)
        {
            ToggleImage(mars);
        }
        else if(slider.value < .9)
        {
            ToggleImage(jupiter);
        }
        
    }

    void ToggleImage(Image img)
    {
        img.enabled = true;

        foreach (Image i in scaleImages)
        {
            if (i != img)
            {
                i.enabled = false;
            }
        
        }


    }
}
