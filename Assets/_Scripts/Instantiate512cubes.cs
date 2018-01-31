using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512cubes : MonoBehaviour {
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;

    public Color color0 = Color.red;
    public Color color1 = Color.blue;
    public float duration = 1.63333F;

    // Use this for initialization
    void Start () {
		
        for (int i = 0; i < 512; i++) {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;
            
        }
	}

    // Update is called once per frame
    void Update () {
		for (int i = 0; i < 512; i++)  {
            if (_sampleCube != null)  {
                _sampleCube[i].transform.localScale = new Vector3(10,(AudioPeer._samples[i] * _maxScale) + 2,10);
                //GetComponent<Renderer>().material.color = new Color(0, 255, 0); //C sharp
            

                //float t = Mathf.PingPong(Time.time, duration) / duration;
                //_sampleCube[i].GetComponent<Renderer>().material.color = Color.Lerp(color0, color1, t);
            }
            
        }
	}
}
