using UnityEngine;
using UnityEngine.InputSystem;

public class DragHandler
{
	public  bool		isDragging;
	public	float		speed = 2f;

	private GameObject	selectedObject;
	private Vector2		startMousePosition;
    private Vector2		previousMousePosition;

	private Vector2		centerPos = new Vector2(2f, 0f);

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
		Vector2 mouseDelta = GetMousePos() - previousMousePosition;
		switch(currentMode)
		{
			case dragMode.rotateX:
				  selectedObject.transform.Rotate(Vector3.up, mouseDelta.x, Space.World);
				  break;
			case dragMode.rotateY:
				  selectedObject.transform.Rotate(Vector3.right, -mouseDelta.y, Space.World);
				  break;
			case dragMode.Translate:
				  DoTranslate(mouseDelta);
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

	void DoTranslate(Vector2 mouseDelta)
	{
		Vector2 pos = new Vector2(
				selectedObject.transform.position.x,
				selectedObject.transform.position.y
				);

		if (Mathf.Abs(mouseDelta.x) > Mathf.Abs(mouseDelta.y))
			pos.x += mouseDelta.x * speed * Time.deltaTime;
		else
			pos.y += mouseDelta.y * speed * Time.deltaTime;

		Vector2 dir = pos - centerPos;
		if (dir.magnitude > 2f)
			pos = centerPos + dir.normalized * 2f;

		selectedObject.transform.position = new Vector3(pos.x, pos.y, selectedObject.transform.position.z);			
	}
}
