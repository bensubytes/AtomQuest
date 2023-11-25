using UnityEngine;

public interface PlayerBaseState
{ 
    void EnterState(Playermovement player, float modifier);
   
    void Update(Playermovement player);
    
    void CheckIfIdle(Playermovement player);

    void Walk(Playermovement player);

    void Decelerate(Playermovement player);

}