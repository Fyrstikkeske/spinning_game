using Godot;
using System;

public partial class Center : Node2D
{
	public override void _Process(double delta)
	{
		GetNode<Globals>("/root/Globals").HalfScreen = GetViewportRect().Size / new Vector2(2,2);
		this.Position = GetNode<Globals>("/root/Globals").HalfScreen;
	}
}
