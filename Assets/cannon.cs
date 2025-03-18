using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public ParticleSystem fireFX;
    public Animator animator;
    public Transform fireSocket;
    public float rotationrate = 90;
    public int fired = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationrate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.World);
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            Fire();
        }
    }

    void Fire()
    {
        fired++;
        fireFX.Play();
        animator.SetTrigger("Fire");
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);

    }
}
