using System.Collections;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float delayTime = 1.0f;
    public ParticleSystem explosionFX;
    public float explosionRadius = 5f;         // Radius of explosion effect
    public float explosionForce = 700f;        // Force of explosion
    public float upwardModifier = 1f;         // How much force is applied upwards

    // Called when the object collides with something
    private void OnCollisionEnter(Collision collision)
    {
        explosionFX.Play();
        StartCoroutine(TriggerExplosionWithDelay());  // Correctly start the coroutine
    }

    // Coroutine to handle the delay and then trigger the explosion
    IEnumerator TriggerExplosionWithDelay()
    {
        // Wait for the specified time (delay)
        yield return new WaitForSeconds(delayTime);

        // Call the method to trigger the explosion (could be any effect, sound, etc.)
        Explode();
    }

    // Call this method to trigger the explosion
    public void Explode()
    {
        

        // Get nearby objects using OverlapSphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply explosion force to the rigidbody objects
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardModifier);
            }
        }

        // Optionally destroy the object this script is attached to after the explosion
        Destroy(gameObject);
    }

    // Optional: Draw a gizmo in the editor to visualize the explosion radius
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}