using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetisObject : MonoBehaviour
{
    float lastFall = 0f;
    
    // public GamePlayController gamePlayController;
    GamePlayController gpc = new GamePlayController();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void moveLeft(){
        // if(Input.GetKeyDown(KeyCode.LeftArrow)){ // if the input id left arrow
        transform.position += new Vector3(-1,0,0); // move tetris object to left by onr unit
        if(IsValidGridPosition()) // check if its new position os valid 
            UpdateMatrixGrid(); // if yes then update it
        else
            transform.position += new Vector3(1,0,0); // if no, then dont move object
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){ // if the input id left arrow
            transform.position += new Vector3(-1,0,0); // move tetris object to left by onr unit
            if(IsValidGridPosition()) // check if its new position os valid 
                UpdateMatrixGrid(); // if yes then update it
            else
                transform.position += new Vector3(1,0,0); // if no, then dont move object

        }else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){ // same for right arrow
            transform.position += new Vector3(1,0,0);
            if(IsValidGridPosition())
                UpdateMatrixGrid();
            else
                transform.position += new Vector3(-1,0,0);

        }else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){// for up arrow we will rotate the object by 90 degree
            transform.Rotate(0,0,-90);// rotate the object
            if(IsValidGridPosition())
                UpdateMatrixGrid();
            else    
                transform.Rotate(0,0,90);

        }else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Time.time - lastFall >= 1){
            // when we press down key or when time passes by one unit  we will move objcet down
            transform.position += new Vector3(0,-1,0);
            if(IsValidGridPosition())
                UpdateMatrixGrid();
            else{
                transform.position += new Vector3(0,1,0);
                MatrixGrid.DeleteWholeRow();    // check if the row is full or not
                if(CheckIfRowAbove()){
                    gpc.GameOver();
                    // Debug.Log("helo");
                }
                FindObjectOfType<Spawner>().spawnRandom();    // spawn new tetris object
                enabled = false;    // as the object cant move further enable the script
            }
            lastFall = Time.time;
        }
    }

    bool IsValidGridPosition (){ // to check that object is inside the border
        foreach (Transform child in transform){
            Vector2 v = MatrixGrid.RoundVector(child.position); // round the position 
        
            if(! MatrixGrid.IsInsideBorder(v)) // if not inside of border
                return false;

            if(MatrixGrid.grid[(int)v.x, (int)v.y] != null && MatrixGrid.grid[(int)v.x , (int)v.y].parent != transform)
                return false;
        }
        return true;
    }


    void UpdateMatrixGrid(){
        for (int y = 0; y < MatrixGrid.column; ++y){
            for(int x =0 ; x < MatrixGrid.row; ++x){
                if(MatrixGrid.grid[x,y] != null){
                    if(MatrixGrid.grid[x,y].parent == transform){
                        MatrixGrid.grid[x,y] = null;
                        //make the tetris object holding the script to null
                    }
                }
            }
        }// removing the childern which are not null and whose parent is tranform

        foreach(Transform child in transform){
            Vector2 v = MatrixGrid.RoundVector(child.position); // firest round the position
            MatrixGrid.grid[(int)v.x, (int)v.y] = child; // assign that coordinate to box of grid

        }//adding the new childern
    }
     

    public bool CheckIfRowAbove(){
        for(int x =0 ; x < MatrixGrid.row; ++x){
            foreach (Transform child in transform){
                Vector2 v = MatrixGrid.RoundVector(child.position);
                if(v.y > 15)
                    return true;
            }
        }
    return false;
    }
}
