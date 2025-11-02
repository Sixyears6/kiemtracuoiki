using System.Drawing;

namespace kiemtra
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }
        public bool[] Walls { get; set; } = { true, true, true, true };
        public bool Visited { get; set; } = false;

        public Cell? Parent { get; set; } = null;
        public bool IsPath { get; set; } = false;
        public bool IsActiveNode { get; set; } = false;

        // === THUỘC TÍNH MỚI ĐỂ LƯU MÀU SẮC ===
        public Brush? VisitedByBrush { get; set; } = null;

        // === MÀU SẮC ĐỊNH NGHĨA SẴN ===
        public static Brush BfsBrush = Brushes.LightBlue;
        public static Brush DfsBrush = Brushes.LightPink;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics g, int cellSize)
        {
            int xPos = X * cellSize;
            int yPos = Y * cellSize;
            
            if (IsPath)
                g.FillRectangle(Brushes.Yellow, xPos, yPos, cellSize, cellSize);
            else if (IsActiveNode)
                g.FillRectangle(Brushes.Cyan, xPos, yPos, cellSize, cellSize);
            else if (VisitedByBrush != null)
            {
                // Dùng màu đã được gán để tô
                g.FillRectangle(VisitedByBrush, xPos, yPos, cellSize, cellSize);
            }
            
            // Vẽ tường
            if (Walls[0]) g.DrawLine(Pens.Black, xPos, yPos, xPos + cellSize, yPos);
            if (Walls[1]) g.DrawLine(Pens.Black, xPos + cellSize, yPos, xPos + cellSize, yPos + cellSize);
            if (Walls[2]) g.DrawLine(Pens.Black, xPos, yPos + cellSize, xPos + cellSize, yPos + cellSize);
            if (Walls[3]) g.DrawLine(Pens.Black, xPos, yPos, xPos, yPos + cellSize);
        }
    }
}