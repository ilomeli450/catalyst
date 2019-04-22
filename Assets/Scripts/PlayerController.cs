using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //makes properties visible in inspector 
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class PlayerController : MonoBehaviour
{
    private Rigidbody player;
    private AudioSource audioSource;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public Object projectile;
    public Transform projectileSpawn;
    public float fireRate;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal,moveVertical,0.0f);
        //player.AddForce(movement);
        //player.velocity = movement;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Object clone = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation) as Object;
            audioSource.Play();
            //Rigidbody clone = Instantiate(projectile, projectile.position, projectile.rotation) as Rigidbody;
        }
        //position is vector3 rotation is quaternion
        // obtain from game object
        float moveHorizontal = 0;
        float moveVertical = 0;
        player = GetComponent<Rigidbody>();
        if(Input.GetKey(KeyCode.A))
            moveHorizontal = -1;
        if (Input.GetKey(KeyCode.D))
            moveHorizontal = 1;
        if (Input.GetKey(KeyCode.S))
            moveVertical = -1;
        if (Input.GetKey(KeyCode.W))
            moveVertical = 1;
        // Debug.Log(moveHorizontal);
        // float moveVertical = Input.GetAxis("Vertical");
        // Debug.Log(moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        // Debug.Log(movement.ToString("F4"));
        player.AddForce(movement);
        // player.velocity = movement;
        Vector3 pos = player.transform.position;
        Vector3 noVelocity = new Vector3(0,0,0);
        if (pos.x > boundary.xMax || pos.x < boundary.xMin) {
            player.velocity = noVelocity;
        } 
        if (pos.y > boundary.yMax || pos.y < boundary.yMin)
        {
            player.velocity = noVelocity;
        }
        player.position = new Vector3
        (
            Mathf.Clamp(player.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(player.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
        player.rotation = Quaternion.Euler(player.velocity.y * -tilt ,0.0f, 0.0f);
    }
}
