using Godot;
using System;

public partial class Cursor : Sprite2D
{
	Godot.Node2D center;
	float timer;
	Vector2 swing_radius = new Vector2(250,250);
	public bool reverse = false;
	public float Speed = 5f;
	
	
	public override void _Ready()
	{
		center = this.GetParent<Godot.Node2D>();
	}
	
	
	public override void _Process(double delta)
	{
		switch(reverse){
			case false:
				timer += Convert.ToSingle(delta) * Speed;
				break;
			case true:
				timer -= Convert.ToSingle(delta) * Speed;
				break;
		}
		
		
		Speed = 5/Speed + 0;
		
		if (timer >= 3.14*2 | timer <= -3.14*2)
			timer = 0;
		
		
		this.Position = new Vector2(Mathf.Cos(timer), Mathf.Sin(timer)) * swing_radius;
		
		this.LookAt(center.Position);
	}
}
