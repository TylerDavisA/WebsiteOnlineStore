using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Hobbies
/// </summary>

[Serializable]
public class Hobbies
{
    private string sport, videoGame, job, collection;
    public Hobbies()
    {
    

    }

    public string Sport { get; set; }
    public string Job { get; set; }
    public string VideoGame { get; set; }
    public string Collection { get; set; }
}