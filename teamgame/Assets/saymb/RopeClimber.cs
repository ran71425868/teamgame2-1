using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class RopeClimber : MonoBehaviour
{
    public float climbSpeed = 3f;
    private HashSet<Collider> ropeContacts = new HashSet<Collider>();
    private bool atTop = false;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (IsClimbing() && !atTop)
        {
            Vector3 climbMovement = Vector3.up * climbSpeed * Time.deltaTime;
            controller.Move(climbMovement);
        }
    }

    private bool IsClimbing()
    {
        return ropeContacts.Count > 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rope"))
        {
            ropeContacts.Add(other);
        }
        else if (other.CompareTag("Top"))
        {
            atTop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Rope"))
        {
            ropeContacts.Remove(other);
        }
        else if (other.CompareTag("Top"))
        {
            atTop = false;
        }
    }
}