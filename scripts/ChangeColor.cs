using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // speed: Change color every 2 seconds
    public float changeTime = 2f;
    // The starting color
    private Color startColor;
    // timer: since the last color change
    private float timer = 0f;
    // Array of colors
    public Color[] colors = {Color.red, Color.blue, Color.green};
    private int currentColor = 0; // Index of color of the current state in the array
    
    public bool colorChange = false; // Flag to keep track of color changing.


    void Start()
    {
        startColor = GetComponent<Renderer>().material.color;
    }

    // Update per frame
    void Update()
    {
        // checking for key press
        if (Input.GetKey(KeyCode.X)) 
        {
            colorChange = true;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            colorChange = false; // if the player press C, return the bool back to false
            GetComponent<Renderer>().material.color = startColor; // reset the color to the start value
        }
        // change the color every 'changeTime'
        if (colorChange)
        {
            timer = timer + Time.deltaTime;
            
            // reset the timer of the last color change
            // move to the next color in the array
            if (timer > changeTime)
            {
                timer = 0f;
                currentColor = (currentColor + 1) % colors.Length;
            }
            // set the color to the index
            GetComponent<Renderer>().material.color = colors[currentColor];
        }

    }
}
