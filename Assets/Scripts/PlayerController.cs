using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables
    public GameObject audSour;
    private int[] audioData;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;
    public GameObject cube4;
    public GameObject cube5;

    private float changeAmount = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        // get array from audioController
        audioData = audSour.GetComponent<AudioController>().tenSamples;
    }

    // Update is called once per frame
    void Update()
    {
        // compare first 5 results from array
        int audioArrayIdx = 0;
        // you know a better way than linking all these up to find al the cubes in an array for you
        //however this is not ultimately how you will be using this anyway, so it does not matter much
        GameObject[] cubes = new GameObject[] { cube1, cube2, cube3, cube4, cube5 };
        foreach (GameObject cube in cubes)
        {

            Debug.Log(audioData[audioArrayIdx]);
            float cubeChange = 0.0f;

            // check if value = even, move cube right
            // else if value = odd, move cube left
            // else default change 0 does not move cube

            if ((audioData[audioArrayIdx] % 2) == 0 && audioData[audioArrayIdx] != 0)
            {
                //move cube more or less by multiplying it by current audionumber
                cubeChange = changeAmount * audioData[audioArrayIdx];
            }
            else if ((audioData[audioArrayIdx] % 2) == 1)
            {
                //move cube more or less by multiplying it by current audionumber
                cubeChange = -1 * changeAmount * audioData[audioArrayIdx];
            }

            Vector2 calcPos = cube.transform.right * Time.deltaTime * cubeChange;
            calcPos.y = cube.transform.position.y;
            cube.transform.position = calcPos;

            audioArrayIdx++;
        }
    }
}
