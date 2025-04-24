using Godot;
using System;

public partial class GameManager : Node
{
	private int _score;
	private Label _scoreLabel;

	public override void _Ready()
	{
		_score = 0;
		_scoreLabel = GetNode<Label>("ScoreLabel");
	}

	public void AddPoint()
	{
		_score++;
		_scoreLabel.Text = $"You collected {_score} coins.";
	}
}
