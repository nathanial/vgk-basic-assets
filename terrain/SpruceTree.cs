using UnityEngine;
using VGK.Entities;
using VGK.Modules;
using VGK;

namespace VGKBasicAssets {

  [PostRealmGen]
  [Frequency(0.01)]
  [Organic]
  [GrowsOn("Grass", "Dirt")]
  public class SpruceTree : VoxelItem {
    public override bool Create(Entity entity){
      var SPRUCE_LOG = Assets.Voxels["Spruce Log"].Block;
      var SPRUCE_LEAVES = Assets.Voxels["Spruce Leaves"].Block;
      for(var y = 0; y < 10; y++){
        entity[1,y,1] = SPRUCE_LOG;
        if(y > 3){
          for(var x = -1; x < 4; x++){
            for(var z = -1; z < 4; z++){
              if(x == 1 && z == 1){
                continue;
              }
              entity[x,y,z] = SPRUCE_LEAVES;
            }
          }
        }
      }
      return true;
    }

    public override void Update(){

    }
  }
}
