using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];
    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MaxFrequencyBands();
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MaxFrequencyBands()
    {
        /*
         * 22050 / 512  = 43Hz per sample
         * 20 - 60 Hz
         * 60 - 250 Hz
         * 250 - 500 Hz
         * 500 - 2000 HZ
         * 2000 - 4000 Hz
         * 4000 - 6000 Hz
         * 6000 - 20000 Hz
         * 
         * 0 - 2 = 86 Hz
         * 1 - 4 = 172 Hz  - 87 - 258
         * 2 - 8 = 344 Hz  - 259 - 602
         * 3 - 16 = 688 HZ  - 603 - 1290
         * 4 - 32 = 1376 Hz  - 1291 - 266
         * 5 - 64 = 2752 Hz  - 2667 - 5418
         * 6 - 128 = 5504 Hz  - 5419 - 10922
         * 7 - 256 = 11008 Hz  - 10923 - 21930
         * 510
         *///

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                    count++;
            }

            average /= count;

            _freqBand[i] = average * 10; 
        }

    }
}
