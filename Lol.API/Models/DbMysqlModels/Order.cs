using System;
using System.Collections.Generic;

namespace Lol.API.Models.DbMysqlModels;

public partial class Order
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Role { get; set; }

    public string Lane { get; set; }

    public int Difficulty { get; set; }

    public int BlueEssence { get; set; }

    public string DamageType { get; set; }

    public string Images { get; set; }

    public string Description { get; set; }
}
