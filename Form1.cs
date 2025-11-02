using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiemtra
{
    // Lớp SearchThread giữ nguyên
    public class SearchThread
    {
        // ... Giữ nguyên như cũ ...
        public Queue<Cell>? BfsQueue { get; }
        public Stack<Cell>? DfsStack { get; }
        public Brush ThreadBrush { get; }
        public bool IsBfs => BfsQueue != null;
        public SearchThread(Brush brush) { BfsQueue = new Queue<Cell>(); ThreadBrush = brush; }
        public SearchThread(Brush brush, bool isDfs) { DfsStack = new Stack<Cell>(); ThreadBrush = brush; }
    }

    public partial class Form1 : Form
    {
        // ... Các biến thành viên giữ nguyên như cũ ...
        private Cell[,]? grid;
        private int mazeWidth, mazeHeight;
        private int cellSize = 25;
        private Random rand = new Random();
        private Stopwatch stopwatch = new Stopwatch();
        private bool _isSolving = false;
        private Cell? startCell, endCell;

        public Form1()
        {
            InitializeComponent();
        }

        // === SỰ KIỆN NÚT BẤM (Không thay đổi) ===
        private void btnGenerate_Click(object sender, EventArgs e) { /* ... Giữ nguyên như cũ ... */ _isSolving = false; if (!int.TryParse(txtWidth.Text, out mazeWidth) || mazeWidth <= 0) mazeWidth = 20; if (!int.TryParse(txtHeight.Text, out mazeHeight) || mazeHeight <= 0) mazeHeight = 20; txtWidth.Text = mazeWidth.ToString(); txtHeight.Text = mazeHeight.ToString(); InitializeGrid(); if (grid == null) return; GenerateMaze(grid[0, 0]); PickStartAndEndCells(); txtTimer.Text = "Thời gian: 0 ms"; SetControlsEnabled(true); pictureBoxMaze.Refresh(); }
        private async void btnBfs_Click(object sender, EventArgs e) { await SolveMaze("BFS"); }
        private async void btnDfs_Click(object sender, EventArgs e) { await SolveMaze("DFS"); }
        private async void btnHybridSearch_Click(object sender, EventArgs e) { await SolveMaze("HYBRID"); }

        // === PHƯƠNG THỨC GIẢI MÊ CUNG CHÍNH (Sửa lại như cũ) ===
        private async Task SolveMaze(string algorithm)
        {
            if (_isSolving || grid == null || startCell == null || endCell == null)
            {
                if (!_isSolving) MessageBox.Show("Vui lòng tạo mê cung trước!");
                return;
            }
            _isSolving = true;
            SetControlsEnabled(false);
            ResetSearchState();
            stopwatch.Restart();

            bool pathFound = false;

            // Quay lại việc gọi các hàm riêng biệt
            if (algorithm == "BFS") pathFound = await RunBFS_Animated();
            else if (algorithm == "DFS") pathFound = await RunDFS_Animated();
            else if (algorithm == "HYBRID") pathFound = await RunHybridSearch_Animated();

            stopwatch.Stop();
            txtTimer.Text = $"Thời gian: {stopwatch.Elapsed.TotalMilliseconds:F2} ms";

            if (pathFound) ReconstructPath();

            _isSolving = false;
            SetControlsEnabled(true);
            pictureBoxMaze.Refresh();
        }

        // === THUẬT TOÁN BFS (Giữ nguyên như code gốc của bạn) ===
        private async Task<bool> RunBFS_Animated()
        {
            if (startCell == null || endCell == null) return false;
            Queue<Cell> queue = new Queue<Cell>();
            startCell.VisitedByBrush = Cell.BfsBrush; // Màu xanh
            queue.Enqueue(startCell);
            while (queue.Count > 0 && _isSolving)
            {
                Cell current = queue.Dequeue();
                current.IsActiveNode = true;
                pictureBoxMaze.Refresh();
                await Task.Delay(101 - trackBarSpeed.Value);
                if (current == endCell) { current.IsActiveNode = false; return true; }
                foreach (var neighbor in GetPathfindingNeighbors(current))
                {
                    if (neighbor.VisitedByBrush == null)
                    {
                        neighbor.VisitedByBrush = Cell.BfsBrush; // Màu xanh
                        neighbor.Parent = current;
                        queue.Enqueue(neighbor);
                    }
                }
                current.IsActiveNode = false;
            }
            return false;
        }

        // === THUẬT TOÁN DFS (Giữ nguyên như code gốc của bạn) ===
        private async Task<bool> RunDFS_Animated()
        {
            if (startCell == null || endCell == null) return false;
            Stack<Cell> stack = new Stack<Cell>();
            startCell.VisitedByBrush = Cell.DfsBrush; // Màu hồng
            stack.Push(startCell);
            while (stack.Count > 0 && _isSolving)
            {
                Cell current = stack.Pop();
                current.IsActiveNode = true;
                pictureBoxMaze.Refresh();
                await Task.Delay(101 - trackBarSpeed.Value);
                if (current == endCell) { current.IsActiveNode = false; return true; }
                foreach (var neighbor in GetPathfindingNeighbors(current))
                {
                    if (neighbor.VisitedByBrush == null)
                    {
                        neighbor.VisitedByBrush = Cell.DfsBrush; // Màu hồng
                        neighbor.Parent = current;
                        stack.Push(neighbor);
                    }
                }
                current.IsActiveNode = false;
            }
            return false;
        }


        // === THUẬT TOÁN LAI (Giữ nguyên) ===
        private async Task<bool> RunHybridSearch_Animated()
        {
            // ... Mã nguồn của hàm này giữ nguyên như cũ, không thay đổi ...
            if (startCell == null || endCell == null) return false;
            var threads = new List<SearchThread>();
            var initialThread = new SearchThread(Cell.BfsBrush);
            initialThread.BfsQueue.Enqueue(startCell);
            threads.Add(initialThread);
            startCell.VisitedByBrush = Cell.BfsBrush;
            startCell.Parent = null;

            while (threads.Any() && _isSolving)
            {
                var newThreads = new List<SearchThread>();
                bool isNextBranchDfs = true;
                for (int i = threads.Count - 1; i >= 0; i--)
                {
                    var thread = threads[i];
                    Cell? current = null;
                    if (thread.IsBfs && thread.BfsQueue.Any()) current = thread.BfsQueue.Dequeue();
                    else if (!thread.IsBfs && thread.DfsStack.Any()) current = thread.DfsStack.Pop();
                    if (current == null) { threads.RemoveAt(i); continue; }
                    current.IsActiveNode = true;
                    pictureBoxMaze.Refresh();
                    await Task.Delay(101 - trackBarSpeed.Value);
                    if (current == endCell) { current.IsActiveNode = false; return true; }
                    var neighbors = GetPathfindingNeighbors(current).Where(n => n.VisitedByBrush == null).ToList();
                    if (neighbors.Count == 1)
                    {
                        var neighbor = neighbors.First();
                        neighbor.VisitedByBrush = thread.ThreadBrush;
                        neighbor.Parent = current;
                        if (thread.IsBfs) thread.BfsQueue.Enqueue(neighbor); else thread.DfsStack.Push(neighbor);
                    }
                    else if (neighbors.Count > 1)
                    {
                        foreach (var neighbor in neighbors)
                        {
                            SearchThread newThread;
                            if (isNextBranchDfs)
                            {
                                newThread = new SearchThread(Cell.DfsBrush, true);
                                newThread.DfsStack.Push(neighbor);
                            }
                            else
                            {
                                newThread = new SearchThread(Cell.BfsBrush);
                                newThread.BfsQueue.Enqueue(neighbor);
                            }
                            neighbor.VisitedByBrush = newThread.ThreadBrush;
                            neighbor.Parent = current;
                            newThreads.Add(newThread);
                            isNextBranchDfs = !isNextBranchDfs;
                        }
                        threads.RemoveAt(i);
                    }
                    current.IsActiveNode = false;
                }
                threads.AddRange(newThreads);
            }
            return false;
        }

        // ... Các hàm hỗ trợ khác không thay đổi ...
        private void SetControlsEnabled(bool enabled){ btnGenerate.Enabled = enabled; btnBfs.Enabled = enabled; btnDfs.Enabled = enabled; btnHybridSearch.Enabled = enabled; txtWidth.Enabled = enabled; txtHeight.Enabled = enabled; }
        private void ResetSearchState(){ if (grid == null) return; foreach (var cell in grid) { cell.VisitedByBrush = null; cell.Parent = null; cell.IsPath = false; cell.IsActiveNode = false; } }
        private void InitializeGrid(){ grid = new Cell[mazeWidth, mazeHeight]; for (int y = 0; y < mazeHeight; y++) { for (int x = 0; x < mazeWidth; x++) { grid[x, y] = new Cell(x, y); } } }
        private void GenerateMaze(Cell start){ Stack<Cell> stack = new Stack<Cell>(); start.Visited = true; stack.Push(start); while (stack.Count > 0) { Cell current = stack.Peek(); List<Cell> neighbors = GetGenerationNeighbors(current); if (neighbors.Count > 0) { Cell next = neighbors[rand.Next(neighbors.Count)]; RemoveWalls(current, next); next.Visited = true; stack.Push(next); } else { stack.Pop(); } } }
        private List<Cell> GetGenerationNeighbors(Cell cell){ List<Cell> neighbors = new List<Cell>(); if (grid == null) return neighbors; int x = cell.X; int y = cell.Y; if (y > 0 && !grid[x, y - 1].Visited) neighbors.Add(grid[x, y - 1]); if (x < mazeWidth - 1 && !grid[x + 1, y].Visited) neighbors.Add(grid[x + 1, y]); if (y < mazeHeight - 1 && !grid[x, y + 1].Visited) neighbors.Add(grid[x, y + 1]); if (x > 0 && !grid[x - 1, y].Visited) neighbors.Add(grid[x - 1, y]); return neighbors; }
        private void RemoveWalls(Cell a, Cell b){ int dx = a.X - b.X; if (dx == 1) { a.Walls[3] = false; b.Walls[1] = false; } else if (dx == -1) { a.Walls[1] = false; b.Walls[3] = false; } int dy = a.Y - b.Y; if (dy == 1) { a.Walls[0] = false; b.Walls[2] = false; } else if (dy == -1) { a.Walls[2] = false; b.Walls[0] = false; } }
        private void PickStartAndEndCells(){ if (grid == null) return; startCell = grid[rand.Next(mazeWidth), rand.Next(mazeHeight)]; do { endCell = grid[rand.Next(mazeWidth), rand.Next(mazeHeight)]; } while (startCell == endCell); }
        private List<Cell> GetPathfindingNeighbors(Cell cell){ List<Cell> neighbors = new List<Cell>(); if (grid == null) return neighbors; int x = cell.X; int y = cell.Y; if (y > 0 && !cell.Walls[0]) neighbors.Add(grid[x, y - 1]); if (x < mazeWidth - 1 && !cell.Walls[1]) neighbors.Add(grid[x + 1, y]); if (y < mazeHeight - 1 && !cell.Walls[2]) neighbors.Add(grid[x, y + 1]); if (x > 0 && !cell.Walls[3]) neighbors.Add(grid[x - 1, y]); return neighbors; }
        private void ReconstructPath(){ Cell? current = endCell; while (current != null) { current.IsPath = true; current = current.Parent; } }
        private void pictureBoxMaze_Paint(object sender, PaintEventArgs e){ if (grid == null) return; e.Graphics.Clear(Color.WhiteSmoke); for (int y = 0; y < mazeHeight; y++) { for (int x = 0; x < mazeWidth; x++) { grid[x, y].Draw(e.Graphics, cellSize); } } if (startCell != null) e.Graphics.FillRectangle(Brushes.Green, startCell.X * cellSize + 2, startCell.Y * cellSize + 2, cellSize - 4, cellSize - 4); if (endCell != null) e.Graphics.FillRectangle(Brushes.Red, endCell.X * cellSize + 2, endCell.Y * cellSize + 2, cellSize - 4, cellSize - 4); }
    }
}