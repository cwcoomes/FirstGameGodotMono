using Godot;
using System; 

public partial class Coin : Area2D
{
	private GameManager _gameManager;
	private AnimationPlayer _animationPlayer;

	public override void _Ready()
	{
		_gameManager = GetNode<Node>("%GameManager") as GameManager;
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node2D body)
	{
		// Call the "add_point" method on the GameManager
		_gameManager.AddPoint();

		// Play the pickup animation
		_animationPlayer.Play("pickup");
	}
}
