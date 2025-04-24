using Godot;
using System;

public partial class Slime : Node2D
{
	private const float Speed = 60f;
	private int _direction = 1;

	private RayCast2D _rayCastLeft;
	private RayCast2D _rayCastRight;
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		_rayCastRight = GetNode<RayCast2D>("RayCastRight");
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _Process(double delta)
	{
		var deltaF = (float)delta;

		// Check collisions and flip direction
		if (_rayCastRight.IsColliding())
		{
			_direction = -1;
			_animatedSprite.FlipH = true;
		}

		if (_rayCastLeft.IsColliding())
		{
			_direction = 1;
			_animatedSprite.FlipH = false;
		}

		// Move position
		Position = new Vector2(Position.X + _direction * Speed * deltaF, Position.Y);
	}
}
