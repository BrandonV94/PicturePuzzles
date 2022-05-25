using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectionManager : MonoBehaviour
{

    public Color[] colorList;
    public Color curColor;
    public int colorCount;

    void Update()
    {
        curColor = colorList[colorCount];

        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, -Vector2.up);

        if (Input.GetButton("Fire1"))
        {
            if(hit.collider != null)
            {
                // Gets the sprite renderer components from the sprite selected.
                SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                //Debug.Log(hit.collider.name);

                sp.color = curColor;
            }
        }
    }

    public void paint(int colorCode)
    {
        colorCount = colorCode;
    }
}
