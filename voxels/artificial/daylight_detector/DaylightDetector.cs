using VGK;

namespace VGKBasicAssets {
  public class DaylightDetector : VoxelDefinition {
    public DaylightDetector(){
      TopImage = "voxels/artificial/daylight_detector/daylight_detector_top.png";
      SideImage = "voxels/artificial/daylight_detector/daylight_detector_side.png";
      BottomImage = "voxels/artificial/daylight_detector/daylight_detector_top.png";

      Drains.Add(new ManaDrain {
        Mana = ManaKind.Luxen,
        Min = 0.0,
        Max = 0.01,
        Source = ManaZone.Ambient
      });

      Emitters.Add(new ManaEmitter {
        Mana = ManaKind.Luxen,
        ValueFunction = (entity, position) => {
          return Drains[0].FindValue(entity, position);
        },
        EmitTo = ManaZone.Connection
      });
    }
  }
}
