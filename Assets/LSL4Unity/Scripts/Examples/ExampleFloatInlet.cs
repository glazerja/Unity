using UnityEngine;
using System;
using System.Linq;
using Assets.LSL4Unity.Scripts.AbstractInlets;

namespace Assets.LSL4Unity.Scripts.Examples
{
    /// <summary>
    /// Just an example implementation for a Inlet recieving float values
    /// </summary>
    public class ExampleFloatInlet : AFloatInlet
    {
        public float sampleFromInlet = 0;
        public string lastSample = String.Empty;

        protected override void Process(float[] newSample, double timeStamp)
        {
            // just as an example, make a string out of all channel values of this sample
            lastSample = string.Join(" ", newSample.Select(c => c.ToString()).ToArray());
            if (newSample[0] > 0)
            {
                sampleFromInlet = newSample[0];
                int sampleFromInletInt = (int)newSample[0];
                print(sampleFromInletInt);
                
                //print(GameObject.Find("LabStreamingLayer").GetComponent<ExampleFloatInlet>().sampleFromInletInt);
                print(GameObject.Find("LabStreamingLayer").GetComponent<ExampleFloatInlet>().sampleFromInlet);

            }

            //Debug.Log(string.Format("Got {0} samples at {1}", newSample.Length, timeStamp));
        }
    }
}