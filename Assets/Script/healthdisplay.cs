using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthdisplay : MonoBehaviour
{
    Rect rect;
    Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        rect = new Rect(Screen.width * .05f, Screen.height * .90f, Screen.width * .05f, Screen.width * .05f);
        texture = Resources.Load("Textures/energy") as Texture;
    }

    // Update is called once per frame
    void OnGUI()
    {
        for (int i = 0; i < GameVariables.health; i++)
        {
            Rect newRect = new Rect(rect.x, rect.y - i * Screen.width * .07f, rect.width, rect.width);
            GUI.DrawTexture(newRect, texture);
        }
    }
}
