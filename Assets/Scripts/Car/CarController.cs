using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 100f;
    private bool MovingLeft = true;
    private bool firstInput = true;


    public GameObject pickUpEffect;
    
    //private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            MoveCar();
            CheckInput();

            if(transform.position.y <= -2)
            {
                GameManager.instance.GameOver();
            }
        }

        
    }

    void MoveCar()
    {
       transform.position += transform.forward * speed * Time.deltaTime;
    }

    void CheckInput()
    {
        //se for a primeira entrada ignora
        if (firstInput)
        {
            firstInput = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (MovingLeft)
        {
            MovingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            MovingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            GameManager.instance.incrementsScore();

            Instantiate(pickUpEffect, other.transform.position, pickUpEffect.transform.rotation);


            other.gameObject.SetActive(false);
            
        }
    }
}
