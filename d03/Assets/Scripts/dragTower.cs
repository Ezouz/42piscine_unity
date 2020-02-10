using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragTower : EventTrigger
{
    private bool dragging;
    public Vector3 initPos;
    public Vector3 drop;
    public Collider2D tile;
    public bool ADD = false;
    public bool block = false;
    public Vector3 screenPos;

    void Start()
    {
        initPos = transform.position;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!block) {
            dragging = true;
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (!block) {
            screenPos = Input.mousePosition;
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
            if (hit.collider) {
                if (hit.collider.tag == "empty")
                {
                    drop = new Vector3(position.x, position.y, 0);
                    ADD = true;
                    tile = hit.collider;
                }
                dragging = false;
                transform.position = initPos;
            }
        }
    }
    void Update()
    {
        if (!block)
        {
            if (dragging) {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
            }
        }
    }
}
