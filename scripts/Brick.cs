using Godot;
using System;

public partial class Brick : Sprite2D
{
	Godot.Node2D center;
	Vector2 swing_radius = new Vector2(250,250);
	float random;
	Cursor cursor;
	
	public override void _Ready()
	{
		cursor = GetParent().GetNode<Cursor>("Cursor");
		center = this.GetParent<Godot.Node2D>();
		NewPos();
	}
	
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("Action")){
			switch(GetNode<Area2D>("BrickCollision").HasOverlappingAreas()){
				case true:
					GetNode<Globals>("/root/Globals").Points += 2;
					cursor.reverse = !cursor.reverse;
					cursor.Speed = 5;
					NewPos();
					GetNode<AudioStreamPlayer2D>("Hit").Playing = false;
					GetNode<AudioStreamPlayer2D>("Hit").Playing = true;
					GetParent().GetParent().GetNode<AnimationPlayer>("AnimationPlayer").Stop();
					GetParent().GetParent().GetNode<AnimationPlayer>("AnimationPlayer").Play("shake");
					break;
				case false:
					GetNode<Globals>("/root/Globals").Points -= 2;
					GetNode<AudioStreamPlayer2D>("SoldierDammit").Playing = true;
					break;
			}
			
		}
	}
	
	void NewPos(){
		
		switch(cursor.reverse){
			case false:
				random += Convert.ToSingle(GD.RandRange(0.5, 2));
				break;
			case true:
				random -= Convert.ToSingle(GD.RandRange(0.5, 2));
				break;
		}
		
		
		this.Position = new Vector2(Mathf.Cos(random), Mathf.Sin(random)) * swing_radius;
		this.LookAt(center.Position);
	}
	
	private void _on_brick_collision_area_exited(Area2D area)
	{
		GetNode<Globals>("/root/Globals").Points -= 1;
	}
}



