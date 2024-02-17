using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool playerOne;
    public PlayerData playerData;
    public CoinMeter coinMeter;

    private CharacterController characterController;

    //input keys
    private KeyCode upKey = KeyCode.UpArrow;
    private KeyCode downKey = KeyCode.DownArrow;
    private KeyCode rightKey = KeyCode.RightArrow;
    private KeyCode leftKey = KeyCode.LeftArrow;

    private KeyCode yellowKey = KeyCode.U;
    private KeyCode greenKey = KeyCode.I;
    private KeyCode blueKey = KeyCode.O;
    private KeyCode redKey = KeyCode.J;
    private KeyCode whiteKey = KeyCode.K;
    private KeyCode blackKey = KeyCode.L;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        coinMeter.meterAtZeroEvent += Die;
        InitializeInputKeyCodes();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        //movement
        if (Input.GetKey(upKey))
        {
            characterController.Move(transform.forward * (playerData.moveSpeed * Time.deltaTime));
        } else if(Input.GetKey(downKey))
        {
            characterController.Move(transform.forward * (-playerData.moveSpeed * Time.deltaTime));
        }

        //rotation
        if (Input.GetKey(rightKey))
        {
            transform.Rotate(new Vector3(0f, playerData.rotateSpeed * Time.deltaTime, 0f));
        } else if(Input.GetKey(leftKey))
        {
            transform.Rotate(new Vector3(0f, -playerData.rotateSpeed * Time.deltaTime, 0f));
        }

        //abilities
    }

    public void Damage(int delta)
    {
        coinMeter.ChangeMeter(-delta);
    }

    public void Heal(int delta)
    {
        coinMeter.ChangeMeter(delta);
    }

    public void Die()
    {
        Debug.Log("Dieded");
    }

    private void InitializeInputKeyCodes()
    {
        if (playerOne)
        {
            upKey = KeyCode.UpArrow;
            downKey = KeyCode.DownArrow;
            rightKey = KeyCode.RightArrow;
            leftKey = KeyCode.LeftArrow;

            yellowKey = KeyCode.U;
            greenKey = KeyCode.I;
            blueKey = KeyCode.O;
            redKey = KeyCode.J;
            whiteKey = KeyCode.K;
            blackKey = KeyCode.L;
        } else
        {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
            rightKey = KeyCode.D;
            leftKey = KeyCode.A;

            yellowKey = KeyCode.R;
            greenKey = KeyCode.T;
            blueKey = KeyCode.V;
            redKey = KeyCode.F;
            whiteKey = KeyCode.G;
            blackKey = KeyCode.H;
        }
    }

}
