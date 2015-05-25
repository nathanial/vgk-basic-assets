using VGK;

namespace VGKBasicAssets {
  public class Cobblestone : VoxelDefinition {
    public Cobblestone(){
      AllImages = "voxels/inanimate/cobblestone/cobblestone.png";
      Hardness = Hardness.Strong;
    }
  }

  public class CobblestoneMossy : VoxelDefinition {
    public CobblestoneMossy(){
      AllImages = "voxels/inanimate/cobblestone/cobblestone_mossy.png";
      Hardness = Hardness.Normal;
      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Life,
        Value = 1,
        EmitTo = ManaZone.Ambient
      });
    }
  }
}
