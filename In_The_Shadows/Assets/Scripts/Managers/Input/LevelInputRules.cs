using UnityEngine.InputSystem;
using UnityEngine;

public struct DragSettings
{
	public static bool isDragging;
	public static float rotationSpeed;
	public static GameObject obj;

	static DragSettings()
    {
        rotationSpeed = 1f;
        isDragging = false;
		obj = null;
    }
}

public class Level1Rules : ILevelInputRules
{
	private DragRotate dragRotate;

	public Level1Rules()
    {
        dragRotate = new DragRotate();
    }

    public void HandleLevelInput(InputAction mouseClick)
    {
		if (mouseClick.WasPressedThisFrame())
		{
			RaycastHit hit;
			Vector2 mousePos = Mouse.current.position.ReadValue();
			Ray ray = Camera.main.ScreenPointToRay(mousePos);

			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				DragSettings.obj = hit.collider.gameObject;
				DragSettings.isDragging = true;
				dragRotate.StartDrag(mousePos);
			}
		}

		if (mouseClick.WasReleasedThisFrame())
		{
			DragSettings.isDragging = false;
			DragSettings.obj = null;
			dragRotate.EndDrag();
		}

		if (DragSettings.isDragging)
			dragRotate.Rotate(Vector3.up);
    }
}

public class Level2Rules : ILevelInputRules
{
    public void HandleLevelInput(InputAction mouseClick)
    {
        Debug.Log("level2 rules");
    }
}

public class Level3Rules : ILevelInputRules
{
    public void HandleLevelInput(InputAction mouseClick)
    {
        Debug.Log("level3 rules");
    }
}

public class DragRotate
{
    private Vector2 previousMousePosition;

    public void StartDrag(Vector2 mousePos)
    {
        previousMousePosition = mousePos;
    }

	public void EndDrag()
	{
		ShadowChecker.instance.CheckShadow();
	}

    public void Rotate(Vector3 axis)
    {
        Vector2 mouseDelta = Mouse.current.position.ReadValue() - previousMousePosition;
        DragSettings.obj.transform.Rotate(axis, mouseDelta.x * DragSettings.rotationSpeed, Space.World);
        previousMousePosition = Mouse.current.position.ReadValue();
    }
}
