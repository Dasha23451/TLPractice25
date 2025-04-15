using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using Fighters.Models.FighterClass;
using Fighters.Extensions;

namespace Fighters.Models.Fighter;

public class Fighter : IFighter
{
    private readonly IRace _race;
    private readonly IFighterClass _class;
    private IWeapon _weapon;
    private IArmor _armor;
    private int _currentHealth;
    private readonly Random _random = new Random();
    private bool _firstStrike = true;
    private int _durability;

    public string Name { get; }
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _race.Health + _class.HealthBonus;
    public int TotalPower => _race.Damage + _weapon.Damage + _class.DamageBonus;
    public int TotalArmor => _race.Armor + _armor.ArmorValue + _class.ArmorBonus;
    public int Initiative => _race.Initiative + _class.InitiativeBonus;
    public bool IsAlive => this.IsAlive();

    public Fighter( string name, IRace race, IFighterClass fighterClass, IWeapon weapon, IArmor armor )
    {
        Name = name;
        _race = race;
        _class = fighterClass;
        _weapon = weapon;
        _armor = armor;
        _currentHealth = MaxHealth;
        _durability = armor.Durability;
    }

    public void Attack( IFighter target )
    {
        if ( !IsAlive || !target.IsAlive )
            return;

        int baseDamage = TotalPower;
        int effectiveDamage = Math.Max( baseDamage - target.TotalArmor / 2, 1 );
        double damageMultiplier = 0.8 + _random.NextDouble() * 0.3;
        int variedDamage = ( int )( effectiveDamage * damageMultiplier );

        bool isCritical = _random.Next( 100 ) < _weapon.CritChance || ( _class is Rogue && _firstStrike );
        int finalDamage = isCritical ? variedDamage * 2 : variedDamage;

        finalDamage = ApplyClassAbilities( finalDamage, target );

        Console.WriteLine( $"{Name} атакует {target.Name} и наносит {finalDamage} урона" +
                          ( isCritical ? " (КРИТИЧЕСКИЙ УРОН!)" : "" ) );

        target.TakeDamage( finalDamage );


        ApplyWeaponEffects( target );
        _firstStrike = false;
    }

    private int ApplyClassAbilities( int damage, IFighter target )
    {
        switch ( _class )
        {
            case Berserker berserker when CurrentHealth < MaxHealth * 0.3:
                damage = ( int )( damage * 1.3 );
                Console.WriteLine( $"{Name} впадает в ярость!" );
                break;

            case Mage mage:
                damage = ( int )( damage * 1.1 );
                break;

            case Archer archer when _random.Next( 100 ) < 15:
                damage *= 2;
                Console.WriteLine( $"{Name} совершает меткий выстрел!" );
                break;
        }
        return damage;
    }

    private void ApplyWeaponEffects( IFighter target )
    {
        if ( _weapon is FireEffectDecorator )
        {
            int burnDamage = 10;
            target.TakeDamage( burnDamage );
            Console.WriteLine( $"{target.Name} получает этот урон от поджигания!" );
        }

        if ( _weapon is LifestealDecorator lifestealDecorator )
        {
            int lifestealAmount = ( int )( target.CurrentHealth * ( lifestealDecorator.LifestealPercent / 100.0 ) );
            _currentHealth = Math.Min( MaxHealth, _currentHealth + lifestealAmount );
            Console.WriteLine( $"{Name} восстанавливает {lifestealAmount} здоровья от кражи здоровья!" );
        }

        if ( !string.IsNullOrEmpty( _weapon.SpecialEffect ) )
        {
            Console.WriteLine( $"Эффект оружия: {_weapon.SpecialEffect}" );
        }
    }

    public void TakeDamage( int damage )
    {
        int finalDamage = ApplyClassDefenses( damage );
        finalDamage = _armor.CalculateDamageReduction( finalDamage );

        if ( _armor is not NoArmor )
        {
            _durability = Math.Max( 0, _durability - damage / 5 );
            if ( _durability == 0 )
            {
                Console.WriteLine( $"Броня {_armor.Name} полностью разрушена!" );
                _armor = new NoArmor();
            }
        }

        _currentHealth -= finalDamage;
        if ( _currentHealth < 0 )
            _currentHealth = 0;

        Console.WriteLine( $"{Name} получает {finalDamage} урона. Осталось здоровья: {CurrentHealth}/{MaxHealth}" );

        if ( !IsAlive )
        {
            Console.WriteLine( $"{Name} погибает!" );
        }

        ApplyClassDefenses( 0 );
    }




    private int ApplyClassDefenses( int damage )
    {
        int finalDamage = damage;

        switch ( _class )
        {
            case Knight knight when _random.Next( 4 ) == 0:
                finalDamage = damage / 2;
                Console.WriteLine( $"{Name} блокирует урон щитом!" );
                break;

            case Paladin paladin:
                int healAmount = MaxHealth / 10;
                if ( ( _currentHealth + healAmount ) < MaxHealth )
                {
                    _currentHealth = _currentHealth + healAmount;
                    Console.WriteLine( $"{Name} восстанавливает {healAmount} здоровья!" );
                }
                else
                {
                    healAmount = MaxHealth - _currentHealth;
                    _currentHealth = MaxHealth;
                    if ( healAmount != 0)
                    {
                        Console.WriteLine( $"{Name} восстанавливает {healAmount} здоровья!" );
                    }
                }
                break;

            case Mage mage:
                finalDamage = ( int )( damage * 0.8 );
                break;
        }

        return finalDamage;
    }


    public void DisplayStats()
    {
        Console.WriteLine( $"=== {Name} ===" );
        Console.WriteLine( $"Раса: {_race.Name}, Класс: {_class.Name}" );
        Console.WriteLine( $"Оружие: {_weapon.Name} (Урон: {_weapon.Damage}, Крит: {_weapon.CritChance}%)" );
        if ( _weapon is FireEffectDecorator )
        {
            Console.WriteLine( "Эффект: Огненное оружие (наносит 5 урона каждый раунд)" );
        }
        else if ( _weapon is LifestealDecorator lifestealDecorator )
        {
            Console.WriteLine( $"Эффект: Кража здоровья ({lifestealDecorator.LifestealPercent}% от урона)" );
        }
        else if ( !string.IsNullOrEmpty( _weapon.SpecialEffect ) )
        {
            Console.WriteLine( $"Эффект: {_weapon.SpecialEffect}" );
        }
        Console.WriteLine( $"Броня: {_armor.Name} (Защита: {_armor.ArmorValue}, Прочность: {( _armor is NoArmor ? "N/A" : _durability.ToString() )})" );
        Console.WriteLine( $"Здоровье: {CurrentHealth}/{MaxHealth}" );
        Console.WriteLine( $"Сила: {TotalPower}, Броня: {TotalArmor}" );
        Console.WriteLine( $"Инициатива: {Initiative}" );
        Console.WriteLine( $"Способность класса: {_class.SpecialAbility}" );
        Console.WriteLine( $"Эффект брони: {_armor.SpecialEffect}" );
        Console.WriteLine( $"Состояние: {( IsAlive ? "Жив" : "Мёртв" )}" );
        Console.WriteLine();
    }

}