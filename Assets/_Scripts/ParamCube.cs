using Assets.LSL4Unity.Scripts.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParamCube : MonoBehaviour {
    public int _band;
    public float _startScale, _scaleMultiplier;

    public Color color0 = Color.red;
    public Color color1 = Color.blue;
    public float duration = 1.0F;
    public int mySample;
   
    // Use this for initialization
    void Start () {
		
	}


    void collectSamples()
    {

        if (GameObject.Find("LabStreamingLayer").GetComponent<ExampleFloatInlet>().sampleFromInlet == 1)
        {
            print(GameObject.Find("LabStreamingLayer").GetComponent<ExampleFloatInlet>().sampleFromInlet);
            float t = Mathf.PingPong(Time.time, duration) / duration;
            GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, t);

            //GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        }
        if (GameObject.Find("LabStreamingLayer").GetComponent<ExampleFloatInlet>().sampleFromInlet == 3)
        {
            print(GameObject.Find("LabStreamingLayer").GetComponent<ExampleFloatInlet>().sampleFromInlet);
            float t = Mathf.PingPong(Time.time, duration) / duration;
            GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.blue, t);

            //GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        }

    }


    // Update is called once per frame
    void Update () {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);

        //float t = Mathf.PingPong(Time.time, duration) / duration;
        //GetComponent<Renderer>().material.color = Color.Lerp(color0, color1, t);

        collectSamples();

    }
}


