using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject mainImage;
    [SerializeField] GameObject[] gamePieces;
    [SerializeField] bool isGameComplete = false;

    void Start()
    {
        mainImage = GameObject.Find("Main Image");
        gamePieces = GameObject.FindGameObjectsWithTag("PlayablePiece");
    }

    void Update()
    {
        isGameComplete = checkGameOver(gamePieces);
    }

    bool checkGameOver(GameObject[] pieces)
    {
        //Check if all piece are unique.
        foreach (var piece in pieces)
        {
            var unique = piece.GetComponent<CheckSurroundingsColors>();
            if (unique.isPieceUnique == false)
            {
                return false;
            }
        }
        return true;
    }
}
