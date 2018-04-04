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

    public Text score;
    private int paperScore;
    
    private bool canLaunch = true;

    private void Awake()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
    }

    // Use this for initialization
    void Start () {
        //direction = move.wantedPosition;
        InitialPosition = paperPrefab.transform.position;
        target = FindObjectOfType<Move>();
        score = FindObjectOfType<Text>();
        paperPrefab.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        
        paperPrefab.GetComponent<Rigidbody>().velocity = new Vector3();
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
            Invoke("InstantiateNewBall",5f);
            Destroy(gameObject, 5f);

        }
    }

    void InstantiateNewBall()
    {
        Instantiate(paperPrefab, InitialPosition, new Quaternion());
    }

    private void OnTriggerEnter(Collider col)   //Panier
    {
        if (col.gameObject.tag == "trashtrigger")
        {
            paperScore++;
            score.text = "Nombre de panier: " + paperScore.ToString();
            Debug.Log(paperScore);
            Debug.Log(score.text);
            Destroy(this.gameObject, 2f);
            InstantiateNewBall();
        }
    }
}


