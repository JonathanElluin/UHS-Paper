using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperThrowScript : MonoBehaviour {

    public Rigidbody paper;
    public Rigidbody target;
    private Vector3 InitialPosition;

    private Vector3 direction;

    public float power;
    private float xAxisForce;
    private float yAxisForce;

    public Text score;
    private int paperScore = 0;

    private bool canLaunch = true;

    // Use this for initialization
    void Start () {
        //direction = move.wantedPosition;
        InitialPosition = this.transform.position;
        paper.useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("space"))
        {
            OnKeydown();
        }
    }

    void OnKeydown()
    {
        if (canLaunch == true)
        {
            canLaunch = false;
            xAxisForce = target.position.x - paper.position.x;
            yAxisForce = target.position.y - paper.position.y;

            direction = new Vector3(xAxisForce, yAxisForce*1.6f, -power);
            paper.useGravity = true;
            paper.velocity = direction;
            
            Destroy(gameObject, 5.0f);
            ResetPosition();
        }
    }
    

    private void ResetPosition()
    {
        this.transform.position = InitialPosition + new Vector3(Random.Range(-20, 20), 0f, 0f);
        paper.useGravity = false;
        canLaunch = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "trashtrigger")
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


