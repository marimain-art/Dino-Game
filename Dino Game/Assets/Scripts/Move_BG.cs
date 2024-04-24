using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_BG : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        Vector2 displacement = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = displacement;
    }
}
