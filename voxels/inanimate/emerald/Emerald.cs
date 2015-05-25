using VGK;

namespace VGKBasicAssets {
  public class Emerald : VoxelDefinition {
    public Emerald(){
      AllImages = "voxels/inanimate/emerald/emerald_block.png";
      Hardness = Hardness.VeryHard;
      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Luxen,
        Value = 2,
        EmitTo = ManaZone.Connection | ManaZone.Ambient
      });
      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Life,
        Value = 2,
        EmitTo = ManaZone.Connection | ManaZone.Ambient
      });
    }
  }

  public class EmeraldOre : VoxelDefinition {
    public EmeraldOre(){
      AllImages = "voxels/inanimate/emerald/emerald_ore.png";
      Hardness = Hardness.Hard;
      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Earth,
        Value = 2,
        EmitTo = ManaZone.Connection | ManaZone.Ambient
      });
    }
  }
}
