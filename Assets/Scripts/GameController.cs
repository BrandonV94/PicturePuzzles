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

    void Start()
    {
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
                // Flash button red to show incorrect
                isGameComplete = false;
            }
        }
        Invoke("activateCongratulationsText", 2);
        isGameComplete = true;
    }

    void activateCongratulationsText()
    {
        congratulationsText.gameObject.SetActive(true);
    }
}
