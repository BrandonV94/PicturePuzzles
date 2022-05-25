using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSurroundingsColors : MonoBehaviour
{
    public Component[] adjacentSprites;
    public Color curColor;
    public bool isPieceUnique = false;

    void Start()
    {

    }

    void Update()
    {
        curColor = gameObject.GetComponent<SpriteRenderer>().color;
        checkPieceIsUnique();
    }

    void checkPieceIsUnique()
    {
        if(ColorUtility.ToHtmlStringRGB(curColor) != "FFFFFF" && surroundingsUnique(adjacentSprites))
        {
            Debug.Log("Setting bool to true");
            isPieceUnique = true;
        }
        else
        {
            Debug.Log("Setting bool to false");
            isPieceUnique = false;
        }
    }

    bool surroundingsUnique(Component[] pieces)
    {
        foreach (var piece in pieces)
        {
            if(piece.GetComponent<SpriteRenderer>().color == curColor &&
                ColorUtility.ToHtmlStringRGB(piece.GetComponent<SpriteRenderer>().color) != "FFFFFF")
            {
                return false;
            }
        }
        return true;
    }
}
