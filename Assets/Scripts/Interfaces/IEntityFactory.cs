using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityFactory
{
    FieldEntity CreateItem(ItemConfig config);
    FieldEntity CreateSpawner(SpawnerConfig config);
    FieldEntity Create(ConfigBase config);
}
