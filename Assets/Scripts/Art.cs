using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Art
{
    private int id;
    private string author;
    private string year;
    private string room;
    private string description;
    private List<string> tips;

    public Art(int id, string author, string year, string room, string description, List<string> tips)
    {
        this.id = id;
        this.author = author;
        this.year = year;
        this.room = room;
        this.description = description;
        this.tips = tips;
    }

    public int getID()
    {
        return id;
    }

    public string getAuthor()
    {
        return author;
    }

    public string getYear()
    {
        return year;
    }

    public string getRoom()
    {
        return room;
    }
    public string getDescription()
    {
        return description;
    }

    public List<string> getTips()
    {
        return tips;
    }
}
