using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
public class PlayerAgent : Agent
{
    [Header("Enemy Agent Settings")]
    public float moveSpeed = 1f;
    public float rotateSpeed = 2f;
    public GameObject myBullet;

    PlayerScript me;
    float lastShot;
    float fireRate;
    GameObject firePoint;
    Rigidbody agentRigidbody;
    RayPerception rayPerception;
    // Start is called before the first frame update

    public void Start()
    {
        me = new PlayerScript();
        agentRigidbody = GetComponent<Rigidbody>();
        firePoint = transform.GetChild(2).gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "crate")
        {
            me.setAmo(30);
            Destroy(collision.gameObject);
        }
    }
    public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Determine the rotation action
        float rotateAmount = 0;
        if (vectorAction[1] == 1)
        {
            //transform.Rotate(0f, 0f, 0f);
            rotateAmount = -rotateSpeed;
        }
        else if (vectorAction[1] == 2)
        {
            rotateAmount = rotateSpeed;
            //transform.Rotate(0f, 180f, 0f);
            //firePoint.transform.Rotate(0f, 180f, 0f);
        }
        //transform.Rotate(0f,0f,0f);
        //Apply the rotation
        Vector3 rotateVector = transform.up * rotateAmount;
        agentRigidbody.MoveRotation(Quaternion.Euler(agentRigidbody.rotation.eulerAngles + rotateVector * rotateSpeed));

        // Determine move action
        float moveAmount = 0;
        if (vectorAction[0] == 1)
        {
            moveAmount = moveSpeed;
        }
        else if (vectorAction[0] == 2)
        {
            moveAmount = moveSpeed * -1f; // move at half-speed going backwards
        }

        if(vectorAction[2] == 1)
        {
            Shoot();
            Debug.Log("Shoot");
        }
        // Apply the movement
        Vector3 moveVector = transform.forward * moveAmount;
        agentRigidbody.AddForce(moveVector * moveSpeed, ForceMode.VelocityChange);

        // Determine state
    }

    public void Shoot()
    {
        if(me.getAmo() > 0)
        {
            me.setAmo(-1);
            GameObject bulletObect = Instantiate(myBullet, firePoint.transform.position, firePoint.transform.rotation);
            bulletObect.AddComponent<bulletBehavior>();
            bulletObect.GetComponent<Rigidbody>().AddForce(transform.forward * 8f);
            bulletObect.GetComponent<bulletBehavior>().setPower(me.getPower());
        }    
    }
}
