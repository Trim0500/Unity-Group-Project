using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //Declare Fields
    private string name;
    private string type;
    private int quantity;
    private double Mt;
    private bool openDoors;

    public void setName(String n)
    {
        this.name = n;
    }

    public String getName()
    {
        return name;
    }

    public void setType(String t)
    {
        this.type = t;
    }

    public String getType()
    {
        return type;
    }

    public void setQuantity(int q)
    {
        this.quantity = q;
    }

    public int getQuantity()
    {
        return quantity;
    }

    public void setMt(double M)
    {
        this.Mt = M;
    }

    public double getMt()
    {
        return Mt;
    }

    public void setOpenDoors(bool oD)
    {
        this.openDoors = oD;
    }

    public bool getOpenDoors()
    {
        return openDoors;
    }
}
