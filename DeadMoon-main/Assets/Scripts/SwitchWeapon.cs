
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapon : MonoBehaviour
{
    public int selectedWeapon = 0;
    private PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previusSelectWeapon = selectedWeapon;

        if(playerInput.OnFoot.Weapon1.IsPressed())
        {
            selectedWeapon = 0;
        }
        
        if(playerInput.OnFoot.Weapon2.IsPressed() && transform.childCount >=2)
        {
            selectedWeapon = 1;
        }



        if(previusSelectWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
        
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform )
        {
            if(i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i ++;
        }
    }
}
