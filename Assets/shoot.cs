using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class shoot : MonoBehaviour
{
    public new Rigidbody rigidbody;

    public float force = 15;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Vector3 forcedirection = transform.forward;
        rigidbody.AddForce(forcedirection * force, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rigidbody.velocity;
        transform.rotation = Quaternion.LookRotation(velocity);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("castle"))
        {
            
        }
    }
}
