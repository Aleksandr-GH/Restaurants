﻿using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OpenData
{
    private FoodPlace[] restorans;
    private Dictionary<string, FoodPlace[]> foodPlaceSortedByType;

    public OpenData(string fileName)
    {
        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        string json = File.ReadAllText(fullPath, Encoding.UTF8);
        restorans = JsonConvert.DeserializeObject<FoodPlace[]>(json);

        string[] types = GetUniqueType();
        foodPlaceSortedByType = new Dictionary<string, FoodPlace[]>(types.Length);
        foreach(string type in types)
        {
            foodPlaceSortedByType[type.ToLower()] = FindFoodPlacesOnTypeObject(type);
        }
    }

    public FoodPlace[] GetFoodPlaces()
    {
        return restorans;
    }

    public FoodPlace[] FindFoodPlaces(string name, FoodPlace[] foodPlaces) //Делает поиск среди массива foodPlaces
    {
        if (name.Length > 0)
        {
            return foodPlaces.Where(food => food.Name.ToLower().Contains(name.ToLower())).ToArray();
        }
        else
        {
            return foodPlaces;
        }
    }

    private string[] GetUniqueType()
    {
        List<string> types = new List<string>();
        foreach (var x in restorans)
        {
            types.Add(x.TypeObject);
        }

        return types.Distinct().ToArray();
    }

    private FoodPlace[] FindFoodPlacesOnTypeObject(string typeObject)
    {
        return restorans.Where(food => food.TypeObject.ToLower().Contains(typeObject.ToLower())).ToArray();
    }

    public FoodPlace[] FindOnType(string typeObject)
    {
        return foodPlaceSortedByType[typeObject.ToLower()];
    }



}

public class PublicPhoneItem
{
    public string PublicPhone { get; set; }
}

public class FoodPlace
{

    public string Name { get; set; }

    public string IsNetObject { get; set; }

    public string TypeObject { get; set; }

    public string Address { get; set; }

    public List<PublicPhoneItem> PublicPhone { get; set; }

    public int SeatsCount { get; set; }

    public string SocialPrivileges { get; set; }
}