using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceScaling : MonoBehaviour {

    public GameObject renderObject;

    //public float minDistance, maxDistance;

    //public float scalingAmount;

    //private float initialSize;

    private float prevCameraSize;

    private float CameraSize;

    //private float normalizedDistance;

    //private float scaledAmount;

    //private float scaledSize;

    //private float dist;

	// Use this for initialization
	void Start () {

        //initialSize = renderObject.GetComponent<Renderer>().material.GetFloat("_LineSize");
        prevCameraSize = gameObject.GetComponent<Camera>().orthographicSize;

	}
	
	// Update is called once per frame
	void Update () 
    {
        CameraSize = gameObject.GetComponent<Camera>().orthographicSize;
        
        if (prevCameraSize < CameraSize && renderObject.GetComponent<Renderer>().material.GetFloat("_LineSize") < 0.12f)
        {
            renderObject.GetComponent<Renderer>().material.SetFloat("_LineSize", renderObject.GetComponent<Renderer>().material.GetFloat("_LineSize") + 0.01f);
        }
        else if(prevCameraSize > CameraSize && renderObject.GetComponent<Renderer>().material.GetFloat("_LineSize") > 0.04f)
        {
            renderObject.GetComponent<Renderer>().material.SetFloat("_LineSize", renderObject.GetComponent<Renderer>().material.GetFloat("_LineSize") - 0.01f);
        }

        prevCameraSize = CameraSize;

        /*
         
        dist = Vector3.Distance(this.transform.position, renderObject.transform.position);
        
        if (dist < minDistance) {
            normalizedDistance = 0;
        }
        else
        {
            normalizedDistance = dist / maxDistance;
        }

        scaledAmount = scalingAmount * normalizedDistance;

        scaledSize = (initialSize + scaledAmount);

        renderObject.GetComponent<Renderer>().material.SetFloat("_LineSize", scaledSize);
        */


    }
}
