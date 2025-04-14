namespace Fighters.Models.Weapons;
public static class WeaponFactory
{
    public static IWeapon CreateWeapon( string type )
    {
        return type switch
        {
            "топор" => new Axe(),
            "лук" => new Bow(),
            "кулаки" => new Firsts(),
            "посох" => new Staff(),
            "меч" => new Sword(),
            _ => throw new ArgumentException( "Неверный ввод. Попробуйте снова" )
        };
    }
}
