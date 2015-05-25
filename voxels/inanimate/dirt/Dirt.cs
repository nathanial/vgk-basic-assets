using VGK;

namespace VGKBasicAssets {

  public class Dirt : VoxelDefinition {
    public Dirt(){
      Name = "Dirt";
      AllImages = "voxels/inanimate/dirt/dirt.png";
      Hardness = Hardness.Soft;
      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Earth,
        Value = 1,
        EmitTo = ManaZone.Connection | ManaZone.Ambient
      });
    }
  }

  public class Grass : VoxelDefinition {
    public Grass(){
      Name = "Grass";
      TopImage = "voxels/inanimate/dirt/grass_top.png";
      SideImage = "voxels/inanimate/dirt/grass_side.png";
      BottomImage = "voxels/inanimate/dirt/dirt.png";

      Hardness = Hardness.Soft;

      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Life,
        Value = 1,
        EmitTo = ManaZone.Connection | ManaZone.Ambient
      });

      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Earth,
        Value = 0.5,
        EmitTo = ManaZone.Connection | ManaZone.Ambient
      });
    }
  }

}
