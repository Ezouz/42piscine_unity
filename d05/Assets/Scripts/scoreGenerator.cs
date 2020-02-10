using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreGenerator : MonoBehaviour
{
    public static scoreGenerator SG;
    public string currentRank = "patate";

    void Awake() {
        if (SG == null) {
            SG = this;
        }
    }

    // calcul rapport au par
    public string moulinette(int score, int par) {
        string rank = "";
        if (score == 1)
            rank = "Ace";
        else if (score == (par - 3))
            rank = "Albatross";
        else if (score == (par - 2))
            rank = "Eagle";
        else if (score == (par - 1))
            rank = "Birdie";
        else if (score == par)
            rank = "Par";
        else if (score == (par + 1))
            rank = "Bogey";
        else if (score == (par + 2))
            rank = "Double Bogey";
        else if (score == (par + 3))
            rank = "Triple Bogey";
        else
            rank = "+" + (score - par).ToString();
        return rank;
    }
    
}
