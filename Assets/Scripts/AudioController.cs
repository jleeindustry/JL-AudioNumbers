using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Music featured is by Pictures of the Floating World
    //Surge and Swell mp3 taken from:
    //https://freemusicarchive.org/music/Pictures_of_the_Floating_World/Surge_and_Swell/
    //Licensed under: Attribution-Noncommercial-Share Alike 3.0 United States License.

    // Documentation: 
    // GetSpectrumData: https://docs.unity3d.com/ScriptReference/AudioListener.GetSpectrumData.html
    // FFTWindow: https://docs.unity3d.com/ScriptReference/FFTWindow.html

    // variables
    public AudioSource source;
    //all samples, must be power of 2
    public float[] samples = new float[512];
    //arbitrary subset of samples (chosen because there are 5 cubes in example
    public int[] tenSamples = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        // get audio source
        source.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // get spectrum
        // sampels = float array power of 2, min = 64, max 8192
        // channel = channel from the sample
        // FFTWindow = reduce leakage of signals across frequency bands

        //try different windows to see different results.
        //read about concept of each windiw here
        // https://en.wikipedia.org/wiki/Window_function
        //see docs linked on line 9 for more about windows in unity.
        source.GetSpectrumData(samples, 0, FFTWindow.Hanning);

        // Get the first ten numbers of sample and cast to int
        for(int i = 0; i < tenSamples.Length; i++)
        {
            tenSamples[i] = (int)(samples[i]*100);
        }
    }
}
