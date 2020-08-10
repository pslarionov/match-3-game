﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float scale = 1.25f;
    public Sprite sprite;
    Image image;
    BoxCollider2D col;
    public int row, column;

    /// <summary>
    /// randomezes type of tile
    /// </summary>
    public void RandomizeTile()
    {
        sprite = MainVars.spriteList[Random.Range(0, MainVars.spriteList.Length)];
        name = sprite.name;
    }

    public void OnSelected()
    {
        image.color = Color.grey;
    }
    public void OnDeselected()
    {
        image.color = Color.white;
    }


    /// <summary>
    /// checks if this tile and provided are same
    /// </summary>
    /// <param name="tile"></param>
    /// <returns></returns>
    public bool IsSame(Tile tile)
    {
        return sprite == tile.sprite;
    }

    /// <summary>
    /// placing tile in cell and defining its row and column
    /// </summary>
    /// <param name="localposition"></param>
    /// <param name="_row"></param>
    /// <param name="_column"></param>
    public void PlaceInCell(Vector3 localposition, int _row, int _column)
    {
        transform.localPosition = localposition;
        row = _row;
        column = _column;
        if (image == null)
        {
            image = gameObject.AddComponent<Image>();
            image.sprite = sprite;

            image.transform.localScale = Vector3.one * scale;
        }
        if (col == null)
        {
            col = gameObject.AddComponent<BoxCollider2D>();
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (MainVars.gameBoard.selectedTile == null)           // no selected tile
        {
            OnSelected();
            MainVars.gameBoard.selectedTile = this;
        }
        else
        {
            if (MainVars.gameBoard.selectedTile == this)       // if clicking on same tile as selected
            {
                OnDeselected();
                MainVars.gameBoard.selectedTile = null;
            }
            else                                             // clicking on another tile 
            {
                MainVars.gameBoard.TrySwapTiles(this);
            }
        }
    }
}
