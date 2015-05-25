using VGK;

namespace VGKBasicAssets {
  public class CraftingTable : VoxelDefinition {
    public CraftingTable(){
      TopImage = "voxels/artificial/crafting_table/crafting_table_top.png";
      SideImage = "voxels/artificial/crafting_table/crafting_table_side.png";
      BottomImage = "voxels/artificial/crafting_table/planks_acacia.png";

      // Flammable = true;
      //
      // Characteristics.Add(new CraftingDevice {
      //   UI = "CraftingTable"
      // });
    }
  }
}
