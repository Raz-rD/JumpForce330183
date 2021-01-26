using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //variables
    private float speed = 30;
    private float leftBound = -15;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {   //playercontroller component binnenhalen
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {   //alles naar links bewegen
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }   
        //als het te ver naar links gaat wordt het weggehaald
        if (transform.position.x < leftBound && gameObject.CompareTag("Object"))
        {
            Destroy(gameObject);
        }
    }
}
