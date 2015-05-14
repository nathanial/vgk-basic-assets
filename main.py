from VGK.Modules import VoxelLoader, Assets
from terrain.island_terrain import IslandTerrain

vloader = VoxelLoader()
vloader.LoadVoxels(plugin_folder + "/voxels")

Assets.TerrainGenerators.Add(IslandTerrain())
