using MasterCRM.Domain.Enums;

namespace MasterCRM.Application.MapExtensions;

public static class MaterialExtensions
{
    public static Material ConvertToMaterial(this string materialStr)
    {
        return materialStr.ToLower() switch
        {
            "дерево" => Material.Wood,
            "керамика" => Material.Ceramics,
            "кожа" => Material.Leather,
            "ткань" => Material.Fabric,
            "металл" => Material.Metal,
            "стекло" => Material.Glass,
            "резина" => Material.Rubber,
            "бумага" => Material.Paper,
            "камень" => Material.Stone,
            _ => throw new ArgumentException("Unknown material string argument: " + materialStr.ToLower())
        };
    }

    public static string ConvertToString(this Material material)
    {
        return material switch
        {
            Material.Wood => "Дерево",
            Material.Ceramics => "Керамика",
            Material.Leather => "Кожа",
            Material.Fabric => "Ткань",
            Material.Metal => "Металл",
            Material.Glass => "Стекло",
            Material.Rubber => "Резина",
            Material.Paper => "Бумага",
            Material.Stone => "Камень",
            _ => throw new Exception("Error when convert material to string: " + material)
        };
    }
}