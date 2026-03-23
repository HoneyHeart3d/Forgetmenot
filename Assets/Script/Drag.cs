using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private PlayerMovement playermovement;
    private bool dragging = false;
    private Vector3 offset;
    private BoxCollider2D child;
    void Start()
    {
        child = gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>();
        playermovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (playermovement.Groundcheck())
            if (dragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
    }
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        child.enabled = false;
        dragging = true;
    }
    private void OnMouseUp()
    {
        child.enabled = true;
        dragging = false;
    }
}
