using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private bool selected;

    GameObject player;
    
    BoxCollider2D collider;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        collider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && selected && Vector3.Distance(player.transform.position, transform.position) < 4)
        {
            Debug.Log(Vector3.Distance(player.transform.position, transform.position));
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            //transform.position = Vector2.MoveTowards(transform.position, mousePosition, 1000);
            rigidbody.velocity =(mousePosition - rigidbody.transform.position) * 8;
            gameObject.layer = LayerMask.NameToLayer("BoxMoving");

        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Ground");
            collider.enabled = true;
            selected = false;
        }

        if(Vector3.Distance(player.transform.position, transform.position) > 6)
        {
            rigidbody.velocity = new Vector2(0,0);
        }

    }

    private void OnMouseDown()
    {
        selected = true;
    }
}
