using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_BG : MonoBehaviour
{
    public float cenarioVelocity;
 
    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        Vector2 displacement = new Vector2(Time.time * cenarioVelocity, 0);
        GetComponent<Renderer>().material.mainTextureOffset = displacement;
    }
}
