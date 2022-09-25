using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material MaterialOutline;
    public Material MaterialDefault;
    public GameUI UI;

    Character _selectedCharacter;

    enum SelectionMode
    {
        Default,
        Attack
    }

    SelectionMode _currentMode = SelectionMode.Default;


    public void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                Character character = hit.collider.gameObject.GetComponent<Character>();

                if (character != null)
                {
                    if(_currentMode == SelectionMode.Default)
                    {
                        if (_selectedCharacter != null)
                            _selectedCharacter.Visual.material = MaterialDefault;


                        _selectedCharacter = character;
                        character.Visual.material = MaterialOutline;
                        UI.SetCharacter(character);
                    }
                    else
                    {
                        _selectedCharacter.Attack(character);
                    }
                }
            }
        }
    }

    public void SetAttackMode()
    {
        if (_selectedCharacter == null)
            return;

        _currentMode = SelectionMode.Attack;
    }
}
