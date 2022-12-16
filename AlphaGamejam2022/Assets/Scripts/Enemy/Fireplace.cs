using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    [SerializeField] private int maxheat;
    [SerializeField] private int heat;
    [SerializeField] private int maxrangeRadius;
    [SerializeField] private int rangeRadius;
    [SerializeField] Transform firePlaceTransform;

    // Start is called before the first frame update
    void Start()
    {
        heat = maxheat;
        rangeRadius = maxrangeRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        UpdateFireRange();
    }

    public void AddHeat(int heatbonus)
    {
        this.heat += heatbonus;
        if (heat > maxheat)
            this.heat = maxheat;
        UpdateFireRange();
    }

    public void CoolDown(){

    }

    public bool CheckIfGameOver(){
        if(heat <= 0)
            return true;
        return false;
    }
}
