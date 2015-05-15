from VGK.Modules import TerrainGenerator, Assets
from VGK import World, Chunk
from SimplexNoise import Noise
from UnityEngine import Random, Vector3, Mathf, Debug
from System import Random


class IslandTerrain(TerrainGenerator):

    def __init__(self):
        self.ViewDistance = 400
        self.random = Random()
        random = self.random
        self.grain_0_offset = Vector3(random.NextDouble() * 10000.0, random.NextDouble() * 10000.0, random.NextDouble() * 10000.0)
        self.grain_1_offset = Vector3(random.NextDouble() * 10000.0, random.NextDouble() * 10000.0, random.NextDouble() * 10000.0)
        self.grain_2_offset = Vector3(random.NextDouble() * 10000.0, random.NextDouble() * 10000.0, random.NextDouble() * 10000.0)


    def CreateVoxels(self, chunk):
        random = self.random
        grain_0_offset = self.grain_0_offset
        grain_1_offset = self.grain_1_offset
        grain_2_offset = self.grain_2_offset

        height_base = 10.0
        max_height = 50.0
        height_swing = max_height - height_base

        GRASS = Assets.Voxels['Grass'].Block
        DIRT = Assets.Voxels['Dirt'].Block
        STONE = Assets.Voxels['Stone'].Block

        x = 0
        while x < Chunk.Width:
            y = 0
            while y < Chunk.Height:
                z = 0
                while z < Chunk.Width:
                    pos = Vector3(x,y,z) + chunk.Position.ToVector3()
                    mountain_value = self.CalculateNoiseValue(pos, grain_0_offset, 0.009)
                    distance_from_center = Mathf.Sqrt(pos.x * pos.x + pos.z * pos.z)

                    if mountain_value < 0:
                        mountain_value = 0

                    mountain_value *= height_swing
                    mountain_value += height_base
                    mountain_value -= (distance_from_center * distance_from_center) / (1500.0 * (self.ViewDistance / 200.0))

                    mountain_value += self.CalculateNoiseValue(pos, grain_1_offset, 0.05) * 2.5 - 1.25
                    if mountain_value >= (y + chunk.Position.y):
                        chunk.Voxels[self.GetIndex(x,y,z)] = GRASS
                        if y > 0 and chunk.Voxels[self.GetIndex(x,y-1,z)] == GRASS:
                            chunk.Voxels[self.GetIndex(x,y-1,z)] = DIRT
                    z += 1
                y += 1
            x += 1
