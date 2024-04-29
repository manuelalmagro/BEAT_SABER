using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material materialRed;
    public bool blue;
    public int angle;
    public float speed;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != angle)
                transform.GetChild(i).gameObject.SetActive(false);
            else if (!blue)
                transform.GetChild(i).GetComponent<MeshRenderer>().material = materialRed;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.back * speed);
    }

    public void CollisionDetected(bool _blue)
    {
        if (_blue == blue)
        {
            print("Ha golpeado el color correcto");
            GameManager.manager.UpdateScore();
        }
        else
        {
            print("Te has equivocado de color");
            GameManager.manager.Takedamage();
        }
        Destroy(gameObject);
        GetComponent<Collider>().enabled = false;
    }

    private void OnCollisionEnter(Collision x)
    {
        if (x.gameObject.CompareTag("Left") || x.gameObject.CompareTag("Right"))
        {
            if (x.gameObject.GetComponent<Saber>().angle == angle)
                CollisionDetected(x.gameObject.GetComponent<Saber>().blue);
            else
            {
                print("Has llegado al centro");
                GameManager.manager.Takedamage();
                Destroy(gameObject);
            }
            
        }
    }
}
