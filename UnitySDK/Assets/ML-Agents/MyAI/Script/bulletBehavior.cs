using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    int power;

    public bulletBehavior(int power)
    {
        this.power = power;
    }
    //public myArea area;
    //public float speed = 5f;
    void Start()
    {

    }

    public void setPower(int power)
    {
        this.power = power;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.name == "Player")
        {
            PlayerScript PS = collision.gameObject.GetComponent<PlayerScript>();
            PS.setHP(-power);
            Debug.Log(PS.getHP());
            Destroy(this.gameObject);
        }

        
    }
}
