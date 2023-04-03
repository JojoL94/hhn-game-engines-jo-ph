using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDebugging : MonoBehaviour
{
    private SpringJoint sj;

    private Vector3 origin;
    // Start is called before the first frame update
    void Awake()
    {
        sj = GetComponent<SpringJoint>();
        origin = transform.position + sj.anchor;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(sj.connectedBody.transform.position + sj.connectedAnchor, sj.transform.position);
    }
}
