using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb.tag == "Projectile")
        {
            //Rotate the sprite about the Y axis in the positive direction
            //projectile.transform.Rotate(new Vector3(0, 90, 0));
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            // projectile.velocity = transform.forward * speed;
            //rb.transform.Translate(Vector3.down * speed * Time.deltaTime);
            rb.velocity = new Vector3(10, 0, 0);
        } else if (rb.tag == "Hazardbox")
        {
            //Debug.Log(rb.tag);
            //Rotate the sprite about the Y axis in the positive direction
            //projectile.transform.Rotate(new Vector3(0, 90, 0));
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            // projectile.velocity = transform.forward * speed;
            //rb.transform.Translate(Vector3.left * speed * Time.deltaTime);
            rb.velocity = new Vector3(0, -5, 0);
        } 
    }

}
