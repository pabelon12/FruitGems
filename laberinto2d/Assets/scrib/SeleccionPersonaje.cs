using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour
{
    public enum Player { Zorro,pickMan, ardilla, MaskDude };//Player de selecion 
    public Player SelecionPlayer;// menu de opciones ;

    public Animator animar;//Poner el arbol animacion 
    public SpriteRenderer Selecionsprite; // para selecionar los sprite
                              
    public RuntimeAnimatorController[] ControlarPlayer;//Controlar el player 
    public Sprite[] usoSprite;// usar 

    void Start()
    {
        switch (SelecionPlayer)
        {
            case Player.Zorro:
                Selecionsprite.sprite = usoSprite[0];
                animar.runtimeAnimatorController = ControlarPlayer[0];
                break;
            case Player.pickMan:
                Selecionsprite.sprite = usoSprite[1];
                animar.runtimeAnimatorController = ControlarPlayer[1];
                break;
            case Player.ardilla:
                Selecionsprite.sprite = usoSprite[2];
                animar.runtimeAnimatorController = ControlarPlayer[2];
                break;
            case Player.MaskDude:
                Selecionsprite.sprite = usoSprite[3];
                animar.runtimeAnimatorController = ControlarPlayer[3];
                break;
            default:
                break;
        }
    }

}
