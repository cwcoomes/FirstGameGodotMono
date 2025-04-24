using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Constants
	private const float Speed = 130.0f;
	private const float JumpVelocity = -300.0f;

	// Gravity from project settings
	private float _gravity;

	// Animated sprite reference
	private AnimatedSprite2D _animatedSprite;

	public override void _Ready()
	{
		_gravity = (float)ProjectSettings.GetSetting("physics/2d/default_gravity");
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		var deltaF = (float)delta;

		// Apply gravity
		if (!IsOnFloor())
			Velocity = new Vector2(Velocity.X, Velocity.Y + _gravity * deltaF);

		// Handle jumping
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			Velocity = new Vector2(Velocity.X, JumpVelocity);

		// Get movement direction (-1, 0, 1)
		float direction = Input.GetAxis("move_left", "move_right");

		// Flip sprite
		if (direction > 0)
			_animatedSprite.FlipH = false;
		else if (direction < 0)
			_animatedSprite.FlipH = true;

		// Set animations
		if (IsOnFloor())
		{
			if (direction == 0)
				_animatedSprite.Play("idle");
			else
				_animatedSprite.Play("run");
		}
		else
		{
			_animatedSprite.Play("jump");
		}

		// Apply horizontal movement
		if (direction != 0)
		{
			Velocity = new Vector2(direction * Speed, Velocity.Y);
		}
		else
		{
			Velocity = new Vector2(Mathf.MoveToward(Velocity.X, 0, Speed), Velocity.Y);
		}

		// Move the character
		MoveAndSlide();
	}
}
