using Fighters.Models.Armors;
using Fighters.Models.Fighter;
using Fighters.Models.FighterClass;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Creator;
public class ConsoleFighterCreator : IConsoleFighterCreator
{
    private readonly List<IFighter> _fighters = new List<IFighter>();
    public void CreateFighter()
    {
        Console.WriteLine( "Создание нового бойца:" );
        Console.Write( "Введите имя бойца: " );
        string name = Console.ReadLine();

        IRace race = ChooseRace();
        IWeapon weapon = ChooseWeapon();
        IArmor armor = ChooseArmor();
        IFighterClass fighterClass = ChooseFighterClass();
        IFighter fighter = new Fighter( name, race, fighterClass, weapon, armor );
        _fighters.Add( fighter );

        Console.WriteLine( $"\nБоец {name} успешно создан!" );
        fighter.DisplayStats();
    }
    public List<IFighter> GetFighters()
    {
        return _fighters.ToList();
    }
    private IFighterClass ChooseFighterClass()
    {
        bool isValidChoise = false;
        IFighterClass fighterClass = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Выберите класс:\n" +
                "1 - Рыцарь (Бонус здоровья: 50, Бонус урона: 5, Бонус брони: 3, Бонус инициативы: 2, Крит шанс: 0.10, Блок щитом (шанс 25% уменьшить урон на 50%))\n" +
                "2 - Берсерк (Бонус здоровья: 30, Бонус урона: 10, Бонус брони: 0, Бонус инициативы: 4, Крит шанс: 0.20, Ярость (при здоровье <30% урон +30%))\n" +
                "3 - Лучник (Бонус здоровья: 10, Бонус урона: 12, Бонус брони: -2, Бонус инициативы: 3, Крит шанс: 0.25, Меткий выстрел (шанс 15% на двойной урон))\n" +
                "4 - Маг (Бонус здоровья: 50, Бонус урона: 5, Бонус брони: 3, Бонус инициативы: 2, Крит шанс: 0.10, Магический щит (поглощает 20% урона)))\n" +
                "5 - Разбойник (Бонус здоровья: 25, Бонус урона: 7, Бонус брони: 2, Бонус инициативы: 8, Крит шанс: 0.30, Скрытая атака (первый удар в бою всегда критический))\n" +
                "6 - Паладин (Бонус здоровья: 60, Бонус урона: 6, Бонус брони: 5, Бонус инициативы: 1, Крит шанс: 0.08, Божественное исцеление (восстанавливает 10% здоровья за ход))\n";
            Console.WriteLine( message );
            string value = CheckTheValue( "Боец не может не иметь класс. Выберите класс бойца:" );
            switch ( value )
            {
                case "1":
                    fighterClass = new Knight();
                    break;
                case "2":
                    fighterClass = new Berserker();
                    break;
                case "3":
                    fighterClass = new Archer();
                    break;
                case "4":
                    fighterClass = new Mage();
                    break;
                case "5":
                    fighterClass = new Rogue();
                    break;
                case "6":
                    fighterClass = new Paladin();
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    isValidChoise = false;
                    break;
            };
        }

