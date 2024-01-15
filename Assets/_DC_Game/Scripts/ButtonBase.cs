using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;


public class ButtonBase : MonoBehaviour
{
    [SerializeField] private EnumButton enumButton;
    [SerializeField] private EnumGameCommand command;
    [SerializeField] private Button button;

    void Start()
    {
        UIManager.Ins.RegisterButton(enumButton, command, button);

        button.onClick.AddListener(() => SoundIn());
    }

    private void SoundIn()
    {
        SoundManager.Ins.PlaySound(EnumSFX.BUTTON_CLICK_SFX);
    }
}
