using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject diamondCollectable;

    // Start is called before the first frame update
    void Start()
    {
        int randDiamond = Random.Range(0,55);

        Vector3 diamondPos = transform.position;
        diamondPos.y += 1f;

        if(randDiamond < 1)
        {
            //spawnar o diamante
           GameObject diamondInstance =  Instantiate(diamondCollectable, diamondPos,diamondCollectable.transform.rotation);
           
           diamondInstance.transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.5f);
        }

    }
    

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 3f);
    }
}
