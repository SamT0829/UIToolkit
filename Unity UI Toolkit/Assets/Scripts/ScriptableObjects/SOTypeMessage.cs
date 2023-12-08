using System;
using UnityEngine;

[Serializable]
public struct CurrencyIcon
{
    public Sprite icon;
    public CurrencyType currencyType;
}

[Serializable]
public struct ShopItemTypeIcon
{
    public Sprite icon;
    public ShopItemType shopItemType;
}

[Serializable]
public struct CharacterClassIcon
{
    public Sprite icon;
    public CharacterClass characterClass;
}

[Serializable]
public struct RarityIcon
{
    public Sprite icon;
    public Rarity rarity;
}

[Serializable]
public struct AttackTypeIcon
{
    public Sprite icon;
    public AttackType attackType;
}

// type of currency used to purchase
[Serializable]
public enum CurrencyType
{
    Gold,
    Gems,
    // use real money to buy gems
    USD
}

// what player is buying
[System.Serializable]
public enum ShopItemType
{
    // soft currency (in-game)
    Gold,

    // hard currency (buy with real money)
    Gems,

    // used in gameplay
    HealthPotion,

    // levels up the character (PowerPotion)
    LevelUpPotion
}

public enum CharacterClass
{
    Paladin,
    Wizard,
    Barbarian,
    Necromancer
}
public enum Rarity
{
    Common,
    Rare,
    Special,
    All, // for filtering
}

public enum AttackType
{
    Melee,
    Magic,
    Ranged
}