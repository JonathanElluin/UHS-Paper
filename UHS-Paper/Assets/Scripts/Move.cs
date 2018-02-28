using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector3 wantedPositon;         //La position désirée
    public bool useLerp = false;         //Si on utilise la fonction Lerp dans notre Update
    public float speed;            //La vitesse de déplacement si on utilise MoveToward
    public float damping = 1f;            //Le facteur du lerp
                                          //damping = 0 -> L'ojet ne se déplacera pas
                                          //damping = 1000 -> L'objet ira à la position instantanement

    private int direction;
    private bool hasHitLeft;
    private bool hasHitRight;
    public Transform DummyRightPos;
    public Transform DummyLeftPos;

    void Start()
    {
        wantedPositon = transform.position; //Pour que l'objet soit à sa place initiale dans la scene
        hasHitLeft = true;
    }

    void Update()
    {
        if(transform.position.x >= DummyRightPos.position.x)
        {
            hasHitRight = true;
            hasHitLeft = false;
        }
        if(transform.position.x <= DummyLeftPos.position.x)
        {
            hasHitLeft = true;
            hasHitRight = false;
        }

        if (transform.position.x < DummyRightPos.position.x && hasHitLeft && !hasHitRight )
        {
            direction = 1;
        }
        else
        {
            if (transform.position.x > DummyLeftPos.position.x && hasHitRight && !hasHitLeft)
            {
                direction = -1;
            }
        }


        transform.position = transform.position + new Vector3(speed * direction * Time.deltaTime, 0, 0);
    }

    //Fonction que tu utilisera avec tes autres scripts
    public void MoveTo(Vector3 position, bool lerped = false)
    {
        useLerp = lerped;
        wantedPositon = position;
    }
}

