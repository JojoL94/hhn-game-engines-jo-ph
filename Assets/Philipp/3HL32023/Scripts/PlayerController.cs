using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ballPrefab, hand, objInhand;

    public GameObject camera;
    public int throwForce;
    public LayerMask interactionMask;
    public float maxDist = 20;

    public float attrForce;

    public float grabDist;

    public float slowScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale ==1)
            {
                Time.timeScale = slowScale;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = new Ray(camera.transform.position, camera.transform.forward);
            Debug.DrawLine(ray.origin, ray.GetPoint(maxDist));
            RaycastHit obj;
            if(Physics.Raycast(ray, out obj, maxDist, interactionMask))
            {
                if (Vector3.Distance(hand.transform.position, obj.transform.position) < grabDist)
                {
                    objInhand = obj.transform.gameObject;
                    obj.transform.position = hand.transform.position;
                    obj.transform.parent = hand.transform;
                    obj.transform.GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    Vector3 dir = (hand.transform.position - obj.transform.position).normalized;
                    obj.rigidbody.AddForce(dir * attrForce, ForceMode.Impulse);
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(objInhand !=null)
            {
                objInhand.transform.parent = null;
                objInhand.GetComponent<Rigidbody>().isKinematic = false;
                objInhand.GetComponent<Rigidbody>().AddForce(camera.transform.forward * throwForce, ForceMode.Impulse);
                objInhand = null;
            }
            else
            {
                GameObject ball = Instantiate(ballPrefab, hand.transform.position, new Quaternion(0, 0, 0, 0));
                Rigidbody ballRB = ball.GetComponent<Rigidbody>();
                ballRB.AddForce(camera.transform.forward * throwForce, ForceMode.Impulse);
            }
        }
        
    }
}
