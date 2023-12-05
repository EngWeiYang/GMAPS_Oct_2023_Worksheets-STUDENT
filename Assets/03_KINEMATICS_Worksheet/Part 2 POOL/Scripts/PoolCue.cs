using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolCue : MonoBehaviour
{
	public LineFactory lineFactory;
	public GameObject ballObject;
	private Line drawnLine;
	private Ball2D ball;
	private void Start()
	{
		ball = ballObject.GetComponent<Ball2D>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get mouse position while left click is held

			if (ball != null && ball.IsCollidingWith(mousePos.x, mousePos.y))  //If ball object exists and is clicked
			{
				drawnLine = lineFactory.GetLine(ball.transform.position, mousePos, 3f, Color.black);  //Creates a line drawing from the ball to the mouse position
																									  //of size 3f and black in color
				drawnLine.EnableDrawing(true);  //Pass in true value to function to start the drawing
			}
		}

		else if (Input.GetMouseButtonUp(0) && drawnLine != null)  //Left click released
		{
			drawnLine.EnableDrawing(false);  //Pass in false value to function to disable line drawing

			HVector2D v = new HVector2D(drawnLine.end - drawnLine.start);  //Set velocity of the white ball.
			ball.Velocity = v;  //Update the velocity of the white ball.

			drawnLine = null; //Reset drawnLine to null
		}

		if (drawnLine != null)
		{
			drawnLine.end = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //Update ending position of line drawing to current mouse position if
																				  //drawnLine is not null (meaning left click is still held)
        }
	}
	
	/// <summary>
	/// Get a list of active lines and deactivates them.
	/// </summary>
	public void Clear()
	{
		var activeLines = lineFactory.GetActive();
		foreach (var line in activeLines)
		{
			line.gameObject.SetActive(false);
		}
	}
}