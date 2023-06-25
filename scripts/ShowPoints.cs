using Godot;
using System;

public partial class ShowPoints : RichTextLabel
{
	public override void _Process(double delta)
	{
		this.Position = GetNode<Globals>("/root/Globals").HalfScreen + new Vector2(0,40);
		this.Text = "[center]" + GetNode<Globals>("/root/Globals").Points.ToString();
	}
}
