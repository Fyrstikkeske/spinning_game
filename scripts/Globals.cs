using Godot;
using System;

public partial class Globals : Node
{
	public Int32 Points = 0;
	
	public Vector2 HalfScreen = new Vector2(500,500);
	
	public override void _Input(InputEvent @event){
		if (@event.IsActionPressed("Quit"))
			GetTree().Quit();
	}
}
