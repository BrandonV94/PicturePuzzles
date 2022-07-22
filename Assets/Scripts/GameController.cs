using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] CheckColors checkColors;
    [SerializeField] GameObject mainImage;
    [SerializeField] GameObject congratulations;

    [SerializeField] bool isGameComplete = false;
    [SerializeField] int numUniquePieces = 0;
    [SerializeField] public GameObject[] gamePieces;

    void Awake()
    {
        congratulations = GameObject.Find("Congratulations");
        mainImage = GameObject.Find("Main");
        gamePieces = GameObject.FindGameObjectsWithTag("PlayablePiece");
        checkColors = FindObjectOfType<CheckColors>();
    }

    private void Start()
    {
        congratulations.gameObject.SetActive(false);
    }

    public void CheckGameOver()
    {
        Debug.Log("Check results is running.");
        //Check if all piece are unique.
        foreach (var piece in gamePieces)
        {
            var pieceSR = piece.GetComponent<SpriteRenderer>();
            var unique = piece.GetComponent<CheckPieces>();
            if (unique.isPieceUnique == false)
            {
                StartCoroutine(Pulse(pieceSR));
                isGameComplete = false;
            }
            else
            {
                numUniquePieces++;
            }
        }
        
        if (numUniquePieces == gamePieces.Length && checkColors.allColorsUsed)
        {
            Invoke("ActivateCongratulationsText", 2);
            isGameComplete = true;
        }

        numUniquePieces = 0;
        Debug.Log("Check results complete.");
    }

    // Makes any non-unique piece pulse when checking for game results.
    IEnumerator Pulse(SpriteRenderer pieceSR)
    {
        int countDown = 12;
        for (; countDown > 0; countDown--)
        {
            if (pieceSR.sortingOrder == 0)
            {
                pieceSR.sortingOrder = 5;
            }
            else
            {
                pieceSR.sortingOrder = 0;
            }
            yield return new WaitForSeconds(.25f);
        }

        pieceSR.sortingOrder = 0;
        yield break;    // Breaks the coroutine after flashing for a few seconds
    }

    void ActivateCongratulationsText()
    {
        congratulations.gameObject.SetActive(true);
    }
}
