using UnityEngine.InputSystem;
using UnityEngine;

public class Level1Rules : ILevelInputRules
{
	private DragHandler dragHandler;

	public Level1Rules(DragHandler dragHandler)
    {
		this.dragHandler = dragHandler;
    }

    public void HandleLevelInput(InputAction mouseClick)
    {
		if (mouseClick.WasPressedThisFrame())
			dragHandler.HandleDrag(DragHandler.dragMode.rotateX);

		if (dragHandler.isDragging)
			dragHandler.DoMode();
			
		if (mouseClick.WasReleasedThisFrame())
			dragHandler.EndDrag();
    }
}

public class Level2Rules : ILevelInputRules
{
	private DragHandler dragHandler;

	public Level2Rules(DragHandler dragHandler)
    {
		this.dragHandler = dragHandler;
    }

    public void HandleLevelInput(InputAction mouseClick)
    {
        if (mouseClick.WasPressedThisFrame() && !Keyboard.current.leftCtrlKey.isPressed)
			dragHandler.HandleDrag(DragHandler.dragMode.rotateX);
		else if (mouseClick.WasPressedThisFrame() && Keyboard.current.leftCtrlKey.isPressed)
			dragHandler.HandleDrag(DragHandler.dragMode.rotateY);
		
		if (dragHandler.isDragging)
			dragHandler.DoMode();
			
		if (mouseClick.WasReleasedThisFrame())
			dragHandler.EndDrag();
    }
}

public class Level3Rules : ILevelInputRules
{
	private DragHandler dragHandler;

	public Level3Rules(DragHandler dragHandler)
    {
		this.dragHandler = dragHandler;
    }

    public void HandleLevelInput(InputAction mouseClick)
    {
		if (mouseClick.WasPressedThisFrame() && Keyboard.current.leftCtrlKey.isPressed)
			dragHandler.HandleDrag(DragHandler.dragMode.rotateY);
		else if (mouseClick.WasPressedThisFrame() && Keyboard.current.leftShiftKey.isPressed)
			dragHandler.HandleDrag(DragHandler.dragMode.Translate);
		else if (mouseClick.WasPressedThisFrame())
			dragHandler.HandleDrag(DragHandler.dragMode.rotateX);

		if (dragHandler.isDragging)
			dragHandler.DoMode();
			
		if (mouseClick.WasReleasedThisFrame())
			dragHandler.EndDrag();
	}
}
