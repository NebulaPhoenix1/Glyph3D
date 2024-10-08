using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Swipe : MonoBehaviour
{
    public MOve m;
    private Vector3 Startmousepos;
    public bool hit;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;    
    }
    private void Awake()
    {
        
    }
    public void OnEnterDrag(PointerEventData eventData)
    {
        
    }
    private void OnMouseDrag()
    {

        Debug.Log("Press position + " + Input.mousePosition);
        Debug.Log("End position + " + Input.mousePosition);
       // Vector3 dragVectorDirection = (.position - eventData.pressPosition).normalized;
       // Debug.Log("norm + " + dragVectorDirection);
       // GetDragDirection(dragVectorDirection);

    }
   /// public void OnEndDrag(PointerEventData eventData)
   /// {
     //   Debug.Log("Press position + " + eventData.pressPosition);
      ///  Debug.Log("End position + " + eventData.position);
       // Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
      //  Debug.Log("norm + " + dragVectorDirection);
       // GetDragDirection(dragVectorDirection);
   // }
    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        Debug.Log(draggedDir);
        return draggedDir;
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Startmousepos = ray.origin;
            if (Physics.Raycast(ray, out RaycastHit cube))
            {
                hit = true;
                Debug.Log(Startmousepos);
            }
            if (hit)
            {
                Debug.Log("hit");

            }
        }


        if ((Input.GetMouseButtonUp(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            DraggedDirection dd = GetDragDirection(ray.origin - Startmousepos);
           
            if (Physics.Raycast(ray, out RaycastHit cube))
            {
                if (cube.collider.gameObject.GetComponent<ObjectCheck>().enabled)
                {
                    cube.collider.gameObject.GetComponent<ObjectCheck>().Check(dd.ToString());
                }
            }


         

        }
    }
}
