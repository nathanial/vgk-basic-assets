using VGK;

namespace VGKBasicAssets {

  public class Coal : VoxelDefinition {
    public Coal(){
      AllImages = "voxels/inanimate/coal/coal_block.png";
      Actions.Add(new Burn {
        Output = ManaKind.Fire,
        Energy = 1000,
        Rate = 10
      });
    }
  }

  public class CoalOre : VoxelDefinition {
    public CoalOre(){
      AllImages = "voxels/inanimate/coal/coal_ore.png";
      Hitpoints = 4;
      Actions.Add(new Mine<Coal> {
        Quantity = 4
      });
    }
  }
}