        return fighterClass;
    }

    private string CheckTheValue( string message )
    {
        string value = Console.ReadLine();
        while ( string.IsNullOrEmpty( value ) )
        {
            Console.WriteLine( message );
            value = Console.ReadLine();
        }
        return value;
    }

    private IRace ChooseRace()
    {
        IRace race = null;
        bool isValidChoise = false;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string messageRaceMenu = "Выберите расу:\n" +
                "1 - Человек (Здоровье: 100, Урон: 5, Броня: 2, Инициатива: 5)\n" +
                "2 - Эльф (Здоровье: 80, Урон: 7, Броня: 1, Инициатива: 8)\n" +
                "3 - Орк (Здоровье: 120, Урон: 8, Броня: 3, Инициатива: 3)\n" +
                "4 - Гном (Здоровье: 90, Урон: 6, Броня: 5, Инициатива: 4)\n" +
                "5 - Дракон (Здоровье: 125, Урон: 9, Броня: 6, Инициатива: 4)\n" +
                "6 - Нежить (Здоровье: 70, Урон: 6, Броня: 0, Инициатива: 6)\n" +
                "7 - Демон (Здоровье: 85, Урон: 10, Броня: 1, Инициатива: 7)\n" +
                "8 - Ангел (Здоровье: 110, Урон: 7, Броня: 4, Инициатива: 6)\n";
            Console.WriteLine( messageRaceMenu );
            string value = CheckTheValue( "Боец не может не иметь расу. Выберите расу бойца:" );
            switch ( value )
            {
                case "1":
                    race = new Human();
                    break;
                case "2":
                    race = new Elf();
                    break;
                case "3":
                    race = new Orc();
                    break;
                case "4":
                    race = new Dwarf();
                    break;
                case "5":
                    race = new Dragon();
                    break;
                case "6":
                    race = new Undead();
                    break;
                case "7":
                    race = new Demon();
                    break;
                case "8":
                    race = new Angel();
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    isValidChoise = false;
                    break;
            };
        }

        return race;
    }

    private IWeapon ChooseWeapon()
    {
        IWeapon weapone = null;
        bool isValidChoise = false;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Выберите оружие:\n" +
                "Меч (Урон: 10, Крит шанс: 5, Эффект: Нет, Редкость: обычная)\n" +
                "Топор (Урон: 12, Крит шанс: 5, Эффект: Нет, Редкость: обычная)\n" +
                "Лук (Урон: 8, Крит шанс: 10, Эффект: Нет, Редкость: обычная)\n" +
                "Кулаки (Урон: 1, Крит шанс: 0, Эффект: Нет, Редкость: обычная)\n" +
                "Посох (Урон: 6, Крит шанс: 2, Эффект: Нет, Редкость: обычная)\n" +
                "Чтобы создать огненное оружие, которое будет наносить +5 урона противнику каждый раунд, введите перед названием слово \"Огненный\" (Например: Огненный меч (Урон: 15, Крит шанс: 5, Эффект: Поджигает врага, Редкость: эпический)\n" +
                "Чтобы создать огненное оружие, которое будет красть 30% от здоровья противника, введите перед названием слово \"Вампирский\" (Например: Вампирский топор (Урон: 12, Крит шанс: 5, Эффект: Кража здоровья 20%, Редкость: эпический)\n";
            Console.WriteLine( message );
            string value = CheckTheValue( "Обязательно выберите оружие для бойца:" );
            value = value.ToLower();
            string[] values = value.Split( new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
            try
            {
                if ( !value.Contains( "огненный" ) && !value.Contains( "вампирский" ) )
                {
                    weapone = WeaponFactory.CreateWeapon( value );
                    return weapone;
                }
                else
                {
                    if ( value.Contains( "огненный" ) && !value.Contains( "вампирский" ) )
                    {
                        weapone = WeaponFactory.CreateWeapon( values[ 1 ] );
                        var fireWeapone = new FireEffectDecorator( weapone );
                        return fireWeapone;
                    }
                    else
                    {
                        if ( !value.Contains( "огненный" ) && value.Contains( "вампирский" ) )
                        {
                            weapone = WeaponFactory.CreateWeapon( values[ 1 ] );
                            var lifestealWeapone = new LifestealDecorator( weapone, 30 );
                            return lifestealWeapone;
                        }
                        else
                        {
                            Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                            isValidChoise = false;
                        }
                    }

                }
            }
            catch ( Exception e )
            {
                Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                isValidChoise = false;
            }
        }

        return weapone;
    }

    private IArmor ChooseArmor()
    {
        IArmor armor = null;
        bool isValidChoise = false;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Выберите броню:\n" +
                "1 - Без брони (Защита: 0, Эффект: +15% уклонение)\n" +
                "2 - Кожаная броня (Защита: 8, Эффект: +10% уклонение)\n" +
                "3 - Кольчужная рубаха (Защита: 12, Эффект: Нет)\n" +
                "4 - Чешуйчатый доспех (Защита: 15, Эффект: -20% крит урон)\n" +
                "5 - Латы (Защита: 22, Эффект: Блокирует 10% урона)\n" +
                "6 - Мантия мага (Защита: 5, Эффект: +20% маг.защита)\n" +
                "7 - Драконий доспех (Защита: 20, Эффект: Блокирует 30% урона)\n" +
                "8 - Проклятая броня (Защита: 25, Эффект: Постепенно уменьшает здоровье владельца на 10 единиц)\n";

            Console.WriteLine( message );
            string value = CheckTheValue( "Обязательно выберите броню для бойца:" );
            switch ( value )
            {
                case "1":
                    armor = new NoArmor();
                    break;
                case "2":
                    armor = new LeatherArmor();
                    break;
                case "3":
                    armor = new ChainShirt();
                    break;
                case "4":
                    armor = new ScaleMail();
                    break;
                case "5":
                    armor = new Plate();
                    break;
                case "6":
                    armor = new MageRobe();
                    break;
                case "7":
                    armor = new DragonScaleArmor();
                    break;
                case "8":
                    armor = new CursedArmor();
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    isValidChoise = false;
                    break;
            };
        }

        return armor;
    }
}