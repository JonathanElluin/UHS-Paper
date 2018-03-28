using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperThrowScript : MonoBehaviour {

    public GameObject paper;
    public GameObject target;
    public float weight;
    private int direction = 0;
    private Quaternion rotation;
    public float speed;
    public Move move;

    // Use this for initialization
    void Start () {
        //direction = move.wantedPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("space"))
        {
            OnKeyPressed();
        }
    }

    void OnKeyPressed()
    {
        bool firstLaunch = true;
        if (firstLaunch == true)
        {
            paper.GetComponent<Rigidbody>().useGravity = true;
            paper.GetComponentInChildren<Rigidbody>().AddTorque(target.transform.position);
            paper.GetComponent<Rigidbody>().AddForce(target.transform.position);
        }
        else
        {

        }
    }
}


