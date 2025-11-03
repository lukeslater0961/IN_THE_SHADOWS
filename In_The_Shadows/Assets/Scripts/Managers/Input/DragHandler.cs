using UnityEngine;
using UnityEngine.InputSystem;

public class DragHandler
{
	public  bool		isDragging;
	public	float		speed = 2f;

	private GameObject	selectedObject;
	private Vector2		startMousePosition;
    private Vector2		previousMousePosition;

	public  enum dragMode{None, rotateY, rotateX, Translate};
	private		 dragMode currentMode = dragMode.None;

	Vector2 GetMousePos()
	{
		return Mouse.current.position.ReadValue();
	}

	public void HandleDrag(dragMode mode)
	{
		currentMode = mode;
		StartManipulation();
	}

	public void StartManipulation()
	{
		RaycastHit hit;
		startMousePosition = GetMousePos();
		Ray ray = Camera.main.ScreenPointToRay(startMousePosition);
		previousMousePosition = startMousePosition;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			selectedObject = hit.collider.gameObject;
			isDragging = true;
		}
	}

	public void DoMode()
	{
		Vector2 mouseDelta = Mouse.current.position.ReadValue() - previousMousePosition;
		switch(currentMode)
		{
			case dragMode.rotateX:
				  selectedObject.transform.Rotate(Vector3.up, mouseDelta.x, Space.World);
				  break;
			case dragMode.rotateY:
				  selectedObject.transform.Rotate(Vector3.right, -mouseDelta.y, Space.World);
				  break;
			case dragMode.Translate:
				  selectedObject.transform.Translate(mouseDelta * speed * Time.deltaTime, Space.World);
				  break;
		}
		previousMousePosition = GetMousePos();
	}

	public void EndDrag()
	{
		isDragging = false;
		currentMode = dragMode.None;
		if (GetMousePos() != startMousePosition)
			ShadowChecker.instance.CheckShadow();
	}
}
