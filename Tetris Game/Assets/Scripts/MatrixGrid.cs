using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid : MonoBehaviour
{
    public static int row = 10;
    public static int column = 20;
    
    
    public static Transform[,] grid = new Transform[row, column];

    
    public static Vector2 RoundVector(Vector2 v){
        return new Vector2(Mathf.Round(v.x) , Mathf.Round(v.y));
        //to get a rounded value while moving and rotating tetris object
        
    } 

    public static bool IsInsideBorder(Vector2 pos){
        return ((int)pos.x >= 0 && (int)pos.x < row && (int)pos.y >= 0);
        //to check that tetris objetc is inside game border
    }
    
    public static void DeleteRow(int y){
        for (int x = 0; x < row; ++x){
            GameObject.Destroy(grid[x,y].gameObject); // delete the game object on that position
            grid[x,y] = null; // make a sapce empty for that position
        }
    }

    public static void DecreaseRow(int y){
        for(int x = 0; x < row ; ++x){
            if(grid[x,y] != null){
                grid[x ,y-1] = grid[x,y]; // move one row down
                grid[x,y] = null; // make that row null

                grid[x,y-1].position += new Vector3(0,-1,0); // update tha position
            }
        }
    }

    public static void DecreaseRowAbove(int y){ // decrease all the row
        for(int i = y ; i < column; ++i){
            DecreaseRow(i); 
        }
    }

    public static bool IsRowFull(int y){ // to check that if the whole row is full or not
        for(int x = 0 ; x < row ; ++x){
            if(grid[x,y]  == null)
                return false;
        }
        return true;
    }

    public static void DeleteWholeRow(){
        for(int y =0;y<column ;y++){
            if(IsRowFull(y)){
                DeleteRow(y);
                DecreaseRowAbove(y + 1);
                --y;
            }
        }
    }
}
