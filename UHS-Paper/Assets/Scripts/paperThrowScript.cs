using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperThrowScript : MonoBehaviour {

    public GameObject paper;
    public float weight;
    private Vector3 direction;
    private Quaternion rotation;
    public float power;
    public Move move;

    // Use this for initialization
    void Start () {
        direction = move.wantedPosition;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            paper.transform.SetPositionAndRotation(direction, rotation);
        }

    }
}
