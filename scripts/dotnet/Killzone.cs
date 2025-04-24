using Godot;
using System;

public partial class Killzone : Area2D
{
	private Timer _timer;

	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
		_timer.Timeout += OnTimerTimeout;

		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		GD.Print("You died!");
		Engine.TimeScale = 0.5f;

		var collisionShape = body.GetNodeOrNull<CollisionShape2D>("CollisionShape2D");
		if (collisionShape != null)
		{
			collisionShape.QueueFree();
		}

		_timer.Start();
	}

	private void OnTimerTimeout()
	{
		Engine.TimeScale = 1.0f;
		GetTree().ReloadCurrentScene();
	}
}
