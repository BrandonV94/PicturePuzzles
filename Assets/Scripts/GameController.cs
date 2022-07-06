using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject mainImage;
    [SerializeField] GameObject[] gamePieces;
    [SerializeField] bool isGameComplete = false;
    [SerializeField] TextMeshProUGUI congratulationsText;
    int numUniquePieces = 0;

    void Awake()
    {
        congratulationsText.gameObject.SetActive(false);
        mainImage = GameObject.Find("Main Image");
        gamePieces = GameObject.FindGameObjectsWithTag("PlayablePiece");
    }

    public void checkGameOver()
    {
        //Check if all piece are unique.
        foreach (var piece in gamePieces)
        {
            var unique = piece.GetComponent<CheckSurroundingsColors>();
            if (unique.isPieceUnique == false)
            {
                // TODO Flash button red to show incorrect
                isGameComplete = false;
            }
            else
            {
                numUniquePieces++;
            }
        }

        if(numUniquePieces == gamePieces.Length)
        {
            Invoke("activateCongratulationsText", 2);
            isGameComplete = true;
        }

        numUniquePieces = 0; 
    }

    void activateCongratulationsText()
    {
        congratulationsText.gameObject.SetActive(true);
    }
}
