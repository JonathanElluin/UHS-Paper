using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperThrowScript : MonoBehaviour {

    public Move target;
    public GameObject paperPrefab;
    private Vector3 InitialPosition;
    private Vector3 direction;

    public float power;
    private float xAxisForce;
    private float yAxisForce;
    
    private bool canLaunch = true;

    private void Awake()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
    }

    // Use this for initialization
    void Start () {
        //direction = move.wantedPosition;
        this.InitialPosition = paperPrefab.transform.position;
        this.target = FindObjectOfType<Move>();
        this.paperPrefab.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        
        this.paperPrefab.GetComponent<Rigidbody>().velocity = new Vector3();
        Time.timeScale = 1;
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
            xAxisForce = target.transform.position.x - this.transform.position.x;
            yAxisForce = target.transform.position.y - this.transform.position.y;

            direction = new Vector3(xAxisForce, yAxisForce*1.6f, -power);
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().velocity = direction;
            Invoke("InstantiateNewBall",3f);
        }
    }

    void InstantiateNewBall()
    {
        CancelInvoke();
        Instantiate(this.paperPrefab, InitialPosition, new Quaternion());
        //Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("trashtrigger"))
        {
            Invoke("InstantiateNewBall", 0f);
        }
    }
}


