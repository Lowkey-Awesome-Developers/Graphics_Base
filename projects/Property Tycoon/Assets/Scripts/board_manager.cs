using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board_manager : MonoBehaviour
{
    // a list of locations on the board
    public GameObject[] locations;
    public GameObject[] pieces;
    int currentloc;
    int diceRoll;
    bool moving = false;
    int moveindex;
    // a dictionary of game pieces and their location on the board
    public Dictionary<string, GameObject> pieceCurrentLoc = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // If game piece is being used set active. For when more game pieces are introduced.
        pieceCurrentLoc.Add("goblet", locations[0]);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !moving){
            

            diceRoll = Random.Range(1, 7);
            Debug.Log(diceRoll);
            // Use a list for game pieces. A list for game location objects. A dictionary for current location of game piece.

            StartCoroutine(move());

            //while (pieces[0].transform.position != locations[currentloc + diceRoll].transform.position){
            //    currentloc = System.Array.IndexOf(locations, pieceCurrentLoc["goblet"]);
            //    pieces[0].transform.position = Vector3.MoveTowards(pieces[0].transform.position, locations[currentloc + diceRoll].transform.position, 0.5f);
               // my_dict[testpiece];
            //}

            // if (pieces[0].transform.position == locations[currentloc + diceRoll].transform.position) {
            //     pieceCurrentLoc["goblet"] = locations[currentloc + diceRoll];

            // }
            //}
        }
    }

    // IEnumerator move(){
    //     moving = true;
    //     currentloc = System.Array.IndexOf(locations, pieceCurrentLoc["goblet"]);
    //     //

    //     int overlap = (IndexOf(locations, pieceCurrentLoc["goblet"]) + diceRoll) - 40; 

    //     while (pieces[0].transform.position != locations[currentloc + diceRoll].transform.position){
                
    //             pieces[0].transform.position = Vector3.MoveTowards(pieces[0].transform.position, locations[currentloc + diceRoll].transform.position, 0.5f);
    //             // my_dict[testpiece];
    //             yield return null;
    //     }

    //     if (pieces[0].transform.position == locations[currentloc + diceRoll].transform.position) {
    //             pieceCurrentLoc["goblet"] = locations[currentloc + diceRoll];
    //     }

    //     moving = false;
    // }

    IEnumerator move(){
        moving = true;
        currentloc = System.Array.IndexOf(locations, pieceCurrentLoc["goblet"]);
        // 
        if ((System.Array.IndexOf(locations, pieceCurrentLoc["goblet"]) + diceRoll) > 39){
            moveindex = (System.Array.IndexOf(locations, pieceCurrentLoc["goblet"]) + diceRoll) - 40;
           Debug.Log(moveindex);
        } else {
            moveindex = currentloc + diceRoll;
        }
        while (pieces[0].transform.position != locations[moveindex].transform.position){
            pieces[0].transform.position = Vector3.MoveTowards(pieces[0].transform.position, locations[moveindex].transform.position, 0.5f);
            // my_dict[testpiece];
            yield return null;
        }

        if (pieces[0].transform.position == locations[moveindex].transform.position) {
            pieceCurrentLoc["goblet"] = locations[moveindex];
        }

        moving = false;
    }

}
