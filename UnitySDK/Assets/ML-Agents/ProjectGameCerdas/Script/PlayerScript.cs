using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    int amo;
    int HP;
    int power;

    public void Update()
    {
        if(HP<=0)
        {       
            Debug.Log("I'm dead");
            Destroy(this.gameObject);
        }
    }
    public PlayerScript()
    {
        this.amo = 30;
        this.HP = 200;
        this.power = 10;
    }
    public int getAmo()
    {
        return this.amo;
    }

    public void setAmo(int bullet)
    {
        this.amo = this.amo + bullet; 
        if(this.amo > 30)
        {
            this.amo = 30;
        }
    }

    public void setHP(int power)
    {
        this.HP = HP + power;
    }

    public int getHP()
    {
        return this.HP;
    }

    public int getPower()
    {
        return this.power;
    }

    public void setPower(int power)
    {
        this.power = power;
    }
    public void attack(PlayerScript enemy)
    {
        enemy.setHP(power);
    }
}

