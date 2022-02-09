using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointData : MonoBehaviour
{
    [SerializeField] private int _coinPointNum = 10;
    [SerializeField] private int _monsterPointNum = 20;
    [SerializeField] private int _ingredientPointNum = 30;
    [SerializeField] private int _healthPowerUpPointNum = 40;
    
    public int GetCoinPointNum() { return _coinPointNum; }
    public int GetIngredientPointNum() { return _ingredientPointNum; }
    public int GetMonsterPointNum() { return _monsterPointNum; }
    public int GetHealthPowerUpPointNum() { return _healthPowerUpPointNum; }

}
