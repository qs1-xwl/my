Candy Tileset
=============

58 cartoon tiles for light interfaces — warm cream with bubblegum pink
accents. SVG plus transparent PNG at 1x, 2x and 4x.

Candy Tileset is a set of 58 tiles drawn in the cartoon style, where a heavy
clean outline wraps a glossy face with a single sparkle. It contains a 47-mask
autotile set, ground and wall variations, edge and corner pieces, grid-aligned
props and an assembled sheet.

A tileset is only a tileset if the tiles actually connect. Most free sets are
a folder of squares that look related and line up almost everywhere, and the
almost is what costs an afternoon: one edge mask is off by a pixel and the
seam shows on every wall in the level.

The gloss is a hard-edged split at 44% of the height, not a smooth gradient: a
soft fade reads as glass, a hard split reads as drawn. The offset drop shadow
is solid rather than blurred for the same reason.

Inside that style this is the Candy reading of it: a light interface on a warm
cream palette with bubblegum pink accents, built around two concentric frames,
fully rounded pill buttons at 168x56, banded bars divided into 6 segments, and
solid icons on a 32px grid. Those measurements are why two families can share
an art style without being interchangeable: the style decides how an edge is
drawn, the numbers decide what the interface is for.

The autotile masks are generated from the same edge geometry rather than drawn
one at a time, so a tile and its neighbour share the exact border by
construction rather than by care. Ground variations are drawn to be
interchangeable at any position, which is what stops a large floor reading as
a repeating pattern.

Every sprite ships as an editable SVG and as transparent PNG at 1x, 2x and 4x,
so you can drop the PNGs straight into an engine or open the vector and change
a colour. Built to the same measurements as the rest of the Candy family,
which means this kit and the Candy panel kit line up without either being
resized. A good fit for anime and cartoon games.

HOW TO USE

  - Import the sheet with the tile size the specs box names and no padding or
    extrusion; the tiles are drawn to the grid edge on purpose so adjacent
    tiles meet exactly.
  - Map the autotile masks by their bitmask number — the file names are the
    mask value, so a standard blob autotile setup wires up without a lookup
    table.
  - Scale by whole numbers only. A tileset at 1.5x lands tile edges on half
    pixels and produces a seam that is not in the art.

License: CC-BY-4.0 — see LICENSE.txt
Page: https://www.colorosse.com/assets/2d/tilesets/candy-tileset
More free assets: https://www.colorosse.com
