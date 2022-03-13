using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    
    private Vector2 direction = Vector2.right;          //direction de départ du snake
    public float speed = 0f;
    
    public GameObject eat;
    public GameObject eat2;

    public Transform segmentPrefab;         //stockage des segments depuis l'inspector
    private List<Transform> segments;        //creation de la LIST


    private void Start()
    {
        segments = new List<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            direction = Vector2.up;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            direction = Vector2.left;
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        
        
    }
    
    
    void FixedUpdate()
    {
        //this.transform.position = this.transform.position + direction;           

        this.transform.position = new Vector3(
            this.transform.position.x + direction.x * speed,
            this.transform.position.y + direction.y * speed,
            0);
        //utilisation d'un vector3 car le transform ne peut qu'etre appliqué avec un vector3
        //this = preciser que l'on parle du transforme de cet object (celui du script). pas indispensable mais recommandé.
                                    
    }
    
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Miam1"))
        {
            Debug.Log("J'ai miam 1 !");
            Destroy(eat);
            Transform segment = Instantiate(this.segmentPrefab);    //segment (sans "s") = 1 seul segment.
            segment.position = segments[segments.Count - 1].position;   //segments (avec "s") = la liste de segment.
        }
        
        if(other.gameObject.CompareTag("Miam2"))
        {
            Debug.Log("J'ai miam 2 !");
            Destroy(eat2);
        }
        
        if(other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Perdu !");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
    
    
    
}

