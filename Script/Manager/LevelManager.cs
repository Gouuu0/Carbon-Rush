using Godot;
using System;

public class LevelManager : Node
{
    [Export] private NodePath OBJECT_CONTAINER_PATH;
    [Export] private NodePath PLAYER_CONTAINER_PATH;
    [Export] private NodePath ENEMIES_CONTAINER_PATH;
    [Export] private NodePath WALLS_CONTAINER_PATH;

    private Node2D objectContainer;
    private Node2D playerContainer;
    private Node2D enemyContainer;
    private Node2D wallsContainer;

    public override void _Ready()
    {
        objectContainer = GetNode<Node2D>(OBJECT_CONTAINER_PATH);
        playerContainer = GetNode<Node2D>(PLAYER_CONTAINER_PATH);
        enemyContainer = GetNode<Node2D>(ENEMIES_CONTAINER_PATH);
        wallsContainer = GetNode<Node2D>(WALLS_CONTAINER_PATH);
    }
}
