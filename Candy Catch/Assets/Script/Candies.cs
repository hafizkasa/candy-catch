using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.gameObject.tag == "Player")
        {
            //increase score
            GameManager.instance.incrementScore();
            Destroy(gameObject);
        }
       else if(collider.gameObject.tag == "Boundary")
        {
            //decrease lives
            GameManager.instance.DecreaseLife();
            Destroy(gameObject);
        }
    }
}
