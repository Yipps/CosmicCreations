using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlanetInfo : MonoBehaviour {
    public int[] elementArray = new int[7];
    //set the values in the array as well when the Start method is called
    //[0] hydrogen
    //[1] helium
    //[2] carbon
    //[3] oxygen
    //[4] neon
    //[5] silicon
    //[6] iron

    public bool atmosphere = false;

    public int total;
    public int layers = 1;
    public int totalSolids;
    public int someGases;

    Color targetColor = Color.white;

    public float[] layerSizes = new float[3];

    public float radius;
    public float mass;
    public float distFromSun;


	// Use this for initialization
	void Awake () {
        GeneratePlanet();

        layerSizes[0] = 1;
        layerSizes[1] = 0;
        layerSizes[2] = 0;

        //need to call at start once to initialize the layers for cross section
        ProcessElements();
        SetColor();
        CrossSection();
	}
	
	// Update is called once per frame
	void Update () {
        //expand(radius);
        //Rotate();
        distFromSun = DistFromSun();
        GetComponent<Renderer>().material.color = targetColor; 
	}

    //makes the planet larger/smaller
    void Expand (float rad){
        gameObject.transform.localScale = new Vector3(rad, rad,rad);
    }

    //orbits the planet around the origin
    void Rotate() {
        transform.Rotate(Vector3.right*Time.deltaTime*10); 
    }

    //returns the distance from the Sun/origin as a vector quantity
    float DistFromSun() {
        float dist = transform.position.magnitude;
        return dist;
    }

    //total amt of elements
    void ProcessElements(){
        total = elementArray.Sum();
        //carbon + si + iron
        totalSolids = elementArray[2] + elementArray[5] + elementArray[6];
        //oxygen + neon
        someGases = elementArray[3] + elementArray[4];
    }

    //layer generation for cross sections
    //if only gases or only solids selected - only one layer
    //if the percentage of solids is <30%, three layers
    //else - two layers
    //sizes of layers
    // if one layer then size is 1
    //if three layers, inner layer is 1- ratio of solids
    void CrossSection(){
        if (totalSolids == 0 || (total - totalSolids) == 0)
        {
            layers = 1;
            layerSizes[0] = 1;
            layerSizes[1] = 0;
            layerSizes[2] = 0;
        }
        else if (((float)totalSolids / total) * 100 < 30)
        {
            layers = 3;
            layerSizes[0] = ((float)totalSolids/total);
            layerSizes[1] = 1 - ((float)someGases / total);
            layerSizes[2] = 1f;
        } 
        else
        {
            layers = 2;
            layerSizes[0] = (float) totalSolids/total;
            layerSizes[1] = 0f;
            layerSizes[2] = 1f;
        }
    }

    //dynamically change element ratio
    public void AddElement(int planetIndex){

        if (total < 160)
        {
            //hydrogen
            if (planetIndex == 0)
            {
                if (elementArray[0] < 40)
                    elementArray[0]++;
            }//helium
            else if (planetIndex == 1)
            {
                if (elementArray[1] < 30)
                    elementArray[1]++;
            }//carbon
            else if (planetIndex == 2)
            {
                if (elementArray[2] < 20)
                    elementArray[2]++;
            }//oxygen
            else if (planetIndex == 3)
            {
                if (elementArray[3] < 20)
                    elementArray[3]++;
            }//neon
            else if (planetIndex == 4)
            {
                if (elementArray[4] < 10)
                    elementArray[4]++;
            }//silicon
            else if (planetIndex == 5)
            {
                if (elementArray[5] < 20)
                    elementArray[5]++;
            }//iron
            else if (planetIndex == 6)
            {
                if (elementArray[6] < 20)
                    elementArray[6]++;
            }
            else
            {
                Debug.Log("this should be impossible");
            }
        }
        ProcessElements();
        SetColor();
        CrossSection();
    }

    public void SubtractElement(int planetIndex)
    {
        //hydrogen
        if (planetIndex == 0)
        {
            if (elementArray[0] > 1)
                elementArray[0]--;
        }//helium
        else if (planetIndex == 1)
        {
            if (elementArray[1] > 0)
                elementArray[1]--;
        }//carbon
        else if (planetIndex == 2)
        {
            if (elementArray[2] > 0)
                elementArray[2]--;
        }//oxygen
        else if (planetIndex == 3)
        {
            if (elementArray[3] > 0)
                elementArray[3]--;
        }//neon
        else if (planetIndex== 4)
        {
            if (elementArray[4] > 0)
                elementArray[4]--;
        }//silicon
        else if (planetIndex == 5)
        {
            if (elementArray[5] > 0)
                elementArray[5]--;
        }//iron
        else if (planetIndex == 6)
        {
            if (elementArray[6] > 0)
                elementArray[6]--;
        }
        else
       {
            Debug.Log("this should be impossible");
        }
        ProcessElements();
        SetColor();
        CrossSection();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(100, 50, 500, 20), "% Solid" + ((float)totalSolids/total).ToString() );
        GUI.Label(new Rect(100, 80, 500, 20), "% SomeGas" + ((float)someGases/total).ToString());
    }

    //randomizes element composition when new planets are setup
    public void GeneratePlanet(){
        for (int rand = Random.Range(0, 6); rand >= 0; rand--)
        {
            elementArray[rand] = Random.Range(1, 10);
        }
    }

    public void SetColor(){
        //elementArray[0] hydrogen - yellow
        //elementArray[1] helium - magenta
        //elementArray[2] carbon - black
        //elementArray[3] oxygen - blue
        //elementArray[4] neon - cyan
        //elementArray[5] silicon - grey
        //elementArray[6] iron - red

        int maxVal = GetLargestElement();
        //float perH  = (float)(elementArray[0] / total) * 100;
        //float perHe = (float)(elementArray[1] / total) * 100;
        //float perC  = (float)(elementArray[2] / total) * 100;
        //float perO  = (float)(elementArray[3] / total) * 100;
        //float perNe = (float)(elementArray[4] / total) * 100;
        //float perSi = (float)(elementArray[5] / total) * 100;
        //float perFe = (float)(elementArray[6] / total) * 100;

  

        if (maxVal == 0)
        {
            targetColor = Color.yellow;
        }
        else if (maxVal == 1)
        {
            targetColor = Color.magenta;
        }
        else if (maxVal == 2)
        {
            targetColor = Color.black;
        }
        else if (maxVal == 3)
        {
            targetColor = Color.blue;
        }
        else if (maxVal == 4)
        {
            targetColor = Color.cyan;
        }
        else if (maxVal == 5)
        {
            targetColor = Color.grey;
        }
        else if (maxVal == 6)
        {
            targetColor = Color.red;
        }


    }

    int GetLargestElement(){
        int max = 0;
        int index = 0;
        for (int i = 0; i < elementArray.Length; i++){
            if (elementArray[i] > max)
            {
                max = elementArray[i];
                index = i;
            }
        }
        return index;
    }
}