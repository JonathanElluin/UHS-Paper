using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperCount : MonoBehaviour {

    public Text score;
    private int paperScore = 0;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "trashtrigger")
        {
            ScoreUpdate();
        }
    }

    private void ScoreUpdate()
    {
        paperScore++;
        score.text = "Nombre de panier: " + paperScore.ToString();
    }

}
