using VGK;

namespace VGKBasicAssets {

  public class Diamond : VoxelDefinition {
    public Diamond(){
      AllImages = "voxels/inanimate/diamond/diamond_block.png";
      Hardness = Hardness.VeryHard;
      Hitpoints = 10;
    }
  }

  public class DiamondOre : VoxelDefinition {
    public DiamondOre(){
      AllImages = "voxels/inanimate/diamond/diamond_ore.png";
      Hardness = Hardness.Hard;
    }
  }
}
