using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
[Serializable]
public class ItemInfo
{
    private string title, smileType, company, fluffType, imgFull, imgThumb, description;
    private int modelNumber, quantity;
    private double price, rating, weight;
    

    public ItemInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Quantity { get; set; }
    public string Description { get; set; }
    public int ModelNumber { get; set; }
    public double Rating { get; set; }
    public double Weight { get; set; }

    public string Title { get; set; }
    public string SmileType { get; set; }
    public string Company { get; set; }
    public double Price { get; set; }
    public string ImgFull{ get; set; }
    public string ImgThumb { get; set; }
    public string FluffType { get; set; }
}