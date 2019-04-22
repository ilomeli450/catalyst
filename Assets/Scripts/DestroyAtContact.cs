using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerDiesExplosion;
    private int scoreValue = 5;
    private GameController gameController;
    // Marks objects to be destroyed
    // At end of frame, all marked objects are deleted
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerDiesExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        
        //Debug.Log(other.name); 
        // Print's name of other gameobject
        Destroy(other.gameObject); // Destroys projectile as it hits hazard box
        Destroy(gameObject); // Destroys hazard box itself
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(scoreValue);
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) //test reference
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
