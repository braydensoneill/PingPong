using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHold : MonoBehaviour
{
    private enum Movement
    {
        playerUp = 0,
        playerDown = 1,
        enemyUp = 2,
        enemyDown = 3
    }

    private int currentMovement;
    public GameObject character;
    bool isPressed;

    void Update()
    {
       if(isPressed)
        {
            MoveCharacter();
        }
    }
    
    public void pointerDown()
    {
        isPressed = true;
    }

    public void pointerUp()
    {
        isPressed = false;
    }

    public void setCurrentMovement(int value)
    {
        currentMovement = value;
    }

    private void MoveCharacter()
    {
        if(currentMovement == (int)Movement.playerUp)
            character.GetComponent<CharacterController>().MoveUp();

        if (currentMovement == (int)Movement.playerDown)
            character.GetComponent<CharacterController>().MoveDown();

        if (currentMovement == (int)Movement.enemyUp)
            character.GetComponent<CharacterController>().MoveUp();

        if (currentMovement == (int)Movement.enemyDown)
            character.GetComponent<CharacterController>().MoveDown();
    }
}
