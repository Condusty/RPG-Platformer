using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    public PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, new Vector2(playerMovement.direction, -1), rayDistance);

        if(hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            //grab object
            if(Keyboard.current.eKey.wasPressedThisFrame && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
                //grabbedObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else if(Keyboard.current.eKey.wasPressedThisFrame)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                //grabbedObject.GetComponent<BoxCollider2D>().enabled = true;
                grabbedObject = null;
            }
        }

        Debug.DrawRay(rayPoint.position, new Vector2(playerMovement.direction, 0) * rayDistance);
    }
}
