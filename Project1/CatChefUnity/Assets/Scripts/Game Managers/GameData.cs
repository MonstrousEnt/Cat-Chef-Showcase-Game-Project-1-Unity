/* Project Name: Arcade 2D Platformer
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, Ben Topple
 * Created Date: January 30, 2022
 * Latest Update: February 11, 2022
 * Description: The class is the data for the game manager.
 * Notes: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //Class Variables
    [Header("Game Data Info")]
    [SerializeField] protected int ingredinetsNum = 0;
    [SerializeField] protected int maxIngredients;
    [SerializeField] protected List<bool> ingredinetImagesActive;
    [SerializeField] protected int coinNum;
    [SerializeField] protected Vector2 lastCheckpointPos;

    # region Getters and Setters
    public List<bool> GetIngredinetImagesActive() { return ingredinetImagesActive; }
    public int GetMaxIngredients() { return maxIngredients; }
    public int GetIngredinetsNum() { return ingredinetsNum; }
    public void SetIngredinetsNum(int ingredinetsNum) { this.ingredinetsNum = ingredinetsNum; }
    public void SetCoinNum(int coinNum) { this.coinNum = coinNum; }
    public int GetCoinNum() { return coinNum; }
    public Vector2 GetLastCheckpointPos() { return lastCheckpointPos; }
    public void SetLastCheckpointPos(Vector2 lastCheckpointPos) { this.lastCheckpointPos = lastCheckpointPos; }
    #endregion
}
