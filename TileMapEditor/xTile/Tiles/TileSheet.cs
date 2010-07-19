﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XTile.Dimensions;
using XTile.ObjectModel;

namespace XTile.Tiles
{
    [Serializable]
    public class TileSheet : DescribedComponent
    {
        private Map m_map;
        private string m_imageSource;
        private Size m_sheetSize;
        private Size m_tileSize;
        private Size m_margin;
        private Size m_spacing;

        public TileSheet(Map map, string imageSource, Size sheetSize, Size tileSize)
        {
            m_map = map;
            m_imageSource = imageSource;
            m_sheetSize = sheetSize;
            m_tileSize = tileSize;
            m_margin = m_spacing = Size.Zero;
        }

        public TileSheet(string id, Map map, string imageSource, Size sheetSize, Size tileSize)
            : base(id)
        {
            m_map = map;
            m_imageSource = imageSource;
            m_sheetSize = sheetSize;
            m_tileSize = tileSize;
            m_margin = m_spacing = Size.Zero;
        }

        public Rectangle GetTileImageBounds(int tileIndex)
        {
            int tileX = tileIndex % m_sheetSize.Width;
            int tileY = tileIndex / m_sheetSize.Width;
            Location location = new Location(
                m_margin.Width + (m_tileSize.Width + m_spacing.Width) * tileX,
                m_margin.Height + (m_tileSize.Height + m_spacing.Height) * tileY);

            return new Rectangle(location, m_tileSize);
        }

        public int GetTileIndex(Location pixelLocation)
        {
            int tileX = (pixelLocation.X - m_margin.Width) / (m_tileSize.Width + m_spacing.Width);
            int tileY = (pixelLocation.Y - m_margin.Height) / (m_tileSize.Height + m_spacing.Height);

            return tileY * m_sheetSize.Width + tileX;
        }

        public Map Map { get { return m_map; } }

        public string ImageSource
        {
            get { return m_imageSource; }
            set { m_imageSource = value; }
        }

        public Size SheetSize
        {
            get { return m_sheetSize; }
            set { m_sheetSize = value; }
        }

        public Size TileSize 
        {
            get { return m_tileSize; }
            set { m_tileSize = value; }
        }

        public Size Margin
        {
            get { return m_margin; }
            set { m_margin = value; }
        }

        public Size Spacing
        {
            get { return m_spacing; }
            set { m_spacing = value; }
        }

        public int TileCount
        {
            get
            {
                return m_sheetSize.Width * m_sheetSize.Height;
            }
        }
    }
}