using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
   public float tumble;
   private Rigidbody box;
   void Start ()
   {
       box = GetComponent<Rigidbody>();
       box.angularVelocity = Random.insideUnitSphere * tumble; // Vector3 with random x y z
   }
}
