using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    [SerializeField] private int heat;
    [SerializeField] private int maxrangeRadius;
    [SerializeField] private int rangeRadius;
    [SerializeField] Transform firePlaceTransform;

    // Start is called before the first frame update
    void Start()
    {
        rangeRadius = maxrangeRadius;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFireRange();
    }

    private void UpdateFireRange()
    {
        rangeRadius = maxrangeRadius * heat / 100;
        firePlaceTransform.localScale = new Vector2(rangeRadius, rangeRadius);
    }


    public void ReduceHeat(){
        if(heat >= 10){
            heat -= 10;
        }else if(heat < 0){
            heat = 0;
        }
    }

    public void CoolDown(){

    }

    public bool CheckIfGameOver(){
        if(heat <= 0)
            return true;
        return false;
    }
}
