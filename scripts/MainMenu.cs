using Godot;
using System;

public partial class MainMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode("Sprite2D").GetNode<AnimationPlayer>("AnimationPlayer").Play("menu");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GetNode<Globals>("/root/Globals").HalfScreen = GetViewportRect().Size / new Vector2(2,2);
		this.Position = GetNode<Globals>("/root/Globals").HalfScreen;
	}
	
	private void _on_animation_player_animation_finished(StringName anim_name)
	{
		GetNode("Sprite2D").GetNode<AnimationPlayer>("AnimationPlayer").Play("menu");
	}

	private void _on_start_game_button_down()
	{
		var GameWorld = (PackedScene)ResourceLoader.Load("res://scenes/game.tscn");
		GetTree().ChangeSceneToPacked(GameWorld);
	}
}



