﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameBoards;

public static class MainVars
{
    public static Sprite[] spriteList;
    public static GameBoard gameBoard;
    public delegate void ValueChanged<T>(T new_value);

    public delegate void EndOfAction(GameObject go);
    public enum gameStates { falling,  calm };
    static MainVars()
    {
        spriteList = Resources.LoadAll<Sprite>("Sprites"); // load all sprites
        gameBoard = Object.FindObjectOfType<GameBoard>();

    }
}
